using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Controls = System.Windows.Controls;
using System.Data.Entity;
using System.Data;
using System.Data.Linq;
using System.Data.OleDb;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WPFdataGrid
{
    /// <summary>
    /// Interaction logic for WPFdataGridControl.xaml
    /// </summary>
    public partial class DataGridControl : Controls.UserControl
    {
        public Controls.DataGrid grid;

        public PokemonBaseStat pokemon;

        private Pokemon Pokemon;

        public DataGridControl()
        {
            InitializeComponent();
            grid = dataGrid;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (!(Process.GetCurrentProcess().ProcessName == "devenv"))
            {
                InitControl();
            }
        }

        protected virtual void InitControl()
        {
            Pokemon = new Pokemon();
            Pokemon.PokemonBaseStats.Load();
            Pokemon.PokemonBaseStats.Local.ToBindingList();

            using (Pokemon db = new Pokemon())
            {
                var monster = (from p in db.PokemonBaseStats
                               select p).ToList();

                dataGrid.ItemsSource = monster;
            }
        }

        private void dataGrid_RowDetailsVisibilityChanged(object sender, Controls.DataGridRowDetailsEventArgs e)
        {
            Controls.DataGrid data = e.DetailsElement.FindName("details") as Controls.DataGrid;

            using (Pokemon db = new Pokemon())
            {
                
                var monsterDetails = (from p in db.PokemonBaseStats
                                      select p.PokemonCapRate).ToList();

                data.Items.Clear();
                if (e.Row.GetIndex() < grid.Items.Count - 2)
                {
                    data.Items.Add(monsterDetails.ElementAt(e.Row.GetIndex()));
                }
            }
        }
    }
}
