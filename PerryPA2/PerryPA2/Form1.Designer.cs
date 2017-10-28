namespace PerryPA2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.PromoCodeLabel = new System.Windows.Forms.Label();
            this.PromoCodeText2 = new System.Windows.Forms.TextBox();
            this.PromoCodeGrouping = new System.Windows.Forms.GroupBox();
            this.PromoCodeText1 = new System.Windows.Forms.TextBox();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.Game1SubscriptionChoices = new System.Windows.Forms.ComboBox();
            this.Game2SubscriptionChoices = new System.Windows.Forms.ComboBox();
            this.Game3SubscriptionChoices = new System.Windows.Forms.ComboBox();
            this.Game1 = new System.Windows.Forms.CheckBox();
            this.Game2 = new System.Windows.Forms.CheckBox();
            this.Game3 = new System.Windows.Forms.CheckBox();
            this.SubscriptionsGrouping = new System.Windows.Forms.GroupBox();
            this.CostLabel = new System.Windows.Forms.Label();
            this.DiscountLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.CheckoutGrouping = new System.Windows.Forms.GroupBox();
            this.TotalInsert = new System.Windows.Forms.TextBox();
            this.DiscountInsert = new System.Windows.Forms.TextBox();
            this.CostInsert = new System.Windows.Forms.TextBox();
            this.BuyNow = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.PromoCodeGrouping.SuspendLayout();
            this.SubscriptionsGrouping.SuspendLayout();
            this.CheckoutGrouping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reset,
            this.About});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 2, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(366, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Reset
            // 
            this.Reset.BackColor = System.Drawing.SystemColors.Control;
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(57, 24);
            this.Reset.Text = "Reset";
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.SystemColors.Control;
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(62, 24);
            this.About.Text = "About";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // PromoCodeLabel
            // 
            this.PromoCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PromoCodeLabel.AutoSize = true;
            this.PromoCodeLabel.Location = new System.Drawing.Point(52, 24);
            this.PromoCodeLabel.Name = "PromoCodeLabel";
            this.PromoCodeLabel.Size = new System.Drawing.Size(17, 17);
            this.PromoCodeLabel.TabIndex = 4;
            this.PromoCodeLabel.Text = " -";
            // 
            // PromoCodeText2
            // 
            this.PromoCodeText2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PromoCodeText2.Location = new System.Drawing.Point(75, 21);
            this.PromoCodeText2.MaxLength = 5;
            this.PromoCodeText2.Name = "PromoCodeText2";
            this.PromoCodeText2.Size = new System.Drawing.Size(112, 22);
            this.PromoCodeText2.TabIndex = 3;
            this.PromoCodeText2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKeyPressedInPromoCode);
            this.PromoCodeText2.Validating += new System.ComponentModel.CancelEventHandler(this.PromoCodeText2_Validating);
            this.PromoCodeText2.Validated += new System.EventHandler(this.PromoCodeText2_Validated);
            // 
            // PromoCodeGrouping
            // 
            this.PromoCodeGrouping.Controls.Add(this.PromoCodeText1);
            this.PromoCodeGrouping.Controls.Add(this.AddToCartButton);
            this.PromoCodeGrouping.Controls.Add(this.PromoCodeText2);
            this.PromoCodeGrouping.Controls.Add(this.PromoCodeLabel);
            this.PromoCodeGrouping.Location = new System.Drawing.Point(12, 161);
            this.PromoCodeGrouping.MaximumSize = new System.Drawing.Size(281, 59);
            this.PromoCodeGrouping.MinimumSize = new System.Drawing.Size(260, 59);
            this.PromoCodeGrouping.Name = "PromoCodeGrouping";
            this.PromoCodeGrouping.Size = new System.Drawing.Size(260, 59);
            this.PromoCodeGrouping.TabIndex = 5;
            this.PromoCodeGrouping.TabStop = false;
            this.PromoCodeGrouping.Text = "PromoCode";
            // 
            // PromoCodeText1
            // 
            this.PromoCodeText1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PromoCodeText1.CausesValidation = false;
            this.PromoCodeText1.Location = new System.Drawing.Point(6, 21);
            this.PromoCodeText1.MaxLength = 3;
            this.PromoCodeText1.Name = "PromoCodeText1";
            this.PromoCodeText1.Size = new System.Drawing.Size(40, 22);
            this.PromoCodeText1.TabIndex = 7;
            this.PromoCodeText1.Text = "RHZ";
            this.PromoCodeText1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddToCartButton.Location = new System.Drawing.Point(193, 12);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(60, 40);
            this.AddToCartButton.TabIndex = 6;
            this.AddToCartButton.Text = "Add to\r\nCart";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // Game1SubscriptionChoices
            // 
            this.Game1SubscriptionChoices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Game1SubscriptionChoices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Game1SubscriptionChoices.CausesValidation = false;
            this.Game1SubscriptionChoices.FormattingEnabled = true;
            this.Game1SubscriptionChoices.Items.AddRange(new object[] {
            "3 Months",
            "6 Months",
            "12 Months"});
            this.Game1SubscriptionChoices.Location = new System.Drawing.Point(8, 26);
            this.Game1SubscriptionChoices.MaximumSize = new System.Drawing.Size(171, 0);
            this.Game1SubscriptionChoices.MinimumSize = new System.Drawing.Size(103, 0);
            this.Game1SubscriptionChoices.Name = "Game1SubscriptionChoices";
            this.Game1SubscriptionChoices.Size = new System.Drawing.Size(103, 24);
            this.Game1SubscriptionChoices.TabIndex = 6;
            this.Game1SubscriptionChoices.Visible = false;
            // 
            // Game2SubscriptionChoices
            // 
            this.Game2SubscriptionChoices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Game2SubscriptionChoices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Game2SubscriptionChoices.CausesValidation = false;
            this.Game2SubscriptionChoices.FormattingEnabled = true;
            this.Game2SubscriptionChoices.Items.AddRange(new object[] {
            "3 Months",
            "6 Months",
            "12 Months"});
            this.Game2SubscriptionChoices.Location = new System.Drawing.Point(8, 56);
            this.Game2SubscriptionChoices.MaximumSize = new System.Drawing.Size(171, 0);
            this.Game2SubscriptionChoices.MinimumSize = new System.Drawing.Size(103, 0);
            this.Game2SubscriptionChoices.Name = "Game2SubscriptionChoices";
            this.Game2SubscriptionChoices.Size = new System.Drawing.Size(103, 24);
            this.Game2SubscriptionChoices.TabIndex = 7;
            this.Game2SubscriptionChoices.Visible = false;
            // 
            // Game3SubscriptionChoices
            // 
            this.Game3SubscriptionChoices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.Game3SubscriptionChoices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Game3SubscriptionChoices.CausesValidation = false;
            this.Game3SubscriptionChoices.FormattingEnabled = true;
            this.Game3SubscriptionChoices.Items.AddRange(new object[] {
            "3 Months",
            "6 Months",
            "12 Months"});
            this.Game3SubscriptionChoices.Location = new System.Drawing.Point(8, 86);
            this.Game3SubscriptionChoices.MaximumSize = new System.Drawing.Size(171, 0);
            this.Game3SubscriptionChoices.MinimumSize = new System.Drawing.Size(103, 0);
            this.Game3SubscriptionChoices.Name = "Game3SubscriptionChoices";
            this.Game3SubscriptionChoices.Size = new System.Drawing.Size(103, 24);
            this.Game3SubscriptionChoices.TabIndex = 8;
            this.Game3SubscriptionChoices.Visible = false;
            // 
            // Game1
            // 
            this.Game1.AutoSize = true;
            this.Game1.CausesValidation = false;
            this.Game1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game1.Location = new System.Drawing.Point(12, 57);
            this.Game1.Name = "Game1";
            this.Game1.Size = new System.Drawing.Size(90, 24);
            this.Game1.TabIndex = 9;
            this.Game1.Text = "Game 1";
            this.Game1.UseVisualStyleBackColor = true;
            // 
            // Game2
            // 
            this.Game2.AutoSize = true;
            this.Game2.CausesValidation = false;
            this.Game2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game2.Location = new System.Drawing.Point(12, 87);
            this.Game2.Name = "Game2";
            this.Game2.Size = new System.Drawing.Size(90, 24);
            this.Game2.TabIndex = 10;
            this.Game2.Text = "Game 2";
            this.Game2.UseVisualStyleBackColor = true;
            // 
            // Game3
            // 
            this.Game3.AutoSize = true;
            this.Game3.CausesValidation = false;
            this.Game3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game3.Location = new System.Drawing.Point(12, 117);
            this.Game3.Name = "Game3";
            this.Game3.Size = new System.Drawing.Size(90, 24);
            this.Game3.TabIndex = 11;
            this.Game3.Text = "Game 3";
            this.Game3.UseVisualStyleBackColor = true;
            // 
            // SubscriptionsGrouping
            // 
            this.SubscriptionsGrouping.Controls.Add(this.Game2SubscriptionChoices);
            this.SubscriptionsGrouping.Controls.Add(this.Game1SubscriptionChoices);
            this.SubscriptionsGrouping.Controls.Add(this.Game3SubscriptionChoices);
            this.SubscriptionsGrouping.Location = new System.Drawing.Point(108, 31);
            this.SubscriptionsGrouping.MaximumSize = new System.Drawing.Size(185, 124);
            this.SubscriptionsGrouping.MinimumSize = new System.Drawing.Size(120, 124);
            this.SubscriptionsGrouping.Name = "SubscriptionsGrouping";
            this.SubscriptionsGrouping.Size = new System.Drawing.Size(120, 124);
            this.SubscriptionsGrouping.TabIndex = 12;
            this.SubscriptionsGrouping.TabStop = false;
            this.SubscriptionsGrouping.Text = "Subscriptions";
            this.SubscriptionsGrouping.Visible = false;
            // 
            // CostLabel
            // 
            this.CostLabel.BackColor = System.Drawing.SystemColors.Control;
            this.CostLabel.Location = new System.Drawing.Point(6, 24);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CostLabel.Size = new System.Drawing.Size(67, 22);
            this.CostLabel.TabIndex = 13;
            this.CostLabel.Text = "Cost:";
            this.CostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CostLabel.Visible = false;
            // 
            // DiscountLabel
            // 
            this.DiscountLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DiscountLabel.Location = new System.Drawing.Point(6, 56);
            this.DiscountLabel.Name = "DiscountLabel";
            this.DiscountLabel.Size = new System.Drawing.Size(67, 22);
            this.DiscountLabel.TabIndex = 14;
            this.DiscountLabel.Text = "Discount:";
            this.DiscountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DiscountLabel.Visible = false;
            // 
            // TotalLabel
            // 
            this.TotalLabel.Location = new System.Drawing.Point(6, 90);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(67, 17);
            this.TotalLabel.TabIndex = 15;
            this.TotalLabel.Text = "Total:";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TotalLabel.Visible = false;
            // 
            // CheckoutGrouping
            // 
            this.CheckoutGrouping.Controls.Add(this.TotalInsert);
            this.CheckoutGrouping.Controls.Add(this.DiscountInsert);
            this.CheckoutGrouping.Controls.Add(this.CostInsert);
            this.CheckoutGrouping.Controls.Add(this.CostLabel);
            this.CheckoutGrouping.Controls.Add(this.DiscountLabel);
            this.CheckoutGrouping.Controls.Add(this.TotalLabel);
            this.CheckoutGrouping.Location = new System.Drawing.Point(234, 31);
            this.CheckoutGrouping.MaximumSize = new System.Drawing.Size(120, 124);
            this.CheckoutGrouping.MinimumSize = new System.Drawing.Size(120, 124);
            this.CheckoutGrouping.Name = "CheckoutGrouping";
            this.CheckoutGrouping.Size = new System.Drawing.Size(120, 124);
            this.CheckoutGrouping.TabIndex = 16;
            this.CheckoutGrouping.TabStop = false;
            this.CheckoutGrouping.Text = "Cart";
            this.CheckoutGrouping.Visible = false;
            // 
            // TotalInsert
            // 
            this.TotalInsert.BackColor = System.Drawing.SystemColors.Control;
            this.TotalInsert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalInsert.Location = new System.Drawing.Point(72, 92);
            this.TotalInsert.Name = "TotalInsert";
            this.TotalInsert.ReadOnly = true;
            this.TotalInsert.Size = new System.Drawing.Size(46, 15);
            this.TotalInsert.TabIndex = 17;
            this.TotalInsert.Visible = false;
            // 
            // DiscountInsert
            // 
            this.DiscountInsert.BackColor = System.Drawing.SystemColors.Control;
            this.DiscountInsert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiscountInsert.Location = new System.Drawing.Point(72, 61);
            this.DiscountInsert.Name = "DiscountInsert";
            this.DiscountInsert.ReadOnly = true;
            this.DiscountInsert.Size = new System.Drawing.Size(46, 15);
            this.DiscountInsert.TabIndex = 16;
            this.DiscountInsert.Visible = false;
            // 
            // CostInsert
            // 
            this.CostInsert.BackColor = System.Drawing.SystemColors.Control;
            this.CostInsert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CostInsert.Location = new System.Drawing.Point(72, 29);
            this.CostInsert.Name = "CostInsert";
            this.CostInsert.ReadOnly = true;
            this.CostInsert.Size = new System.Drawing.Size(46, 15);
            this.CostInsert.TabIndex = 8;
            this.CostInsert.Visible = false;
            // 
            // BuyNow
            // 
            this.BuyNow.CausesValidation = false;
            this.BuyNow.Location = new System.Drawing.Point(278, 167);
            this.BuyNow.Name = "BuyNow";
            this.BuyNow.Size = new System.Drawing.Size(76, 53);
            this.BuyNow.TabIndex = 17;
            this.BuyNow.Text = "Buy Now";
            this.BuyNow.UseVisualStyleBackColor = true;
            this.BuyNow.Visible = false;
            this.BuyNow.Click += new System.EventHandler(this.BuyNow_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(366, 232);
            this.Controls.Add(this.BuyNow);
            this.Controls.Add(this.CheckoutGrouping);
            this.Controls.Add(this.Game3);
            this.Controls.Add(this.Game2);
            this.Controls.Add(this.Game1);
            this.Controls.Add(this.PromoCodeGrouping);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.SubscriptionsGrouping);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(384, 279);
            this.MinimumSize = new System.Drawing.Size(323, 279);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PerryPA2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PromoCodeGrouping.ResumeLayout(false);
            this.PromoCodeGrouping.PerformLayout();
            this.SubscriptionsGrouping.ResumeLayout(false);
            this.CheckoutGrouping.ResumeLayout(false);
            this.CheckoutGrouping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label PromoCodeLabel;
        private System.Windows.Forms.TextBox PromoCodeText2;
        private System.Windows.Forms.GroupBox PromoCodeGrouping;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.ToolStripMenuItem Reset;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ComboBox Game1SubscriptionChoices;
        private System.Windows.Forms.ComboBox Game2SubscriptionChoices;
        private System.Windows.Forms.ComboBox Game3SubscriptionChoices;
        private System.Windows.Forms.CheckBox Game1;
        private System.Windows.Forms.CheckBox Game2;
        private System.Windows.Forms.CheckBox Game3;
        private System.Windows.Forms.GroupBox SubscriptionsGrouping;
        private System.Windows.Forms.TextBox PromoCodeText1;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label DiscountLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.GroupBox CheckoutGrouping;
        private System.Windows.Forms.TextBox TotalInsert;
        private System.Windows.Forms.TextBox DiscountInsert;
        private System.Windows.Forms.TextBox CostInsert;
        private System.Windows.Forms.Button BuyNow;
        public System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

