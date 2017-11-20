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
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using System.Data.Objects.SqlClient;
using System.Data.Entity;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using Database_Pokedex_;

namespace CEdatabase
{
    public partial class Form1 : Form
    {
        //private string connection_string = ConfigurationManager.ConnectionStrings["PokemonDatabase"].ConnectionString;

        private PokemonBaseStat pokemon;

        //pokemon entity
        private PokemonEntity pokemonEntity;

        public Form1()
        {
            InitializeComponent();
        }

        private void Compare_Click(object sender, EventArgs e)
        {
            if (HP.Checked)
            {
                //using (OleDbConnection dbConnect = new OleDbConnection(connection_string))
                //{
                //    using (Pokemon db = new Pokemon(dbConnect))
                //    {
                //        bindingSource1.DataSource = (from p in db.PokemonBaseStats
                //                                     where p.HP < Convert.ToInt16(HPvalue.Value)
                //                                     select new { PName = p.PName, HP = p.HP }).ToList();
                //        bindingSource2.DataSource = (from p in db.PokemonBaseStats
                //                                     where p.HP >= Convert.ToInt16(HPvalue.Value)
                //                                     select new { PName = p.PName, HP = p.HP }).ToList();
                //    }
                //}

                //pokemon entity
                var control = Convert.ToInt16(HPvalue.Value);

                bindingSource1.DataSource = (from p in pokemonEntity.PokemonBaseStats
                                             where p.HP < control
                                             select new { PName = p.PName, HP = p.HP }).ToList();

                bindingSource2.DataSource = (from p in pokemonEntity.PokemonBaseStats
                                             where p.HP >= control
                                             select new { PName = p.PName, HP = p.HP }).ToList();

                dataGridView1.DataSource = bindingSource1;
                dataGridView2.DataSource = bindingSource2;
            }

            if (Attack.Checked)
            {
                //using (OleDbConnection dbConnect = new OleDbConnection(connection_string))
                //{
                //    using (Pokemon db = new Pokemon(dbConnect))
                //    {
                //        bindingSource1.DataSource = (from p in db.PokemonBaseStats
                //                                     where p.Attack < Convert.ToInt16(AttackValue.Value)
                //                                     select new { PName = p.PName, Attack = p.Attack }).ToList();

                //        bindingSource2.DataSource = (from p in db.PokemonBaseStats
                //                                     where p.Attack >= Convert.ToInt16(AttackValue.Value)
                //                                     select new { PName = p.PName, Attack = p.Attack }).ToList();
                //    }
                //}

                //pokemon entity
                var control = Convert.ToInt16(AttackValue.Value);

                bindingSource1.DataSource = (from p in pokemonEntity.PokemonBaseStats
                                             where p.Attack < control
                                             select new { PName = p.PName, Attack = p.Attack }).ToList();

                bindingSource2.DataSource = (from p in pokemonEntity.PokemonBaseStats
                                             where p.Attack >= control
                                             select new { PName = p.PName, Attack = p.Attack }).ToList();

                dataGridView1.DataSource = bindingSource1;
                dataGridView2.DataSource = bindingSource2;

                //below does the same as above^
                //dataAdapter = new OleDbDataAdapter(statement, connection_string);
                //dbCommandBuilder = new OleDbCommandBuilder(dataAdapter);

                //DataTable pokemon = new DataTable();

                //dataAdapter.Fill(pokemon);
                //dataGridView1.DataSource = pokemon;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            DataTable pokemons = new DataTable();

            //using (OleDbConnection dbConnect = new OleDbConnection(connection_string))
            //{
            //    using (Pokemon db = new Pokemon(dbConnect))
            //    {

            //          IEnumerable<string> pokemon_name = from p in db.PokemonBaseStats
            //                                   where p.PName.StartsWith(StartingTextSearch.Text)
            //                                   select p.PName;

            //          IEnumerable<string> pokemon_firstType = from p in db.PokemonBaseStats
            //                                        where p.PName.StartsWith(StartingTextSearch.Text)
            //                                        select p.Type1;

            //          IEnumerable<string> pokemon_secondType = from p in db.PokemonBaseStats
            //                                         where p.PName.StartsWith(StartingTextSearch.Text)
            //                                         select p.Type2;

            //    }
            //}

            //pokemon entity
            IEnumerable<string> pokemon_name = from p in pokemonEntity.PokemonBaseStats
                                               where p.PName.StartsWith(StartingTextSearch.Text)
                                               select p.PName;

            IEnumerable<string> pokemon_firstType = from p in pokemonEntity.PokemonBaseStats
                                                    where p.PName.StartsWith(StartingTextSearch.Text)
                                                    select p.Type1;

            IEnumerable<string> pokemon_secondType = from p in pokemonEntity.PokemonBaseStats
                                                     where p.PName.StartsWith(StartingTextSearch.Text)
                                                     select p.Type2;

            pokemons.Columns.Add("PName", typeof(string));
                    pokemons.Columns.Add("Type1", typeof(string));
                    pokemons.Columns.Add("Type2", typeof(string));

                    for (int i = 0; i < pokemon_name.Count(); i++)
                    {
                        DataRow row = pokemons.NewRow();
                        row["PName"] = pokemon_name.ElementAt(i);
                        row["Type1"] = pokemon_firstType.ElementAt(i);
                        row["Type2"] = pokemon_secondType.ElementAt(i);

                        pokemons.Rows.Add(row);
                    }

            bindingSource1.DataSource = pokemons;

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;

            dataGridView3.DataSource = bindingSource1;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //using (OleDbConnection dbConnect = new OleDbConnection(connection_string))
            //{
            //    using (Pokemon db = new Pokemon(dbConnect))
            //    {
            //          var pokemonToUpdate = from p in db.PokemonBaseStats
            //                                where p.PName == pokemon.PName
            //                                select p;
            //          
            //           db.Log = Console.Out;
            //           db.SubmitChanges();
            //    }
            //}

            //pokemon entity
            var pokemonToUpdate = from p in pokemonEntity.PokemonBaseStats
                                    where p.PName == pokemon.PName
                                    select p;

            foreach (var monster in pokemonToUpdate)
            {
                monster.PName = monster.PName;
                monster.HP = monster.HP;
                monster.Attack = monster.Attack;
                monster.Defense = monster.Defense;
                monster.SPAttack = monster.SPAttack;
                monster.SPDefense = monster.SPDefense;
                monster.Speed = monster.Speed;

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
                dataGridView3.EndEdit();
                //pokemon entity save changes
                pokemonEntity.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Data: {ex.Data} \n Source: {ex.Source} \n " +
                    $"Message: {ex.Message} \n Inner Error: {ex.InnerException} \n Target Site: {ex.TargetSite} \n Stack Trace: {ex.StackTrace} \n " +
                    $"Result Code: {ex.HResult} \n {ex.HelpLink}");
            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            pokemon = new PokemonBaseStat()
            {
                PName = (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value.ToString(),
                Type1 = (sender as DataGridView).Rows[e.RowIndex].Cells[1].Value.ToString(),
                Type2 = (sender as DataGridView).Rows[e.RowIndex].Cells[2].Value.ToString()
            };
        }

        private void dataGridView3_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            PokemonBaseStat monster = new PokemonBaseStat()
            {
                PName = (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value.ToString(),
                Type1 = (sender as DataGridView).Rows[e.RowIndex].Cells[1].Value.ToString(),
                Type2 = (sender as DataGridView).Rows[e.RowIndex].Cells[2].Value.ToString()
            };

            ValidationContext Valid = new ValidationContext(monster, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(monster, Valid, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    (sender as DataGridView).Rows[e.RowIndex].ErrorText = result.ErrorMessage;
                }

                e.Cancel = true;
            }
        }

        private void dataGridView3_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            (sender as DataGridView).Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            (sender as DataGridView).Rows[e.RowIndex].ErrorText = null;
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if ((sender as DataGridView).HitTest(e.X, e.Y).RowIndex == dataGridView3.RowCount - 2 && pokemon != null)
                {
                    PokemonBaseStat monster;

                    var PName = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString();

                    try
                    {
                        monster = (from p in pokemonEntity.PokemonBaseStats
                                       where p.PName == PName
                                       select p).First();
                    }
                    catch
                    {
                        monster = null;
                    }

                    if (monster == null)
                    {
                        contextMenuStrip1.Items[0].Visible = true;
                        contextMenuStrip1.Items[1].Visible = false;
                        contextMenuStrip1.Items[2].Visible = false;
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }

                if ((sender as DataGridView).HitTest(e.X, e.Y).RowIndex < dataGridView3.RowCount - 1 && pokemon != null)
                {
                    PokemonBaseStat monster;

                    var PName = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString();
                    var Type1 = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[1].Value.ToString();
                    var Type2 = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[2].Value.ToString();

                    try
                    {
                        monster = (from p in pokemonEntity.PokemonBaseStats
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
                        contextMenuStrip1.Items[0].Visible = false;
                        contextMenuStrip1.Items[1].Visible = true;
                        contextMenuStrip1.Items[2].Visible = false;
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }

                if ((sender as DataGridView).HitTest(e.X, e.Y).RowIndex < dataGridView3.RowCount - 1)
                {
                    var PName = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[0].Value.ToString();
                    var Type1 = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[1].Value.ToString();
                    var Type2 = dataGridView3.Rows[dataGridView3.HitTest(e.X, e.Y).RowIndex].Cells[2].Value.ToString();

                    var monster = (from p in pokemonEntity.PokemonBaseStats
                                   where p.PName == PName
                                   select p).First();

                    if(Type1 == "")
                    {
                        Type1 = null;
                    }

                    if(Type2 == "")
                    {
                        Type2 = null;
                    }

                    if (monster.PName == PName
                        && monster.Type1 == Type1 && monster.Type2 == Type2)
                    {
                        contextMenuStrip1.Items[0].Visible = false;
                        contextMenuStrip1.Items[1].Visible = false;
                        contextMenuStrip1.Items[2].Visible = true;
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateButton.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize pokemon entity
            pokemonEntity = new PokemonEntity();
            bindingSource1.DataSource = pokemonEntity.PokemonBaseStats.Local.ToBindingList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dispose of pokemon entity
            pokemonEntity.Dispose();
        }
    }
}
