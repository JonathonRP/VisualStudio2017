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
            this.FoundMatchingCodes = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.AvgIDLabel = new System.Windows.Forms.Label();
            this.FindMatchingCodesButton = new System.Windows.Forms.Button();
            this.shippingID = new System.Windows.Forms.TextBox();
            this.RoutingNumber = new System.Windows.Forms.ComboBox();
            this.DisplayAvgID = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.file_name = new System.Windows.Forms.ToolStripMenuItem();
            this.AvgID = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(500, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // select_file
            // 
            this.select_file.Name = "select_file";
            this.select_file.Size = new System.Drawing.Size(88, 24);
            this.select_file.Text = "Select File";
            this.select_file.Click += new System.EventHandler(this.select_file_Click);
            // 
            // FoundMatchingCodes
            // 
            this.FoundMatchingCodes.BackColor = System.Drawing.SystemColors.Window;
            this.FoundMatchingCodes.Location = new System.Drawing.Point(12, 131);
            this.FoundMatchingCodes.Name = "FoundMatchingCodes";
            this.FoundMatchingCodes.ReadOnly = true;
            this.FoundMatchingCodes.Size = new System.Drawing.Size(476, 137);
            this.FoundMatchingCodes.TabIndex = 4;
            this.FoundMatchingCodes.Text = "";
            this.FoundMatchingCodes.Visible = false;
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
            // FindMatchingCodesButton
            // 
            this.FindMatchingCodesButton.Location = new System.Drawing.Point(294, 98);
            this.FindMatchingCodesButton.Name = "FindMatchingCodesButton";
            this.FindMatchingCodesButton.Size = new System.Drawing.Size(194, 27);
            this.FindMatchingCodesButton.TabIndex = 6;
            this.FindMatchingCodesButton.Text = "Find Matching Codes";
            this.FindMatchingCodesButton.UseVisualStyleBackColor = true;
            this.FindMatchingCodesButton.Visible = false;
            this.FindMatchingCodesButton.Click += new System.EventHandler(this.FindMatchingIDsButton_Click);
            // 
            // shippingID
            // 
            this.shippingID.Location = new System.Drawing.Point(12, 98);
            this.shippingID.Name = "shippingID";
            this.shippingID.Size = new System.Drawing.Size(248, 27);
            this.shippingID.TabIndex = 7;
            this.shippingID.Text = "Input Shipping ID";
            this.shippingID.Visible = false;
            this.shippingID.Validating += new System.ComponentModel.CancelEventHandler(this.ShippingID_Validating);
            this.shippingID.Validated += new System.EventHandler(this.ShippingID_Validated);
            // 
            // RoutingNumber
            // 
            this.RoutingNumber.FormattingEnabled = true;
            this.RoutingNumber.Items.AddRange(new object[] {
            "ATX",
            "RIO",
            "NYC"});
            this.RoutingNumber.Location = new System.Drawing.Point(12, 34);
            this.RoutingNumber.Name = "RoutingNumber";
            this.RoutingNumber.Size = new System.Drawing.Size(248, 28);
            this.RoutingNumber.TabIndex = 9;
            this.RoutingNumber.Text = "Starting Letters of Routing Number";
            this.RoutingNumber.Validating += new System.ComponentModel.CancelEventHandler(this.CodeBeginning_Validating);
            this.RoutingNumber.Validated += new System.EventHandler(this.CodeBeginning_Validated);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // file_name
            // 
            this.file_name.Name = "file_name";
            this.file_name.Size = new System.Drawing.Size(83, 24);
            this.file_name.Text = "file name";
            this.file_name.Click += new System.EventHandler(this.file_name_Click);
            // 
            // AvgID
            // 
            this.AvgID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AvgID.CausesValidation = false;
            this.AvgID.Location = new System.Drawing.Point(261, 67);
            this.AvgID.Name = "AvgID";
            this.AvgID.ReadOnly = true;
            this.AvgID.Size = new System.Drawing.Size(100, 20);
            this.AvgID.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(500, 276);
            this.Controls.Add(this.AvgID);
            this.Controls.Add(this.DisplayAvgID);
            this.Controls.Add(this.RoutingNumber);
            this.Controls.Add(this.shippingID);
            this.Controls.Add(this.FindMatchingCodesButton);
            this.Controls.Add(this.AvgIDLabel);
            this.Controls.Add(this.FoundMatchingCodes);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PerryCE4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem select_file;
        private System.Windows.Forms.RichTextBox FoundMatchingCodes;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label AvgIDLabel;
        private System.Windows.Forms.CheckBox DisplayAvgID;
        private System.Windows.Forms.ComboBox RoutingNumber;
        private System.Windows.Forms.TextBox shippingID;
        private System.Windows.Forms.Button FindMatchingCodesButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem file_name;
        private System.Windows.Forms.TextBox AvgID;
    }
}

