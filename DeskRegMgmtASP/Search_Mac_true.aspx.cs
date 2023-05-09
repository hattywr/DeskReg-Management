using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class Search_Mac_true : System.Web.UI.Page
    {
        DeskRegLogic DL = new DeskRegLogic();
        usrregDevEntities DC = new usrregDevEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
            mac_lbl.Text = mac_address;
            
            
            string status = (from elem in DC.DESKREG_SYSTEMS
                             where elem.AssetID == mac_lbl.Text
                             select elem.DISABLED).FirstOrDefault().ToString(); // get device status

            if (status == "n") // device is enabled
            {
                status_lbl.Text = "Enabled"; // set status text to enabled
                Disable_Button.Visible = true; // show disable button
                //Block_Button.Visible = true; // show block button

            }
            else // device is disabled
            {
                status_lbl.Text = "Disabled"; // set status text to disabled
                Enable_Button.Visible = true; // show enable button

            }

            DESKREG_SYSTEMS Desk = (from elem in DC.DESKREG_SYSTEMS
                                    where elem.AssetID == mac_address
                                    select elem).ToList().FirstOrDefault(); //get the asset record

            string Asset_Name = ""; //set asset name to blank string

            if (Desk != null && Desk.AssetName != null) // name exists
            {
                Asset_Name = Desk.AssetName; // set asset name
            }

            string vlan = (from elem in DC.DESKREG_SYSTEMS
                           where elem.AssetID == mac_address
                           select elem.VLAN).FirstOrDefault(); //get the vlan from DB (DeskregSystems) using mac 


            if (!IsPostBack)
            {
                string EQ_Name = (from elem in DC.DESKREG_SYSTEMS
                                  where elem.AssetID == mac_lbl.Text
                                  select elem.AssetName).FirstOrDefault(); //get eq name from DB (DeskregSystems)

                Text_Box_EQ_Name.Text = EQ_Name; //display EQ name in our grid


                for (int month = 1; month < 13; month++)
                {
                    ddMonth_Input.Items.Add(new ListItem(month.ToString(), month.ToString())); //Create list and fill Month DD menu
                }

                for (int day = 1; day < 32; day++)
                {
                    ddDay_Input.Items.Add(new ListItem(day.ToString(), day.ToString())); //Create list and fill Day DD menu
                }

                for (int year = 2000; year < DateTime.Now.Year + 5; year++)
                {
                    ddYear_Input.Items.Add(new ListItem(year.ToString(), year.ToString())); //Create list and fill Year DD menu
                }

                DESKREG_SYSTEMS Stuff = (from elem in DC.DESKREG_SYSTEMS
                                         where elem.AssetID == mac_lbl.Text
                                         select elem).ToList().FirstOrDefault(); //check exp date

                if (Stuff.EXP_DATE != null) // exp date exists
                {
                    string exp_date = (from elem in DC.DESKREG_SYSTEMS
                                       where elem.AssetID == mac_lbl.Text
                                       select elem.EXP_DATE).FirstOrDefault().ToString(); // pull exp date

                    DateTime dateTime = Convert.ToDateTime(exp_date); //convert exp date to a date and Time

                    if (dateTime.Day.ToString() != null) // check if Day is null
                    {
                        ddDay_Input.SelectedValue = dateTime.Day.ToString(); //day not null, set it to value of day dropdown
                    }
                    else // Day value is null
                    {
                        ddDay_Input.SelectedValue = "DD"; //leave as DD
                    }

                    if (dateTime.Month.ToString() != null) // check if month is null
                    {
                        ddMonth_Input.SelectedValue = dateTime.Month.ToString(); //month not null, set it to value of month in dropdown
                    }
                    else //month is null
                    {
                        ddMonth_Input.SelectedValue = "MM"; //leave as MM
                    }
                    if (dateTime.Year.ToString() != null) // check if year is null
                    {
                        ddYear_Input.SelectedValue = dateTime.Year.ToString(); // year not null, set it to value of year in dropdown
                    }
                    else
                    {
                        ddYear_Input.SelectedValue = "YYYY"; // leave as YYYY
                    }


               
                }

                Device_Type_DropDown.DataSource = DL.GetDevTypes();
                Device_Type_DropDown.DataBind(); //create Dropdown menu for device type and fill it

                string Dev_Type = get_dev_type_proper(mac_lbl.Text);
                Device_Type_DropDown.SelectedValue = Dev_Type; // default to the device type the device is associated with



                string Reg_date = (from elem in DC.DESKREG_SYSTEMS
                                   where elem.AssetID == mac_lbl.Text
                                   select elem.REG_DATE).FirstOrDefault().ToString(); // get reg date

                if (Reg_date == "") // no reg date on record
                {
                    Reg_Date.Text = "N/A";
                }
                else //reg date exists
                {
                    Reg_Date.Text = Reg_date; // set reg date to display in our grid
                }

                //Formatting logic
                VLAN_Dropdown.DataSource = DL.GetVLANs();
                VLAN_Dropdown.DataBind(); // create Dropdown menu for vlans and fill it

                string proper_vlan = get_vlan_proper(mac_lbl.Text);
                VLAN_Dropdown.SelectedValue = proper_vlan; // default to the vlan the device is on
                if (proper_vlan != "3 - Doors" && VLAN_Dropdown.SelectedValue == "3 - Doors") // the VLAN did not exist in the dropdown, therefore it is has restricted visibility
                {
                    // remove vlan dropdown visibility
                    VLAN_Dropdown.Visible = false;
                    // remove change vlan button visibility
                    Change_vlan_button.Visible = false;

                    // create label to display the actual vlan name as plain text (as it isnt editable at the moment
                    Label actual_vlan = new Label();
                    actual_vlan.Text = proper_vlan;
                    actual_vlan.Style.Add("font-weight", "bold");
                    VLAN.Controls.Add(actual_vlan);

                    // create the not visible message for the user
                    Label not_visible_msg = new Label();

                    not_visible_msg.Text = "NOT";
                    not_visible_msg.Style.Add("font-weight", "bold");
                    not_visible_msg.Style.Add("margin-left", "2em");
                    VLAN.Controls.Add(not_visible_msg);

                    // link the modify vlan page to the vlan in question so that visibility access can be adjusted
                    HyperLink link = new HyperLink();
                    proper_vlan = DL.fix_VLAN(proper_vlan);
                    link.NavigateUrl = ("Modify_VLAN.aspx?vlan_query=" + proper_vlan + "&next=" + "20");
                    link.Text = "VISIBLE/EDITABLE";
                    link.Style.Add("font-weight", "bold");
                    link.Style.Add("margin-left", ".35em");
                    VLAN.Controls.Add(link);
                }
            }


            // need to check if the mac exists in the sysinfo table - if it does, resnet styling, if it doesnt, lmc device styling
            Boolean exists_in_sysinfo = DC.DESKREG_SYSINFO.AsEnumerable().Any(x => mac_address == x.AssetID);
     

            if (exists_in_sysinfo!= true)
            {
                this.LMC_Device_Formatting(mac_address);
            }
            else
            {
                this.Resnet_Device_Formatting(mac_address);
            }

        }




        protected void delete_button_Click(object sender, EventArgs e)
        {

            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
            Response.Redirect("Reg_Confirm_Delete.aspx?Mac_Address=" + mac_address); //pass mac through to the delete confirmation page


        }

        protected void Enable_Button_Click(object sender, EventArgs e)
        {
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
                                                                  // string mac_address = Mac_Address.Text; //retrieve mac to be enabled

            DL.enable_device(mac_address, sender, e); // call enable method from logic file
            DL.Log_Event(mac_address, 5, Session["username"].ToString(), "Disabled", "Enabled");
            Disable_Button.Visible = true;
            //Block_Button.Visible = true;
            Enable_Button.Visible = false;
            status_lbl.Text = "Enabled";
           // Page_Load(sender, e); // reload page to process changes


        }

        protected void Disable_Button_Click(object sender, EventArgs e)
        {
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
            //string mac_address = Mac_Address.Text; // retrieve mac to be disabled
            DL.disable_device(mac_address, sender, e); // call disable method from logic file
            DL.Log_Event(mac_address, 4, Session["username"].ToString(), "Enabled", "Disabled");
            Disable_Button.Visible = false;
            //Block_Button.Visible = false;
            Enable_Button.Visible = true;
            status_lbl.Text = "Disabled";
            //Page_Load(sender, e); // reload page to process changes

        }

        protected void Block_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ ?begin=" + "Find 15 digits...Try starting with Registering LMC EQ...");
        }

        protected void Change_Name_Button_Click(object sender, EventArgs e)
        {
            // string mac_address = Mac_Address.Text;
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
            string old_name = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac_address
                               select elem.AssetName).First().ToString(); // get old name from deskreg_systems 

            string new_name = Text_Box_EQ_Name.Text; // get new name from textbox

            if(old_name == new_name)
            {
                no_change_msg(sender, e);
            }
            else
            {
                DL.Log_Event(mac_address, 7, Session["username"].ToString(), old_name, new_name); //log the event
                DL.change_name(mac_address, new_name, sender, e); // change the name
                updated_information_msg(sender, e, "Device Name");
            }

        }

        protected void Change_Type_Button_Click(object sender, EventArgs e)
        {
            //string mac_address = Mac_Address.Text;
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form

            var old_type_id = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac_address
                               select elem.TYPE_ID).FirstOrDefault(); // get old type ID

            old_type_id = Convert.ToInt32(old_type_id); // convert old type to Int

            string old_device_type = (from elem in DC.DESKREG_TYPE
                                      where elem.TYPE_ID == old_type_id
                                      select elem.TYPE_NAME).FirstOrDefault().ToString(); // use old device type to get old device type name

            string new_device_type = Device_Type_DropDown.SelectedValue; // get the new device type

            if(old_device_type == new_device_type)
            {
                no_change_msg(sender, e);
            }
            else
            {
                DL.Log_Event(mac_address, 8, Session["username"].ToString(), old_device_type, new_device_type); // log the new event
                DL.change_dev_type(mac_address, new_device_type, sender, e); // change the device type
                updated_information_msg(sender, e, "Device Type");
                //Page_Load(sender, e); // reload the page
            }


        }

        protected void Change_vlan_button_Click(object sender, EventArgs e)
        {
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
                                                                  // string mac_address = Mac_Address.Text;

            string old_vlan = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac_address
                               select elem.VLAN).First().ToString(); // get old vlan

            string new_vlan = VLAN_Dropdown.SelectedValue; // get new vlan

            if(new_vlan.Contains(old_vlan))
            {
                no_change_msg(sender, e);
            }
            else
            {
                DL.Log_Event(mac_address, 9, Session["username"].ToString(), old_vlan, DL.fix_VLAN(new_vlan)); // log the event
                DL.change_vlan(mac_address, new_vlan, sender, e); // change the vlan
                updated_information_msg(sender, e, "VLAN");
                //Page_Load(sender, e); // reload the page
            }

        }

        protected void Change_Exp_Date_button_Click(object sender, EventArgs e)
        {
            //string mac_address = Mac_Address.Text;
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
            string old_exp_date = (from elem in DC.DESKREG_SYSTEMS
                                   where elem.AssetID == mac_address
                                   select elem.EXP_DATE).FirstOrDefault().ToString(); // get the old exp date

            

            string new_exp_date = ddYear_Input.SelectedValue + "-" + ddMonth_Input.SelectedValue + "-" + ddDay_Input.SelectedValue; // get the new exp date from the selected values

            if (new_exp_date == "YYYY-MM-DD") // no new input
            {
                // do nothing

            }
            
            if(old_exp_date == "" && new_exp_date == "YYYY-MM-DD")
            {
                no_change_msg(sender, e);
            }

            else // new exp date inputted
            {
                try
                {
                    DateTime new_date = Convert.ToDateTime(new_exp_date); // try to convert new date to a date and time
                    if (new_date.ToString() == old_exp_date)
                    {
                        no_change_msg(sender, e);
                    }
                    else
                    {
                        DL.Log_Event(mac_address, 10, Session["username"].ToString(), old_exp_date, new_date.ToString()); // log the event
                        DL.change_exp_date(mac_address, new_exp_date, sender, e); // change the exp date
                        updated_information_msg(sender, e, "Expiration Date");
                        //Page_Load(sender, e); // reload the page
                    }

                }

                catch (Exception ex) // bad date inputted
                {
                    bad_exp_date(sender, e); // inform user that their input was not suitable
                }

                
            }


        }

        protected void Delete_Exp_Date_button_Click(object sender, EventArgs e)
        {
            
            var mac_address = Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form
                                                                  // string mac_address = Mac_Address.Text;
            

            string exp_date = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac_address
                               select elem.EXP_DATE).FirstOrDefault().ToString(); // get exp date

            if (exp_date == "")
            {
                no_change_msg(sender, e);
                ddDay_Input.SelectedValue = "DD"; // reset default value
                ddMonth_Input.SelectedValue = "MM"; // reset default value
                ddYear_Input.SelectedValue = "YYYY"; // reset default value
            }
            else
            {
                DL.Log_Event(mac_address, 11, Session["username"].ToString(), exp_date, ""); // log event

                DL.delete_exp_date(mac_address, sender, e); // delete the exp date
                ddDay_Input.SelectedValue = "DD"; // reset default value
                ddMonth_Input.SelectedValue = "MM"; // reset default value
                ddYear_Input.SelectedValue = "YYYY"; // reset default value
                updated_information_msg(sender, e, "Expiration Date");
                //Page_Load(sender, e); // reload page
            }
        }





        protected string get_dev_type_proper(string mac_address_formatted) //format device type for our formatting grid
        {
            string type_id = (from elem in DC.DESKREG_SYSTEMS
                              where elem.AssetID == mac_address_formatted
                              select elem.TYPE_ID).First().ToString(); //pull type ID from DB (DeskregSystems) using mac

            string Type_name = (from elem in DC.DESKREG_TYPE
                                where elem.TYPE_ID.ToString() == type_id
                                select elem.TYPE_NAME).First().ToString(); // Pull the type name from DB (DeskregType) using the type ID retrieved above

            return Type_name; //return type name for our data grid display
        }

        protected string get_vlan_proper(string mac_address_formatted) //format VLAN to display properly for our data grid
        {
            string vlan = (from elem in DC.DESKREG_SYSTEMS
                           where elem.AssetID == mac_address_formatted
                           select elem.VLAN).First().ToString(); //pull VLAN from DB (deskregSystems) using the Mac

            string fixed_vlan = (from elem in DC.DESKREG_VLAN
                                 where elem.VLAN_NAME == vlan
                                 select elem.VLAN_NO + " - " + elem.VLAN_NAME).SingleOrDefault(); //Format VLAN with its number and name

            return fixed_vlan; //return the formatted vlan for our data grid display
        }

        protected void LMC_Device_Formatting(string mac_address) 
        {
            if (User_ID_Row.Visible != true) //check if a residential student's device is being switched (has extra rows)
            {
                Owner_Name.Text = "Le Moyne College"; //set owner's name
            }
            
        }

        protected void Resnet_Device_Formatting(string mac_address)
        {
            if (Owner_Name.Text  != "Le Moyne College")
            {
                string unique_ID = (from elem in DC.DESKREG_SYSINFO
                                    where elem.AssetID == mac_address
                                    select elem.UNIQUE_ID).FirstOrDefault(); // get unique ID for the mac address registered from DB (sysinfo)

                string user_ID = (from elem in DC.DESKREG_USERINFO
                                  where elem.UNIQUE_ID == unique_ID
                                  select elem.USERID).FirstOrDefault(); // get the user's ID using the unique ID pulled above

                string owner_Name = (from elem in DC.DESKREG_USERINFO
                                     where elem.UNIQUE_ID == unique_ID
                                     select elem.USER_FNAME + " " + elem.USER_LNAME).FirstOrDefault(); // get the owner's name


                User_ID_Row.Visible = true; //add user ID row
                User_ID.Text = user_ID;

                Unique_ID_Row.Visible = true; // add unique ID row
                Unique_ID_Number.Text = unique_ID;

                //Owner_Name.Text = owner_Name; // fill out owner's name

                HyperLink link = new HyperLink();
                link.NavigateUrl = ("RegSearchUserID_LIST_User.aspx?username=" + user_ID +"&next=" + "20"); // create a link to the user's info inside each username
                link.Text = owner_Name;
                Owner_Name.Controls.Add(link);
                


            }
        }

        protected void bad_exp_date(object sender, EventArgs e) //message to inform user to try again after failed search
        {
            string script = DL.generic_message(sender, e, "Please Submit A Proper Expiration Date", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "bad_exp_date", script, true);
        }

        protected void updated_information_msg(object sender, EventArgs e, string item_modified)
        {
            string script = DL.generic_message(sender, e, item_modified + " was modified successfully", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "update_confirmation_msg", script, true);
        }

        protected void no_change_msg(object sender, EventArgs e) //message to inform user to try again after failed search
        {
            string script = DL.generic_message(sender, e, "No change detected. Stop just hitting buttons", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_change_msg", script, true);
        }
    }

}