using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace DeskRegMgmtASP
{
    public partial class Reg_Confirm_Delete : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string mac_address= Request.QueryString["Mac_Address"]; //retrieve the Mac Address sent from Search Mac address form


            string dev_name = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac_address
                               select elem.AssetName).FirstOrDefault(); // get the device's name if it exists in the DB

            Mac_Address_cell.Text = mac_address; // add the mac to the mac cell

            User_Name_cell.Text = dev_name; // add the device name to the cell

            string VLAN = (from elem in DC.DESKREG_SYSTEMS
                           where elem.AssetID == mac_address
                           select elem.VLAN).FirstOrDefault(); // get the vlan

            VLAN_cell.Text = VLAN; // add the vlan to the vlan cell

            string exp_date = (from elem in DC.DESKREG_SYSTEMS
                               where elem.AssetID == mac_address
                               select elem.EXP_DATE).FirstOrDefault().ToString(); // get the exp date

            Exp_Date_cell.Text = exp_date; // add the exp date to the exp date cell
            
        }

        protected void confirm_delete_button_Click(object sender, EventArgs e)
        {
            var mac_to_delete = Request.QueryString["Mac_Address"]; // retrieve the mac address to be deleted

            bool success = DL.delete_device(mac_to_delete, sender, e); // try and delete the mac address
            if (success == true) // device was deleted from the deskreg_systems table
            {
                DL.Log_Event(mac_to_delete, 3, Session["username"].ToString(), VLAN_cell.Text, null); // log the event
                try // check if the device also exists in sysinfo (resnet device)
                {
                   DL.delete_from_sys_info(mac_to_delete); // delete device from sysinfo as well
                }
                catch (Exception ex)
                {

                }
                Confirm_Delete_Info.Visible = false; // hide the table containing device info
                confirm_delete_button.Visible = false; // hide delete button
                delete_confirmed.Visible = true; // show the confirmed delete message
                main_menu.Visible = true; // show link back to main menu
            }
        }


    }
}