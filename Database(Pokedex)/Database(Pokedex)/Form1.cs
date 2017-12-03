using System;
using System.Web;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Control = System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using System.ComponentModel.DataAnnotations;
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
            Control.DataGrid grid = dataGrid.grid;
            grid.IsReadOnly = true;
            grid.MouseRightButtonUp += new MouseButtonEventHandler(dataGrid_MouseRightClick);
            grid.CellEditEnding += new EventHandler<Control.DataGridCellEditEndingEventArgs>(dataGrid_CellValueChanged);
        }
        private void dataGrid_CellValueChanged(object sender, Control.DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == Control.DataGridEditAction.Commit)
            {
                WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
                var dataGridView = wPFdataGrid.grid;

                Control.DataGridRow dataRow = e.Row as Control.DataGridRow;

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                pokemon = new PokemonBaseStat()
                {
                    PName = properties["PName"].GetValue(dataRow.Item)?.ToString(),
                    Type1 = properties["Type1"].GetValue(dataRow.Item)?.ToString(),
                    Type2 = properties["Type2"].GetValue(dataRow.Item)?.ToString()
                };

                //System.Windows.Forms.MessageBox.Show($"Pokemon Name: {pokemon.PName}");

                //ValidationContext Valid = new ValidationContext(pokemon, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateProperty(GetType().GetProperty(e.Column.Header.ToString()).GetValue(pokemon), new ValidationContext(pokemon) { MemberName = e.Column.Header.ToString() }, errors))
                {
                    e.Cancel = true;
                    EventArgs.Cancel = true;
                    EventArgs.Error = null;

                    Control.DataErrorValidationRule validationRule = new Control.DataErrorValidationRule();

                    Control.ValidationError error = new Control.ValidationError(validationRule, dataRow.BindingGroup.BindingExpressions);

                    foreach (ValidationResult result in errors)
                    {
                        EventArgs.Error += $"{result.ErrorMessage}\n";

                        error.ErrorContent += $"{result.ErrorMessage}\n";
                    }

                    foreach (var binding in dataRow.BindingGroup.BindingExpressions)
                    {
                        Control.Validation.MarkInvalid(dataRow.BindingGroup.BindingExpressions.First(), error);

                        //dataRow.IsEnabled = false;
                    }
                }
                else
                {
                    Control.DataErrorValidationRule validationRule = new Control.DataErrorValidationRule();

                    Control.ValidationError error = new Control.ValidationError(validationRule, dataRow.BindingGroup.BindingExpressions);

                    e.Cancel = false;
                    dataRow.IsEnabled = true;
                    EventArgs.Cancel = false;
                    error.ErrorContent = null;
                }
            }
        }

        private void dataGrid_MouseRightClick(object sender, MouseButtonEventArgs e)
        {
            WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            var dataGridView = wPFdataGrid.grid;

            DependencyObject Hit = (DependencyObject)e.OriginalSource;

            while(Hit == null || !(Hit is Control.DataGridRow))
            {
                Hit = VisualTreeHelper.GetParent(Hit);
            }

            Control.DataGridRow dataRow = Hit as Control.DataGridRow;

            Pokemon = new Pokemon();

            if (dataRow.GetIndex() <= dataGridView.Items.Count - 2 && pokemon != null)
            {
                PokemonBaseStat monster;

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);
                
                var PName = properties["PName"].GetValue(dataRow.Item)?.ToString();

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

            if (dataRow.GetIndex() <= dataGridView.Items.Count - 2 && pokemon != null
                && Control.Validation.GetHasError(dataRow) == false)
            {
                PokemonBaseStat monster;

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                var PName = properties["PName"].GetValue(dataRow.Item)?.ToString();
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

            if (dataRow.GetIndex() <= dataGridView.Items.Count - 2
                && Control.Validation.GetHasError(dataRow) == false)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                var PName = properties["PName"].GetValue(dataRow.Item)?.ToString();
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
            WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            var dataGridView = wPFdataGrid.grid;

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
                    dataGridView.CommitEdit();
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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            using (Pokemon db = new Pokemon())
            {
                grid.ItemsSource = (from p in db.PokemonBaseStats
                                    select p).ToList();
            }
        }

        private int count = 0;

        private void EditDatabase_Click(object sender, EventArgs e)
        {
            count++;

            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            if (count % 2 == 0)
            {
                grid.IsReadOnly = true;
            }
            else
            {
                grid.IsReadOnly = false;
            }
        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
                Control.DataGrid grid = dataGrid.grid;

                var PName = (sender as ToolStripComboBox).Text;

                using (Pokemon db = new Pokemon())
                {
                    if (!(PName == null))
                    {
                        grid.ItemsSource = (from p in db.PokemonBaseStats
                                            where p.PName.StartsWith(PName)
                                            select p).ToList();
                    }
                    else
                    {
                        grid.ItemsSource = (from p in db.PokemonBaseStats
                                            select p).ToList();
                    }
                }

                if (!(PName == null) && !(toolStripComboBox1.Items.Contains(PName)))
                {
                    toolStripComboBox1.Items.Add(PName);
                }
            }
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }

    public class CancelEvent : EventArgs
    {
        public bool Cancel { get; set; }

        public string Error { get; set; }
    }
}
