using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
 using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
   
namespace Ranch_Max.Users
{
    public partial class RolesAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridView();
                PopulateAspNetRoles();
                Label5.Text = "";
             }

        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvRole.DataSource = db.AspNetRoles.ToList<AspNetRole>();
                gvRole.DataBind();

            }

        }


        //FUNCTION TO POPULATE  Animal  

        private void PopulateAspNetRoles()
        {
            List<AspNetRole> allRoles = null;
            using (Entities db = new Entities())
            {
                var roles = (from a in db.AspNetRoles

                            select new
                            {
                                a,


                            });
                if (roles != null)
                {
                    allRoles = new List<AspNetRole>();
                    foreach (var i in roles)
                    {
                        AspNetRole c = i.a;

                        allRoles.Add(c);

                    }

                }
                else
                {
                    gvRole.DataSource = allRoles;
                    gvRole.DataBind();
                }

            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        { 
                Entities db = new Entities();
                AspNetRole role = new AspNetRole();

                role.Id = Guid.NewGuid().ToString();
                role.Name = txtRole.Text.ToLower();



                db.AspNetRoles.Add(role);
                db.SaveChanges();
             
            Label5.Visible = true;

            Label5.Text = "Role Added ";
            txtRole.Text = "";
            
            populateGridView();
            PopulateAspNetRoles();

        }

        protected void gvRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Id = (string)gvRole.DataKeys[e.RowIndex]["Id"];
            using (Entities db = new Entities())
            {
                var v = db.AspNetRoles.Where(a => a.Id.Equals(Id)).FirstOrDefault();
                if (v != null)
                {
                    db.AspNetRoles.Remove(v);
                    db.SaveChanges();
                    PopulateAspNetRoles();
                    populateGridView();

                }
            }

        }

        protected void gvRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRole.EditIndex = -1;
            PopulateAspNetRoles();
            populateGridView();


        }

        protected void gvRole_RowEditing(object sender, GridViewEditEventArgs e)
        {
             gvRole.EditIndex = e.NewEditIndex;
            PopulateAspNetRoles();
            populateGridView();
          
        }

        protected void gvRole_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            string Id = (string)gvRole.DataKeys[e.RowIndex]["Id"];
            TextBox txtName = (TextBox)gvRole.Rows[e.RowIndex].FindControl("txtName");
             using (Entities db = new Entities())
            {
                var v = db.AspNetRoles.Where(a => a.Id == Id.ToString()).FirstOrDefault();


                if (v != null)
                {
                    v.Name = txtName.Text;
                    
                }

                db.SaveChanges();
                gvRole.EditIndex = -1;
                PopulateAspNetRoles();
                populateGridView();

            }

        }
    }
}
