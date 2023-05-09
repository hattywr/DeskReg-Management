using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class Add_VLAN : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (visibility_dd.Items.Count <= 1) // fill our visibility dropdown
            {
                visibility_dd.Items.Add("Yes");
                visibility_dd.Items.Add("No");
            }
            name_input_txt_box.Focus();
            
        }

        protected void Add_VLAN_Click(object sender, EventArgs e)
        {
            //int maybe_vlan_number;
            if (name_input_txt_box.Text.Length != 0 && number_input_txt_box.Text.Length != 0 && visibility_dd.SelectedValue != "Select") // all fields have been filled out
            {
                // retrieve the user's selected values
                string maybe_new_vlan = name_input_txt_box.Text;
                try
                {
                    int maybe_vlan_number = Convert.ToInt32(number_input_txt_box.Text);

                    string maybe_visibility = visibility_dd.SelectedValue;

                    var vlan_no_list = (from elem in DC.DESKREG_VLAN
                                        orderby elem.VLAN_NO
                                        select elem.VLAN_NO).ToList(); // retrieve all VLANS from the deskreg_vlan table

                    var vlan_name_list = (from elem in DC.DESKREG_VLAN
                                          select elem.VLAN_NAME).ToList(); //retrieve all vlan names from table

                    if (maybe_visibility == "Yes") // vlan should be visible
                    {
                        maybe_visibility = "Y";
                    }
                    else // vlan should be hidden
                    {
                        maybe_visibility = "N";
                    }

                    if (vlan_no_list.Contains(maybe_vlan_number)) // the vlan number is already assigned to another vlan
                    {
                        Invalid_VLAN_NO(sender, e); // inform user to choose a different vlan number
                    }

                    else if (vlan_name_list.Contains(maybe_new_vlan)) //check if the 
                    {
                        bad_name(sender, e);
                    }

                    else // entry is suitable for DB
                    {

                        DL.create_vlan(maybe_new_vlan, maybe_vlan_number, maybe_visibility); // create a new entry into the DB
                        DL.Log_Event("VLAN-" + maybe_vlan_number.ToString(), 14, Session["username"].ToString(), null, maybe_new_vlan);
                        Response.Redirect("RegVlanMgmt.aspx");
                    }

                }
                catch (Exception ex)
                {
                    Number_Too_Small(sender, e);
                }
                //int verified_number = Convert.ToInt32(number_input_txt_box.Text);
                //int top = Convert.ToInt32(4,294, 967, 295);
                

            }
            else // input is not complete or does not exist
            {
                no_Input(sender, e);
            }

            

        }

        protected void Reset_VLAN_Entry_Click(object sender, EventArgs e)
        {
            // reset anything inputted
            name_input_txt_box.Text = string.Empty;
            number_input_txt_box.Text = string.Empty;
            visibility_dd.SelectedValue = "Select";
        }

        protected void no_Input(object sender, EventArgs e) //message to inform that no entry was detected and to request that an entry be made or that the entry was not complete
        {
            string script = DL.generic_message(sender, e, "Please enter ALL VLAN details", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_Input", script, true);
        }

        protected void Invalid_VLAN_NO(object sender, EventArgs e) //message to inform that the vlan number is already in use and to pick another one
        {
            string script = DL.generic_message(sender, e, "VLAN with that number already exists. Please select a different number.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "Invalid_VLAN_NO", script, true);
        }

        protected void bad_name(object sender, EventArgs e)
        {
            string script = DL.generic_message(sender, e, "A VLAN with that name already exists. Please choose a different name and try again.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "bad_name", script, true);
        }

        protected void Number_Too_Small(object sender, EventArgs e) //message to inform that the vlan number is already in use and to pick another one
        {
            string script = DL.generic_message(sender, e, "VLAN Number is not valid and is outside the accepted range. Please select a different number.", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "Number_Too_Small", script, true);
        }
    }
}