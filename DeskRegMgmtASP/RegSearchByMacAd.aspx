<%@Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchByMacAd.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchByMacAd" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Please enter your MAC address to search:" Style ="text-align:left;margin-bottom:20px" />
    <br/>
     <asp:Label runat="server" Width="170" Text="Search by MAC Address: " Style ="text-align: center;margin-left:6%; margin-top:12px" /> <asp:TextBox runat="server" ID="tbSearchMac"  CssClass="MAC_Address_Input_Box"  />
     <br />
      <asp:Button runat="server" ID="btnSubmit" Text="Search" CssClass="button_style" Style="margin-left:42%" OnClick="btnSearch_Click" /> 
      <asp:Button runat="server" ID ="btnReset" Text="Reset" CssClass="button_style" OnClick="btnReset_Click" />


</asp:Content>

