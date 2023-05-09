<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegResnetEQ.aspx.cs" Inherits="DeskRegMgmtASP.RegResnetEQ" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" Width="560" Text="Please type in a username, first/last name, or full name to search (partial or complete)" Style ="text-anchor:start" /> 
    <br />
    <asp:Label runat="server" Width="75" Text="Username:" Style="text-anchor:start;  border-width:1px; border-radius:15px; margin-left:10%;margin-top:10px" /><asp:TextBox runat="server" ID="tbUsername"  CssClass="MAC_Address_Input_Box" />
    <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Search" CssClass="button_style"  Style="margin-left:27%" OnClick="btnSearch_Click"/>
    <asp:Button runat="server" ID="btnResetResnetEQ" Text="Reset" CssClass="button_style"  OnClick="btnResetResnetEQ_Click" />


</asp:Content>