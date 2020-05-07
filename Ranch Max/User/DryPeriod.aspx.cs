using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class DryPeriod1 : System.Web.UI.Page
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

             }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            DryPeriod dp = new DryPeriod();
            dp.Animal_Id = int.Parse(ddAnimal.SelectedValue);
            dp.StartDate = DateTime.Parse(txtSdate.Text).Date;
            if (txtEdate.Text != "") { 

            dp.EndDate = DateTime.Parse(txtEdate.Text).Date;
            }
            else
            {
                dp.EndDate = null;
            }


            db.DryPeriods.Add(dp);
            db.SaveChanges();

            Label5.Visible = true;

            Label5.Text = "Dry Period Added ";
            ddAnimal.SelectedIndex =  0;
            txtSdate.Text = txtEdate.Text = "";

        }
    }
}