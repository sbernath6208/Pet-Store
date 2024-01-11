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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (SalesForm.instance != null)
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

        private void label3_Click(object sender, EventArgs e)
        {
            if (SalesForm.instance != null)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
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

        private void shoppingCartButton_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
