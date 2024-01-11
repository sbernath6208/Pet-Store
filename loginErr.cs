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
    public partial class loginErr : Form
    {
        public loginErr()
        {
            InitializeComponent();
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            /*
            ShoppingCart shoppingCartForm = new ShoppingCart();
            shoppingCartForm.Show();
            this.Hide();
            */
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            HomePage homePageForm = new HomePage();
            homePageForm.Show();
            this.Hide();

        }

        private void createNewAccountButton_Click(object sender, EventArgs e)
        {
            createNewUser createUser = new createNewUser();
            createUser.Show();
            this.Hide();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            MainForm loginForm = new MainForm();
            loginForm.Show();
            this.Hide(); 
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }

        private void loginErr_Load(object sender, EventArgs e)
        {

        }
    }
}
