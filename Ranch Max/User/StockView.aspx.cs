using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class StockView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStockAdds();

                populateGridView();
            }
        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvStock.DataSource = db.StockAdds.ToList<StockAdd>();
                gvStock.DataBind();

            }

        }



        //FUNCTION TO POPULATE STOCKvIEW

        private void PopulateStockAdds()
        {
            List<StockAdd> allStockAdds = null;
            using (Entities db = new Entities())
            {
                var stock = (from a in db.StockAdds
                             join b in db.StockItems
      on a.StockItem_Id equals b.StockItem_Id
                             join c in db.AspNetUsers on a.User_Id equals c.Id
                             select new
                             {
                                 a,
                                 b.Name,
                                 c.UserName

                             });
                if (stock != null)
                {
                    allStockAdds = new List<StockAdd>();
                    foreach (var i in stock)
                    {
                        StockAdd c = i.a;
                        c.Name = i.Name;
                        c.UserName = i.UserName;
                        allStockAdds.Add(c);

                    }

                }
                else
                {
                    gvStock.DataSource = allStockAdds;
                    gvStock.DataBind();
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


        //function to fetch User from  database
        private List<AspNetUser> PopulateAspNetUser()
        {
            using (Entities db = new Entities())
            {
                return db.AspNetUsers.OrderBy(a => a.UserName).ToList();
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

        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddType.Text == "Feed")
                {

                    //string StockType = ((DropDownList)sender).SelectedValue;
                    //var dd = (DropDownList)((System.Web.UI.WebControls.ListControl)(sender)).Parent.Parent.FindControl("ddIName");
                    //BindStockItem(dd, int.Parse(StockType));

                    ddTypeItems.Items.Clear();
                    var feed = from c in db.StockItems where c.StockType.TypeName == "Feed" select new { c.StockItem_Id, c.Name };

                    ddTypeItems.DataSource = feed.ToList();
                    ddTypeItems.DataTextField = "Name";
                    ddTypeItems.DataValueField = "StockItem_Id";
                    ddTypeItems.DataBind();

                    ddTypeItems.Items.Insert(0, "--Select--");


                }

                else if (ddType.Text == "Medicine")
                {
                    ddTypeItems.Items.Clear();
                    var med = from c in db.StockItems where c.StockType.TypeName == "Medicine" select new { c.StockItem_Id, c.Name };

                    ddTypeItems.DataSource = med.ToList();
                    ddTypeItems.DataTextField = "Name";
                    ddTypeItems.DataValueField = "StockItem_Id";
                    ddTypeItems.DataBind();

                    ddTypeItems.Items.Insert(0, "--Select--");


                }
                else if (ddType.Text == "Semon")
                {
                    ddTypeItems.Items.Clear();
                    ddTypeItems.DataSource = db.StockItems.ToList<StockItem>();
                    ddTypeItems.DataTextField = "StockItem_Id";
                    ddTypeItems.DataValueField = "Name";
                    ddTypeItems.DataBind();

                    ddTypeItems.Items.Insert(0, "--Select--");


                }


            }

        }
        [Obsolete]
        protected void ddTypeItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {

                if (ddType.Text == "Feed")
                {
                    string name = ddTypeItems.SelectedValue;
                    var stockType = from c in db.StockAdds
                                    where c.StockItem_Id.ToString() == name
                                    select new
                                    {
                                        c.StockItem.Name,
                                        c.AspNetUser.UserName,
                                        c.TotalBags_Packs,
                                        c.BagSize_PackSize,
                                        c.Quantity,
                                        c.Expiry,
                                        c.Unit,
                                        c.Rate,
                                        c.Amount
                                    };
                    GridView2.DataSource = stockType.ToList();
                    GridView2.DataBind();



                }

                if (ddType.Text == "Medicine")
                {
                    string name = ddTypeItems.SelectedValue;
                    var stockType = from c in db.StockAdds
                                    where c.StockItem_Id.ToString() == name
                                    select new
                                    {
                                        c.StockItem.Name,
                                        c.AspNetUser.UserName,
                                        c.TotalBags_Packs,
                                        c.BagSize_PackSize,
                                        c.Quantity,
                                        c.Expiry,
                                        c.Unit,
                                        c.Rate,
                                        c.Amount
                                    };
                    GridView2.DataSource = stockType.ToList();
                    GridView2.DataBind();



                }

                if (ddType.Text == "Semon")
                {
                    string name = ddTypeItems.SelectedValue;
                    var stockType = from c in db.StockAdds
                                    where c.StockItem_Id.ToString() == name
                                    select new
                                    {
                                        c.StockItem_Id,
                                        c.User_Id,
                                        c.TotalBags_Packs,
                                        c.BagSize_PackSize,
                                        c.Quantity,
                                        c.Expiry,
                                        c.Unit,
                                        c.Rate,
                                        c.Amount
                                    };
                    GridView2.DataSource = stockType.ToList();
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
                ddTypeItems.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Response.Redirect("StockView.aspx");
            }
            gvStock.Visible = true;
            GridView2.Visible = false;
        }

        protected void gvStock_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //get StockItem_Id and User_Id of edit able row
            string StockItem_Id = gvStock.DataKeys[e.NewEditIndex]["StockItem_Id"].ToString();
            string User_Id = gvStock.DataKeys[e.NewEditIndex]["User_Id"].ToString();
            gvStock.EditIndex = e.NewEditIndex;
            PopulateStockAdds();
            populateGridView();
            DropDownList ddIName = (DropDownList)gvStock.Rows[e.NewEditIndex].FindControl("ddIName");

            DropDownList ddUName = (DropDownList)gvStock.Rows[e.NewEditIndex].FindControl("ddUName");
            if (ddIName != null && ddUName != null)
            {
                BindStockItem(ddIName, PopulatestockItem());
                ddIName.SelectedValue = StockItem_Id;
                BindAspNetUser(ddUName, PopulateAspNetUser());
                ddUName.SelectedValue = User_Id;
            }
        }

        protected void gvStock_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int StockAdd_Id = (int)gvStock.DataKeys[e.RowIndex]["StockAdd_Id"];
            DropDownList ddIName = (DropDownList)gvStock.Rows[e.RowIndex].FindControl("ddIName");
            DropDownList ddUName = (DropDownList)gvStock.Rows[e.RowIndex].FindControl("ddUName");
            DropDownList ddUnit = (DropDownList)gvStock.Rows[e.RowIndex].FindControl("ddUnit");
            TextBox txtTBags = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtTBags");
            TextBox txtBSize = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtBSize");
            TextBox txtQ = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtQ");
            TextBox txtDate = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtDate");
            TextBox txtRate = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtRate");
            TextBox txtAmount = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txtAmount");

            using (Entities db = new Entities())
            {
                var v = db.StockAdds.Where(a => a.StockAdd_Id == StockAdd_Id).FirstOrDefault();


                if (v != null)
                {
                    v.StockItem_Id = int.Parse(ddIName.SelectedValue);
                    v.User_Id = ddUName.SelectedValue;
                    if (txtTBags.Text != "")
                    {
                        v.TotalBags_Packs = int.Parse(txtTBags.Text);
                    }
                    else
                    {
                        v.TotalBags_Packs = null;
                    }
                    if (txtTBags.Text != "")
                    {
                        v.BagSize_PackSize = int.Parse(txtBSize.Text);
                    }
                    else
                    {
                        v.BagSize_PackSize = null;
                    }
                    if (txtQ.Text != "")
                    {
                        v.Quantity = int.Parse(txtQ.Text);
                    }
                    else
                    {
                        v.Quantity = null;
                    }
                    if (txtDate.Text != "")
                    {
                        string dateString = txtDate.Text;
                        v.Expiry = Convert.ToDateTime(dateString,
                            System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        // v.Expiry = DateTime.Parse(txtDate.Text);
                    }
                    else
                    {
                        v.Expiry = null;
                    }
                    //if (ddUnit.SelectedValue != "NA") { 
                    v.Unit = ddUnit.SelectedValue;
                    //}
                    //else
                    //{
                    //    v.Unit = null;
                    //}
                    if (txtAmount.Text != "")
                    {
                        v.Amount = int.Parse(txtAmount.Text);
                    }
                    else
                    {
                        v.Amount = null;
                    }

                    v.Rate = int.Parse(txtRate.Text);
                }

                db.SaveChanges();
                gvStock.EditIndex = -1;
                //gvFeed.DataBind();
                PopulateStockAdds();
                populateGridView();

            }
        }

        protected void gvStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int StockAdd_Id = (int)gvStock.DataKeys[e.RowIndex]["StockAdd_Id"];
            using (Entities db = new Entities())
            {
                var v = db.StockAdds.Where(a => a.StockAdd_Id.Equals(StockAdd_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.StockAdds.Remove(v);
                    db.SaveChanges();
                    PopulateStockAdds();
                    populateGridView();

                }
            }
        }

        protected void gvStock_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStock.EditIndex = -1;
            PopulateStockAdds();
            populateGridView();

        }

        protected void ddUName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddIName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
