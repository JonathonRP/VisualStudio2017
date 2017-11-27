using System;
using System.Web;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Controls = System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.OleDb;
using System.Data.Entity;
using Data = System.ComponentModel.DataAnnotations;
using WPFdataGrid;


namespace Database_Pokedex_
{
    public partial class Form1 : Form
    {
        public PokemonBaseStat pokemon;

        private Pokemon Pokemon;

        private CancelEvent EventArgs = new CancelEvent();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Controls.DataGrid grid = dataGrid.grid;
            grid.MouseRightButtonUp += new MouseButtonEventHandler(dataGrid_MouseClick);
            grid.CurrentCellChanged += new EventHandler<EventArgs>(dataGrid_CellValueChanged);
        }

        private void dataGrid_CellValueChanged(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            var dataGridView = wPFdataGrid.grid;

            pokemon = new PokemonBaseStat()
            {
                PName = dataGridView.SelectedCells[0].Item.ToString(),
                Type1 = dataGridView.SelectedCells[7].Item?.ToString(),
                Type2 = dataGridView.SelectedCells[8].Item?.ToString()
            };

            //Data.ValidationContext Valid = new Data.ValidationContext(pokemon, null, null);
            //IList<Data.ValidationResult> errors = new List<Data.ValidationResult>();

            //if (!Data.Validator.TryValidateObject(pokemon, Valid, errors, true))
            //{
            //    dataGridView.Items[].ErrorText = null;
            //    EventArgs.Error = null;

            //    foreach (Data.ValidationResult result in errors)
            //    {
            //        EventArgs.Cancel = true;
            //        EventArgs.Error += $"{result.ErrorMessage}\n";
            //        dataGridView.Items[e.RowIndex].ErrorText += $"{result.ErrorMessage}\n";
            //    }
            //}
            //else
            //{
            //    EventArgs.Cancel = false;
            //    dataGridView.Items[].ErrorText = null;
            //}
        }

        private void dataGrid_MouseClick(object sender, MouseButtonEventArgs e)
        {
            WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            var dataGridView = wPFdataGrid.grid;

            DependencyObject Hit = (DependencyObject)e.OriginalSource;
            Controls.DataGridRow dataRow = Hit as Controls.DataGridRow;

            if (dataRow.GetIndex() == dataGridView.Items.Count - 2 && pokemon != null)
            {
                PokemonBaseStat monster;

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                var PName = properties["PName"].GetValue(dataRow.Item).ToString();

                try
                {
                    monster = (from p in Pokemon.PokemonBaseStats
                                where p.PName == PName
                                select p).First();
                }
                catch
                {
                    monster = null;
                }

                if (monster == null)
                {
                    contextMenuStrip.Items[0].Visible = true;
                    contextMenuStrip.Items[1].Visible = false;
                    contextMenuStrip.Items[2].Visible = false;
                    contextMenuStrip.Show(System.Windows.Forms.Cursor.Position);
                }
            }

            if (dataRow.GetIndex() < dataGridView.Items.Count - 1 && pokemon != null
                && System.Windows.Controls.Validation.GetHasError(dataGridView) == false)
            {
                PokemonBaseStat monster;

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                var PName = properties["PName"].GetValue(dataRow.Item).ToString();
                var Type1 = properties["Type1"].GetValue(dataRow.Item)?.ToString();
                var Type2 = properties["Type2"].GetValue(dataRow.Item)?.ToString();

                try
                {
                    monster = (from p in Pokemon.PokemonBaseStats
                                where p.PName == PName
                                select p).First();
                }
                catch
                {
                    monster = null;
                    return;
                }

                if (monster.PName == pokemon.PName
                    && (monster.Type1 != pokemon.Type1 || monster.Type2 != pokemon.Type2))
                {
                    contextMenuStrip.Items[0].Visible = false;
                    contextMenuStrip.Items[1].Visible = true;
                    contextMenuStrip.Items[2].Visible = false;
                    contextMenuStrip.Show(System.Windows.Forms.Cursor.Position);
                }
            }

            if (dataRow.GetIndex() < dataGridView.Items.Count - 1
                && System.Windows.Controls.Validation.GetHasError(dataGridView) == false)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                var PName = properties["PName"].GetValue(dataRow.Item).ToString();
                var Type1 = properties["Type1"].GetValue(dataRow.Item)?.ToString();
                var Type2 = properties["Type2"].GetValue(dataRow.Item)?.ToString();

                var monster = (from p in Pokemon.PokemonBaseStats
                                where p.PName == PName
                                select p).First();

                if (Type1 == "")
                {
                    Type1 = null;
                }

                if (Type2 == "")
                {
                    Type2 = null;
                }

                if (monster.PName == PName
                    && monster.Type1 == Type1 && monster.Type2 == Type2)
                {
                    contextMenuStrip.Items[0].Visible = false;
                    contextMenuStrip.Items[1].Visible = false;
                    contextMenuStrip.Items[2].Visible = true;
                    contextMenuStrip.Show(System.Windows.Forms.Cursor.Position);
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WPFdataGrid.UserControl1 wPFdataGrid = elementHost1.Child as WPFdataGrid.UserControl1;
            //var dataGridView = wPFdataGrid.grid;

            Pokemon = new Pokemon();

            if (EventArgs.Cancel != true)
            {
                //pokemon entity
                var pokemonToUpdate = from p in Pokemon.PokemonBaseStats
                                      where p.PName == pokemon.PName
                                      select p;

                foreach (var monster in pokemonToUpdate)
                {
                    if (pokemon.Type1 != "")
                    {
                        monster.Type1 = pokemon.Type1;
                    }
                    else if (pokemon.Type1 == "")
                    {
                        monster.Type1 = null;
                    }

                    if (pokemon.Type2 != "")
                    {
                        monster.Type2 = pokemon.Type2;
                    }
                    else if (pokemon.Type2 == "")
                    {
                        monster.Type2 = null;
                    }
                }

                try
                {
                    //dataGridView.CommitEdit();
                    //pokemon entity save changes
                    Pokemon.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($" Data: {ex.Data} \n Source: {ex.Source} \n " +
                        $"Message: {ex.Message} \n Inner Error: {ex.InnerException} \n Target Site: {ex.TargetSite} \n Stack Trace: {ex.StackTrace} \n " +
                        $"Result Code: {ex.HResult} \n {ex.HelpLink}");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(EventArgs.Error, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dispose of pokemon entity
            Pokemon.Dispose();
        }
    }

    public class CancelEvent : EventArgs
    {
        public bool Cancel { get; set; }

        public string Error { get; set; }
    }
}
