<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_VLAN.aspx.cs" Inherits="DeskRegMgmtASP.Add_VLAN" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <asp:Label runat="server" Style="margin-left:38.7%"><a href="RegVlanMgmt.aspx">Return to VLAN Management</a></asp:Label>

    <asp:Table runat="server" ID="Add_Vlan_Table" Style="margin-top:10px" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="Add New VLAN"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow ID = "Name_Row">
             <asp:TableCell Text="VLAN Name:" CssClass="Left_Cell1"></asp:TableCell>
             <asp:TableCell ID="Name_Input" CssClass="Right_Cell1" Style="width:auto">
                 <asp:TextBox ID="name_input_txt_box" runat="server" CssClass="MAC_Address_Input_Box" Style="width:400px; margin-bottom:0px"></asp:TextBox>
             </asp:TableCell>  
        </asp:TableRow>

        <asp:TableRow ID="number_Row">
            <asp:TableCell Text="VLAN #:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID="number_Input" CssClass="Right_Cell1" Style="width:auto">
                <asp:TextBox ID="number_input_txt_box" runat="server" CssClass="MAC_Address_Input_Box" Style="width:400px; margin-bottom:0px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="Visiblity_Row">
            <asp:TableCell Text = "Visible:" CssClass= "Left_Cell1"></asp:TableCell>
            <asp:TableCell ID="Visible_Input" CssClass="Right_Cell1" Style="width:auto">
                <asp:DropDownList runat="server" ID="visibility_dd" CssClass="drop_down" Style="width:70px" AppendDataBoundItems="true"><asp:ListItem Text="Select"></asp:ListItem></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>

    <asp:Button runat="server" ID="add_vlan" Text="Add" CssClass="button_style" Style="margin-left:40%" OnClick="Add_VLAN_Click" />
    <asp:Button runat="server" ID="reset_vlan_entry" Text="Reset" CssClass="button_style" OnClick="Reset_VLAN_Entry_Click" />

  

 </asp:Content>