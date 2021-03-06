﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace PerryHMK04
{
    public partial class Form1 : Form
    {
        public enum ScrollBarType : uint
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }

        public enum Message : uint
        {
            WM_VSCROLL = 0x0115
        }

        public enum ScrollBarCommands : uint
        {
            SB_THUMBPOSITION = 4
        }

        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
            ClearFile();
            AlignRight();
        }

        private void File_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file.Text = openFileDialog1.FileName;
            }
        }

        private void OpenFilePath_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding((sender as TextBox), 5);

            if(!A_ValidFile((sender as TextBox).Text, out string errMsg))
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
            string result;
            System.Text.RegularExpressions.Regex numeric = new System.Text.RegularExpressions.Regex("^[0-9](\\.?[0-9])+$");

            if ((sender as CheckBox).Checked)
            {
                using (StreamReader sr = new StreamReader(file.Text))
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
                    
                    result = String.Format($"{openFileDialog1.FileName} contains {numCount} line(s) of numbers ({(double)numCount / count:P0})");
                    OutputText.Text += result;

                    using (StreamWriter writer = new StreamWriter("Result.txt", true))
                    {
                        writer.WriteLine(result);
                    }

                    LineNum.AppendText($"{File.ReadAllLines("Result.txt").Count()}");
                }

                LineNum.Visible = true;
                OutputGrouping.Visible = true;
                OutputText.Visible = true;
            }
            else
            {
                OutputText.Text += "\n";
                LineNum.Text += "\n";
            }
        }

        private bool A_ValidFile(string path, out string errMsg)
        {
            if (path == "")
            {
                errMsg = "Click textbox to open file";
                return false;
            }

            if (File.Exists(file.Text))
            {
                errMsg = "";
                return true;
            }

            errMsg = $"\"{file.Text}\" is not a file. Click textbox to open file";
            return false;
        }

        private async void ClearFile()
        {
            await Task.Delay(3000);
            file.Clear();
        }

        private void AlignRight()
        {
            LineNum.SelectAll();
            LineNum.SelectionAlignment = HorizontalAlignment.Right;
            LineNum.DeselectAll();
            OutputText.SelectAll();
            OutputText.SelectionAlignment = HorizontalAlignment.Center;
            OutputText.DeselectAll();
        }

        private void OutputText_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(OutputText.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(LineNum.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Result.txt");
        }
    }
}
