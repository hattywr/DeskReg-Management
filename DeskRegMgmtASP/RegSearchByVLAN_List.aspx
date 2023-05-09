<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchByVLAN_List.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchByVLAN_List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="Search Results"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID = "Header">
            <asp:TableCell Text = "Name" runat="server" CssClass="Left_Title_Cell1"></asp:TableCell>
            <asp:TableCell Text = "MAC" runat="server" CssClass="Left_Title_Cell1"></asp:TableCell>
            <asp:TableCell Text = "Type" runat="server" CssClass="Right__Title_Cell1"></asp:TableCell>
            <asp:TableCell Text = "VLAN" runat = "server" CssClass="Right__Title_Cell1"></asp:TableCell>
        </asp:TableRow>
 

         </asp:Table>

       <script type="text/javascript" >
        function changesize()
        {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "85em";
        }
       </script>

</asp:Content>
