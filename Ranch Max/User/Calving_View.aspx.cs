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
    public partial class Calving_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            numberShow();
            statusShow();

            if (!IsPostBack)
            {
                PopulateCalvings();

                populateGridView();
                //Chart1.Visible = false;
                //Chart2.Visible = false;
            }

        }
        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvCalve.DataSource = db.Calvings.ToList<Calving>();
                gvCalve.DataBind();

            }

        }


        //FUNCTION TO POPULATE CALVING

        private void PopulateCalvings()
        {
            List<Calving> allCalvings = null;
            using (Entities db = new Entities())
            {
                var calv = (from a in db.Calvings
                            join d in db.Animals on a.Animal_Id equals d.Animal_Id
                            select new
                           {
                               a,
                               d.EarTag

                           });
                if (calv != null)
                {
                    allCalvings = new List<Calving>();
                    foreach (var i in calv)
                    {
                        Calving c = i.a;
                        c.EarTag = i.EarTag.ToString();
                        allCalvings.Add(c);

                    }

                }
                else
                {
                    gvCalve.DataSource = allCalvings;
                    gvCalve.DataBind();


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
            //Chart1.Visible = false;

            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Animal")
                {
                    string tag = ddSearchItems.SelectedValue;
                    var form2 = from c in db.Calvings
                                where c.Animal_Id.ToString() == tag
                                select new
                                {
                                    c.Animal.EarTag,
                                    c.Date,
                                    c.Gender,
                                    c.Status,
                                    c.Weight
                                };
                    gvCalve2.DataSource = form2.ToList();
                    gvCalve2.DataBind();



                }
                gvCalve.Visible = false;
                gvCalve2.Visible = true;

            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Chart1.Visible = true;
            //Chart2.Visible = true;

            ddSearch.SelectedIndex = 0;
            try
            {
                ddSearchItems.SelectedIndex = 0;
            }
            catch (Exception et)
            {
                Response.Redirect("Calving_View.aspx");
            }
            gvCalve.Visible = true;
            gvCalve2.Visible = false;

            

        }

        protected void gvCalve_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //get Animal_Id and User_Id of edit able row
           


            string Animal_Id = gvCalve.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
             gvCalve.EditIndex = e.NewEditIndex;
            PopulateCalvings();
            populateGridView();
            DropDownList ddTag = (DropDownList)gvCalve.Rows[e.NewEditIndex].FindControl("ddTag");
 
            if (ddTag != null )
            {
                BindAnimal(ddTag, PopulateAnimal());
                ddTag.SelectedValue = Animal_Id;
             }

        }

        protected void gvCalve_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Calving_Id = (int)gvCalve.DataKeys[e.RowIndex]["Calving_Id"];
            DropDownList ddTag = (DropDownList)gvCalve.Rows[e.RowIndex].FindControl("ddTag");
             TextBox txtDate = (TextBox)gvCalve.Rows[e.RowIndex].FindControl("txtDate");
            DropDownList ddGender = (DropDownList)gvCalve.Rows[e.RowIndex].FindControl("ddGender");
            DropDownList ddStatus = (DropDownList)gvCalve.Rows[e.RowIndex].FindControl("ddStatus");
            TextBox txtWeight = (TextBox)gvCalve.Rows[e.RowIndex].FindControl("txtWeight");

            using (Entities db = new Entities())
            {
                var v = db.Calvings.Where(a => a.Calving_Id == Calving_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Animal_Id = int.Parse(ddTag.SelectedValue);
                    // v.Date = DateTime.Parse(txtDate.Text);
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    v.Gender = ddGender.SelectedValue;
                    v.Status = ddStatus.SelectedValue;
                    if (txtWeight.Text != "")
                    {
                        v.Weight = int.Parse(txtWeight.Text);
                    }
                    else
                    {
                        v.Weight = null;
                    }

                }

                db.SaveChanges();
                gvCalve.EditIndex = -1;
                PopulateCalvings();
                populateGridView();

            }

        }

        protected void gvCalve_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Calving_Id = (int)gvCalve.DataKeys[e.RowIndex]["Calving_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Calvings.Where(a => a.Calving_Id.Equals(Calving_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Calvings.Remove(v);
                    db.SaveChanges();
                    PopulateCalvings();
                    populateGridView();

                }
            }

        }

        protected void gvCalve_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCalve.EditIndex = -1;
            PopulateCalvings();
            populateGridView();
        }

        void numberShow()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, Date), COUNT(Calving_Id) FROM Calving GROUP BY DATENAME(MONTH, Date)", con);

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

        void statusShow()
        {
            SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
            SqlCommand com = new SqlCommand("SELECT Status, COUNT(Status) AS Stat FROM Calving GROUP BY(Status)", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            string[] XAxis = new string[dt.Rows.Count];
            int[] YAxis = new int[dt.Rows.Count];

            for (int c = 0; c < dt.Rows.Count; c++)
            {
                XAxis[c] = dt.Rows[c]["Status"].ToString();
                YAxis[c] = Convert.ToInt32(dt.Rows[c]["Stat"]);
            }

            Chart2.Series[0].Points.DataBindXY(XAxis, YAxis);

            Chart2.Series[0].BorderWidth = 10;

            Chart2.Series[0].ChartType = SeriesChartType.Pie;

            foreach (Series chart in Chart2.Series)
            {
                foreach (DataPoint dp in chart.Points)
                {
                    switch (dp.AxisLabel)
                    {
                        case "Alive":
                            dp.Color = Color.Blue;
                            break;
                        case "Dead":
                            dp.Color = Color.Red;
                            break;
                    }
                    dp.Label = string.Format("{1}", dp.YValues[0], dp.AxisLabel);
                }
            }
            con.Close();
        }
    }
}