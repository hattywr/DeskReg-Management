using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchEventOwner : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            var unique = DC.DESKREG_EVENT.Select(z => z.EVENT_OWNER.ToLower()).Distinct().OrderBy(x => x).ToList(); // get all user's who have logged an event
            unique.Remove(""); // ensure no blanks are in the list

            if (event_owner_dd.Items.Count <= 1)
            {
                for (int i = 0; i < unique.Count; i++)
                {
                    event_owner_dd.Items.Add(unique[i]); // fill the dropdown with the user's names
                }
            }



        }

        protected void search_owner_Click(object sender, EventArgs e)
        {

            string owner = event_owner_dd.SelectedValue; // get the selected owner/user

            List<int> event_list = (from elem in DC.DESKREG_EVENT
                                    where elem.EVENT_OWNER == owner
                                    select elem.EVENT_ID).ToList(); // get the list of all actions associated with this owner
          

            if (owner != "Choose One") // a user was selected from the list
            {
                if(event_list.Count == 0) // no actions are associated with this user
                {
                    no_events(sender, e);
                }
                else // user has actions associated with the name - send to another form to display these results
                {
                    Response.Redirect("RegSearchByEventOwner_true.aspx?owner=" + owner);
                }
                
            }
            else // nothing was selected by the user
            {
                no_entry(sender, e);
            }

        }

        protected void remove_entry_Click(object sender, EventArgs e) // clear out the selected value
        {
            event_owner_dd.SelectedValue = "Choose One";
        }

        protected void no_entry(object sender, EventArgs e) //message to inform user to select a value
        {
            string script = DL.generic_message(sender, e, "Please select a user to search by", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_entry", script, true);
        }

        protected void no_events(object sender, EventArgs e) //message to inform user that the selected person does not gave anything related to it.
        {
            string script = DL.generic_message(sender, e, "This user does not have any events to display!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_events", script, true);
        }
    }

}