using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class SearchUserID : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbSearchUser.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string potential_search = tbSearchUser.Text;
            if(tbSearchUser.Text.Length == 0) // nothing was searched
            {
                no_Input(sender,e); // inform user to search something
            }
            else
            {
                List<string> maybe_users = (from elem in DC.DESKREG_USERINFO
                                            where elem.USERID.Contains(potential_search) || (elem.USER_FNAME + " " + elem.USER_LNAME).Contains(potential_search) || (potential_search.Contains(elem.USER_FNAME) && potential_search.Contains(elem.USER_LNAME))
                                            select elem.USERID).ToList(); // retrieve all users that may be associated with the potential searched name or username (Full or Partial of anything)

                if (maybe_users.Count == 0) // no users are associated with the search
                {
                    no_User(sender, e);
                }

                else // there are users associated with the searched username etc.
                {
                    Response.Redirect("RegSearchUserID_LIST.aspx?Query=" + potential_search); // send the search through to another form
                }
            }
        }

        protected void btnSearchUserReset_Click(object sender, EventArgs e) // reset the searched item
        {
            tbSearchUser.Text = string.Empty;
        }

        protected void no_User(object sender, EventArgs e) //message to inform that the username searched does not exist as typed
        {
            string script = DL.generic_message(sender, e, "Users do not exist. Check spelling and try again.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_User", script, true);
        }

        protected void no_Input(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made
        {
            string script = DL.generic_message(sender, e, "Please enter a username.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_Input", script, true);
        }
    }
}