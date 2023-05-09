<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UPDATE_NETWORK_TRUE.aspx.cs" Inherits="DeskRegMgmtASP.UPDATE_NETWORK_TRUE" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="RegEQ_User" runat="server" width="100%"   HorizontalAlign="Center" CssClass="Table_Style">
        
        <asp:TableRow ID ="Network_Update_Details">
        <asp:TableCell Text ="Network Update Recap"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Text = "Update Status:" CssClass="generic_table_cell" Width="60%"></asp:TableCell>
            <asp:TableCell ID="Update_Confirmation_Cell" CssClass="generic_table_cell" Width="40%" Style="font-weight:900; text-decoration:underline"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Text = "Devices Registered:" CssClass="generic_table_cell" Width ="60%"></asp:TableCell>
            <asp:TableCell ID="device_number_cell"  CssClass="generic_table_cell" Width="40%" Style="font-weight:900; text-decoration:underline"></asp:TableCell>
        </asp:TableRow>

        
    </asp:Table>

    <asp:Label runat="server" Style="margin-left:37.5%"><a href="Default.aspx">Return to Main Menu</a></asp:Label>



    </asp:Content>