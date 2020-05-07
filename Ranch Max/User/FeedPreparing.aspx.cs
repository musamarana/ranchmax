using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class FeedPreparing1 : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //for Formula name
                var formula = from c in db.FeedFormulas select new { c.Formula_Id, c.FormulaName };
                ddFormula.DataSource = formula.ToList();
                ddFormula.DataValueField = "Formula_Id";
                ddFormula.DataTextField = "FormulaName";
                ddFormula.DataBind();
                ddFormula.Items.Insert(0, new ListItem("--Select--"));

                //for Item name
                var item = from c in db.StockItems where c.StockType.TypeName == "Feed" select new { c.StockItem_Id, c.Name };
                ddItem.DataSource = item.ToList();
                ddItem.DataValueField = "StockItem_Id";
                ddItem.DataTextField = "Name";
                ddItem.DataBind();
                ddItem.Items.Insert(0, new ListItem("--Select--"));

                 
           }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            FeedPreparing FP = new FeedPreparing();
            FP.Formula_Id = int.Parse(ddFormula.SelectedValue);
            FP.StockItem_Id = int.Parse(ddItem.SelectedValue);
            FP.Quantity = int.Parse(txtQty.Text);
            if (ddUnit.SelectedValue != "0")
            {
                FP.Unit = ddUnit.SelectedValue;

            }
            else
            {
                FP.Unit = null;
            }
            if (txtRate.Text != "")
            {
                FP.Rate = int.Parse(txtRate.Text);

            }
            else
            {
                FP.Rate = null;
            }
            db.FeedPreparings.Add(FP);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Feed Prepared ";
            ddFormula.SelectedIndex = ddItem.SelectedIndex = 0;
            txtQty.Text  = txtRate.Text = "";
            
        }
    }
}