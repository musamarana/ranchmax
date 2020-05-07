using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace Ranch_Max
{
    public partial class Animal_Sale : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {

                //for Animal Eartag
                var Animal = from c in db.Animals where c.Status=="Active" select new { c.Animal_Id, c.EarTag };
                ddETag.DataSource = Animal.ToList();
                ddETag.DataValueField = "Animal_Id";
                ddETag.DataTextField = "EarTag";
                ddETag.DataBind();
                ddETag.Items.Insert(0, new ListItem("--Select--"));


            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            AnimalSale sale = new AnimalSale();

            sale.Animal_Id = int.Parse(ddETag.SelectedValue);
            sale.Amount = int.Parse(txtAmnt.Text);

            if (txtBuyer.Text != " " && txtCNIC.Text != "" && txtdate.Text != "")
            {
                sale.BuyerName = txtBuyer.Text;
                sale.CNIC =  txtCNIC.Text;
                sale.Date = DateTime.Parse(txtdate.Text);


            }
            else
            {
                sale.BuyerName = null;
                sale.CNIC = null;
                sale.Date = null;
            }

            db.AnimalSales.Add(sale);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = " Animal Sold ";

            

            txtAmnt.Text = txtdate.Text = txtBuyer.Text = txtCNIC.Text = "";
            ddETag.SelectedIndex = 0;
         }

        

    }
   
}