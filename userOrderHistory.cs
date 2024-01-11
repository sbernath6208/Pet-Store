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
    public partial class userOrderHistory : Form
    {
        public static userOrderHistory instance;
        public string orderNoRef; // userOrderHistory.instance.orderNoRef;

        public userOrderHistory()
        {
            InitializeComponent();
            instance = this; 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            orderNoRef = orderNoComboBox.Text;

            orderDetailsHistory orderDetailsHist = new orderDetailsHistory();
            orderDetailsHist.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
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

        private void label5_Click(object sender, EventArgs e)
        {
            String userName = MainForm.instance.userTextBoxRef.Text;
            List<Order> userOrders = new List<Order>();
            userOrders = OrderDB.GetByUserName(userName);


            //orderNoComboBox.Items.Add();


        }

        private void userOrderHistory_Load(object sender, EventArgs e)
        {
            String userName = "";

            if (MainForm.instance.userTextBoxRef != null)
            {
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

                userName = MainForm.instance.userTextBoxRef.Text;
            }
            List<Order> userOrderNos = new List<Order>();
            userOrderNos = OrderDB.GetByUserName(userName);
            //int[] orderNoArr = new int[];

            int i = 0;
            
            foreach (Order orderNo in userOrderNos)
            {
                orderNoComboBox.Items.Add(orderNo.OrderNo);
                i++;
            }
            
            

            int totalOrders = i; 
            int[] orderNoArr = new int[i];

            i = 0; 
            foreach (Order orderNo in userOrderNos)
            {
                int thisOrderNo = orderNo.OrderNo; 
                orderNoArr[i] = thisOrderNo;
                i++; 
            }

            for (int k = 0; k < totalOrders; k++)
            {
                if (orderNoComboBox.Text == orderNoArr[k].ToString())
                {
                    int thisOrderSelected = orderNoArr[k]; 
                    Order orderNoSelected = OrderDB.GetById(thisOrderSelected);
                    //dateLabelOne.Text = orderNoSelected.

                    OrderLine thisOrderLine = OrderLineDB.GetByOrderAndLine(thisOrderSelected, 1);
                    if (thisOrderLine != null)
                    {
                        dateLabelOne.Text = thisOrderLine.ShipDate.ToString();
                    }
                    else
                        dateLabelOne.Text = ""; 
                    orderNumLabelOne.Text = thisOrderSelected.ToString();
                    totalCostLabelOne.Text = orderNoSelected.TotalCost.ToString();  
                }
            }




                /*
                String orderNos = "";
                foreach (Order orderNo in userOrderNos)
                    orderNos += orderNo.ToString() + "\t"; 
                MessageBox.Show(orderNos); 
                */


                //orderNoComboBox
                /*
                if (reviewCartDetails.instance != null)
                {
                    totalCostLabelOne.Text = reviewCartDetails.instance.totalCostRef.Text;

                    dateLabelOne.Text = reviewCartDetails.instance.todaysDateRef;

                    orderNumLabelOne.Text = reviewCartDetails.instance.productOneNameRef.Text;
                    //productDateOneLabelTwo.Text = reviewCartDetails.instance.productTwoNameRef.Text;
                   // productDateOneLabelThree.Text = reviewCartDetails.instance.productThreeNameRef.Text;

                }
                */
            }

        private void rePopulate_Change(object sender, EventArgs e)
        {
            String userName = MainForm.instance.userTextBoxRef.Text;
            List<Order> userOrderNos = new List<Order>();
            userOrderNos = OrderDB.GetByUserName(userName);
            //int[] orderNoArr = new int[];

            int i = 0;

            
            foreach (Order orderNo in userOrderNos)
            {
                //orderNoComboBox.Items.Add(orderNo.OrderNo);
                i++;
            }
            


            int totalOrders = i;
            int[] orderNoArr = new int[i];

            i = 0;
            foreach (Order orderNo in userOrderNos)
            {
                int thisOrderNo = orderNo.OrderNo;
                orderNoArr[i] = thisOrderNo;
                i++;
            }

            for (int k = 0; k < totalOrders; k++)
            {
                if (orderNoComboBox.Text == orderNoArr[k].ToString())
                {
                    int thisOrderSelected = orderNoArr[k];
                    Order orderNoSelected = OrderDB.GetById(thisOrderSelected);
                    //dateLabelOne.Text = orderNoSelected.

                    OrderLine thisOrderLine = OrderLineDB.GetByOrderAndLine(thisOrderSelected, 1);
                    if (thisOrderLine != null)
                    {
                        dateLabelOne.Text = thisOrderLine.ShipDate.ToString();
                    }
                    else
                        dateLabelOne.Text = "";
                    orderNumLabelOne.Text = thisOrderSelected.ToString();
                    totalCostLabelOne.Text = orderNoSelected.TotalCost.ToString();
                }
            }
        }
    }
}
