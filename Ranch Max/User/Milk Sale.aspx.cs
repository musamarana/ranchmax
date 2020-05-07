using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Milk_Sale : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //for Buyer
                var buyer = from c in db.Buyers select new { c.Buyer_Id, c.Name };
                ddBuyer.DataSource = buyer.ToList();
                ddBuyer.DataValueField = "Buyer_Id";
                ddBuyer.DataTextField = "Name";
                ddBuyer.DataBind();
                ddBuyer.Items.Insert(0, new ListItem("--Buyer--"));


                //for Milk amount
                //var MilkBreed = from c in db.Milkings select new { c.Milking_Id, c.Amount_Ltr };
                //ddmilk.DataSource = MilkBreed.ToList();
                //ddmilk.DataValueField = "Milking_Id";

                //ddmilk.DataTextField = "Amount_Ltr";
                //ddmilk.DataBind();
                //ddmilk.Items.Insert(0, new ListItem("--Select--"));



            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Entities db = new Entities();
            MilkBuyer milk = new MilkBuyer();

            milk.Buyer_Id = int.Parse(ddBuyer.SelectedValue);
            //if (ddmilk.SelectedValue != "") { 
            //milk.Milking_Id = int.Parse(ddmilk.SelectedValue);
            //}
            //else
            //{
            //    milk.Milking_Id = null;
            //}
            milk.DateTime = DateTime.Parse(txtdate.Text);
            milk.Quantity = double.Parse(txtQty.Text);
            if (txtRate.Text != "")
            {
                milk.Rate = int.Parse(txtRate.Text);

            }
            else
            {
                milk.Rate = null;
            }
            db.MilkBuyers.Add(milk);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = " Milk Sold ";

           txtRate.Text= txtdate.Text = txtQty.Text =  "";
            ddBuyer.SelectedIndex = 0;
            
        }

    }
}