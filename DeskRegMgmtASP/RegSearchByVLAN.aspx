<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchByVLAN.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchByVLAN" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" Width="120" Text="Search by VLAN:" Style="text-align:center" />
    <asp:DropDownList runat="server" ID="ddVLAN" AppendDataBoundItems="true" CssClass="vlan_drop_down"><asp:ListItem Text="Choose One"></asp:ListItem></asp:DropDownList>
    <br />
    <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="button_style" Style="margin-top:10px; margin-left:20.7%" OnClick="btnSearch_Click" />  
    <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="button_style"  OnClick="btnReset_Click" />
    



</asp:Content>

