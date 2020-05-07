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
    public partial class DryPeriod_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
            
        {
            showDry();

            if (!IsPostBack)
            {
                PopulateDryPeriods();

                populateGridView();
            }

        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvDry.DataSource = db.DryPeriods.ToList<DryPeriod>();
                gvDry.DataBind();

            }

        }


        //FUNCTION TO POPULATE Dry Period

        private void PopulateDryPeriods()
        {
            List<DryPeriod> allDryPeriods = null;
            using (Entities db = new Entities())
            {
                var dry = (from a in db.DryPeriods

                           join d in db.Animals on a.Animal_Id equals d.Animal_Id
                           select new
                           {
                               a,
                               d.EarTag

                           });
                if (dry != null)
                {
                    allDryPeriods = new List<DryPeriod>();
                    foreach (var i in dry)
                    {
                        DryPeriod c = i.a;
                        c.EarTag = i.EarTag.ToString();
                        allDryPeriods.Add(c);

                    }

                }
                else
                {
                    gvDry.DataSource = allDryPeriods;
                    gvDry.DataBind();


                }
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
                    var form2 = from c in db.DryPeriods
                                where c.Animal_Id.ToString() == tag
                                select new
                                {
                                    c.Animal.EarTag,
                                     c.StartDate,
                                    c.EndDate
                                };
                    gvDry2.DataSource = form2.ToList();
                    gvDry2.DataBind();



                }

                gvDry.Visible = false;
                gvDry2.Visible = true;

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch (Exception et)
            {
                Response.Redirect("DryPeriod_View.aspx");
            }
            gvDry.Visible = true;
            gvDry2.Visible = false;

        }

        protected void gvDry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get Animal_Id and User_Id of edit able row

             string Animal_Id = gvDry.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
             gvDry.EditIndex = e.NewEditIndex;
            PopulateDryPeriods();
            populateGridView();
             DropDownList ddTag = (DropDownList)gvDry.Rows[e.NewEditIndex].FindControl("ddTag");
              
            if ( ddTag != null  )
            {
                 BindAnimal(ddTag, PopulateAnimal());
                ddTag.SelectedValue = Animal_Id;
              }

        }

        protected void gvDry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Dry_Id = (int)gvDry.DataKeys[e.RowIndex]["Dry_Id"];
             DropDownList ddTag = (DropDownList)gvDry.Rows[e.RowIndex].FindControl("ddTag");
              TextBox txtSDate = (TextBox)gvDry.Rows[e.RowIndex].FindControl("txtSDate");
             TextBox txtEDate = (TextBox)gvDry.Rows[e.RowIndex].FindControl("txtEDate");

            using (Entities db = new Entities())
            {
                var v = db.DryPeriods.Where(a => a.Dry_Id == Dry_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Animal_Id = int.Parse(ddTag.SelectedValue);
                    string dateString = txtSDate.Text;
                    v.StartDate = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    //v.StartDate = DateTime.Parse(txtSDate.Text);

                    if (txtEDate.Text != "")
                    { 
                    string dateString1 = txtEDate.Text;
                    v.EndDate = Convert.ToDateTime(dateString1,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        //v.EndDate = DateTime.Parse(txtEDate.Text);
                    }
                    else
                    {
                        v.EndDate = null;
                    }
                }

                db.SaveChanges();
                gvDry.EditIndex = -1;
                PopulateDryPeriods();
                populateGridView();

            }

        }

        protected void gvDry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Dry_Id = (int)gvDry.DataKeys[e.RowIndex]["Dry_Id"];
            using (Entities db = new Entities())
            {
                var v = db.DryPeriods.Where(a => a.Dry_Id.Equals(Dry_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.DryPeriods.Remove(v);
                    db.SaveChanges();
                    PopulateDryPeriods();
                    populateGridView();

                }
            }


        }

        protected void gvDry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDry.EditIndex = -1;
            PopulateDryPeriods();
            populateGridView();
        }

        void showDry()
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, StartDate), COUNT(Animal_Id) FROM DryPeriod GROUP BY DATENAME(MONTH, StartDate)", con);

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
