using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max.Users
{
    public partial class UserInformation : System.Web.UI.Page
    {
        Entities db = new Entities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //for User
                var user = from c in db.AspNetUsers select new { c.Id, c.UserName };
                ddUser.DataSource = user.ToList();
                ddUser.DataValueField = "Id";
                ddUser.DataTextField = "UserName";
                ddUser.DataBind();
                ddUser.Items.Insert(0, new ListItem("--Entry User--"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities db = new Entities();
            AspNetUserInfo info = new AspNetUserInfo();
            info.Id = ddUser.SelectedValue;
            info.Name = txtName.Text;
            info.Fname = txtFName.Text;
            info.Cnic = txtCNIC.Text;
            info.Address = txtadd.Text;

            db.AspNetUserInfoes.Add(info);
            db.SaveChanges();
            Label5.Visible = true;

            Label5.Text = "User Info Added ";
            txtadd.Text = txtCNIC.Text = txtName.Text = txtFName.Text = "";
            ddUser.SelectedIndex = 0;


        }
    }
}