using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchEventType : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(dd_event_items.Items.Count <= 1)
            {
                var list_items = (from elem in DC.DESKREG_ACTION
                                  select elem.ACTION_NAME).ToList(); // get all actions from Deskreg Action

                for (int i = 0; i<list_items.Count; i++)
                {
                    dd_event_items.Items.Add(new ListItem(list_items[i].ToString(), list_items[i].ToString())); // fill action dropdown menu
                }
                dd_event_items.Items.Remove(list_items[28]); // get rid of Update Network option - Not Needed

            }
        }

        protected void search_action_Click(object sender, EventArgs e)
        {
            string searched_action = dd_event_items.SelectedValue; // get the action selected by the user
            if (searched_action != "Choose One") // user picked something to search
            {
                string action_ID = (from elem in DC.DESKREG_ACTION
                                    where elem.ACTION_NAME == searched_action
                                    select elem.ACTION_ID).FirstOrDefault().ToString(); // retrieve the action ID via the action name from the Deskreg Action table

                var events = (from elem in DC.DESKREG_EVENT
                              where elem.ACTION_ID.ToString() == action_ID
                              select elem.EVENT_ID).ToList(); // get all events associated with the selected action

                if (events.Count != 0) // list of events is not empty - send to another form to display results
                {
                    Response.Redirect("RegSearchEventType_true.aspx?action_id=" + action_ID);
                }
                else // list of events is empty
                {
                    no_events(sender, e);
                }
            }
            else // user did not select something to search
            {
                no_action_chosen(sender, e);
            }

        }

        protected void remove_entry_Click(object sender, EventArgs e)
        {
            dd_event_items.SelectedValue = "Choose One"; // clear out any selected values
        }

        protected void no_action_chosen(object sender, EventArgs e) //message to inform user to select something to search by
        {
            string script = DL.generic_message(sender, e, "Please select an action to search by", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_action_chosen", script, true);
        }

        protected void no_events(object sender, EventArgs e) //message to inform user that the searched action does not have anything relating to it
        {
            string script = DL.generic_message(sender, e, "This action does not have any events associated with it!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_events", script, true);
        }
    }
}