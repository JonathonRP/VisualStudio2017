namespace PerryHMK04
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.file = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ProcessFileCheckBox = new System.Windows.Forms.CheckBox();
            this.OutputText = new System.Windows.Forms.RichTextBox();
            this.OutputGrouping = new System.Windows.Forms.GroupBox();
            this.LineNum = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.OutputGrouping.SuspendLayout();
            this.SuspendLayout();
            // 
            // file
            // 
            this.file.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file.Location = new System.Drawing.Point(12, 6);
            this.file.Name = "file";
            this.file.ReadOnly = true;
            this.file.Size = new System.Drawing.Size(264, 22);
            this.file.TabIndex = 0;
            this.file.Text = "Click to Open File";
            this.file.Click += new System.EventHandler(this.File_Click);
            this.file.Validating += new System.ComponentModel.CancelEventHandler(this.OpenFilePath_Validating);
            this.file.Validated += new System.EventHandler(this.OpenFilePath_Validated);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // ProcessFileCheckBox
            // 
            this.ProcessFileCheckBox.AutoSize = true;
            this.ProcessFileCheckBox.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessFileCheckBox.Location = new System.Drawing.Point(302, 8);
            this.ProcessFileCheckBox.Name = "ProcessFileCheckBox";
            this.ProcessFileCheckBox.Size = new System.Drawing.Size(126, 21);
            this.ProcessFileCheckBox.TabIndex = 1;
            this.ProcessFileCheckBox.Text = "Process File";
            this.ProcessFileCheckBox.UseVisualStyleBackColor = true;
            this.ProcessFileCheckBox.CheckedChanged += new System.EventHandler(this.ProcessFileCheckBox_CheckedChanged);
            // 
            // OutputText
            // 
            this.OutputText.BackColor = System.Drawing.SystemColors.Window;
            this.OutputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputText.Font = new System.Drawing.Font("Century Schoolbook", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputText.Location = new System.Drawing.Point(38, 55);
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(390, 128);
            this.OutputText.TabIndex = 2;
            this.OutputText.Text = "";
            this.OutputText.Visible = false;
            this.OutputText.VScroll += new System.EventHandler(this.OutputText_VScroll);
            // 
            // OutputGrouping
            // 
            this.OutputGrouping.Controls.Add(this.LineNum);
            this.OutputGrouping.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputGrouping.Location = new System.Drawing.Point(5, 34);
            this.OutputGrouping.Name = "OutputGrouping";
            this.OutputGrouping.Size = new System.Drawing.Size(429, 157);
            this.OutputGrouping.TabIndex = 3;
            this.OutputGrouping.TabStop = false;
            this.OutputGrouping.Text = "Output";
            this.OutputGrouping.Visible = false;
            // 
            // LineNum
            // 
            this.LineNum.BackColor = System.Drawing.SystemColors.Window;
            this.LineNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNum.Font = new System.Drawing.Font("Century Schoolbook", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineNum.Location = new System.Drawing.Point(7, 21);
            this.LineNum.Name = "LineNum";
            this.LineNum.ReadOnly = true;
            this.LineNum.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNum.Size = new System.Drawing.Size(28, 128);
            this.LineNum.TabIndex = 4;
            this.LineNum.Text = "";
            this.LineNum.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(439, 195);
            this.Controls.Add(this.ProcessFileCheckBox);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.file);
            this.Controls.Add(this.OutputGrouping);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PerryHMK4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.OutputGrouping.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RichTextBox OutputText;
        private System.Windows.Forms.CheckBox ProcessFileCheckBox;
        private System.Windows.Forms.GroupBox OutputGrouping;
        private System.Windows.Forms.RichTextBox LineNum;
    }
}

