using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;
using DataAccessLayer.DBObjects;

namespace Final_Pet_Store_Bernath
{
    public partial class CCError : Form
    {
        public CCError()
        {
            InitializeComponent();
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.instance != null)
            {
                ShoppingCart cartForm = ShoppingCart.instance;
                cartForm.Show();
                this.Hide();
            }
            else
            {
                ShoppingCart cartForm = new ShoppingCart();
                cartForm.Show();
                this.Hide();
            }
        }

        private void CCError_Load(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;
        }
    }
}
