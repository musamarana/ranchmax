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
    public partial class Milk_Sale_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showMilk();
            if (!IsPostBack)
            {
                PopulateMilk_Sales();

                populateGridView();

                
            }


        }

        void populateGridView()
        {
            Label23.Visible = false;
            using (Entities db = new Entities())
            {
                gvSale.DataSource = db.MilkBuyers.ToList<MilkBuyer>();
                gvSale.DataBind();

                var q = (from e in db.MilkBuyers select e.Rate).Sum();

                Label22.Text = "Total: " + q + "\n";


            }

        }
        //FUNCTION TO POPULATE Milk sale  

        private void PopulateMilk_Sales()
        {
            List<MilkBuyer> allMilk_Sales = null;
            using (Entities db = new Entities())
            {
                var sale = (from a in db.MilkBuyers
                            join b in db.Buyers
                            on a.Buyer_Id equals b.Buyer_Id

                            select new
                            {
                                a,
                                b.Name


                            });
                if (sale != null)
                {
                    allMilk_Sales = new List<MilkBuyer>();
                    foreach (var i in sale)
                    {
                        MilkBuyer c = i.a;
                        c.Name = i.Name;
                        allMilk_Sales.Add(c);

                    }

                }
                else
                {
                    gvSale.DataSource = allMilk_Sales;
                    gvSale.DataBind();
                }

            }
        }

        //function to fetch Buyer name from  database
        private List<Buyer> PopulateBuyer()
        {
            using (Entities db = new Entities())
            {

                return db.Buyers.OrderBy(a => a.Name).ToList();
            }
        }

        //function to bind buyer name to dropdownlist

        private void BindBuyer(DropDownList ddBName, List<Buyer> buyer)
        {
            ddBName.Items.Clear();
            ddBName.Items.Add(new ListItem { Text = "Select Buyer", Value = "0" });
            ddBName.AppendDataBoundItems = true;
            ddBName.DataValueField = "Buyer_Id";
            ddBName.DataTextField = "Name";
            ddBName.DataSource = buyer;
            ddBName.DataBind();

        }

        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Buyer")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.Buyers.ToList<Buyer>();
                    ddSearchItems.DataTextField = "Name";
                    ddSearchItems.DataValueField = "Buyer_Id";
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

                if (ddSearch.Text == "Buyer")
                {

                    string name = ddSearchItems.SelectedValue;
                    var form = from c in db.MilkBuyers
                               where c.Buyer_Id
                               .ToString() == name
                               select new
                               {
                                   c.Buyer.Name,
                                   c.Quantity,
                                   c.DateTime,
                                   c.Rate

                               };
                    gvSale2.DataSource = form.ToList();
                    gvSale2.DataBind();



                }

                gvSale.Visible = false;
                gvSale2.Visible = true;
                Label22.Visible = false;
                Label23.Visible = true;


                int total;
                int totalMarks = 0;

                foreach (GridViewRow row in gvSale2.Rows)
                {

                    total = Convert.ToInt32(row.Cells[3].Text);

                    totalMarks = totalMarks + total;

                 }

                   Label23.Text = "Total: " + Convert.ToString(totalMarks) + "\n";


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
                Response.Redirect("Milk_Sale View.aspx");

            }
            gvSale.Visible = true;
            gvSale2.Visible = false;

        }
        protected void gvSale_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get buyer_Id  of edit able row

            string Buyer_Id = gvSale.DataKeys[e.NewEditIndex]["Buyer_Id"].ToString();
            gvSale.EditIndex = e.NewEditIndex;
            PopulateMilk_Sales();
            populateGridView();
            DropDownList ddBuyer = (DropDownList)gvSale.Rows[e.NewEditIndex].FindControl("ddBuyer");
            //DropDownList ddSlot = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddSlot");
            //TextBox txtDate = (TextBox)gvFeedCon.Rows[e.NewEditIndex].FindControl("txtDate");

            if (ddBuyer != null)
            {
                BindBuyer(ddBuyer, PopulateBuyer());
                ddBuyer.SelectedValue = Buyer_Id;
                //  ddSlot.SelectedValue =ddSlot.DataValueField ;
                //txtDate.Text= txtDate.Text;         
            }

        }

        protected void gvSale_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int MilkBuyer_Id = (int)gvSale.DataKeys[e.RowIndex]["MilkBuyer_Id"];
            DropDownList ddBuyer = (DropDownList)gvSale.Rows[e.RowIndex].FindControl("ddBuyer");
            TextBox txtQty = (TextBox)gvSale.Rows[e.RowIndex].FindControl("txtQty");
            TextBox txtRate = (TextBox)gvSale.Rows[e.RowIndex].FindControl("txtRate");
            TextBox txtDate = (TextBox)gvSale.Rows[e.RowIndex].FindControl("txtDate");

            using (Entities db = new Entities())
            {
                var v = db.MilkBuyers.Where(a => a.MilkBuyer_Id == MilkBuyer_Id).FirstOrDefault();


                if (v != null)
                {
                    v.Buyer_Id = int.Parse(ddBuyer.SelectedValue);
                    v.Quantity = double.Parse(txtQty.Text);
                    if (txtRate.Text != "")
                    {
                        v.Rate = int.Parse(txtRate.Text);

                    }
                    else
                    {
                        v.Rate = null;
                    }
                        string dateString = txtDate.Text;
                    v.DateTime = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    //v.DateTime = DateTime.Parse(txtDate.Text);
                }

                db.SaveChanges();
                gvSale.EditIndex = -1;
                PopulateMilk_Sales();
                populateGridView();

            }

        }

        protected void gvSale_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int MilkBuyer_Id = (int)gvSale.DataKeys[e.RowIndex]["MilkBuyer_Id"];
            using (Entities db = new Entities())
            {
                var v = db.MilkBuyers.Where(a => a.MilkBuyer_Id.Equals(MilkBuyer_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.MilkBuyers.Remove(v);
                    db.SaveChanges();
                    PopulateMilk_Sales();
                    populateGridView();

                }
            }

        }

        protected void gvSale_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvSale.EditIndex = -1;
            PopulateMilk_Sales();
            populateGridView();

        }

        void showMilk()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DateTime, ISNULL(SUM(Quantity),0) FROM MilkBuyer GROUP BY (DateTime)", con);

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