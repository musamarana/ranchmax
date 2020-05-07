using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Abortion1 : System.Web.UI.Page
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
            Abortion ab = new Abortion();
            ab.Animal_Id = int.Parse(ddAnimal.SelectedValue);
            ab.User_Id = ddUser.SelectedValue;
            ab.Date = DateTime.Parse(txtdate.Text).Date;
              
            db.Abortions.Add(ab);
            db.SaveChanges();

            Label5.Visible = true;

            Label5.Text = "Abortion Added ";
            ddAnimal.SelectedIndex = ddUser.SelectedIndex = 0;
            txtdate.Text =  "";

        }
    }
}