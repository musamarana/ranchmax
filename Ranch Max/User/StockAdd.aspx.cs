using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class StockAdd1 : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {

                //for item name
                var item = from c in db.StockItems select new { c.StockItem_Id, c.Name };
                ddIName.DataSource = item.ToList();
                ddIName.DataValueField = "StockItem_Id";
                ddIName.DataTextField = "Name";
                ddIName.DataBind();
                ddIName.Items.Insert(0, new ListItem("--Item--"));

                //for entry person
                var user = from c in db.AspNetUsers select new { c.Id, c.UserName };
                ddUser.DataSource = user.ToList();
                ddUser.DataValueField = "Id";
                ddUser.DataTextField = "UserName";
                ddUser.DataBind();
                ddUser.Items.Insert(0, new ListItem("--Entry User--"));




            }
        }


        //function to fetch stock item from  database
        private List<StockItem> PopulatestockItem()
        {
            using (Entities db = new Entities())
            {
                return db.StockItems.OrderBy(a => a.Name).ToList();
            }
        }


        //function to fetch stock item from  database
        private List<AspNetUser> PopulateAspNetUser()
        {
            using (Entities db = new Entities())
            {
                return db.AspNetUsers.OrderBy(a => a.UserName).ToList();
            }
        }

        //function to bind stockItem to dropdownlist

        private void BindStockItem(DropDownList ddIName,List<StockItem> stockItem)
        {
            ddIName.Items.Clear();
            ddIName.Items.Add(new ListItem { Text = "Select Item", Value = "0" });
            ddIName.AppendDataBoundItems = true;
            ddIName.DataValueField = "StockItem_Id";
            ddIName.DataTextField = "Name";
            ddIName.DataSource = stockItem;
            ddIName.DataBind();

        }

        //function to bind User to dropdownlist

        private void BindAspNetUser(DropDownList ddUser, List<AspNetUser> Username)
        {
            ddUser.Items.Clear();
            ddUser.Items.Add(new ListItem { Text = "Select User", Value = "0" });
            ddUser.AppendDataBoundItems = true;
            ddUser.DataValueField = "Id";
            ddUser.DataTextField = "UserName";
            ddUser.DataSource = Username;
            ddUser.DataBind();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            StockAdd SA = new StockAdd();
            SA.StockItem_Id = int.Parse(ddIName.SelectedValue);
            SA.User_Id = ddUser.SelectedValue;
            if (TBags.Text != "") { 
            SA.TotalBags_Packs = int.Parse(TBags.Text);
            }
            else
            {
                SA.TotalBags_Packs = null;
            }
            if (BSize.Text != "") { 
            SA.BagSize_PackSize = int.Parse(BSize.Text);
            }
            else
            {
                SA.BagSize_PackSize = null;
            }
            if (txtQty.Text != "") { 
            SA.Quantity = int.Parse(txtQty.Text);
            }
            else
            {
                SA.Quantity = null;
            }
            if (txtExp.Text != "") { 
            SA.Expiry = DateTime.Parse(txtExp.Text);
            }
            else
            {
                SA.Expiry = null;
            }
            //if (ddUnit.SelectedValue != "0") { 
            SA.Unit = ddUnit.SelectedValue;
            //}
            //else
            //{
            //    SA.Unit = null;
            //}
            SA.Rate = int.Parse(txtRate.Text);
            SA.Amount = int.Parse(txtRate.Text) * int.Parse(txtQty.Text);

            db.StockAdds.Add(SA);
            db.SaveChanges();
            Label5.Visible = true;
            Label5.Text = "Stock Added ";
            ddIName.SelectedIndex = ddUnit.SelectedIndex = ddUser.SelectedIndex = 0;
            txtExp.Text = txtQty.Text = txtRate.Text=TBags.Text=BSize.Text = "";

        }
    }
}