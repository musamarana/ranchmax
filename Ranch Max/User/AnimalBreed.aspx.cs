using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class AnimalBreed1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridView();
                PopulateAnimalBreeds();
            }


        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvBreed.DataSource = db.AnimalBreeds.ToList<AnimalBreed>();
                gvBreed.DataBind();

            }

        }


        //FUNCTION TO POPULATE  Animal breed  

        private void PopulateAnimalBreeds()
        {
            List<AnimalBreed> allBreeds = null;
            using (Entities db = new Entities())
            {
                var breeds = (from a in db.AnimalBreeds

                             select new
                             {
                                 a,


                             });
                if (breeds != null)
                {
                    allBreeds = new List<AnimalBreed>();
                    foreach (var i in breeds)
                    {
                        AnimalBreed c = i.a;

                        allBreeds.Add(c);

                    }

                }
                else
                {
                    gvBreed.DataSource = allBreeds;
                    gvBreed.DataBind();
                }

            }
        }



        protected void gvBreed_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Breed_Id = (int)gvBreed.DataKeys[e.RowIndex]["Breed_Id"];
            using (Entities db = new Entities())
            {
                var v = db.AnimalBreeds.Where(a => a.Breed_Id.Equals(Breed_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.AnimalBreeds.Remove(v);
                    db.SaveChanges();
                    PopulateAnimalBreeds();
                    populateGridView();

                }
            }

        }

        protected void gvBreed_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBreed.EditIndex = -1;
            PopulateAnimalBreeds();
            populateGridView();


        }

        protected void gvBreed_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBreed.EditIndex = e.NewEditIndex;
            PopulateAnimalBreeds();
            populateGridView();

        }

        protected void gvBreed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Breed_Id = (int)gvBreed.DataKeys[e.RowIndex]["Breed_Id"];
            TextBox txtBreed = (TextBox)gvBreed.Rows[e.RowIndex].FindControl("txtBreed");
            using (Entities db = new Entities())
            {
                var v = db.AnimalBreeds.Where(a => a.Breed_Id == Breed_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Breed = txtBreed.Text;

                }

                db.SaveChanges();
                gvBreed.EditIndex = -1;
                PopulateAnimalBreeds();
                populateGridView();

            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            AnimalBreed AB = new AnimalBreed();

            AB.Breed = txtBreed.Text;


            db.AnimalBreeds.Add(AB);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Breed Added ";
            txtBreed.Text = "";
            populateGridView();
            PopulateAnimalBreeds();
        }
    }
}