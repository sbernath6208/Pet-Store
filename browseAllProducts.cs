using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SkiaSharp;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;
using DataAccessLayer.DBObjects;
using System.IO;
using Final_Pet_Store_Bernath.DataAccessLayer.DBObjects;
using Final_Pet_Store_Bernath.DataAccessLayer.BussinessObjects;

namespace Final_Pet_Store_Bernath
{
    public partial class browseAllProducts : Form
    {
        

        public static browseAllProducts instance;

        public Label productLabelRefOne;
        public Label costLabelRefOne;

        public Label productLabelRefTwo;
        public Label costLabelRefTwo;

        public Label productLabelRefThree;
        public Label costLabelRefThree;
        public ListBox browseListBoxRef;

        public String browseProductOneIdRef;
        public String browseProductOneTypeRef; 

        public browseAllProducts()
        {
            InitializeComponent();
            instance = this; 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();
            menuForm.Show();
            this.Hide(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (browseListBox.Items.Count == 3)
                MessageBox.Show("Error: limit of three items in list"); 
            else if (browseListBox.Items.Contains(productLabelOne.Text))
                MessageBox.Show("Error: item already added to shopping list");
            else
            {
                browseListBox.Items.Add(productLabelOne.Text);   // string.Format("{0} \t\t {1}", productLabelOne.Text, costLabelOne.Text

            }
            //costListLabelOne.Text = costLabelOne.Text; 

            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (browseListBox.Items.Count == 3)
                MessageBox.Show("Error: limit of three items in list");
            else if (browseListBox.Items.Contains(productLabelTwo.Text))
                MessageBox.Show("Error: item already added to shopping list");
            else
                browseListBox.Items.Add(productLabelTwo.Text);
            //costListLabelTwo.Text = costLabelTwo.Text;
        }
        
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (browseListBox.Items.Count == 3)
                MessageBox.Show("Error: limit of three items in list");
            else if (browseListBox.Items.Contains(productLabelThree.Text))
                MessageBox.Show("Error: item already added to shopping list");
            else
                browseListBox.Items.Add(productLabelThree.Text);
            //costListLabelThree.Text = costLabelThree.Text;
        }

        private void shoppingCartButton_Click(object sender, EventArgs e)
        {
            /*
            ShoppingCart shoppingCartForm = new ShoppingCart();
            shoppingCartForm.Show();
            this.Hide(); 
            */
        }

