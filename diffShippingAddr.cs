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
    public partial class diffShippingAddr : Form
    {
        public diffShippingAddr()
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

        private void goBackButton_Click(object sender, EventArgs e)
        {
            reviewCartDetails reviewForm = reviewCartDetails.instance;
            reviewForm.Show();
            this.Hide(); 
        }

        private void fullNameTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (fullNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(fullNameTextBox, "Full name is required.");
                e.Cancel = true;
            }
            else if (!(Regex.IsMatch(fullNameTextBox.Text, @"^[a-zA-Z\s]+$")))
            {
                errorProvider.SetError(fullNameTextBox, "Full name must use alphabet characters and spaces only.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(fullNameTextBox, "");
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
            else if (!(Regex.IsMatch(cityTextBox.Text, @"^[a-zA-Z]+$")))
            {
                errorProvider.SetError(cityTextBox, "City must use alphabet characters only.");
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {


                int profileId = Convert.ToInt32(MainForm.instance.profileIdRef);
                Profile profile = ProfileDB.GetById(profileId);

                Address address = AddressDB.GetById(profile.AddressId);
                address.AddressLine1 = streetTextBox.Text;
                //address.AddressLine2 = addressLineTwoTextBox.Text;
                address.City = cityTextBox.Text;
                address.StateAbbr = stateTextBox.Text;
                address.PostalCode = zipCodeTextBox.Text;
                AddressDB.Update(address);

                String fullNameStr = fullNameTextBox.Text;
                String[] nameArr = fullNameStr.Split(" ");
                String firstName = nameArr[0];
                String lastName = nameArr[1];

                //profile.UserName = userNameTextBox.Text;
                //profile.Password = retypePwdTextBox.Text;
                profile.FirstName = firstName;
                profile.LastName = lastName;
                //profile.Email = emailTextBox.Text;
                //profile.Phone = phoneTextBox.Text;
                ProfileDB.Update(profile);

                reviewCartDetails reviewForm = new reviewCartDetails();
                reviewForm.Show();
                this.Hide();
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }

        private void diffShippingAddr_Load(object sender, EventArgs e)
        {
           

            if (MainForm.instance.userTextBoxRef != null)
            {
                String name = MainForm.instance.userTextBoxRef.Text;
                Profile profile = ProfileDB.GetByUserName(name);
                int addressId = profile.AddressId;
                Address address = AddressDB.GetById(addressId);

                fullNameTextBox.Text = profile.FirstName.ToString() + " " + profile.LastName.ToString();       // profile.UserName.ToString();
                //passwordTextBox.Text = profile.Password.ToString();
                //retypePwdTextBox.Text = profile.Password.ToString();
                //firstNameTextBox.Text = profile.FirstName.ToString();
                //lastNameTextBox.Text = profile.LastName.ToString();
                streetTextBox.Text = address.AddressLine1.ToString();
                //addressLineTwoTextBox.Text = address.AddressLine2.ToString();
                cityTextBox.Text = address.City.ToString();
                stateTextBox.Text = address.StateAbbr.ToString();
                zipCodeTextBox.Text = address.PostalCode.ToString();
                //emailTextBox.Text = profile.Email.ToString();
                //phoneTextBox.Text = profile.Phone.ToString();
            }
        }
    }
}
