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
using Final_Pet_Store_Bernath.DataAccessLayer.BussinessObjects;
using Final_Pet_Store_Bernath.DataAccessLayer.DBObjects;

namespace Final_Pet_Store_Bernath
{
    public partial class orderDetailsHistory : Form
    {
        public orderDetailsHistory()
        {
            InitializeComponent();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            userOrderHistory userOrderHist = new userOrderHistory();
            userOrderHist.Show();
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

        private void orderDetailsHistory_Load(object sender, EventArgs e)
        {
            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            int orderNo = Convert.ToInt32(userOrderHistory.instance.orderNoRef); 
            String userName = MainForm.instance.userTextBoxRef.Text;
            List<OrderLine> userOrderLines = new List<OrderLine>();
            userOrderLines = OrderLineDB.GetByOrderNo(orderNo);
            //OrderLine orderLine = new OrderLine(); 
            //int[] orderNoArr = new int[];

            int i = 0;

            foreach (OrderLine orderLine in userOrderLines)
            {
                orderLineComboBox.Items.Add(orderLine.LineNo);
                i++;
            }

            int totalLines = i;
            int[] orderLinesArr = new int[i];

            i = 0;
            foreach (OrderLine orderLine in userOrderLines)
            {
                int thisOrderLine = orderLine.LineNo;
                orderLinesArr[i] = thisOrderLine;
                i++;
            }

            for (int k = 0; k < totalLines; k++)
            {
                if (orderLineComboBox.Text == orderLinesArr[k].ToString())
                {
                    int thisOrderNo = Convert.ToInt32(orderNo);
                    Order orderSelected = OrderDB.GetById(thisOrderNo); 
                    int thisLineSelected = orderLinesArr[k];
                    OrderLine orderLineSelected = OrderLineDB.GetByOrderAndLine(Convert.ToInt32(orderNo), thisLineSelected);
                    //dateLabelOne.Text = orderNoSelected.

                   // OrderLine thisOrderLine = OrderLineDB.GetByOrderAndLine(thisLineSelected);
                    if (orderLineSelected != null)
                    {
                        arrivalDateTextBox.Text = orderLineSelected.ShipDate.ToString();
                    }
                    else
                        arrivalDateTextBox.Text = "";
                    if (orderLineSelected.ProductId != 0)
                    {
                        BrowseProducts thisProduct = BrowseProductsDB.GetById(orderLineSelected.ProductId);
                        productTextBoxOne.Text = thisProduct.Name;
                        label101.Text = thisProduct.Price.ToString(); 
                     }
                    else if (orderLineSelected.SalesId != 0)
                    {
                        Sales salesProduct = SalesProductsDB.GetById(orderLineSelected.SalesId);
                        productTextBoxOne.Text = salesProduct.SalesName;
                        label101.Text = salesProduct.Price.ToString();
                    }

                    quantityTextBoxOne.Text = orderLineSelected.Qty.ToString();
                    shippingCostTextBox.Text = orderSelected.ShippingCost.ToString();
                    shippingMethodTextBox.Text = orderSelected.ShipperId.ToString();
                    taxTextBox.Text = orderSelected.SalesTax.ToString();
                    totalCostTextBox.Text = orderLineSelected.ExtendedPrice.ToString();
                    arrivalDateTextBox.Text = orderLineSelected.ShipDate.ToString(); 

                }
            }

            /*
            if (reviewCartDetails.instance != null)
            {
                dateTextBox.Text = reviewCartDetails.instance.todaysDateRef;

                quantityTextBoxOne.Text = reviewCartDetails.instance.totalQtyOneRef.Text;
                quantityTextBoxTwo.Text = reviewCartDetails.instance.totalQtyTwoRef.Text;
                quantityTextBoxThree.Text = reviewCartDetails.instance.totalQtyThreeRef.Text;
                productTextBoxOne.Text = reviewCartDetails.instance.productOneNameRef.Text;
                productTextBoxTwo.Text = reviewCartDetails.instance.productTwoNameRef.Text;
                productTextBoxThree.Text = reviewCartDetails.instance.productThreeNameRef.Text;
                shippingCostTextBox.Text = reviewCartDetails.instance.shippingLabelRef.Text;
                shippingMethodTextBox.Text = reviewCartDetails.instance.shipMethodComboBoxRef.Text;
                taxTextBox.Text = reviewCartDetails.instance.taxLabelRef.Text;

                totalCostTextBox.Text = reviewCartDetails.instance.totalCostRef.Text;
                arrivalDateTextBox.Text = reviewCartDetails.instance.estDeliveryDateRef.Text;
            */
        
        }

        private void ComboText_Changed(object sender, EventArgs e)
        {
            int orderNo = Convert.ToInt32(userOrderHistory.instance.orderNoRef);
            String userName = MainForm.instance.userTextBoxRef.Text;
            List<OrderLine> userOrderLines = new List<OrderLine>();
            userOrderLines = OrderLineDB.GetByOrderNo(orderNo);
            //OrderLine orderLine = new OrderLine(); 
            //int[] orderNoArr = new int[];

            int i = 0;
            
            foreach (OrderLine orderLine in userOrderLines)
            {
                //orderLineComboBox.Items.Add(orderLine.LineNo);
                i++;
            }
            
            int totalLines = i;
            int[] orderLinesArr = new int[i];

            i = 0;
            foreach (OrderLine orderLine in userOrderLines)
            {
                int thisOrderLine = orderLine.LineNo;
                orderLinesArr[i] = thisOrderLine;
                i++;
            }

            for (int k = 0; k < totalLines; k++)
            {
                if (orderLineComboBox.Text == orderLinesArr[k].ToString())
                {
                    int thisOrderNo = Convert.ToInt32(orderNo);
                    Order orderSelected = OrderDB.GetById(thisOrderNo);
                    int thisLineSelected = orderLinesArr[k];
                    OrderLine orderLineSelected = OrderLineDB.GetByOrderAndLine(Convert.ToInt32(orderNo), thisLineSelected);
                    //dateLabelOne.Text = orderNoSelected.

                    // OrderLine thisOrderLine = OrderLineDB.GetByOrderAndLine(thisLineSelected);
                    if (orderLineSelected != null)
                    {
                        arrivalDateTextBox.Text = orderLineSelected.ShipDate.ToString();
                    }
                    else
                        arrivalDateTextBox.Text = "";
                    if (orderLineSelected.ProductId != 0)
                    {
                        BrowseProducts thisProduct = BrowseProductsDB.GetById(orderLineSelected.ProductId);
                        productTextBoxOne.Text = thisProduct.Name;
                        unitCostTextBox.Text = thisProduct.Price.ToString();
                    }
                    else if (orderLineSelected.SalesId != 0)
                    {
                        Sales salesProduct = SalesProductsDB.GetById(orderLineSelected.SalesId);
                        productTextBoxOne.Text = salesProduct.SalesName;
                        unitCostTextBox.Text = salesProduct.Price.ToString();
                    }

                    quantityTextBoxOne.Text = orderLineSelected.Qty.ToString();
                    shippingCostTextBox.Text = orderSelected.ShippingCost.ToString();
                    shippingMethodTextBox.Text = orderSelected.ShipperId.ToString();
                    taxTextBox.Text = orderSelected.SalesTax.ToString();
                    totalCostTextBox.Text = orderLineSelected.ExtendedPrice.ToString();
                   // arrivalDateTextBox.Text = orderLineSelected.ShipDate.ToString();

                }
            }
            }
    }
}