        private void browseAllProducts_Load(object sender, EventArgs e)
        {
            displayButton.Hide(); 
            //______________________________________________________________________________
            //Pet pet = new Pet();
            BrowseProducts productOne = BrowseProductsDB.GetById(1);
            BrowseProducts productTwo = BrowseProductsDB.GetById(2);
            BrowseProducts productThree = BrowseProductsDB.GetById(3);

            BindingSource source = new BindingSource();

            List<BrowseProducts> productList = new List<BrowseProducts>();

            try
            {
                productList.Add(productOne);
                productList.Add(productTwo);
                productList.Add(productThree);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            productDataGridView.DataSource = source;
            source.DataSource = productList;
            productDataGridView.DataSource = source;


            this.productDataGridView.Columns["ProductId"].Visible = false;
            this.productDataGridView.Columns["StatusId"].Visible = false;
            this.productDataGridView.Columns["CategoryId"].Visible = false;
            // this.productDataGridView.Columns["BreedId"].Visible = false;
            this.productDataGridView.Columns["Image"].Visible = false;
            //_______________________________________________________________________________


            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            if (browseAllProducts.instance.browseListBoxRef != null)
                browseListBox = browseAllProducts.instance.browseListBoxRef;

            BrowseProducts browseCrate = BrowseProductsDB.GetById(1); 

            productLabelOne.Text = browseCrate.Name.ToString(); //browseCrate.ProductId.ToString() + " " + 
            productDescLabelOne.Text = browseCrate.Description.ToString();
            costLabelOne.Text = browseCrate.Price.ToString("0.00");
            productPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage; 
            FileStream fs = new System.IO.FileStream(browseCrate.Image.ToString(), FileMode.Open, FileAccess.Read);
            productPictureBoxOne.Image = Image.FromStream(fs);
            fs.Close();
            //productPictureBoxOne.Image = Properties.Resources.crate; 

            BrowseProducts browseLeash = BrowseProductsDB.GetById(2);

            productLabelTwo.Text = browseLeash.Name.ToString(); // browseLeash.ProductId.ToString() + " " + 
            productDescLabelTwo.Text = browseLeash.Description.ToString();
            costLabelTwo.Text = browseLeash.Price.ToString("0.00");
            productPictureBoxTwo.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs2 = new System.IO.FileStream(browseLeash.Image.ToString(), FileMode.Open, FileAccess.Read);
            productPictureBoxTwo.Image = Image.FromStream(fs2);
            fs2.Close();

            BrowseProducts browseTreats = BrowseProductsDB.GetById(3);

            productLabelThree.Text = browseTreats.Name.ToString(); //browseTreats.ProductId.ToString() + " " + 
            productDescLabelThree.Text = browseTreats.Description.ToString();
            costLabelThree.Text = browseTreats.Price.ToString("0.00");
            productPictureBoxThree.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs3 = new System.IO.FileStream(browseTreats.Image.ToString(), FileMode.Open, FileAccess.Read);
            productPictureBoxThree.Image = Image.FromStream(fs3);
            fs3.Close();
            
            if (ShoppingCart.instance != null)
            {
                foreach (object row in ShoppingCart.instance.shoppingCartListBoxRef.Items)
                {
                    foreach (BrowseProducts product in BrowseProductsDB.GetAll())
                        if (row.ToString() == product.Name)
                             browseListBox.Items.Add(row);
                }
            }
            
        }

        private void addShoppingCartList_Click(object sender, EventArgs e)
        {
            if (browseListBox.Items.Count == 0)
            {
                MessageBox.Show("No items selected");
            }

            else
            {
                //SalesForm.instance = null;

                //browseAllProducts.instance.browseListBoxRef; 

                //productLabelRefOne = productListLabelOne;
                //costLabelRefOne = costListLabelOne;
                //productLabelRefTwo = productListLabelTwo;
                //costLabelRefTwo = costListLabelTwo;
                //productLabelRefThree = productListLabelThree;
                //costLabelRefThree = costListLabelThree;
                browseListBoxRef = browseListBox;

                ShoppingCart shoppingCartForm = new ShoppingCart();
                shoppingCartForm.Show();
                this.Hide();
            }
        }

        private void removeButtonOne_Click(object sender, EventArgs e)
        {
            object selectedItem = browseListBox.SelectedItem; 
            browseListBox.Items.Remove(selectedItem); 
            //productListLabelOne.Text = "";
            //costListLabelOne.Text = ""; 
        }

        private void removeButtonTwo_Click(object sender, EventArgs e)
        {
            //productListLabelTwo.Text = "";
            //costListLabelTwo.Text = "";
        }

        private void removeButtonThree_Click(object sender, EventArgs e)
        {
            //productListLabelThree.Text = "";
            //costListLabelThree.Text = "";
        }

        private void orderByButton_Click(object sender, EventArgs e)
        {
            productDataGridView.DataSource = null;

            if (productComboBox.Text == "Alpha Asc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<BrowseProducts> productList = new List<BrowseProducts>();

                try
                {
                    productList = BrowseProductsDB.GetAllAlphaAsc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                productDataGridView.DataSource = source;
                source.DataSource = productList;
                productDataGridView.DataSource = source;


                this.productDataGridView.Columns["ProductId"].Visible = false;
                this.productDataGridView.Columns["StatusId"].Visible = false;
                this.productDataGridView.Columns["CategoryId"].Visible = false;
               
                this.productDataGridView.Columns["Image"].Visible = false;
            }

            else if (productComboBox.Text == "Alpha Desc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<BrowseProducts> productList = new List<BrowseProducts>();

                try
                {
                    productList = BrowseProductsDB.GetAllAlphaDesc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                productDataGridView.DataSource = source;
                source.DataSource = productList;
                productDataGridView.DataSource = source;


                this.productDataGridView.Columns["ProductId"].Visible = false;
                this.productDataGridView.Columns["StatusId"].Visible = false;
                this.productDataGridView.Columns["CategoryId"].Visible = false;

                this.productDataGridView.Columns["Image"].Visible = false;
            }

            else if (productComboBox.Text == "Cost Asc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<BrowseProducts> productList = new List<BrowseProducts>();

                try
                {
                    productList = BrowseProductsDB.GetAllPriceAsc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                productDataGridView.DataSource = source;
                source.DataSource = productList;
                productDataGridView.DataSource = source;


                this.productDataGridView.Columns["ProductId"].Visible = false;
                this.productDataGridView.Columns["StatusId"].Visible = false;
                this.productDataGridView.Columns["CategoryId"].Visible = false;

                this.productDataGridView.Columns["Image"].Visible = false;
            }

            else if (productComboBox.Text == "Cost Desc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<BrowseProducts> productList = new List<BrowseProducts>();

                try
                {
                    productList = BrowseProductsDB.GetAllPriceDesc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                productDataGridView.DataSource = source;
                source.DataSource = productList;
                productDataGridView.DataSource = source;


                this.productDataGridView.Columns["ProductId"].Visible = false;
                this.productDataGridView.Columns["StatusId"].Visible = false;
                this.productDataGridView.Columns["CategoryId"].Visible = false;

                this.productDataGridView.Columns["Image"].Visible = false;
            }

        }

        private void searchProductButton_Click(object sender, EventArgs e)
        {
            productDataGridView.DataSource = null;

            if (petTypeComboBox.Text == "Dog")
            {
                BrowseProducts productCrate = BrowseProductsDB.GetById(1);
                BrowseProducts productLeash = BrowseProductsDB.GetById(2);


                BindingSource source = new BindingSource();

                List<BrowseProducts> productList = new List<BrowseProducts>();

                try
                {
                    productList.Add(productCrate);
                    productList.Add(productLeash);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                productDataGridView.DataSource = source;
                source.DataSource = productList;
                productDataGridView.DataSource = source;


                this.productDataGridView.Columns["ProductId"].Visible = false;
                this.productDataGridView.Columns["StatusId"].Visible = false;
                this.productDataGridView.Columns["CategoryId"].Visible = false;
              
                this.productDataGridView.Columns["Image"].Visible = false;

            }

            else
            if (petTypeComboBox.Text == "Cat")
            {
                BrowseProducts productKittyTreats = BrowseProductsDB.GetById(3);
               // BrowseProducts productLeash = BrowseProductsDB.GetById(2);


                BindingSource source = new BindingSource();

                List<BrowseProducts> productList = new List<BrowseProducts>();

                try
                {
                    productList.Add(productKittyTreats);
                   // productList.Add(productLeash);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                productDataGridView.DataSource = source;
                source.DataSource = productList;
                productDataGridView.DataSource = source;


                this.productDataGridView.Columns["ProductId"].Visible = false;
                this.productDataGridView.Columns["StatusId"].Visible = false;
                this.productDataGridView.Columns["CategoryId"].Visible = false;
        
                this.productDataGridView.Columns["Image"].Visible = false;

            }

            else if (petTypeComboBox.Text == "Reptile")
            {
                productDataGridView.DataSource = null;
            }

            else if (petTypeComboBox.Text == "Rodent")
            {
                productDataGridView.DataSource = null;
            }

        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            List<BrowseProducts> listProducts = new List<BrowseProducts>();

            listProducts = BrowseProductsDB.GetAll();
            DataGridViewRow rowSelected = productDataGridView.Rows[0];

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if (productDataGridView.Rows[i].Selected == true)
                    {
                        rowSelected = productDataGridView.Rows[i];
                    }
                }
                BrowseProducts productSelected = new BrowseProducts();
                productSelected.Name = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
                BrowseProducts productChosen = BrowseProductsDB.GetByName(productSelected.Name);

                displayProductLabel.Text = productChosen.Name;
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

        private void displayClick(object sender, DataGridViewCellEventArgs e)
        {
            List<BrowseProducts> listProducts = new List<BrowseProducts>();

            listProducts = BrowseProductsDB.GetAll();
            DataGridViewRow rowSelected = productDataGridView.Rows[0];

            try
            {
                int i = 0;
                foreach (DataGridViewRow row in productDataGridView.Rows)
                {
                    i++;
                }
                int totalRows = i;

                for (i = 0; i < totalRows; i++)
                {
                    if (productDataGridView.Rows[i].Selected == true)
                    {
                        rowSelected = productDataGridView.Rows[i];
                    }
                }
                BrowseProducts productSelected = new BrowseProducts();
                productSelected.Name = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
                BrowseProducts productChosen = BrowseProductsDB.GetByName(productSelected.Name);

                displayProductLabel.Text = productChosen.Name;
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

            List<BrowseProducts> listProducts = new List<BrowseProducts>();

            listProducts = BrowseProductsDB.GetAll();
            DataGridViewRow rowSelected = productDataGridView.Rows[0];

            try
            {
                int i = 0;
                foreach (DataGridViewRow row in productDataGridView.Rows)
                {
                    i++;
                }
                int totalRows = i;

                for (i = 0; i < totalRows; i++)
                {
                    if (productDataGridView.Rows[i].Selected == true)
                    {
                        rowSelected = productDataGridView.Rows[i];
                    }
                }
                BrowseProducts productSelected = new BrowseProducts();
                productSelected.Name = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
                BrowseProducts productChosen = BrowseProductsDB.GetByName(productSelected.Name);

                if (browseListBox.Items.Count == 3)
                    MessageBox.Show("Error: limit of three items in list");
                else if (browseListBox.Items.Contains(displayProductLabel.Text))
                    MessageBox.Show("Error: item already added to shopping list");
                else
                    browseListBox.Items.Add(displayProductLabel.Text);

                displayProductLabel.Text = productChosen.Name;
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

        private void searchSiteButton_Click(object sender, EventArgs e)
        {
            productDataGridView.DataSource = null;

            List<BrowseProducts> searchProductsList = new List<BrowseProducts>();
            List<BrowseProducts> productFoundList = new List<BrowseProducts>();
            BindingSource source = new BindingSource();
            searchProductsList = BrowseProductsDB.GetAll();

            foreach (BrowseProducts product in searchProductsList)
            {
                if (searchTextBox.Text == product.Name)
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

            productDataGridView.DataSource = source;
            source.DataSource = productFoundList;
            productDataGridView.DataSource = source;


            this.productDataGridView.Columns["ProductId"].Visible = false;
            this.productDataGridView.Columns["StatusId"].Visible = false;
            this.productDataGridView.Columns["CategoryId"].Visible = false;

            this.productDataGridView.Columns["Image"].Visible = false;

            
        }
    }
}
