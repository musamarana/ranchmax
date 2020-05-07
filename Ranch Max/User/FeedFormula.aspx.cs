using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class FeedFormula1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridView();
                PopulateFeedFormulas();
            }
        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvFormula.DataSource = db.FeedFormulas.ToList<FeedFormula>();
                gvFormula.DataBind();

            }

        }


        //FUNCTION TO POPULATE  feed formula  

        private void PopulateFeedFormulas()
        {
            List<FeedFormula> allFromulas = null;
            using (Entities db = new Entities())
            {
                var formulas = (from a in db.FeedFormulas

                             select new
                             {
                                 a,


                             });
                if (formulas != null)
                {
                    allFromulas= new List<FeedFormula>();
                    foreach (var i in formulas)
                    {
                        FeedFormula c = i.a;

                        allFromulas.Add(c);

                    }

                }
                else
                {
                    gvFormula.DataSource = allFromulas;
                    gvFormula.DataBind();
                }

            }
        }



        protected void gvFormula_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Formula_Id = (int)gvFormula.DataKeys[e.RowIndex]["Formula_Id"];
            using (Entities db = new Entities())
            {
                var v = db.FeedFormulas.Where(a => a.Formula_Id.Equals(Formula_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.FeedFormulas.Remove(v);
                    db.SaveChanges();
                    PopulateFeedFormulas();
                    populateGridView();

                }
            }

        }

        protected void gvFormula_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFormula.EditIndex = -1;
            PopulateFeedFormulas();
            populateGridView();


        }

        protected void gvFormula_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFormula.EditIndex = e.NewEditIndex;
            PopulateFeedFormulas();
            populateGridView();

        }

        protected void gvFormula_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Formula_Id = (int)gvFormula.DataKeys[e.RowIndex]["Formula_Id"];
            TextBox txtName = (TextBox)gvFormula.Rows[e.RowIndex].FindControl("txtName");
            using (Entities db = new Entities())
            {
                var v = db.FeedFormulas.Where(a => a.Formula_Id == Formula_Id).FirstOrDefault();


                if (v != null)
                {
                    v.FormulaName = txtName.Text;

                }

                db.SaveChanges();
                gvFormula.EditIndex = -1;
                PopulateFeedFormulas();
                populateGridView();

            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            FeedFormula FF = new FeedFormula();
          
            FF.FormulaName = txtName.Text;
            

            db.FeedFormulas.Add(FF);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Formula Added ";
            txtName.Text = "";
            populateGridView();
            PopulateFeedFormulas();
        }
    }
}