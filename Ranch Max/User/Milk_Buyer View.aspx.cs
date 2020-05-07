using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Validation;


namespace Ranch_Max
{
    public partial class Milk_Buyer_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateBuyers();

                populateGridView();
            }


        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvBuy.DataSource = db.Buyers.ToList<Buyer>();
                gvBuy.DataBind();

                //var q = (from e in db.Expenses select e.Amount).Sum();

                //Label22.Text = "Total: " + q + "\n";


            }

        }
        //FUNCTION TO POPULATE Buyer  

        private void PopulateBuyers()
        {
            List<Buyer> allBuyers = null;
            using (Entities db = new Entities())
            {
                var buyer = (from a in db.Buyers
                             select new
                             {
                                 a,
                             });
                if (buyer != null)
                {
                    allBuyers = new List<Buyer>();
                    foreach (var i in buyer)
                    {
                        Buyer c = i.a;
                        allBuyers.Add(c);

                    }

                }
                else
                {
                    gvBuy.DataSource = allBuyers;
                    gvBuy.DataBind();
                }

            }
        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Name")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.Buyers.ToList<Buyer>();
                    ddSearchItems.DataTextField = "Name";
                    ddSearchItems.DataValueField = "Name";
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

                if (ddSearch.Text == "Name")
                {

                    string name = ddSearchItems.SelectedValue;
                    var form = from c in db.Buyers
                               where c.Name == name
                               select new
                               {
                                   c.Name,
                                   c.CNIC,
                                   c.Phone,
                                   c.Address

                               };
                    gvBuy2.DataSource = form.ToList();
                    gvBuy2.DataBind();



                }


                gvBuy.Visible = false;
                gvBuy2.Visible = true;

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Response.Redirect("Milk_Buyer View.aspx");

            }
            gvBuy.Visible = true;
            gvBuy2.Visible = false;

        }

        protected void gvBuy_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBuy.EditIndex = e.NewEditIndex;
            PopulateBuyers();
            populateGridView();
        }

        protected void gvBuy_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Buyer_Id = (int)gvBuy.DataKeys[e.RowIndex]["Buyer_Id"];
            TextBox txtName = (TextBox)gvBuy.Rows[e.RowIndex].FindControl("txtName");
            TextBox txtCNIC = (TextBox)gvBuy.Rows[e.RowIndex].FindControl("txtCNIC");
            TextBox txtPhone = (TextBox)gvBuy.Rows[e.RowIndex].FindControl("txtPhone");
            TextBox txtAdd = (TextBox)gvBuy.Rows[e.RowIndex].FindControl("txtAdd");

            using (Entities db = new Entities())
            {
                var v = db.Buyers.Where(a => a.Buyer_Id == Buyer_Id).FirstOrDefault();

                
                if (v != null)
                {
                    v.Name = txtName.Text;
                    v.CNIC = txtCNIC.Text;
                    v.Phone =  txtPhone.Text;
                    v.Address = txtAdd.Text;

                }

                 db.SaveChanges();
                gvBuy.EditIndex = -1;
                PopulateBuyers();
                populateGridView();

            }

        }

        protected void gvBuy_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Buyer_Id = (int)gvBuy.DataKeys[e.RowIndex]["Buyer_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Buyers.Where(a => a.Buyer_Id.Equals(Buyer_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Buyers.Remove(v);
                    db.SaveChanges();
                    PopulateBuyers();
                    populateGridView();

                }
            }


        }

        protected void gvBuy_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBuy.EditIndex = -1;
            PopulateBuyers();
            populateGridView();

        }
    }
}