<%@Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchUserID_LIST.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchUserID_LIST" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="Search Results"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>

        

       

   </asp:Table>
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
            margin-right:3px;
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:50%;
        }

        .Right_Cell1{
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:center;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:auto;
        }

       

        .Flex_Parent{
            display:flex;
        }

        .Flex_Buttons{
            justify-content:center;
            margin-top:5px;
        }
        
    </style>


    


</asp:Content>
