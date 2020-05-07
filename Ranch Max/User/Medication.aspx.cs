using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Medication1 : System.Web.UI.Page
    {
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //for Medicine name
                var med = from c in db.StockItems where c.StockType.TypeName == "Medicine" select new { c.StockItem_Id, c.Name };
                ddMed.DataSource = med.ToList();
                ddMed.DataValueField = "StockItem_Id";
                ddMed.DataTextField = "Name";
                ddMed.DataBind();
                ddMed.Items.Insert(0, new ListItem("--Select--"));

                //for Animal breed
                var Animal = from c in db.Animals select new { c.Animal_Id, c.EarTag };
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
            Medication MD = new Medication();
            MD.StockItem_Id = int.Parse(ddMed.SelectedValue);
            MD.Animal_Id = int.Parse(ddAnimal.SelectedValue);
            MD.User_Id = ddUser.SelectedValue;
            MD.Quantity = int.Parse(txtQty.Text);
             
            if (ddUnit.SelectedValue != "0" )
            {
                MD.Unit = ddUnit.SelectedValue;

            }
            else
            {
                MD.Unit = null;
            }
            MD.Method = ddMethod.SelectedValue;
            MD.Date = DateTime.Parse(txtdate.Text);
            if (txttime.Text != "")
            { 
                MD.Time = TimeSpan.Parse(txttime.Text);
            }
            else
            {
                MD.Time = null;
            }
            db.Medications.Add(MD);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Medication Added ";
            ddAnimal.SelectedIndex = ddMed.SelectedIndex = ddUnit.SelectedIndex =
            ddUser.SelectedIndex = ddMethod.SelectedIndex = 0;
            txtdate.Text = txtQty.Text = txttime.Text = "";

        }
    }
}