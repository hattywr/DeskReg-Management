using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class LeMoyneEQ_STATS : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true); // adjust size of the page for easier viewing


            var device_count = DC.DESKREG_SYSTEMS.Select(x => x.AssetID).Count(); // retrieve device count of all systems in DC deskreg_systems

            device_count_cell.Text = device_count.ToString(); 

            var disabled_systems = DC.DESKREG_SYSTEMS.Where(x => x.DISABLED == "Y").Select(z => z.AssetID).Count(); // retrieve count of all disabled systems

            disabled_system_count_cell.Text = disabled_systems.ToString();

            var blocked_systems = DC.DESKREG_SYSTEMS.Where(x => x.DISABLED == "B").Select(z => z.AssetID).Count(); // retrieve all blocked systems

            blocked_system_count_cell.Text = blocked_systems.ToString();


            var device_types = DC.DESKREG_TYPE.Select(x => x.TYPE_NAME).ToList(); // make a list of dev types

            var vlans = DC.DESKREG_VLAN.Select(x => x.VLAN_NAME).ToList(); // make a list of vlans

            

            create_dev_type_stats_table(device_types, dev_type_table, device_count); // create the device type stats table

            create_vlan_stats_table(vlans, vlan_type_table, device_count); // create the vlan stats table

        }

        protected void create_dev_type_stats_table(List<string> dev_type, Table table, int total_dev_count)
        {
            foreach(string i in dev_type) // run for every type of device
            {
                string dev_type_number = (from elem in DC.DESKREG_TYPE
                                       where elem.TYPE_NAME == i
                                       select elem.TYPE_ID).FirstOrDefault().ToString(); // get the proper dev type number from the name

                int fixed_dev_type_number = Convert.ToInt32(dev_type_number);

                var dev_count_for_type = (from elem in DC.DESKREG_SYSTEMS
                                          where elem.TYPE_ID == fixed_dev_type_number
                                          select elem.AssetID).Count(); // get a count of the devices per device type



                //calculate the percentage and format it cleanly for our cells

                string percentage = ((decimal)dev_count_for_type / total_dev_count).ToString("N6"); 

                if (percentage != "0") // some devices are registered under this dev type
                {
                    //format our percentage
                    percentage = percentage.Substring(0, 5);
                    percentage = percentage.Remove(0, 2);
                    percentage = percentage.Insert(2, ".");

                    if (percentage.Substring(0, 1) == "0") // there is a leading 0
                    {
                        percentage = percentage.Remove(0, 1);
                    }

                    percentage = percentage + "%";


                    //create the table row for each device type w/ stats etc
                    TableRow row = new TableRow();

                    // add our device type name to the table
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    //add our device count to the table
                    TableCell cell2 = new TableCell();
                    cell2.CssClass = "generic_table_cell";
                    cell2.Style.Add("width", "25%");
                    cell2.Style.Add("font-size", "medium");
                    cell2.Text = dev_count_for_type.ToString();

                    //add our percentage to the table
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "generic_table_cell";
                    cell3.Style.Add("width", "35%");
                    cell3.Style.Add("font-size", "medium");
                    cell3.Text = percentage;

                    //add our cells to the row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add our row to the table
                }
                else // no dev types are registered under this dev type
                {
                    //create the table row for each device type w/ stats etc
                    TableRow row = new TableRow();

                    // add our device type name to the table
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    //add our device count to the table
                    TableCell cell2 = new TableCell();
                    cell2.CssClass = "generic_table_cell";
                    cell2.Style.Add("width", "25%");
                    cell2.Style.Add("font-size", "medium");
                    cell2.Text = "0";

                    //add our percentage to the table
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "generic_table_cell";
                    cell3.Style.Add("width", "35%");
                    cell3.Style.Add("font-size", "medium");
                    cell3.Text = "0.0%";

                    // add our cells to the row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to the table
                }



            }
        }

        protected void create_vlan_stats_table(List<string> vlans, Table table, int total_dev_count) // to create the vlan stats table one row at a time
        {

            foreach (string i in vlans) // will run for each vlan
            {
                var devs_per_vlan = (from elem in DC.DESKREG_SYSTEMS
                                     where elem.VLAN == i
                                     select elem.AssetID).Count(); // get the count of devices registered for the specific vlan


                // calculate the percentage of devices relative to the total
                string percentage = ((decimal)devs_per_vlan / total_dev_count).ToString("N6"); 

                if(percentage != "0") // some devices exist for the vlan
                {
                    //format our percentage
                    percentage = percentage.Substring(0, 5);
                    percentage = percentage.Remove(0, 2);
                    percentage = percentage.Insert(2, ".");

                    if (percentage.Substring(0, 1) == "0") // percentage has a leading 0
                    {
                        percentage = percentage.Remove(0, 1);
                    }

                    percentage = percentage + "%";


                    // create the row with the devices and stats
                    TableRow row = new TableRow();

                    // add vlan name to our row
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    // add our device count for that vlan to our row
                    TableCell cell2 = new TableCell();
                    cell2.CssClass = "generic_table_cell";
                    cell2.Style.Add("width", "25%");
                    cell2.Style.Add("font-size", "medium");
                    cell2.Text = devs_per_vlan.ToString();

                    // add our percentage to our row
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "generic_table_cell";
                    cell3.Style.Add("width", "35%");
                    cell3.Style.Add("font-size", "medium");
                    cell3.Text = percentage;

                    //add cells to our row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to our table
                }

                else // no devices are registered on this vlan
                {
                    // create the row with the devices and stats
                    TableRow row = new TableRow();

                    // add vlan name to our row
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    // add our device count for that vlan to our row
                    TableCell cell2 = new TableCell();
                    cell2.CssClass = "generic_table_cell";
                    cell2.Style.Add("width", "25%");
                    cell2.Style.Add("font-size", "medium");
                    cell2.Text = "0";

                    // add our percentage to our row
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "generic_table_cell";
                    cell3.Style.Add("width", "35%");
                    cell3.Style.Add("font-size", "medium");
                    cell3.Text = "0.0%";

                    //add cells to our row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to our table
                }

                
            }

        }
    }
}