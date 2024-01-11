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
    public partial class OrderConfirmed : Form
    {
        public OrderConfirmed()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HomePage homePageForm = new HomePage();
            homePageForm.Show();
            this.Hide(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            reviewCartDetails reviewDetailsForm = new reviewCartDetails();
            reviewDetailsForm.Show();
            this.Hide(); 
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            /*
            ShoppingCart shopCartForm = new ShoppingCart();
            shopCartForm.Show();
            this.Hide();
            */
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }

        private void OrderConfirmed_Load(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            totalBillLabel.Text = reviewCartDetails.instance.totalCostRef.Text;
            estDeliveryLabel.Text = reviewCartDetails.instance.estDeliveryDateRef.Text;
        }
    }
}
