using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class StockItem1 : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var type = from c in db.StockTypes select new { c.StockType_Id, c.TypeName };
                ddSType.DataSource = type.ToList();
                ddSType.DataValueField = "StockType_Id";
                ddSType.DataTextField = "TypeName";
                ddSType.DataBind();
                ddSType.Items.Insert(0, new ListItem("--Type--"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            StockItem SI = new StockItem();
            SI.StockType_Id= int.Parse(ddSType.SelectedValue);
            SI.Name = txtIName.Text;
            if (txtBrand.Text != "") { 
            SI.Brand = txtBrand.Text;
            }
            else
            {
                SI.Brand = null;

            }
            db.StockItems.Add(SI);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Item Added ";
            txtBrand.Text = txtIName.Text = "";
            ddSType.SelectedIndex = 0;
            //Response.Redirect("StockAdd.aspx");



        }
    }
}