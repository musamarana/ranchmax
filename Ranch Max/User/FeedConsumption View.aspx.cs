using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ranch_Max
{
    public partial class FeedConsumption_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFeedConsumptions();

                populateGridView();
            }
        }
        void populateGridView()
        {
            using (Entities db = new Entities())
            {
                gvFeedCon.DataSource = db.FeedConsumptions.ToList<FeedConsumption>();
                gvFeedCon.DataBind();

            }

        }


        //FUNCTION TO POPULATE feed consumption

        private void PopulateFeedConsumptions()
        {
            List<FeedConsumption> allFeedConsumptions = null;
            using (Entities db = new Entities())
            {
                var cons = (from a in db.FeedConsumptions
                            join b in db.FeedFormulas
                            on a.Formula_Id equals b.Formula_Id
                            join c in db.AspNetUsers on a.User_Id equals c.Id
                            join d in db.Animals on a.Animal_Id equals d.Animal_Id
                            select new
                            {
                                a,
                                b.FormulaName,
                                c.UserName,
                                d.AnimalBreed.Breed

                            });
                if (cons != null)
                {
                    allFeedConsumptions = new List<FeedConsumption>();
                    foreach (var i in cons)
                    {
                        FeedConsumption c = i.a;
                        c.Name = i.FormulaName;
                        c.UserName = i.UserName;
                        c.Breed = i.Breed;
                        allFeedConsumptions.Add(c);

                    }

                }
                else
                {
                    gvFeedCon.DataSource = allFeedConsumptions;
                    gvFeedCon.DataBind();
                }

            }
        }

        //function to fetch Formula name from  database
        private List<FeedFormula> PopulateFeedFormula()
        {
            using (Entities db = new Entities())
            {
                return db.FeedFormulas.OrderBy(a => a.FormulaName).ToList();
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
        private List<AnimalBreed> PopulateAnimalBreed()

        {
            using (Entities db = new Entities())
            {
                return db.AnimalBreeds.OrderBy(a => a.Breed).ToList();
            }
        }

        //function to bind Feed Formula to dropdownlist

        private void BindFeedFormula(DropDownList ddFName, List<FeedFormula> formula)
        {
            ddFName.Items.Clear();
            ddFName.Items.Add(new ListItem { Text = "Select Formula", Value = "0" });
            ddFName.AppendDataBoundItems = true;
            ddFName.DataValueField = "Formula_Id";
            ddFName.DataTextField = "FormulaName";
            ddFName.DataSource = formula;
            ddFName.DataBind();

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

        private void BindAnimalBreed(DropDownList ddBreed, List<AnimalBreed> breed)
        {
            ddBreed.Items.Clear();
            ddBreed.Items.Add(new ListItem { Text = "Select Breed", Value = "0" });
            ddBreed.AppendDataBoundItems = true;
            ddBreed.DataValueField = "Breed_Id";
            ddBreed.DataTextField = "Breed";
            ddBreed.DataSource = breed;
            ddBreed.DataBind();

        }

         
        protected void ddSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {


                if (ddSearch.Text == "Breed")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.AnimalBreeds.ToList<AnimalBreed>();
                    ddSearchItems.DataTextField = "Breed";
                    ddSearchItems.DataValueField = "Breed_Id";
                    ddSearchItems.DataBind();

                    ddSearchItems.Items.Insert(0, "--Select--");



                }

                else if (ddSearch.Text == "Formula")
                {
                    ddSearchItems.Items.Clear();
                    ddSearchItems.DataSource = db.FeedFormulas.ToList<FeedFormula>();
                    ddSearchItems.DataTextField = "FormulaName";
                    ddSearchItems.DataValueField = "Formula_Id";
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

                if (ddSearch.Text == "Formula")
                {
                     
                    string name = ddSearchItems.SelectedValue;
                    var form = from c in db.FeedConsumptions
                                    where c.Formula_Id.ToString() == name
                                    select new
                                    {
                                        c.FeedFormula.FormulaName,
                                        c.Animal.AnimalBreed.Breed,
                                        c.AspNetUser.UserName,
                                        c.Slot,
                                        c.Date
                                         
                                    };
                    gvCon.DataSource = form.ToList();
                    gvCon.DataBind();



                }

                if (ddSearch.Text == "Breed")
                {
                    string breed = ddSearchItems.SelectedValue;
                    var form2 = from c in db.FeedConsumptions
                                    where c.Animal_Id.ToString() == breed
                                    select new
                                    {
                                        c.FeedFormula.FormulaName,
                                        c.Animal.AnimalBreed.Breed,
                                        c.AspNetUser.UserName,
                                        c.Slot,
                                        c.Date

                                    };
                    gvCon.DataSource = form2.ToList();
                    gvCon.DataBind();



                }

                if (ddSearch.Text == "User")
                {
                    string uname = ddSearchItems.SelectedValue;
                    var form3 = from c in db.FeedConsumptions
                                    where c.User_Id.ToString() == uname
                                    select new
                                    {
                                        c.FeedFormula.FormulaName,
                                        c.Animal.AnimalBreed.Breed,
                                         c.AspNetUser.UserName,
                                        c.Slot,
                                        c.Date
                                    };
                    gvCon.DataSource = form3.ToList();
                    gvCon.DataBind();



                }

                gvFeedCon.Visible = false;
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
            catch (Exception et)
            {
                Response.Redirect("FeedConsumption View.aspx");
            }
            gvFeedCon.Visible = true;
            gvCon.Visible = false;

        }

        protected void gvFeedCon_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //get FeedFormula_Id,Animal_Id and User_Id of edit able row

            string Formula_Id = gvFeedCon.DataKeys[e.NewEditIndex]["Formula_Id"].ToString();
            string Animal_Id = gvFeedCon.DataKeys[e.NewEditIndex]["Animal_Id"].ToString();
            string User_Id = gvFeedCon.DataKeys[e.NewEditIndex]["User_Id"].ToString();
            gvFeedCon.EditIndex = e.NewEditIndex;
            PopulateFeedConsumptions();
            populateGridView();
            DropDownList ddFName = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddFName");
            DropDownList ddBreed = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddBreed");
            DropDownList ddUName = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddUName");
            //DropDownList ddSlot = (DropDownList)gvFeedCon.Rows[e.NewEditIndex].FindControl("ddSlot");
            //TextBox txtDate = (TextBox)gvFeedCon.Rows[e.NewEditIndex].FindControl("txtDate");

            if (ddFName != null && ddBreed!= null && ddUName != null)
            {
                BindFeedFormula(ddFName, PopulateFeedFormula());
                ddFName.SelectedValue = Formula_Id;
                BindAnimalBreed(ddBreed, PopulateAnimalBreed());
                ddBreed.SelectedValue = Animal_Id;
                BindAspNetUser(ddUName, PopulateAspNetUser());
                ddUName.SelectedValue = User_Id;
                //  ddSlot.SelectedValue =ddSlot.DataValueField ;
                //txtDate.Text= txtDate.Text;         
            }

        }

        protected void gvFeedCon_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("edit");
            if (!Page.IsValid)
            {
                return;
            }
            int ConsumptionId = (int)gvFeedCon.DataKeys[e.RowIndex]["ConsumptionId"];
            DropDownList ddFName = (DropDownList)gvFeedCon.Rows[e.RowIndex].FindControl("ddFName");
             DropDownList ddBreed = (DropDownList)gvFeedCon.Rows[e.RowIndex].FindControl("ddBreed");
            DropDownList ddUName = (DropDownList)gvFeedCon.Rows[e.RowIndex].FindControl("ddUName");
            DropDownList ddSlot = (DropDownList)gvFeedCon.Rows[e.RowIndex].FindControl("ddSlot");
            TextBox txtDate = (TextBox)gvFeedCon.Rows[e.RowIndex].FindControl("txtDate");
            using (Entities db = new Entities())
            {
                var v = db.FeedConsumptions.Where(a => a.ConsumptionId == ConsumptionId).FirstOrDefault();


                if (v != null)
                {
                    v.Formula_Id = int.Parse(ddFName.SelectedValue);
                    v.Animal_Id = int.Parse(ddBreed.SelectedValue);
                    v.User_Id = ddUName.SelectedValue; 
                    v.Slot = ddSlot.SelectedItem.Value;
                    string dateString = txtDate.Text;
                    v.Date = Convert.ToDateTime(dateString,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                }
               

                db.SaveChanges();
                gvFeedCon.EditIndex = -1;
                PopulateFeedConsumptions();
                populateGridView();

            }

        }

        protected void gvFeedCon_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ConsumptionId = (int)gvFeedCon.DataKeys[e.RowIndex]["ConsumptionId"];
            using (Entities db = new Entities())
            {
                var v = db.FeedConsumptions.Where(a => a.ConsumptionId.Equals(ConsumptionId)).FirstOrDefault();
                if (v != null)
                {
                    db.FeedConsumptions.Remove(v);
                    db.SaveChanges();
                    PopulateFeedConsumptions();
                    populateGridView();

                }
            }

        }

        protected void gvFeedCon_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFeedCon.EditIndex = -1;
            PopulateFeedConsumptions();
            populateGridView();

        }
    }
}     
