using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchUserID_LIST_User : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"].ToString(); // get username from previous form submission

            DESKREG_USERINFO user_info = (from elem in DC.DESKREG_USERINFO
                                          where elem.USERID == username
                                          select elem).Single();

            Full_Name.Text = user_info.USER_FNAME + " " + user_info.USER_LNAME;

            Unique_ID.Text = user_info.UNIQUE_ID;

            string status = user_info.DISABLED;


            if (status == "N") // user is enabled
            {
                status_lbl.Text = "Enabled";
                enable_user_button.Visible = false; // hide enable button
                disable_user_button.Visible = true; // show disable button
            }
            else // user is disabled
            {
                status_lbl.Text = "Disabled";
                enable_user_button.Visible = true; // show enable button
                disable_user_button.Visible = false; // hide disable button
            }


            List<string> users_systems = (from elem in DC.DESKREG_SYSINFO
                                            where elem.UNIQUE_ID == user_info.UNIQUE_ID
                                            select elem.AssetID).ToList(); // get list of all mac addresses registered to one username
                
            int i = 0;

            foreach(string element in users_systems)
            {
                i = i + 1;
                string mac_address = DL.val_MAC(element); // validate and fix the mac to make sure it is valid (should never have been able to make it into tables if it is not in proper form)
                DESKREG_SYSTEMS Systems = (from elem in DC.DESKREG_SYSTEMS
                                           where elem.AssetID == mac_address
                                           select elem).Single();

                DESKREG_SYSINFO Sysinfo = (from elem in DC.DESKREG_SYSINFO
                                           where elem.AssetID == mac_address
                                           select elem).Single();

                create_device_table(i, Systems, Sysinfo); // create a data table for each system with all buttons etc as needed
            }
        }

  
        /// <summary>
        ///DA 12/16/22 You can make summaries of your methods here, the shortcut is /// above the method to describe what
        ///the method does. 
        ///I would suggest some different parameters here since you query the database alot in this method. Find a way to pass
        ///in the entity (record) rather than the mac address since you have to requery for it several times
        /// </summary>
        /// <param name="i"></param>
        /// <param name="mac"></param>
        protected void create_device_table(int i, DESKREG_SYSTEMS System, DESKREG_SYSINFO SYSinfo)
        {
            
            var id = ("System" + i.ToString()); // create table ID
            var table = new Table { ID = id }; //create table and assign it the above ID
            tablePlaceHolder.Controls.Add(table); // overwrite to placeholder on the ASPX side
            table.CssClass = "Table_Style"; // add CSS class
            table.Style.Add("WIDTH", "100%"); // adapt CSS class to fit page
            

            TableRow title = new TableRow(); 
            table.Controls.Add(title); // create title tablerow

            TableCell title_cell = new TableCell();
            title.Controls.Add(title_cell);
            title_cell.CssClass = "Title1";
            title_cell.Text = "System " + i.ToString();
            title_cell.ColumnSpan = 2; // Add Title Cell

            // Using the re-usable method to increase cleanliness and efficiency -  next portion of lines is all creating a table for each system the user has registered to his/her username
            // Table Creation Region
            #region TableCreation
            //stuff 
            TableRow mac_row = new TableRow();
            create_tbl_row(table, mac_row); // create mac row

            TableCell mac_cell = new TableCell();
            create_normal_cells(mac_row, mac_cell, "Mac Address", "Left_Cell1"); // create left side description cell

            TableCell mac_address = new TableCell();
            create_changeable_cells(mac_row, mac_address, "Right_Cell1");
            Label mac_lbl = new Label();
            mac_address.Controls.Add(mac_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)



            TableRow status_row = new TableRow();
            create_tbl_row(table, status_row); // create status row

            TableCell status_cell = new TableCell();
            create_normal_cells(status_row, status_cell, "Status:", "Left_Cell1"); // create left side description cell

            TableCell status_status_cell = new TableCell();
            create_changeable_cells(status_row, status_status_cell, "Right_Cell1");
            Label status_lbl = new Label();
            status_lbl.ID = System.AssetID + ".status_lbl";
            status_status_cell.Controls.Add(status_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)



            TableRow Equipment_row = new TableRow();
            create_tbl_row(table, Equipment_row); // create equipment row

            TableCell eq_name_cell = new TableCell();
            create_normal_cells(Equipment_row, eq_name_cell, "Equipment Name:", "Left_Cell1"); // create left side description cell

            TableCell actual_eq_name = new TableCell();
            create_changeable_cells(Equipment_row, actual_eq_name, "Right_Cell1");
            Label eq_name_lbl = new Label();
            actual_eq_name.Controls.Add(eq_name_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)



            TableRow OS_row = new TableRow();
            create_tbl_row(table, OS_row); // create OS row

            TableCell OS_name_cell = new TableCell();
            create_normal_cells(OS_row, OS_name_cell, "OS:", "Left_Cell1"); // create left side description cell

            TableCell actual_OS_name = new TableCell();
            create_changeable_cells(OS_row, actual_OS_name, "Right_Cell1");
            Label os_name_lbl = new Label();
            actual_OS_name.Controls.Add(os_name_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)


            TableRow Browser_row = new TableRow();
            create_tbl_row(table, Browser_row); // create browser row

            TableCell Browser_name_cell = new TableCell();
            create_normal_cells(Browser_row, Browser_name_cell, "Browser:", "Left_Cell1"); // create left side description cell

            TableCell actual_browser_name = new TableCell();
            create_changeable_cells(Browser_row, actual_browser_name, "Right_Cell1");
            Label browser_name_lbl = new Label();
            actual_browser_name.Controls.Add(browser_name_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)



            TableRow Dev_type_row = new TableRow();
            create_tbl_row(table, Dev_type_row); // create dev type row

            TableCell dev_type_name_cell = new TableCell();
            create_normal_cells(Dev_type_row, dev_type_name_cell, "Device Type:", "Left_Cell1"); // create left side description cell

            TableCell actual_dev_type_name = new TableCell();
            create_changeable_cells(Dev_type_row, actual_dev_type_name, "Right_Cell1");
            Label dev_type_lbl = new Label();
            actual_dev_type_name.Controls.Add(dev_type_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)


            TableRow Reg_date_row = new TableRow();
            create_tbl_row(table, Reg_date_row); // create reg date row

            TableCell reg_date = new TableCell();
            create_normal_cells(Reg_date_row, reg_date, "Registration Date:", "Left_Cell1"); // create left side description cell

            TableCell var_reg_date = new TableCell();
            create_changeable_cells(Reg_date_row, var_reg_date, "Right_Cell1");
            Label reg_date_lbl = new Label();
            var_reg_date.Controls.Add(reg_date_lbl); // add blank label to the right cell (to be filled in dynamically after table generation)



            TableRow Exp_date_row = new TableRow();
            create_tbl_row(table, Exp_date_row); // create exp date row

            TableCell exp_date = new TableCell();
            create_normal_cells(Exp_date_row, exp_date, "Expiration Date:", "Left_Cell1"); // create left side description cell

            TableCell actual_exp_date = new TableCell();
            create_changeable_cells(Exp_date_row, actual_exp_date, "Right_Cell1");

            HyperLink link = new HyperLink();
            link.NavigateUrl = ("Search_Mac_true.aspx?Mac_Address=" + System.AssetID); // create a link to the user's info inside each username
            link.Text = System.AssetID;


            // mac_lbl.Text = System.AssetID;
            mac_lbl.Controls.Add(link);

            Button delete_mac_button = new Button(); // create delete mac button
            create_delete_button(mac_address, delete_mac_button, "grid_button_style", System.AssetID); // style and add delete mac button to our mac cell

            Button enable_system_button = new Button();
            create_enable_system_button(status_status_cell, enable_system_button, "grid_button_style", System.AssetID); // create and fill the enable system button

            Button disable_system_button = new Button();
            create_disable_system_button(status_status_cell, disable_system_button, "grid_button_style", System.AssetID); // create and fill the disable system button


            if (System.DISABLED == "n") // System is enabled
            {
                status_lbl.Text = "Enabled";
                disable_system_button.Visible = true; // allow user to disable device
                enable_system_button.Visible = false; // hide enable button

            }
            else // system is disabled
            {
                status_lbl.Text = "Disabled";
                disable_system_button.Visible = false; // hide disable button
                enable_system_button.Visible = true; // allow user to enable device

            }

            if (System.AssetName.Length == 0) // no device name

                eq_name_lbl.Text = "N/A";

            else // device name exists

                eq_name_lbl.Text = System.AssetName;

            if (SYSinfo.OS != "") // OS Name exists
            
                os_name_lbl.Text = SYSinfo.OS;
            
            else // No OS name exists
            
                os_name_lbl.Text = "N/A";
            

            if (SYSinfo.Browser != "") // Browser name exists
            
                browser_name_lbl.Text = SYSinfo.Browser;
            
            else // browser name does not exist
            
                browser_name_lbl.Text = "N/A";
            

            string dev_db_type = (from elem in DC.DESKREG_TYPE
                                  where elem.TYPE_ID == System.TYPE_ID
                                  select elem.TYPE_NAME).Single().ToString(); // use type ID to get name of device type

            dev_type_lbl.Text = dev_db_type;

            if (System.REG_DATE == null) // no reg date
            
                reg_date_lbl.Text = "N/A";
            
            else // reg date exists
            
                reg_date_lbl.Text = System.REG_DATE.ToString();
            
            create_exp_date_dd(actual_exp_date, System.AssetID); // create and fill the exp date dropdowns

        }
        #endregion

        protected void create_tbl_row(Table table, TableRow row) // adds a row a table
        {
            table.Controls.Add(row);
        }

        protected void create_normal_cells (TableRow tableRow, TableCell cell, string cell_text, string Css_class) // add cells for cells that do not change (typically left side)
        {
            tableRow.Controls.Add(cell);
            cell.CssClass = Css_class;
            Label label = new Label();
            cell.Controls.Add(label);
            label.Text = cell_text;
            
        }

        protected void create_changeable_cells(TableRow tableRow, TableCell cell, string Css_class) // add cells for cells that will be filled with other items than just text (text too but not exclusively)
        {
            tableRow.Controls.Add(cell);
            cell.CssClass = Css_class;

        }

        protected void create_exp_date_dd(TableCell cell, string mac) // to create and fill the exp date dropdowns
        {
            DropDownList ddMonth_Input = new DropDownList(); // create dropdownlist
            ddMonth_Input.ID = mac + ".month_drop_down"; // assign a UNIQUE IDENTIFIER to this dropdown
            ddMonth_Input.CssClass = "drop_down"; // add CSS class
            ddMonth_Input.Style.Add("margin-left", "0px"); // adapt class to our needs
            ddMonth_Input.Items.Add("MM"); // add the default value
            ddMonth_Input.AppendDataBoundItems = true; // append default value
            cell.Controls.Add(ddMonth_Input); // and the Dropdown to the cell it will be going into

            Label slash1 = new Label();
            slash1.Text = "/";
            cell.Controls.Add(slash1); // add spacer between dropdowns

            DropDownList ddDay_Input = new DropDownList(); // create dropdown list
            ddDay_Input.ID = mac + ".day_drop_down"; // assign a UNIQUE IDENTIFIER to this dropdown
            ddDay_Input.CssClass = "drop_down"; // add CSS class
            ddDay_Input.Items.Add("DD"); // add the default value
            ddDay_Input.AppendDataBoundItems = true; // append default value
            cell.Controls.Add(ddDay_Input);  // and the Dropdown to the cell it will be going into

            Label slash2 = new Label();
            slash2.Text = "/";
            cell.Controls.Add(slash2); // add spacer between dropdowns

            DropDownList ddYear_Input = new DropDownList();  // create dropdown list
            ddYear_Input.ID = mac + ".year_drop_down";  // assign a UNIQUE IDENTIFIER to this dropdown
            ddYear_Input.CssClass = "drop_down"; // add CSS class
            ddYear_Input.Style.Add("WIDTH", "65px");   // adapt class to our needs
            ddYear_Input.Items.Add("YYYY");  // add the default value
            ddYear_Input.AppendDataBoundItems = true; // append default value
            cell.Controls.Add(ddYear_Input);  // and the Dropdown to the cell it will be going into

            if (ddMonth_Input.Items.Count <= 1) // make sure list hasnt already been created in a previous page load
            {
                for (int month = 1; month < 13; month++)
                {
                    ddMonth_Input.Items.Add(new ListItem(month.ToString(), month.ToString())); //Create list and fill Month DD menu
                }
                ddMonth_Input.DataBind(); // bind data to list

                for (int day = 1; day < 32; day++)
                {
                    ddDay_Input.Items.Add(new ListItem(day.ToString(), day.ToString())); //Create list and fill Day DD menu
                }
                ddDay_Input.DataBind(); // bind data to list

                for (int year = 2000; year < DateTime.Now.Year + 5; year++)
                {
                    ddYear_Input.Items.Add(new ListItem(year.ToString(), year.ToString())); //Create list and fill Year DD menu
                }
                ddYear_Input.DataBind(); // bind data to list
            }
               
                fill_exp_date(mac, ddDay_Input, ddMonth_Input, ddYear_Input); // fill in our Dropdown lists if applicable


                Button change_exp_date = new Button(); // create change_exp date button
                Button delete_exp_date = new Button(); // create delete exp date button
                create_change_exp_date_button(cell, change_exp_date, "grid_button_style", mac); // add all necessary pieces to the button (see method comments below)
                create_delete_exp_date_button(cell, delete_exp_date, "grid_button_style", mac); // add all necessary pieces to the button (see method comments below)




        }

        private void Delete_mac_button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // get the mac which was assigned as the idea via the button
            string mac = process_button_ID(buttonId); // manipulate string to only get the good mac
            Response.Redirect("Reg_Confirm_Delete.aspx?Mac_Address=" + mac + "&next=" + "21"); //pass mac through to the delete confirmation page
        }

        protected void disable_user_button_Click(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"].ToString(); // get username from previous form submission
            DL.disable_user(username, sender, e); // disable user
            DL.Log_Event(username, 12, Session["username"].ToString(), "User Enabled", "User Disabled"); // log event
            status_lbl.Text = "Disabled"; //change user status in our grid
            disable_user_button.Visible = false; // hide disable button
            enable_user_button.Visible = true; // allow user to re-enable the disabled user

        }

        protected void enable_user_button_Click(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"].ToString(); // get username from previous form submission
            DL.enable_user(username, sender, e); // enable the user
            DL.Log_Event(username, 13, Session["username"].ToString(), "User Disabled", "User Enabled"); // log the event
            status_lbl.Text = "Enabled"; // change user status in our grid
            disable_user_button.Visible = true; // allow the user to disable the user
            enable_user_button.Visible = false; // hide the enable button
        }

        private void disable_system_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button's unique ID
            string mac = process_button_ID(buttonId); // get the mac address from the ID
            DL.disable_device(mac, sender, e); // Disable the device
            DL.Log_Event(mac, 4, Session["username"].ToString(), "Enabled", "Disabled"); // log the event



            string enable_button_ID = mac + ".enable_system"; // assign variable to the UNIQUE IDENTIFIER we had assigned to this specific button upon creation

            Button enable_button = (Button)FindControlRecursive(Page, enable_button_ID); // find the button control
            if (enable_button != null) // control has been found
            {
                enable_button.Visible = true; //show enable button
            }
            string disable_button_ID = mac + ".disable_system"; // assign variable to the UNIQUE IDENTIFIER we had assigned to this specific button upon creation
            Button disable_button = (Button)FindControlRecursive(Page, disable_button_ID);  // find the button control
            if (disable_button != null) // control has been found
            {
                disable_button.Visible = false; // hide disable button
            }

            string lbl_ID = mac + ".status_lbl";  // assign variable to the UNIQUE IDENTIFIER we had assigned to this specific label upon creation
            Label status_lbl = (Label)FindControlRecursive(Page, lbl_ID); // find the label control
            if (status_lbl != null) //control exists
            {
                status_lbl.Text = "Disabled"; // change device status label
            }


        }

        private void enable_system_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string mac = process_button_ID(buttonId); // get the mac from the button ID
            DL.enable_device(mac, sender, e); // enable the device
            DL.Log_Event(mac, 5, Session["username"].ToString(), "Disabled", "Enabled"); // log the event



            string enable_button_ID = mac + ".enable_system";  // assign variable to the UNIQUE IDENTIFIER we had assigned to this specific button upon creation

            Button enable_button = (Button)FindControlRecursive(Page, enable_button_ID); // find the button control
            if (enable_button != null) // control exists
            {
                enable_button.Visible = false; // hide the enable button
            }
            string disable_button_ID = mac + ".disable_system";  // assign variable to the UNIQUE IDENTIFIER we had assigned to this specific button upon creation
            Button disable_button = (Button)FindControlRecursive(Page, disable_button_ID); // find the button control
            if (disable_button != null) // control exists
            {
                disable_button.Visible = true; // show the disable button
            }

            string lbl_ID = mac + ".status_lbl"; // assign variable to the UNIQUE IDENTIFIER we had assigned to this specific label upon creation
            Label status_lbl = (Label)FindControlRecursive(Page, lbl_ID); // find control
            if (status_lbl != null) // control exists
            {
                status_lbl.Text = "Enabled"; // change device status in our grid
            }

        }

        private void change_exp_date_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string mac = process_button_ID(buttonId); // get the mac from the button ID

            string old_exp_date = (from elem in DC.DESKREG_SYSTEMS
                                   where elem.AssetID == mac
                                   select elem.EXP_DATE).FirstOrDefault().ToString(); // get old EXP Date

            DropDownList ddDay_Input = (DropDownList)FindControlRecursive(Page, mac+ ".day_drop_down"); // find drop down control
            DropDownList ddMonth_Input = (DropDownList)FindControlRecursive(Page, mac + ".month_drop_down"); // find drop down control
            DropDownList ddYear_Input = (DropDownList)FindControlRecursive(Page, mac + ".year_drop_down" ); // find drop down control

            string new_exp_date = ddYear_Input.SelectedValue + "-" + ddMonth_Input.SelectedValue + "-" + ddDay_Input.SelectedValue; // create new exp date


            if (new_exp_date != "YYYY-MM-DD") // something was changed
            {
                
                
                    try
                    {
                        DateTime new_date = Convert.ToDateTime(new_exp_date); // create a new date and time from the inputted values
                        if (new_date.ToString() == old_exp_date)
                        {
                            no_change_msg(sender, e);
                        }
                        else
                        {
                            DL.change_exp_date(mac, new_exp_date, sender, e); // change the exp date
                            DL.Log_Event(mac, 10, Session["username"].ToString(), old_exp_date, new_date.ToString()); // log the change event   
                            updated_information_msg(sender, e, "Expiration Date");
                        }
                    
                    }

                    catch (Exception ex) // incorrect entry or only half inputted
                    {
                        bad_exp_date(sender, e); // inform user to fix their input
                    }
                
                
            }
            else
            {
                no_change_msg(sender, e); 
            }
    }

        private void delete_exp_date_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // assign the idea to a string
            string mac = process_button_ID(buttonId); // retrieve just the mac address from our ID

            string exp_date = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac
                               select elem.EXP_DATE).FirstOrDefault().ToString(); // get the old exp date from the table to log it into event table

            if (exp_date == "")
            {
                no_change_msg(sender, e);
                DropDownList ddDay_Input = (DropDownList)FindControlRecursive(Page, mac + ".day_drop_down"); // find dropdown control
                DropDownList ddMonth_Input = (DropDownList)FindControlRecursive(Page, mac + ".month_drop_down"); // find drop down control
                DropDownList ddYear_Input = (DropDownList)FindControlRecursive(Page, mac + ".year_drop_down"); // find drop down control
                ddDay_Input.SelectedValue = "DD"; // change value back to default
                ddMonth_Input.SelectedValue = "MM"; // change value back to default
                ddYear_Input.SelectedValue = "YYYY"; // change value back to default
            }

            else
            {
                DL.Log_Event(mac, 11, Session["username"].ToString(), exp_date, ""); // log event

                DL.delete_exp_date(mac, sender, e); // remove exp date from table
                updated_information_msg(sender, e, "Expiration Date");

                DropDownList ddDay_Input = (DropDownList)FindControlRecursive(Page, mac + ".day_drop_down"); // find dropdown control
                DropDownList ddMonth_Input = (DropDownList)FindControlRecursive(Page, mac + ".month_drop_down"); // find drop down control
                DropDownList ddYear_Input = (DropDownList)FindControlRecursive(Page, mac + ".year_drop_down"); // find drop down control
                ddDay_Input.SelectedValue = "DD"; // change value back to default
                ddMonth_Input.SelectedValue = "MM"; // change value back to default
                ddYear_Input.SelectedValue = "YYYY"; // change value back to default
            }

        }

        protected void create_delete_button(TableCell cell, Button button, string Css_Class, string mac)
        {
            button.ID = mac + ".delete_system"; // add unique identifier which contains mac address
            button.Text = "Delete"; // add button text
            button.CssClass = Css_Class; // add Css Class
            button.Click += Delete_mac_button_Click; // create button press event
            cell.Controls.Add(button); // add the button into the cell
        }

        protected void create_disable_system_button(TableCell cell, Button button, string Css_Class, string mac)
        {
            button.ID = mac + ".disable_system"; // add unique identifier which contains mac address
            button.Text = "Disable"; // add button text
            button.CssClass = Css_Class; // add Css class
            button.Click += disable_system_Click; // create button press event
            cell.Controls.Add(button); // add the button into the cell
        }

        protected void create_enable_system_button(TableCell cell, Button button, string Css_Class, string mac)
        {
            button.ID = mac + ".enable_system"; // add unique identifier which contains mac address 
            button.Text = "Enable"; // add button text
            button.CssClass = Css_Class; // add Css class
            button.Click += enable_system_Click; // create button press event
            cell.Controls.Add(button); // add the button into the cell
        }

        protected void create_change_exp_date_button(TableCell cell, Button button, string Css_Class, string mac)
        {
            button.ID = mac + ".change_exp_date"; // add unique identifier which contains mac address 
            button.Text = "Change"; // add button text
            button.CssClass = Css_Class; // add Css class
            button.Style.Add("margin-left", "1px"); // adapt the CSS to our specific needs
            button.Click += change_exp_date_Click; // create the button press event
            cell.Controls.Add(button); // add the button into the cell
        }

        protected void create_delete_exp_date_button(TableCell cell, Button button, string Css_Class, string mac)
        {
            button.ID = mac + ".delete_exp_date"; // add unique identifier which contains mac address 
            button.Text = "Delete"; // add button text
            button.CssClass = Css_Class; // add Css class
            button.Style.Add("margin-left", "1px"); // adapt the CSS to our specific needs
            button.Click += delete_exp_date_Click; // create the button press event
            cell.Controls.Add(button); // add the button to the cell
        }

        private string process_button_ID(string weird_mac) // need to remove the unique identifier added to the button on creation
        {
            string good_mac = weird_mac.Substring(0,14); // remove the added piece of the ID (.delete_button etc etc --> see the button creation and ID assignment methods) to get just the mac address we want
            return good_mac; // return just the mac address
        }

        protected void fill_exp_date(string mac, DropDownList ddDay_Input, DropDownList ddMonth_Input, DropDownList ddYear_Input)
        {
            DESKREG_SYSTEMS Stuff = (from elem in DC.DESKREG_SYSTEMS
                                     where elem.AssetID == mac
                                     select elem).ToList().FirstOrDefault(); //check exp date

            if (Stuff.EXP_DATE != null) // exp date exists
            {
                string exp_date = (from elem in DC.DESKREG_SYSTEMS
                                   where elem.AssetID == mac
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
        }

        private Control FindControlRecursive(Control root_controls, string id) // find a control in a page
        {
            if (root_controls.ID == id) // control wanted was the root control
            {
                return root_controls; // return the control 
            }

            foreach (Control c in root_controls.Controls) // for all controls in the master controller
            {
                Control found = FindControlRecursive(c, id); // recursve across list until control is found
                if (found != null) // the control exists
                {
                    return found; // return the specified control
                }
            }

            return null; // no controls that matched the wanted one were found
        }

        protected void bad_exp_date(object sender, EventArgs e) //message to inform user that expiration date wasnt proper
        {
            string script = DL.generic_message(sender, e, "Please Submit A Proper Expiration Date", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "bad_exp_date", script, true);
        }

        protected void no_change_msg(object sender, EventArgs e) //message to inform user that no change was detected 
        {
            string script = DL.generic_message(sender, e, "No change detected. Stop just hitting buttons", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "no_change_msg", script, true);
        }

        protected void updated_information_msg(object sender, EventArgs e, string item_modified) // message to tell user that an item was modified
        {
            string script = DL.generic_message(sender, e, item_modified + " was modified successfully", "window.onload = setTimeout(function(){ alert('");
            ClientScript.RegisterStartupScript(this.GetType(), "update_confirmation_msg", script, true);
        }
    }
}
