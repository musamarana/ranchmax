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
    public partial class Animal_Sale_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showSale();
            if (!IsPostBack)
            {
                PopulateAnimalSales();

                populateGridView();
            }


        }
        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvAniSale.DataSource = db.AnimalSales.ToList<AnimalSale>();
                gvAniSale.DataBind();

            }

        }

        //FUNCTION TO POPULATE Animal sale  

        private void PopulateAnimalSales()
        {
            List<AnimalSale> allAnimalSales = null;
            using (Entities db = new Entities())
            {
                var Anisale = (from a in db.AnimalSales
                                  join b in db.Animals
                                  on a.Animal_Id equals b.Animal_Id

                                  select new
                                  {
                                      a,
                                      b.EarTag


                                  });
                if (Anisale != null)
                {
                    allAnimalSales = new List<AnimalSale>();
                    foreach (var i in Anisale)
                    {
                        AnimalSale c = i.a;
                        c.EarTag = i.EarTag;
                        allAnimalSales.Add(c);

                    }

                }
                else
                {
                    gvAniSale.DataSource = allAnimalSales;
                    gvAniSale.DataBind();
                }

            }
        }




        //function to fetch animal from  database
        private List<Animal> PopulateAnimal()
        {
            using (Entities db = new Entities())
            {

                return db.Animals.OrderBy(a => a.EarTag).ToList();
            }
        }

        //function to bind Animal eartag to dropdownlist

        private void BindAnimal(DropDownList ddETag, List<Animal> animal)
        {
            ddETag.Items.Clear();
            ddETag.Items.Add(new ListItem { Text = "Select Animal", Value = "0" });
            ddETag.AppendDataBoundItems = true;
            ddETag.DataValueField = "Animal_Id";
            ddETag.DataTextField = "EarTag";
            ddETag.DataSource = animal;
            ddETag.DataBind();

        }

        protected void gvAniSale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get Animal_id  of edit able row

            string Animal_Id = gvAniSale.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
            gvAniSale.EditIndex = e.NewEditIndex;
            PopulateAnimalSales();
            populateGridView();
            DropDownList ddETag = (DropDownList)gvAniSale.Rows[e.NewEditIndex].FindControl("ddETag");

            if (ddETag != null)
            {
                BindAnimal(ddETag, PopulateAnimal());
                ddETag.SelectedValue = Animal_Id;

            }

        }

        protected void gvAniSale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int AnimalSale_Id = (int)gvAniSale.DataKeys[e.RowIndex]["AnimalSale_Id"];
            DropDownList ddETag = (DropDownList)gvAniSale.Rows[e.RowIndex].FindControl("ddETag");
            TextBox txtAmnt = (TextBox)gvAniSale.Rows[e.RowIndex].FindControl("txtAmnt");
            TextBox txtBuyerName = (TextBox)gvAniSale.Rows[e.RowIndex].FindControl("txtBuyerName");
            TextBox txtBuyerCnic = (TextBox)gvAniSale.Rows[e.RowIndex].FindControl("txtBuyerCnic");
            TextBox txtDate = (TextBox)gvAniSale.Rows[e.RowIndex].FindControl("txtDate");

            using (Entities db = new Entities())
            {
                var v = db.AnimalSales.Where(a => a.AnimalSale_Id == AnimalSale_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Animal_Id = int.Parse(ddETag.SelectedValue);
                    v.Amount = int.Parse(txtAmnt.Text);
                    if (txtBuyerName.Text != "") { 
                    v.BuyerName = txtBuyerName.Text;
                    }
                    else
                    {
                        v.BuyerName = null;
                    }
                    if (txtBuyerCnic.Text != "")
                    {
                        v.CNIC = txtBuyerCnic.Text;

                    }
                    else
                    {
                        v.CNIC = null;
                    }
                    if (txtDate.Text != "") { 
                    //v.Date = DateTime.Parse(txtDate.Text);
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    }
                    else
                    {
                        v.Date = null;
                    }
                }

                db.SaveChanges();
                gvAniSale.EditIndex = -1;
                PopulateAnimalSales();
                populateGridView();

            }

        }

        protected void gvAniSale_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int AnimalSale_Id = (int)gvAniSale.DataKeys[e.RowIndex]["AnimalSale_Id"];
            using (Entities db = new Entities())
            {
                var v = db.AnimalSales.Where(a => a.AnimalSale_Id.Equals(AnimalSale_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.AnimalSales.Remove(v);
                    db.SaveChanges();
                    PopulateAnimalSales();
                    populateGridView();

                }
            }

        }

        protected void gvAniSale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAniSale.EditIndex = -1;
            PopulateAnimalSales();
            populateGridView();

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

                    string animal = ddSearchItems.SelectedValue;
                    var form = from c in db.AnimalSales
                               where c.Animal_Id
                               .ToString() == animal
                               select new
                               {
                                   c.Animal.EarTag,
                                   c.Amount,
                                   c.BuyerName,
                                   c.CNIC,
                                   c.Date

                               };
                    gvAniSale2.DataSource = form.ToList();
                    gvAniSale2.DataBind();



                }

                gvAniSale.Visible = false;
                gvAniSale2.Visible = true;

            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ddSearch.Text == "0" && ddSearchItems.Text == "0")
            {
                Response.Redirect("~/ Animal_Sale View.aspx");

            }
            ddSearch.SelectedIndex = 0;
            ddSearchItems.SelectedValue = "--Select--";
            gvAniSale.Visible = true;
            gvAniSale2.Visible = false;

        }

        void showSale()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DATENAME(MONTH, Date), COUNT(AnimalSale_Id) FROM AnimalSale GROUP BY DATENAME(MONTH, Date)", con);

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