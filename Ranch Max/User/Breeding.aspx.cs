using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Breeding1 : System.Web.UI.Page
    {
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //for Animal Eartag
                var Animal = from c in db.Animals where c.Gender=="F" select new { c.Animal_Id, c.EarTag };
                ddAnimal.DataSource = Animal.ToList();
                ddAnimal.DataValueField = "Animal_Id";
                ddAnimal.DataTextField = "EarTag";
                ddAnimal.DataBind();
                ddAnimal.Items.Insert(0, new ListItem("--Select--"));


                //for Animal Eartag for Male
                var Animal_M = from x in db.Animals where x.Gender=="M"  select new { x.Animal_Id, x.EarTag };
                ddAnimal_M.DataSource = Animal_M.ToList();
                ddAnimal_M.DataValueField = "Animal_Id";
                ddAnimal_M.DataTextField = "EarTag";
                ddAnimal_M.DataBind();
                ddAnimal_M.Items.Insert(0, new ListItem("--Select--","NA"));



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
            Breeding bd = new Breeding();
            bd.Animal_Id = int.Parse(ddAnimal.SelectedValue);
            if (ddAnimal_M.SelectedValue != "NA" )
            {
                bd.Animal_Id_M = int.Parse(ddAnimal_M.SelectedValue);
                
                

            }
            else
            {
                bd.Animal_Id_M = null;
                

            }
            if (txtDose.Text != "")
            {

                bd.Dose = txtDose.Text;
            }
            else
            {
                bd.Dose = null;
            }
            bd.User_Id = ddUser.SelectedValue;
            bd.Type = ddType.SelectedValue;
            bd.Date = DateTime.Parse(txtdate.Text).Date;
 

            db.Breedings.Add(bd);
            db.SaveChanges();

            Label5.Visible = true;

            Label5.Text = "Breeding Added ";
            ddAnimal.SelectedIndex = ddUser.SelectedIndex =ddAnimal_M.SelectedIndex= 0;
            txtdate.Text = txtDose.Text = "";

        }
    }
}