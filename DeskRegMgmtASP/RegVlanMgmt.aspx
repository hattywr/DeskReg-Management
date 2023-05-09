<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegVlanMgmt.aspx.cs" Inherits="DeskRegMgmtASP.RegVlanMgmt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <asp:Label runat="server" Text="Add VLAN" Style="margin-left:46.5%; font-weight:600"></asp:Label>
    <br />
    <asp:Button ID ="add_vlan_button" runat="server" Text="Add" CssClass="button_style" Style="margin-left:45.8%; margin-top:5px; margin-bottom:5px" OnClick="add_vlan_button_Click" />

    <asp:Table ID="VLAN_Management" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">
   

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="Management Table"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID = "Header">
            <asp:TableCell Text = "VLAN #" runat="server" CssClass="Left_Title_Cell1" Style="width:20%"></asp:TableCell>
            <asp:TableCell Text = "VLAN NAME" runat="server" CssClass="Left_Title_Cell1" Style="width:25%"></asp:TableCell>
            <asp:TableCell Text = "VISIBLE" runat="server" CssClass="Right__Title_Cell1" Style="width:20%"></asp:TableCell>
            <asp:TableCell Text = "ACTION" runat = "server" CssClass="Right__Title_Cell1" Style="width:35%"></asp:TableCell>
        </asp:TableRow>

   </asp:Table>

    <script type="text/javascript" >
        function changesize() {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "60em";
        }
    </script>
    </asp:Content>