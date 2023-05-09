<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reg_Confirm_Delete.aspx.cs" Inherits="DeskRegMgmtASP.Reg_Confirm_Delete" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >


         


        <asp:Table ID="Confirm_Delete_Info" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

         <asp:TableRow ID ="Title">
            <asp:TableCell Text ="YOU ARE ABOUT TO DELETE THIS SYSTEM. PLEASE PROCEED WITH CAUTION AND CONFIRM YOUR DECISION!"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
         </asp:TableRow>

        

       <asp:TableRow>
           <asp:TableCell Text="Mac Address:"  CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID ="Mac_Address_cell" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow>
           <asp:TableCell Text ="Name:" CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID="User_Name_cell" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow>
           <asp:TableCell Text ="VLAN:" CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID="VLAN_cell" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow >
           <asp:TableCell Text ="Expiration Date:" CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID="Exp_Date_cell" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

   </asp:Table>

     <asp:Button runat="server" ID="confirm_delete_button" Text="DELETE FOREVER" Style="text-align:center; color:white; font-size:14px; background-color:#007850; border-width:1px; border-radius:50%; font-weight:600; margin:inherit" Width ="10em" Height="10em" OnClick="confirm_delete_button_Click"/>

    <asp:Label ID="delete_confirmed" runat="server" Text="Device has been eradicated!" Visible="false" CssClass="title_text"></asp:Label>
    <asp:Label ID="main_menu" runat="server" Visible="false" Style="position:relative; left:40%"><a href="Default.aspx">Return to Main Menu</a></asp:Label>
    <style>

       

.Table_Style{
       
            display: table;
            border-radius:5px;
            border-collapse: separate;
            box-sizing: border-box;
            text-indent: initial;
            border-spacing: 2px;
            border-color:#F4C400;
            border-width:2px;
            border-style:solid;
            margin-bottom:20px;
            
            
        }
        .Left_Cell1{
            padding:5px;
            margin-right:3px;
            text-align:right;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:30%;
        }

        .Right_Cell1{
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:left;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:auto;
        }

        .Title1{
            padding:5px;
            
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:auto;
            font-weight:600;
            color:red;
        }

        .center_button{
            display: flex;
            justify-content:center;
            align-items:center;
            height:200px;
            border: 3px solid green;
        }

        .title_text{
            display:flex;
            position:relative;
            left:34%;
            padding:5px;
            font-weight:600;
            color:red;
        }
    </style>
    

</asp:Content>
