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
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace Ranch_Max
{
    public partial class Breeding_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showBreed();
            if (!IsPostBack)
            {
                PopulateBreedings();

                populateGridView();
                //showBreed();
            }


        }
        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvbreed.DataSource = db.Breedings.ToList<Breeding
>();
                gvbreed.DataBind();

            }

        }


        //FUNCTION TO POPULATE breeding

        private void PopulateBreedings()
        {
            List<Breeding> allBreedings = null;
            using (Entities db = new Entities())
            {
                var breed = (from a in db.Breedings
                             join b in db.AspNetUsers on a.User_Id equals b.Id
                             join c in db.Animals on a.Animal_Id & a.Animal_Id_M equals c.Animal_Id    
                             //join d in db.Animals on a.Animal_Id_M equals d.Animal_Id where d.Gender=="M"
                             select new
                            {
                                a,
                                b.UserName,
                                c.EarTag ,
                               // u2=d.EarTag
                            });
                  if (breed != null)
                {
                    allBreedings = new List<Breeding>();
                    foreach (var i in breed)
                    {
                        Breeding e = i.a;
                        e.UserName = i.UserName;
                        e.EarTag = i.EarTag.ToString();
                        //c.u1 = i.u1.ToString();
                       // c.u2 = i.u2.ToString();
                        allBreedings.Add(e);

                    }

                }
                else
                {
                    gvbreed.DataSource = allBreedings;
                    gvbreed.DataBind();


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
        private List<Animal> PopulateAnimal1()

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

        private void BindAnimal(DropDownList ddTag )
        {
            Entities db = new Entities();
            ddTag.Items.Clear();
            var animal = from c in db.Animals where c.Gender == "F" select new { c.Animal_Id, c.EarTag };

            ddTag.Items.Add(new ListItem { Text = "--Select Animal--", Value = "0" });
            ddTag.AppendDataBoundItems = true;
            ddTag.DataValueField = "Animal_Id";
            ddTag.DataTextField = "EarTag";
            ddTag.DataSource = animal.ToList();
            ddTag.DataBind();

        }

        private void BindAnimal1(DropDownList ddTag1 )
        {
            Entities db = new Entities();
            ddTag1.Items.Clear();
            var animal1 = from c in db.Animals where c.Gender == "M" select new { c.Animal_Id, c.EarTag };

            ddTag1.Items.Add(new ListItem ( "--Select Animal--", "NA" ));
            ddTag1.AppendDataBoundItems = true;
            ddTag1.DataValueField = "Animal_Id";
            ddTag1.DataTextField = "EarTag";
            ddTag1.DataSource = animal1.ToList();
            ddTag1.DataBind();

        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "F_Animal")
                {

                    ddSearchItems.Items.Clear();
                    var animal = from c in db.Animals where c.Gender == "F" select new { c.Animal_Id, c.EarTag };
                    ddSearchItems.DataSource = animal.ToList();
                    ddSearchItems.DataTextField = "EarTag";
                    ddSearchItems.DataValueField = "Animal_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");



                }

                if (ddSearch.Text == "M_Animal")
                {
                    ddSearchItems.Items.Clear();
                    var animal1 = from c in db.Animals where c.Gender == "M" select new { c.Animal_Id, c.EarTag };
                    ddSearchItems.DataSource = animal1.ToList ();
                    ddSearchItems.DataTextField = "EarTag";
                    ddSearchItems.DataValueField = "Animal_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");



                }


                if (ddSearch.Text == "Type")
                {

                    ddSearchItems.Items.Clear();
                    var type = from c in db.Breedings  select new {  c.Type };
                    ddSearchItems.DataSource = type.ToList();
                    ddSearchItems.DataTextField = "Type";
                    ddSearchItems.DataValueField = "Type";
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

        protected void ddSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "F_Animal")
                {
                    string tag = ddSearchItems.SelectedValue;
                    var form2 = from c in db.Breedings
                                where c.Animal_Id.ToString() == tag
                                select new
                                {
                                    F_Animal = c.Animal.EarTag,
                                    M_Animal = (int?)c.Animal1.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Type,
                                    c.Date,
                                    c.Dose,
                                 };
                    gvbreed2.DataSource = form2.ToList();
                    gvbreed2.DataBind();



                }
                if (ddSearch.Text == "M_Animal")
                {
                    string tag1 = ddSearchItems.SelectedValue;
                    var form22 = from c in db.Breedings
                                where c.Animal_Id_M.ToString() == tag1
                                select new
                                {
                                    F_Animal = c.Animal.EarTag,
                                    M_Animal = c.Animal1.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Type,
                                    c.Date,
                                 };
                    gvbreed2.DataSource = form22.ToList();
                    gvbreed2.DataBind();



                }

                if (ddSearch.Text == "Type")
                {
                    string type = ddSearchItems.SelectedValue;
                    var form33 = from c in db.Breedings
                                where c.Type == type
                                select new
                                {
                                    F_Animal = c.Animal.EarTag,
                                    M_Animal = (int?)c.Animal1.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Type,
                                    c.Date,
                                    c.Dose,
                                };
                    gvbreed2.DataSource = form33.ToList();
                    gvbreed2.DataBind();



                }



                if (ddSearch.Text == "User")
                {
                    string uname = ddSearchItems.SelectedValue;
                    var form3 = from c in db.Breedings
                                where c.User_Id.ToString() == uname
                                select new
                                {
                                    F_Animal = c.Animal.EarTag,
                                    M_Animal= (int?)c.Animal1.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Type,
                                    c.Date,
                                    c.Dose,
                                };
                    gvbreed2.DataSource = form3.ToList();
                    gvbreed2.DataBind();



                }

                
                gvbreed.Visible = false;
                gvbreed2.Visible = true;

            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch(Exception en)
            {
                Response.Redirect("Breeding_View.aspx");
            }
            gvbreed.Visible = true;
            gvbreed2.Visible = false;

        }

        protected void gvbreed_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get Animal_Id and User_Id of edit able row

            string Animal_Id = gvbreed.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
            var Animal_Id_M_check = gvbreed.DataKeys[e.NewEditIndex]["Animal_Id_M"];
            string Animal_Id_M = "";
            if (Animal_Id_M_check != null)
            {
                 Animal_Id_M = gvbreed.DataKeys[e.NewEditIndex]["Animal_Id_M"].ToString();
            }
           
            string User_Id = gvbreed.DataKeys[e.NewEditIndex]["User_Id"].ToString();

            gvbreed.EditIndex = e.NewEditIndex;
            PopulateBreedings();
            populateGridView();
            DropDownList ddTag = (DropDownList)gvbreed.Rows[e.NewEditIndex].FindControl("ddTag");
            DropDownList ddTag1 = (DropDownList)gvbreed.Rows[e.NewEditIndex].FindControl("ddTag1");

            DropDownList ddUName = (DropDownList)gvbreed.Rows[e.NewEditIndex].FindControl("ddUName");

            if ( ddTag1!=null && ddTag != null && ddUName != null)
            {
                BindAnimal(ddTag );
                ddTag.SelectedValue = Animal_Id;
                BindAnimal1(ddTag1 );
                ddTag1.SelectedValue = Animal_Id_M;
                BindAspNetUser(ddUName, PopulateAspNetUser());
                ddUName.SelectedValue = User_Id;
            }

        }

        protected void gvbreed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Breeding_Id = (int)gvbreed.DataKeys[e.RowIndex]["Breeding_Id"];
            DropDownList ddTag = (DropDownList)gvbreed.Rows[e.RowIndex].FindControl("ddTag");
            DropDownList ddTag1 = (DropDownList)gvbreed.Rows[e.RowIndex].FindControl("ddTag1");

            DropDownList ddUName = (DropDownList)gvbreed.Rows[e.RowIndex].FindControl("ddUName");
            TextBox txtDate = (TextBox)gvbreed.Rows[e.RowIndex].FindControl("txtDate");
             DropDownList ddtype = (DropDownList)gvbreed.Rows[e.RowIndex].FindControl("ddtype");
            TextBox txtdose = (TextBox)gvbreed.Rows[e.RowIndex].FindControl("txtdose");

            using (Entities db = new Entities())
            {
                var v = db.Breedings.Where(a => a.Breeding_Id == Breeding_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Animal_Id = int.Parse(ddTag.SelectedValue);
                    if(ddTag1.SelectedValue != "NA")
                    {
                        v.Animal_Id_M = int.Parse(ddTag1.SelectedValue);

                    }
                    else
                    {
                        v.Animal_Id_M = null;
                    }
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                             System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    v.User_Id = ddUName.SelectedValue;
                    v.Type = ddtype.SelectedValue;
                    v.Dose = txtdose.Text;

                }

                db.SaveChanges();
                gvbreed.EditIndex = -1;
                PopulateBreedings();
                populateGridView();

            }

        }

        protected void gvbreed_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Breeding_Id = (int)gvbreed.DataKeys[e.RowIndex]["Breeding_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Breedings.Where(a => a.Breeding_Id.Equals(Breeding_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Breedings.Remove(v);
                    db.SaveChanges();
                    PopulateBreedings();
                    populateGridView();

                }
            }

        }

        protected void gvbreed_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvbreed.EditIndex = -1;
            PopulateBreedings();
            populateGridView();

        }

        void showBreed()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, Date), COUNT(Breeding_Id) FROM Breeding GROUP BY DATENAME(MONTH, Date)", con);

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