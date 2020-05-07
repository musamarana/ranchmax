using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max.Users
{
    public partial class EmployeeView1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAspNetUserInfos();

                populateGridView();
            }

        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvEmp.DataSource = db.AspNetUserInfoes.ToList<AspNetUserInfo>();
                gvEmp.DataBind();

                //var q = (from e in db.Expenses select e.Amount).Sum();

                //Label22.Text = "Total: " + q + "\n";


            }

        }


         
        //FUNCTION TO POPULATE userinfo  

        private void PopulateAspNetUserInfos()
        {
            List<AspNetUserInfo> alluserinfos = null;
            using (Entities db = new Entities())
            {
                var info = (from a in db.AspNetUserInfoes
                            join b in db.AspNetUsers on a.Id equals b.Id
                             select new
                             {
                                 a,
                                 b.PhoneNumber,
                                 b.UserName

                             });
                if (info != null)
                {
                    alluserinfos = new List<AspNetUserInfo>();
                    foreach (var i in info)
                    {
                        AspNetUserInfo c = i.a;
                        c.PhoneNumber = i.PhoneNumber;
                        c.UserName = i.UserName;
                        alluserinfos.Add(c);

                    }

                }
                else
                {
                    gvEmp.DataSource = alluserinfos;
                    gvEmp.DataBind();
                }

            }


           

        }


        //function to fetch User from  database
        private List<AspNetUser> PopulateAspNetUserName()
        {
            using (Entities db = new Entities())
            {
                return db.AspNetUsers.OrderBy(a => (a.UserName)).ToList();
 
            }
        }

        //function to bind User to dropdownlist
        private void BindAspNetUserName(DropDownList ddUName, List<AspNetUser> Username)
        {
            ddUName.Items.Clear();
            ddUName.Items.Add(new ListItem { Text = "Select User", Value = "0" });
            ddUName.AppendDataBoundItems = true;
            ddUName.DataValueField = "Id";
            ddUName.DataTextField = "UserName";
            ddUName.DataSource = Username;
            ddUName.DataBind();

        }

        //function to fetch User from  database
        private List<AspNetUser> PopulateAspNetUserEmail()
        {
            using (Entities db = new Entities())
            {
                return db.AspNetUsers.OrderBy(a => (a.Email)).ToList();

            }
        }

        //function to bind User email to dropdownlist
        private void BindAspNetUserEmail(DropDownList ddEmail, List<AspNetUser> email)
        {
            ddEmail.Items.Clear();
            ddEmail.Items.Add(new ListItem { Text = "Select User", Value = "0" });
            ddEmail.AppendDataBoundItems = true;
            ddEmail.DataValueField = "Id";
            ddEmail.DataTextField = "Email";
            ddEmail.DataSource = email;
            ddEmail.DataBind();

        }

        protected void gvEmp_RowEditing(object sender, GridViewEditEventArgs e)
        {    //get User_Id of edit able row

           // string User_Id = gvEmp.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
 
            string Id = gvEmp.DataKeys[e.NewEditIndex]["Id"].ToString();

            gvEmp.EditIndex = e.NewEditIndex;
            PopulateAspNetUserInfos();
            populateGridView();
 
            DropDownList ddUName = (DropDownList)gvEmp.Rows[e.NewEditIndex].FindControl("ddUName");
            DropDownList ddEmail = (DropDownList)gvEmp.Rows[e.NewEditIndex].FindControl("ddEmail");

            if (ddEmail != null && ddUName != null)
            {
                BindAspNetUserEmail(ddEmail, PopulateAspNetUserEmail());
                ddEmail.SelectedValue = Id;

                BindAspNetUserName(ddUName, PopulateAspNetUserName());
                ddUName.SelectedValue = Id;
            }
             
        }

        protected void gvEmp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int InfoId = (int)gvEmp.DataKeys[e.RowIndex]["InfoId"];
            TextBox txtName = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtName");
            TextBox txtFname = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtFname");
            TextBox txtCNIC = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtCNIC");
            TextBox txtph = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtph");
            TextBox txtadd = (TextBox)gvEmp.Rows[e.RowIndex].FindControl("txtadd");
            DropDownList ddUName = (DropDownList)gvEmp.Rows[e.RowIndex].FindControl("ddUName");
            DropDownList ddEmail = (DropDownList)gvEmp.Rows[e.RowIndex].FindControl("ddEmail");


            using (Entities db = new Entities())
            {
                var v = db.AspNetUserInfoes.Where(a => a.InfoId == InfoId).FirstOrDefault();


                if (v != null)
                {
                    v.Name = txtName.Text;
                    v.Fname = txtFname.Text;
                    v.Cnic = txtCNIC.Text;
                    v.PhoneNumber = txtph.Text;
                    v.Address = txtadd.Text;
                    v.UserName = ddUName.SelectedValue;
                    v.Id = ddEmail.SelectedValue;
                }

                db.SaveChanges();
                gvEmp.EditIndex = -1;
                PopulateAspNetUserInfos();
                populateGridView();

            }


        }

        protected void gvEmp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int InfoId = (int)gvEmp.DataKeys[e.RowIndex]["InfoId"];
            using (Entities db = new Entities())
            {
                var v = db.AspNetUserInfoes.Where(a => a.InfoId.Equals(InfoId)).FirstOrDefault();
                if (v != null)
                {
                    db.AspNetUserInfoes.Remove(v);
                    db.SaveChanges();
                    PopulateAspNetUserInfos();
                    populateGridView();

                }
            }


        }

        protected void gvEmp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmp.EditIndex = -1;
            PopulateAspNetUserInfos();
            populateGridView();


        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Name")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.AspNetUserInfoes.ToList<AspNetUserInfo>();
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
                    var form = from c in db.AspNetUserInfoes
                               where c.Name == name
                               select new
                               {
                                   c.Name,
                                   c.Fname,
                                   c.Cnic,
                                   c.AspNetUser.PhoneNumber,
                                   c.AspNetUser.UserName,
                                   c.AspNetUser.Email,
                                   c.Address

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
                Response.Redirect("EmployeeView.aspx");

            }
            gvEmp.Visible = true;
            gvEmp2.Visible = false;

        }
    }
}