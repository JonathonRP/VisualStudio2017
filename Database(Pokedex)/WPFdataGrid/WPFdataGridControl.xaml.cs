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

        public DataGridControl()
        {
            InitializeComponent();
            grid = dataGrid;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            DependencyObject Hit = (DependencyObject)e.OriginalSource;

            while (Hit == null || !(Hit is Controls.DataGridRow))
            {
                Hit = VisualTreeHelper.GetParent(Hit);
            }

            Controls.DataGridRow dataRow = Hit as Controls.DataGridRow;

            dataRow.DetailsVisibility = Visibility.Collapsed;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DependencyObject Hit = (DependencyObject)e.OriginalSource;

            while (Hit == null || !(Hit is Controls.DataGridRow))
            {
                Hit = VisualTreeHelper.GetParent(Hit);
            }

            Controls.DataGridRow dataRow = Hit as Controls.DataGridRow;

            dataRow.DetailsVisibility = Visibility.Visible;
        }
    }
}
