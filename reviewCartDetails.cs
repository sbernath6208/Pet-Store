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

namespace Final_Pet_Store_Bernath
{
    public partial class reviewCartDetails : Form
    {
        public static reviewCartDetails instance;

        public Label totalCostRef;
        public TextBox estDeliveryDateRef;
        public Label totalQtyOneRef;
        public Label totalQtyTwoRef;
        public Label totalQtyThreeRef;
        public Label productOneNameRef;
        public Label productTwoNameRef;
        public Label productThreeNameRef;
        public Label shippingLabelRef;
        public ComboBox shipMethodComboBoxRef;
        public Label taxLabelRef;
        public String todaysDateRef;
        public int shipperIdRef;
        public DateTime estShippingDateRef;

        public reviewCartDetails()
        {
            InitializeComponent();
            instance = this;
            totalCostRef = TotalLabel;
            estDeliveryDateRef = estDeliveryDateTextBox; 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (updateCreditCard.instance != null)
            {
                updateCreditCard updateCCForm = updateCreditCard.instance;
                updateCCForm.Show();
                this.Hide();
            }
            else
            {
                updateCreditCard updateCCForm = new updateCreditCard();
                updateCCForm.Show();
                this.Hide();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            diffShippingAddr diffForm = new diffShippingAddr();
            diffForm.Show();
            this.Hide(); 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                /*
                totalCostRef = TotalLabel;
                estDeliveryDateRef = estDeliveryDateTextBox;
                totalQtyOneRef = productOneQty;
                totalQtyTwoRef = productTwoQty;
                totalQtyThreeRef = productThreeQty;
                productOneNameRef = productOneLabel;
                productTwoNameRef = productTwoLabel;
                productThreeNameRef = productThreeLabel;
                shippingLabelRef = shippingLabel;

                shippingLabelRef = shippingLabel;
                shipMethodComboBoxRef = shipMethodComboBox;
                taxLabelRef = taxLabel;
                */

                if (MainForm.instance.userTextBoxRef != null)
                {
                    
                    List<BrowseProducts> browseProducts = new List<BrowseProducts>(); 
                    List<Sales> salesProducts = new List<Sales>(); 
                    browseProducts = BrowseProductsDB.GetAll();
                    salesProducts = SalesProductsDB.GetAll(); 
                    Order cartOrder = new Order();
                    //OrderLine cartOrderLine = new OrderLine();
                    String userName = MainForm.instance.userTextBoxRef.Text;
                    Profile profile = ProfileDB.GetByUserName(userName);
                    Address address = AddressDB.GetById(profile.AddressId);
                    Pet pet = new Pet();
                    pet.PetId = 14;
                    pet.CategoryId = 1;
                    pet.StatusId = 2;
                    pet.BreedId = 1; 
                    pet.Name = "Throw away record";
                    pet.Description = "Throw away for foreign key constraint";
                    pet.Price = 0.00M;
                    pet.Image = ""; 
                    PetDB.Update(pet); 
                    


                    cartOrder.UserName = userName;
                    cartOrder.BillAddressId = profile.AddressId;
                    cartOrder.BillingFirstName = profile.FirstName;
                    cartOrder.BillingLastName = profile.LastName;
                    cartOrder.ShipperId = shipperIdRef;
                    cartOrder.ShippingCost = Convert.ToDecimal(shippingLabel.Text);
                    cartOrder.SalesTax = Convert.ToDecimal(taxLabel.Text);
                    cartOrder.TotalCost = Convert.ToDecimal(TotalLabel.Text);
                    //cartOrder.CreditCardNo = creditCardTextBox.Text; // is this legal to store the entire card by PCI standards?  probably not
                    // here is another way to store the credit card with only the last four digits for verification
                    cartOrder.CreditCardNo = creditCardTextBox.Text.Substring(creditCardTextBox.Text.Length - 4); // this is more secure and less legal work, I believe
                    cartOrder.BillAddressId = profile.AddressId;
                    cartOrder.ShipToFirstName = profile.FirstName;
                    cartOrder.ShipToLastName = profile.LastName;
                    cartOrder.ShipToAddressId = profile.AddressId;
                    cartOrder.StatusId = 5;
                    OrderDB.Add(cartOrder);

                    int[] qtys = new int[5];
                    if ((qtyTextBox1.Text != "") && (qtyTextBox1.Text != "0")) 
                        qtys[0] = Convert.ToInt32(qtyTextBox1.Text);
                    if ((qtyTextBox2.Text != "") && (qtyTextBox2.Text != "0"))
                        qtys[1] = Convert.ToInt32(qtyTextBox2.Text);
                    if ((qtyTextBox3.Text != "") && (qtyTextBox3.Text != "0"))
                        qtys[2] = Convert.ToInt32(qtyTextBox3.Text);
                    if ((qtyTextBox4.Text != "") && (qtyTextBox4.Text != "0"))
                        qtys[3] = Convert.ToInt32(qtyTextBox4.Text);
                    if ((qtyTextBox5.Text != "") && (qtyTextBox5.Text != "0"))
                        qtys[4] = Convert.ToInt32(qtyTextBox5.Text);
                    if ((qtyTextBox6.Text != "") && (qtyTextBox6.Text != "0"))
                        qtys[5] = Convert.ToInt32(qtyTextBox6.Text);

                    decimal[] subTotals = new decimal[6];
                    if ((subTotalTextBox1.Text != "") && (subTotalTextBox1.Text != "0.00")) 
                        subTotals[0] = Convert.ToDecimal(subTotalTextBox1.Text);
                    if ((subTotalTextBox2.Text != "") && (subTotalTextBox2.Text != "0.00"))
                        subTotals[1] = Convert.ToDecimal(subTotalTextBox2.Text);
                    if ((subTotalTextBox3.Text != "") && (subTotalTextBox3.Text != "0.00"))
                        subTotals[2] = Convert.ToDecimal(subTotalTextBox3.Text);
                    if ((subTotalTextBox4.Text != "") && (subTotalTextBox4.Text != "0.00"))
                        subTotals[3] = Convert.ToDecimal(subTotalTextBox4.Text);
                    if ((subTotalTextBox5.Text != "") && (subTotalTextBox5.Text != "0.00"))
                        subTotals[4] = Convert.ToDecimal(subTotalTextBox5.Text);
                    if ((subTotalTextBox6.Text != "") && (subTotalTextBox6.Text != "0.00"))
                        subTotals[5] = Convert.ToDecimal(subTotalTextBox6.Text);

             
                    int i = 0;
                    foreach (string productName in reviewListBox.Items)
                    {
                        
                        foreach (BrowseProducts browseProduct in browseProducts)
                        {
                            
                            if (browseProduct.Name == productName)
                            {
                                
                                BrowseProducts browseProductTemp = BrowseProductsDB.GetByName(productName); 
                                OrderLine cartOrderLine = new OrderLine();
                                   
                                cartOrderLine.OrderNo = cartOrder.OrderNo;
                                //cartOrderLine.LineNo = ?
                                cartOrderLine.ProductId = browseProduct.ProductId;

                                cartOrderLine.Qty = qtys[i];
                                cartOrderLine.StatusId = 5;
                                cartOrderLine.ExtendedPrice = subTotals[i];
                                cartOrderLine.Price = Convert.ToDecimal(browseProduct.Price);
                                cartOrderLine.ShipDate = estShippingDateRef;
                                cartOrderLine.PetId = 14; 
                                OrderLineDB.Add(cartOrderLine);
                                
                            }
                        }
                        foreach (Sales salesProduct in salesProducts)
                        {

                            if (salesProduct.SalesName == productName)
                            {
                                
                                Sales salesProductTemp = SalesProductsDB.GetByName(productName);
                                OrderLine cartOrderLine = new OrderLine();

                                cartOrderLine.OrderNo = cartOrder.OrderNo;
                                //cartOrderLine.LineNo = ?
                                cartOrderLine.SalesId = salesProduct.SalesId;
                                cartOrderLine.Qty = qtys[i];
                                cartOrderLine.StatusId = 5;
                                cartOrderLine.ExtendedPrice = subTotals[i];
                                cartOrderLine.Price = Convert.ToDecimal(salesProduct.Price);
                                cartOrderLine.ShipDate = estShippingDateRef;
                                cartOrderLine.PetId = 14;
                                OrderLineDB.Add(cartOrderLine);
                                
                            }

                        }

                        i++;
                    }
                    

                    OrderConfirmed orderConfirmedForm = new OrderConfirmed();
                    orderConfirmedForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Must create an account to complete purchase.  Please create an account and/or login to proceed.");
                }
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

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }

        private void ShippingMethod_Validating(object sender, CancelEventArgs e)
        {
            if ((shipMethodComboBox.Text != "Ground") && (shipMethodComboBox.Text != "ExFast") && (shipMethodComboBox.Text != "Air"))
            {
                errorProvider.SetError(shipMethodComboBox, "Must select either 'Ground', 'ExFast', or 'Air'.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(shipMethodComboBox, "");
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

        private void creditCardTextBox_Validating(object sender, CancelEventArgs e)
        {
            
            if (creditCardTextBox.Text.Length == 0)
            {
                errorProvider.SetError(creditCardTextBox, "Credit card number is required.");
                e.Cancel = true;
            }
            
            if (!checkLuhn(creditCardTextBox.Text))
            {
                errorProvider.SetError(creditCardTextBox, "Credit card number is incorrect.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(creditCardTextBox, "");
                e.Cancel = false;

            }
        }

        private void reviewCartDetails_Load(object sender, EventArgs e)
        {
            shipMethodButton.Hide();

            if (MainForm.instance.userTextBoxRef != null)
            {
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            }

            // creditCardTextBox.Text = "";
            try
            {
                if (updateCreditCard.instance != null)
                {
                    if (updateCreditCard.instance.CCNumberRef != null)
                            creditCardTextBox.Text = updateCreditCard.instance.CCNumberRef.Text;
                      
                    else
                        creditCardTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //foreach (string productName in ShoppingCart.instance.listBoxArrRef)
            //  reviewListBox.Items.Add(productName);
            foreach (object row in ShoppingCart.instance.shoppingCartListBoxRef.Items)
            {
                String productStr = row.ToString();
                //String[] productArr = productStr.Split(" ");
                //if (browseAllProducts.instance.browseListBoxRef.Items(row) != "")
                reviewListBox.Items.Add(productStr);
                //= ShoppingCart.instance.;
            }

            qtyTextBox1.Text = ShoppingCart.instance.qtyTextBox1Ref.Text;
            qtyTextBox2.Text = ShoppingCart.instance.qtyTextBox2Ref.Text;
            qtyTextBox3.Text = ShoppingCart.instance.qtyTextBox3Ref.Text;
            qtyTextBox4.Text = ShoppingCart.instance.qtyTextBox4Ref.Text;
            qtyTextBox5.Text = ShoppingCart.instance.qtyTextBox5Ref.Text;
            qtyTextBox6.Text = ShoppingCart.instance.qtyTextBox6Ref.Text;

            subTotalTextBox1.Text = ShoppingCart.instance.subTotalTextBox1Ref;
            subTotalTextBox2.Text = ShoppingCart.instance.subTotalTextBox2Ref;
            subTotalTextBox3.Text = ShoppingCart.instance.subTotalTextBox3Ref;
            subTotalTextBox4.Text = ShoppingCart.instance.subTotalTextBox4Ref;
            subTotalTextBox5.Text = ShoppingCart.instance.subTotalTextBox5Ref;
            subTotalTextBox6.Text = ShoppingCart.instance.subTotalTextBox6Ref;

            //decimal taxRate = 0.06M;

            String todaysDate = DateTime.Now.ToString("MM/dd/yyyy");
            todaysDateRef = todaysDate;
            DateTime today = DateTime.Now;
            DateTime shippingDate = today.AddDays(14);
            estDeliveryDateTextBox.Text = shippingDate.ToString("MM/dd/yyyy");
            estShippingDateRef = shippingDate;

            taxLabel.Text = ShoppingCart.instance.taxTotalRef.Text;
            shippingLabel.Text = ShoppingCart.instance.estShippingRef.Text;
            TotalLabel.Text = ShoppingCart.instance.estTotalRef.Text;

            /*
            productOneLabel.Text = ShoppingCart.instance.productNameLabelOneRef.Text;
            productTwoLabel.Text = ShoppingCart.instance.productNameLabelTwoRef.Text;
            productThreeLabel.Text = ShoppingCart.instance.productNameLabelThreeRef.Text;
            */
            /*
            decimal costProductOne;
            decimal costProductTwo;
            decimal costProductThree;
            */
            /*
            if (ShoppingCart.instance.costTextBoxOneRef.Text != "")
                costProductOne = Convert.ToDecimal(ShoppingCart.instance.costTextBoxOneRef.Text);
            else
                costProductOne = 0; 
            if (ShoppingCart.instance.costTextBoxTwoRef.Text != "")
                costProductTwo = Convert.ToDecimal(ShoppingCart.instance.costTextBoxTwoRef.Text);
            else
                costProductTwo = 0;
            if (ShoppingCart.instance.costTextBoxThreeRef.Text != "")
                costProductThree = Convert.ToDecimal(ShoppingCart.instance.costTextBoxThreeRef.Text);
            else
                costProductThree = 0;

            int productQtyOne = Convert.ToInt32(ShoppingCart.instance.qtyTextBoxOneRef.Text);
            int productQtyTwo = Convert.ToInt32(ShoppingCart.instance.qtyTextBoxTwoRef.Text);
            int productQtyThree = Convert.ToInt32(ShoppingCart.instance.qtyTextBoxThreeRef.Text);
            int totalProductQty = productQtyOne + productQtyTwo + productQtyThree;

            productOneQty.Text = ShoppingCart.instance.qtyTextBoxOneRef.Text;
            productTwoQty.Text = ShoppingCart.instance.qtyTextBoxTwoRef.Text;
            productThreeQty.Text = ShoppingCart.instance.qtyTextBoxThreeRef.Text;

            productOneTotalLabel.Text = (costProductOne * productQtyOne).ToString();
            productTwoTotalLabel.Text = (costProductTwo * productQtyTwo).ToString();
            productThreeTotalLabel.Text = (costProductThree * productQtyThree).ToString();

            decimal subTotal = (costProductOne * productQtyOne) + (costProductTwo * productQtyTwo) + (costProductThree * productQtyThree);

            decimal taxTotal = (subTotal * taxRate);
            taxLabel.Text = taxTotal.ToString("0.00"); 

            decimal shippingCost = 0.00M;
            if (shipMethodComboBox.Text == "Ground") 
                shippingCost = 2.99M;
            else if (shipMethodComboBox.Text == "ExFast")
                shippingCost = 3.99M;
            else if (shipMethodComboBox.Text == "Air")
                shippingCost = 5.99M;
            decimal shippingTotal = (shippingCost * totalProductQty);
            shippingLabel.Text = shippingTotal.ToString("0.00");

            TotalLabel.Text = (subTotal + shippingTotal + taxTotal).ToString("0.00");
            */
            /*
                totalCostRef = TotalLabel;
                estDeliveryDateRef = estDeliveryDateTextBox;
                totalQtyOneRef = productOneQty;
                totalQtyTwoRef = productTwoQty;
                totalQtyThreeRef = productThreeQty;
                productOneNameRef = productOneLabel;
                productTwoNameRef = productTwoLabel;
                productThreeNameRef = productThreeLabel;
            */
            //productOneTotalLabel.Text = ShoppingCart.instance.totalProductOneRef.ToString();

        }

        private void shipMethodButton_Click(object sender, EventArgs e)
        {
            decimal shippingCost = 0.00M;
            if (shipMethodComboBox.Text == "Ground")
            {
                shippingCost = 2.99M;
                shipperIdRef = 1;
            }
            else if (shipMethodComboBox.Text == "ExFast")
            {
                shippingCost = 3.99M;
                shipperIdRef = 2;
            }
            else if (shipMethodComboBox.Text == "Air")
            {
                shippingCost = 5.99M;
                shipperIdRef = 3;
            }
            decimal shippingTotal = shippingCost; 
            shippingLabel.Text = shippingCost.ToString();

            decimal totalProduct1 = 0.00M;
            decimal totalProduct2 = 0.00M;
            decimal totalProduct3 = 0.00M;
            decimal totalProduct4 = 0.00M;
            decimal totalProduct5 = 0.00M;
            decimal totalProduct6 = 0.00M;

            if (subTotalTextBox1.Text != null)
            {
                totalProduct1 = Convert.ToDecimal(subTotalTextBox1.Text);
            }
            if (subTotalTextBox2.Text != null)
            {
                totalProduct2 = Convert.ToDecimal(subTotalTextBox2.Text);
            }
            if (subTotalTextBox3.Text != null)
            {
                totalProduct3 = Convert.ToDecimal(subTotalTextBox3.Text);
            }
            if (subTotalTextBox4.Text != null)
            {
                totalProduct4 = Convert.ToDecimal(subTotalTextBox4.Text);
            }
            if (subTotalTextBox5.Text != null)
            {
                totalProduct5 = Convert.ToDecimal(subTotalTextBox5.Text);
            }
            if (subTotalTextBox6.Text != null)
            {
                totalProduct6 = Convert.ToDecimal(subTotalTextBox6.Text);
            }

            decimal subTotal = totalProduct1 + totalProduct2 + totalProduct3 + totalProduct4 + totalProduct5 + totalProduct6;
             

            TotalLabel.Text = (subTotal + shippingTotal + Convert.ToDecimal(taxLabel.Text)).ToString("0.00");
        }
    }
}
