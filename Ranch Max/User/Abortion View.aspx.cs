using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;


namespace Ranch_Max
{
    public partial class Abortion_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAbort();
            if (!IsPostBack)
            {
                PopulateAbortions();

                populateGridView();
                //ShowAbort();
            }


        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvAbor.DataSource = db.Abortions.ToList<Abortion>();
                gvAbor.DataBind();

            }

        }

        //FUNCTION TO POPULATE Abortion

        private void PopulateAbortions()
        {
            List<Abortion> allAbortions = null;
            using (Entities db = new Entities())
            {
                var abor = (from a in db.Abortions
                            join c in db.AspNetUsers on a.User_Id equals c.Id
                            join d in db.Animals on a.Animal_Id equals d.Animal_Id
                            select new
                            {
                                a,
                                c.UserName,
                                d.EarTag

                            });
                if (abor != null)
                {
                    allAbortions = new List<Abortion>();
                    foreach (var i in abor)
                    {
                        Abortion c = i.a;
                        c.UserName = i.UserName;
                        c.EarTag = i.EarTag.ToString();
                        allAbortions.Add(c);

                    }

                }
                else
                {
                    gvAbor.DataSource = allAbortions;
                    gvAbor.DataBind();


                }
            }

        }


        //function to fetch User from  database
        private List<AspNetUser> PopulateAspNetUser()
        {
            using (Entities db = new Entities())
            {
                return db.AspNetUsers.OrderBy(a => a.UserName).ToList();
            }
        }

        //function to fetch Animal Breed from  database
        private List<Animal> PopulateAnimal()

        {
            using (Entities db = new Entities())
            {
                return db.Animals.OrderBy(a => a.EarTag).ToList();
            }
        }



        //function to bind User to dropdownlist

        private void BindAspNetUser(DropDownList ddUser, List<AspNetUser> Username)
        {
            ddUser.Items.Clear();
            ddUser.Items.Add(new ListItem { Text = "Select User", Value = "0" });
            ddUser.AppendDataBoundItems = true;
            ddUser.DataValueField = "Id";
            ddUser.DataTextField = "UserName";
            ddUser.DataSource = Username;
            ddUser.DataBind();

        }

        //function to bind Animal breed to dropdownlist

        private void BindAnimal(DropDownList ddTag, List<Animal> animal)
        {
            ddTag.Items.Clear();
            ddTag.Items.Add(new ListItem { Text = "Select Animal", Value = "0" });
            ddTag.AppendDataBoundItems = true;
            ddTag.DataValueField = "Animal_Id";
            ddTag.DataTextField = "EarTag";
            ddTag.DataSource = animal;
            ddTag.DataBind();

        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Animal")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.Animals.ToList<Animal>();
                    ddSearchItems.DataTextField = "EarTag";
                    ddSearchItems.DataValueField = "Animal_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");



                }


                else if (ddSearch.Text == "User")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.AspNetUsers.ToList<AspNetUser>();
                    ddSearchItems.DataTextField = "UserName";
                    ddSearchItems.DataValueField = "Id";
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


                if (ddSearch.Text == "Animal")
                {
                    string tag = ddSearchItems.SelectedValue;
                    var form2 = from c in db.Abortions
                                where c.Animal_Id.ToString() == tag
                                select new
                                {
                                    c.Animal.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Date
                                     };
                    gvAbor2.DataSource = form2.ToList();
                    gvAbor2.DataBind();



                }

                if (ddSearch.Text == "User")
                {
                    string uname = ddSearchItems.SelectedValue;
                    var form3 = from c in db.Abortions
                                where c.User_Id.ToString() == uname
                                select new
                                {

                                    c.Animal.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Date
                                };
                    gvAbor2.DataSource = form3.ToList();
                    gvAbor2.DataBind();



                }

                gvAbor.Visible = false;
                gvAbor2.Visible = true;

            }



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }

            catch(Exception ep)
            {
                Response.Redirect("Abortion View.aspx");
            }
            gvAbor.Visible = true;
            gvAbor2.Visible = false;
        }

        protected void gvAbor_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //get Animal_Id and User_Id of edit able row

            string Animal_Id = gvAbor.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
            string User_Id = gvAbor.DataKeys[e.NewEditIndex]["User_Id"].ToString();
            gvAbor.EditIndex = e.NewEditIndex;
            PopulateAbortions();
            populateGridView();
            DropDownList ddTag = (DropDownList)gvAbor.Rows[e.NewEditIndex].FindControl("ddTag");
            DropDownList ddUName = (DropDownList)gvAbor.Rows[e.NewEditIndex].FindControl("ddUName");

            if (ddTag != null && ddUName != null)
            {
                BindAnimal(ddTag, PopulateAnimal());
                ddTag.SelectedValue = Animal_Id;
                BindAspNetUser(ddUName, PopulateAspNetUser());
                ddUName.SelectedValue = User_Id;
            }

        }

        protected void gvAbor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Abortion_Id = (int)gvAbor.DataKeys[e.RowIndex]["Abortion_Id"];
            DropDownList ddTag = (DropDownList)gvAbor.Rows[e.RowIndex].FindControl("ddTag");
            DropDownList ddUName = (DropDownList)gvAbor.Rows[e.RowIndex].FindControl("ddUName");
            TextBox txtDate = (TextBox)gvAbor.Rows[e.RowIndex].FindControl("txtDate");
             
            using (Entities db = new Entities())
            {
                var v = db.Abortions.Where(a => a.Abortion_Id == Abortion_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Animal_Id = int.Parse(ddTag.SelectedValue);
                    v.User_Id = ddUName.SelectedValue;
                    // v.Date = DateTime.Parse(txtDate.Text);
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }

                db.SaveChanges();
                gvAbor.EditIndex = -1;
                PopulateAbortions();
                populateGridView();

            }

        }

        protected void gvAbor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Abortion_Id = (int)gvAbor.DataKeys[e.RowIndex]["Abortion_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Abortions.Where(a => a.Abortion_Id.Equals(Abortion_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Abortions.Remove(v);
                    db.SaveChanges();
                    PopulateAbortions();
                    populateGridView();

                }
            }
        }

        protected void gvAbor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAbor.EditIndex = -1;
            PopulateAbortions();
            populateGridView();
        }

        void ShowAbort()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, Date), COUNT(Animal_Id) FROM Abortion GROUP BY DATENAME(MONTH, Date)", con);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                con.Close();




            }

            String[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);

            }



            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Column;
        }
    }

}