<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEventOwner.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchEventOwner" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <asp:Label runat="server" Width="170" Text="Search by Event Owner: " Style ="text-align: center;margin-left:6%; margin-top:12px" />
    <asp:DropDownList ID="event_owner_dd" runat="server" CssClass="vlan_drop_down" AppendDataBoundItems="true"><asp:ListItem Text="Choose One"></asp:ListItem></asp:DropDownList>
     <br />
      <asp:Button runat="server" ID="search_owner" Text="Search" CssClass="button_style" Style="margin-left:36.5%; margin-top:5px" OnClick="search_owner_Click"   /> 
      <asp:Button runat="server" ID ="remove_entry" Text="Reset" CssClass="button_style" OnClick="remove_entry_Click" />


    
</asp:Content>