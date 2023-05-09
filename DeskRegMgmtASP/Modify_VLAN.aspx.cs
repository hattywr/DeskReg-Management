using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class Modify_VLAN : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (visibility_dd.Items.Count <= 1) // ensure that the list has not already been filled
                {
                    visibility_dd.Items.Add("Yes");
                    visibility_dd.Items.Add("No");
                }
                string vlan_name = Request.QueryString["vlan_query"].ToString(); // get the vlan to be modified via the name

                string vlan_number = (from elem in DC.DESKREG_VLAN
                                      where elem.VLAN_NAME == vlan_name
                                      select elem.VLAN_NO).First().ToString(); // retrieve the vlan number via the Deskreg vlan table

                string visible = (from elem in DC.DESKREG_VLAN
                                  where elem.VLAN_NAME == vlan_name
                                  select elem.VLAN_SHOW).First().ToString(); // retrieve the visibility via the Deskreg vlan table

                name_input_txt_box.Text = vlan_name; // populate the table with the VLAN Name

                number_input_txt_box.Text = vlan_number; // populate the table witht the VLAN Number

                if (visible == "Y") // vlan is visible
                {
                    visibility_dd.SelectedValue = "Yes"; // choose the visible value on the page load
                }
                else // vlan is not visible
                {
                    visibility_dd.SelectedValue = "No"; // choose the not visible value on the page load
                }
            }
            


        }

        protected void modify_vlan_Click(object sender, EventArgs e)
        {

            if (name_input_txt_box.Text.Length != 0 && number_input_txt_box.Text.Length != 0 && visibility_dd.SelectedValue != "Select") // all fields have been filled out
            {
                string old_vlan_name = Request.QueryString["vlan_query"].ToString(); // get the old vlan name

                string vlan_ID = (from elem in DC.DESKREG_VLAN
                                  where elem.VLAN_NAME == old_vlan_name
                                  select elem.VLAN_ID).First().ToString(); // get the vlan ID (Unique so it does not change)

                string old_vlan_number = (from elem in DC.DESKREG_VLAN
                                          where elem.VLAN_NAME == old_vlan_name
                                          select elem.VLAN_NO).First().ToString(); // get the old vlan number in case was just changed by the user

                int old_vlan_no = Convert.ToInt32(old_vlan_number); // convert the old vlan number to an int

                int vlan_ID_number = Convert.ToInt32(vlan_ID); // convert the vlan ID number to an int

                var vlan_no_list = (from elem in DC.DESKREG_VLAN
                                    orderby elem.VLAN_NO
                                    select elem.VLAN_NO).ToList(); // retrieve all VLANS from the deskreg_vlan table

                var vlan_name_list = (from elem in DC.DESKREG_VLAN
                                      select elem.VLAN_NAME).ToList();

                vlan_no_list.Remove(old_vlan_no); // remove the old vlan number from the list of vlan numbers
                                                  // we will later search through this list to ensure the new value chosen by the user is not already in use
                                                  // but user is allowed to use the current value
                vlan_name_list.Remove(old_vlan_name);



                string vlan_name = name_input_txt_box.Text; // retrieve the potentially new vlan name

                
                int vlan_no = Convert.ToInt32(number_input_txt_box.Text); // get and convert the potentially new vlan number to an int

                if (vlan_no_list.Contains(vlan_no)) // the vlan number is already assigned to another vlan - will not trigger if the value was not changed- we removed the value from the list above to ensure this
                {
                    Invalid_VLAN_NO(sender, e); // inform user to choose a different vlan number
                }
                else if (vlan_name_list.Contains(vlan_name))
                {
                    bad_name(sender, e);
                }
                else // vlan number is unique / not in use / may be the old value
                {
                    string visibile = visibility_dd.SelectedValue; // get the vlan visibility
                    if (visibile == "Yes") // vlan is visible
                    {
                        visibile = "Y";
                    }
                    else // vlan is not visible
                    {
                        visibile = "N";
                    }

                    DL.update_vlan(vlan_ID_number, vlan_name, vlan_no, visibile); // update the vlan with the potential changes
                    DL.Log_Event("VLAN-" + vlan_no.ToString(), 15, Session["username"].ToString(), old_vlan_name, vlan_name); // log the event
                    Response.Redirect("RegVlanMgmt.aspx"); // send the user back to the MGMT page to view the changes
                }
                    
                
            }
            else // input is not suitable
            {
                no_Input(sender, e);
            }
            
        }

        protected void Invalid_VLAN_NO(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made
        {
            string script = DL.generic_message(sender, e, "VLAN with that number already exists. Please select a different number.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "Invalid_VLAN_NO", script, true);
        }
        protected void no_Input(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made
        {
            string script = DL.generic_message(sender, e, "Please ensure all entries contain a proper value", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_Input", script, true);
        }

        protected void bad_name(object sender, EventArgs e)
        {
            string script = DL.generic_message(sender, e, "A VLAN with that name already exists. Please choose a different name and try again.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "bad_name", script, true);
        }
    }
}