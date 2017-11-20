using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PerryPA03
{
    public partial class Form1 : Form
    {
        private string file;
        private List<VideoGame> VideoGames = new List<VideoGame>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView1_LoadMergedHeaders(false);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataGridView1_LoadMergedHeaders(true);

                file = openFileDialog1.FileName;
                fileNameToolStripMenuItem.Text = file;
                fileNameToolStripMenuItem.Visible = true;

                FileProcessing();

                var data = from game in VideoGames
                           select new
                           {
                               game.Rank,
                               game.Name,
                               game.Platform,
                               game.Year,
                               game.Genre,
                               game.Publisher,
                                USA = game.sales["NA"],
                                Europe = game.sales["EU"],
                                Japan = game.sales["JP"],
                                Other = game.sales["Other"],
                                Global = game.sales["Global"]
                           };

                Size = MaximumSize;
                richTextBox1.Visible = false;
                dataGridView1.Visible = true;

                var source = new BindingSource();
                source.DataSource = data;
                dataGridView1.DataSource = source;
            }
        }

        private void FileProcessing()
        {
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] data = line.Split(',');

                    int rank;

                    if (int.TryParse(data[0], out rank))
                    {
                        string name = data[1];
                        string platform = data[2];
                        int.TryParse(data[3], out int year);
                        string genre = data[4];
                        string publisher = data[5];
                        double.TryParse(data[6], out double na_sales);
                        double.TryParse(data[7], out double eu_sales);
                        double.TryParse(data[8], out double jp_sales);
                        double.TryParse(data[9], out double other_sales);
                        double.TryParse(data[10], out double global_sales);
                        
                        VideoGame game = new VideoGame(rank, name, platform, year, genre, publisher,
                            na_sales, eu_sales, jp_sales, other_sales, global_sales);
                        VideoGames.Add(game);
                    }
                }
            }
        }

        private bool ValidDate(int year, out string errmsg)
        {
            if (year >= 1980 && year <= DateTime.Now.Year && MaxYear.Value.Year >= MinYear.Value.Year)
            {
                errmsg = "";
                return true;
            }

            if (MaxYear.Value.Year < MinYear.Value.Year)
            {
                errmsg = "Max Year can not be small than Min Year";
                return false;
            }

            errmsg = "Invalid Year";
            return false;
        }

        private void TopSales_Click(object sender, EventArgs e)
        {
            DataGridView1_LoadMergedHeaders(false);

            var NA_sales = (from game in VideoGames
                            where game.Year <= MaxYear.Value.Year && game.Year >= MinYear.Value.Year
                            orderby game.sales["NA"] descending
                            select new
                            {
                                Location = game.location["NA"],
                                Name = game.Name,
                                Platform = game.Platform,
                                Publisher = game.Publisher,
                                Sales = game._sales["NA"]
                            }).Take(1);

            var EU_sales = (from game in VideoGames
                            where game.Year <= MaxYear.Value.Year && game.Year >= MinYear.Value.Year
                            orderby game.sales["EU"] descending
                            select new
                            {
                                Location = game.location["EU"],
                                Name = game.Name,
                                Platform = game.Platform,
                                Publisher = game.Publisher,
                                Sales = game._sales["EU"]
                            }).Take(1);

            var JP_sales = (from game in VideoGames
                            where game.Year <= MaxYear.Value.Year && game.Year >= MinYear.Value.Year
                            orderby game.sales["JP"] descending
                            select new
                            {
                                Location = game.location["JP"],
                                Name = game.Name,
                                Platform = game.Platform,
                                Publisher = game.Publisher,
                                Sales = game._sales["JP"]
                            }).Take(1);

            var Other_sales = (from game in VideoGames
                               where game.Year <= MaxYear.Value.Year && game.Year >= MinYear.Value.Year
                               orderby game.sales["Other"] descending
                               select new
                               {
                                   Location = game.location["Other"],
                                   Name = game.Name,
                                   Platform = game.Platform,
                                   Publisher = game.Publisher,
                                   Sales = game._sales["Other"]
                               }).Take(1);

            var Global_sales = (from game in VideoGames
                                where game.Year <= MaxYear.Value.Year && game.Year >= MinYear.Value.Year
                                orderby game.sales["Global"] descending
                                select new
                                {
                                    Location = game.location["Global"],
                                    Name = game.Name,
                                    Platform = game.Platform,
                                    Publisher = game.Publisher,
                                    Sales = game._sales["Global"]
                                }).Take(1);

            List<object> gamesales = new List<object>();

            AddGame(NA_sales, gamesales);
            AddGame(EU_sales, gamesales);
            AddGame(JP_sales, gamesales);
            AddGame(Other_sales, gamesales);
            AddGame(Global_sales, gamesales);

            var source = new BindingSource();
            source.DataSource = gamesales;
            dataGridView1.DataSource = source;
        }

        private void MaxYear_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void MaxYear_Validating(object sender, CancelEventArgs e)
        {
            
            if (!(ValidDate(MaxYear.Value.Year, out string errmsg)))
            {
                e.Cancel = true;
                errorProvider1.SetIconPadding(max_yearLabel, -3);
                errorProvider1.SetError(max_yearLabel, errmsg);
            }
        }

        private void MinYear_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void MinYear_Validating(object sender, CancelEventArgs e)
        {
            if (!(ValidDate(MinYear.Value.Year, out string errmsg)))
            {
                e.Cancel = true;
                errorProvider1.SetIconPadding(min_yearLabel, -2);
                errorProvider1.SetError(min_yearLabel, errmsg);
            }
        }

        private void fileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView1_LoadMergedHeaders(false);
            DataGridView1_LoadMergedHeaders(true);

            var data = from game in VideoGames
                       select new
                       {
                           game.Rank,
                           game.Name,
                           game.Platform,
                           game.Year,
                           game.Genre,
                           game.Publisher,
                            USA = game.sales["NA"],
                            Europe = game.sales["EU"],
                            Japan = game.sales["JP"],
                            Other = game.sales["Other"],
                            Global = game.sales["Global"]
                       };

            Size = MaximumSize;
            richTextBox1.Visible = false;
            dataGridView1.Visible = true;

            var source = new BindingSource();
            source.DataSource = data;
            dataGridView1.DataSource = source;
        }

        private void AddGame(IEnumerable<object> list, List<object> gamesales)
        {
            foreach(var game in list)
            {
                gamesales.Add(game);
            }
        }

        private void DataGridView1_LoadMergedHeaders(bool enable)
        {
            if (enable == true)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                DataGridViewTextBoxColumn Rank = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Title = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Platform = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Year = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Genre = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Publisher = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn USA = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Europe = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Japan = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Other = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Global = new DataGridViewTextBoxColumn();

                Rank.DataPropertyName = "Rank";
                Rank.HeaderText = "Rank";
                dataGridView1.Columns.Add(Rank);
                Rank.HeaderCell.Style.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Pixel);
                Rank.HeaderCell.Style.Padding = new Padding(14, 0, 0, 0);

                Title.DataPropertyName = "Name";
                Title.HeaderText = "Name";
                dataGridView1.Columns.Add(Title);
                Title.HeaderCell.Style.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Pixel);

                Platform.DataPropertyName = "Platform";
                Platform.HeaderText = "Platform";
                dataGridView1.Columns.Add(Platform);
                Platform.HeaderCell.Style.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Pixel);
                Platform.HeaderCell.Style.Padding = new Padding(14, 0, 0, 0);

                Year.DataPropertyName = "Year";
                Year.HeaderText = "Year";
                dataGridView1.Columns.Add(Year);
                Year.HeaderCell.Style.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Pixel);
                Year.HeaderCell.Style.Padding = new Padding(14, 0, 0, 0);

                Genre.DataPropertyName = "Genre";
                Genre.HeaderText = "Genre";
                dataGridView1.Columns.Add(Genre);
                Genre.HeaderCell.Style.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Pixel);
                Genre.SortMode = DataGridViewColumnSortMode.NotSortable;

                Publisher.DataPropertyName = "Publisher";
                Publisher.HeaderText = "Publisher";
                dataGridView1.Columns.Add(Publisher);
                Publisher.HeaderCell.Style.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Pixel);
                Publisher.SortMode = DataGridViewColumnSortMode.NotSortable;

                USA.DataPropertyName = "USA";
                USA.HeaderText = "USA";
                dataGridView1.Columns.Add(USA);
                USA.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                USA.HeaderCell.Style.Padding = new Padding(9, 0, 9, 0);
                USA.SortMode = DataGridViewColumnSortMode.NotSortable;

                Europe.DataPropertyName = "Europe";
                Europe.HeaderText = "Europe";
                dataGridView1.Columns.Add(Europe);
                Europe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                Europe.HeaderCell.Style.Padding = new Padding(9, 0, 9, 0);
                Europe.SortMode = DataGridViewColumnSortMode.NotSortable;

                Japan.DataPropertyName = "Japan";
                Japan.HeaderText = "Japan";
                dataGridView1.Columns.Add(Japan);
                Japan.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                Japan.HeaderCell.Style.Padding = new Padding(9, 0, 9, 0);
                Japan.SortMode = DataGridViewColumnSortMode.NotSortable;

                Other.DataPropertyName = "Other";
                Other.HeaderText = "Other";
                dataGridView1.Columns.Add(Other);
                Other.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                Other.HeaderCell.Style.Padding = new Padding(9, 0, 9, 0);
                Other.SortMode = DataGridViewColumnSortMode.NotSortable;

                Global.DataPropertyName = "Global";
                Global.HeaderText = "Global";
                dataGridView1.Columns.Add(Global);
                Global.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                Global.HeaderCell.Style.Padding = new Padding(9, 0, 9, 0);
                Global.SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.ColumnHeadersHeightSizeMode =
                        DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 
                        dataGridView1.ColumnHeadersHeight * 2;
                
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

                dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
            }
            else
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.ColumnHeadersHeightSizeMode =
                        DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 23;

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Paint -= new PaintEventHandler(dataGridView1_Paint);
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            string[] column = { "Sales" };

            for (int j = 6; j < 7;)
            {
                //get the column header cell
                Rectangle r1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true);

                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width * 6 - 13;
                r1.Height = r1.Height / 2 - 2;

                using (Pen pen = new Pen(SystemColors.ControlDark, 3))
                {
                    float shrinkAmount = pen.Width / 2;
                    e.Graphics.DrawRectangle(
                        pen,
                        r1.X + shrinkAmount,   // move half a pen-width to the right
                        r1.Y + shrinkAmount,   // move half a pen-width to the down
                        r1.Width - 3,   // shrink width with one pen-width
                        r1.Height - 2); // shrink height with one pen-width
                }

                e.Graphics.FillRectangle(new
                   SolidBrush(this.dataGridView1.DefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(column[j / 8],
                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),
                    r1,
                    format);
                j += 5;
            }
        }
    }
}
