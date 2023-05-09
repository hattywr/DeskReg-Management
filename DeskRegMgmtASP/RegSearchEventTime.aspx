<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEventTime.aspx.cs" Inherits="DeskRegMgmtASP.SearchEventTime" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


     <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" Style="margin-top:8px; margin-bottom:5px">

        <asp:TableRow ID ="Title">
            <asp:TableCell ID="table_title" Text="Please enter a mm/dd/yyyy time period to search across :" ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title">
            </asp:TableCell>
        </asp:TableRow>

         <asp:TableRow>
             <asp:TableCell runat="server" Text="Start Date: " CssClass="Left_Cell"></asp:TableCell>
             <asp:TableCell runat="server" CssClass="Right_Cell">
                 <asp:DropDownList runat="server" ID="ddMonth_start" AppendDataBoundItems="true"  CssClass = "drop_down"><asp:ListItem Text="MM"></asp:ListItem></asp:DropDownList> 
                 <asp:Label runat="server" Width="2" Text="/" Style="margin:2px" />
                 <asp:DropDownList runat="server" ID="ddDay_start" AppendDataBoundItems="true" CssClass = "drop_down"><asp:ListItem Text="DD"></asp:ListItem></asp:DropDownList> 
                 <asp:Label runat="server" Width="2" Text="/" Style="margin:2px" />
                 <asp:DropDownList runat="server" ID="ddYear_start" AppendDataBoundItems="true" CssClass = "drop_down" Style="width:65px"><asp:ListItem Text="YYYY"></asp:ListItem></asp:DropDownList>
             </asp:TableCell>
         </asp:TableRow>

         <asp:TableRow>
             <asp:TableCell runat="server" Text="End Date: " CssClass="Left_Cell"></asp:TableCell>
             <asp:TableCell runat="server" CssClass="Right_Cell">
                 <asp:DropDownList runat="server" ID="ddMonth_end" AppendDataBoundItems="true"  CssClass = "drop_down"><asp:ListItem Text="MM"></asp:ListItem></asp:DropDownList> 
                 <asp:Label runat="server" Width="2" Text="/" Style="margin:2px" />
                 <asp:DropDownList runat="server" ID="ddDay_end" AppendDataBoundItems="true" CssClass = "drop_down"><asp:ListItem Text="DD"></asp:ListItem></asp:DropDownList> 
                 <asp:Label runat="server" Width="2" Text="/" Style="margin:2px" />
                 <asp:DropDownList runat="server" ID="ddYear_end" AppendDataBoundItems="true" CssClass = "drop_down" Style="width:65px"><asp:ListItem Text="YYYY"></asp:ListItem></asp:DropDownList>
             </asp:TableCell>
         </asp:TableRow>
      </asp:Table>

    <asp:Button runat="server" ID="search_date" Text="Search" CssClass="button_style" Style="margin-left:36.5%; margin-top:5px" OnClick="search_date_Click" /> 
    <asp:Button runat="server" ID ="remove_entry" Text="Reset" CssClass="button_style" OnClick="remove_entry_Click" />

    <asp:Table ID="Warning_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style" Visible="false" Style="margin-top:10px; margin-bottom:5px" >
        <asp:TableRow>
            <asp:TableCell ID="warning_message_cell" Text="THE PERIOD YOU SELECTED CONTAINS MANY RECORDS AND WILL TAKE A MOMENT TO RETRIEVE. PLEASE CONFIRM YOUR DECISION TO RETRIEVE THESE RECORDS" ColumnSpan="2" HorizontalAlign="Center" CssClass="Title" Style="margin-top:10px"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button runat="server" ID="confirm_large_search" Visible="false" Text="Confirm" CssClass="button_style" Style="margin-left:44%; margin-top:5px" OnClick="confirm_large_search_Click" />

       

</asp:Content>

