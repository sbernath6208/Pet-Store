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
    public partial class petConfirmation : Form
    {
        public static petConfirmation instance; 

        public petConfirmation()
        {
            InitializeComponent();
            instance = this;
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            HomePage homePageForm = new HomePage();
            homePageForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addPet addPetForm = new addPet();
            addPetForm.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //addPet.instance = null; 
                       

            PetShop petShopForm = new PetShop();
            petShopForm.Show();
            this.Hide(); 
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

        private void companyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void petConfirmation_Load(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            /*
            decimal taxRate = 0.00M;
            Profile userProfile = ProfileDB.GetByUserName(MainForm.instance.userTextBoxRef.Text);
            Address userAddress = AddressDB.GetById(userProfile.AddressId);
            */
            Profile userProfile = new Profile();
            Address userAddress = new Address();
            userAddress.StateAbbr = "";

            decimal taxRate = 0.00M;
            if (MainForm.instance.userTextBoxRef != null)
                userProfile = ProfileDB.GetByUserName(MainForm.instance.userTextBoxRef.Text);
            if (userProfile != null)
                userAddress = AddressDB.GetById(userProfile.AddressId);

            if (userAddress != null)
            {
                if ((userAddress.StateAbbr == "AL") || (userAddress.StateAbbr == "Al") || (userAddress.StateAbbr == "al"))
                    taxRate = 0.04M;
                if ((userAddress.StateAbbr == "AK") || (userAddress.StateAbbr == "Ak") || (userAddress.StateAbbr == "ak"))
                    taxRate = 0.00M;
                if ((userAddress.StateAbbr == "AZ") || (userAddress.StateAbbr == "Az") || (userAddress.StateAbbr == "az"))
                    taxRate = 0.056M;
                if ((userAddress.StateAbbr == "AR") || (userAddress.StateAbbr == "Ar") || (userAddress.StateAbbr == "ar"))
                    taxRate = 0.065M;
                if ((userAddress.StateAbbr == "CA") || (userAddress.StateAbbr == "Ca") || (userAddress.StateAbbr == "ca"))
                    taxRate = 0.0725M;
                if ((userAddress.StateAbbr == "CO") || (userAddress.StateAbbr == "Co") || (userAddress.StateAbbr == "co"))
                    taxRate = 0.029M;
                if ((userAddress.StateAbbr == "CT") || (userAddress.StateAbbr == "Ct") || (userAddress.StateAbbr == "ct"))
                    taxRate = 0.0635M;
                if ((userAddress.StateAbbr == "DE") || (userAddress.StateAbbr == "De") || (userAddress.StateAbbr == "de"))
                    taxRate = 0.00M;
                if ((userAddress.StateAbbr == "DC") || (userAddress.StateAbbr == "Dc") || (userAddress.StateAbbr == "dc"))
                    taxRate = 0.06M;
                if ((userAddress.StateAbbr == "FL") || (userAddress.StateAbbr == "Fl") || (userAddress.StateAbbr == "fl"))
                    taxRate = 0.06M;
                if ((userAddress.StateAbbr == "GA") || (userAddress.StateAbbr == "Ga") || (userAddress.StateAbbr == "ga"))
                    taxRate = 0.04M;
                if ((userAddress.StateAbbr == "HI") || (userAddress.StateAbbr == "Hi") || (userAddress.StateAbbr == "hi"))
                    taxRate = 0.04M;
                if ((userAddress.StateAbbr == "ID") || (userAddress.StateAbbr == "Id") || (userAddress.StateAbbr == "id"))
                    taxRate = 0.06M;
                if ((userAddress.StateAbbr == "IL") || (userAddress.StateAbbr == "Il") || (userAddress.StateAbbr == "il"))
                    taxRate = 0.0625M;
                if ((userAddress.StateAbbr == "KS") || (userAddress.StateAbbr == "Ks") || (userAddress.StateAbbr == "ks"))
                    taxRate = 0.065M;
                if ((userAddress.StateAbbr == "KY") || (userAddress.StateAbbr == "Ky") || (userAddress.StateAbbr == "ky"))
                    taxRate = 0.06M;
                if ((userAddress.StateAbbr == "LA") || (userAddress.StateAbbr == "La") || (userAddress.StateAbbr == "la"))
                    taxRate = 0.0445M;
                if ((userAddress.StateAbbr == "ME") || (userAddress.StateAbbr == "Me") || (userAddress.StateAbbr == "me"))
                    taxRate = 0.055M;
                if ((userAddress.StateAbbr == "MD") || (userAddress.StateAbbr == "Md") || (userAddress.StateAbbr == "md"))
                    taxRate = 0.06M;
                if ((userAddress.StateAbbr == "MA") || (userAddress.StateAbbr == "Ma") || (userAddress.StateAbbr == "ma"))
                    taxRate = 0.0625M;
                if ((userAddress.StateAbbr == "MI") || (userAddress.StateAbbr == "Mi") || (userAddress.StateAbbr == "mi"))
                    taxRate = 0.06M;
                if ((userAddress.StateAbbr == "MN") || (userAddress.StateAbbr == "Mn") || (userAddress.StateAbbr == "mn"))
                    taxRate = 0.06875M;
                if ((userAddress.StateAbbr == "MS") || (userAddress.StateAbbr == "Ms") || (userAddress.StateAbbr == "ms"))
                    taxRate = 0.07M;
                if ((userAddress.StateAbbr == "MO") || (userAddress.StateAbbr == "Mo") || (userAddress.StateAbbr == "mo"))
                    taxRate = 0.04225M;
                if ((userAddress.StateAbbr == "MT") || (userAddress.StateAbbr == "Mt") || (userAddress.StateAbbr == "mt"))
                    taxRate = 0.00M;
                if ((userAddress.StateAbbr == "NE") || (userAddress.StateAbbr == "Ne") || (userAddress.StateAbbr == "ne"))
                    taxRate = 0.055M;
                if ((userAddress.StateAbbr == "NV") || (userAddress.StateAbbr == "Nv") || (userAddress.StateAbbr == "nv"))
                    taxRate = 0.0685M;
                if ((userAddress.StateAbbr == "NE") || (userAddress.StateAbbr == "Ne") || (userAddress.StateAbbr == "ne"))
                    taxRate = 0.055M;
                if ((userAddress.StateAbbr == "NH") || (userAddress.StateAbbr == "Nh") || (userAddress.StateAbbr == "nh"))
                    taxRate = 0.00M;
                if ((userAddress.StateAbbr == "NE") || (userAddress.StateAbbr == "Ne") || (userAddress.StateAbbr == "ne"))
                    taxRate = 0.055M;
                if ((userAddress.StateAbbr == "NJ") || (userAddress.StateAbbr == "Nj") || (userAddress.StateAbbr == "nj"))
                    taxRate = 0.06625M;
                if ((userAddress.StateAbbr == "NM") || (userAddress.StateAbbr == "Nm") || (userAddress.StateAbbr == "nm"))
                    taxRate = 0.05125M;
                if ((userAddress.StateAbbr == "NE") || (userAddress.StateAbbr == "Ne") || (userAddress.StateAbbr == "ne"))
                    taxRate = 0.055M;
                if ((userAddress.StateAbbr == "NY") || (userAddress.StateAbbr == "Ny") || (userAddress.StateAbbr == "ny"))
                    taxRate = 0.04M;
                if ((userAddress.StateAbbr == "NC") || (userAddress.StateAbbr == "Nc") || (userAddress.StateAbbr == "nc"))
                    taxRate = 0.0475M;
                if ((userAddress.StateAbbr == "ND") || (userAddress.StateAbbr == "Nd") || (userAddress.StateAbbr == "nd"))
                    taxRate = 0.05M;
                if ((userAddress.StateAbbr == "OH") || (userAddress.StateAbbr == "Oh") || (userAddress.StateAbbr == "oh"))
                    taxRate = 0.0575M;
                if ((userAddress.StateAbbr == "OK") || (userAddress.StateAbbr == "Ok") || (userAddress.StateAbbr == "ok"))
                    taxRate = 0.045M;
                if ((userAddress.StateAbbr == "NE") || (userAddress.StateAbbr == "Ne") || (userAddress.StateAbbr == "ne"))
                    taxRate = 0.055M;
                if ((userAddress.StateAbbr == "OR") || (userAddress.StateAbbr == "Or") || (userAddress.StateAbbr == "or"))
                    taxRate = 0.00M;
                if (userAddress.StateAbbr.ToUpper() == "PA")
                    taxRate = 0.06M;
                if (userAddress.StateAbbr.ToUpper() == "RI")
                    taxRate = 0.07M;
                if (userAddress.StateAbbr.ToUpper() == "SC")
                    taxRate = 0.06M;
                if (userAddress.StateAbbr.ToUpper() == "SD")
                    taxRate = 0.045M;
                if (userAddress.StateAbbr.ToUpper() == "TN")
                    taxRate = 0.07M;
                if (userAddress.StateAbbr.ToUpper() == "TX")
                    taxRate = 0.0625M;
                if (userAddress.StateAbbr.ToUpper() == "UT")
                    taxRate = 0.0485M;
                if (userAddress.StateAbbr.ToUpper() == "TX")
                    taxRate = 0.0625M;
                if (userAddress.StateAbbr.ToUpper() == "VT")
                    taxRate = 0.06M;
                if (userAddress.StateAbbr.ToUpper() == "VA")
                    taxRate = 0.043M;
                if (userAddress.StateAbbr.ToUpper() == "WA")
                    taxRate = 0.065M;
                if (userAddress.StateAbbr.ToUpper() == "WV")
                    taxRate = 0.06M;
                if (userAddress.StateAbbr.ToUpper() == "WI")
                    taxRate = 0.05M;
                if (userAddress.StateAbbr.ToUpper() == "WY")
                    taxRate = 0.04M;
                if (userAddress.StateAbbr.ToUpper() == "")
                    taxRate = 0.06M;
            }
            else
            {
                taxRate = 0.06M;
            }

            decimal totalCost;
            decimal totalTax;
            decimal subTotal;
            

                if (getPet.instance != null)
                {
                    addPet.instance = null;
                    
                    petTypeTextBox.Text = getPet.instance.petTypeTextBoxRef.Text;
                    petNameTextBox.Text = getPet.instance.petNameTextBoxRef.Text;
                    totalTax = Convert.ToDecimal(getPet.instance.costTextBoxRef.Text) * taxRate;
                    totalCost = totalTax + Convert.ToDecimal(getPet.instance.costTextBoxRef.Text);
                    costTextBox.Text = totalCost.ToString("0.00");
                    dateTextBox.Text = getPet.instance.dateTextBoxRef;
                    timeTextBox.Text = getPet.instance.timeTextBoxRef.Text;
                }
            

            if (addPet.instance != null)
            {
                petTypeTextBox.Text = addPet.instance.petTypeTextBoxRef.Text;
                petNameTextBox.Text = addPet.instance.petNameTextBoxRef.Text;
                //breedTextBox.Text = addPet.instance.breedTextBoxRef.Text;
                //ageTextBox.Text = addPet.instance.ageTextBoxRef.Text;
                dateTextBox.Text = addPet.instance.dateTextBoxRef;
                timeTextBox.Text = addPet.instance.timeTextBoxRef.Text;
                subTotal = Convert.ToDecimal(addPet.instance.askingPriceTextBoxRef.Text);
                totalTax = subTotal * taxRate;
                totalCost = subTotal + totalTax; 
                costTextBox.Text = totalCost.ToString(); 
             }
        }
    }
}
