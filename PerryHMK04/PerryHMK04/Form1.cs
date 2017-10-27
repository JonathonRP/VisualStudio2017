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

namespace PerryHMK04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void File_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Text = openFileDialog1.FileName;
            }
        }

        private void OpenFilePath_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding((sender as TextBox), 5);

            if(!IsValidPath((sender as TextBox).Text, out string errMsg))
            {
                e.Cancel = true;
                (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
                errorProvider1.SetError((sender as TextBox), errMsg);
            }
        }

        private void OpenFilePath_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((sender as TextBox), "");
        }

        private void ProcessFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex numeric = new System.Text.RegularExpressions.Regex("^[0-9](\\.?[0-9])+$");

            if ((sender as CheckBox).Checked)
            {
                using (StreamReader sr = new StreamReader(File.Text))
                {
                    // initialize some accumulator variables (for lines of numbers count and average)
                    int numCount = 0;
                    int count = 0;

                    string line = sr.ReadLine();

                    while (line != null) // null is returned at the end of the file
                    {
                        // Process
                        if (numeric.IsMatch(line))
                        {
                            // process all lines that are numeric
                            numCount++;
                        }

                        // read the next line
                        line = sr.ReadLine();
                        count++;
                    }

                    OutputText.Text += String.Format($"{openFileDialog1.FileName} contains {numCount} line(s) of numbers ({(double)numCount/ count:P0})");
                }

                OutputGrouping.Visible = true;
                OutputText.Visible = true;
            }
            else
            {
                OutputText.Text += "\n";
            }
        }

        private bool IsValidPath(string path, out string errMsg)
        {
            if (path == "")
            {
                errMsg = "A path is needed!";
                return false;
            }
            else if(openFileDialog1.CheckFileExists)
            {
                errMsg = "";
                return true;
            }

            errMsg = "not a file";
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.Clear();
        }
    }
}
