using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    
    public partial class Confirm_VLAN_delete : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            string vlan_name = Request.QueryString["vlan_delete_query"].ToString(); // get the submitted vlan to potentially delete

            Name_Input.Text = vlan_name; // populate the form with the vlan name

            string vlan_no = (from elem in DC.DESKREG_VLAN
                              where elem.VLAN_NAME == vlan_name
                              select elem.VLAN_NO).First().ToString(); // get the vlan number via the deskreg vlan table

            number_Input.Text = vlan_no; // populate the form with the vlan number


            
        }

        protected void delete_vlan_Click(object sender, EventArgs e)
        {
            string vlan_name = Request.QueryString["vlan_delete_query"].ToString(); // retrieve vlan to delete

            string vlan_ID = (from elem in DC.DESKREG_VLAN
                              where elem.VLAN_NAME == vlan_name
                              select elem.VLAN_ID).First().ToString(); // get the vlan ID to delete from

            int vlan_ID_to_Delete = Convert.ToInt32(vlan_ID); // convert the vlan ID to an int

            DL.delete_vlan(vlan_ID_to_Delete); // delete the vlan
            DL.Log_Event("VLAN-" + number_Input.Text, 16, Session["username"].ToString(), Name_Input.Text , null); // log the event
            Response.Redirect("RegVlanMgmt.aspx"); // send the user back the MGMT page to view their changes
            
        }
    }
}