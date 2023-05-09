<%@Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchUserID.aspx.cs" Inherits="DeskRegMgmtASP.SearchUserID" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Please type in a first and/or last name, or username to search (partial or complete)" Style ="text-align:start" />
    <br/>
    <asp:Label runat="server" Width="120" Text="Search by User: " Style ="text-align:center;margin-top:10px; margin-left:7%" /> 
    <asp:TextBox runat="server" ID="tbSearchUser" Width="200" CssClass="MAC_Address_Input_Box"/> 
    <br />
    <asp:Button runat="server" ID="btnSearch" Text="Search"  CssClass="button_style" Style="margin-left:12.8em; margin-top:0.2em" OnClick="btnSearch_Click" />
    <asp:Button runat="server" ID="btnSearchUserReset" Text="Reset" CssClass="button_style" OnClick="btnSearchUserReset_Click" />


</asp:Content>