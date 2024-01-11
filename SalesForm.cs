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
    public partial class SalesForm : Form
    {
        public static SalesForm instance;
        
        public Label productLabelRefOne;
        public Label costLabelRefOne;

        public Label productLabelRefTwo;
        public Label costLabelRefTwo;

        public Label productLabelRefThree;
        public Label costLabelRefThree;

        public ListBox salesListBoxRef; 

        /*
        public int SalesId { get; internal set; }
        public int CategoryId { get; internal set; }
        public int StatusId { get; internal set; }
        public string SalesName { get; internal set; }
        public string Description { get; internal set; }
        public decimal Price { get; internal set; }
        public Image Image { get; internal set; }
        */

        public SalesForm()
        {
            InitializeComponent();
            instance = this; 
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (salesListBox.Items.Count == 3)
                MessageBox.Show("Error: limit of three items in list");
            else if (salesListBox.Items.Contains(salesProductNameLabelOne.Text))   // string.Format("{0} \t {1}", salesProductNameLabelOne.Text, costLabelOne.Text)
                MessageBox.Show("Error: item already added to shopping list");
            else
                salesListBox.Items.Add(salesProductNameLabelOne.Text);
            //costListLabelOne.Text = costLabelOne.Text; 

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (salesListBox.Items.Count == 3)
                MessageBox.Show("Error: limit of three items in list");
            else if (salesListBox.Items.Contains(salesProductNameLabelTwo.Text))
                MessageBox.Show("Error: item already added to shopping list");
            else
                salesListBox.Items.Add(salesProductNameLabelTwo.Text);
            //costListLabelTwo.Text = costLabelTwo.Text;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (salesListBox.Items.Count == 3)
                MessageBox.Show("Error: limit of three items in list");
            else if (salesListBox.Items.Contains(salesProductNameLabelThree.Text))
                MessageBox.Show("Error: item already added to shopping list");
            else
                salesListBox.Items.Add(salesProductNameLabelThree.Text);
            //costListLabelThree.Text = costLabelThree.Text;
            /*
            ShoppingCart shoppingCartForm = new ShoppingCart();
            shoppingCartForm.Show();
            this.Hide();
            */
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            /*
            ShoppingCart cartForm = new ShoppingCart();
            cartForm.Show();
            this.Hide(); 
            */
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
           
            //______________________________________________________________________________
            //Pet pet = new Pet();
            Sales salesOne = SalesProductsDB.GetById(1);
            Sales salesTwo = SalesProductsDB.GetById(2);
            Sales salesThree = SalesProductsDB.GetById(3);

            BindingSource source = new BindingSource();

            List<Sales> salesList = new List<Sales>();

            try
            {
                salesList.Add(salesOne);
                salesList.Add(salesTwo);
                salesList.Add(salesThree);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            salesDataGridView.DataSource = source;
            source.DataSource = salesList;
            salesDataGridView.DataSource = source;

            this.salesDataGridView.Columns["SalesId"].Visible = false;
            this.salesDataGridView.Columns["StatusId"].Visible = false;
            this.salesDataGridView.Columns["CategoryId"].Visible = false;
            // this.productDataGridView.Columns["BreedId"].Visible = false;
            this.salesDataGridView.Columns["Image"].Visible = false;

            //_______________________________________________________________________________

            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            if (SalesForm.instance.salesListBoxRef != null)
            salesListBox = SalesForm.instance.salesListBoxRef; 

            Sales saleFood = SalesProductsDB.GetById(1); 

            salesProductNameLabelOne.Text = saleFood.SalesName.ToString(); //"Dog Food"; //saleFood.SalesId.ToString() + " " + 
            salesDescLabelOne.Text = saleFood.Description.ToString();
            costLabelOne.Text = saleFood.Price.ToString("0.00");
            FileStream fs = new System.IO.FileStream(saleFood.Image.ToString(), FileMode.Open, FileAccess.Read);
            salesPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage; 
            salesPictureBoxOne.Image = Image.FromStream(fs);
            fs.Close();

            //productPictureBoxOne.Image = Properties.Resources.crate; 
            Sales saleCollar = SalesProductsDB.GetById(2); 

            salesProductNameLabelTwo.Text = saleCollar.SalesName.ToString(); //saleCollar.SalesId.ToString() + " " + 
            salesDescLabelTwo.Text = saleCollar.Description.ToString();
            costLabelTwo.Text = saleCollar.Price.ToString("0.00");
            salesPictureBoxTwo.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs2 = new System.IO.FileStream(saleCollar.Image.ToString(), FileMode.Open, FileAccess.Read);
            salesPictureBoxTwo.Image = Image.FromStream(fs2);
            fs2.Close();

            Sales saleAqua = SalesProductsDB.GetById(3);

            salesProductNameLabelThree.Text = saleAqua.SalesName.ToString(); //saleAqua.SalesId.ToString() + " " + 
            salesDescLabelThree.Text = saleAqua.Description.ToString(); 
            costLabelThree.Text = saleAqua.Price.ToString("0.00");
            salesPictureBoxThree.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs3 = new System.IO.FileStream(saleAqua.Image.ToString(), FileMode.Open, FileAccess.Read);
            salesPictureBoxThree.Image = Image.FromStream(fs3);
            fs3.Close();
            
            if (ShoppingCart.instance != null)
            {
                foreach (object row in ShoppingCart.instance.shoppingCartListBoxRef.Items)
                {
                    foreach (Sales salesProduct in SalesProductsDB.GetAll())
                    if ((row.ToString() == salesProduct.SalesName))
                        salesListBox.Items.Add(row);
                }
            }
            
        }

        private void addShoppingCartList_Click(object sender, EventArgs e)
        {
            if (salesListBox.Items.Count == 0)
            {
                MessageBox.Show("No items selected");
            }

            else
            {
                //browseAllProducts.instance = null;

                salesListBoxRef = salesListBox;

                /*
                productLabelRefOne = productListLabelOne;
                costLabelRefOne = costListLabelOne;
                productLabelRefTwo = productListLabelTwo;
                costLabelRefTwo = costListLabelTwo;
                productLabelRefThree = productListLabelThree;
                costLabelRefThree = costListLabelThree;
                */

                ShoppingCart shoppingCartForm = new ShoppingCart();
                shoppingCartForm.Show();
                this.Hide();
            }
        }

        private void removeButtonOne_Click(object sender, EventArgs e)
        {
            object selectedItem = salesListBox.SelectedItem;
            salesListBox.Items.Remove(selectedItem);
            //productListLabelOne.Text = "";
            //costListLabelOne.Text = ""; 
        }

        private void removeButtonTwo_Click(object sender, EventArgs e)
        {
           // productListLabelTwo.Text = "";
           // costListLabelTwo.Text = "";
        }

        private void removeButtonThree_Click(object sender, EventArgs e)
        {
           // productListLabelThree.Text = "";
            //costListLabelThree.Text = "";
        }

        private void orderByButton_Click(object sender, EventArgs e)
        {
            salesDataGridView.DataSource = null;

            if (salesComboBox.Text == "Alpha Asc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<Sales> salesList = new List<Sales>();

                try
                {
                    salesList = SalesProductsDB.GetAllAlphaAsc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                salesDataGridView.DataSource = source;
                source.DataSource = salesList;
                salesDataGridView.DataSource = source;


                this.salesDataGridView.Columns["SalesId"].Visible = false;
                this.salesDataGridView.Columns["StatusId"].Visible = false;
                this.salesDataGridView.Columns["CategoryId"].Visible = false;
                this.salesDataGridView.Columns["Image"].Visible = false;
            }

            else if (salesComboBox.Text == "Alpha Desc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<Sales> salesList = new List<Sales>();

                try
                {
                    salesList = SalesProductsDB.GetAllAlphaDesc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                salesDataGridView.DataSource = source;
                source.DataSource = salesList;
                salesDataGridView.DataSource = source;


                this.salesDataGridView.Columns["SalesId"].Visible = false;
                this.salesDataGridView.Columns["StatusId"].Visible = false;
                this.salesDataGridView.Columns["CategoryId"].Visible = false;
                this.salesDataGridView.Columns["Image"].Visible = false;
            }

            else if (salesComboBox.Text == "Cost Asc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<Sales> salesList = new List<Sales>();

                try
                {
                    salesList = SalesProductsDB.GetAllPriceAsc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                salesDataGridView.DataSource = source;
                source.DataSource = salesList;
                salesDataGridView.DataSource = source;


                this.salesDataGridView.Columns["SalesId"].Visible = false;
                this.salesDataGridView.Columns["StatusId"].Visible = false;
                this.salesDataGridView.Columns["CategoryId"].Visible = false;
                this.salesDataGridView.Columns["Image"].Visible = false;
            }

            else if (salesComboBox.Text == "Cost Desc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<Sales> salesList = new List<Sales>();

                try
                {
                    salesList = SalesProductsDB.GetAllPriceDesc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                salesDataGridView.DataSource = source;
                source.DataSource = salesList;
                salesDataGridView.DataSource = source;


                this.salesDataGridView.Columns["SalesId"].Visible = false;
                this.salesDataGridView.Columns["StatusId"].Visible = false;
                this.salesDataGridView.Columns["CategoryId"].Visible = false;
                this.salesDataGridView.Columns["Image"].Visible = false;
            }

        }

        private void productSearchButton_Click(object sender, EventArgs e)
        {
            salesDataGridView.DataSource = null;

            if (productSearchComboBox.Text == "Dog")
            {
                Sales salesDogFood = SalesProductsDB.GetById(1);
                Sales salesShockCollar = SalesProductsDB.GetById(2);


                BindingSource source = new BindingSource();

                List<Sales> productList = new List<Sales>();

                try
                {
                    productList.Add(salesDogFood);
                    productList.Add(salesShockCollar);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }


                //salesDataGridView.DataSource = null;
                salesDataGridView.DataSource = source;
                source.DataSource = productList;
                salesDataGridView.DataSource = source;


                this.salesDataGridView.Columns["SalesId"].Visible = false;
                this.salesDataGridView.Columns["StatusId"].Visible = false;
                this.salesDataGridView.Columns["CategoryId"].Visible = false;

                this.salesDataGridView.Columns["Image"].Visible = false;

            }

            else if (productSearchComboBox.Text == "Reptile")
            {
                Sales salesAqua = SalesProductsDB.GetById(3);
                // Sales salesShockCollar = SalesProductsDB.GetById(2);


                BindingSource source = new BindingSource();

                List<Sales> productList = new List<Sales>();

                try
                {
                    productList.Add(salesAqua);
                    //productList.Add(salesShockCollar);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                salesDataGridView.DataSource = source;
                source.DataSource = productList;
                salesDataGridView.DataSource = source;


                this.salesDataGridView.Columns["SalesId"].Visible = false;
                this.salesDataGridView.Columns["StatusId"].Visible = false;
                this.salesDataGridView.Columns["CategoryId"].Visible = false;

                this.salesDataGridView.Columns["Image"].Visible = false;

            }


        }

        private void displayLabel(object sender, DataGridViewCellEventArgs e)
        {
            List<Sales> listProducts = new List<Sales>();

            listProducts = SalesProductsDB.GetAll();
            DataGridViewRow rowSelected = salesDataGridView.Rows[0];

            try
            {
                int i = 0;
                foreach (DataGridViewRow row in salesDataGridView.Rows)
                {
                    i++;
                }
                int totalRows = i;

                for (i = 0; i < totalRows; i++)
                {
                    if (salesDataGridView.Rows[i].Selected == true)
                    {
                        rowSelected = salesDataGridView.Rows[i];
                    }
                }
                Sales productSelected = new Sales();
                productSelected.SalesName = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
                Sales productChosen = SalesProductsDB.GetByName(productSelected.SalesName);

                displaySaleLabel.Text = productChosen.SalesName;
                displayCostLabel.Text = productChosen.Price.ToString();
                displayDescLabel.Text = productChosen.Description;
                //Breed petBreed = BreedDB.GetById(petChosen.PetId);
                //breedSelectedLabel.Text = petBreed.BreedDesc;
                displayPictureLabel.SizeMode = PictureBoxSizeMode.StretchImage;
                if (productChosen.Image.ToString() != "")
                {
                    FileStream fs = new System.IO.FileStream(productChosen.Image.ToString(), FileMode.Open, FileAccess.Read);
                    displayPictureLabel.Image = Image.FromStream(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void displayAddToCartButton_Click(object sender, EventArgs e)
        {
            List<Sales> listProducts = new List<Sales>();

            listProducts = SalesProductsDB.GetAll();
            DataGridViewRow rowSelected = salesDataGridView.Rows[0];

            try
            {
                int i = 0;
                foreach (DataGridViewRow row in salesDataGridView.Rows)
                {
                    i++;
                }
                int totalRows = i;

                for (i = 0; i < totalRows; i++)
                {
                    if (salesDataGridView.Rows[i].Selected == true)
                    {
                        rowSelected = salesDataGridView.Rows[i];
                    }
                }
                Sales productSelected = new Sales();
                productSelected.SalesName = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
                Sales productChosen = SalesProductsDB.GetByName(productSelected.SalesName);

                if (salesListBox.Items.Count == 3)
                    MessageBox.Show("Error: limit of three items in list");
                else if (salesListBox.Items.Contains(displaySaleLabel.Text))
                    MessageBox.Show("Error: item already added to shopping list");
                else
                    salesListBox.Items.Add(displaySaleLabel.Text);

                displaySaleLabel.Text = productChosen.SalesName;
                displayCostLabel.Text = productChosen.Price.ToString();
                displayDescLabel.Text = productChosen.Description;
                //Breed petBreed = BreedDB.GetById(petChosen.PetId);
                //breedSelectedLabel.Text = petBreed.BreedDesc;
                displayPictureLabel.SizeMode = PictureBoxSizeMode.StretchImage;
                if (productChosen.Image.ToString() != "")
                {
                    FileStream fs = new System.IO.FileStream(productChosen.Image.ToString(), FileMode.Open, FileAccess.Read);
                    displayPictureLabel.Image = Image.FromStream(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            salesDataGridView.DataSource = null;

            List<Sales> searchProductsList = new List<Sales>();
            List<Sales> productFoundList = new List<Sales>();
            BindingSource source = new BindingSource();
            searchProductsList = SalesProductsDB.GetAll();

            foreach (Sales product in searchProductsList)
            {
                if (searchTextBox.Text == product.SalesName)
                {
                    //MessageBox.Show(product.Name); 


                    try
                    {
                        // foreach (BrowseProducts productFound in productFoundList)
                        productFoundList.Add(product);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }

            
            salesDataGridView.DataSource = source;
            source.DataSource = productFoundList;
            salesDataGridView.DataSource = source;


            this.salesDataGridView.Columns["SalesId"].Visible = false;
            this.salesDataGridView.Columns["StatusId"].Visible = false;
            this.salesDataGridView.Columns["CategoryId"].Visible = false;

            this.salesDataGridView.Columns["Image"].Visible = false;


        }
    }
}
