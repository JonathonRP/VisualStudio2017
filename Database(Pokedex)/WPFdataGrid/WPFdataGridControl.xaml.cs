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
using Database_Pokedex_;

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

        private CancelEvent EventArgs = new CancelEvent();

        public DataGridControl()
        {
            InitializeComponent();
            grid = dataGrid;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this) == false)
            {
                InitControl();
            }
        }

        protected virtual void InitControl()
        {
            Pokemon = new Pokemon();
            Pokemon.PokemonBaseStats.Local.ToBindingList();

            using (Pokemon db = new Pokemon())
            {
                var monster = (from p in db.PokemonBaseStats
                               select p).ToList();

                dataGrid.ItemsSource = monster;
            }
        }
    }
}
