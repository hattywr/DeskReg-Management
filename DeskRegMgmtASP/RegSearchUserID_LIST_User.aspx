<%@Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchUserID_LIST_User.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchUserID_LIST_User" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="User Information"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Text="User:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID="Full_Name" CssClass="Right_Cell1"></asp:TableCell>
         
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Text="Unique ID:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID="Unique_ID" CssClass="Right_Cell1"></asp:TableCell>
          
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell Text="Status:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID="User_Status"  CssClass="Right_Cell1">
                <asp:Label ID="status_lbl" runat="server"></asp:Label>
                <asp:Button ID="disable_user_button" runat="server" Text="Disable" CssClass="grid_button_style" Visible="false" OnClick="disable_user_button_Click" />
                <asp:Button ID="enable_user_button" runat="server" Text="Enable" CssClass="grid_button_style" Visible="false" OnClick="enable_user_button_Click" />
            </asp:TableCell>
            
            
        </asp:TableRow>
   </asp:Table>


    <asp:PlaceHolder runat="server" ID="tablePlaceHolder"></asp:PlaceHolder>

   

    <style>
        .Title1{
            padding:5px;
            
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:auto;
            font-weight:600; 
            
        }
        .Left_Cell1{
            padding:5px;

            text-align:right;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:30%;
        }

        .Right_Cell1{
             padding:5px;
         
            border-spacing:3px;
            text-align:left;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:auto;
            
        }
        
    </style>

</asp:Content>