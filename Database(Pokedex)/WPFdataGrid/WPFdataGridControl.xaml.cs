using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Controls = System.Windows.Controls;
using System.Data.Entity;
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Pokemon = new Pokemon();
            Pokemon.PokemonBaseStats.Load();
            Pokemon.PokemonBaseStats.Local.ToBindingList();

            using (Pokemon db = new Pokemon())
            {
                var monsters = (from p in db.PokemonBaseStats
                                select p).ToList();

                var monsterDetails = (from p in db.PokemonBaseStats
                                      select new { p.PokemonCapRate.CapRate, p.PokemonCapRate.ExpDrop }).ToList();

                dataGrid.ItemsSource = monsters;

                //DataGridView.MouseDown += new MouseButtonEventHandler(DataGridView_MouseClick);
                //DataGridView.MouseEnter += new System.Windows.Input.MouseEventHandler(UserContol_MouseEnter);
            }
        }

        private void dataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject Hit = (DependencyObject)e.OriginalSource;
            Controls.DataGridRow dataRow = Hit as Controls.DataGridRow;

            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (dataRow.GetIndex() == dataGrid.Items.Count - 2 && pokemon != null)
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
                        Form1 form = new Form1();

                        form.contextMenu.Items[0].Visible = true;
                        form.contextMenu.Items[1].Visible = false;
                        form.contextMenu.Items[2].Visible = false;
                        form.contextMenu.Show(System.Windows.Forms.Cursor.Position);
                    }
                }

                if (dataRow.GetIndex() < dataGrid.Items.Count - 1 && pokemon != null
                    && System.Windows.Controls.Validation.GetHasError(dataGrid) == false)
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
                        Form1 form = new Form1();

                        form.contextMenu.Items[0].Visible = false;
                        form.contextMenu.Items[1].Visible = true;
                        form.contextMenu.Items[2].Visible = false;
                        form.contextMenu.Show(System.Windows.Forms.Cursor.Position);
                    }
                }

                if (dataRow.GetIndex() < dataGrid.Items.Count - 1
                    && System.Windows.Controls.Validation.GetHasError(dataGrid) == false)
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
                        Form1 form = new Form1();

                        form.contextMenu.Items[0].Visible = false;
                        form.contextMenu.Items[1].Visible = false;
                        form.contextMenu.Items[2].Visible = true;
                        form.contextMenu.Show(System.Windows.Forms.Cursor.Position);
                    }
                }
            }
        }
    }
}
