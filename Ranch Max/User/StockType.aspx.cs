using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class StockType1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateStockTypes();
                populateGridView();

            }
        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvStock.DataSource = db.StockTypes.ToList<StockType>();
                gvStock.DataBind();

            }

        }


        //FUNCTION TO POPULATE  stock type  

        private void PopulateStockTypes()
        {
            List<StockType> allTypes = null;
            using (Entities db = new Entities())
            {
                var types = (from a in db.StockTypes

                             select new
                             {
                                 a,


                             });
                if (types != null)
                {
                    allTypes = new List<StockType>();
                    foreach (var i in types)
                    {
                        StockType c = i.a;

                        allTypes.Add(c);

                    }

                }
                else
                {
                    gvStock.DataSource = allTypes;
                    gvStock.DataBind();
                }

            }
        }



        protected void gvStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int StockType_Id = (int)gvStock.DataKeys[e.RowIndex]["StockType_Id"];
            using (Entities db = new Entities())
            {
                var v = db.StockTypes.Where(a => a.StockType_Id.Equals(StockType_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.StockTypes.Remove(v);
                    db.SaveChanges();
                    PopulateStockTypes();
                    populateGridView();

                }
            }

        }

        protected void gvStock_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStock.EditIndex = -1;
            PopulateStockTypes();
            populateGridView();


        }

        protected void gvStock_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStock.EditIndex = e.NewEditIndex;
            PopulateStockTypes();
            populateGridView();

        }

        protected void gvStock_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int StockType_Id = (int)gvStock.DataKeys[e.RowIndex]["StockType_Id"];
            TextBox txttype = (TextBox)gvStock.Rows[e.RowIndex].FindControl("txttype");
            using (Entities db = new Entities())
            {
                var v = db.StockTypes.Where(a => a.StockType_Id == StockType_Id).FirstOrDefault();


                if (v != null)
                {
                    v.TypeName = txttype.Text;

                }

                db.SaveChanges();
                gvStock.EditIndex = -1;
                PopulateStockTypes();
                populateGridView();

            }

        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            StockType ST = new StockType();

            ST.TypeName = txttype.Text;

            db.StockTypes.Add(ST);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Stock Type Added ";
            txttype.Text = "";
            PopulateStockTypes();
            populateGridView();

        }
    }
}