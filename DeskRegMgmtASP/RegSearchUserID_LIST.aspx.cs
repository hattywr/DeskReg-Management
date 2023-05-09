using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchUserID_LIST : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            //var username = Request.QueryString["UserName"]; //retrieve the username sent from RegResnetEQ form

            string potential_search = Request.QueryString["Query"].ToString(); // get the searched username from the previous form

            List<string> user_list = (from elem in DC.DESKREG_USERINFO
                                        where elem.USERID.Contains(potential_search) || (elem.USER_FNAME + " " + elem.USER_LNAME).Contains(potential_search) || (potential_search.Contains(elem.USER_FNAME) && potential_search.Contains(elem.USER_LNAME))
                                        select elem.USERID).ToList();  // get all potential users who may be associated with the searched username or name (Full or Partial)

            for (int i=0; i <user_list.Count; i++) // for all items in the user list
            {
                string users_name = user_list[i]; //get the user's name
                DESKREG_USERINFO uSERINFO = (from elem in DC.DESKREG_USERINFO
                                             where elem.USERID == users_name
                                             select elem).FirstOrDefault(); // get the record associated with user
                add_row(uSERINFO); // add a row for each user's name
                
            }


        }

        protected void add_row(DESKREG_USERINFO uSERINFO ) // add a row for a username 

        {
            TableRow row = new TableRow(); // create new row
            // create a link for each user's name 
            HyperLink link = new HyperLink();
            link.NavigateUrl = ("RegSearchUserID_LIST_User.aspx?username=" + uSERINFO.USERID); // create a link to the user's info inside each username
            link.Text = uSERINFO.USERID;
            
            // create a cell to hold link
            TableCell cell1 = new TableCell();
            cell1.Controls.Add(link); // add the link to the left cell

            // create a tablecell for the user's full name
            TableCell cell2 = new TableCell();

            string full_name = uSERINFO.USER_FNAME + " " + uSERINFO.USER_LNAME;

            cell2.Text =  full_name; // assign the full name to the right cell

            
            cell1.CssClass = "Left_Cell1"; // assign Css class
            cell2.CssClass = "Right_Cell1"; // assign Css class

            // add cells to the row
            row.Cells.Add(cell1);
            row.Cells.Add(cell2); 
            
            Search_Results_Table.Rows.Add(row); // add the row to the table
            
        }
    }
}