<%@  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegLeMoyneEQ.aspx.cs" Inherits="DeskRegMgmtASP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="RegEQ_User" runat="server" width="100%"   HorizontalAlign="Center" CssClass="Table_Style">
        
        <asp:TableRow ID ="Title">
        <asp:TableCell Text ="New System Details:"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell runat="server" Text="MAC Address:" CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="Right_Cell">
                <asp:TextBox runat="server" ID="tbMacaddress" CssClass="MAC_Address_Input_Box" Style="margin:0px"  />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Equipment Name:" CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="Right_Cell">
                <asp:TextBox runat="server" ID="tbEQName" CssClass="MAC_Address_Input_Box" Style="margin:0px" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="Device Type:" CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="Right_Cell">
                <asp:DropDownList runat="server" ID="ddDeviceType" AppendDataBoundItems="true" CssClass="vlan_drop_down" Style="margin:0px"><asp:ListItem Text="Choose Type"></asp:ListItem></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell runat="server" Text="VLAN:" CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="Right_Cell">
                <asp:DropDownList runat="server" ID="ddVLAN" AppendDataBoundItems="true" CssClass="vlan_drop_down" Style="margin:0px"><asp:ListItem Text="Choose VLAN"></asp:ListItem></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="expiration_date_row">
            <asp:TableCell runat="server" Text="Expiration Date:" CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell runat="server" CssClass="Right_Cell">
                <asp:DropDownList runat="server" ID="ddMonth" AppendDataBoundItems="true" CssClass="drop_down"><asp:ListItem Text="MM"></asp:ListItem></asp:DropDownList> 
                <asp:Label runat="server" Width="2" Text="/" Style="margin:2px" />
                <asp:DropDownList runat="server" ID="ddDay" AppendDataBoundItems="true" CssClass="drop_down"><asp:ListItem Text="DD"></asp:ListItem></asp:DropDownList> 
                <asp:Label runat="server" Width="2" Text="/" Style="margin:2px"/>
                <asp:DropDownList runat="server" ID="ddYear" AppendDataBoundItems="true" CssClass="drop_down" Style="width:65px"><asp:ListItem Text="YYYY"></asp:ListItem></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="button_style" Style="margin-left:14em" OnClick="btnSubmit_Click" />
    <asp:Button runat="server" ID="btnResetEQReg" Text="Reset" CssClass="button_style" OnClick="btnResetEQReg_CLick"  />
 
</asp:Content>
