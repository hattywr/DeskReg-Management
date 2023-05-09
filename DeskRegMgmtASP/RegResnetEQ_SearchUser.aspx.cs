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
    public partial class RegResnetEQ_SearchUser : System.Web.UI.Page
    {
        //Create class objects
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Request.QueryString["UserName"]; //retrieve the username sent from RegResnetEQ form
            U_Name.Text = (from elem in DC.DESKREG_USERINFO
                           where elem.USERID == username
                           select elem.USER_FNAME +" " + elem.USER_LNAME).Single(); //Fill in the User textbox in our grid with the user's name-matched using the username pulled from other form

            Unique_ID.Text = (from elem in DC.DESKREG_USERINFO
                              where elem.USERID == username
                              select elem.UNIQUE_ID).Single(); // Fill unqiue ID for the user-matched using username pulled from other form

            User_Status.Text = "Enabled";

            if (ddDeviceType_Input.Items.Count <= 1)
            {
                ddDeviceType_Input.DataSource = DL.GetDevTypes(); //Create Device type dropdown
                ddDeviceType_Input.DataBind(); //Bind to list
            }
            Mac_Address_Text_Input.Focus();
        }

        protected void Submit_User_Reg_Click(object sender, EventArgs e)
        {
            int input = Val_ResnetInput(); //Call main validation method to confirm all inputs are valid
            if (input == 1) // input does not pass validation
            {
                this.input_wrong(sender, e, "MAC Address Failed Validation. Please Adjust Your Input And Try Again."); //inform user to fix input

            }

            else if (input == 2)
            {
                input_wrong(sender, e, "Equipment Name Appears To Be Blank. Please Enter A Name.");
            }

            else if (input == 3)
            {
                input_wrong(sender, e, "Device Type Has Not Been Selected. Please Select A Device Type.");
            }

            else if (input == 4)
            {
                input_wrong(sender, e, "VLAN Has Not Been Selected. Please Select A VLAN For This Device.");
            }

            else if (input == 5)
            {
                input_wrong(sender, e, "The Guest VLAN Requires An Expiration Date To Be Set. Please Add An Expiration Date And Try Again.");
            }

            else if (input == 404)
            {
                input_wrong(sender, e, "There Was A Problem With Your Submission. Please Try Again.");
            }
            else if (input == 6)//inputs are confirmed
            {
                //Call registration method-confirm no duplicate entry and that validated inputs are saved to the DB 
                Boolean success = DL.RegisterEQ("64-Resnet", null, null, null, ddDeviceType_Input.SelectedValue, Mac_Address_Text_Input.Text, EQ_Name_Text_Input.Text);
                if (success==true) //Device is successfully registered
                {

                    DL.Update_Sys_Info(Mac_Address_Text_Input.Text, Unique_ID.Text);
                    DL.Log_Event(DL.val_MAC(Mac_Address_Text_Input.Text), 2, Session["username"].ToString(), null, "Resnet");
                    Success_Msg(sender, e); //Inform user that the input was registered successfully
                    reset_form(); //Reset the form for the next entry
                }
                else //Registration failed
                {
                    fail_Submission(sender, e); //Inform user that the registration failed
                }
            }
            
        }

        protected void Reset_User_Reg_Click(object sender, EventArgs e)
        {
            reset_form();
        }

        protected int Val_ResnetInput()
        {
            return DL.val_InputExternal(Mac_Address_Text_Input.Text, EQ_Name_Text_Input.Text, ddDeviceType_Input.Text, "Resnet", null, null, null);
        }

        protected void reset_form()
        {
            Mac_Address_Text_Input.Text = string.Empty;
            EQ_Name_Text_Input.Text = string.Empty;
            ddDeviceType_Input.ClearSelection();
        }

        protected void input_wrong(object sender, EventArgs e, string custom_message)
        {
            string script = DL.generic_message(sender, e, custom_message, "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "input_wrong", script, true);
        }

        protected void Success_Msg(object sender, EventArgs e)
        {
            string script = DL.generic_message(sender, e, "Device Successfullly Registered!", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "Success_Msg", script, true);
        }

        protected void fail_Submission(object sender, EventArgs e)
        {
            string script = DL.generic_message(sender, e, "Registration Failed-Possible Duplicate", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "fail_Submission", script, true);
        }
    }
}