using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class FeedConsumption1 : System.Web.UI.Page
    {
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //for Formula name
                var formula = from c in db.FeedFormulas select new { c.Formula_Id, c.FormulaName };
                ddFormula.DataSource = formula.ToList();
                ddFormula.DataValueField = "Formula_Id";
                ddFormula.DataTextField = "FormulaName";
                ddFormula.DataBind();
                ddFormula.Items.Insert(0, new ListItem("--Select--"));

                //for Animal breed
                var Animal = from c in db.Animals select new { c.Animal_Id, c.AnimalBreed.Breed };
                ddBreed.DataSource = Animal.ToList();
                ddBreed.DataValueField = "Animal_Id";
                ddBreed.DataTextField = "Breed";
                ddBreed.DataBind();
                ddBreed.Items.Insert(0, new ListItem("--Select--"));

                //for User
                var user = from c in db.AspNetUsers select new { c.Id, c.UserName };
                ddUser.DataSource = user.ToList();
                ddUser.DataValueField = "Id";
                ddUser.DataTextField = "UserName";
                ddUser.DataBind();
                ddUser.Items.Insert(0, new ListItem("--Entry User--"));

               

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            var q = from a in db.Animals where a.Breed_Id.ToString() == ddBreed.SelectedValue select new { animalId = a.Animal_Id };

            foreach (var ani in q)
            {
                FeedConsumption FC = new FeedConsumption();
                FC.Formula_Id = int.Parse(ddFormula.SelectedValue);
                FC.Animal_Id = ani.animalId;
                FC.User_Id = ddUser.SelectedValue;
                FC.Slot = ddSlot.SelectedValue;
                FC.Date = DateTime.Parse(txtdate.Text).Date;

                db.FeedConsumptions.Add(FC);
            }
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Consumption Added ";
            ddBreed.SelectedIndex = ddFormula.SelectedIndex = ddSlot.SelectedIndex =
                ddUser.SelectedIndex = 0;
            txtdate.Text = "";
        }
    }
}