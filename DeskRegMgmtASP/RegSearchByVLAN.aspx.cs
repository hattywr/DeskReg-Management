using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchByVLAN : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities(); //Connect SQL Server Object
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (ddVLAN.Items.Count <= 1)
            {
                ddVLAN.DataSource = (from elem in DC.DESKREG_VLAN
                                     orderby elem.VLAN_NO
                                     select elem.VLAN_NO + " - " + elem.VLAN_NAME).ToList(); //Create list of VLAN's

                ddVLAN.DataBind(); // Bind VLAN types to VLAN DD
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string selected_vlan = ddVLAN.SelectedValue;

            if (selected_vlan == "Choose One") // nothing was chosen
            {
                no_Input(sender, e);
            }

            else
            {
                string fixed_vlan = DL.fix_VLAN(selected_vlan); //properly format our VLAN

                Response.Redirect("RegSearchByVLAN_List.aspx?vlan_query=" + fixed_vlan + "&next=" + "15"); // pass through our VLAN
            }
            

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddVLAN.ClearSelection(); //clear the searched entry
        }

        protected void no_Input(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made
        {
            string script = DL.generic_message(sender, e, "Please select a VLAN.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_Input", script, true);
        }
    }
}