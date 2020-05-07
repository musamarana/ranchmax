using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max.Admin
{
    public partial class AspNetUserView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAspNetUser();

                populateGridView();
            }


        }


        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvEmp.DataSource = db.AspNetUsers.ToList<AspNetUser>();
                gvEmp.DataBind();
                 


            }

        }

        //FUNCTION TO POPULATE Aspnetuser  

        private void PopulateAspNetUser()
        {
            List<AspNetUser> allusers = null;
            using (Entities db = new Entities())
            {
                var info = (from a in db.AspNetUsers
                             select new
                            {
                                a,
                                

                            });
                if (info != null)
                {
                    allusers = new List<AspNetUser>();
                    foreach (var i in info)
                    {
                        AspNetUser c = i.a;
                         
                        allusers.Add(c);

                    }

                }
                else
                {
                    gvEmp.DataSource = allusers;
                    gvEmp.DataBind();
                }

            }




        }



        protected void gvEmp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmp.EditIndex = e.NewEditIndex;
            PopulateAspNetUser();
            populateGridView();
        }

        protected void gvEmp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            string Id = (string)gvEmp.DataKeys[e.RowIndex]["Id"];
            TextBox txtUsername = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtUsername");
            TextBox txtEmail = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtEmail");
             TextBox txtph = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtph");
 
            using (Entities db = new Entities())
            {
                var v = db.AspNetUsers.Where(a => a.Id == Id).FirstOrDefault();


                if (v != null)
                {
                    v.UserName = txtUsername.Text;
                    v.Email = txtEmail.Text;
                    v.PhoneNumber = txtph.Text;
 
                }

                db.SaveChanges();
                gvEmp.EditIndex = -1;
                PopulateAspNetUser();
                populateGridView();

            }


        }

        protected void gvEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = (string)gvEmp.DataKeys[e.RowIndex]["Id"];
            using (Entities db = new Entities())
            {
                var v = db.AspNetUsers.Where(a => a.Id.Equals(Id)).FirstOrDefault();
                if (v != null)
                {
                    db.AspNetUsers.Remove(v);
                    db.SaveChanges();
                    PopulateAspNetUser();
                    populateGridView();

                }
            }


        }

        protected void gvEmp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmp.EditIndex = -1;
            PopulateAspNetUser();
            populateGridView();


        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "UserName")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.AspNetUsers.ToList<AspNetUser>();
                    ddSearchItems.DataTextField = "UserName";
                    ddSearchItems.DataValueField = "UserName";
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

                if (ddSearch.Text == "UserName")
                {

                    string name = ddSearchItems.SelectedValue;
                    var form = from c in db.AspNetUsers
                               where c.UserName == name
                               select new
                               {
                                   c.UserName,
                                   c.Email,
                                   c.PhoneNumber 
                               };
                    gvEmp2.DataSource = form.ToList();
                    gvEmp2.DataBind();



                }


                gvEmp.Visible = false;
                gvEmp2.Visible = true;

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
                Response.Redirect("AspNetUserView.aspx");

            }
            gvEmp.Visible = true;
            gvEmp2.Visible = false;

        }

    }
}