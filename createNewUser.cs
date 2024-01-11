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
using System.Text.RegularExpressions;
using System.Linq; 

namespace Final_Pet_Store_Bernath
{
    public partial class createNewUser : Form
    {
        public createNewUser()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void userNameTextBox_Validating(object sender, CancelEventArgs e)
        {

            /*
            if ((userNameTextBox.Text == "jSmith") || (userNameTextBox.Text == "jDoe") || (userNameTextBox.Text == "jJohnson") || (userNameTextBox.Text == "pPaulson")  )
            {
                errorProvider.SetError(userNameTextBox, "Username taken, try a different name.");
                e.Cancel = true;
            }
            */
            List<Profile> allProfiles = new List<Profile>();
            allProfiles = ProfileDB.GetAll();
            

            foreach (Profile profile in allProfiles)
            {
                //MessageBox.Show(profile.UserName); 
                if (userNameTextBox.Text == profile.UserName)
                {
                    userNameTextBox.Text = "";
                    MessageBox.Show("Error, user name already taken.  Please choose another user name.");
                    errorProvider.SetError(userNameTextBox, "User Name is already taken.  Please choose another user name.");
                    e.Cancel = true;
                }
            }

            if (userNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(userNameTextBox, "User Name is required.");
                e.Cancel = true;
            }
            else if (!(Regex.IsMatch(userNameTextBox.Text, @"^[a-zA-Z]+$")))
            {
                errorProvider.SetError(userNameTextBox, "User Name must be letters only and cannot contain white space.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(userNameTextBox, "");
                e.Cancel = false;

            }
            
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            bool haveLetter = passwordTextBox.Text.Any(c => char.IsLetter(c));
            bool haveDigit = passwordTextBox.Text.Any(c => char.IsDigit(c));
            //bool haveSymbol = passwordTextBox.Text.Any(c => char.IsSymbol(c));


            if (passwordTextBox.Text.Length < 8)
            {
                errorProvider.SetError(passwordTextBox, "Password must be at least 8 characters long.");
                e.Cancel = true;
            }
            else if (!haveLetter)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain a letter.");
                e.Cancel = true;
            }
            else if (!haveDigit)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain a digit.");
                e.Cancel = true;
            }
            /*
            else if (!haveSymbol)
            {
                errorProvider.SetError(passwordTextBox, "Password must contain a symbol that isn't '!', '@', or '#'");
                e.Cancel = true;
            }
            */
            /*
            else if (passwordTextBox != userName.password)
            {
                errorProvider.SetError(passwordTextBox, "Incorrect password.");
                e.Cancel = true;
            }
            */
            else
            {
                errorProvider.SetError(passwordTextBox, "");
                e.Cancel = false;

            }
        }

        private void retypepwdTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (retypePwdTextBox.Text.Length == 0)
            {
                errorProvider.SetError(retypePwdTextBox, "Retyped password is required.");
                e.Cancel = true;
            }
            else if (retypePwdTextBox.Text != passwordTextBox.Text)
            {
                errorProvider.SetError(retypePwdTextBox, "Retyped password must match password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(retypePwdTextBox, "");
                e.Cancel = false;

            }
        }

