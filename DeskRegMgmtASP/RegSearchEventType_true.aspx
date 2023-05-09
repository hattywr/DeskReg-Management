<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEventType_true.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchEventType_true" %>
 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Label runat="server" Style="margin-left:45%"><a href="RegSearchEventType.aspx">Return to Search</a></asp:Label>

     <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" Style="margin-top:8px">

        <asp:TableRow ID ="Title">
            <asp:TableCell ID="table_title" Text = "Target Examination"  ColumnSpan="6" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID = "Header">
            <asp:TableCell Text = "Time" runat="server" CssClass="Left_Title_Cell1" Style="width:18%"></asp:TableCell>
            <asp:TableCell Text = "Owner" runat="server" CssClass="Left_Title_Cell1" Style="width:18%"></asp:TableCell>
            <asp:TableCell Text = "Type" runat="server" CssClass="Left_Title_Cell1" Style="width:18%"></asp:TableCell>
            <asp:TableCell Text = "Target" runat = "server" CssClass="Right__Title_Cell1" Style="width:18%"></asp:TableCell>
            <asp:TableCell Text = "From" runat="server" CssClass="Right__Title_Cell1" Style="width:14%"></asp:TableCell>
            <asp:TableCell Text = "To" runat="server" CssClass = "Right__Title_Cell1" Style="width:14%"></asp:TableCell>
        </asp:TableRow>
 

         </asp:Table>


    <script type="text/javascript" >
        function changesize() {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "85em";
        }
    </script>

</asp:Content>