using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchEventTarget : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            target_input_txt_box.Focus();
        }

        protected void remove_entry_Click(object sender, EventArgs e)
        {
            target_input_txt_box.Text = string.Empty; // clear out selected value
        }

        protected void search_target_Click(object sender, EventArgs e)
        {
            string target = target_input_txt_box.Text; // retrieve the user's selected value

            if(target.Length != 0) // something was inputted
            {
                var potential_hits = (from elem in DC.DESKREG_EVENT
                                      where elem.EVENT_TARGET.Contains(target)
                                      select elem.EVENT_ID).ToList(); // get all potential matches into a list

                if(potential_hits.Count != 0) // the target has some hits - send to another form to display results
                {
                    Response.Redirect("RegSearchEventTarget_true.aspx?target=" + target + "&last=" + "21");
                }
                else // target does not have any hits
                {
                    no_hits(sender, e);
                }
            }
            else // nothing was inputted
            {
                no_entry(sender, e);
            }
        }

        protected void no_entry(object sender, EventArgs e) //message to inform user to try again after inputting nothing
        {
            string script = DL.generic_message(sender, e, "Please Enter a Value to Search By", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_entry", script, true);
        }

        protected void no_hits(object sender, EventArgs e) //message to inform user to try again after no events were returned
        {
            string script = DL.generic_message(sender, e, "This target does not have any events associated with it. Please enter a different value and try again.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_hits", script, true);
        }
    }
}