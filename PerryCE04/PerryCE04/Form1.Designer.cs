namespace PerryCE04
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.select_file = new System.Windows.Forms.ToolStripMenuItem();
            this.file_name = new System.Windows.Forms.ToolStripTextBox();
            this.FoundMatchingIDs = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.AvgIDLabel = new System.Windows.Forms.Label();
            this.FindMatchingIDsButton = new System.Windows.Forms.Button();
            this.ShippingID = new System.Windows.Forms.TextBox();
            this.AvgID = new System.Windows.Forms.Label();
            this.CodeBeginning = new System.Windows.Forms.ComboBox();
            this.DisplayAvgID = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.select_file,
            this.file_name});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // select_file
            // 
            this.select_file.Name = "select_file";
            this.select_file.Size = new System.Drawing.Size(88, 27);
            this.select_file.Text = "Select File";
            this.select_file.Click += new System.EventHandler(this.select_file_Click);
            // 
            // file_name
            // 
            this.file_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_name.Name = "file_name";
            this.file_name.ReadOnly = true;
            this.file_name.Size = new System.Drawing.Size(100, 27);
            this.file_name.Text = "file name";
            this.file_name.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.file_name.Validating += new System.ComponentModel.CancelEventHandler(this.file_name_Validating);
            this.file_name.Validated += new System.EventHandler(this.file_name_Validated);
            // 
            // FoundMatchingIDs
            // 
            this.FoundMatchingIDs.BackColor = System.Drawing.SystemColors.Window;
            this.FoundMatchingIDs.Location = new System.Drawing.Point(12, 131);
            this.FoundMatchingIDs.Name = "FoundMatchingIDs";
            this.FoundMatchingIDs.ReadOnly = true;
            this.FoundMatchingIDs.Size = new System.Drawing.Size(476, 137);
            this.FoundMatchingIDs.TabIndex = 4;
            this.FoundMatchingIDs.Text = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AvgIDLabel
            // 
            this.AvgIDLabel.AutoSize = true;
            this.AvgIDLabel.Location = new System.Drawing.Point(135, 70);
            this.AvgIDLabel.Name = "AvgIDLabel";
            this.AvgIDLabel.Size = new System.Drawing.Size(120, 20);
            this.AvgIDLabel.TabIndex = 5;
            this.AvgIDLabel.Text = "Avg Shipping ID:";
            // 
            // FindMatchingIDsButton
            // 
            this.FindMatchingIDsButton.Location = new System.Drawing.Point(294, 98);
            this.FindMatchingIDsButton.Name = "FindMatchingIDsButton";
            this.FindMatchingIDsButton.Size = new System.Drawing.Size(194, 27);
            this.FindMatchingIDsButton.TabIndex = 6;
            this.FindMatchingIDsButton.Text = "Display Matching IDs";
            this.FindMatchingIDsButton.UseVisualStyleBackColor = true;
            this.FindMatchingIDsButton.Click += new System.EventHandler(this.FindMatchingIDsButton_Click);
            // 
            // ShippingID
            // 
            this.ShippingID.Location = new System.Drawing.Point(12, 98);
            this.ShippingID.Name = "ShippingID";
            this.ShippingID.Size = new System.Drawing.Size(248, 27);
            this.ShippingID.TabIndex = 7;
            this.ShippingID.Validating += new System.ComponentModel.CancelEventHandler(this.ShippingID_Validating);
            this.ShippingID.Validated += new System.EventHandler(this.ShippingID_Validated);
            // 
            // AvgID
            // 
            this.AvgID.AutoSize = true;
            this.AvgID.Location = new System.Drawing.Point(261, 70);
            this.AvgID.Name = "AvgID";
            this.AvgID.Size = new System.Drawing.Size(0, 20);
            this.AvgID.TabIndex = 8;
            // 
            // CodeBeginning
            // 
            this.CodeBeginning.FormattingEnabled = true;
            this.CodeBeginning.Items.AddRange(new object[] {
            "ATX",
            "RIO",
            "NYC"});
            this.CodeBeginning.Location = new System.Drawing.Point(12, 34);
            this.CodeBeginning.Name = "CodeBeginning";
            this.CodeBeginning.Size = new System.Drawing.Size(248, 28);
            this.CodeBeginning.TabIndex = 9;
            this.CodeBeginning.Text = "Choose First 3 Characters of Code";
            this.CodeBeginning.Validating += new System.ComponentModel.CancelEventHandler(this.CodeBeginning_Validating);
            this.CodeBeginning.Validated += new System.EventHandler(this.CodeBeginning_Validated);
            // 
            // DisplayAvgID
            // 
            this.DisplayAvgID.AutoSize = true;
            this.DisplayAvgID.Location = new System.Drawing.Point(296, 36);
            this.DisplayAvgID.Name = "DisplayAvgID";
            this.DisplayAvgID.Size = new System.Drawing.Size(192, 24);
            this.DisplayAvgID.TabIndex = 10;
            this.DisplayAvgID.Text = "Display Avg Shipping ID";
            this.DisplayAvgID.UseVisualStyleBackColor = true;
            this.DisplayAvgID.CheckedChanged += new System.EventHandler(this.DisplayAvgID_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(500, 276);
            this.Controls.Add(this.DisplayAvgID);
            this.Controls.Add(this.CodeBeginning);
            this.Controls.Add(this.AvgID);
            this.Controls.Add(this.ShippingID);
            this.Controls.Add(this.FindMatchingIDsButton);
            this.Controls.Add(this.AvgIDLabel);
            this.Controls.Add(this.FoundMatchingIDs);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PerryCE4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem select_file;
        private System.Windows.Forms.ToolStripTextBox file_name;
        private System.Windows.Forms.RichTextBox FoundMatchingIDs;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label AvgIDLabel;
        private System.Windows.Forms.CheckBox DisplayAvgID;
        private System.Windows.Forms.ComboBox CodeBeginning;
        private System.Windows.Forms.Label AvgID;
        private System.Windows.Forms.TextBox ShippingID;
        private System.Windows.Forms.Button FindMatchingIDsButton;
    }
}

