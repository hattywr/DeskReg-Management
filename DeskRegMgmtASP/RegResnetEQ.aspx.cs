using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegResnetEQ : System.Web.UI.Page
    {
        //Create class objects for DB and Logic files
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            tbUsername.Focus();

        }
        public void btnSearch_Click(object sender, EventArgs e)
        {

            string potential_search = tbUsername.Text;

            if (tbUsername.Text.Length == 0) //nothing was inputted
            {
                no_Input(sender, e);
            }
            else
            {
                //retrieve all possible users that contain the searched target
                List<string> maybe_users = (from elem in DC.DESKREG_USERINFO
                                            where elem.USERID.Contains(potential_search) || (elem.USER_FNAME + " " + elem.USER_LNAME).Contains(potential_search) || (potential_search.Contains(elem.USER_FNAME) && potential_search.Contains(elem.USER_LNAME))
                                            select elem.USERID).ToList();
                
                //no users exist
                if (maybe_users.Count == 0)
                {
                    no_User(sender, e);
                }

                else
                {
                    Response.Redirect("RegResnetEQ_List.aspx?list_stuff=" + potential_search); //redirect to display results of our search
                }
            }


        }

        protected void btnResetResnetEQ_Click(object sender, EventArgs e)
        {
            tbUsername.Text = string.Empty; //reset the inputted username
        }

        protected void no_User(object sender, EventArgs e) //message to inform that the username searched does not exist as typed
        {
            string script = DL.generic_message(sender, e, "User does not exist. Check spelling and try again.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_User", script, true);
        }

        protected void no_Input(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made
        {
            string script = DL.generic_message(sender, e, "Please enter a username.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_Input", script, true);
        }

        protected void user_Disabled(object sender, EventArgs e) //message to inform that the username searched returned a disabled user-devices cannot be registered to them
        {
            string script = DL.generic_message(sender, e, "User is Disabled. You are not authorized to register device for this user.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "user_Disabled", script, true);
        }




    }
}