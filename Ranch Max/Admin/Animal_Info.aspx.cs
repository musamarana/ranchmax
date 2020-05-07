using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max.User
{
    public partial class Animal_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void grid()
        {

            Entities db = new Entities();

            ///////////////////for feed consumption per animal////////////

            ////for per formula rate
            var FormulaRate = db.FeedPreparings
                   .GroupBy(p => p.Formula_Id)
                   .Select(g => new { formula_Id = g.Key, Rate = g.Sum(x => x.Rate) });
            //for formula name
            var PerFormulaRate = from a in db.FeedFormulas
                                 join b in FormulaRate on a.Formula_Id equals b.formula_Id
                                 select new
                                 {
                                     a.FormulaName,
                                     b.Rate
                                 };
            gvFormula.DataSource = PerFormulaRate.ToList();
            gvFormula.DataBind();

            string tag1 = ddType.SelectedValue;

            var form22 = from c in db.FeedConsumptions
                         join a in FormulaRate on c.Formula_Id equals a.formula_Id

                         where c.Animal_Id.ToString() == tag1

                         select new
                         {
                             c.Date,
                             c.FeedFormula.FormulaName,
                             c.Slot,
                             c.Animal.EarTag,
                             Rate = a.Rate
                         };
            GvCon2.DataSource = form22.ToList();
            GvCon2.DataBind();

            int total1;
            int totalRate1 = 0;

            foreach (GridViewRow row in GvCon2.Rows)
            {

                total1 = Convert.ToInt32(row.Cells[4].Text);

                totalRate1 = totalRate1 + total1;

            }

            Label2.Text = "Total: " + Convert.ToString(totalRate1) + "\n";


            ///////////////////for medication consumption per animal////////////

            var adds = db.StockAdds.GroupBy(p => p.StockItem_Id)
                .Select(g => new { stockitem_id = g.Key, amnt = g.Sum(x => x.Amount), qty = g.Sum(y => y.Quantity) });
            //GridView1.DataSource = adds.ToList();
            //GridView1.DataBind();

            string tag = ddType.SelectedValue;

            var form2 = from c in db.Medications
                        join a in adds on c.StockItem_Id equals a.stockitem_id

                        where c.Animal_Id.ToString() == tag

                        select new
                        {
                            c.Date,
                            c.StockItem.Name,
                            c.Quantity,
                            c.Animal.EarTag,
                            Rate = (a.amnt / a.qty) * c.Quantity
                        };
            gvCon.DataSource = form2.ToList();
            gvCon.DataBind();

            //GridView2.DataSource = form2.ToList();
            //GridView2.DataBind();

            int total;
            int totalRate = 0;

            foreach (GridViewRow row in gvCon.Rows)
            {

                total = Convert.ToInt32(row.Cells[4].Text);

                totalRate = totalRate + total;

            }

            Label22.Text = "Total: " + Convert.ToString(totalRate) + "\n";

            //showing total consumption per animal
            Label3.Text = Convert.ToString(totalRate + totalRate1);

            //showing price of animal
            string price = ddType.SelectedValue;
            var animalPrice = from c in db.Animals
                              where c.Animal_Id.ToString() == price
                              select new
                              {
                                  c.Price
                              };
            Label4.Text = animalPrice.First().Price.ToString();

            //showing selling  price of animal
            string sell_price = ddType.SelectedValue;
            var animalSellPrice = from c in db.AnimalSales
                                  where c.Animal_Id.ToString() == sell_price
                                  select new
                                  {
                                      c.Amount
                                  };

            var pp1 = db.AnimalSales.Where(p => p.Animal_Id.ToString() == sell_price).Select(q => q.Animal_Id).FirstOrDefault().ToString();


            // var pp = (from a in db.AnimalSales select a.Animal_Id).FirstOrDefault().ToString();
            if (sell_price != pp1)
            {
                Label5.Text = "Not Sold Yet";

            }
            else
            {
                Label5.Text = animalSellPrice.FirstOrDefault().Amount.ToString();
            }
        }




        protected void Button2_Click(object sender, EventArgs e)
        {
            ddSearch.SelectedIndex = 0;
            try
            {
                ddType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Response.Redirect("Animal_Info.aspx");
            }

            gvFormula.Visible = false;
            gvCon.Visible = false;
            GvCon2.Visible = false;
            Label2.Visible = false;
            Label22.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
        }
        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Animal")
                {
                    ddType.Items.Clear();
                    ddType.DataSource = db.Animals.ToList<Animal>();
                    ddType.DataTextField = "EarTag";
                    ddType.DataValueField = "Animal_Id";
                    ddType.DataBind();

                    ddType.Items.Insert(0, "--Select--");
                }
            }
        }

        [Obsolete]
        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {

                if (ddSearch.Text == "Animal")
                {
                    grid();
                }
            }
        }
    }
}