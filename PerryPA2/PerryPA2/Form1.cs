using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PerryPA2
{
    public partial class Form1 : Form
    {
        private Dictionary<int, CheckBox> Game = new Dictionary<int, CheckBox>();
        private Dictionary<int, ComboBox> SubscriptionChoicesForGame = new Dictionary<int, ComboBox>();
        private List<List<object>> Game_Selection = new List<List<object>>();

        private int i = 0;
        private double cost;
        private double discount;
        private double total;

        public Form1()
        {
            InitializeComponent();

            for (int i = 1; i <= Controls.OfType<CheckBox>().Count(); i++)
            {
                Game.Add(i, Controls.OfType<CheckBox>().Where(x => x.Name == $"Game{i}").First());
            }

            for (int i = 1; i <= Game.Count(); i++)
            {
                SubscriptionChoicesForGame.Add(i, SubscriptionsGrouping.Controls.OfType<ComboBox>().Where(x => x.Name.StartsWith($"Game{i}")).First());
            }

            for (int i = 0; i <= Game.Count(); i++)
            {
                Game_Selection.Add(new List<object>());
            }

            foreach(CheckBox CheckBox in Game.Values)
            {
                CheckBox.CheckedChanged += Game_CheckedChanged;
                CheckBox.KeyDown += EnterKeyPressedOnCheckBox;
            }

            foreach (ComboBox ComboBox in SubscriptionChoicesForGame.Values)
            {
                ComboBox.KeyDown += EnterKeyPressedInComboBox;
            }

            Default();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            foreach(CheckBox CheckBox in Game.Values)
            {
                CheckBox.Enabled = true;
                CheckBox.Checked = false;
            }

            errorProvider1.Clear();
            Default();
        }

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Perry PA2", "About", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void Game_CheckedChanged(object sender, EventArgs e)
        {
            int key = Game.Where(x => x.Value.Name == (sender as CheckBox).Name).First().Key;

            for (int i = key; i <= key; i++)
            {
                ShowSubscriptionChoicesFor(Game[i], SubscriptionChoicesForGame[i]);
                SubscriptionChoicesForGame[i].Focus();
            }
        }

        private void PromoCodeText2_Validating(object sender, CancelEventArgs e)
        {
            string errMsg;
            string error1 = errorProvider1.GetError((sender as TextBox));
            
            errorProvider1.SetIconAlignment((sender as TextBox), ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding((sender as TextBox), -20);

            if (!ValidPromoCode((sender as TextBox).Text, out errMsg))
            {
                if (!(SubscriptionChoicesForGame[1].Focused || SubscriptionChoicesForGame[2].Focused || SubscriptionChoicesForGame[3].Focused))
                {
                    e.Cancel = true;
                    (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
                    errorProvider1.SetError((sender as TextBox), errMsg);
                }

                string error2 = errorProvider1.GetError((sender as TextBox));

                if (error2 != error1)
                {
                    i++;
                }
                else if (error2 == error1 && i == 1)
                {
                    MessageBox.Show(errMsg, "Try Again",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    i--;
                }
            }
        }

        private void PromoCodeText2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((sender as TextBox), "");
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (AddToCartButton.Text == "Add to Cart")
            {
                if (Game[1].Checked || Game[2].Checked || Game[3].Checked)
                {
                    AddToCart();
                }
                else if (!(Game[1].Checked && Game[2].Checked && Game[3].Checked))
                {
                    MessageBox.Show("You need to pick a game", "Try Again", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Game1.Focus();
                }
            }

            else if (AddToCartButton.Text == "Apply")
            {
                foreach (CheckBox CheckBox in Game.Values)
                {
                    if(CheckBox.Checked)
                    {
                        DiscountCalculation();
                    }
                }

                DiscountInsert.Text = $"{discount:C}";
                TotalCalculation();
                TotalInsert.Text = $"{total:C}";

                AddToCartButton.Enabled = false;
                PromoCodeText1.Enabled = false;
                PromoCodeText2.Enabled = false;

                foreach (ComboBox ComboBox in SubscriptionChoicesForGame.Values)
                {
                    ComboBox.SelectionLength = 0;
                }

                BuyNow.Focus();
            }
        }

        private void BuyNow_Click(object sender, EventArgs e)
        {
            DialogResult Close = MessageBox.Show($"Items Purchased.\nTotal: {total}" 
                + $"\nWould you like to close the program?", "Puchase Confirmed", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Close == DialogResult.Yes)
            {
                Dispose(true);
            }
            else
            {
                Reset.PerformClick();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CheckoutGrouping.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            CostLabel.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            CostInsert.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            DiscountLabel.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            DiscountInsert.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            TotalLabel.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            TotalInsert.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
            BuyNow.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
        }

        private void EnterKeyPressedOnCheckBox(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int key = Game.Where(x => x.Value.Name == (sender as CheckBox).Name).First().Key;

                for (int i = key; i <= key; i++)
                {
                    Game[i].Checked = !Game[i].Checked;
                }
            }
        }

        private void EnterKeyPressedInComboBox(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                AddToCartButton.PerformClick();
            }
        }

        private void EnterKeyPressedInPromoCode(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (PromoCodeText2.TextLength == 0 && AddToCartButton.Text == "Add to Cart")
                {
                    DialogResult quick_question = 
                        MessageBox.Show("Did you mean to not apply a promocode?", "Question", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    
                    if(quick_question == DialogResult.Yes)
                    {
                        AddToCartButton.PerformClick();
                    }
                    else
                    {
                        PromoCodeText2.Focus();
                    }
                }
                else
                {
                    AddToCartButton.PerformClick();
                }
            }
        }

        private void ShowSubscriptionChoicesFor(CheckBox _Game, ComboBox _SubscriptionChoices)
        {
            _SubscriptionChoices.Visible = _Game.Checked;

            SubscriptionsGrouping.Visible = Game[1].Checked || Game[2].Checked || Game[3].Checked;
        }

        private void ChoiceMadeFor(CheckBox _Game, List<object> _Game_Selection, ComboBox _SubscriptionChoices)
        {
            if (_Game.Checked)
            {
                _Game_Selection.Add(_SubscriptionChoices.Text);
            }
            else
            {
                _Game_Selection.Clear();
            }
        }

        private bool ValidPromoCode(string PromoCode, out string errMsg)
        {
            System.Text.RegularExpressions.Regex numeric = new System.Text.RegularExpressions.Regex("^[0-9]+$");
            System.Text.RegularExpressions.Regex alphabets = new System.Text.RegularExpressions.Regex("^[A-z]+$");

            if (PromoCodeText1.Text != "RHZ" || PromoCode.Length > 0 && PromoCode.Length < 5 || AddToCartButton.Text == "Apply" && PromoCode.Length < 5)
            {
                if (PromoCodeText1.Text != "RHZ" || PromoCode.Length == 0)
                {
                    if (PromoCodeText1.Text == "RHZ")
                    {
                        errMsg = "A PromCode must be entered to be apply";
                        return false;
                    }
                    else
                    {
                        errMsg = "PromoCode must start with \"RHZ\" and contain 5 more Characters, that are either all Letters or all Numbers";
                        return false;
                    }
                }

                if (PromoCodeText1.Text != "RHZ" || PromoCode.Length > 0)
                {
                    if (!(numeric.IsMatch(PromoCodeText2.Text) || alphabets.IsMatch(PromoCodeText2.Text)))
                    {
                        errMsg = "PromoCode only contains either all letters or all numbers and no symbols!";
                        return false;
                    }
                    else
                    {
                        errMsg = "PromoCode must start with \"RHZ\" and contain 5 more Characters, that are either all Letters or all Numbers";
                        return false;
                    }
                }
            }

            if (PromoCodeText1.Text == "RHZ" && (PromoCode.Length == 0 || PromoCode.Length == 5) && AddToCartButton.Text == "Add to Cart")
            {
                if (PromoCode.Length == 0)
                {
                    errMsg = "";
                    return true;
                }
                if (PromoCode.Length == 5)
                {
                    if (numeric.IsMatch(PromoCode) || alphabets.IsMatch(PromoCode))
                    {
                        errMsg = "";
                        return true;
                    }
                    else
                    {
                        errMsg = "PromoCode only contains either all letters or all numbers and no symbols!";
                        return false;
                    }
                }
            }

            if (PromoCodeText1.Text == "RHZ" && PromoCode.Length == 5)
            {
                if (numeric.IsMatch(PromoCode) || alphabets.IsMatch(PromoCode))
                {
                    errMsg = "";
                    return true;
                }
                else
                {
                    errMsg = "PromoCode only contains either all letters or all numbers and no symbols!";
                    return false;
                }
            }

            errMsg = "PromoCode must be a valid Promotional Code."
                + "\nA valid PromoCode must start with \"RHZ\" and contain 5 more Characters, that are either all Letters or all Numbers";
            return false;
        }

        private void AddToCart()
        {
            List<string> game = new List<string>();

            for (int i = 0; i <= SubscriptionChoicesForGame.Count() + 1; i++)
            {
                game.Add(null);
            }

            for (int i = 1; i <= Game.Count; i++)
            {
                ChoiceMadeFor(Game[i], Game_Selection[i], SubscriptionChoicesForGame[i]);
            }

            Size = MaximumSize;

            foreach (CheckBox CheckBox in Game.Values)
            {
                CheckBox.Enabled = false;
            }

            foreach (Control Ctrl in Controls)
            {
                if (Ctrl is GroupBox)
                {
                    (Ctrl as GroupBox).Size = Ctrl.MinimumSize;
                }
                if (Ctrl is Button)
                {
                    (Ctrl as Button).Visible = true;
                }
            }

            foreach (ComboBox ComboBox in SubscriptionChoicesForGame.Values)
            {
                ComboBox.Size = ComboBox.MinimumSize;
                ComboBox.Enabled = false;
                ComboBox.SelectionLength = 0;
            }

            foreach (Control Ctrl in PromoCodeGrouping.Controls)
            {
                if (Ctrl is TextBox)
                {
                    if (Ctrl.Name == PromoCodeText2.Name)
                    {
                        (Ctrl as TextBox).Focus();
                    }
                }
            }

            for (int i = 1; i <= Game.Count; i++)
            {
                CheckOutReceiptApplying(game[i], Game_Selection[i]);
            }

            AddToCartButton.Text = "Apply";

            if (ValidPromoCode(PromoCodeText2.Text, out string errMsg))
            {
                AddToCartButton.Enabled = false;
                PromoCodeText1.Enabled = false;
                PromoCodeText2.Enabled = false;
                BuyNow.Focus();
            }
        }

        private void CostCalculation(string _game)
        {
            if (_game.Contains("3 Months"))
            {
                cost += 3 * 15.99;
            }
            else if (_game.Contains("6 Months"))
            {
                cost += 6 * 12.99;
            }
            else if (_game.Contains("12 Months"))
            {
                cost += 12 * 10.99;
            }
        }

        private void DiscountCalculation()
        {
            if (PromoCodeText1.Text.Contains("RHZ") && PromoCodeText2.TextLength == 5)
            {
                discount -= 5.00;
            }
        }

        private void TotalCalculation()
        {
            total = cost + discount;
        }

        private void CheckOutReceiptApplying(string _game, List<object> _Game_Selection)
        {
            if (_Game_Selection.Count >= 1)
            {
                _game = $"{_Game_Selection.Last()}";
                CostCalculation(_game);
                CostInsert.Text = $"{cost:C}";
                DiscountCalculation();
                DiscountInsert.Text = $"{discount:C}";
                TotalCalculation();
                TotalInsert.Text = $"{total:C}";
            }
        }

        private void Default()
        {
            cost = 0.0;
            discount = 0.0;
            total = 0.0;

            Size = MinimumSize;

            foreach (Control Ctrl in Controls)
            {
                if (Ctrl is GroupBox)
                {
                    (Ctrl as GroupBox).Size = Ctrl.MaximumSize;

                    foreach(Control ctrl in (Ctrl as GroupBox).Controls)
                    {
                        if (ctrl is ComboBox)
                        {
                            (ctrl as ComboBox).Size = ctrl.MaximumSize;
                            (ctrl as ComboBox).SelectedIndex = 2;
                            (ctrl as ComboBox).Enabled = true;
                        }

                        if (ctrl is TextBox)
                        {
                            (ctrl as TextBox).Enabled = true;

                            if (ctrl.Name == PromoCodeText1.Name)
                            {
                                (ctrl as TextBox).Text = "RHZ";
                            }
                            if (ctrl.Name == PromoCodeText2.Name)
                            {
                                (ctrl as TextBox).Text = null;
                            }
                        }

                        if (ctrl is Button)
                        {
                            (ctrl as Button).Enabled = true;
                            (ctrl as Button).Text = "Add to Cart";
                        }
                    }
                }

                if (Ctrl is CheckBox)
                {
                    (Ctrl as CheckBox).Focus();
                }
            }
        }
        
        protected override bool ProcessTabKey(bool forward)
        {
            if (Game[1].Focused || Game[3].Focused || AddToCartButton.Focused)
            {
                if (forward)
                {
                    if (Game[1].Focused)
                    {
                        return base.ProcessTabKey(forward);
                    }

                    if (Game3.Focused && SubscriptionsGrouping.Visible)
                    {
                        Game[1].Focus();
                    }

                    if (Game[3].Focused)
                    {
                        PromoCodeText2.Focus();
                    }

                    if (AddToCartButton.Focused)
                    {
                        Game[1].Focus();
                    }
                }
                else
                {
                    if (Game[1].Focused || Game[3].Focused)
                    {
                        PromoCodeText2.Focus();
                    }
                    else
                    {
                        return base.ProcessTabKey(forward);
                    }
                    
                }

                return true;
            }

            if(SubscriptionChoicesForGame[1].Focused || SubscriptionChoicesForGame[2].Focused || SubscriptionChoicesForGame[3].Focused)
            {
                if (forward)
                {
                    int key = 0;

                    foreach (ComboBox ComboBox in SubscriptionChoicesForGame.Values)
                    {
                        if (ComboBox.Focused)
                        {
                            key = SubscriptionChoicesForGame.Where(x => x.Value.Name == ComboBox.Name).First().Key;
                        }
                    }

                    if (key >= 3)
                    {
                        key = 0;
                    }

                    for (int i = key; i <= key; i++)
                    {
                        Game[i + 1].Focus();
                    }
                }
                else
                {
                    PromoCodeText2.Focus();
                }

                return true;
            }

            return base.ProcessTabKey(forward);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.Clear();
        }
        //Use tuple <bool,Generic>TryParse
    }
}
