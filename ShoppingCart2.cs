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
    public partial class ShoppingCart2 : Form
    {
        public ShoppingCart2()
        {
            InitializeComponent();
        }

        private void ShoppingCart2_Load(object sender, EventArgs e)
        {

        }
    }
}

/*
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
/*
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
    
}
*/
    /*
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
    ShoppingCart cartForm = new ShoppingCart();
    cartForm.Show();
    this.Hide();
}

private void cartDescriptionLabelOne_Click(object sender, EventArgs e)
{

}

private void ShoppingCart_Load(object sender, EventArgs e)
{
    if (MainForm.instance.userTextBoxRef != null)
        userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

    if (browseAllProducts.instance != null)
    {
        if (browseAllProducts.instance.browseListBoxRef != null)
        {
            foreach (object row in browseAllProducts.instance.browseListBoxRef.Items)
                shoppingCartListBox.Items.Add(row);
        }
        else
            shoppingCartListBox.Items.Add("");
        /*
        if (browseAllProducts.instance.productLabelRefOne.Text != "")
            productNameLabelOne.Text = browseAllProducts.instance.productLabelRefOne.Text;
        if (browseAllProducts.instance.productLabelRefTwo.Text != "")
            productNameLabelTwo.Text = browseAllProducts.instance.productLabelRefTwo.Text;
        if (browseAllProducts.instance.productLabelRefThree.Text != "")
            productNameLabelThree.Text = browseAllProducts.instance.productLabelRefThree.Text;
        
    }
    */
    /*
    if (SalesForm.instance != null)
    {
        if (SalesForm.instance.salesListBoxRef != null)
        {
            foreach (object row in SalesForm.instance.salesListBoxRef.Items)
                shoppingCartListBox.Items.Add(row);
        }
        else
            shoppingCartListBox.Items.Add("");
        /*
        if (SalesForm.instance.productLabelRefOne.Text != "")
            productNameLabelOne.Text = SalesForm.instance.productLabelRefOne.Text;
        if (SalesForm.instance.productLabelRefTwo.Text != "")
            productNameLabelTwo.Text = SalesForm.instance.productLabelRefTwo.Text;
        if (SalesForm.instance.productLabelRefThree.Text != "")
            productNameLabelThree.Text = SalesForm.instance.productLabelRefThree.Text;
        
    }
    */
    /*
    cartPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;
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
    if (qtyTextBoxOne.Text == "")
        qtyTextBoxOne.Text = "0";
    if (qtyTextBoxTwo.Text == "")
        qtyTextBoxTwo.Text = "0";
    if (qtyTextBoxThree.Text == "")
        qtyTextBoxThree.Text = "0";
    */
    /*
    decimal taxRate = 0.06M;
    decimal estShipping = 2.99M;

    decimal totalProductOne;
    decimal totalProductTwo;
    decimal totalProductThree; 
    */
    /*
    if (Decimal.TryParse(costTextBoxOne.Text, out decimal decOne) && int.TryParse(qtyLabelOne.Text, out int qtyOne) &&
        Decimal.TryParse(costTextBoxTwo.Text, out decimal decTwo) && int.TryParse(qtyLabelTwo.Text, out int qtyTwo) &&
        Decimal.TryParse(costTextBoxThree.Text, out decimal decThree) && int.TryParse(qtyLabelThree.Text, out int qtyThree) )
    */
    //if ((qtyTextBoxOne.Text != "") && (qtyTextBoxTwo.Text != "") && (qtyTextBoxThree.Text != ""))

    /*
    if (int.TryParse(qtyTextBoxOne.Text, out int qtyOne) && int.TryParse(qtyTextBoxTwo.Text, out int qtyTwo) && int.TryParse(qtyTextBoxThree.Text, out int qtyThree) )
    {
        if (Decimal.TryParse(costTextBoxOne.Text, out decimal costOne))
            totalProductOne = (Convert.ToDecimal(costTextBoxOne.Text) * Convert.ToInt32(qtyTextBoxOne.Text));
        else
            totalProductOne = 0;
        if (Decimal.TryParse(costTextBoxTwo.Text, out decimal costTwo))
            totalProductTwo = (Convert.ToDecimal(costTextBoxTwo.Text) * Convert.ToInt32(qtyTextBoxTwo.Text));
        else
            totalProductTwo = 0;
        if (Decimal.TryParse(costTextBoxThree.Text, out decimal costThree))
            totalProductThree = (Convert.ToDecimal(costTextBoxThree.Text) * Convert.ToInt32(qtyTextBoxThree.Text));
        else
            totalProductThree = 0; 

        int totalQty = Convert.ToInt32(qtyTextBoxOne.Text) + Convert.ToInt32(qtyTextBoxTwo.Text) + Convert.ToInt32(qtyTextBoxThree.Text);

        decimal subTotal = totalProductOne + totalProductTwo + totalProductThree;
        decimal estTax = subTotal * taxRate;
        decimal estShippingCalc = estShipping = 2.99M * totalQty;

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
    
}
*/
    /*
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
    
}
*/
    /*
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
    
}
*/
    /*
private void pictureBox1_Click(object sender, EventArgs e)
{
    SalesForm salesForm = new SalesForm();
    salesForm.Show();
    this.Hide();
}

private void removeButton_Click(object sender, EventArgs e)
{
    object selectedItem = shoppingCartListBox.SelectedItem;
    shoppingCartListBox.Items.Remove(selectedItem);
}
    }
}
*/