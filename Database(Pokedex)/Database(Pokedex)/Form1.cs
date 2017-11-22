using System;
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
using Database_Pokedex_;

namespace Database_Pokedex_
{
    public partial class Form1 : Form
    {
        private PokemonBaseStat pokemon;

        private Pokemon Pokemon;

        private CancelEvent EventArgs = new CancelEvent();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pokemon = new Pokemon();
            bindingSource1.DataSource = Pokemon.PokemonBaseStats.Local.ToBindingList();


            using (Pokemon db = new Pokemon())
            {
                var pokemon = (from p in db.PokemonBaseStats
                                select p).ToList();

                bindingSource1.DataSource = pokemon;
                dataGridView.DataSource = bindingSource1;
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            pokemon = new PokemonBaseStat()
            {
                PName = (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value.ToString(),
                Type1 = (sender as DataGridView).Rows[e.RowIndex].Cells[7].Value?.ToString(),
                Type2 = (sender as DataGridView).Rows[e.RowIndex].Cells[8].Value?.ToString()
            };

            //try catch

            ValidationContext Valid = new ValidationContext(pokemon, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(pokemon, Valid, errors, true))
            {
                (sender as DataGridView).Rows[e.RowIndex].ErrorText = null;
                EventArgs.Error = null;

                foreach (ValidationResult result in errors)
                {
                    EventArgs.Cancel = true;
                    EventArgs.Error += $"{result.ErrorMessage}\n";
                    (sender as DataGridView).Rows[e.RowIndex].ErrorText += $"{result.ErrorMessage}\n";
                }
            }
            else
            {
                EventArgs.Cancel = false;
                (sender as DataGridView).Rows[e.RowIndex].ErrorText = null;
            }
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if ((sender as DataGridView).HitTest(e.X, e.Y).RowIndex == dataGridView.RowCount - 2 && pokemon != null)
                {
                    PokemonBaseStat monster;

                    var PName = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString();

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
                        contextMenuStrip.Show(Cursor.Position);
                    }
                }

                if ((sender as DataGridView).HitTest(e.X, e.Y).RowIndex < dataGridView.RowCount - 1 && pokemon != null
                    && dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].ErrorText == string.Empty)
                {
                    PokemonBaseStat monster;

                    var PName = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString();
                    var Type1 = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[7].Value?.ToString();
                    var Type2 = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[8].Value?.ToString();

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
                        contextMenuStrip.Show(Cursor.Position);
                    }
                }

                if ((sender as DataGridView).HitTest(e.X, e.Y).RowIndex < dataGridView.RowCount - 1
                    && dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].ErrorText == string.Empty)
                {
                    string PName = string.Empty;
                    string Type1 = string.Empty;
                    string Type2 = string.Empty;

                    PName = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString();
                    Type1 = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[7].Value?.ToString();
                    Type2 = dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[8].Value?.ToString();

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
                        contextMenuStrip.Show(Cursor.Position);
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                    dataGridView.EndEdit();
                    //pokemon entity save changes
                    Pokemon.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($" Data: {ex.Data} \n Source: {ex.Source} \n " +
                        $"Message: {ex.Message} \n Inner Error: {ex.InnerException} \n Target Site: {ex.TargetSite} \n Stack Trace: {ex.StackTrace} \n " +
                        $"Result Code: {ex.HResult} \n {ex.HelpLink}");
                }
            }
            else
            {
                MessageBox.Show(EventArgs.Error, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
