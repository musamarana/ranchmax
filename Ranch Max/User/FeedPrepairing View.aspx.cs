using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class FeedPrepairing_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PopulateFeedPrepairings();

                populateGridView();
            }
        }


        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvFeedPre.DataSource = db.FeedPreparings.ToList<FeedPreparing>();
                gvFeedPre.DataBind();

            }

        }
        //FUNCTION TO POPULATE feedpreparing

        private void PopulateFeedPrepairings()
        {
            List<FeedPreparing> allFeedPrepairings = null;
            using (Entities db = new Entities())
            {
                var prepairing = (from a in db.FeedPreparings
                             join b in db.StockItems
                             on a.StockItem_Id equals b.StockItem_Id
                             join c in db.FeedFormulas on a.Formula_Id equals c.Formula_Id
                             select new
                             {
                                 a,
                                 b.Name,
                                 c.FormulaName

                             });
                if (prepairing != null)
                {
                    allFeedPrepairings = new List<FeedPreparing>();
                    foreach (var i in prepairing)
                    {
                        FeedPreparing c = i.a;
                        c.Name = i.Name;
                        c.FormulaName = i.FormulaName;
                        allFeedPrepairings.Add(c);

                    }

                }
                else
                {
                    gvFeedPre.DataSource = allFeedPrepairings;
                    gvFeedPre.DataBind();
                }

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


        //function to fetch Formula name from  database
        private List<FeedFormula> PopulateFeedFormula()
        {
            using (Entities db = new Entities())
            {
                return db.FeedFormulas.OrderBy(a => a.FormulaName).ToList();
            }
        }

        //function to bind stockItem to dropdownlist

        private void BindStockItem(DropDownList ddIName, List<StockItem> item)
        {
            ddIName.Items.Clear();
            ddIName.Items.Add(new ListItem { Text = "Select Item", Value = "0" });
            ddIName.AppendDataBoundItems = true;
            ddIName.DataValueField = "StockItem_Id";
            ddIName.DataTextField = "Name";
            ddIName.DataSource = item;
            ddIName.DataBind();

        }
        //function to bind Feed Formula to dropdownlist

        private void BindFeedFormula(DropDownList ddFName, List<FeedFormula> formula)
        {
            ddFName.Items.Clear();
            ddFName.Items.Add(new ListItem { Text = "Select Formula", Value = "0" });
            ddFName.AppendDataBoundItems = true;
            ddFName.DataValueField = "Formula_Id";
            ddFName.DataTextField = "FormulaName";
            ddFName.DataSource = formula;
            ddFName.DataBind();

        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (Entities db = new Entities())
            {


               if (ddSearch.Text == "Formula")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.FeedFormulas.ToList<FeedFormula>();
                    ddSearchItems.DataTextField = "FormulaName";
                    ddSearchItems.DataValueField = "Formula_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");


                }
                else if (ddSearch.Text == "Item")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.StockItems.ToList<StockItem>();
                    ddSearchItems.DataTextField = "Name";
                    ddSearchItems.DataValueField = "StockItem_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");


                }


            }

        }
        [Obsolete]
        protected void ddSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {

                if (ddSearch.Text == "Formula")
                {

                    string fname = ddSearchItems.SelectedValue;
                    var form = from c in db.FeedPreparings
                               where c.Formula_Id.ToString() == fname
                               select new
                               {
                                   c.FeedFormula.FormulaName,
                                    c.StockItem.Name,
                                   c.Quantity,
                                   c.Unit,
                                   c.Rate

                               };
                    gvFPre.DataSource = form.ToList();
                    gvFPre.DataBind();



                }
                 

                if (ddSearch.Text == "Item")
                {
                    string iname = ddSearchItems.SelectedValue;
                    var form2 = from c in db.FeedPreparings
                                where c.StockItem_Id.ToString() == iname
                                select new
                                {
                                    c.FeedFormula.FormulaName,
                                    c.StockItem.Name,
                                    c.Quantity,
                                    c.Unit,
                                    c.Rate
                                };
                    gvFPre.DataSource = form2.ToList();
                    gvFPre.DataBind();



                }

                gvFeedPre.Visible = false;
                gvFPre.Visible = true;

            }

        }

        protected void gvFeedPre_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get FeedFormula_Id  and StockItem_Id of edit able row

            string Formula_Id = gvFeedPre.DataKeys[e.NewEditIndex]["Formula_Id"].ToString();
             string StockItem_Id  = gvFeedPre.DataKeys[e.NewEditIndex]["StockItem_Id"].ToString();
            gvFeedPre.EditIndex = e.NewEditIndex;
            PopulateFeedPrepairings();
            populateGridView();
            DropDownList ddFName = (DropDownList)gvFeedPre.Rows[e.NewEditIndex].FindControl("ddFName");
             DropDownList ddIName = (DropDownList)gvFeedPre.Rows[e.NewEditIndex].FindControl("ddIName");
 
            if (ddFName != null && ddIName != null)
            {
                BindFeedFormula(ddFName, PopulateFeedFormula());
                ddFName.SelectedValue = Formula_Id;
                 BindStockItem(ddIName, PopulatestockItem());
                ddIName.SelectedValue = StockItem_Id;
             }

        }

        protected void gvFeedPre_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Id = (int)gvFeedPre.DataKeys[e.RowIndex]["Id"];
            DropDownList ddFName = (DropDownList)gvFeedPre.Rows[e.RowIndex].FindControl("ddFName");
            DropDownList ddIName = (DropDownList)gvFeedPre.Rows[e.RowIndex].FindControl("ddIName");
            DropDownList ddUnit = (DropDownList)gvFeedPre.Rows[e.RowIndex].FindControl("ddUnit");
            TextBox txtQ = (TextBox)gvFeedPre.Rows[e.RowIndex].FindControl("txtQ");
            TextBox txtRate = (TextBox)gvFeedPre.Rows[e.RowIndex].FindControl("txtRate");

            using (Entities db = new Entities())
            {
                var v = db.FeedPreparings.Where(a => a.Id == Id).FirstOrDefault();


                if (v != null)
                {
                    v.Formula_Id = int.Parse(ddFName.SelectedValue);
                     v.StockItem_Id= int.Parse(ddIName.SelectedValue);
                    v.Unit = ddUnit.SelectedItem.Value;
                    v.Quantity =  int.Parse(txtQ.Text);
                    v.Rate = int.Parse(txtRate.Text);
                }

                db.SaveChanges();
                gvFeedPre.EditIndex = -1;
                PopulateFeedPrepairings();
                populateGridView();

            }

        }

        protected void gvFeedPre_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = (int)gvFeedPre.DataKeys[e.RowIndex]["Id"];
            using (Entities db = new Entities())
            {
                var v = db.FeedPreparings.Where(a => a.Id.Equals(Id)).FirstOrDefault();
                if (v != null)
                {
                    db.FeedPreparings.Remove(v);
                    db.SaveChanges();
                    PopulateFeedPrepairings();
                    populateGridView();

                }
            }

        }

        protected void gvFeedPre_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFeedPre.EditIndex = -1;
            PopulateFeedPrepairings();
            populateGridView();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch (Exception et)
            {
                Response.Redirect("FeedPrepairing View.aspx");
            }
            gvFeedPre.Visible = true;
            gvFPre.Visible = false;

        }
    }
}