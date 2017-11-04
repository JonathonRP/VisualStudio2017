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
using PerryCE04;

namespace PerryCE04
{
    public partial class Form1 : Form
    {
        private string file;
        private List<ShippingID> shippingIDs = new List<ShippingID>();

        public Form1()
        {
            InitializeComponent();
            RoutingNumber.Focus();
        }

        private void CodeBeginning_Validating(object sender, CancelEventArgs e)
        {
            if (!validFile(file, out string errMsg))
            {
                errorProvider1.SetIconPadding(menuStrip1, -260);
                e.Cancel = true;
                errorProvider1.SetError(menuStrip1, errMsg);
            }
            else if (!validBeginningCode(RoutingNumber.Text, out errMsg))
            {
                e.Cancel = true;
                errorProvider1.SetError(RoutingNumber, errMsg);
            }

            if (validFile(file, out errMsg))
            {
                errorProvider1.SetError(menuStrip1, "");
            }
        }

        private void CodeBeginning_Validated(object sender, EventArgs e)
        {        
            errorProvider1.SetError(RoutingNumber, "");
        }

        private void ShippingID_Validating(object sender, CancelEventArgs e)
        {
            if (!validShippingID(shippingID.Text, out string errMsg))
            {
                e.Cancel = true;
                errorProvider1.SetError(shippingID, errMsg);
            }
        }

        private void ShippingID_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(shippingID, "");
        }

        private void select_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                file_name.Text = file;
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

                    int shipping_id;

                    if (int.TryParse(data[0], out shipping_id))
                    {
                        string shipping_code = data[1];
                        string routing = data[2];

                        ShippingID ID = new ShippingID(shipping_id, shipping_code, routing);
                        shippingIDs.Add(ID);
                    }
                }
            }
        }

        private void DisplayAvgID_CheckedChanged(object sender, EventArgs e)
        {
            if(DisplayAvgID.Checked)
            {
                FileProcessing();

                var avg_id = from id in shippingIDs
                            where id.Routing.StartsWith(RoutingNumber.Text)
                            select id.Shipping_id;

                AvgID.Text = $"{avg_id.Average()}";

                shippingID.Visible = true;
                shippingID.Focus();
                FindMatchingCodesButton.Visible = true;
                FoundMatchingCodes.Visible = true;
            }
        }

        private void FindMatchingIDsButton_Click(object sender, EventArgs e)
        {
            var find_codes = from id in shippingIDs
                            where id.Shipping_id == int.Parse(shippingID.Text)
                            select id.Shipping_code;

            foreach (var code in find_codes)
            {
                if (!(code == find_codes.Last()))
                {
                    FoundMatchingCodes.AppendText($"{code},");
                }
                else
                {
                    FoundMatchingCodes.AppendText($"{code}");
                }
            }
        }

        private bool validFile(string file, out string errMsg)
        {
            if (File.Exists(file))
            {
                errMsg = "";
                return true;
            }

            errMsg = $"{file} is not a file";
            return false;
        }

        private bool validBeginningCode(string code_beginning, out string errMsg)
        {
            if (code_beginning == "ATX" || code_beginning == "RIO" || code_beginning == "NYC")
            {
                errMsg = "";
                return true;
            }

            errMsg = $"{code_beginning} is not a valid choice";
            return false;
        }

        private bool validShippingID(string shippingId, out string errMsg)
        {
            if (double.TryParse(shippingId, out double id))
            {
                errMsg = "";
                return true;
            }

            errMsg = $"Please enter shipping id";
            return false;
        }

        private void file_name_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(file);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.Clear();
        }
    }
}
