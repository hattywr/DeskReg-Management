using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Windows;
using System.Messaging;
using Microsoft.VisualBasic;
using System.Text;

namespace DeskRegMgmtASP
{
    public partial class About : Page
    {

        usrregDevEntities DC = new usrregDevEntities(); //Connect SQL Server Object
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e) //Populate dropdown menus
        {
            if (ddDeviceType.Items.Count <= 1)
            {
                ddDeviceType.DataSource = DL.GetDevTypes(); //Create list of Device Types
                ddDeviceType.DataBind(); //Bind Device Type list to Device Type DD
            }
           

            if(ddVLAN.Items.Count <= 1)
            {
                ddVLAN.DataSource = DL.GetVLANs();//Create list of VLAN's
                ddVLAN.DataBind(); // Bind VLAN types to VLAN DD
            }
            

            if (ddMonth.Items.Count<=1) //condition for more than one registration (w/out this, DD menu's for day month year would duplicate each time the page reset)

            {
                for (int month = 1; month < 13; month++)
                {
                    ddMonth.Items.Add(new ListItem(month.ToString(), month.ToString())); //Create list and fill Month DD menu
                }

                for (int day = 1; day < 32; day++)
                {
                    ddDay.Items.Add(new ListItem(day.ToString(), day.ToString())); //Create list and fill Day DD menu
                }

                for (int year = DateTime.Now.Year; year < DateTime.Now.Year + 5; year++)
                {
                    ddYear.Items.Add(new ListItem(year.ToString(), year.ToString())); //Create list and fill Year DD menu
                }
            }
            tbMacaddress.Focus();
        }


        protected void btnSubmit_Click(object sender, EventArgs e) //Write user selections into SQL 
        {

            int input_good = val_Input(); //Ensure the user has inputted data of some sort
            
            if (input_good == 1) // input does not pass validation
            {
                this.fix_InputMsg(sender, e, "MAC Address Failed Validation. Please Adjust Your Input And Try Again."); //inform user to fix input
                
            }

            else if(input_good == 2)
            {
                fix_InputMsg(sender, e, "Equipment Name Appears To Be Blank. Please Enter A Name.");
            }
            
            else if(input_good == 3)
            {
                fix_InputMsg(sender, e, "Device Type Has Not Been Selected. Please Select A Device Type.");
            }

            else if(input_good == 4)
            {
                fix_InputMsg(sender, e, "VLAN Has Not Been Selected. Please Select A VLAN For This Device.");
            }

            else if(input_good == 5)
            {
                fix_InputMsg(sender, e, "The Guest VLAN Requires An Expiration Date To Be Set. Please Add An Expiration Date And Try Again.");
            }

            else if(input_good == 404)
            {
                fix_InputMsg(sender, e, "There Was A Problem With Your Submission. Please Try Again.");
            }

            else if (input_good == 6)
            {
                
                Boolean registered = DL.RegisterEQ(ddVLAN.SelectedValue, ddYear.SelectedValue, ddMonth.SelectedValue,ddDay.SelectedValue, ddDeviceType.SelectedValue, tbMacaddress.Text, tbEQName.Text); // attempt to register a device

               

                if (registered == true) // device was registered
                {
                   
                    DL.Log_Event(DL.val_MAC(tbMacaddress.Text), 1, Session["username"].ToString(), null, DL.fix_VLAN(ddVLAN.SelectedValue)); // log the event
                    this.SuccessMsg(sender, e); // inform user that registration was successful
                    rstForm(); // clear out form
                }
                else // submission failed
                {
                    this.failed_SubmissionMsg(sender, e); // let user know the submission failed
                }
            }
        }
         
            
 

        protected void rstForm() // Clear out all values that had/have been selected by user
        {
            tbMacaddress.Text = string.Empty;
            tbEQName.Text = string.Empty;
            ddDeviceType.ClearSelection();
            ddVLAN.ClearSelection();
            ddMonth.ClearSelection();
            ddDay.ClearSelection();
            ddYear.ClearSelection();
            
        }

        protected void btnResetEQReg_CLick(object sender, EventArgs e) //Resets User Selections
        {
            rstForm();
        }  

        protected int val_Input()
        {

            return DL.val_InputExternal(tbMacaddress.Text, tbEQName.Text, ddDeviceType.Text, ddVLAN.Text, ddDay.Text, ddMonth.Text, ddYear.Text); // validate input
            
        }


        protected void SuccessMsg(object sender, EventArgs e)
        {
            //Display success message.
            string script = DL.generic_message(sender, e, "Device Registered Successfully!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
        }

        protected void fix_InputMsg(object sender, EventArgs e, string custom_message)
        {
            //Display message informing user to fix input
            string script = DL.generic_message(sender, e, custom_message, "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "fix_InputMsg", script, true);


        }

        protected void failed_SubmissionMsg(object sender, EventArgs e)
        {
            //Display message informing user to fix input
            string script = DL.generic_message(sender, e, "Registration Failed-Possible Duplicate", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "failed_SubmissionMsg", script, true);
        }
    }

}