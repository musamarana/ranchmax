using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace Ranch_Max
{
    public partial class Animal_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateAnimals();
                populateGridView();
                
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvAnimal.DataSource = db.Animals.ToList<Animal>();
                gvAnimal.DataBind();

            }

        }


        //FUNCTION TO POPULATE  Animal  

        private void PopulateAnimals()
        {
            List<Animal> allAnimals = null;
            using (Entities db = new Entities())
            {
                var cons = (from a in db.Animals
                             
                            select new
                            {
                                a,
                                 

                            });
                if (cons != null)
                {
                    allAnimals = new List<Animal>();
                    foreach (var i in cons)
                    {
                        Animal c = i.a;
                         
                        allAnimals.Add(c);

                    }

                }
                else
                {
                    gvAnimal.DataSource = allAnimals;
                    gvAnimal.DataBind();
                }

            }
        }

        //function to fetch Formula name from  database
        private List<FeedFormula> PopulateFeedFormula()
        {
            using (Entities db = new Entities())
            {
                return db.FeedFormulas.OrderBy(a => a.FormulaName).ToList();
            }
        }

        //function to fetch User from  database
        private List<AspNetUser> PopulateAspNetUser()
        {
            using (Entities db = new Entities())
            {
                return db.AspNetUsers.OrderBy(a => a.UserName).ToList();
            }
        }

        //function to fetch Animal Breed from  database
        private List<AnimalBreed> PopulateAnimalBreed()

        {
            using (Entities db = new Entities())
            {
                return db.AnimalBreeds.OrderBy(a => a.Breed).ToList();
            }
        }

  
        //function to bind Animal breed to dropdownlist

        private void BindAnimalBreed(DropDownList ddBreed, List<AnimalBreed> breed)
        {
            ddBreed.Items.Clear();
            ddBreed.Items.Add(new ListItem { Text = "Select Breed", Value = "0" });
            ddBreed.AppendDataBoundItems = true;
            ddBreed.DataValueField = "Breed_Id";
            ddBreed.DataTextField = "Breed";
            ddBreed.DataSource = breed;
            ddBreed.DataBind();

        }



        protected void gvAnimal_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAnimal.EditIndex = -1;
            PopulateAnimals();
            populateGridView();


        }

         
        protected void gvAnimal_RowEditing(object sender, GridViewEditEventArgs e)
        {
             string Breed_Id = gvAnimal.DataKeys[e.NewEditIndex]["Breed_Id"].ToString();
             gvAnimal.EditIndex = e.NewEditIndex;
            PopulateAnimalBreed();
            populateGridView();
             DropDownList ddBreed = (DropDownList)gvAnimal.Rows[e.NewEditIndex].FindControl("ddBreed");
 
            if ( ddBreed != null )
            {
                 BindAnimalBreed(ddBreed, PopulateAnimalBreed());
                ddBreed.SelectedValue = Breed_Id;
             }


             
        }

        protected void gvAnimal_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Animal_Id = (int)gvAnimal.DataKeys[e.RowIndex]["Animal_Id"];
             TextBox txtETag = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtETag");
            DropDownList ddCat = (DropDownList)gvAnimal.Rows[e.RowIndex].FindControl("ddCat");
            DropDownList ddCountry = (DropDownList)gvAnimal.Rows[e.RowIndex].FindControl("ddCountry");
            DropDownList ddGender = (DropDownList)gvAnimal.Rows[e.RowIndex].FindControl("ddGender");
            DropDownList ddStatus = (DropDownList)gvAnimal.Rows[e.RowIndex].FindControl("ddStatus");
            DropDownList ddBreed = (DropDownList)gvAnimal.Rows[e.RowIndex].FindControl("ddBreed");
            TextBox txtLact = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtLact");
            TextBox txtSire = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtSire");
            TextBox txtIDate = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtIDate");
            TextBox txtBDate = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtBDate");
            TextBox txtWeight = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtWeight");
            TextBox txtAge = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtAge");
            TextBox txtPrice = (TextBox)gvAnimal.Rows[e.RowIndex].FindControl("txtPrice");



            using (Entities db = new Entities())
            {
                var v = db.Animals.Where(a => a.Animal_Id == Animal_Id).FirstOrDefault();


                if (v != null)
                {
                    v.EarTag = int.Parse(txtETag.Text);
                    v.Category = ddCat.SelectedValue;
                    v.OriginCountry = ddCountry.SelectedValue;
                    v.Gender = ddGender.SelectedValue;
                    v.Status = ddStatus.SelectedValue;
                    v.Breed_Id = int.Parse(ddBreed.SelectedValue);

                    if (txtIDate.Text != "")
                    {
                        string dateString = txtIDate.Text;
                        v.InsertionDate = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        //v.InsertionDate = DateTime.Parse(txtIDate.Text);
                    }
                    else
                    {
                        v.InsertionDate = null;
                    }
                    if (txtSire.Text != "")
                    {
                        v.Sire = int.Parse(txtSire.Text);

                    }
                    else
                    {
                        v.Sire = null;

                    }
                    if (txtAge.Text != "")
                    {
                        v.Age = int.Parse(txtAge.Text);

                    }
                    else
                    {
                      v.Age = null;
                     }
                    if (txtWeight.Text != "")
                    {
                        v.Weight = int.Parse(txtWeight.Text);

                    }
                    else
                    {
                        v.Weight = null;

                    }
                    if (txtPrice.Text != "")
                    {
                        v.Price = int.Parse(txtPrice.Text);

                    }
                    else
                    {
                        v.Price = null;

                    }

                    if (txtBDate.Text != "")
                    {
                        string dateString1 = txtBDate.Text;
                        v.Birthdate = Convert.ToDateTime(dateString1,
                            System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        //v.Birthdate = DateTime.Parse(txtBDate.Text) ;

                    }
                    else
                    {
                        v.Birthdate = null;

                    }
                    if (txtLact.Text != "")
                    {
                        v.Lactation = int.Parse(txtLact.Text);

                    }
                    else
                    {
                        v.Lactation = null;

                    }

                }

                db.SaveChanges();
                gvAnimal.EditIndex = -1;
                 PopulateAnimals();
                populateGridView();
            }

        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "EarTag")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.Animals.ToList<Animal>();
                    ddSearchItems.DataTextField = "EarTag";
                    ddSearchItems.DataValueField = "EarTag";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");



                }

                else if (ddSearch.Text == "Breed")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.AnimalBreeds.ToList<AnimalBreed>();
                    ddSearchItems.DataTextField = "Breed";
                    ddSearchItems.DataValueField = "Breed_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");


                }
                else if (ddSearch.Text == "Gender")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.Animals.ToList<Animal>();
                    ddSearchItems.DataTextField = "Gender";
                    ddSearchItems.DataValueField = "Gender";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");


                }


            }

        }
        [Obsolete]
        protected void ddSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {



                if (ddSearch.Text == "EarTag")
                {

                    string tag = ddSearchItems.SelectedValue;
                    var form = from c in db.Animals
                               where c.EarTag.ToString() == tag
                               select new
                               {
                                   c.EarTag,
                                   c.Category,
                                   c.OriginCountry,
                                   c.Gender,
                                   c.AnimalBreed.Breed,
                                   c.Status,
                                   c.Lactation,
                                   c.Sire,
                                   c.InsertionDate,
                                   c.Birthdate,
                                   c.Weight,
                                   c.Age,
                                   c.Price
                               };
                    gvAni.DataSource = form.ToList();
                    gvAni.DataBind();



                }

                if (ddSearch.Text == "Breed")
                {

                    string breed = ddSearchItems.SelectedValue;
                    var form2 = from c in db.Animals
                               where c.Breed_Id.ToString() == breed
                               select new
                               {
                                   c.EarTag,
                                   c.Category,
                                   c.OriginCountry,
                                   c.Gender,
                                   c.AnimalBreed.Breed,
                                   c.Status,
                                   c.Lactation,
                                   c.Sire,
                                   c.InsertionDate,
                                   c.Birthdate,
                                   c.Weight,
                                   c.Age,
                                   c.Price
                               };
                    gvAni.DataSource = form2.ToList();
                    gvAni.DataBind();



                }
                if (ddSearch.Text == "Gender")
                {

                    string gender = ddSearchItems.SelectedValue;
                    var form3 = from c in db.Animals
                                where c.Gender == gender
                                select new
                                {
                                    c.EarTag,
                                    c.Category,
                                    c.OriginCountry,
                                    c.Gender,
                                    c.AnimalBreed.Breed,
                                    c.Status,
                                    c.Lactation,
                                    c.Sire,
                                    c.InsertionDate,
                                    c.Birthdate,
                                    c.Weight,
                                    c.Age,
                                    c.Price
                                };
                    gvAni.DataSource = form3.ToList();
                    gvAni.DataBind();




                }

                gvAnimal.Visible = false;
                gvAni.Visible = true;

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch (Exception ex)
            { 
                    Response.Redirect("Animal_View.aspx");
            }
            gvAnimal.Visible = true;
            gvAni.Visible = false;


        }

        protected void ddCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}