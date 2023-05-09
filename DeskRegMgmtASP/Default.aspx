<%@ Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DeskRegMgmtASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Table ID="Directory_Table_Title" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" >

        <asp:TableRow ID ="Table_Title">
            <asp:TableCell Text ="DeskReg Directory"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="eq_mgmt_table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" >


        <asp:TableRow ID ="eq_mgmt_title">
            <asp:TableCell Text = "Equipment Management"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
          <asp:TableCell runat="server" Text="Register Le Moyne Equipment" CssClass="generic_table_cell" Style="width:40%">

          </asp:TableCell>
          <asp:TableCell ID="Reg_LMC_EQ_button_cell" runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="reg_lmc_eq_button" Text="Go" CssClass="button_style" OnClick="reg_lmc_eq_button_Click" />
          </asp:TableCell>

          <asp:TableCell runat="server" Text="Register Resnet Equipment" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" style="width:10%">
              <asp:Button runat="server" ID="reg_resnet_eq_button" Text="Go" CssClass="button_style" OnClick="reg_resnet_eq_button_Click" />
            </asp:TableCell>
        </asp:TableRow>


      <asp:TableRow>
          <asp:TableCell runat="server" Text="Search By Mac Address" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell ID="search_mac_cell" runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="search_mac_button" Text="Go" CssClass="button_style" OnClick="search_mac_button_Click" />
          </asp:TableCell>

          <asp:TableCell runat="server" Text="Search By User ID (Resnet)" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" style="width:10%">
              <asp:Button runat="server" ID="search_user_button" Text="Go" CssClass="button_style" OnClick="search_user_button_Click" />
          </asp:TableCell>
      </asp:TableRow>

    <asp:TableRow>
          <asp:TableCell runat="server" Text="Search By Equipment Name" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell ID="search_eq_name_cell" runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="search_eq_name_button" Text="Go" CssClass="button_style" OnClick="search_eq_name_button_Click" />
          </asp:TableCell>

          <asp:TableCell runat="server" Text="Search By VLAN" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" style="width:10%">
              <asp:Button runat="server" ID="search_vlan_button" Text="Go" CssClass="button_style" OnClick="search_vlan_button_Click" />
          </asp:TableCell>
      </asp:TableRow>

   </asp:Table>


    <asp:Table ID="DB_mgmt_table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">
        <asp:TableRow ID ="Database_Management_row">
           <%-- <asp:TableCell Text = "Update Network"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title" Style="width:50%"></asp:TableCell>--%>
            <asp:TableCell Text="Database Management" ColumnSpan="4" HorizontalAlign="Center" CssClass="Title" Style="width:100%"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Update Network" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>

            <asp:TableCell ID="update_network_cell" runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="update_network_button" Text="Update" CssClass="button_style" OnClick="update_network_button_Click" />
            </asp:TableCell>

            <asp:TableCell runat="server" Text="VLAN" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>

            <asp:TableCell ID="vlan_mgmt_cell" runat="server" CssClass="generic_table_cell" Style="width:10%">
                <asp:Button runat="server" ID="vlan_mgmt_button" Text="Go" CssClass="button_style" OnClick="vlan_mgmt_button_Click" />
            </asp:TableCell>
            
        </asp:TableRow>

    </asp:Table>


    <asp:Table runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" >
        <asp:TableRow ID ="Audit_title">
            <asp:TableCell Text = "Audit"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
          <asp:TableCell runat="server" Text="Search By Event Owner" CssClass="generic_table_cell" Style="width:40%">

          </asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="search_event_owner_button" Text="Go" CssClass="button_style" OnClick="search_event_owner_button_Click" />
          </asp:TableCell>

          <asp:TableCell runat="server" Text="Search By Event Time" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" style="width:10%">
              <asp:Button runat="server" ID="search_by_event_time_button" Text="Go" CssClass="button_style" OnClick="search_by_event_time_button_Click" />
            </asp:TableCell>
        </asp:TableRow>


      <asp:TableRow>
          <asp:TableCell runat="server" Text="Search By Event Target" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="search_by_event_target_button" Text="Go" CssClass="button_style" OnClick="search_by_event_target_button_Click" />
          </asp:TableCell>

          <asp:TableCell runat="server" Text="Search By Event Type" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" style="width:10%">
              <asp:Button runat="server" ID="search_by_event_type_button" Text="Go" CssClass="button_style" OnClick="search_by_event_type_button_Click"/>
          </asp:TableCell>
      </asp:TableRow>
        
    </asp:Table>

        <asp:Table ID="stats_table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">
        <asp:TableRow ID ="stats_table_title">
            <asp:TableCell Text ="DeskReg Statistics"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
          <asp:TableCell runat="server" Text="Le Moyne Equipment Statistics" CssClass="generic_table_cell" Style="width:40%">

          </asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" Style="width:10%">
              <asp:Button runat="server" ID="eq_stats_button" Text="Go" CssClass="button_style" OnClick="eq_stats_button_Click" />
          </asp:TableCell>

          <asp:TableCell runat="server" Text="Resnet Equipment Statistics" CssClass="generic_table_cell" Style="width:40%"></asp:TableCell>
          <asp:TableCell runat="server" CssClass="generic_table_cell" style="width:10%">
              <asp:Button runat="server" ID="resnet_eq_stats_button" Text="Go" CssClass="button_style" OnClick="resnet_eq_stats_button_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    

    <script>
     function changesize()
        {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "55em";
        }
       </script>
</asp:Content>
