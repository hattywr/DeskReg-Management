<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEQName.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchEQName" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Please enter part of or full name of equipment:" Style ="text-align:left" />
    <br/>
     <asp:Label runat="server" Width="140" Text="Search by Name: " Style ="text-align: center;margin-left:6%; margin-top:8px" /> <asp:TextBox runat="server" ID="tbSearchEQName"  CssClass="MAC_Address_Input_Box" />
     <br />
      <asp:Button runat="server" ID="btnSubmitEQName" Text="Search" CssClass="button_style" Style="margin-left: 13.9em" OnClick="btnSubmitEQName_Click" />
      <asp:Button runat="server" ID ="btnResetEQName" Text="Reset" CssClass="button_style" OnClick="btnResetEQName_Click" />

</asp:Content>