        private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (firstNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(firstNameTextBox, "First name is required.");
                e.Cancel = true;
            }
            else if (!(Regex.IsMatch(firstNameTextBox.Text, @"^[a-zA-Z]+$")))
            {
                errorProvider.SetError(firstNameTextBox, "First name must use alphabet characters only.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(firstNameTextBox, "");
                e.Cancel = false;

            }
        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (lastNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(lastNameTextBox, "Last name is required.");
                e.Cancel = true;
            }
            else if (!(Regex.IsMatch(lastNameTextBox.Text, @"^[a-zA-Z]+$")))
            {
                errorProvider.SetError(lastNameTextBox, "Last name must use alphabet characters only.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(lastNameTextBox, "");
                e.Cancel = false;

            }
        }

        private void streetTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (streetTextBox.Text.Length == 0)
            {
                errorProvider.SetError(streetTextBox, "Street is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(streetTextBox, "");
                e.Cancel = false;

            }
        }

        private void cityTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (cityTextBox.Text.Length == 0)
            {
                errorProvider.SetError(cityTextBox, "City is required.");
                e.Cancel = true;
            }
            else if (!(Regex.IsMatch(cityTextBox.Text, @"^[a-zA-Z ]+$")))
            {
                errorProvider.SetError(cityTextBox, "City must use alphabet characters and spaces only.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cityTextBox, "");
                e.Cancel = false;

            }
        }

        private void stateTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (stateTextBox.Text.Length == 0)
            {
                errorProvider.SetError(stateTextBox, "State is required.");
                e.Cancel = true;
            }
            else if (!(Regex.IsMatch(stateTextBox.Text, @"^[a-zA-Z]+$")))
            {
                errorProvider.SetError(stateTextBox, "State must use alphabet characters only.");
                e.Cancel = true;
            }
            else if ((stateTextBox.Text.Length < 2) || (stateTextBox.Text.Length > 2))
            {
                errorProvider.SetError(stateTextBox, "State must use two letter code.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(stateTextBox, "");
                e.Cancel = false;

            }
        }

        private void zipCodeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((zipCodeTextBox.Text.Length < 5) || (zipCodeTextBox.Text.Length > 5))
            {
                errorProvider.SetError(zipCodeTextBox, "Zip code must be five digits.");
                e.Cancel = true;
            }

            else if (!(Regex.IsMatch(zipCodeTextBox.Text, @"^\d+$")))
            {
                errorProvider.SetError(zipCodeTextBox, "Zip code  must be integers only.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(zipCodeTextBox, "");
                e.Cancel = false;

            }
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (emailTextBox.Text.Length == 0)
            {
                errorProvider.SetError(emailTextBox, "Email is required.");
                e.Cancel = true;
            }
            else if (!(emailTextBox.Text.Contains('@')))
            {
                errorProvider.SetError(emailTextBox, "Email must contain '@' char.");
                e.Cancel = true;
            }
            else if (!(emailTextBox.Text.Contains('.')))
            {
                errorProvider.SetError(emailTextBox, "Email must contain '.' char.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(emailTextBox, "");
                e.Cancel = false;

            }
        }

        private void phoneTextBox_Validating(object sender, CancelEventArgs e)
        {
            if ((phoneTextBox.Text.Length < 10) || (phoneTextBox.Text.Length > 10))
            {
                errorProvider.SetError(phoneTextBox, "Phone number must be ten digits.");
                e.Cancel = true;
            }

            else if (!(Regex.IsMatch(phoneTextBox.Text, @"^\d+$")))
            {
                errorProvider.SetError(phoneTextBox, "Phone number must be integers only.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(phoneTextBox, "");
                e.Cancel = false;

            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            
            if (ValidateChildren())
            {
                try
                {
                    Profile profile = new Profile();
                    Address address = new Address();

                    address.AddressLine1 = streetTextBox.Text;
                    address.AddressLine2 = addrLineTwoTextBox.Text;
                    address.City = cityTextBox.Text;
                    address.StateAbbr = stateTextBox.Text;
                    address.PostalCode = zipCodeTextBox.Text;
                    
                    AddressDB.Add(address);


                    profile.FirstName = firstNameTextBox.Text;
                    profile.LastName = lastNameTextBox.Text;
                    profile.UserName = userNameTextBox.Text;
                    profile.Password = passwordTextBox.Text;
                    profile.Email = emailTextBox.Text;
                    profile.Phone = phoneTextBox.Text;
                    profile.StatusId = 1;
                    profile.AddressId = address.AddressId; 
                    ProfileDB.Add(profile);
                    
                    //profile.AddressId = profile.ProfileId;
                    //address.AddressId = profile.AddressId;
                    //address.AddressId = profile.ProfileId;
                    //MessageBox.Show(profile.ProfileId.ToString());
                    //MessageBox.Show(profile.AddressId.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                HomePage homeForm = new HomePage();
                homeForm.Show();
                this.Close();
                /*
                createCreditCard createCardForm = new createCreditCard();
                createCardForm.Show();
                this.Hide();
                */
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
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
    }
}
