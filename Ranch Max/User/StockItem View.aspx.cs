using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max.Users
{
    public partial class StockItem_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStockItems();

                populateGridView();
            }
        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvStock.DataSource = db.StockItems.ToList<StockItem>();
                gvStock.DataBind();

            }

        }



        //FUNCTION TO POPULATE STOCK items

        private void PopulateStockItems()
        {
            List<StockItem> allStockItems = null;
            using (Entities db = new Entities())
            {
                var item = (from a in db.StockItems
                             join b in db.StockTypes
                            on a.StockType_Id equals b.StockType_Id
                              select new
                             {
                                 a,
                                 b.TypeName
                                 

                             });
                if (item != null)
                {
                    allStockItems = new List<StockItem>();
                    foreach (var i in item)
                    {
                        StockItem c = i.a;
                        c.TypeName = i.TypeName;
                         allStockItems.Add(c);

                    }

                }
                else
                {
                    gvStock.DataSource = allStockItems;
                    gvStock.DataBind();
                }

            }
        }
        //function to fetch stock type from  database
        private List<StockType> PopulatestockType()
        {
            using (Entities db = new Entities())
            {
                return db.StockTypes.OrderBy(a => a.TypeName).ToList();
            }
        }

         
        //function to bind stocktype to dropdownlist

        private void BindStockType(DropDownList ddIName, List<StockType> item)
        {
            ddIName.Items.Clear();
            ddIName.Items.Add(new ListItem { Text = "Select Type", Value = "0" });
            ddIName.AppendDataBoundItems = true;
            ddIName.DataValueField = "StockType_Id";
            ddIName.DataTextField = "TypeName";
            ddIName.DataSource = item;
            ddIName.DataBind();

        }
         
        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddType.Text == "Feed")
                {
                      var feed = from c in db.StockItems
                               where c.StockType.TypeName == "Feed"
                                select new
                               {
                                   c.StockType.TypeName,
                                   c.Name,
                                   c.Brand

                               };
 
                    GridView2.DataSource = feed.ToList();
                     GridView2.DataBind();
                     
                }

                else if (ddType.Text == "Medicine")
                {

                     var med = from c in db.StockItems
                               where c.StockType.TypeName == "Medicine"
                               select new
                               {
                                   c.StockType.TypeName,
                                   c.Name,
                                   c.Brand

                               };

                    GridView2.DataSource = med.ToList();
                    GridView2.DataBind();
                }

                else if (ddType.Text == "Semon")
                {

                     var sem = from c in db.StockItems
                              where c.StockType.TypeName == "Semon"
                              select new
                              {
                                  c.StockType.TypeName,
                                  c.Name,
                                  c.Brand

                              };

                    GridView2.DataSource = sem.ToList();
                    GridView2.DataBind();

                }
                gvStock.Visible = false;
                GridView2.Visible = true;

            }

        }
         
        protected void Button2_Click(object sender, EventArgs e)
        {
            ddType.SelectedIndex = 0;
            try
            {
             }
            catch (Exception ex)
            {
                Response.Redirect("StockItem View.aspx");
            }
            gvStock.Visible = true;
            GridView2.Visible = false;
        }

        protected void gvStock_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //get Stocktype_Id  of edit able row
            string StockType_Id = gvStock.DataKeys[e.NewEditIndex]["StockType_Id"].ToString();
             gvStock.EditIndex = e.NewEditIndex;
            PopulateStockItems();
            populateGridView();
            DropDownList ddIName = (DropDownList)gvStock.Rows[e.NewEditIndex].FindControl("ddIName");

             if (ddIName != null  )
            {
                BindStockType(ddIName, PopulatestockType());
                ddIName.SelectedValue = StockType_Id;
             }
        }

        protected void gvStock_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int StockItem_Id = (int)gvStock.DataKeys[e.RowIndex]["StockItem_Id"];
            DropDownList ddIName = (DropDownList)gvStock.Rows[e.RowIndex].FindControl("ddIName");
             TextBox txtName = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtName");
            TextBox txtBrand = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtBrand");
             
            using (Entities db = new Entities())
            {
                var v = db.StockItems.Where(a => a.StockItem_Id == StockItem_Id).FirstOrDefault();


                if (v != null)
                {
                    v.StockType_Id = int.Parse(ddIName.SelectedValue);
                     if (txtName.Text != "")
                    {
                        v.Name = txtName.Text;
                    }
                    else
                    {
                        v.Name = null;
                    }
                    if (txtBrand.Text != "")
                    {
                        v.Brand = txtBrand.Text;
                    }
                    else
                    {
                        v.Brand = null;
                    }
                     }

                db.SaveChanges();
                gvStock.EditIndex = -1;
                 PopulateStockItems();
                populateGridView();

            }
        }

        protected void gvStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int StockItem_Id = (int)gvStock.DataKeys[e.RowIndex]["StockItem_Id"];
            using (Entities db = new Entities())
            {
                var v = db.StockItems.Where(a => a.StockItem_Id.Equals(StockItem_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.StockItems.Remove(v);
                    db.SaveChanges();
                    PopulateStockItems();
                    populateGridView();

                }
            }
        }

        protected void gvStock_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStock.EditIndex = -1;
            PopulateStockItems();
            populateGridView();

        }

        
    }
}
