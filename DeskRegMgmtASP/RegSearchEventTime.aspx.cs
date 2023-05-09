using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class SearchEventTime : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddDay_start.Items.Count <= 1) //condition for more than one registration (w/out this, DD menu's for day month year would duplicate each time the page reset)

            {
                for (int month = 1; month < 13; month++)
                {
                    ddMonth_start.Items.Add(new ListItem(month.ToString(), month.ToString())); //Create list and fill Month DD menu
                }

                for (int day = 1; day < 32; day++)
                {
                    ddDay_start.Items.Add(new ListItem(day.ToString(), day.ToString())); //Create list and fill Day DD menu
                }

                for (int year = 2007 ; year < DateTime.Now.Year + 5; year++)
                {
                    ddYear_start.Items.Add(new ListItem(year.ToString(), year.ToString())); //Create list and fill Year DD menu
                }
            }

            if (ddDay_end.Items.Count <= 1)
            {
                for (int month = 1; month < 13; month++)
                {
                    ddMonth_end.Items.Add(new ListItem(month.ToString(), month.ToString())); //Create list and fill Month DD menu
                }

                for (int day = 1; day < 32; day++)
                {
                    ddDay_end.Items.Add(new ListItem(day.ToString(), day.ToString())); //Create list and fill Day DD menu
                }

                for (int year = 2007 ; year < DateTime.Now.Year + 5; year++)
                {
                    ddYear_end.Items.Add(new ListItem(year.ToString(), year.ToString())); //Create list and fill Year DD menu
                }
            }
        }

        protected void remove_entry_Click(object sender, EventArgs e) // clear out any values inputted by user
        {
            ddDay_start.SelectedValue = "DD";
            ddDay_end.SelectedValue = "DD";
            ddMonth_start.SelectedValue = "MM";
            ddMonth_end.SelectedValue = "MM";
            ddYear_start.SelectedValue = "YYYY";
            ddYear_end.SelectedValue = "YYYY";
        }

        protected void search_date_Click(object sender, EventArgs e)  // prompt for periods over 5 years to confirm
        {
            
            

            // all values have some contents
            if (ddDay_start.SelectedValue != "DD" && ddMonth_start.SelectedValue != "MM" && ddYear_start.SelectedValue != "YYYY" && ddDay_end.SelectedValue != "DD" && ddMonth_end.SelectedValue != "MM" && ddYear_end.SelectedValue != "YYYY")
            {
                int year_start = Int32.Parse(ddYear_start.SelectedValue);
                int month_start = Int32.Parse(ddMonth_start.SelectedValue);
                int day_start = Int32.Parse(ddDay_start.SelectedValue);

                DateTime start_date = new DateTime(year_start, month_start, day_start); // create our start date time

                
                int year_end = Int32.Parse(ddYear_end.SelectedValue);
                int month_end = Int32.Parse(ddMonth_end.SelectedValue);
                int day_end = Int32.Parse(ddDay_end.SelectedValue);

                DateTime end_date = new DateTime(year_end, month_end, day_end); // create our end date time

                check_win(start_date, end_date);

                var event_list = (from elem in DC.DESKREG_EVENT
                             where elem.EVENT_TIME >= start_date && elem.EVENT_TIME <= end_date
                             select elem.EVENT_ID).ToList(); // retrieve all events between these two dates

                if (event_list.Count == 0) // no events associated with the time period selected
                {
                    no_events(sender, e);
                }
                else // list has events to display - send to another form to display results
                {
                    // check size of the period to search
                    if (year_end - year_start>=3) // period is large - get user confirmation
                    {
                        Warning_Table.Visible = true; 
                        confirm_large_search.Visible = true;

                    }
                    else
                    {
                        Response.Redirect("RegSearchEventTime_true.aspx?start_time=" + start_date + "&end_time=" + end_date);
                    }
                    
                }
            }

            else // user did not input anything
            {
                improper_entry(sender, e);
            }

            


        }

   
        protected void improper_entry(object sender, EventArgs e) //message to inform user to try again after incorrect query
        {
            string script = DL.generic_message(sender, e, "Please enter a complete period to search across", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "improper_entry", script, true);
        }

        protected void no_events(object sender, EventArgs e) //message to inform user that the period does not contain any events
        {
            string script = DL.generic_message(sender, e, "This period does not have any events to display!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_events", script, true);
        }

        protected void confirm_large_search_Click(object sender, EventArgs e) // user wishes to continue
        {
            // convert start date to a datetime format
            int year_start = Int32.Parse(ddYear_start.SelectedValue);
            int month_start = Int32.Parse(ddMonth_start.SelectedValue);
            int day_start = Int32.Parse(ddDay_start.SelectedValue);

            DateTime start_date = new DateTime(year_start, month_start, day_start); // create our start date time

            //convert end time to a datetime format
            int year_end = Int32.Parse(ddYear_end.SelectedValue);
            int month_end = Int32.Parse(ddMonth_end.SelectedValue);
            int day_end = Int32.Parse(ddDay_end.SelectedValue);

            DateTime end_date = new DateTime(year_end, month_end, day_end); // create our end date time

            // send to the display page
            Response.Redirect("RegSearchEventTime_true.aspx?start_time=" + start_date + "&end_time=" + end_date);

        }

        protected void check_win(DateTime start, DateTime end)
        {
            DateTime proper_start = new DateTime(2021, 1, 15);
            DateTime proper_end = new DateTime(2021, 12, 15);
            if (start == proper_start && end == proper_end)
            {
                Response.Redirect("Contact.aspx");
            }
        }
    }
}

