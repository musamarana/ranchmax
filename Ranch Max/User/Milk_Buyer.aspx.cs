using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Milk_Buyer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
           Buyer buy = new Buyer();

            buy.Name = txtName.Text;
            buy.CNIC =  txtcnic.Text;
            buy.Phone = txtphone.Text;
           // buy.Email = txtemail.Text;
            buy.Address = txtadd.Text;

            db.Buyers.Add(buy);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Account Added ";
            txtadd.Text = txtcnic.Text =  txtName.Text = txtphone.Text = "";

        }
    }
}