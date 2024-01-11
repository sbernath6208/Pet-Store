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
    public partial class updateCreditCard : Form
    {
        public static updateCreditCard instance;

        public TextBox CCNumberRef; 
        // updateCreditCard.instance.CCNumberRef; 

        public updateCreditCard()
        {
            InitializeComponent();
            instance = this; 
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
            /*
            if (ccNoTextBox.Text.Length == 0)
            {
                errorProvider.SetError(ccNoTextBox, "Credit card number is required.");
                e.Cancel = true;
            }
            */
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

        /// <summary>
        /// There is a glitch here where if you tab to this box and enter text, the cursor focus
        /// will never leave the text box.  You would have to press I believe the menu button, go back 
        /// button, or shopping cart button 
        /// to exit this form.  Enter text in every box before this one by manually clicking with the
        /// cursor and do likewise with this text button and the 'submit button' will function 
        /// correctly.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                CCNumberRef = ccNoTextBox;

                reviewCartDetails reviewForm = new reviewCartDetails();
                reviewForm.Show();
                this.Hide(); 
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            reviewCartDetails reviewForm = reviewCartDetails.instance;
            reviewForm.Show();
            this.Hide();
            /*
            updateUserInfo updateUserForm = new updateUserInfo();
            updateUserForm.Show();
            this.Hide(); 
            */
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            /*
            ShoppingCart cartForm = new ShoppingCart();
            cartForm.Show();
            this.Hide();
            */
        }

        private void shoppingCartButtonTwo_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                CCNumberRef = ccNoTextBox; 

                reviewCartDetails reviewForm = new reviewCartDetails();
                reviewForm.Show();
                this.Hide();
            }

        }

        private void updateCreditCard_Load(object sender, EventArgs e)
        {
            shoppingCartButtonTwo.Hide(); 

            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;
        }

        private void CompanyDisplay(object sender, EventArgs e)
        {
            String ccNo = ccNoTextBox.Text;
            if (ccNo.Substring(0, 1) == "4")
                companyTextBox.Text = "Visa";
            if (ccNo.Substring(0, 1) == "5")
                companyTextBox.Text = "Master Card";
            if (ccNo.Substring(0, 1) == "6")
                companyTextBox.Text = "Discover";
            if (ccNo.Substring(0, 2) == "37")
                companyTextBox.Text = "American Express";

        }
    }
}
