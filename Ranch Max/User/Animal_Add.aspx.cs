using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Animal_Add : System.Web.UI.Page
    {
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var q = from c in db.AnimalBreeds select new { c.Breed_Id, c.Breed };
                ddBreed.DataSource = q.ToList();
                ddBreed.DataValueField = "Breed_Id";
                ddBreed.DataTextField = "Breed";
                ddBreed.DataBind();
                ddBreed.Items.Insert(0, new ListItem("--Select--"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Entities db = new Entities();
            Animal ani = new Animal();
            ani.EarTag =int.Parse(txttag.Text);
            
            ani.OriginCountry = ddCountry.SelectedValue;
            ani.Gender = ddGender.SelectedValue;
            ani.Status = ddStatus.SelectedValue;
            ani.Breed_Id = int.Parse(ddBreed.SelectedValue);
            ani.Category = ddCat.SelectedValue;

            if (txtsire.Text != "")
            {
                ani.Sire = int.Parse(txtsire.Text);

            }
            else
            {
                ani.Sire = null;

            }
            if (txtage.Text != "")
            {
                ani.Age = int.Parse(txtage.Text);

            }
            else
            {
                ani.Age = null;
            }
            if (txtweight.Text != "")
            {
                ani.Weight = int.Parse(txtweight.Text);

            }
            else
            {
                ani.Weight = null;

            }
            if (txtBdate.Text != "")
            {
                string dateString1 = txtBdate.Text;
                ani.Birthdate =  DateTime.Parse(txtBdate.Text) ;

            }
            else
            {
                ani.Birthdate = null;

            }
            if (txtlact.Text != "") { 
            
                ani.Lactation = int.Parse(txtlact.Text);

            }
            else
            {
                ani.Lactation = null;

            }

            if (txtIdate.Text != "")
            {
                string dateString2 = txtBdate.Text;

                ani.InsertionDate = DateTime.Parse(txtIdate.Text);

            }
            else
            {
                ani.InsertionDate = null;

            }

            if (txtprice.Text != "")
            {
                ani.Price = int.Parse(txtprice.Text);

            }
            else
            {
                ani.Price = null;

            }


            db.Animals.Add(ani);
            db.SaveChanges();

            Label5.Visible = true;

            Label5.Text = "Animal Added ";

            ddBreed.SelectedIndex = ddCat.SelectedIndex = ddCountry.SelectedIndex =
                ddGender.SelectedIndex = ddStatus.SelectedIndex = 0;
            txtage.Text = txtBdate.Text = txtIdate.Text = txtlact.Text = txtsire.Text = 
                txttag.Text = txtweight.Text = txtprice.Text = "";
        }
    }
}