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
using System.Drawing;

namespace Ranch_Max
{
    public partial class Animal_Detail : System.Web.UI.Page
    {
        string str, str2, str3;
        SqlCommand comm;

        protected void Page_Load(object sender, EventArgs e)
        {
            GenderChart();
            BreedChart();



            SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
            con.Open();
            str = "SELECT COUNT(Animal_Id) AS Stat FROM Animal";
            comm = new SqlCommand(str, con);
            SqlDataReader reader = comm.ExecuteReader();

            reader.Read();
            Label1.Text = reader["Stat"].ToString();


            reader.Close();
            con.Close();

            con.Open();
            str2 = "SELECT COUNT(Animal_Id) AS Stat1 FROM Animal WHERE Status = 'Active'";
            comm = new SqlCommand(str2, con);
            SqlDataReader reader2 = comm.ExecuteReader();
            reader2.Read();
            Label2.Text = reader2["Stat1"].ToString();
            reader2.Close();
            con.Close();

            con.Open();
            str3 = "SELECT COUNT(Animal_Id) AS Total FROM Animal WHERE DATEPART(m, InsertionDate) <= DATEPART(m, getdate())";
            comm = new SqlCommand(str3, con);
            SqlDataReader reader3 = comm.ExecuteReader();
            reader3.Read();
            Label3.Text = reader3["Total"].ToString();
            reader3.Close();
            con.Close();

        }

        void GenderChart()
        {
            SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947");
            SqlCommand com = new SqlCommand("SELECT Gender, COUNT(Gender) AS num FROM Animal GROUP BY(Gender)", con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            string[] XAxis = new string[dt.Rows.Count];
            int[] YAxis = new int[dt.Rows.Count];

            for (int c = 0; c < dt.Rows.Count; c++)
            {
                XAxis[c] = dt.Rows[c]["Gender"].ToString();
                YAxis[c] = Convert.ToInt32(dt.Rows[c]["num"]);
            }

            Chart1.Series[0].Points.DataBindXY(XAxis, YAxis);

            Chart1.Series[0].BorderWidth = 10;

            Chart1.Series[0].ChartType = SeriesChartType.Doughnut;

            foreach (Series chart in Chart1.Series)
            {
                foreach (DataPoint dp in chart.Points)
                {
                    switch (dp.AxisLabel)
                    {
                        case "M":
                            dp.Color = Color.Blue;
                            break;
                        case "F":
                            dp.Color = Color.Pink;
                            break;
                    }
                    dp.Label = string.Format("{0:0} - {1}", dp.YValues[0], dp.AxisLabel);
                }
            }
            con.Close();
        }

        void BreedChart()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=tcp:fypranchmax.database.windows.net,1433;Initial Catalog=DefaultConnection;User ID=fypranchmax@fypranchmax;Password=Pakistan_1947"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  AnimalBreed.Breed ,COUNT(Animal.Breed_Id) FROM Animal INNER JOIN AnimalBreed ON AnimalBreed.Breed_Id = Animal.Breed_Id GROUP BY(Breed)", con);

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



            Chart2.Series[0].Points.DataBindXY(x, y);
            Chart2.Series[0].ChartType = SeriesChartType.StackedColumn;


        }
    }
}