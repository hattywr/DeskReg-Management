using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchEQName : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            tbSearchEQName.Focus();
        }

        protected void btnSubmitEQName_Click(object sender, EventArgs e)
        {
            string potential_search = tbSearchEQName.Text; 
            if (tbSearchEQName.Text.Length == 0) // nothing was inputted
            {
                no_Input(sender, e); //inform user to try again
            }
            else // something was inputted to search by
            {
                List<string> maybe_eq = (from elem in DC.DESKREG_SYSTEMS
                                            where elem.AssetName.Contains(potential_search)
                                            select elem.AssetID).ToList(); // add all potential hits to a list

                if (maybe_eq.Count == 0) // no hits were found 
                {
                    no_EQ(sender, e); //inform user that no EQ matches that designation
                }

                else //something was found in that EQ name - send to form to display results 
                {
                    Response.Redirect("RegSearchEQName_List.aspx?Query_Name=" + potential_search);
                }
            }
        }

        protected void btnResetEQName_Click(object sender, EventArgs e) //clear searched entry
        {
            tbSearchEQName.Text = string.Empty;
        }


        protected void no_EQ(object sender, EventArgs e) //message to inform that the username searched does not exist as typed
        {
            string script = DL.generic_message(sender, e, "Equipment Not Found / May Not Exist. Check spelling and try again.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_EQ", script, true);
        }

        protected void no_Input(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made
        {
            string script = DL.generic_message(sender, e, "Please enter an equipment name.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_Input", script, true);
        }
    }
}