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

        public PokemonCapRate pokemonCapRate;

        private List<PokemonCapRate> pokemonCapRates = new List<PokemonCapRate>();

        private Pokemon Pokemon;

        private CancelEvent EventArgs = new CancelEvent();
        private ApplicationStorage search = new ApplicationStorage();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            var detailGrids = FindVisualChildren<Control.DataGrid>(grid);

            grid.IsReadOnly = true;
            grid.MouseRightButtonUp += new MouseButtonEventHandler(dataGrid_MouseRightClick);
            grid.CellEditEnding += new EventHandler<Control.DataGridCellEditEndingEventArgs>(dataGrid_CellValueChanged);
            grid.RowDetailsVisibilityChanged += new EventHandler<Control.DataGridRowDetailsEventArgs>(dataGrid_RowDetailsVisibilityChanged);

            foreach (var detailGrid in detailGrids)
            {
                detailGrid.IsReadOnly = true;
                detailGrid.CellEditEnding += new EventHandler<Control.DataGridCellEditEndingEventArgs>(detailGrid_CellValueChanged);
            }

            Pokemon = new Pokemon();
            Pokemon.PokemonBaseStats.Load();
            Pokemon.PokemonBaseStats.Local.ToBindingList();

            using (Pokemon db = new Pokemon())
            {
                var monster = (from p in db.PokemonBaseStats
                               select p).ToList();

                grid.Items.Clear();
                grid.ItemsSource = monster;
            }

            foreach (var value in search.Values)
            {
                toolStripComboBox1.Items.Add(value);
            }

            fileNameToolStripMenuItem.Text = "PokemonDatabase.accdb";
            fileNameToolStripMenuItem.ToolTipText = "Click to Open File";
            fileToolStripMenuItem.ToolTipText = "Refresh, Edit Database";
            fileNameToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            menuStrip1.ShowItemToolTips = true;
            fileNameToolStripMenuItem.Visible = true;
        }

        private void dataGrid_RowDetailsVisibilityChanged(object sender, Control.DataGridRowDetailsEventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            Control.DataGrid data = e.DetailsElement.FindName("details") as Control.DataGrid;

            Control.DataGridRow dataRow = e.Row as Control.DataGridRow;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

            var PName = properties["PName"].GetValue(dataRow.Item)?.ToString();

            if (pokemonCapRates == null || !(pokemonCapRates.Any(p => p.PName == PName)))
            {
                using (Pokemon db = new Pokemon())
                {
                    var monsterDetails = (from p in db.PokemonBaseStats
                                          where p.PName == PName
                                          select p.PokemonCapRate).ToList();

                    if (!(monsterDetails == null))
                    {
                        data.ItemsSource = monsterDetails;
                    }
                }
            }
            else
            {
                data.ItemsSource = (from p in pokemonCapRates
                                    where p.PName == PName
                                    select p).ToList();
            }

            data.IsReadOnly = grid.IsReadOnly;
            data.CellEditEnding += new EventHandler<Control.DataGridCellEditEndingEventArgs>(detailGrid_CellValueChanged);
        }

        private void dataGrid_CellValueChanged(object sender, Control.DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == Control.DataGridEditAction.Commit)
            {
                WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
                var dataGridView = wPFdataGrid.grid;

                Control.DataGridRow dataRow = e.Row as Control.DataGridRow;
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                DataGridDetailsPresenter presenter = FindVisualChild<DataGridDetailsPresenter>(dataRow);
                DataTemplate detail = presenter.ContentTemplate;

                Int16.TryParse(properties["HP"].GetValue(dataRow.Item).ToString(), out Int16 HP);
                Int16.TryParse(properties["Attack"].GetValue(dataRow.Item).ToString(), out Int16 Attack);
                Int16.TryParse(properties["Defense"].GetValue(dataRow.Item).ToString(), out Int16 Defense);
                Int16.TryParse(properties["SPAttack"].GetValue(dataRow.Item).ToString(), out Int16 SPAttack);
                Int16.TryParse(properties["SPDefense"].GetValue(dataRow.Item).ToString(), out Int16 SPDefense);
                Int16.TryParse(properties["Speed"].GetValue(dataRow.Item).ToString(), out Int16 Speed);

                Int16 CapRate = 0;
                Int16 ExpDrop = 0;

                try
                {
                    Control.DataGrid detailGrid = detail.FindName("details", presenter) as Control.DataGrid;

                    PropertyDescriptorCollection detailProperties = TypeDescriptor.GetProperties(detailGrid.Items.CurrentItem);

                    Int16.TryParse(detailProperties["CapRate"]?.GetValue(detailGrid.Items?.CurrentItem)?.ToString(), out CapRate);
                    Int16.TryParse(detailProperties["ExpDrop"]?.GetValue(detailGrid.Items?.CurrentItem)?.ToString(), out ExpDrop);
                }
                catch
                {
                    using (Pokemon db = new Pokemon())
                    {
                        try
                        {
                            CapRate = db.PokemonBaseStats.Where(p => p.PName == properties["PName"].GetValue(dataRow.Item).ToString()).Single().PokemonCapRate.CapRate;
                            ExpDrop = db.PokemonBaseStats.Where(p => p.PName == properties["PName"].GetValue(dataRow.Item).ToString()).Single().PokemonCapRate.ExpDrop;
                        }
                        catch
                        {
                            CapRate = 0;
                            ExpDrop = 0;
                        }
                    }
                }

                pokemon = new PokemonBaseStat()
                {
                    PName = properties["PName"].GetValue(dataRow.Item)?.ToString(),
                    HP = HP,
                    Attack = Attack,
                    Defense = Defense,
                    SPAttack = SPAttack,
                    SPDefense = SPDefense,
                    Speed = Speed,
                    Type1 = properties["Type1"].GetValue(dataRow.Item)?.ToString(),
                    Type2 = properties["Type2"].GetValue(dataRow.Item)?.ToString(),

                    PokemonCapRate = new PokemonCapRate()
                    {
                        PName = properties["PName"].GetValue(dataRow.Item)?.ToString(),
                        CapRate = CapRate,
                        ExpDrop = ExpDrop
                    }
                };

                ValidationContext validate = new ValidationContext(pokemon, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(pokemon, validate, errors, true))
                {
                    e.Cancel = true;
                    EventArgs.Cancel = true;
                    EventArgs.Error = null;

                    Control.DataErrorValidationRule validationRule = new Control.DataErrorValidationRule();

                    Control.ValidationError error = new Control.ValidationError(validationRule, dataRow.BindingGroup.BindingExpressions);

                    EventArgs.Error = $"{errors.First().ErrorMessage}";

                    error.ErrorContent = $"{errors.First().ErrorMessage}";

                    foreach (ValidationResult result in errors.Skip(1))
                    {
                        EventArgs.Error += $"\n{result.ErrorMessage}";

                        error.ErrorContent += $"\n{result.ErrorMessage}";
                    }

                    foreach (var binding in dataRow.BindingGroup.BindingExpressions)
                    {
                        Control.Validation.MarkInvalid(dataRow.BindingGroup.BindingExpressions.First(), error);
                    }
                }
                else
                {
                    Control.DataErrorValidationRule validationRule = new Control.DataErrorValidationRule();

                    Control.ValidationError error = new Control.ValidationError(validationRule, dataRow.BindingGroup.BindingExpressions);

                    e.Cancel = false;
                    EventArgs.Cancel = false;
                    error.ErrorContent = null;
                }
            }
        }

        private void detailGrid_CellValueChanged(object sender, Control.DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == Control.DataGridEditAction.Commit)
            {
                WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
                var dataGridView = wPFdataGrid.grid;

                Control.DataGridRow dataRow = e.Row as Control.DataGridRow;

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

                Int16.TryParse(properties["CapRate"]?.GetValue(dataRow.Item)?.ToString(), out Int16 CapRate);
                Int16.TryParse(properties["ExpDrop"]?.GetValue(dataRow.Item)?.ToString(), out Int16 ExpDrop);

                pokemonCapRate = new PokemonCapRate()
                {
                    PName = properties["PName"].GetValue(dataRow.Item)?.ToString(),
                    CapRate = CapRate,
                    ExpDrop = ExpDrop
                };

                ValidationContext validate = new ValidationContext(pokemonCapRate, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(pokemonCapRate, validate, errors, true))
                {
                    e.Cancel = true;
                    EventArgs.Cancel = true;
                    EventArgs.Error = null;

                    Control.DataErrorValidationRule validationRule = new Control.DataErrorValidationRule();

                    Control.ValidationError error = new Control.ValidationError(validationRule, dataRow.BindingGroup.BindingExpressions);

                    EventArgs.Error = $"{errors.First().ErrorMessage}";

                    error.ErrorContent = $"{errors.First().ErrorMessage}";

                    foreach (ValidationResult result in errors.Skip(1))
                    {
                        EventArgs.Error += $"\n{result.ErrorMessage}";

                        error.ErrorContent += $"\n{result.ErrorMessage}";
                    }

                    foreach (var binding in dataRow.BindingGroup.BindingExpressions)
                    {
                        Control.Validation.MarkInvalid(dataRow.BindingGroup.BindingExpressions.First(), error);
                    }
                }
                else
                {
                    Control.DataErrorValidationRule validationRule = new Control.DataErrorValidationRule();

                    Control.ValidationError error = new Control.ValidationError(validationRule, dataRow.BindingGroup.BindingExpressions);

                    e.Cancel = false;
                    EventArgs.Cancel = false;
                    error.ErrorContent = null;

                    pokemonCapRates.Add(pokemonCapRate);
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
            var detailGrids = FindVisualChildren<Control.DataGrid>(dataGridView);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(dataRow.Item);

            Pokemon = new Pokemon();

            string PName = properties["PName"].GetValue(dataRow.Item)?.ToString();
            Int16 HP = 0;
            Int16 Attack = 0;
            Int16 Defense = 0;
            Int16 SPAttack = 0;
            Int16 SPDefense = 0;
            Int16 Speed = 0;
            string Type1 = null;
            string Type2 = null;

            if (properties["HP"] != null && properties["Attack"] != null && properties["Defense"] != null && properties["SPAttack"] != null &&
                properties["SPDefense"] != null && properties["Speed"] != null)
            {
                Int16.TryParse(properties["HP"].GetValue(dataRow.Item).ToString(), out HP);
                Int16.TryParse(properties["Attack"].GetValue(dataRow.Item).ToString(), out Attack);
                Int16.TryParse(properties["Defense"].GetValue(dataRow.Item).ToString(), out Defense);
                Int16.TryParse(properties["SPAttack"].GetValue(dataRow.Item).ToString(), out SPAttack);
                Int16.TryParse(properties["SPDefense"].GetValue(dataRow.Item).ToString(), out SPDefense);
                Int16.TryParse(properties["Speed"].GetValue(dataRow.Item).ToString(), out Speed);
                Type1 = properties["Type1"].GetValue(dataRow.Item)?.ToString();
                Type2 = properties["Type2"].GetValue(dataRow.Item)?.ToString();
            }
            else
            {
                using (Pokemon db = new Pokemon())
                {
                    HP = db.PokemonBaseStats.Where(p => p.PName == PName).Single().HP;
                    Attack = db.PokemonBaseStats.Where(p => p.PName == PName).Single().Attack;
                    Defense = db.PokemonBaseStats.Where(p => p.PName == PName).Single().Defense;
                    SPAttack = db.PokemonBaseStats.Where(p => p.PName == PName).Single().SPAttack;
                    SPDefense = db.PokemonBaseStats.Where(p => p.PName == PName).Single().SPDefense;
                    Speed = db.PokemonBaseStats.Where(p => p.PName == PName).Single().Speed;
                }
            }

            Int16 CapRate = 0;
            Int16 ExpDrop = 0;

            if (detailGrids.Count() > 0 && pokemonCapRates.Count > 0 && dataRow.DetailsVisibility == Visibility.Visible)
            {
                foreach (var detailGrid in detailGrids.Where(g => g.Items.CurrentItem.GetType().GetProperty("PName").GetValue(g.Items.CurrentItem).ToString() == dataRow.Item.GetType().GetProperty("PName").GetValue(dataRow.Item).ToString()))
                {
                    PropertyDescriptorCollection detailProperties = TypeDescriptor.GetProperties(detailGrid.Items.CurrentItem);
                    Int16.TryParse(detailProperties["CapRate"].GetValue(detailGrid.Items.CurrentItem).ToString(), out CapRate);
                    Int16.TryParse(detailProperties["ExpDrop"].GetValue(detailGrid.Items.CurrentItem).ToString(), out ExpDrop);
                }
            }
            else
            {
                using (Pokemon db = new Pokemon())
                {
                    try
                    {
                        CapRate = db.PokemonBaseStats.Where(p => p.PName == PName).Single().PokemonCapRate.CapRate;
                        ExpDrop = db.PokemonBaseStats.Where(p => p.PName == PName).Single().PokemonCapRate.ExpDrop;
                    }
                    catch
                    {
                        CapRate = 0;
                        ExpDrop = 0;
                    }
                }
            }

            if (dataRow.GetIndex() <= dataGridView.Items.Count - 2 && pokemon != null)
            {
                PokemonBaseStat monster;

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
                if (properties["HP"] != null && properties["Attack"] != null && properties["Defense"] != null && properties["SPAttack"] != null &&
                    properties["SPDefense"] != null && properties["Speed"] != null)
                {
                    PokemonBaseStat monster;

                    try
                    {
                        monster = (from p in Pokemon.PokemonBaseStats
                                   where p.PName == PName
                                   select p).Single();
                    }
                    catch
                    {
                        monster = null;
                        return;
                    }

                    if (monster.PName == pokemon.PName
                        && (monster.HP != pokemon.HP || monster.Attack != pokemon.Attack || monster.Defense != pokemon.Defense || monster.SPAttack != pokemon.SPAttack || monster.SPDefense != pokemon.SPDefense ||
                        monster.Speed != pokemon.Speed || monster.Type1 != pokemon.Type1 || monster.Type2 != pokemon.Type2 || monster.PokemonCapRate.CapRate != pokemon.PokemonCapRate.CapRate || monster.PokemonCapRate.ExpDrop != pokemon.PokemonCapRate.ExpDrop))
                    {
                        contextMenuStrip.Items[0].Visible = false;
                        contextMenuStrip.Items[1].Visible = true;
                        contextMenuStrip.Items[2].Visible = false;
                        contextMenuStrip.Show(System.Windows.Forms.Cursor.Position);
                    }
                }
            }

            if (dataRow.GetIndex() <= dataGridView.Items.Count - 2
                && Control.Validation.GetHasError(dataRow) == false)
            {
                var monster = (from p in Pokemon.PokemonBaseStats
                                where p.PName == PName
                                select p).First();

                pokemon = new PokemonBaseStat()
                {
                    PName = properties["PName"].GetValue(dataRow.Item).ToString(),
                    HP = HP,
                    Attack = Attack,
                    Defense = Defense,
                    SPAttack = SPAttack,
                    SPDefense = SPDefense,
                    Speed = Speed,
                    Type1 = Type1,
                    Type2 = Type2,

                    PokemonCapRate = new PokemonCapRate()
                    {
                        PName = properties["PName"].GetValue(dataRow.Item).ToString(),
                        CapRate = CapRate,
                        ExpDrop = ExpDrop
                    }
                };

                if (Type1 == "")
                {
                    Type1 = null;
                }

                if (Type2 == "")
                {
                    Type2 = null;
                }

                if (monster.PName == PName
                    && monster.HP == HP && monster.Attack == Attack && monster.Defense == Defense && monster.SPAttack == SPAttack && monster.SPDefense == SPDefense &&
                    monster.Speed == Speed && monster.Type1 == pokemon.Type1 && monster.Type2 == pokemon.Type2 && monster.PokemonCapRate.CapRate == CapRate && monster.PokemonCapRate.ExpDrop == ExpDrop)
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
            if (EventArgs.Cancel != true)
            {
                try
                {
                    using (var context = new Pokemon())
                    {

                        //create Book object

                        PokemonBaseStat pokemonToAdd = new PokemonBaseStat();

                        //assign its properties
                        pokemonToAdd.PName = pokemon.PName;
                        pokemonToAdd.HP = pokemon.HP;
                        pokemonToAdd.Attack = pokemon.Attack;
                        pokemonToAdd.Defense = pokemon.Defense;
                        pokemonToAdd.SPAttack = pokemon.SPAttack;
                        pokemonToAdd.SPDefense = pokemon.SPDefense;
                        pokemonToAdd.Speed = pokemon.Speed;
                        pokemonToAdd.Type1 = pokemon.Type1;
                        pokemonToAdd.Type2 = pokemon.Type2;
                        pokemonToAdd.PokemonCapRate = pokemon.PokemonCapRate;
                        //add the Book to the object set Books
                        context.PokemonBaseStats.Add(pokemonToAdd);
                        //save change to the database
                        context.SaveChanges();
                    }

                    refreshToolStripMenuItem.PerformClick();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($" Data: {ex.Data} \n Source: {ex.Source} \n " +
                        $"Message: {ex.Message} \n Inner Error: {ex.InnerException} \n Target Site: {ex.TargetSite} \n Stack Trace: {ex.StackTrace} \n " +
                        $"Result Code: {ex.HResult} \n {ex.HelpLink}");
                }
            }
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
                    monster.HP = pokemon.HP;
                    monster.Attack = pokemon.Attack;
                    monster.Defense = pokemon.Defense;
                    monster.SPAttack = pokemon.SPAttack;
                    monster.SPDefense = monster.SPDefense;
                    monster.Speed = pokemon.Speed;

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

                    monster.PokemonCapRate.CapRate = pokemon.PokemonCapRate.CapRate;
                    monster.PokemonCapRate.ExpDrop = pokemon.PokemonCapRate.ExpDrop;
                }

                try
                {
                    dataGridView.CommitEdit();
                    //pokemon entity save changes
                    Pokemon.SaveChanges();

                    refreshToolStripMenuItem.PerformClick();
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
            WPFdataGrid.DataGridControl wPFdataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            var dataGridView = wPFdataGrid.grid;

            string recordDeleteConformationMessage = $@"This Record will be Deleted,
                [ PName: ""{pokemon.PName}"", Type 1: ""{pokemon.Type1}"", Type 2: ""{pokemon.Type2}"" ] ";

            DialogResult result = System.Windows.Forms.MessageBox.Show(recordDeleteConformationMessage, "Confirmation, Do You Still Want to Delete?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                try
                {
                    using (var context = new Pokemon())
                    {
                        var pokemonToDelete = from p in context.PokemonBaseStats
                                              where p.PName == pokemon.PName
                                              select p;

                        var pokemonCapRateToDelete = from p in context.PokemonCapRates
                                                     where p.PName == pokemon.PName
                                                     select p;

                        foreach (var monster in pokemonToDelete)
                        {
                            context.PokemonBaseStats.Remove(monster);
                        }

                        foreach (var monster in pokemonCapRateToDelete)
                        {
                            context.PokemonCapRates.Remove(monster);
                        }

                        context.SaveChanges();

                    } //delete the record from the Book table

                    refreshToolStripMenuItem.PerformClick();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($" Data: {ex.Data} \n Source: {ex.Source} \n " +
                        $"Message: {ex.Message} \n Inner Error: {ex.InnerException} \n Target Site: {ex.TargetSite} \n Stack Trace: {ex.StackTrace} \n " +
                        $"Result Code: {ex.HResult} \n {ex.HelpLink}");
                }
            }
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

        private void EditDatabase_Click(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            var detailGrids = FindVisualChildren<Control.DataGrid>(grid);

            if (grid.IsReadOnly == false)
            {
                grid.IsReadOnly = true;

                foreach (var detailGrid in detailGrids)
                {
                    detailGrid.IsReadOnly = grid.IsReadOnly;
                }
            }
            else
            {
                grid.IsReadOnly = false;

                foreach (var detailGrid in detailGrids)
                {
                    detailGrid.IsReadOnly = grid.IsReadOnly;
                }
            }
        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
                Control.DataGrid grid = dataGrid.grid;

                var PName = (sender as ToolStripComboBox).Text;

                if (!(PName == null) && !(toolStripComboBox1.Items.Contains(PName)) && !(PName == "Search"))
                {
                    toolStripComboBox1.Items.Add(PName);
                    search.Add(PName, PName);
                    search.Save();
                }
            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            var PName = (sender as ToolStripComboBox).Text;

            using (Pokemon db = new Pokemon())
            {
                if (!(PName == null))
                {
                    if (PName == "Search")
                    {
                        grid.ItemsSource = (from p in db.PokemonBaseStats
                                            select p).ToList();
                    }
                    else
                    {
                        grid.ItemsSource = (from p in db.PokemonBaseStats
                                            where p.PName.StartsWith(PName)
                                            select p).ToList();
                    }
                }
                else
                {
                    grid.ItemsSource = (from p in db.PokemonBaseStats
                                        select p).ToList();
                }
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WPFdataGrid.DataGridControl dataGrid = elementHost1.Child as WPFdataGrid.DataGridControl;
            Control.DataGrid grid = dataGrid.grid;

            var PName = (sender as ToolStripComboBox).Text;

            using (Pokemon db = new Pokemon())
            {
                if (!(PName == null))
                {
                    if (PName == "Search")
                    {
                        grid.ItemsSource = (from p in db.PokemonBaseStats
                                            select p).ToList();
                    }
                    else
                    {
                        grid.ItemsSource = (from p in db.PokemonBaseStats
                                            where p.PName.StartsWith(PName)
                                            select p).ToList();
                    }
                }
                else
                {
                    grid.ItemsSource = (from p in db.PokemonBaseStats
                                        select p).ToList();
                }
            }
        }

        private void clearSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Search";
        }

        private void clearQueryHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();
            search.Clear();
            search.Save();
        }

        private void fileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("..\\..\\..\\PokemonDatabase.accdb");
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

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }

    public class CancelEvent : EventArgs
    {
        public bool Cancel { get; set; }

        public string Error { get; set; }
    }
}
