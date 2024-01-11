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

namespace Final_Pet_Store_Bernath
{
    public partial class PetShop : Form
    {
        

        public static PetShop instance;

        public Label petTypeLabelRef;
        public TextBox petNameTextBoxRef;
        public TextBox petAgeTextBoxRef;
        public Label costLabelRef;
        //public PictureBox petPictureBoxRef; 

        public PetShop()
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
            // pet one
            Pet petLab = PetDB.GetById(2);
            if (petLab.StatusId == 2)
            {
                MessageBox.Show("Sorry, this pet is no longer available");
            }
            else
            {
                //petLab.StatusId = 2;
                // PetDB.Update(petLab);

                petTypeLabelRef = petTypeLabelOne;
                petNameTextBoxRef = petNameTextBoxOne;
                petAgeTextBoxRef = petAgeTextBoxOne;
                costLabelRef = costLabelOne;

                //petPictureBoxRef = petPicturesBoxOne; 

                getPet getPetForm = new getPet();
                getPetForm.Show();
                this.Hide();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Pet petPoodle = PetDB.GetById(7);
            if (petPoodle.StatusId == 2)
            {
                MessageBox.Show("Sorry, this pet is no longer available");
            }
            else
            {
                //petPoodle.StatusId = 2;
               // PetDB.Update(petPoodle);

                petTypeLabelRef = petTypeLabelTwo;
                petNameTextBoxRef = petNameTextBoxTwo;
                petAgeTextBoxRef = petAgeTextBoxTwo;
                costLabelRef = costLabelTwo;

                getPet getPetForm = new getPet();
                getPetForm.Show();
                this.Hide();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Pet petCat = PetDB.GetById(8);
            if (petCat.StatusId == 2)
            {
                MessageBox.Show("Sorry, this pet is no longer available");
            }
            else
            {
                //petCat.StatusId = 2;
               // PetDB.Update(petCat);

                petTypeLabelRef = petTypeLabelThree;
                petNameTextBoxRef = petNameTextBoxThree;
                petAgeTextBoxRef = petAgeTextBoxThree;
                costLabelRef = costLabelThree;

                getPet getPetForm = new getPet();
                getPetForm.Show();
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

        private void PetShop_Load(object sender, EventArgs e)
        {
            displayPetButton.Hide();

            /* sql db experiment
            Pet petGoldy = PetDB.GetByName("Goldy"); 
            MessageBox.Show(petGoldy.Name + ", " + petGoldy.Price + ", " + petGoldy.Description + ", " + petGoldy.StatusId); 


            end experiment */ 
            //______________________________________________________________________________
            //Pet pet = new Pet();
            Pet petOne = PetDB.FormGetById(2);
            Pet petTwo = PetDB.FormGetById(7);
            Pet petThree = PetDB.FormGetById(8);
            Pet petFour = PetDB.FormGetById(9);
            Pet petFive = PetDB.FormGetById(10);

            BindingSource source = new BindingSource();
            
            List<Pet> petList = new List<Pet>();
            
            try
            {
                petList.Add(petOne);
                petList.Add(petTwo);
                petList.Add(petThree);
                petList.Add(petFour);
                petList.Add(petFive);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
           


            petDataGridView.DataSource = source;
            source.DataSource = petList;
            petDataGridView.DataSource = source;


            this.petDataGridView.Columns["PetId"].Visible = false;
            this.petDataGridView.Columns["StatusId"].Visible = false;
            this.petDataGridView.Columns["CategoryId"].Visible = false;
            this.petDataGridView.Columns["BreedId"].Visible = false;
            this.petDataGridView.Columns["Image"].Visible = false;
            
           

            //_______________________________________________________________________________

            if (MainForm.instance.userTextBoxRef != null)
                userNameLabel.Text = MainForm.instance.userTextBoxRef.Text;

            

            Pet petLab = PetDB.GetById(2);
            int breedId = petLab.BreedId;
            Breed breedLab = BreedDB.GetById(breedId);
            //Profile profile = ProfileDB.GetById(userId);

            petTypeLabelOne.Text = petLab.Name.ToString();
            petNameTextBoxOne.Text = breedLab.BreedDesc.ToString();
            petAgeTextBoxOne.Text = "4";
            petDescLabelOne.Text = petLab.Description.ToString();
            costLabelOne.Text = petLab.Price.ToString();
            petPictureBoxOne.SizeMode = PictureBoxSizeMode.StretchImage; 
            FileStream fs = new System.IO.FileStream(petLab.Image.ToString(), FileMode.Open, FileAccess.Read);
            petPictureBoxOne.Image = Image.FromStream(fs);
            fs.Close();

            Pet petPoodle = PetDB.GetById(7);
            int breedIdTwo = petPoodle.BreedId;
            Breed breedPoodle = BreedDB.GetById(breedIdTwo);

            petTypeLabelTwo.Text = petPoodle.Name.ToString(); 
            petNameTextBoxTwo.Text = breedPoodle.BreedDesc.ToString();
            petAgeTextBoxTwo.Text = "2";
            petDescLabelTwo.Text = petPoodle.Description.ToString();
            costLabelTwo.Text = petPoodle.Price.ToString();
            petPictureBoxTwo.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs2 = new System.IO.FileStream(petPoodle.Image.ToString(), FileMode.Open, FileAccess.Read);
            petPictureBoxTwo.Image = Image.FromStream(fs2);
            fs2.Close();

            Pet petCat = PetDB.GetById(8);
            int breedIdThree = petCat.BreedId;
            Breed breedCat = BreedDB.GetById(breedIdThree);

            petTypeLabelThree.Text = petCat.Name.ToString();
            petNameTextBoxThree.Text = breedCat.BreedDesc.ToString();
            petAgeTextBoxThree.Text = "5";
            petDescLabelThree.Text = petCat.Description.ToString();
            costLabelThree.Text = petCat.Price.ToString();
            petPictureBoxThree.SizeMode = PictureBoxSizeMode.StretchImage;
            FileStream fs3 = new System.IO.FileStream(petCat.Image.ToString(), FileMode.Open, FileAccess.Read);
            petPictureBoxThree.Image = Image.FromStream(fs3);
            fs3.Close();

            Pet petLizard = PetDB.GetById(9);
            int breedIdFour = petLizard.BreedId;
            Breed breedLizard = BreedDB.GetById(breedIdFour);

            petTypeLabelFour.Text = petLizard.Name.ToString();
            petNameTextBoxFour.Text = breedLizard.BreedDesc.ToString();
            petAgeTextBoxFour.Text = "1";
            petDescLabelFour.Text = petLizard.Description.ToString();
            petPictureBoxFour.SizeMode = PictureBoxSizeMode.StretchImage;
            costLabelFour.Text = petLizard.Price.ToString();
            FileStream fs4 = new System.IO.FileStream(@petLizard.Image.ToString(), FileMode.Open, FileAccess.Read);
            petPictureBoxFour.Image = Image.FromStream(fs4);
            fs4.Close();

            Pet petHamster = PetDB.GetById(10);
            int breedIdFive = petHamster.BreedId;
            Breed breedHamster = BreedDB.GetById(breedIdFive);

            petTypeLabelFive.Text = petHamster.Name.ToString();
            petNameTextBoxFive.Text = breedHamster.BreedDesc.ToString();
            petAgeTextBoxFive.Text = "2";
            petDescLabelFive.Text = petHamster.Description.ToString();
            petPictureBoxFive.SizeMode = PictureBoxSizeMode.StretchImage;
            costLabelFive.Text = petHamster.Price.ToString();
            FileStream fs5 = new System.IO.FileStream(petHamster.Image.ToString(), FileMode.Open, FileAccess.Read);
            petPictureBoxFive.Image = Image.FromStream(fs5);
            fs5.Close();
        }

        private void getPetButtonFour_Click(object sender, EventArgs e)
        {
            Pet petLizard = PetDB.GetById(9);
            if (petLizard.StatusId == 2)
            {
                MessageBox.Show("Sorry, this pet is no longer available");
            }
            else
            {
                //petLizard.StatusId = 2;
                //PetDB.Update(petLizard);

                petTypeLabelRef = petTypeLabelFour;
                petNameTextBoxRef = petNameTextBoxFour;
                petAgeTextBoxRef = petAgeTextBoxFour;
                costLabelRef = costLabelFour;

                getPet getPetForm = new getPet();
                getPetForm.Show();
                this.Hide();
            }
        }

        private void getPetButtonFive_Click(object sender, EventArgs e)
        {
            Pet petHamster = PetDB.GetById(10);
            if (petHamster.StatusId == 2)
            {
                MessageBox.Show("Sorry, this pet is no longer available");
            }
            else
            {
                //petHamster.StatusId = 2;
                //PetDB.Update(petHamster);

                petTypeLabelRef = petTypeLabelFive;
                petNameTextBoxRef = petNameTextBoxFive;
                petAgeTextBoxRef = petAgeTextBoxFive;
                costLabelRef = costLabelFive;

                getPet getPetForm = new getPet();
                getPetForm.Show();
                this.Hide();
            }
        }

        private void orderByButton_Click(object sender, EventArgs e)
        {
            petDataGridView.DataSource = null;

            if (petComboBox.Text == "Alpha Asc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();


                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList = PetDB.GetAllAlphaAsc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;
            }


                //_______________________________________________________________________________

            else if (petComboBox.Text == "Alpha Desc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();

                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList = PetDB.GetAllAlphaDesc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



                //_______________________________________________________________________________
            }

            else if (petComboBox.Text == "Cost Asc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();

                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList = PetDB.GetAllCostAsc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



                //_______________________________________________________________________________
            }

            else if (petComboBox.Text == "Cost Desc")
            {
                //______________________________________________________________________________
                //Pet pet = new Pet();

                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList = PetDB.GetAllCostDesc();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



                //_______________________________________________________________________________
            }
        }

        private void searchPetButton_Click(object sender, EventArgs e)
        {
            petDataGridView.DataSource = null;

            if (petSearchComboBox.Text == "Dog")
            {
                Pet petDog = PetDB.GetByName("Goldy");
                Pet petDogTwo = PetDB.GetByName("Curly");


                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList.Add(petDog);
                    petList.Add(petDogTwo);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



            }

            else if (petSearchComboBox.Text == "Cat")
            {
                Pet pet = PetDB.GetByName("Tiger");


                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList.Add(pet);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



            }

            else if (petSearchComboBox.Text == "Reptile")
            {
                Pet pet = PetDB.GetByName("Gecko");


                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList.Add(pet);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



            }

            else if (petSearchComboBox.Text == "Rodent")
            {
                Pet pet = PetDB.GetByName("Huey");


                BindingSource source = new BindingSource();

                List<Pet> petList = new List<Pet>();

                try
                {
                    petList.Add(pet);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }



                petDataGridView.DataSource = source;
                source.DataSource = petList;
                petDataGridView.DataSource = source;


                this.petDataGridView.Columns["PetId"].Visible = false;
                this.petDataGridView.Columns["StatusId"].Visible = false;
                this.petDataGridView.Columns["CategoryId"].Visible = false;
                this.petDataGridView.Columns["BreedId"].Visible = false;
                this.petDataGridView.Columns["Image"].Visible = false;



            }

        }

        private void displayPetButton_Click(object sender, EventArgs e)
        {
            List<Pet> listPets = new List<Pet>();

            listPets = PetDB.GetAll();
            DataGridViewRow rowSelected = petDataGridView.Rows[0];

            try
            {
                int i = 0;
                foreach (DataGridViewRow row in petDataGridView.Rows)
                {
                    i++;
                }
                int totalRows = i;

                for (i = 0; i < totalRows; i++)
                {
                    if (petDataGridView.Rows[i].Selected == true)
                    {
                        rowSelected = petDataGridView.Rows[i];
                    }
                }
                Pet petSelected = new Pet();
                petSelected.Name = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
                Pet petChosen = PetDB.GetByName(petSelected.Name);

                nameSelectedLabel.Text = petChosen.Name;
                costSelectedLabel.Text = petChosen.Price.ToString();
                descSelectedLabel.Text = petChosen.Description;
                Breed petBreed = BreedDB.GetById(petChosen.PetId);
                breedSelectedLabel.Text = petBreed.BreedDesc;
                pictureSelectedLabel.SizeMode = PictureBoxSizeMode.StretchImage;
                if (petChosen.Image.ToString() != "")
                { 
                FileStream fs = new System.IO.FileStream(petChosen.Image.ToString(), FileMode.Open, FileAccess.Read);
                pictureSelectedLabel.Image = Image.FromStream(fs);
                fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }

        }

        private void petdisplayPetButton_Click(object sender, DataGridViewCellEventArgs e)
        {
            List<Pet> listPets = new List<Pet>();

            listPets = PetDB.GetAll();
            DataGridViewRow rowSelected = petDataGridView.Rows[0];

            int i = 0;
            foreach (DataGridViewRow row in petDataGridView.Rows)
            {
                if (petDataGridView.Rows[i].Selected == true)
                {
                    rowSelected = petDataGridView.Rows[i];
                    
                }
                i++; 
            }
            Pet petSelected = new Pet();
            petSelected.Name = rowSelected.Cells[0].Value.ToString();    // Field<DataGridViewRow>("Name").ToString();
            Pet petChosen = PetDB.GetByName(petSelected.Name);

            nameSelectedLabel.Text = petChosen.Name;
            costSelectedLabel.Text = petChosen.Price.ToString();
            descSelectedLabel.Text = petChosen.Description;
            Breed petBreed = BreedDB.GetById(petChosen.PetId);
            breedSelectedLabel.Text = petBreed.BreedDesc;
            pictureSelectedLabel.SizeMode = PictureBoxSizeMode.StretchImage;
            if (petChosen.Image.ToString() != "")
            {
                FileStream fs = new System.IO.FileStream(petChosen.Image.ToString(), FileMode.Open, FileAccess.Read);
                pictureSelectedLabel.Image = Image.FromStream(fs);
                fs.Close();
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            petDataGridView.DataSource = null;

            List<Pet> searchProductsList = new List<Pet>();
            List<Pet> petFoundList = new List<Pet>();
            BindingSource source = new BindingSource();
            searchProductsList = PetDB.GetAll();

            foreach (Pet petSearch in searchProductsList)
            {
                //MessageBox.Show(petSearch.Name); 
                if (searchTextBox.Text == petSearch.Name)
                {
                    //MessageBox.Show(product.Name); 


                    try
                    {
                        // foreach (BrowseProducts productFound in productFoundList)
                        petFoundList.Add(petSearch);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }

            List<Breed> searchBreedsList = new List<Breed>();
            //List<Pet> petFoundList = new List<Pet>();

            
            Breed searchBreeds = BreedDB.GetByDesc(searchTextBox.Text);
            //MessageBox.Show(searchBreeds.BreedDesc);
            // something weird is going on with this BreedDB.GetAll() where it isn't loading any records at all from the db.
            //searchBreedsList = BreedDB.GetAll();
            //int totalBreeds = searchBreedsList.Count;
            //MessageBox.Show(totalBreeds.ToString()); // this returns 0 even though it shouldn't

           // I can only return one of each type of breed because the BreedDB.GetAll() statement doesn't execute properly 
            if (searchBreeds !=  null)
            {
                //Pet petFound = new Pet(); 
                //MessageBox.Show(product.Name); 
                Pet petFound = PetDB.GetByBreedId(searchBreeds.BreedId);
                //MessageBox.Show(petFound.Name); 

                try
                {
                    // foreach (BrowseProducts productFound in productFoundList)
                    petFoundList.Add(petFound);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }

             /* None of this works for some reason mainly because BreedDB.GetAll() returns 0 count to a list.  
            List<Breed> searchBreedsList = new List<Breed>();
            
            searchBreedsList = BreedDB.GetAll();
            //MessageBox.Show(searchBreeds.BreedDesc);
            // something weird is going on with this BreedDB.GetAll() where it isn't loading any records at all from the db.
            //searchBreedsList = BreedDB.GetAll();
            //int totalBreeds = searchBreedsList.Count;
            //MessageBox.Show(totalBreeds.ToString()); // this returns 0 even though it shouldn't

           // I can only return one of each type of breed because the BreedDB.GetAll() statement doesn't execute properly 
           foreach (Breed searchBreeds in searchBreedsList)
            {
                if (searchTextBox.Text == searchBreeds.BreedDesc)
                {
                    //Pet petFound = new Pet(); 
                    //MessageBox.Show(product.Name); 
                     Pet petFound = PetDB.GetByBreedId(searchBreeds.BreedId);
                    //MessageBox.Show(petFound.Name); 

                    try
                    {
                        // foreach (BrowseProducts productFound in productFoundList)
                        petFoundList.Add(petFound);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
            */


            petDataGridView.DataSource = source;
            source.DataSource = petFoundList;
            petDataGridView.DataSource = source;


            this.petDataGridView.Columns["PetId"].Visible = false;
            this.petDataGridView.Columns["StatusId"].Visible = false;
            this.petDataGridView.Columns["CategoryId"].Visible = false;
            this.petDataGridView.Columns["BreedId"].Visible = false;
            this.petDataGridView.Columns["Image"].Visible = false;


        }
    }

        /*
        private void deleteGrid_Click(object sender, EventArgs e)
        {
            
        }
        */

        }
