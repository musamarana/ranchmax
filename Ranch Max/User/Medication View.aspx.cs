using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class Medication_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateMedications();

                populateGridView();
            }
        }

        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvMedCon.DataSource = db.Medications.ToList<Medication>();
                gvMedCon.DataBind();

            }

        }

        //FUNCTION TO POPULATE Medication  

        private void PopulateMedications()
        {
            List<Medication> allMedications = null;
            using (Entities db = new Entities())
            {
                var cons = (from a in db.Medications
                            join b in db.StockItems
                            on a.StockItem_Id equals b.StockItem_Id
                            join c in db.AspNetUsers on a.User_Id equals c.Id
                            join d in db.Animals on a.Animal_Id equals d.Animal_Id
                            select new
                            {
                                a,
                                b.Name,
                                c.UserName,
                                d.EarTag

                            });
                if (cons != null)
                {
                    allMedications = new List<Medication>();
                    foreach (var i in cons)
                    {
                        Medication c = i.a;
                        c.Name = i.Name;
                        c.UserName = i.UserName;
                        c.EarTag = i.EarTag.ToString();
                        allMedications.Add(c);

                    }

                }
                else
                {
                    gvMedCon.DataSource = allMedications;
                    gvMedCon.DataBind();
                }

            }
        }


        //function to fetch Medicine name from  database
        private List<StockItem> PopulateStockItem()
        {
            using (Entities db = new Entities())
            {
               // var med = from c in db.StockItems where c.StockType == "Medicine" orderby (c.Name).ToList() select new {c.Name} ;
                //return med ;

                return db.StockItems.OrderBy(a => a.Name).ToList();
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

        //function to bind StockItem to dropdownlist

        private void BindStockItem(DropDownList ddMName, List<StockItem> stock)
        {
            ddMName.Items.Clear();
            ddMName.Items.Add(new ListItem { Text = "Select Medicine", Value = "0" });
            ddMName.AppendDataBoundItems = true;
            ddMName.DataValueField = "StockItem_Id";
            ddMName.DataTextField = "Name";
            ddMName.DataSource = stock;
            ddMName.DataBind();

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

        private void BindAnimal(DropDownList ddBreed, List<Animal> animal)
        {
            ddBreed.Items.Clear();
            ddBreed.Items.Add(new ListItem { Text = "Select Animal", Value = "0" });
            ddBreed.AppendDataBoundItems = true;
            ddBreed.DataValueField = "Animal_Id";
            ddBreed.DataTextField = "EarTag";
            ddBreed.DataSource = animal;
            ddBreed.DataBind();

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

                else if (ddSearch.Text == "Medicine")
                {
                    ddSearchItems.Items.Clear();
                    var med = from c in db.StockItems where c.StockType.TypeName == "Medicine" select new { c.StockItem_Id, c.Name };

                    ddSearchItems.DataSource =med.ToList();
                    ddSearchItems.DataTextField = "Name";
                    ddSearchItems.DataValueField = "StockItem_Id";
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

                if (ddSearch.Text == "Medicine")
                {

                    string name = ddSearchItems.SelectedValue;
                    var form = from c in db.Medications
                               where c.StockItem_Id
                               .ToString() == name
                               select new
                               {
                                   c.StockItem.Name,
                                   c.Animal.EarTag,
                                   c.AspNetUser.UserName,
                                   c.Quantity,
                                   c.Unit,
                                   c.Method,
                                   c.Date,
                                   c.Time

                               };
                    gvCon.DataSource = form.ToList();
                    gvCon.DataBind();



                }

                if (ddSearch.Text == "Animal")
                {
                    string tag = ddSearchItems.SelectedValue;
                    var form2 = from c in db.Medications
                                where c.Animal_Id.ToString() == tag
                                select new
                                {
                                    c.StockItem.Name,
                                    c.Animal.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Quantity,
                                    c.Unit,
                                    c.Method,
                                    c.Date,
                                    c.Time
                                };
                    gvCon.DataSource = form2.ToList();
                    gvCon.DataBind();



                }

                if (ddSearch.Text == "User")
                {
                    string uname = ddSearchItems.SelectedValue;
                    var form3 = from c in db.Medications
                                where c.User_Id.ToString() == uname
                                select new
                                {
                                    c.StockItem.Name,
                                    c.Animal.EarTag,
                                    c.AspNetUser.UserName,
                                    c.Quantity,
                                    c.Unit,
                                    c.Method,
                                    c.Date,
                                    c.Time
                                };
                    gvCon.DataSource = form3.ToList();
                    gvCon.DataBind();



                }

                gvMedCon.Visible = false;
                gvCon.Visible = true;

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
                Response.Redirect("Medication View.aspx");
            }
            gvMedCon.Visible = true;
            gvCon.Visible = false;

        }

        protected void gvMedCon_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get StockItem_Id,Animal_Id and User_Id of edit able row

            string StockItem_Id = gvMedCon.DataKeys[e.NewEditIndex]["StockItem_Id"].ToString();
            string Animal_Id = gvMedCon.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
            string User_Id = gvMedCon.DataKeys[e.NewEditIndex]["User_Id"].ToString();
            gvMedCon.EditIndex = e.NewEditIndex;
            PopulateMedications();
            populateGridView();
            DropDownList ddMName = (DropDownList)gvMedCon.Rows[e.NewEditIndex].FindControl("ddMName");
            DropDownList ddBreed = (DropDownList)gvMedCon.Rows[e.NewEditIndex].FindControl("ddBreed");
            DropDownList ddUName = (DropDownList)gvMedCon.Rows[e.NewEditIndex].FindControl("ddUName");
            //DropDownList ddSlot = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddSlot");
            //TextBox txtDate = (TextBox)gvFeedCon.Rows[e.NewEditIndex].FindControl("txtDate");

            if (ddMName != null && ddBreed != null && ddUName != null)
            {
                BindStockItem(ddMName, PopulateStockItem());
                ddMName.SelectedValue = StockItem_Id;
                BindAnimal(ddBreed, PopulateAnimal());
                ddBreed.SelectedValue = Animal_Id;
                BindAspNetUser(ddUName, PopulateAspNetUser());
                ddUName.SelectedValue = User_Id;
                //  ddSlot.SelectedValue =ddSlot.DataValueField ;
                //txtDate.Text= txtDate.Text;         
            }

        }

        protected void gvMedCon_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int Medication_Id = (int)gvMedCon.DataKeys[e.RowIndex]["Medication_Id"];
            DropDownList ddMName = (DropDownList)gvMedCon.Rows[e.RowIndex].FindControl("ddMName");
            DropDownList ddBreed = (DropDownList)gvMedCon.Rows[e.RowIndex].FindControl("ddBreed");
            DropDownList ddUName = (DropDownList)gvMedCon.Rows[e.RowIndex].FindControl("ddUName");
            TextBox txtQty = (TextBox)gvMedCon.Rows[e.RowIndex].FindControl("txtQty");
            DropDownList ddUnit = (DropDownList)gvMedCon.Rows[e.RowIndex].FindControl("ddUnit");
            DropDownList ddMethod = (DropDownList)gvMedCon.Rows[e.RowIndex].FindControl("ddMethod");
            TextBox txtDate = (TextBox)gvMedCon.Rows[e.RowIndex].FindControl("txtDate");
            TextBox txttime = (TextBox)gvMedCon.Rows[e.RowIndex].FindControl("txttime");

            using (Entities db = new Entities())
            {
                var v = db.Medications.Where(a => a.Medication_Id == Medication_Id).FirstOrDefault();


                if (v != null)
                {
                    v.StockItem_Id = int.Parse(ddMName.SelectedValue);
                    v.Animal_Id = int.Parse(ddBreed.SelectedValue);
                    v.User_Id = ddUName.SelectedValue;
                    v.Quantity = int.Parse(txtQty.Text);
                    v.Unit = ddUnit.SelectedItem.Value;
                    v.Method = ddMethod.SelectedValue;
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    //v.Date = DateTime.Parse(txtDate.Text);
                    if (txttime.Text != "") { 
                    v.Time = TimeSpan.Parse(txttime.Text);
                    }
                    else
                    {
                        v.Time = null;
                    }
                }

                db.SaveChanges();
                gvMedCon.EditIndex = -1;
                PopulateMedications();
                populateGridView();

            }

        }

        protected void gvMedCon_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Medication_Id = (int)gvMedCon.DataKeys[e.RowIndex]["Medication_Id"];
            using (Entities db = new Entities())
            {
                var v = db.Medications.Where(a => a.Medication_Id.Equals(Medication_Id)).FirstOrDefault();
                if (v != null)
                {
                    db.Medications.Remove(v);
                    db.SaveChanges();
                    PopulateMedications();
                    populateGridView();

                }
            }


        }

        protected void gvMedCon_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedCon.EditIndex = -1;
            PopulateMedications();
            populateGridView();

        }
    }
}