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
using System.IO;
using Final_Pet_Store_Bernath.DataAccessLayer.DBObjects;
using Final_Pet_Store_Bernath.DataAccessLayer.BussinessObjects;
using System.Text.RegularExpressions;

namespace Final_Pet_Store_Bernath
{
    public partial class ShoppingCart : Form
    {
        public static ShoppingCart instance;

        public Label productNameLabelOneRef;
        public TextBox qtyTextBoxOneRef;
        public TextBox costTextBoxOneRef;

        public Label productNameLabelTwoRef;
        public TextBox qtyTextBoxTwoRef;
        public TextBox costTextBoxTwoRef;

        public Label productNameLabelThreeRef;
        public TextBox qtyTextBoxThreeRef;
        public TextBox costTextBoxThreeRef;

        public ListBox shoppingCartListBoxRef;

        public string subTotalTextBox1Ref;
        public string subTotalTextBox2Ref;
        public string subTotalTextBox3Ref;
        public string subTotalTextBox4Ref;
        public string subTotalTextBox5Ref;
        public string subTotalTextBox6Ref;

        public TextBox qtyTextBox1Ref;
        public TextBox qtyTextBox2Ref;
        public TextBox qtyTextBox3Ref;
        public TextBox qtyTextBox4Ref;
        public TextBox qtyTextBox5Ref;
        public TextBox qtyTextBox6Ref;

        public Label taxTotalRef;
        public Label estShippingRef;
        public Label estTotalRef;

        public String[] listBoxArrRef;


        /*
        public decimal totalProductOneRef;
        public decimal totalProductTwoRef;
        public decimal totalProductThreeRef; 
        */
        /*
        private decimal TotalProductOne()
        {
            costTextBoxOne.Text = "9.99";
            costTextBoxTwo.Text = "19.99";
            costTextBoxThree.Text = "59.99";
            if (int.TryParse(qtyTextBoxOne.Text, out int qtyOne))
            {
                decimal totalProductOne = (Convert.ToDecimal(costTextBoxOne.Text) * Convert.ToInt32(qtyTextBoxOne.Text));
                return totalProductOne;
            }
            else
                return 0; 
        }

        private decimal TotalProductTwo()
        {
            costTextBoxOne.Text = "9.99";
            costTextBoxTwo.Text = "19.99";
            costTextBoxThree.Text = "59.99";
            if (int.TryParse(qtyTextBoxTwo.Text, out int qtyTwo))
            {
                decimal totalProductTwo = (Convert.ToDecimal(costTextBoxTwo.Text) * Convert.ToInt32(qtyTextBoxTwo.Text));
                return totalProductTwo;
            }
            else
                return 0;
        }

        private decimal TotalProductThree()
        {
            costTextBoxOne.Text = "9.99";
            costTextBoxTwo.Text = "19.99";
            costTextBoxThree.Text = "59.99";
            if (int.TryParse(qtyTextBoxThree.Text, out int qtyThree))
            {
                decimal totalProductThree = (Convert.ToDecimal(costTextBoxThree.Text) * Convert.ToInt32(qtyTextBoxThree.Text));
                return totalProductThree;
            }
            else
                return 0;
        }
        */

        public ShoppingCart()
        {
            InitializeComponent();
            instance = this;
            /*
            productNameLabelOneRef = productNameLabelOne;
            qtyTextBoxOneRef = qtyTextBoxOne;
            costTextBoxOneRef = costTextBoxOne;

            productNameLabelTwoRef = productNameLabelTwo;
            qtyTextBoxTwoRef = qtyTextBoxTwo;
            costTextBoxTwoRef = costTextBoxTwo;

            productNameLabelThreeRef = productNameLabelThree;
            qtyTextBoxThreeRef = qtyTextBoxThree;
            costTextBoxThreeRef = costTextBoxThree;
            */
            /*
            totalProductOneRef = TotalProductOne();
            totalProductTwoRef = TotalProductTwo();
            totalProductThreeRef = TotalProductThree();
            */
        }
        // private void newCalc(object sender, CancelArgs e)
        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }
        
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            browseAllProducts productsForm = new browseAllProducts();
            productsForm.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                shoppingCartListBoxRef = shoppingCartListBox;

                reviewCartDetails reviewCartForm = new reviewCartDetails();
                reviewCartForm.Show();
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

