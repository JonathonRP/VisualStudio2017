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

        public Controls.ControlTemplate errorTemplate;

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
                grid.Items.Clear();
                dataGrid.ItemsSource = monster;
            }
        }

        private void dataGrid_RowDetailsVisibilityChanged(object sender, Controls.DataGridRowDetailsEventArgs e)
        {
            Controls.DataGrid data = e.DetailsElement.FindName("details") as Controls.DataGrid;

            Controls.DataGridRow dataRow = e.Row as Controls.DataGridRow;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

            using (Pokemon db = new Pokemon())
            {
                var PName = properties["PName"].GetValue(dataRow.Item)?.ToString();

                var monsterDetails = (from p in db.PokemonBaseStats
                                      where p.PName == PName
                                      select p.PokemonCapRate).ToList();

                if (!(monsterDetails == null))
                {
                    data.ItemsSource = monsterDetails;
                }
            }
        }
    }
}
