using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchByMacAd : System.Web.UI.Page
    {

        usrregDevEntities DC = new usrregDevEntities(); //Create DB object and logic class object for reference
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbSearchMac.Focus();
        }
        protected void btnSearch_Click(object sender, EventArgs e) //searching for mac address
        {
            string macAd = tbSearchMac.Text; //retrieve user input      
            macAd = DL.val_MAC(macAd); //format user input 


            DESKREG_SYSTEMS ds = (from elem in DC.DESKREG_SYSTEMS
                                  where elem.AssetID == macAd
                                  select elem).FirstOrDefault(); //query DB to check if user's input exists

            if (ds == null) // Mac does not exist or user's input is bad
            {
                retry_Msg(sender, e); //message to ask user to try again
            }
            

            else //Mac exists, pass value through to next page
            {
                Response.Redirect("Search_Mac_true.aspx?Mac_Address=" + macAd); // redirect to the information page for the mac - pass mac through
            }

        }

        protected void btnReset_Click(object sender, EventArgs e) 
        {
            tbSearchMac.Text = string.Empty; //empty user's input
        }

        protected void retry_Msg(object sender, EventArgs e) //message to inform user to try again after failed search
        {
            string script = DL.generic_message(sender, e, "Invalid Mac Address or Device Does Not Exist - Please Try Again!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "retry_Msg", script, true); 
        }
        protected void success_message(Object sender, EventArgs e) //message for page if coming from the Reg_Confirm_Delete page after a successful deletion of a device
        {
            string script = DL.generic_message(sender, e, "Eradication Successful!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "success_message", script, true);
        }

    }
}