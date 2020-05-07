using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Expense_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateExpenses();

                populateGridView();
            }

        }
        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvExp.DataSource = db.Expenses.ToList<Expens>();
                gvExp.DataBind();

            }

        }

        //FUNCTION TO POPULATE Expenses  

        private void PopulateExpenses()
        {
            List<Expens> allExpenses = null;
            using (Entities db = new Entities())
            {
                var exp = (from a in db.Expenses
                            join b in db.Expense_Type
                            on a.Type_Id equals b.Type_Id
 
                            select new
                            {
                                a,
                                b.Type 

                            });
                if (exp != null)
                {
                    allExpenses = new List<Expens>();
                    foreach (var i in exp)
                    {
                        Expens c = i.a;
                        c.Type = i.Type;
                         allExpenses.Add(c);

                    }

                }
                else
                {
                    gvExp.DataSource = allExpenses;
                    gvExp.DataBind();
                }

            }
        }

        //function to fetch Expense Type from  database
        private List<Expense_Type> PopulateExpense_Type()
        {
            using (Entities db = new Entities())
            {
                // var med = from c in db.StockItems where c.StockType == "Medicine" orderby (c.Name).ToList() select new {c.Name} ;
                //return med ;

                return db.Expense_Type.OrderBy(a => a.Type).ToList();
            }
        }



        //function to bind Expense Type to dropdownlist

        private void BindExpense_Type(DropDownList ddEType, List<Expense_Type> type)
        {
            ddEType.Items.Clear();
            ddEType.Items.Add(new ListItem { Text = "Select Type", Value = "0" });
            ddEType.AppendDataBoundItems = true;
            ddEType.DataValueField = "Type_Id";
            ddEType.DataTextField = "Type";
            ddEType.DataSource = type;
            ddEType.DataBind();

        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Type")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.Expense_Type.ToList<Expense_Type>();
                    ddSearchItems.DataTextField = "Type";
                    ddSearchItems.DataValueField = "Type_Id";
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

                if (ddSearch.Text == "Type")
                {

                    string type = ddSearchItems.SelectedValue;
                    var form = from c in db.Expenses
                               where c.Type_Id
                               .ToString() == type
                               select new
                               {
                                   c.Expense_Type.Type,
                                   c.Amount,
                                   c.Date,
                                   c.Narration

                               };
                    gvExp2.DataSource = form.ToList();
                    gvExp2.DataBind();



                }

 
                gvExp.Visible = false;
                gvExp2.Visible = true;

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch (Exception ex) {
                Response.Redirect("Expense View.aspx");

            }
            gvExp.Visible = true;
            gvExp2.Visible = false;
        }

        protected void gvExp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get Exp Type_Id  of edit able row

            string Type_Id = gvExp.DataKeys[e.NewEditIndex]["Type_Id"].ToString();
             gvExp.EditIndex = e.NewEditIndex;
            PopulateExpenses();
            populateGridView();
            DropDownList ddEType = (DropDownList)gvExp.Rows[e.NewEditIndex].FindControl("ddEType");
             //DropDownList ddSlot = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddSlot");
            //TextBox txtDate = (TextBox)gvFeedCon.Rows[e.NewEditIndex].FindControl("txtDate");

            if (ddEType != null )
            {
                BindExpense_Type(ddEType, PopulateExpense_Type());
                ddEType.SelectedValue = Type_Id;
                 //  ddSlot.SelectedValue =ddSlot.DataValueField ;
                //txtDate.Text= txtDate.Text;         
            }

        }

        protected void gvExp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Exp_Id = (int)gvExp.DataKeys[e.RowIndex]["Exp_Id"];
            DropDownList ddEType = (DropDownList)gvExp.Rows[e.RowIndex].FindControl("ddEType");
             TextBox txtAmnt = (TextBox)gvExp.Rows[e.RowIndex].FindControl("txtAmnt");
             TextBox txtDate = (TextBox)gvExp.Rows[e.RowIndex].FindControl("txtDate");
             TextBox txtNar = (TextBox)gvExp.Rows[e.RowIndex].FindControl("txtNar");

            using (Entities db = new Entities())
            {
                var v = db.Expenses.Where(a => a.Exp_Id == Exp_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Type_Id = int.Parse(ddEType.SelectedValue);
                     v.Amount = int.Parse(txtAmnt.Text);
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    // v.Date = DateTime.Parse(txtDate.Text);
                    if (txtNar.Text != "")
                    {
                        v.Narration = txtNar.Text;
                    }
                    else
                    {
                        v.Narration = null;
                    }
                }

                db.SaveChanges();
                gvExp.EditIndex = -1;
                PopulateExpenses();
                populateGridView();

            }

        }

        protected void gvExp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Exp_Id = (int)gvExp.DataKeys[e.RowIndex]["Exp_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Expenses.Where(a => a.Exp_Id.Equals(Exp_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Expenses.Remove(v);
                    db.SaveChanges();
                    PopulateExpenses();
                    populateGridView();

                }
            }


        }

        protected void gvExp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvExp.EditIndex = -1;
            PopulateExpenses();
            populateGridView();

        }
    }
}

