using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class ResnetEQ_STATS : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true); // adjust size of the page for easier viewing

            var dev_count = DC.DESKREG_SYSINFO.Select(x => x.AssetID).Count(); // get all devices in Sysinfo

            device_count_cell.Text = dev_count.ToString();

            var users_registered = DC.DESKREG_SYSINFO.Select(x => x.UNIQUE_ID).Distinct().Count(); // get all users that have a device registered in sysinfo

            user_reg_count.Text = users_registered.ToString();

            var dev_per_user = (decimal)dev_count/users_registered; // avg the number of devices per user

            dev_per_user = Math.Round(dev_per_user, 1); // round the result

            systems_per_user_cell.Text = dev_per_user.ToString();

            var all_sysinfo_systems = DC.DESKREG_SYSINFO.Select(x => x.AssetID).ToList(); // retrieve all systems in sysinfo

            var maybe_disabled = (from elem in DC.DESKREG_SYSTEMS
                                  where elem.DISABLED != "N"
                                  select elem.AssetID).ToList(); // check all systems in deskreg systems which are disabled

            int disabled_devs = 0;

            foreach (string i in maybe_disabled) // for all disabled systems
            {
                var found = DC.DESKREG_SYSINFO.Any(x => x.AssetID == i); // check if that disabled system exists in sysinfo -keep track of number
                if (found == true)
                {
                    disabled_devs += 1;
                }
            }
            disabled_system_count_cell.Text = disabled_devs.ToString();


            int disabled_users = (from elem in DC.DESKREG_USERINFO
                                  where elem.DISABLED != "N"
                                  select elem.UNIQUE_ID).Count(); // retrieve all disabled or blocked users

            disabled_user_count_cell.Text = disabled_users.ToString();

            var device_types = DC.DESKREG_TYPE.Select(x => x.TYPE_NAME).ToList(); // get all devices types

            var browser_types = DC.DESKREG_SYSINFO.Select(x => x.Browser).Distinct().ToList(); // get all browser types

            create_dev_type_stats_table(device_types, dev_type_table, dev_count); // create a dev type table with stats etc

            create_browser_stats_table(browser_types, Browser_type_table, dev_count); // create browser stats table

        }


        protected void create_dev_type_stats_table(List<string> dev_type, Table table, int total_dev_count)
        {
            foreach (string i in dev_type) // for every dev type
            {
                string dev_type_number = (from elem in DC.DESKREG_TYPE
                                          where elem.TYPE_NAME == i
                                          select elem.TYPE_ID).FirstOrDefault().ToString(); // get proper number of the dev type

                int fixed_dev_type_number = Convert.ToInt32(dev_type_number);

                var dev_count_for_type_systems = (from elem in DC.DESKREG_SYSTEMS
                                          where elem.TYPE_ID == fixed_dev_type_number
                                          select elem.AssetID).ToList(); // get all devices in deskreg systems that have that dev type

                int dev_count_for_type_sysinfo = 0;
                foreach (string asset_id in dev_count_for_type_systems) // for every device with that dev type 
                {
                    var found = DC.DESKREG_SYSINFO.Any(x => x.AssetID == asset_id); // find if that dev exists in sysinfo - keep track of count
                    if (found == true)
                    {
                        dev_count_for_type_sysinfo += 1;
                    }
                }


                //calculate percentage of devices relative to the total
                string percentage = ((decimal)dev_count_for_type_sysinfo / total_dev_count).ToString();

                if (percentage != "0") // devices exist 
                {
                    //format percentage as needed
                    percentage = percentage.Substring(0, 5);
                    percentage = percentage.Remove(0, 2);
                    percentage = percentage.Insert(2, ".");

                    // there is a leading 0
                    if (percentage.Substring(0, 1) == "0")
                    {
                        percentage = percentage.Remove(0, 1);
                    }

                    percentage = percentage + "%";

                    //create a row to hold our percentages
                    TableRow row = new TableRow();

                    //create a new tablecell for  our dev type
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    //create a cell for our device count
                    TableCell cell2 = new TableCell();
                    cell2.CssClass = "generic_table_cell";
                    cell2.Style.Add("width", "25%");
                    cell2.Style.Add("font-size", "medium");
                    cell2.Text = dev_count_for_type_sysinfo.ToString();

                    //add our percentage to the table
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "generic_table_cell";
                    cell3.Style.Add("width", "35%");
                    cell3.Style.Add("font-size", "medium");
                    cell3.Text = percentage;

                    //add cells to our row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to the table
                }
                else // no devices found with that specific dev type found
                {
                    //create a row to hold our percentages
                    TableRow row = new TableRow();

                    //create a new tablecell for  our dev type
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    //create a cell for our device count
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

                    //add cells to the row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to our table
                }



            }
        }
        
        protected void create_browser_stats_table(List<string> browsers, Table table, int total_dev_count)
        {

            foreach (string i in browsers) // for all different browser types
            {
                var devs_per_browser = (from elem in DC.DESKREG_SYSINFO
                                     where elem.Browser == i
                                     select elem.AssetID).Count(); // get count of devices per browser 


                // calculate percentages
                string percentage = ((decimal)devs_per_browser / total_dev_count).ToString();

                if (percentage != "0") // devices exist with that browser type
                {
                    //format our percentages
                    percentage = percentage.Substring(0, 5);
                    percentage = percentage.Remove(0, 2);
                    percentage = percentage.Insert(2, ".");

                    if (percentage.Substring(0, 1) == "0") // there is a leading 0
                    {
                        percentage = percentage.Remove(0, 1);
                    }

                    percentage = percentage + "%";

                    // create a row to fill in and add to the table
                    TableRow row = new TableRow();

                    //add our browser name cell
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    // add our device count per browser 
                    TableCell cell2 = new TableCell();
                    cell2.CssClass = "generic_table_cell";
                    cell2.Style.Add("width", "25%");
                    cell2.Style.Add("font-size", "medium");
                    cell2.Text = devs_per_browser.ToString();

                    //add our percentage to the table
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "generic_table_cell";
                    cell3.Style.Add("width", "35%");
                    cell3.Style.Add("font-size", "medium");
                    cell3.Text = percentage;

                    // add our cells to the row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to the table
                }

                else // no devices exist with that browser type
                {
                    // create a row to fill in and add to the table
                    TableRow row = new TableRow();

                    //add our browser name cell
                    TableCell cell1 = new TableCell();
                    cell1.CssClass = "generic_table_cell";
                    cell1.Style.Add("width", "40%");
                    cell1.Style.Add("font-size", "medium");
                    cell1.Text = i;

                    // add our device count per browser 
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

                    // add our cells to our row
                    row.Controls.Add(cell1);
                    row.Controls.Add(cell2);
                    row.Controls.Add(cell3);

                    table.Controls.Add(row); // add row to table
                }


            }

        }
    }
}