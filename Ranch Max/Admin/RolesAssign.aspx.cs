using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max.Admin
{
    public partial class RolesAssign : System.Web.UI.Page
    {
       Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                populateGridView();

            }
        }

        void populateGridView()
        {
            using (Entities db = new Entities()) { 
                gvRole.DataSource = (from user in db.AspNetUsers
                                        from role in user.AspNetRoles
                                        select new
                                        {
                                            User = user.UserName,
                                            Role = role.Name
                                        }).ToList();
            gvRole.DataBind();
            }
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertWithData();
            populateGridView();
        }
        public void InsertWithData()
        {
            using (Entities conn = new Entities())
            {
                // 1
                AspNetUser user = new AspNetUser { Id = ddUser.SelectedValue };
                // 2
                conn.AspNetUsers.Add(user);
                // 3
                conn.AspNetUsers.Attach(user);

                // 1
                AspNetRole role = new AspNetRole { Id = ddRole.SelectedValue };
                // 2
                conn.AspNetRoles.Add(role);
                // 3
                
                conn.AspNetRoles.Attach(role);




                // like previous method add instance to navigation property
                user.AspNetRoles.Add(role);

                // call SaveChanges
                conn.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Role Assigned Successfully')", true);
            }
        }


    }
}