using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Expense_Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridView();
                PopulateExpenseTypes();
            }

        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvExp.DataSource = db.Expense_Type.ToList<Expense_Type>();
                gvExp.DataBind();

            }

        }


        //FUNCTION TO POPULATE  exp type  

        private void PopulateExpenseTypes()
        {
            List<Expense_Type> allTypes = null;
            using (Entities db = new Entities())
            {
                var types = (from a in db.Expense_Type

                              select new
                              {
                                  a,


                              });
                if (types != null)
                {
                    allTypes = new List<Expense_Type>();
                    foreach (var i in types)
                    {
                        Expense_Type c = i.a;

                        allTypes.Add(c);

                    }

                }
                else
                {
                    gvExp.DataSource = allTypes;
                    gvExp.DataBind();
                }

            }
        }



        protected void gvExp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Type_Id = (int)gvExp.DataKeys[e.RowIndex]["Type_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Expense_Type.Where(a => a.Type_Id.Equals(Type_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Expense_Type.Remove(v);
                    db.SaveChanges();
                    PopulateExpenseTypes();
                    populateGridView();

                }
            }

        }

        protected void gvExp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvExp.EditIndex = -1;
            PopulateExpenseTypes();
            populateGridView();


        }

        protected void gvExp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvExp.EditIndex = e.NewEditIndex;
            PopulateExpenseTypes();
            populateGridView();

        }

        protected void gvExp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Type_Id = (int)gvExp.DataKeys[e.RowIndex]["Type_Id"];
            TextBox txtName = (TextBox)gvExp.Rows[e.RowIndex].FindControl("txtName");
            using (Entities db = new Entities())
            {
                var v = db.Expense_Type.Where(a => a.Type_Id == Type_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Type = txtName.Text;

                }

                db.SaveChanges();
                gvExp.EditIndex = -1;
                PopulateExpenseTypes();
                populateGridView();

            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            Expense_Type ET = new Expense_Type();

            ET.Type = txtName.Text;


            db.Expense_Type.Add(ET);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Type Added ";
            txtName.Text = "";
            PopulateExpenseTypes();
            populateGridView();
        }
    }
}