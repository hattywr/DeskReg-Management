using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchByVLAN_List : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true);

            string searched_vlan = Request.QueryString["vlan_query"].ToString();

            List<string> dev_list = (from elem in DC.DESKREG_SYSTEMS
                                     where elem.VLAN == searched_vlan
                                     select elem.AssetID).ToList(); // fill list with all potential hits


            for (int i = 0; i < dev_list.Count; i++)
            {
                string asset_ID = dev_list[i]; // retrieve our asset UD
                add_row(asset_ID); // add a row for each user's name

            }

        }
        protected void add_row(string asset_id) // add a row for a each entry
        {
            DESKREG_SYSTEMS Stuff = (from elem in DC.DESKREG_SYSTEMS
                                     where elem.AssetID == asset_id
                                     select elem).FirstOrDefault(); //get our system record to pull from

            string asset_name;

            if (Stuff.AssetName == null || Stuff.AssetName == "") // The name of the system is empty
            {
               asset_name = "Not Assigned"; // Add in a placeholder
            }
            else // system has a name
            {
                asset_name = Stuff.AssetName; //assign name of system
            }

            

            string mac = DL.val_MAC(asset_id); //validate our mac

            string type_ID = Stuff.TYPE_ID.ToString(); //retrieve and assign our type ID integer as a string

            var type_id = Convert.ToInt32(type_ID); //change the type ID to a number

            string Type_name = (from elem in DC.DESKREG_TYPE
                                where elem.TYPE_ID == type_id
                                select elem.TYPE_NAME).FirstOrDefault().ToString(); //retrieve type name 

            string half_vlan = Stuff.VLAN; //get our VLAN and assign it to a number for manipulation

            string full_vlan = (from elem in DC.DESKREG_VLAN
                                where elem.VLAN_NAME == half_vlan
                                select elem.VLAN_NO + "-" + elem.VLAN_NAME).FirstOrDefault().ToString(); // add the number and name to our vlan designation

            

            //add row to our table
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();

            //add our asset name to the cell
            cell1.CssClass = "Left_Cell1";
            cell1.Text = asset_name;

            //create a link to the asset's more detailed information 
            HyperLink link = new HyperLink();
            link.NavigateUrl = ("Search_Mac_true.aspx?Mac_Address=" + asset_id); // create a link to the user's info inside each username
            link.Text = asset_id;


            //add our link to the table cell
            TableCell cell2 = new TableCell();
            cell2.CssClass = "Left_Cell2";
            cell2.Controls.Add(link); // add the link to the cell

            //add a cell for our type name
            TableCell cell3 = new TableCell();
            cell3.CssClass = "Right_Cell1";
            cell3.Text = Type_name;

            //add a cell for the full vlan designation
            TableCell cell4 = new TableCell();
            cell4.CssClass = "Right_Cell2";
            cell4.Text = full_vlan;

            // add cells to the row
            row.Cells.Add(cell1);
            row.Cells.Add(cell2); 
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);

            Search_Results_Table.Rows.Add(row); //add the created row to the table
        }
    }
}