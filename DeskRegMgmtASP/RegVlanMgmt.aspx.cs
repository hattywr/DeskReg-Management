using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegVlanMgmt : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true); // adjust page size for easier viewing

            List<string> vlan_list = (from elem in DC.DESKREG_VLAN
                                      orderby elem.VLAN_NO
                                      select elem.VLAN_NAME).ToList(); // retrieve all VLANS and put them in a list


            for (int i = 0; i < vlan_list.Count; i++)
            {
                string vlan_name = vlan_list[i]; //get the vlan name
                add_row(vlan_name); // add a row for each vlan

            }
        }

        protected void add_row(string vlan_name) // add a row for a vlan 
        {
            string vlan_no = (from elem in DC.DESKREG_VLAN
                              where elem.VLAN_NAME == vlan_name
                              select elem.VLAN_NO).First().ToString(); // get the vlan number via the deskreg vlan table

            string visible = (from elem in DC.DESKREG_VLAN
                              where elem.VLAN_NAME == vlan_name
                              select elem.VLAN_SHOW).First().ToString(); // get the vlan visibilty via the deskreg_vlan table



            // add a row for each vlan in the table
            TableRow row = new TableRow();
            // add the vlan nunber cell
            TableCell cell1 = new TableCell();
            cell1.CssClass = "Left_Cell1";
            cell1.Style.Add("width", "20%");
            cell1.Style.Add("text-align", "center");
            cell1.Text = vlan_no;



            // add the vlan name cell
            TableCell cell2 = new TableCell();
            cell2.CssClass = "Left_Cell2";
            cell2.Style.Add("width", "25%");
            cell2.Style.Add("text-align", "center");
            cell2.Style.Add("text-decoration", "none");
            cell2.Text = vlan_name;

            // add the vlan visibility cell
            TableCell cell3 = new TableCell();
            cell3.CssClass = "Right_Cell1";
            cell3.Style.Add("width", "20%");
            cell3.Text = visible;

            // add the vlan cell for the modify and delete buttons
            TableCell cell4 = new TableCell();
            cell4.CssClass = "Right_Cell2";
            cell4.Style.Add("width", "35%");

            // create the button objects
            Button modify = new Button();
            Button delete = new Button();

            // style and add functionality to the buttons
            create_modify_vlan_button(cell4, modify, "grid_button_style", vlan_name); 
            create_delete_vlan_button(cell4, delete, "grid_button_style", vlan_name);
            

            row.Cells.Add(cell1);
            row.Cells.Add(cell2); // add cells to the row
            row.Cells.Add(cell3);
            row.Cells.Add(cell4);

            VLAN_Management.Rows.Add(row); // add the row to the table
        }

        protected void create_modify_vlan_button(TableCell cell, Button button, string Css_Class, string vlan)
        {
            button.ID = vlan + ".modify_button"; // add unique identifier which contains the vlan
            button.Text = "Modify"; // add button text
            button.CssClass = Css_Class; // add Css class
            button.Click += Modify_Button_Click; ; // create button press event
            cell.Controls.Add(button); // add the button into the cell
        }

        protected void create_delete_vlan_button(TableCell cell, Button button, string Css_Class, string vlan)
        {
            button.ID = vlan + ".delete_button"; // add unique identifier which contains the vlan
            button.Text = "Delete"; // add button text
            button.CssClass = Css_Class; // add Css class
            button.Click += Delete_Button_Click; ; // create button press event
            cell.Controls.Add(button); // add the button into the cell
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string good_vlan = process_button_ID(buttonId); // get the vlan from the button ID
            Response.Redirect("Confirm_VLAN_delete.aspx?vlan_delete_query=" + good_vlan);


        }

        private void Modify_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // get the button that was pressed via the sender event
            string buttonId = button.ID; // retrieve the button ID
            string good_vlan = process_button_ID(buttonId); // get the vlan from the button ID
            Response.Redirect("Modify_VLAN.aspx?vlan_query=" + good_vlan + "&next=" + "20");
        }

        protected string process_button_ID(string weird_vlan)
        {
            //string fixed_vlan = spaces.Substring(spaces.IndexOf(' ') + 1); // remvove spaces 
            string good_vlan = weird_vlan.Substring(0,weird_vlan.IndexOf('.')); // remove the added piece of the ID (.modify_button etc etc --> see the button creation and ID assignment methods) to get just the vlan we want
            return good_vlan; // return just the vlan
            
        }

        protected void add_vlan_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_VLAN.aspx"); // send the user to the add vlan page
        }
    }
}