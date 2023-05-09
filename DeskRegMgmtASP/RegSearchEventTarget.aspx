<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEventTarget.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchEventTarget" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" Style="margin-top:8px; margin-bottom:8px">

        <asp:TableRow ID ="Title">
            <asp:TableCell ID="table_title" Text="Please Enter All or Part of an Event Target :" ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title">
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Search Target" CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" ID="target_cell" CssClass="Right_Cell">
                <asp:TextBox runat="server" ID="target_input_txt_box" CssClass="MAC_Address_Input_Box" Style="margin:0px; width:250px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID ="Under_Title">
            <asp:TableCell ID="under_table_title" Text = "Please Understand That Very General Targets Will Return a Great Deal of Hits and Will Take Time To Retrieve. Be as Specific as Possible in Your Search"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button runat="server" ID="search_target" Text="Search" CssClass="button_style" Style="margin-left:36.5%; margin-top:5px" OnClick="search_target_Click"  /> 
    <asp:Button runat="server" ID ="remove_entry" Text="Reset" CssClass="button_style" OnClick="remove_entry_Click" />

</asp:Content>