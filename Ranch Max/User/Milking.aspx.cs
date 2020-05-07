using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Milking1 : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label5.Enabled = false;

            if (!IsPostBack)
            {


                //for Milk of breed
                //var MilkBreed = from c in db.Animals where c.Gender=="F"  select new { c.Animal_Id, c.Breed };
                //ddAnimal.DataSource = MilkBreed.ToList();
                //ddAnimal.DataValueField = "Animal_Id";

                //ddAnimal.DataTextField = "Breed";
                //ddAnimal.DataBind();
                //ddAnimal.Items.Insert(0, new ListItem("--Select--"));


                //for animal eartag
                var MilkBreed = from c in db.Animals where c.Gender == "F" select new { c.Animal_Id, c.EarTag };
                ddAnimal.DataSource = MilkBreed.ToList();
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
            Milking milk = new Milking();

            milk.Animal_Id = int.Parse(ddAnimal.SelectedValue);
            milk.User_Id = ddUser.SelectedValue;
            milk.Amount_Ltr = double.Parse(txtamnt.Text);
            milk.Date = DateTime.Parse(txtdate.Text);
            if (ddSlot.SelectedValue != "0")
            {
                milk.Slot = ddSlot.SelectedValue;

            }
            else
            {
                milk.Slot = null;
            }

            db.Milkings.Add(milk);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = " Record Added ";
            ddAnimal.SelectedIndex = ddUser.SelectedIndex = ddSlot.SelectedIndex = 0;
            txtamnt.Text = txtdate.Text = "";
        }
    }
}