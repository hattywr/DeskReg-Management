using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchEQName_List : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true); //adjust page size to better display results

            string potential_search = Request.QueryString["Query_Name"].ToString(); // get the searched username from the previous form

            List<string> dev_list = (from elem in DC.DESKREG_SYSTEMS
                                      where elem.AssetName.Contains(potential_search)
                                      orderby elem.AssetName
                                      select elem.AssetID).ToList(); // fill list with all potential hits



           
            

            for (int i = 0; i < dev_list.Count; i++)
            {
                string asset_ID = dev_list[i]; //get the asset ID
                add_row(asset_ID); // add a row for the asset

            }

        }

        protected void add_row(string asset_id) // add a row for the asset given
        {
            string asset_name = (from elem in DC.DESKREG_SYSTEMS
                                 where elem.AssetID == asset_id
                                 select elem.AssetName).FirstOrDefault().ToString(); // retrieve asset name 

            string mac = DL.val_MAC(asset_id); // validate the mac address

            string type_ID = (from elem in DC.DESKREG_SYSTEMS
                              where elem.AssetID == asset_id
                              select elem.TYPE_ID).FirstOrDefault().ToString(); // get type ID

            var type_id = Convert.ToInt32(type_ID); // convert type ID to int

            string Type_name = (from elem in DC.DESKREG_TYPE
                                where elem.TYPE_ID == type_id
                                select elem.TYPE_NAME).FirstOrDefault().ToString(); // retrieve the type name

            string half_vlan = (from elem in DC.DESKREG_SYSTEMS
                                where elem.AssetID == asset_id
                                select elem.VLAN).FirstOrDefault().ToString(); // get the vlan name

            string full_vlan = (from elem in DC.DESKREG_VLAN
                                where elem.VLAN_NAME == half_vlan
                                select elem.VLAN_NO + "-" + elem.VLAN_NAME).FirstOrDefault().ToString(); //add the number and name together to form the full name

            //create a row for our table
            TableRow row = new TableRow();

            //create a cell for the asset name
            TableCell cell1 = new TableCell();
            cell1.CssClass = "Left_Cell1";
            cell1.Text = asset_name;

            //create a link to the device to display
            HyperLink link = new HyperLink();
            link.NavigateUrl = ("Search_Mac_true.aspx?Mac_Address=" + asset_id); // create a link to the user's info inside each username
            link.Text = asset_id;

            //add link to the cell
            TableCell cell2 = new TableCell();
            cell2.CssClass = "Left_Cell2";
            cell2.Controls.Add(link); // add the link to the left cell

            //add cell for our type name
            TableCell cell3 = new TableCell();
            cell3.CssClass = "Right_Cell1";
            cell3.Text = Type_name;

            //add cell for our full vlan
            TableCell cell4 = new TableCell();
            cell4.CssClass = "Right_Cell2";
            cell4.Text = full_vlan;

            //add cells to our row
            row.Cells.Add(cell1);
            row.Cells.Add(cell2); // add cells to the row
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);

            Search_Results_Table.Rows.Add(row); // add row to our table
        }
    }
}