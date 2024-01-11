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
    public partial class getPet : Form
    {
        public static getPet instance;

        public TextBox petTypeTextBoxRef;
        public TextBox petNameTextBoxRef;
        public TextBox costTextBoxRef;
        public String dateTextBoxRef;
        public TextBox timeTextBoxRef; 

        public getPet()
        {
            InitializeComponent();
            instance = this; 
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            PetShop petForm = new PetShop();
            petForm.Show();
            this.Hide();
        }

        private void petTypeTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (petTypeTextBox.Text.Length == 0)
            {
                errorProvider.SetError(petTypeTextBox, "Pet type is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(petTypeTextBox, "");
                e.Cancel = false;

            }
        }

        private void petNameTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (petNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(petNameTextBox, "Pet name is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(petNameTextBox, "");
                e.Cancel = false;

            }
        }

        private void dateTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (petNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(dateTextBox, "Date is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dateTextBox, "");
                e.Cancel = false;

            }
        }

        private void timeTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (petNameTextBox.Text.Length == 0)
            {
                errorProvider.SetError(timeTextBox, "Time is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(timeTextBox, "");
                e.Cancel = false;

            }
        }

        

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (MainForm.instance.userTextBoxRef != null)
                {
                    Pet pet = PetDB.GetByName(petTypeTextBox.Text);
                    Order petOrder = new Order();
                    OrderLine petOrderLine = new OrderLine();
                    String userName = MainForm.instance.userTextBoxRef.Text;
                    Profile profile = ProfileDB.GetByUserName(userName);
                    Address address = AddressDB.GetById(profile.AddressId);

                    //if (petConfirmation.instance == null)
                    //{
                    petOrder.UserName = userName;
                    petOrder.BillAddressId = profile.AddressId;
                    petOrder.BillingFirstName = profile.FirstName;
                    petOrder.BillingLastName = profile.LastName;
                    petOrder.TotalCost = Convert.ToDecimal(costTextBox.Text);
                    petOrder.CreditCardNo = "0000000000000000"; // This is a junk card that auto validates, the user pays at the store
                                                               // eventually get from credit card class if I have time to make it
                    petOrder.ShipperId = 1;
                    petOrder.BillAddressId = profile.AddressId;
                    petOrder.ShipToFirstName = profile.FirstName;
                    petOrder.ShipToLastName = profile.LastName;
                    petOrder.ShipToAddressId = profile.AddressId;
                    petOrder.StatusId = 5;
                    OrderDB.Add(petOrder);


                    petOrderLine.OrderNo = petOrder.OrderNo;
                    //}
                    //petOrderLine.LineNo = 
                    petOrderLine.PetId = pet.PetId;
                    petOrderLine.Qty = 1;
                    petOrderLine.StatusId = 5;
                    //spetOrderLine.ExtendedPrice = Convert.ToDecimal(costTextBox.Text);
                    petOrderLine.Price = Convert.ToDecimal(costTextBox.Text);
                    petOrderLine.ShipDate = Convert.ToDateTime(dateTextBox.Text);
                    OrderLineDB.Add(petOrderLine);

                    petTypeTextBoxRef = petTypeTextBox;
                    petNameTextBoxRef = petNameTextBox;
                    costTextBoxRef = costTextBox;
                    dateTextBoxRef = dateTextBox.Text;
                    timeTextBoxRef = timeTextBox;

                    addPet.instance = null;

                    //String name = petTypeTextBox.Text; 
                    Pet petConfirmed = PetDB.GetByName(petTypeTextBox.Text);
                    petConfirmed.StatusId = 2;
                    PetDB.Update(petConfirmed);

                    petConfirmation confirmationPetForm = new petConfirmation();
                    confirmationPetForm.Show();
                    this.Hide();
                }
                else 
                {
                    MessageBox.Show("Must be logged in"); 
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
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

        private void getPet_Load(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            if (PetShop.instance != null)
            {
                petTypeTextBox.Text = PetShop.instance.petTypeLabelRef.Text;
                petNameTextBox.Text = PetShop.instance.petNameTextBoxRef.Text;
                costTextBox.Text = PetShop.instance.costLabelRef.Text;
            }
        }
    }
}
