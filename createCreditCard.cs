/*
 * Credit Card Type	Credit Card Number	Valid
American Express	378282246310005	    Yes
American Express	371449635398431	    Yes
American Express	378734493671000	    Yes
American Express	378282246310033	    No
Discover	        6011111111111117	Yes
Discover	        6011000990139424	Yes
Discover	        6011934315435339	No
Discover	        6011934315435341	Yes
Mastercard	        5435048476899367	Yes
Mastercard	        5435048476899364	No
Mastercard	        5555555555554444	Yes
Mastercard	        5105105105105100	Yes
Visa	            4388576018402626	No
Visa	            4246345689049834	No
Visa	            4388576018410707	Yes
Visa	            4716776386962205	Yes
Visa	            4111111111111111	Yes
*/ 


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
    public partial class createCreditCard : Form
    {
        public createCreditCard()
        {
            InitializeComponent();
        }

        private void goBackButton_Click(object sender, EventArgs e)
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

        private void fullNameTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (fullNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(fullNameTextBox, "Full name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(fullNameTextBox, "");
                e.Cancel = false;

            }
        }

        private void companyTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (companyTextBox.Text.Length == 0)
            {
                errorProvider.SetError(companyTextBox, "Company is required.");
                e.Cancel = true;
            }
            if ((companyTextBox.Text != "Master Card") && (companyTextBox.Text != "Visa") && (companyTextBox.Text != "Discover") && (companyTextBox.Text != "American Express"))
            {
                errorProvider.SetError(companyTextBox, "Please type either Master Card, Visa, Discover, or American Express.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(companyTextBox, "");
                e.Cancel = false;

            }
        }

        /// <summary>
        /// Luhn's alg code courtesy vt_m from https://www.geeksforgeeks.org/luhn-algorithm/
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        // Returns true if given
        // card number is valid
        static bool checkLuhn(String cardNo)
        {
            if (cardNo.Length != 0)
            {
                int nDigits = cardNo.Length;

                int nSum = 0;
                bool isSecond = false;
                for (int i = nDigits - 1; i >= 0; i--)
                {

                    int d = cardNo[i] - '0';

                    if (isSecond == true)
                        d = d * 2;

                    // We add two digits to handle
                    // cases that make two digits
                    // after doubling
                    nSum += d / 10;
                    nSum += d % 10;

                    isSecond = !isSecond;
                }
                return (nSum % 10 == 0);
            }
            else
                return false; 
        }

        private void ccNoTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (ccNoTextBox.Text.Length == 0)
            {
                errorProvider.SetError(ccNoTextBox, "Credit card number is required.");
                e.Cancel = true;
            }
            if (!checkLuhn(ccNoTextBox.Text))
            {
                errorProvider.SetError(ccNoTextBox, "Credit card number is incorrect.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(ccNoTextBox, "");
                e.Cancel = false;

            }
        }

        private void securityNoTextBox_Validating(object sender, CancelEventArgs e)
        {

            
            int intValue;
            bool validInt = int.TryParse(securityNoTextBox.Text, out intValue);
            if (securityNoTextBox.Text.Length == 0)
            {
                errorProvider.SetError(securityNoTextBox, "Security number is required.");
                e.Cancel = true;
            }
            if (!validInt)
            {
                errorProvider.SetError(securityNoTextBox, "Security is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(securityNoTextBox, "");
                e.Cancel = false;

            }
        }

        private void cardExpirationTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (cardExpirationTextBox.Text.Length == 0)
            {
                errorProvider.SetError(cardExpirationTextBox, "Card expiration is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cardExpirationTextBox, "");
                e.Cancel = false;

            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Hide();
            }
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

        private void createCreditCard_Load(object sender, EventArgs e)
        {
            
            int userId = MainForm.instance.profileIdRef;
            
            Order order = OrderDB.GetById(userId);
            Profile profile = ProfileDB.GetById(userId);

            //MessageBox.Show(userId.ToString());
            //MessageBox.Show(profile.FirstName.ToString()); 

            if (MainForm.instance.userTextBoxRef != null)
            {
                if (MainForm.instance.userTextBoxRef.Text != "")
                {
                    userNameLabel.Text = MainForm.instance.userTextBoxRef.ToString();
                    fullNameTextBox.Text = profile.FirstName.ToString() + " " + profile.LastName.ToString();
                    ccNoTextBox.Text = order.CreditCardNo.ToString();
                }
            }


        }
    }
}
