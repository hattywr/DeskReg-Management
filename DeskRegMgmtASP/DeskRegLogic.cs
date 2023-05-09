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
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

namespace DeskRegMgmtASP
{
    public class DeskRegLogic
    {

        //establish DB connection
        usrregDevEntities DC = new usrregDevEntities();



        public string val_MAC(string MacAd) //Validate Mac Address and its content 
        {

            //string noextraChar = String.Join("", MacAd.Split('.', ':', '-', ';', ',')); 
            string noextraChar = String.Concat(MacAd.Where(ch => Char.IsLetterOrDigit(ch))); //Remove all non-letter/number characters from user input
            if (noextraChar.Length == 12)// With all extra characters gone len(string) should just be 12
            {
                //place periods after every 4 characters 
                for (int i = 4; i < 10; i = i + 5)
                {
                    noextraChar = noextraChar.Insert(i, ".");
                }
                return noextraChar.ToUpper(); //Make all letters uppercase for submission

            }
            else //len(string)!=12: returns null- will then fail in validation for all values (see val_Input method below) and display error message to user
            {
                noextraChar = null;
                return noextraChar;
            }

        }

        public List<string> GetVLANs()
        {

            return (from elem in DC.DESKREG_VLAN
                    where elem.VLAN_SHOW == "Y"
                    orderby elem.VLAN_NO
                    select elem.VLAN_NO + " - " + elem.VLAN_NAME).ToList(); // retrieve all VLANS that are "visible" in the deskreg_vlan table
        }

        public List<string> Get_ALL_VLANS()
        {
            return (from elem in DC.DESKREG_VLAN
                    orderby elem.VLAN_NO
                    select elem.VLAN_NO + " - " + elem.VLAN_NAME).ToList(); // retrieve all VLANS in the deskreg_vlan table
        }


        public List<string> GetDevTypes()
        {
            return (from elem in DC.DESKREG_TYPE
                    select elem.TYPE_NAME).ToList(); // get device types from the deskreg_type table
        }

        public int val_InputExternal(string tbMac, string tbEQName, string ddDeviceType, string ddVLAN, string ddDay, string ddMonth, string ddYear) //Ensure all values are legitimate and ready to be inputted
        {

            // Custom Response Codes - tied to methods in our registration pages
            if (this.val_MAC(tbMac) == null | tbEQName.Length == 0 | ddDeviceType == "Choose Type" |
            ddVLAN == "Choose VLAN")  //| ddDay == "DD" | ddMonth == "MM" | ddYear == "YYYY")
            {
                if (this.val_MAC(tbMac) == null)
                {
                    return 1;
                }
                else if (tbEQName.Length == 0)
                {
                    return 2;
                }
                else if (ddDeviceType == "Choose Type")
                {
                    return 3;
                }
                else if (ddVLAN == "Choose VLAN")
                {
                    return 4;
                }

                return 404;
            }
            //Ensure that MAC address is legitimate and that the user has inputted items for all other fields

            else if (ddVLAN == "76 - guest")
            {
                if (ddDay == "DD" || ddMonth == "MM" || ddYear == "YYYY")
                {
                    return 5;
                }
                else
                {
                    return 6;
                }
            }


            else //All values valid
            {
                return 6;
            }


        }

