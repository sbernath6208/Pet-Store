/// All images from ShutterStock 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;
using DataAccessLayer.DBObjects;
using System.Configuration; 


namespace Final_Pet_Store_Bernath
{
    public partial class MainForm : Form
    {
        public static MainForm instance;

        public TextBox userTextBoxRef;
        // MainForm.instance.userTextBoxRef.Text; 
        public int profileIdRef; 
        // MainForm.instance.profileIdRef; 

        public MainForm()
        {
            InitializeComponent();
            instance = this; 
        }

        private void userTextBox_Validating(object sender, CancelEventArgs e)
        {


            if (userTextBox.Text.Length == 0)
            {
                errorProvider.SetError(userTextBox, "User Name is required.");
                e.Cancel = true;
            }
            
            else
            {
                errorProvider.SetError(userTextBox, "");
                e.Cancel = false;

            }
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {


            if (passwordTextBox.Text.Length == 0)
            {
                errorProvider.SetError(passwordTextBox, "Password is required.");
                e.Cancel = true;
            }
            /*
           else if (passwordTextBox != userName.password)
           {
               errorProvider.SetError(passwordTextBox, "Incorrect password.");
               e.Cancel = true;
           }
           */
            else
            {
                errorProvider.SetError(userTextBox, "");
                e.Cancel = false;

            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool validUser = false;

            if (ValidateChildren())
            {
                List<Profile> profileList = ProfileDB.GetAll(); 
                foreach (Profile profile in profileList)
                {

                    if (userTextBox.Text.Equals(profile.UserName) && passwordTextBox.Text.Equals(profile.Password))
                    {
                        userTextBoxRef = userTextBox;
                        int profileId = profile.ProfileId;
                        profileIdRef = profileId; 
                        validUser = true; 

                        HomePage homePage = new HomePage();
                        homePage.Show();
                        this.Hide();
                    }
                    
                }
                if (validUser == false)
                {
                    loginErr logErrForm = new loginErr();
                    logErrForm.Show();
                    this.Hide();
                }
            }
            


            /*
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\sbern\source\repos\Final_Pet Store_Bernath\Final_Pet Store_Bernath\PetCo.mdf;Integrated Security=True;");
            string query = "Select * from dbo.profile Where username = '" + userTextBox.Text.Trim() + "' and password = '" + passwordTextBox.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                userTextBoxRef = userTextBox;
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Hide();
            }*/
        }

        private void noLoginButton_Click(object sender, EventArgs e)
        {
            /*
            if (userTextBoxRef.Text != "")
                userTextBoxRef.Text = "";
            */
            if (MainForm.instance.userTextBoxRef == null)
            {
                
                if (SalesForm.instance != null)
                {
                    //foreach (object item in SalesForm.instance.salesListBoxRef.Items)
                    //    SalesForm.instance.salesListBoxRef.Items.Remove(item);
                    SalesForm.instance = null;
                }
                if (browseAllProducts.instance != null)
                {
                   // foreach (object item in browseAllProducts.instance.browseListBoxRef.Items)
                    //    browseAllProducts.instance.browseListBoxRef.Items.Remove(item);
                    browseAllProducts.instance = null;
                }
               
                if (PetShop.instance != null)
                    PetShop.instance = null;
                if (ShoppingCart.instance != null)
                {
                    //foreach (object item in ShoppingCart.instance.shoppingCartListBoxRef.Items)
                    //    ShoppingCart.instance.shoppingCartListBoxRef.Items.Remove(item); 
                    ShoppingCart.instance = null;
                }
                
                
            }

            HomePage homeForm = new HomePage();
            homeForm.Show();
            this.Hide(); 
        }

        private void createNewAccountButton_Click(object sender, EventArgs e)
        {
            createNewUser createUser = new createNewUser();
            createUser.Show();
            this.Hide();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide(); 
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            /*
            ShoppingCart shoppingCartForm = new ShoppingCart();
            shoppingCartForm.Show();
            this.Hide();
            */
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search site"); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DALExec.GetInstance("PetCoDB");

            if (SalesForm.instance != null)
            {
                //foreach (object item in SalesForm.instance.salesListBoxRef.Items)
                //    SalesForm.instance.salesListBoxRef.Items.Remove(item);
                SalesForm.instance = null;
            }
            if (browseAllProducts.instance != null)
            {
                // foreach (object item in browseAllProducts.instance.browseListBoxRef.Items)
                //    browseAllProducts.instance.browseListBoxRef.Items.Remove(item);
                browseAllProducts.instance = null;
            }

            if (PetShop.instance != null)
                PetShop.instance = null;
            if (ShoppingCart.instance != null)
            {
                //foreach (object item in ShoppingCart.instance.shoppingCartListBoxRef.Items)
                //    ShoppingCart.instance.shoppingCartListBoxRef.Items.Remove(item); 
                ShoppingCart.instance = null;
            }
        }
    }
}
