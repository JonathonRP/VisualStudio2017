namespace Pokedex
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.clearSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearQueryHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.dataGridControl1 = new WPFdataGrid.DataGridControl();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripComboBox1,
            this.clearSearchToolStripMenuItem,
            this.clearQueryHistoryToolStripMenuItem,
            this.fileNameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.EditDatabase});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // EditDatabase
            // 
            this.EditDatabase.Name = "EditDatabase";
            this.EditDatabase.Size = new System.Drawing.Size(177, 26);
            this.EditDatabase.Text = "Edit Database";
            this.EditDatabase.Click += new System.EventHandler(this.EditDatabase_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.Text = "Search";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.TextUpdate += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            this.toolStripComboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox1_KeyPress);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // clearSearchToolStripMenuItem
            // 
            this.clearSearchToolStripMenuItem.Name = "clearSearchToolStripMenuItem";
            this.clearSearchToolStripMenuItem.Size = new System.Drawing.Size(103, 28);
            this.clearSearchToolStripMenuItem.Text = "Clear Search";
            this.clearSearchToolStripMenuItem.Click += new System.EventHandler(this.clearSearchToolStripMenuItem_Click);
            // 
            // clearQueryHistoryToolStripMenuItem
            // 
            this.clearQueryHistoryToolStripMenuItem.Name = "clearQueryHistoryToolStripMenuItem";
            this.clearQueryHistoryToolStripMenuItem.Size = new System.Drawing.Size(154, 28);
            this.clearQueryHistoryToolStripMenuItem.Text = "Clear Search History";
            this.clearQueryHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearQueryHistoryToolStripMenuItem_Click);
            // 
            // fileNameToolStripMenuItem
            // 
            this.fileNameToolStripMenuItem.Name = "fileNameToolStripMenuItem";
            this.fileNameToolStripMenuItem.Size = new System.Drawing.Size(88, 28);
            this.fileNameToolStripMenuItem.Text = "File Name";
            this.fileNameToolStripMenuItem.Visible = false;
            this.fileNameToolStripMenuItem.Click += new System.EventHandler(this.fileNameToolStripMenuItem_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(128, 76);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.BackColorTransparent = true;
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 32);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(964, 573);
            this.elementHost1.TabIndex = 19;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.dataGridControl1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(964, 605);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Pokedex";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem clearQueryHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WPFdataGrid.DataGridControl dataGridControl1;
        private System.Windows.Forms.ToolStripMenuItem EditDatabase;
        private System.Windows.Forms.ToolStripMenuItem clearSearchToolStripMenuItem;
    }
}

