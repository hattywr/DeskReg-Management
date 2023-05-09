<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEventType.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchEventType" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" Style="margin-top:8px; margin-bottom:8px">

        <asp:TableRow ID ="Title">
            <asp:TableCell ID="table_title" Text="Please Select An Event Type To Search By :" ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title">
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Search by Action: " CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="action_dropdown_cell" CssClass="Right_Cell">
                <asp:DropDownList ID="dd_event_items" runat="server" CssClass="vlan_drop_down" AppendDataBoundItems="true" Style="width:250px"><asp:ListItem Text="Choose One"></asp:ListItem></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:Button runat="server" ID="search_action" Text="Search" CssClass="button_style" Style="margin-left:36.5%; margin-top:5px" OnClick="search_action_Click"  /> 
    <asp:Button runat="server" ID ="remove_entry" Text="Reset" CssClass="button_style" OnClick="remove_entry_Click" />

</asp:Content>


