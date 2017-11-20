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
using Database_Pokedex_;

namespace Database_Pokedex_
{
    public partial class Form1 : Form
    {
        private string file;
        private string connection_string =
            "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=..\\..\\PokemonDatabase.accdb; Persist Security Info = False;";
        private string statement = "select * from [PokemonBaseStats]";
        private OleDbDataAdapter dataAdapter;
        private OleDbCommandBuilder dbCommandBuilder;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (OleDbConnection dbConnection = new OleDbConnection(connection_string))
            {
                using (Pokemon db = new Pokemon(dbConnection))
                {
                    var pokemon = from p in db.PokemonBaseStats
                                  select p;
                    
                    dataGridView1.DataSource = pokemon;
                }

                //below does the same as above^
                //dataAdapter = new OleDbDataAdapter(statement, connection_string);
                //dbCommandBuilder = new OleDbCommandBuilder(dataAdapter);

                //DataTable pokemon = new DataTable();

                //dataAdapter.Fill(pokemon);
                //dataGridView1.DataSource = pokemon;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                fileNameToolStripMenuItem.Text = file;
                fileNameToolStripMenuItem.Visible = true;

                connection_string = $"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={file}; Persist Security Info = False;";

                using (OleDbConnection dbConnection = new OleDbConnection(connection_string))
                {
                    dataAdapter = new OleDbDataAdapter(statement, connection_string);
                    dbCommandBuilder = new OleDbCommandBuilder(dataAdapter);

                    DataTable data = new DataTable();

                    dataAdapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
            }
        }
    }
}