        //method to "Update Network." Moves a file from our hosting server to the server which "talks" to the router (file is created and filled in Update Network True page)
        internal static Boolean MoveFile()
        {
            try
            {
                //designate our file source/location
                string fileSource = @" D:\Sites\deskreg-mgmt\UpdateNetwork\UpdateNetwork.txt"; 

                if (!File.Exists(fileSource)) return false; //file does not exist (something went wrong in other method- file has not been created/filled)
                
                //designate our network share and the exact name of our target location
                string networkShare = @"--this was the servershare name-->removed for security";
                string destFileName = networkShare + @"--this was the file type";

                //attempt to dispose of any connection that may exist
                Process x = new Process();
                ProcessStartInfo test_for_connection = new ProcessStartInfo("net.exe", @"use --this was the servershare name-->removed for security /delete");
                test_for_connection.CreateNoWindow = true; // this and next line hide the process window from user
                test_for_connection.WindowStyle = ProcessWindowStyle.Hidden; 
                x.StartInfo = test_for_connection;
                x.Start(); //remove potential connection
                
                //create our connection
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("net.exe", @"use --this was the servershare name-->removed for security --this was the password lol its gone now you thought Id leave it????\ /user:This was the username");
                psi.CreateNoWindow = true; // this and next line hide the process window from user
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo = psi;
                p.Start(); //creates our connection

                //attempt to delete file
                if (File.Exists(destFileName))
                {
                    File.Delete(destFileName);
                }
                File.Copy(fileSource, destFileName, true); //overwrite target location with our current file on the hosting server

                // adapted version to hide the cmd menus
                Process z = new Process();
                ProcessStartInfo info = new ProcessStartInfo("net.exe", @"use  --this was the servershare name-->removed for security /delete");
                info.CreateNoWindow = true; // this and next line hide the process window from user
                info.WindowStyle = ProcessWindowStyle.Hidden;
                z.StartInfo = info;
                z.Start(); //dispose of our process

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }

        public Boolean RegisterEQ(string ddVLAN, string ddYear, string ddMonth, string ddDay, string ddDeviceType, string tbmac, string tbEQName)
        {
            //Create our entry to be written into SQL
            DESKREG_SYSTEMS reg_Sys = new DESKREG_SYSTEMS();
            string vlan = fix_VLAN(ddVLAN);

            //Format Date/Time for expiration and registration dates
            if (ddMonth == "MM" || ddDay == "DD" || ddYear == "YYYY" || ddMonth == null || ddDay == null || ddYear == null)
            {
                ddDay = null;
                ddMonth = null;
                ddVLAN = null;
                reg_Sys.EXP_DATE = null;
            }
            else
            {
                int year = Int32.Parse(ddYear);
                int month = Int32.Parse(ddMonth);
                int day = Int32.Parse(ddDay);
                DateTime exp_Date = new DateTime(year, month, day);
                reg_Sys.EXP_DATE = exp_Date;
            }

            DateTime reg_Date = DateTime.Now;

            //Match the Device Type # (ID) to the Device Type Name
            int dev_type_ID = (from elem in DC.DESKREG_TYPE
                               where elem.TYPE_NAME == ddDeviceType
                               select elem).First().TYPE_ID;



            //Fill all class variables with chosen values
            reg_Sys.AssetID = val_MAC(tbmac);
            reg_Sys.TYPE_ID = dev_type_ID;
            reg_Sys.VLAN = vlan;
            reg_Sys.AssetName = tbEQName;
            //reg_Sys.EXP_DATE = null;
            reg_Sys.REG_DATE = reg_Date;
            reg_Sys.MAKE_ID = null;
            reg_Sys.MODEL_ID = 1;
            reg_Sys.DISABLED = "n";

            //Add VALIDATED Values to the SQL Database and Save Changes
            DC.DESKREG_SYSTEMS.Add(reg_Sys);
            //Ensure that changes go through 
            try
            {
                DC.SaveChanges(); //Save changes to SQL Table
                return true;
            }
            catch (Exception) //DB Update failed-catch exception and inform user
            {
                return false;
            }
        }

        public Boolean delete_device(string mac_to_delete, Object sender, EventArgs e)
        {
            var asset_to_delete = (from elem in DC.DESKREG_SYSTEMS
                                   where elem.AssetID == mac_to_delete
                                   select elem).Single(); // retrieve the asset ID via the passed in mac address

            DC.DESKREG_SYSTEMS.Remove(asset_to_delete); // remove the device from the table
            DC.SaveChanges();  // save changes

            return true;
        }

        public void enable_device(string mac, Object sender, EventArgs e)
        {
            var status = (from elem in DC.DESKREG_SYSTEMS
                          where elem.AssetID == mac
                          select elem).Single(); // pull the device status cell to edit

            status.DISABLED = "n"; // change the status to n (enable the device)
            DC.SaveChanges(); // save the changes
        }

        public void disable_device(string mac, Object sender, EventArgs e)
        {
            var status = (from elem in DC.DESKREG_SYSTEMS
                          where elem.AssetID == mac
                          select elem).Single(); // pull the device status cell to edit

            status.DISABLED = "y"; // change the status to y (disable device)
            DC.SaveChanges(); // save the changes
        }

        public void disable_user(string username, Object sender, EventArgs e)
        {
            var status = (from elem in DC.DESKREG_USERINFO
                          where elem.USERID == username
                          select elem).Single(); // get the user status cell to edit

            status.DISABLED = "Y"; // change the status to Y (disable the user)
            DC.SaveChanges(); // save the changes
        }

        public void enable_user(string username, Object sender, EventArgs e)
        {
            var status = (from elem in DC.DESKREG_USERINFO
                          where elem.USERID == username
                          select elem).Single(); // get the user status cell to edit

            status.DISABLED = "N"; // change the status to N (enable the user)
            DC.SaveChanges(); // save the changes
        }

        public void change_name(string mac, string new_name, Object sender, EventArgs e)
        {
            var name = (from elem in DC.DESKREG_SYSTEMS
                        where elem.AssetID == mac
                        select elem).Single(); // get the asset name cell to edit

            name.AssetName = new_name; // change the asset name
            DC.SaveChanges(); // save the changes
        }

        public void change_dev_type(string mac, string new_dev_type, Object sender, EventArgs e)
        {
            var dev_type_number = (from elem in DC.DESKREG_TYPE
                                   where elem.TYPE_NAME == new_dev_type
                                   select elem.TYPE_ID).Single(); // retrieve the dev type number via the type name

            var dev_type = (from elem in DC.DESKREG_SYSTEMS
                            where elem.AssetID == mac
                            select elem).Single(); // get the dev type record in deskreg_systems to edit

            dev_type.TYPE_ID = dev_type_number; // change the dev type number 
            DC.SaveChanges(); // save the changes
        }

        public void change_vlan(string mac, string new_vlan, Object sender, EventArgs e)
        {
            string formatted_vlan = fix_VLAN(new_vlan); // format vlan to not have extra "-" etc

            var vlan = (from elem in DC.DESKREG_SYSTEMS
                        where elem.AssetID == mac
                        select elem).Single(); // get the vlan cell from deskrgeg_systems to edit

            vlan.VLAN = formatted_vlan; // change the vlan
            DC.SaveChanges(); // save changes

        }

        public void change_exp_date(string mac_address, string new_exp_date, Object sender, EventArgs e)
        {
            DESKREG_SYSTEMS Stuff = (from elem in DC.DESKREG_SYSTEMS
                                     where elem.AssetID == mac_address
                                     select elem).ToList().FirstOrDefault(); //open the exp date cell to be edited

            if (new_exp_date == "YYYY-MM-DD") // exp date has not changed or is being deleted
            {
                Stuff.EXP_DATE = null; //set exp date in the table to null
            }
            else
            {
                DateTime new_date = Convert.ToDateTime(new_exp_date); // create new date time from the new exp date passed in
                Stuff.EXP_DATE = new_date; // change exp date in the table
            }
            DC.SaveChanges(); // save changes
        }

        public void delete_exp_date(string mac_address, Object sender, EventArgs e)
        {
            DESKREG_SYSTEMS Stuff = (from elem in DC.DESKREG_SYSTEMS
                                     where elem.AssetID == mac_address
                                     select elem).ToList().FirstOrDefault(); //open the exp date cell to be edited
            Stuff.EXP_DATE = null; // set exp date to null in table
            DC.SaveChanges(); // save changes

        }

        public void Log_Event(string mac_address, int action_id, string event_owner, string event_from, string event_to) // write an event to the Deskreg_event table
        {

            DESKREG_EVENT DE = new DESKREG_EVENT(); // create our new event

            var highest_event = DC.DESKREG_EVENT.Max(x => x.EVENT_ID); // get the highest past event

            // fill in all pieces for our addition to the table
            DE.EVENT_ID = highest_event + 1; // set the event ID to one higher than last event
            DE.EVENT_TIME = DateTime.Now;
            DE.ACTION_ID = action_id;
            DE.EVENT_OWNER = event_owner;
            DE.EVENT_TARGET = mac_address;
            DE.EVENT_FROM = event_from;
            DE.EVENT_TO = event_to;

            DC.DESKREG_EVENT.Add(DE); // add the new event to the table

            try
            {
                DC.SaveChanges(); // try to save the changes to the DB
            }
            catch (Exception)
            {
                // Message to tell user that logging of system action failed, tell them to contact dev team ASAP
            }
        }

        public void Update_Sys_Info(string mac_address, string user_ID)
        {
            DESKREG_SYSINFO DS = new DESKREG_SYSINFO(); // create a new system for sysinfo


            // fill in all pieces for our addition statement
            DS.AssetID = this.val_MAC(mac_address);
            DS.UNIQUE_ID = user_ID;
            DS.OS = "DeskRegAdmin";
            DS.Browser = "DeskRegAdmin";

            DC.DESKREG_SYSINFO.Add(DS); // add our entry to the table
            DC.SaveChanges(); // save changes to the DB
        }

        public void delete_from_sys_info(string mac_address)
        {
            var asset_to_delete = (from elem in DC.DESKREG_SYSINFO
                                   where elem.AssetID == mac_address
                                   select elem).Single(); // get the asset to delete from the mac passed in

            DC.DESKREG_SYSINFO.Remove(asset_to_delete); // remove the asset from the DB
            DC.SaveChanges(); // save the changes to the DB
        }

        public string generic_message(object sender, EventArgs e, string message1, string script1)
        {
            //Display message informing user to fix input
            script1 += message1;
            script1 += "')},25);";
            return script1;
        }

        public string fix_VLAN(string vlan)
        {
            string spaces = vlan.Substring(vlan.IndexOf('-') + 1); // remove up to the first occurence of the "-"
            string fixed_vlan = spaces.Substring(spaces.IndexOf(' ') + 1); // remvove spaces 
            return fixed_vlan; // return the fixed version
        }

        public void create_vlan(string vlan_name, int vlan_no, string vlan_visible)
        {
            DESKREG_VLAN DV = new DESKREG_VLAN(); // create our new event

            int highest_vlan_ID = DC.DESKREG_VLAN.Max(x => x.VLAN_ID); // get the highest vlan ID

            //assign all entry values
            DV.VLAN_ID = highest_vlan_ID + 1; // create a unique vlan ID
            DV.VLAN_NAME = vlan_name;
            DV.VLAN_NO = vlan_no;
            DV.VLAN_SHOW = vlan_visible;


            DC.DESKREG_VLAN.Add(DV); //add our entry to the table
            DC.SaveChanges(); // save changes to the DB

        }

        public void delete_vlan(int vlan_ID)
        {
            var vlan_to_delete = (from elem in DC.DESKREG_VLAN
                                  where elem.VLAN_ID == vlan_ID
                                  select elem).Single(); // get the asset to delete from the vlan ID passed in

            DC.DESKREG_VLAN.Remove(vlan_to_delete); // remove the asset from the DB
            DC.SaveChanges(); // save the changes to the DB
        }

        public void update_vlan(int vlan_ID, string vlan_name, int vlan_no, string vlan_visible)
        {
            DESKREG_VLAN DV = (from elem in DC.DESKREG_VLAN
                               where elem.VLAN_ID == vlan_ID
                               select elem).ToList().FirstOrDefault(); //"open" the VLAN entry to be edited

            //assign our new values
            DV.VLAN_NAME = vlan_name;
            DV.VLAN_NO = vlan_no;
            DV.VLAN_SHOW = vlan_visible;

            DC.SaveChanges(); // save our changes

        }

    }

}