using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeskRegMgmtASP
{
    public partial class _Default : Page
    {
        DeskRegLogic DL = new DeskRegLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:changesize(); ", true);

            var userInfo = System.Web.HttpContext.Current;
            var username = userInfo.User.Identity.Name.ToUpper();

            //username = "alenads"; //for testing only
            //username = "hattywr"; // for testing only

            //retrieve username
            Session["username"] = username;
            //authentication for app
            //LeMoyneEntities LE = new LeMoyneEntities();

            //string ColleagueID = (from elem in LE.Users
            //                      where elem.UserName == username
            //                      select elem.UniqueID).FirstOrDefault();

            //if (true) // user does not have access // This if else was the authentication logic which allowed users which had been authenticated already use the application.
            //{
            //    Response.Redirect("No_ACCESS.aspx");
            //}
        }

        // Buttons to take user's to requested page
        protected void reg_lmc_eq_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegLeMoyneEQ.aspx?start=" + "1"); 
        }

        protected void reg_resnet_eq_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegResnetEQ.aspx");
        }

        protected void search_mac_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchByMacAd.aspx");
        }

        protected void search_user_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchUserID.aspx");
        }

        protected void search_eq_name_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchEQName.aspx");
        }

        protected void search_vlan_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchByVLAN.aspx");
        }

        protected void update_network_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("UPDATE_NETWORK_TRUE.aspx?next=" + "12");
        }

        protected void vlan_mgmt_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegVlanMgmt.aspx");
        }

        protected void search_event_owner_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchEventOwner.aspx");
        }

        protected void search_by_event_time_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchEventTime.aspx");
        }

        protected void search_by_event_target_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchEventTarget.aspx");
        }

        protected void search_by_event_type_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegSearchEventType.aspx");
        }

        protected void eq_stats_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeMoyneEQ_STATS.aspx");
        }

        protected void resnet_eq_stats_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResnetEQ_STATS.aspx");

        }
    }
}