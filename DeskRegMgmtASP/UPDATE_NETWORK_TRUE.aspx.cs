using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace DeskRegMgmtASP
{
    public partial class UPDATE_NETWORK_TRUE : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string update_network_file = @"D:\Sites\deskreg-mgmt\UpdateNetwork\UpdateNetwork.txt"; // create file for devices
          
            if (File.Exists(update_network_file)) // check if file exists - prevent an error of trying to overwrite by deleting file
            {
                File.Delete(update_network_file); // delete file if it exists
            }

            StreamWriter sw = File.CreateText(update_network_file); // open a streamwriter to the file to allow for the writing of text
            
            List<string> device_list = (from elem in DC.DESKREG_SYSTEMS
                                where elem.DISABLED == "N" && (elem.EXP_DATE == null || elem.EXP_DATE > DateTime.Now)
                                select elem.AssetID +" " + elem.VLAN).ToList(); // get all devices that arent expired or disabled to be part of the network update

            int item_count = device_list.Count; // count of the devices will be the all devices that are "registered" so we want this to show to the user
            
            for (int i = 0; i < device_list.Count; i++) // for all devices in the list
            {
                Write_Line(sw, device_list[i].Substring(0, 14), device_list[i].Substring(15)); // write a line for the text file
            }
            sw.Close();

            
            Boolean confirmed_update = false; // set our update status to false to start
            var fail_counter = 0; // initialize our fail counter 

            while(confirmed_update == false && fail_counter < 6) // Try to update the network - will stop after 5 tries
            {
                confirmed_update = DeskRegLogic.MoveFile(); // attempt to move file to secured server
                fail_counter += 1; // if it does not work - iterate up by one
            }

            if (confirmed_update == true) // update worked
            {
                //add stylistic changes to show user if the update was successful
                Update_Confirmation_Cell.Text = "Update Successful";
                Update_Confirmation_Cell.Style.Add("color", "#006633");
                device_number_cell.Text = item_count.ToString();
                device_number_cell.Style.Add("color", "#006633");
                DL.Log_Event("UPDATE NETWORK", 29, Session["username"].ToString(), "", item_count.ToString() + " devices"); // log event

            }
            else // update failed
            {
                //add stylistic changes to show user if the update wasnt successful
                Update_Confirmation_Cell.Text = "Update Failed. Please Try Again!";
                Update_Confirmation_Cell.Style.Add("color", "red");
                device_number_cell.Text = item_count.ToString();
                device_number_cell.Style.Add("color", "red");
                DL.Log_Event("UPDATE NETWORK", 29, Session["username"].ToString(), "", "FAILED UPDATE"); // log event
            }
        }

        protected void Write_Line(StreamWriter sw, string mac_address, string vlan) // method to run for each line
        {
            sw.WriteLine("address " + mac_address + " vlan-name " + vlan); // write a line for the specific device - has the mac address and the vlan
            
        }


        public string AppendTimeStamp(string fileName) // add the timestamp for the archived file
        {
            return Path.Combine(Path.GetDirectoryName(fileName),
                string.Concat(Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmss"),
                Path.GetExtension(fileName)));
        }

        
    }
}