        private void cartDescriptionLabelOne_Click(object sender, EventArgs e)
        {
            
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {

            displaySelectedItemButton.Hide();
            recalcButton.Hide();
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabelNew.Text = MainForm.instance.userTextBoxRef.Text;

            if (browseAllProducts.instance != null)
            {
                if (browseAllProducts.instance.browseListBoxRef != null)
                {
                    if (browseAllProducts.instance.browseListBoxRef.Items.Count > 0)
                    {
                        foreach (object row in browseAllProducts.instance.browseListBoxRef.Items)
                            //if (browseAllProducts.instance.browseListBoxRef.Items(row) != "")
                            shoppingCartListBox.Items.Add(row);
                    }
                    //else
                    //  shoppingCartListBox.Items.Add(""); 
                    /*
                    if (browseAllProducts.instance.productLabelRefOne.Text != "")
                        productNameLabelOne.Text = browseAllProducts.instance.productLabelRefOne.Text;
                    if (browseAllProducts.instance.productLabelRefTwo.Text != "")
                        productNameLabelTwo.Text = browseAllProducts.instance.productLabelRefTwo.Text;
                    if (browseAllProducts.instance.productLabelRefThree.Text != "")
                        productNameLabelThree.Text = browseAllProducts.instance.productLabelRefThree.Text;
                    */
                }

            }

            if (SalesForm.instance != null)
            {
                if (SalesForm.instance.salesListBoxRef != null)
                {
                    if (SalesForm.instance.salesListBoxRef.Items.Count > 0)
                    {
                        foreach (object row in SalesForm.instance.salesListBoxRef.Items)
                            shoppingCartListBox.Items.Add(row);
                    }
                    // else
                    //   shoppingCartListBox.Items.Add("");
                    /*
                    if (SalesForm.instance.productLabelRefOne.Text != "")
                        productNameLabelOne.Text = SalesForm.instance.productLabelRefOne.Text;
                    if (SalesForm.instance.productLabelRefTwo.Text != "")
                        productNameLabelTwo.Text = SalesForm.instance.productLabelRefTwo.Text;
                    if (SalesForm.instance.productLabelRefThree.Text != "")
                        productNameLabelThree.Text = SalesForm.instance.productLabelRefThree.Text;
                    */
                }
            }


            if (shoppingCartListBox.Items.Count == 1)
                qtyTextBox1.Text = "1";
            else if (shoppingCartListBox.Items.Count == 2)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
            }
            else if (shoppingCartListBox.Items.Count == 3)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
            }
            else if (shoppingCartListBox.Items.Count == 4)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "1";
            }
            else if (shoppingCartListBox.Items.Count == 5)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "1";
                qtyTextBox5.Text = "1";
            }
            else if (shoppingCartListBox.Items.Count == 6)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "1";
                qtyTextBox5.Text = "1";
                qtyTextBox6.Text = "1";
            }

            cartPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;

            /*
            List<Sales> salesProducts = new List<Sales>();
            salesProducts = SalesProductsDB.GetAll();
            foreach (Sales saleProduct in salesProducts)
            {
                if (saleProduct.SalesName == productArr[0])
                    subTotalTextBox1.Text = saleProduct.Price.ToString("0.00");
            }

            List<BrowseProducts> browseProducts = new List<BrowseProducts>();
            browseProducts = BrowseProductsDB.GetAll();
            foreach (BrowseProducts browseProduct in browseProducts)
            {
                if (browseProduct.Name == productArr[0])
                    subTotalTextBox1.Text = browseProduct.Price.ToString("0.00");
            }
            */

            decimal totalProduct1 = 0.00M;
            decimal totalProduct2 = 0.00M;
            decimal totalProduct3 = 0.00M;
            decimal totalProduct4 = 0.00M;
            decimal totalProduct5 = 0.00M;
            decimal totalProduct6 = 0.00M;

            /*
            object rowOne;
            object rowTwo;
            object rowThree;
            object rowFour;
            object rowFive;
            object rowSix;
            */

            String item1 = "";
            String item2 = "";
            String item3 = "";
            String item4 = "";
            String item5 = "";
            String item6 = "";

            if (shoppingCartListBox.Items.Count >= 1)
            {
                item1 = shoppingCartListBox.Items[0].ToString();

                Sales salesProduct = SalesProductsDB.GetByName(item1);

                if (salesProduct != null)
                    if (salesProduct.SalesName == item1) 
                subTotalTextBox1.Text = salesProduct.Price.ToString("0.00");

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(item1);

                if (browseProductForTotal != null)
                    if (browseProductForTotal.Name == item1)
                        subTotalTextBox1.Text = browseProductForTotal.Price.ToString("0.00");
            }


            /*
            rowOne = shoppingCartListBox.Items[0];

            String productStr = rowOne.ToString();
            String[] productArr = productStr.Split(" ");

            Sales salesProduct = SalesProductsDB.GetByName(productArr[0]);

            if (salesProduct != null)
            {
                if (salesProduct.SalesName == productArr[0])
                    subTotalTextBox1.Text = salesProduct.Price.ToString("0.00");
            }

            BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(productArr[0]);
            if (browseProductForTotal != null)
            {

                if (browseProductForTotal.Name == productArr[0])
                    subTotalTextBox1.Text = browseProductForTotal.Price.ToString("0.00");
            }
            */

            if (shoppingCartListBox.Items.Count >= 2)
            {
                item2 = shoppingCartListBox.Items[1].ToString();
                //MessageBox.Show(item2); 

                Sales salesProduct = SalesProductsDB.GetByName(item2);

                if (salesProduct != null)
                    if (salesProduct.SalesName == item2)
                    {
                        subTotalTextBox2.Text = salesProduct.Price.ToString("0.00");
                        //MessageBox.Show(salesProduct.SalesName + ", " + salesProduct.Price);
                    }

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(item2);
                //MessageBox.Show(browseProductForTotal.Name + ", " + browseProductForTotal.Price); 
                if (browseProductForTotal != null)
                    if (browseProductForTotal.Name == item2)
                    {
                        subTotalTextBox2.Text = browseProductForTotal.Price.ToString("0.00");
                        //MessageBox.Show(browseProductForTotal.Name + ", " + browseProductForTotal.Price); 
                    }
                
            }

            /*
            if (shoppingCartListBox.Items.Count >= 2)
            {
                rowTwo = shoppingCartListBox.Items[1];

                String productStr = rowTwo.ToString();
                String[] productArr = productStr.Split(" ");


                Sales salesProduct = SalesProductsDB.GetByName(productArr[0]);
                if (salesProduct != null)
                {
                    if (salesProduct.SalesName == productArr[0])
                        subTotalTextBox2.Text = salesProduct.Price.ToString("0.00");
                }

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(productArr[0]);
                if (browseProductForTotal != null)
                {

                    if (browseProductForTotal.Name == productArr[0])
                        subTotalTextBox2.Text = browseProductForTotal.Price.ToString("0.00");
                }


            }
            */
            if (shoppingCartListBox.Items.Count >= 3)
            {
                item3 = shoppingCartListBox.Items[2].ToString();

                Sales salesProduct = SalesProductsDB.GetByName(item3);

                if (salesProduct != null)
                    if (salesProduct.SalesName == item3) 
                subTotalTextBox3.Text = salesProduct.Price.ToString("0.00");

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(item3);

                if (browseProductForTotal != null)
                    if (browseProductForTotal.Name == item3)
                        subTotalTextBox3.Text = browseProductForTotal.Price.ToString("0.00");
            }
            /*
            if (shoppingCartListBox.Items.Count >= 3)
            {
                rowThree = shoppingCartListBox.Items[2];

                String productStr = rowThree.ToString();
                String[] productArr = productStr.Split(" ");

                Sales salesProduct = SalesProductsDB.GetByName(productArr[0]);
                if (salesProduct != null)
                {
                    if (salesProduct.SalesName == productArr[0])
                        subTotalTextBox3.Text = salesProduct.Price.ToString("0.00");
                }

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(productArr[0]);
                if (browseProductForTotal != null)
                {

                    if (browseProductForTotal.Name == productArr[0])
                        subTotalTextBox3.Text = browseProductForTotal.Price.ToString("0.00");
                }

            }
            */

            if (shoppingCartListBox.Items.Count >= 4)
            {
                item4 = shoppingCartListBox.Items[3].ToString();

                Sales salesProduct = SalesProductsDB.GetByName(item4);

                if (salesProduct != null)
                    if (salesProduct.SalesName == item4) 
                subTotalTextBox4.Text = salesProduct.Price.ToString("0.00");

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(item4);

                if (browseProductForTotal != null)
                    if (browseProductForTotal.Name == item4)
                        subTotalTextBox4.Text = browseProductForTotal.Price.ToString("0.00");
            }
            /*
            if (shoppingCartListBox.Items.Count >= 4)
            {
                rowFour = shoppingCartListBox.Items[3];

                String productStr = rowFour.ToString();
                String[] productArr = productStr.Split(" ");


                Sales salesProduct = SalesProductsDB.GetByName(productArr[0]);
                if (salesProduct != null)
                {
                    if (salesProduct.SalesName == productArr[0])
                        subTotalTextBox4.Text = salesProduct.Price.ToString("0.00");
                }

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(productArr[0]);
                if (browseProductForTotal != null)
                {

                    if (browseProductForTotal.Name == productArr[0])
                        subTotalTextBox4.Text = browseProductForTotal.Price.ToString("0.00");
                }

            }
            */
            if (shoppingCartListBox.Items.Count >= 5)
            {
                item5 = shoppingCartListBox.Items[4].ToString();

                Sales salesProduct = SalesProductsDB.GetByName(item5);

                if (salesProduct != null)
                    if (salesProduct.SalesName == item5)
                subTotalTextBox5.Text = salesProduct.Price.ToString("0.00");

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(item5);

                if (browseProductForTotal != null)
                    if (browseProductForTotal.Name == item5)
                        subTotalTextBox5.Text = browseProductForTotal.Price.ToString("0.00");
            }

            /*
            if (shoppingCartListBox.Items.Count >= 5)
            {
                rowFive = shoppingCartListBox.Items[4];

                String productStr = rowFive.ToString();
                String[] productArr = productStr.Split(" ");


                Sales salesProduct = SalesProductsDB.GetByName(productArr[0]);
                if (salesProduct != null)
                {
                    if (salesProduct.SalesName == productArr[0])
                        subTotalTextBox4.Text = salesProduct.Price.ToString("0.00");
                }

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(productArr[0]);
                if (browseProductForTotal != null)
                {

                    if (browseProductForTotal.Name == productArr[0])
                        subTotalTextBox4.Text = browseProductForTotal.Price.ToString("0.00");
                }

            }
            */
            if (shoppingCartListBox.Items.Count >= 6)
            {
                item6 = shoppingCartListBox.Items[5].ToString();

                Sales salesProduct = SalesProductsDB.GetByName(item6);

                if (salesProduct != null)
                    if (salesProduct.SalesName == item6) 
                subTotalTextBox6.Text = salesProduct.Price.ToString("0.00");

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(item6);

                if (browseProductForTotal != null)
                    if (browseProductForTotal.Name == item1)
                        subTotalTextBox6.Text = browseProductForTotal.Price.ToString("0.00");
            }
            /*
            if (shoppingCartListBox.Items.Count >= 6)
            {
                rowSix = shoppingCartListBox.Items[5];

                String productStr = rowSix.ToString();
                String[] productArr = productStr.Split(" ");


                Sales salesProduct = SalesProductsDB.GetByName(productArr[0]);
                if (salesProduct != null)
                {
                    if (salesProduct.SalesName == productArr[0])
                        subTotalTextBox5.Text = salesProduct.Price.ToString("0.00");
                }

                BrowseProducts browseProductForTotal = BrowseProductsDB.GetByName(productArr[0]);
                if (browseProductForTotal != null)
                {

                    if (browseProductForTotal.Name == productArr[0])
                        subTotalTextBox5.Text = browseProductForTotal.Price.ToString("0.00");
                }

            }
            */

            //cartPictureBoxTwo.SizeMode = PictureBoxSizeMode.StretchImage;
            //cartPictureBoxThree.SizeMode = PictureBoxSizeMode.StretchImage;
            /*
            if (productNameLabelOne.Text == "")
                    qtyTextBoxOne.Text = "0";
                if (productNameLabelTwo.Text == "")
                    qtyTextBoxTwo.Text = "0";
                if (productNameLabelThree.Text == "")
                    qtyTextBoxThree.Text = "0";
            */
            /*
            if (browseAllProducts.instance != null)
            {
                if (browseAllProducts.instance.costLabelRefOne.Text != "")
                    costTextBoxOne.Text = browseAllProducts.instance.costLabelRefOne.Text;
                if (browseAllProducts.instance.costLabelRefTwo.Text != "")
                    costTextBoxTwo.Text = browseAllProducts.instance.costLabelRefTwo.Text;
                if (browseAllProducts.instance.costLabelRefThree.Text != "")
                    costTextBoxThree.Text = browseAllProducts.instance.costLabelRefThree.Text;
            }
            */
            /*
            if (SalesForm.instance != null)
            {
                if (SalesForm.instance.costLabelRefOne.Text != "")
                    costTextBoxOne.Text = SalesForm.instance.costLabelRefOne.Text;
                if (SalesForm.instance.costLabelRefTwo.Text != "")
                    costTextBoxTwo.Text = SalesForm.instance.costLabelRefTwo.Text;
                if (SalesForm.instance.costLabelRefThree.Text != "")
                    costTextBoxThree.Text = SalesForm.instance.costLabelRefThree.Text;
            }
            */
            /*
            if (qtyTextBox1.Text == "")
                qtyTextBox1.Text = "0";
            if (qtyTextBox2.Text == "")
                qtyTextBox2.Text = "0";
            if (qtyTextBox3.Text == "")
                qtyTextBox3.Text = "0";
            if (qtyTextBox4.Text == "")
                qtyTextBox4.Text = "0";
            if (qtyTextBox5.Text == "")
                qtyTextBox5.Text = "0";
            if (qtyTextBox6.Text == "")
                qtyTextBox6.Text = "0";
            */






            /*
            if (Decimal.TryParse(subTotalTextBoxOne.Text, out decimal decOne) && int.TryParse(qtyLabel1.Text, out int qtyOne) &&
                Decimal.TryParse(subTotalTextBoxTwo.Text, out decimal decTwo) && int.TryParse(qtyLabel2.Text, out int qtyTwo) &&
                Decimal.TryParse(subTotalTextBoxThree.Text, out decimal decThree) && int.TryParse(qtyLabel3.Text, out int qtyThree) )
            */
            //if ((qtyTextBox1.Text != "") && (qtyTextBox2.Text != "") && (qtyTextBox3.Text != ""))

            Profile userProfile = new Profile(); 
            Address userAddress = new Address();
            userAddress.StateAbbr = ""; 

            decimal taxRate = 0.00M;
            if (MainForm.instance.userTextBoxRef != null)
                userProfile = ProfileDB.GetByUserName(MainForm.instance.userTextBoxRef.Text);
            if (userProfile != null)
                 userAddress = AddressDB.GetById(userProfile.AddressId);

            if ((userAddress != null) && (MainForm.instance.userTextBoxRef != null))
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
                if (userAddress.StateAbbr == "")
                    taxRate = 0.06M;
            }
            else
            {
                taxRate = 0.06M; 
            }


            decimal estShipping = 2.99M;


           

            // if (int.TryParse(qtyTextBox1.Text, out int qtyOne) && int.TryParse(qtyTextBox2.Text, out int qtyTwo) && int.TryParse(qtyTextBox3.Text, out int qtyThree) )
            // {
            if (int.TryParse(qtyTextBox1.Text, out int qty1))
            {
                if (Decimal.TryParse(subTotalTextBox1.Text, out decimal costOne))
                    totalProduct1 = (Convert.ToDecimal(subTotalTextBox1.Text) * Convert.ToInt32(qtyTextBox1.Text));
                else
                    totalProduct1 = 0;
            }
            if (int.TryParse(qtyTextBox2.Text, out int qty2))
            {
                if (Decimal.TryParse(subTotalTextBox2.Text, out decimal costTwo))
                    totalProduct2 = (Convert.ToDecimal(subTotalTextBox2.Text) * Convert.ToInt32(qtyTextBox2.Text));
                else
                    totalProduct2 = 0;
            }
            if (int.TryParse(qtyTextBox3.Text, out int qty3))
            {
                if (Decimal.TryParse(subTotalTextBox3.Text, out decimal costThree))
                    totalProduct3 = (Convert.ToDecimal(subTotalTextBox3.Text) * Convert.ToInt32(qtyTextBox3.Text));
                else
                    totalProduct3 = 0;
            }
            if (int.TryParse(qtyTextBox4.Text, out int qty4))
            {
                if (Decimal.TryParse(subTotalTextBox4.Text, out decimal costFour))
                    totalProduct4 = (Convert.ToDecimal(subTotalTextBox4.Text) * Convert.ToInt32(qtyTextBox4.Text));
                else
                    totalProduct4 = 0;
            }
            if (int.TryParse(qtyTextBox5.Text, out int qty5))
            {
                if (Decimal.TryParse(subTotalTextBox5.Text, out decimal costFive))
                    totalProduct5 = (Convert.ToDecimal(subTotalTextBox5.Text) * Convert.ToInt32(qtyTextBox5.Text));
                else
                    totalProduct5 = 0;
            }
            if (int.TryParse(qtyTextBox6.Text, out int qty6))
            {
                if (Decimal.TryParse(subTotalTextBox6.Text, out decimal costSix))
                    totalProduct6 = (Convert.ToDecimal(subTotalTextBox6.Text) * Convert.ToInt32(qtyTextBox6.Text));
                else
                    totalProduct6 = 0;
            }

            int qtyProd1 = 0;
            int qtyProd2 = 0;
            int qtyProd3 = 0;
            int qtyProd4 = 0;
            int qtyProd5 = 0;
            int qtyProd6 = 0;

            if (qtyTextBox1.Text != "")
                qtyProd1 = Convert.ToInt32(qtyTextBox1.Text);
            if (qtyTextBox2.Text != "")
                qtyProd2 = Convert.ToInt32(qtyTextBox2.Text);
            if (qtyTextBox3.Text != "")
                qtyProd3 = Convert.ToInt32(qtyTextBox3.Text);
            if (qtyTextBox4.Text != "")
                qtyProd4 = Convert.ToInt32(qtyTextBox4.Text);
            if (qtyTextBox5.Text != "")
                qtyProd5 = Convert.ToInt32(qtyTextBox5.Text);
            if (qtyTextBox6.Text != "")
                qtyProd6 = Convert.ToInt32(qtyTextBox6.Text);


            int totalQty = qtyProd1 + qtyProd2 + qtyProd3 + qtyProd4 + qtyProd5 + qtyProd6;

            decimal subTotal = totalProduct1 + totalProduct2 + totalProduct3 + totalProduct4 + totalProduct5 + totalProduct6; 
            decimal estTax = subTotal * taxRate;
            decimal estShippingCalc = estShipping;

            taxLabel.Text = (estTax).ToString("0.00");

            if (subTotal == 0)
                estShippingLabel.Text = "0.00";
            else
                estShippingLabel.Text = (estShippingCalc).ToString("0.00");

            if (subTotal == 0)
                estTotalLabel.Text = "0.00";
            else
                estTotalLabel.Text = (subTotal + estTax + estShippingCalc).ToString("0.00");
            
            
        }


        private void qtyTextBoxOne_Validating(object sender, CancelEventArgs e)
        {
            
            if (!(int.TryParse(qtyTextBoxOne.Text, out int qtyOne)))
            {
                errorProvider.SetError(qtyTextBoxOne, "Qty must have an integer for quantity amount.");
                e.Cancel = true;
            }
            
            else
            {
                errorProvider.SetError(qtyTextBoxOne, "");
                e.Cancel = false;

            }
        }

        private void qtyTextBoxTwo_Validating(object sender, CancelEventArgs e)
        {
            /*
            if (!(int.TryParse(qtyTextBoxTwo.Text, out int qtyOne)))
            {
                errorProvider.SetError(qtyTextBoxTwo, "Qty must have an integer for quantity amount.");
                e.Cancel = true;
            }

            else
            {
                errorProvider.SetError(qtyTextBoxTwo, "");
                e.Cancel = false;

            }
            */
        }

        private void qtyTextBoxThree_Validating(object sender, CancelEventArgs e)
        {
            /*
            if (!(int.TryParse(qtyTextBoxThree.Text, out int qtyOne)))
            {
                errorProvider.SetError(qtyTextBoxThree, "Qty must have an integer for quantity amount.");
                e.Cancel = true;
            }

            else
            {
                errorProvider.SetError(qtyTextBoxThree, "");
                e.Cancel = false;

            }
            */
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            object selectedItem = shoppingCartListBox.SelectedItem;
            shoppingCartListBox.Items.Remove(selectedItem);
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            if (shoppingCartListBox.Items.Count == 0)
            {
                MessageBox.Show("Shopping cart empty, cannot check out");
            }

            else if (ValidateChildren())
            {
                
                
                    qtyTextBox1Ref = qtyTextBox1;
                    qtyTextBox2Ref = qtyTextBox2;
                    qtyTextBox3Ref = qtyTextBox3;
                    qtyTextBox4Ref = qtyTextBox4;
                    qtyTextBox5Ref = qtyTextBox5;
                    qtyTextBox6Ref = qtyTextBox6;

                    decimal totalProduct1 = 0.00M;
                    decimal totalProduct2 = 0.00M;
                    decimal totalProduct3 = 0.00M;
                    decimal totalProduct4 = 0.00M;
                    decimal totalProduct5 = 0.00M;
                    decimal totalProduct6 = 0.00M;


                    if (int.TryParse(qtyTextBox1.Text, out int qty1))
                    {
                        if (Decimal.TryParse(subTotalTextBox1.Text, out decimal costOne))
                            totalProduct1 = (Convert.ToDecimal(subTotalTextBox1.Text) * Convert.ToInt32(qtyTextBox1.Text));
                        else
                            totalProduct1 = 0;
                    }
                    if (int.TryParse(qtyTextBox2.Text, out int qty2))
                    {
                        if (Decimal.TryParse(subTotalTextBox2.Text, out decimal costTwo))
                            totalProduct2 = (Convert.ToDecimal(subTotalTextBox2.Text) * Convert.ToInt32(qtyTextBox2.Text));
                        else
                            totalProduct2 = 0;
                    }
                    if (int.TryParse(qtyTextBox3.Text, out int qty3))
                    {
                        if (Decimal.TryParse(subTotalTextBox3.Text, out decimal costThree))
                            totalProduct3 = (Convert.ToDecimal(subTotalTextBox3.Text) * Convert.ToInt32(qtyTextBox3.Text));
                        else
                            totalProduct3 = 0;
                    }
                    if (int.TryParse(qtyTextBox4.Text, out int qty4))
                    {
                        if (Decimal.TryParse(subTotalTextBox4.Text, out decimal costFour))
                            totalProduct4 = (Convert.ToDecimal(subTotalTextBox4.Text) * Convert.ToInt32(qtyTextBox4.Text));
                        else
                            totalProduct4 = 0;
                    }
                    if (int.TryParse(qtyTextBox5.Text, out int qty5))
                    {
                        if (Decimal.TryParse(subTotalTextBox5.Text, out decimal costFive))
                            totalProduct5 = (Convert.ToDecimal(subTotalTextBox5.Text) * Convert.ToInt32(qtyTextBox5.Text));
                        else
                            totalProduct5 = 0;
                    }
                    if (int.TryParse(qtyTextBox6.Text, out int qty6))
                    {
                        if (Decimal.TryParse(subTotalTextBox6.Text, out decimal costSix))
                            totalProduct6 = (Convert.ToDecimal(subTotalTextBox6.Text) * Convert.ToInt32(qtyTextBox6.Text));
                        else
                            totalProduct6 = 0;
                    }

                    subTotalTextBox1Ref = totalProduct1.ToString();
                    subTotalTextBox2Ref = totalProduct2.ToString();
                    subTotalTextBox3Ref = totalProduct3.ToString();
                    subTotalTextBox4Ref = totalProduct4.ToString();
                    subTotalTextBox5Ref = totalProduct5.ToString();
                    subTotalTextBox6Ref = totalProduct6.ToString();
                    /*
                    int i = 0;
                    String[] listBoxArr = new string[6];
                    foreach (string productLine in shoppingCartListBox.Items)
                    {
                        
                        String[] productArr = productLine.Split(" ");
                        
                        String productName = productArr[0]; 
                        listBoxArr[i] = productName;
                        i++;
                    }
                    */
                    //listBoxArrRef = listBoxArr;
                    shoppingCartListBoxRef = shoppingCartListBox;

                    taxTotalRef = taxLabel;
                    estShippingRef = estShippingLabel;
                    estTotalRef = estTotalLabel;
                    estTotalRef = estTotalLabel;

                    int totalQty = qty1 + qty2 + qty3 + qty4 + qty5 + qty6;
                    if (totalQty == 0)
                    {
                    MessageBox.Show("Total quantity is 0, please select desired quantity"); 
                        }
                    else
                    {
                        reviewCartDetails reviewCartForm = new reviewCartDetails();
                        reviewCartForm.Show();
                        this.Hide();
                    }
                
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            shoppingCartListBoxRef = shoppingCartListBox;
            if (browseAllProducts.instance != null)
            {
                browseAllProducts productsForm = browseAllProducts.instance;
                productsForm.Show();
                this.Hide(); 
            }

            else
            {
                
                browseAllProducts productsForm = new browseAllProducts();
                productsForm.Show();
                this.Hide();
            }
        }

        /*
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            shoppingCartListBoxRef = shoppingCartListBox;
            if (SalesForm.instance != null)
            {
                SalesForm salesForm = SalesForm.instance;
                salesForm.Show();
                this.Hide();
            }
            else
            {  
.               SalesForm salesForm = new SalesForm();
                salesForm.Show();
                this.Hide();
            }
        }
        */ 

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            shoppingCartListBoxRef = shoppingCartListBox;

            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide();
        }

        

        

        
        private void removeButton_Click_1(object sender, EventArgs e) //recalculate button
        {
            if (!(Regex.IsMatch(qtyTextBox1.Text, @"^\d+$")))
            {
                qtyTextBox1.Text = "0"; 
            }
            if (!(Regex.IsMatch(qtyTextBox2.Text, @"^\d+$")))
            {
                qtyTextBox2.Text = "0";
            }
            if (!(Regex.IsMatch(qtyTextBox3.Text, @"^\d+$")))
            {
                qtyTextBox3.Text = "0";
            }
            if (!(Regex.IsMatch(qtyTextBox4.Text, @"^\d+$")))
            {
                qtyTextBox4.Text = "0";
            }
            if (!(Regex.IsMatch(qtyTextBox5.Text, @"^\d+$")))
            {
                qtyTextBox5.Text = "0";
            }
            if (!(Regex.IsMatch(qtyTextBox6.Text, @"^\d+$")))
            {
                qtyTextBox6.Text = "0";
            }


            decimal totalProduct1 = 0.00M;
            decimal totalProduct2 = 0.00M;
            decimal totalProduct3 = 0.00M;
            decimal totalProduct4 = 0.00M;
            decimal totalProduct5 = 0.00M;
            decimal totalProduct6 = 0.00M;

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

            decimal estShipping = 2.99M;




            // if (int.TryParse(qtyTextBox1.Text, out int qtyOne) && int.TryParse(qtyTextBox2.Text, out int qtyTwo) && int.TryParse(qtyTextBox3.Text, out int qtyThree) )
            // {
            if (int.TryParse(qtyTextBox1.Text, out int qty1))
            {
                if (Decimal.TryParse(subTotalTextBox1.Text, out decimal costOne))
                {
                    totalProduct1 = (Convert.ToDecimal(subTotalTextBox1.Text) * Convert.ToInt32(qtyTextBox1.Text));
                    //subTotalTextBox1.Text = totalProduct1.ToString();
                }
                else
                {
                    totalProduct1 = 0;
                    //subTotalTextBox1.Text = "0";
                }
            }
            if (int.TryParse(qtyTextBox2.Text, out int qty2))
            {
                if (Decimal.TryParse(subTotalTextBox2.Text, out decimal costTwo))
                {
                    totalProduct2 = Convert.ToDecimal(subTotalTextBox2.Text) * Convert.ToInt32(qtyTextBox2.Text);
                   // subTotalTextBox2.Text = totalProduct2.ToString();
                }
                else
                {
                    totalProduct2 = 0;
                    //subTotalTextBox2.Text = "0";
                }
            }
            if (int.TryParse(qtyTextBox3.Text, out int qty3))
            {
                if (Decimal.TryParse(subTotalTextBox3.Text, out decimal costThree))
                {
                    totalProduct3 = (Convert.ToDecimal(subTotalTextBox3.Text) * Convert.ToInt32(qtyTextBox3.Text));
                   // subTotalTextBox3.Text = totalProduct3.ToString();
                }
                else
                {
                    totalProduct3 = 0;
                   // subTotalTextBox3.Text = totalProduct3.ToString();
                }
            }
            if (int.TryParse(qtyTextBox4.Text, out int qty4))
            {
                if (Decimal.TryParse(subTotalTextBox4.Text, out decimal costFour))
                {
                    totalProduct4 = (Convert.ToDecimal(subTotalTextBox4.Text) * Convert.ToInt32(qtyTextBox4.Text));
                   // subTotalTextBox4.Text = totalProduct4.ToString();
                }
                else
                {
                    totalProduct4 = 0;
                   // subTotalTextBox4.Text = totalProduct4.ToString();
                }
            }
            if (int.TryParse(qtyTextBox5.Text, out int qty5))
            {
                if (Decimal.TryParse(subTotalTextBox5.Text, out decimal costFive))
                {
                    totalProduct5 = (Convert.ToDecimal(subTotalTextBox5.Text) * Convert.ToInt32(qtyTextBox5.Text));
                   // subTotalTextBox5.Text = totalProduct5.ToString();
                }
                else
                {
                    totalProduct5 = 0;
                   // subTotalTextBox5.Text = totalProduct5.ToString();
                }
            }
            if (int.TryParse(qtyTextBox6.Text, out int qty6))
            {
                if (Decimal.TryParse(subTotalTextBox6.Text, out decimal costSix))
                {

                    totalProduct6 = (Convert.ToDecimal(subTotalTextBox6.Text) * Convert.ToInt32(qtyTextBox6.Text));
                   // subTotalTextBox6.Text = totalProduct6.ToString();
                }
                else
                {
                    totalProduct6 = 0;
                 //   subTotalTextBox6.Text = totalProduct6.ToString();
                }
            }

            int qtyProd1 = 0;
            int qtyProd2 = 0;
            int qtyProd3 = 0;
            int qtyProd4 = 0;
            int qtyProd5 = 0;
            int qtyProd6 = 0;

            if (qtyTextBox1.Text != "")
                qtyProd1 = Convert.ToInt32(qtyTextBox1.Text);
            if (qtyTextBox2.Text != "")
                qtyProd2 = Convert.ToInt32(qtyTextBox2.Text);
            if (qtyTextBox3.Text != "")
                qtyProd3 = Convert.ToInt32(qtyTextBox3.Text);
            if (qtyTextBox4.Text != "")
                qtyProd4 = Convert.ToInt32(qtyTextBox4.Text);
            if (qtyTextBox5.Text != "")
                qtyProd5 = Convert.ToInt32(qtyTextBox5.Text);
            if (qtyTextBox6.Text != "")
                qtyProd6 = Convert.ToInt32(qtyTextBox6.Text);


            int totalQty = qtyProd1 + qtyProd2 + qtyProd3 + qtyProd4 + qtyProd5 + qtyProd6;

            decimal subTotal = totalProduct1 + totalProduct2 + totalProduct3 + totalProduct4 + totalProduct5 + totalProduct6;
            decimal estTax = subTotal * taxRate;
            decimal estShippingCalc = estShipping;

            taxLabel.Text = (estTax).ToString("0.00");

            if (subTotal == 0)
                estShippingLabel.Text = "0.00";
            else
                estShippingLabel.Text = (estShippingCalc).ToString("0.00");

            if (subTotal == 0)
                estTotalLabel.Text = "0.00";
            else
                estTotalLabel.Text = (subTotal + estTax + estShippingCalc).ToString("0.00");




            /*
            object selectedItem = shoppingCartListBox.SelectedItem;
            shoppingCartListBox.Items.Remove(selectedItem);

            if (shoppingCartListBox.Items.Count == 0)
            {
                qtyTextBox1.Text = "";
                qtyTextBox2.Text = "";
                qtyTextBox3.Text = "";
                qtyTextBox4.Text = "";
                qtyTextBox5.Text = "";
                qtyTextBox6.Text = "";
            }
            if (shoppingCartListBox.Items.Count == 1)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "";
                qtyTextBox3.Text = "";
                qtyTextBox4.Text = "";
                qtyTextBox5.Text = "";
                qtyTextBox6.Text = "";
            }
            else if (shoppingCartListBox.Items.Count == 2)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "";
                qtyTextBox4.Text = "";
                qtyTextBox5.Text = "";
                qtyTextBox6.Text = "";
            }
            else if (shoppingCartListBox.Items.Count == 3)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "";
                qtyTextBox5.Text = "";
                qtyTextBox6.Text = "";
            }
            else if (shoppingCartListBox.Items.Count == 4)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "1";
                qtyTextBox5.Text = "";
                qtyTextBox6.Text = "";
            }
            else if (shoppingCartListBox.Items.Count == 5)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "1";
                qtyTextBox5.Text = "1";
                qtyTextBox6.Text = "";
            }
            else if (shoppingCartListBox.Items.Count == 6)
            {
                qtyTextBox1.Text = "1";
                qtyTextBox2.Text = "1";
                qtyTextBox3.Text = "1";
                qtyTextBox4.Text = "1";
                qtyTextBox5.Text = "1";
                qtyTextBox6.Text = "1";
            }
            */
        
        }
        

        private void displaySelectedItemButton_Click(object sender, EventArgs e)
        {
            List<BrowseProducts> listBrowse = new List<BrowseProducts>();
            List<Sales> listSales = new List<Sales>(); 

            listBrowse = BrowseProductsDB.GetAll();
            listSales = SalesProductsDB.GetAll();

            String productRow = "";

            if (shoppingCartListBox.SelectedItem != null)
                 productRow = shoppingCartListBox.SelectedItem.ToString();
            
            //String[] productArr = productRow.Split(" ");

            foreach (BrowseProducts browseProduct in listBrowse)
            {
                if (browseProduct.Name == productRow)
                {
                    productLabelOne.Text = browseProduct.Name;
                    productDescLabelOne.Text = browseProduct.Description;
                    productPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;
                    FileStream fs = new System.IO.FileStream(browseProduct.Image.ToString(), FileMode.Open, FileAccess.Read);
                    productPictureBoxOne.Image = Image.FromStream(fs);
                    fs.Close();
                    priceLabel.Text = browseProduct.Price.ToString(); 
                }
            }
            foreach (Sales salesProduct in listSales)
            {
                if (salesProduct.SalesName == productRow)
                {
                    productLabelOne.Text = salesProduct.SalesName;
                    productDescLabelOne.Text = salesProduct.Description;
                    productPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;
                    FileStream fs = new System.IO.FileStream(salesProduct.Image.ToString(), FileMode.Open, FileAccess.Read);
                    productPictureBoxOne.Image = Image.FromStream(fs);
                    fs.Close();
                    priceLabel.Text = salesProduct.Price.ToString();
                }
            }

        }

        private void goBackSalesButton_Click(object sender, EventArgs e)
        {
            shoppingCartListBoxRef = shoppingCartListBox;

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

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
           

           


            if (shoppingCartListBox.Items.Count == 1)
            {
                if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[0])
                {
                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[0]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox1.Text = "";
                    qtyTextBox1.Text = "";
                }
            }

            
            if (shoppingCartListBox.Items.Count == 2)
            {
                if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[1])
                {
                    
                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[1]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox2.Text = "";
                    qtyTextBox2.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[0])
                {
                    shoppingCartListBox.Items[0] = shoppingCartListBox.Items[1];
                    subTotalTextBox1.Text = subTotalTextBox2.Text;
                    qtyTextBox1.Text = qtyTextBox2.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[1]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox2.Text = "0.00";
                    qtyTextBox2.Text = "";
                }
            }



            if (shoppingCartListBox.Items.Count == 3)
            {
                if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[2])
                {
                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[2]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox3.Text = "";
                    qtyTextBox3.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[1])
                {
                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;
                    
                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[2]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox3.Text = "";
                    qtyTextBox3.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[0])
                {
                    shoppingCartListBox.Items[0] = shoppingCartListBox.Items[1];
                    subTotalTextBox1.Text = subTotalTextBox2.Text;
                    qtyTextBox1.Text = qtyTextBox2.Text;

                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[2]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox3.Text = "";
                    qtyTextBox3.Text = "";
                }
            }

            if (shoppingCartListBox.Items.Count == 4)
            {
                if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[3])
                {
                    
                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[3]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox4.Text = "";
                    qtyTextBox4.Text = "";
                }

                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[2])
                {
                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[3]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox4.Text = "";
                    qtyTextBox4.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[1])
                {

                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[3]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox4.Text = "";
                    qtyTextBox4.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[0])
                {
                    shoppingCartListBox.Items[0] = shoppingCartListBox.Items[1];
                    subTotalTextBox1.Text = subTotalTextBox2.Text;
                    qtyTextBox1.Text = qtyTextBox2.Text;

                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[3]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox4.Text = "";
                    qtyTextBox4.Text = "";
                }
            }

            if (shoppingCartListBox.Items.Count == 5)
            {
                if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[4])
                {

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[4]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox5.Text = "";
                    qtyTextBox5.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[3])
                {
                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[4]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox5.Text = "";
                    qtyTextBox5.Text = "";
                }

                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[2])
                {
                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[4]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox5.Text = "";
                    qtyTextBox5.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[1])
                {
                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[4]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox5.Text = "";
                    qtyTextBox5.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[0])
                {
                    shoppingCartListBox.Items[0] = shoppingCartListBox.Items[1];
                    subTotalTextBox1.Text = subTotalTextBox2.Text;
                    qtyTextBox1.Text = qtyTextBox2.Text;

                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[4]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox5.Text = "";
                    qtyTextBox5.Text = "";
                }
            }

            if (shoppingCartListBox.Items.Count == 6)
            {
                if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[5])
                {
                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);   //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox6.Text = "";
                    qtyTextBox6.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[4])
                {
                    shoppingCartListBox.Items[4] = shoppingCartListBox.Items[5];
                    subTotalTextBox5.Text = subTotalTextBox6.Text;
                    qtyTextBox5.Text = qtyTextBox6.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox6.Text = "";
                    qtyTextBox6.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[3])
                {
                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items[4] = shoppingCartListBox.Items[5];
                    subTotalTextBox5.Text = subTotalTextBox6.Text;
                    qtyTextBox5.Text = qtyTextBox6.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox6.Text = "";
                    qtyTextBox6.Text = "";
                }

                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[2])
                {
                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items[4] = shoppingCartListBox.Items[5];
                    subTotalTextBox5.Text = subTotalTextBox6.Text;
                    qtyTextBox5.Text = qtyTextBox6.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox6.Text = "";
                    qtyTextBox6.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[1])
                {
                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items[4] = shoppingCartListBox.Items[5];
                    subTotalTextBox5.Text = subTotalTextBox6.Text;
                    qtyTextBox5.Text = qtyTextBox6.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox6.Text = "";
                    qtyTextBox6.Text = "";
                }
                else if (shoppingCartListBox.SelectedItem == shoppingCartListBox.Items[0])
                {
                    shoppingCartListBox.Items[0] = shoppingCartListBox.Items[1];
                    subTotalTextBox1.Text = subTotalTextBox2.Text;
                    qtyTextBox1.Text = qtyTextBox2.Text;

                    shoppingCartListBox.Items[1] = shoppingCartListBox.Items[2];
                    subTotalTextBox2.Text = subTotalTextBox3.Text;
                    qtyTextBox2.Text = qtyTextBox3.Text;

                    shoppingCartListBox.Items[2] = shoppingCartListBox.Items[3];
                    subTotalTextBox3.Text = subTotalTextBox4.Text;
                    qtyTextBox3.Text = qtyTextBox4.Text;

                    shoppingCartListBox.Items[3] = shoppingCartListBox.Items[4];
                    subTotalTextBox4.Text = subTotalTextBox5.Text;
                    qtyTextBox4.Text = qtyTextBox5.Text;

                    shoppingCartListBox.Items[4] = shoppingCartListBox.Items[5];
                    subTotalTextBox5.Text = subTotalTextBox6.Text;
                    qtyTextBox5.Text = qtyTextBox6.Text;

                    shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);    //shoppingCartListBox.Items.Remove(shoppingCartListBox.Items[5]);
                    subTotalTextBox6.Text = "";
                    qtyTextBox6.Text = "";
                }
            }







        }
    }
}
