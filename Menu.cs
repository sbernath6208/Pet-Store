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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
            {
                userOrderHistory userOrderHist = new userOrderHistory();
                userOrderHist.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User not logged in.  Please login and try again"); 
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
            {
                updateUserInfo updateForm = new updateUserInfo();
                updateForm.Show();
                this.Hide();
            }
            else
            { 
                MessageBox.Show("User not logged in, please login and try again");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            addPet addPetForm = new addPet();
            addPetForm.Show();
            this.Hide(); 
        }

        private void label8_Click(object sender, EventArgs e)
        {
            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide(); 
        }
        /*
        private void label10_Click(object sender, EventArgs e)
        {
            MainForm loginForm = new MainForm();
            loginForm.Show();
            this.Hide(); 
        }
        */
        private void label6_Click(object sender, EventArgs e)
        {
            if (browseAllProducts.instance != null)
            {
                browseAllProducts browseProductsForm = browseAllProducts.instance;
                browseProductsForm.Show();
                this.Hide();
            }
            else
            {
                browseAllProducts browseProductsForm = new browseAllProducts();
                browseProductsForm.Show();
                this.Hide();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {if (SalesForm.instance != null)
            {
                SalesForm salesForm = SalesForm.instance;
                salesForm.Show();
                this.Hide();
            }
            else
            {
                SalesForm salesForm = new SalesForm();
                salesForm.Show();
                this.Hide();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide(); 
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (ShoppingCart.instance != null)
            {
                ShoppingCart shoppingCartForm = ShoppingCart.instance;
                shoppingCartForm.Show();
                this.Hide();
            }
            else
            {
                ShoppingCart shoppingCartForm = new ShoppingCart();
                shoppingCartForm.Show();
                this.Hide();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = ", " + MainForm.instance.userTextBoxRef.Text;
            else
                userNameLabel.Hide();

            if (MainForm.instance.userTextBoxRef != null)
                panel10.Hide();
            else
                panel11.Hide(); 
        }

        private void Login_Click(object sender, EventArgs e)
        {
            MainForm loginForm = new MainForm();
            loginForm.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            MainForm loginForm = new MainForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
