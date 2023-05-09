using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegResnetEQ_List : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            string potential_search = Request.QueryString["list_stuff"].ToString(); // get the searched username from the previous form

            List<string> user_list = (from elem in DC.DESKREG_USERINFO
                                        where elem.USERID.Contains(potential_search) || (elem.USER_FNAME + " " + elem.USER_LNAME).Contains(potential_search) 
                                        || (potential_search.Contains(elem.USER_FNAME) && potential_search.Contains(elem.USER_LNAME))
                                        select elem.USERID).ToList();



            for (int i = 0; i < user_list.Count; i++)
            {
                string users_name = user_list[i]; //get the user's name
                DESKREG_USERINFO userinfo = (from elem in DC.DESKREG_USERINFO
                                             where elem.USERID == users_name
                                             select elem).First();

                add_row(userinfo); // add a row for each user's name

            }
        }


        protected void add_row( DESKREG_USERINFO uSERINFO) // add a row for a username 

        {
            TableRow row = new TableRow();
            HyperLink link = new HyperLink();
            link.NavigateUrl = ("RegResnetEQ_SearchUser.aspx?username=" + uSERINFO.USERID + "&next=" + "15"); // create a link to the user's info inside each username
            link.Text = uSERINFO.USERID;

            TableCell cell1 = new TableCell();
            cell1.Controls.Add(link); // add the link to the left cell

            TableCell cell2 = new TableCell();

            string full_name = uSERINFO.USER_FNAME + " " + uSERINFO.USER_LNAME;




            cell2.Text = full_name; // assign the full name to the right cell
            cell1.CssClass = "generic_table_cell"; // assign Css class
            cell1.Style.Add("width", "50%");
            cell2.CssClass = "generic_table_cell"; // assign Css class
            cell2.Style.Add("width", "50%");
            row.Cells.Add(cell1);
            row.Cells.Add(cell2); // add cells to the row
            Search_Results_Table.Rows.Add(row); // add the row to the table
            
        }
    }
}