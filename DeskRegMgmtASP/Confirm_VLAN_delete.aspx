<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm_VLAN_delete.aspx.cs" Inherits="DeskRegMgmtASP.Confirm_VLAN_delete" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <asp:Label runat="server" Style="margin-left:38.7%"><a href="RegVlanMgmt.aspx">Return to VLAN Management</a></asp:Label>

    <asp:Table ID="Confirm_Delete_Info" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" Style="margin-top:5px">

         <asp:TableRow ID ="Title">
            <asp:TableCell Text ="YOU ARE ABOUT TO DELETE THIS VLAN FROM THE DATABASE. PLEASE PROCEED WITH CAUTION AND CONFIRM YOUR DECISION!"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
         </asp:TableRow>


        <asp:TableRow ID = "Name_Row">
             <asp:TableCell Text="VLAN Name:" CssClass="Left_Cell1"></asp:TableCell>
             <asp:TableCell ID="Name_Input" CssClass="Right_Cell1" Style="width:auto"></asp:TableCell>  
        </asp:TableRow>

        <asp:TableRow ID="number_Row">
            <asp:TableCell Text="VLAN #:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID="number_Input" CssClass="Right_Cell1" Style="width:auto"></asp:TableCell>
        </asp:TableRow>

  </asp:Table>

    <asp:Button ID="delete_vlan" runat="server" Text="DELETE" CssClass="button_style" Style="margin-left:47%" OnClick="delete_vlan_Click" />
 </asp:Content>