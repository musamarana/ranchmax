using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Expenses : System.Web.UI.Page
    {
        Entities db = new Entities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //for Exp Type name
                var type = from c in db.Expense_Type select new { c.Type_Id, c.Type };
                ddEType.DataSource = type.ToList();
                ddEType.DataValueField = "Type_Id";
                ddEType.DataTextField = "Type";
                ddEType.DataBind();
                ddEType.Items.Insert(0, new ListItem("--Select--"));

                 
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Entities db = new Entities();
            Expens exp = new Expens();
             exp.Type_Id = int.Parse(ddEType.SelectedValue);
             exp.Amount = int.Parse(txtAmnt.Text);
            exp.Date = DateTime.Parse(txtdate.Text).Date;
            if (txtNar.Text != ""  )
            {

                exp.Narration = txtNar.Text;
                
            }
            else
            {
                exp.Narration = null;
             }


            db.Expenses.Add(exp);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "Expense Added ";
            ddEType.SelectedIndex =  0;
            txtdate.Text = txtAmnt.Text=txtNar.Text= "";

        }
    }
}