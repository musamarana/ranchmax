using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Calving1 : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //for Animal Eartag
                var Animal = from c in db.Animals where c.Gender == "F" select new { c.Animal_Id, c.EarTag };
                ddAnimal.DataSource = Animal.ToList();
                ddAnimal.DataValueField = "Animal_Id";
                ddAnimal.DataTextField = "EarTag";
                ddAnimal.DataBind();
                ddAnimal.Items.Insert(0, new ListItem("--Select--"));
                 
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            Entities db = new Entities();
            Calving cv = new Calving();
            cv.Animal_Id = int.Parse(ddAnimal.SelectedValue);
             cv.Gender = ddGender.SelectedValue;
            cv.Status = ddStatus.SelectedValue;
             
            cv.Date = DateTime.Parse(txtdate.Text).Date;
             if (txtweight.Text != "")
            {
                cv.Weight = int.Parse(txtweight.Text);

            }
            else
            {
                cv.Weight = null;
            }



            db.Calvings.Add(cv);
            db.SaveChanges();

            Label5.Visible = true;

            Label5.Text = "Calving Added ";
            ddAnimal.SelectedIndex =  ddGender.SelectedIndex = ddStatus.SelectedIndex = 0;
            txtdate.Text = txtweight.Text = "";
             
        }
    }
}