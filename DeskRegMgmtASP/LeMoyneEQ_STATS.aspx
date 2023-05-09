<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeMoyneEQ_STATS.aspx.cs" Inherits="DeskRegMgmtASP.LeMoyneEQ_STATS" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="total_system_stats_table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" >

        <asp:TableRow ID ="Table_Title">
            <asp:TableCell Text ="System Statistics"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Total Systems:" CssClass="generic_table_cell" Width="40%" Font-Size="Medium"></asp:TableCell>
            <asp:TableCell runat="server" ID="device_count_cell"  CssClass="generic_table_cell" Width="60%" Font-Size="Medium"></asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:Table ID="Disabled_Blocked_Stats_table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Disabled/Blocked Device Statistics" ColumnSpan="2" HorizontalAlign="Center" CssClass="Title"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Disabled Systems" CssClass="generic_table_cell" Width="40%" Font-Size="Medium"></asp:TableCell>
            <asp:TableCell runat="server" ID="disabled_system_count_cell" CssClass="generic_table_cell" Width="60%" Font-Size="Medium"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
             <asp:TableCell runat="server" Text="Blocked Systems" CssClass="generic_table_cell" Width="40%" Font-Size="Medium"></asp:TableCell>
            <asp:TableCell runat="server" ID="blocked_system_count_cell" CssClass="generic_table_cell" Width="60%" Font-Size="Medium"></asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:Table ID="dev_type_table" runat="server" Width="100%" HorizontalAlign="Center"  CssClass="Table_Style">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Text="Device Type" CssClass="Title" Width="35%"></asp:TableCell>
            <asp:TableCell runat="server" Text = "Quantity" CssClass="Title" Width="25%"></asp:TableCell>
            <asp:TableCell runat="server" Text="Quantity/Total" CssClass="Title" Width="40%"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="vlan_type_table" runat="server" Width="100%" HorizontalAlign="Center"  CssClass="Table_Style">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Text="VLAN" CssClass="Title" Width="35%"></asp:TableCell>
            <asp:TableCell runat="server" Text = "Quantity" CssClass="Title" Width="25%"></asp:TableCell>
            <asp:TableCell runat="server" Text="Quantity/Total" CssClass="Title" Width="40%"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        
    

    


    
    <script type="text/javascript" >
        function changesize() {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "40em";
        }
    </script>
</asp:Content>