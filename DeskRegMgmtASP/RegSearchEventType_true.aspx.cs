using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class RegSearchEventType_true : System.Web.UI.Page
    {
        usrregDevEntities DC = new usrregDevEntities();
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true); // adjust page size for easier viewing

            string action_ID = Request.QueryString["action_id"].ToString(); // retrieve the action ID sent through

            var events = (from elem in DC.DESKREG_EVENT
                          where elem.ACTION_ID.ToString() == action_ID
                          orderby elem.EVENT_TIME descending
                          select elem.EVENT_ID).ToList(); // get all event ID's associated with that action ID

            var event_record = (from elem in DC.DESKREG_EVENT
                                join elem2 in DC.DESKREG_ACTION
                                on elem.ACTION_ID equals elem2.ACTION_ID
                                where events.Contains(elem.EVENT_ID)
                                orderby elem.EVENT_TIME descending
                                select new { elem.EVENT_TIME, elem.EVENT_OWNER, elem2.ACTION_NAME, elem.EVENT_TARGET, elem.EVENT_FROM, elem.EVENT_TO }).ToList(); // get all events and their details for that action ID and put them into a list

            for (int i = 0; i < events.Count; i++) // for all events
            {
                TableRow row = new TableRow(); // create a new table row


                // create and style our event time cell
                TableCell cell1 = new TableCell();
                cell1.CssClass = "generic_table_cell";
                cell1.Style.Add("width", "18%");
                cell1.Text = event_record[i].EVENT_TIME.ToString();

                //create and style our event owner cell
                TableCell cell2 = new TableCell();
                cell2.CssClass = "generic_table_cell";
                cell2.Style.Add("width", "18%");
                cell2.Text = event_record[i].EVENT_OWNER;

                // create and style our action name cell
                TableCell cell3 = new TableCell();
                cell3.CssClass = "generic_table_cell";
                cell3.Style.Add("width", "18%");
                cell3.Text = event_record[i].ACTION_NAME;

                //create and style our event target cell
                TableCell cell4 = new TableCell();
                cell4.CssClass = "generic_table_cell";
                cell4.Style.Add("width", "18%");
                cell4.Text = event_record[i].EVENT_TARGET;

                // create a link if our asset still exists in our database (has not been deleted)
                if (DC.DESKREG_SYSTEMS.Where(x => x.AssetID == cell4.Text).Any())
                {
                    HyperLink link = new HyperLink();
                    link.NavigateUrl = ("Search_Mac_true.aspx?Mac_Address=" + cell4.Text); // create a link to the user's info inside each username
                    link.Text = cell4.Text;
                    cell4.Controls.Add(link);
                }
                else // device no longer exists
                {
                    cell4.Text = cell4.Text;
                }

                //create and style our event from cell
                TableCell cell5 = new TableCell();
                cell5.CssClass = "generic_table_cell";
                cell5.Style.Add("width", "14%");
                cell5.Text = event_record[i].EVENT_FROM;

                // create and style our event to cell
                TableCell cell6 = new TableCell();
                cell6.CssClass = "generic_table_cell";
                cell6.Style.Add("width", "14%");
                cell6.Text = event_record[i].EVENT_TO;


                row.Cells.Add(cell1);
                row.Cells.Add(cell2); // add cells to the row
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                row.Cells.Add(cell6);

                Search_Results_Table.Rows.Add(row); // add our row to the table
            }
        }
    }
}