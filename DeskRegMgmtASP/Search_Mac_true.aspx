  <%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_Mac_true.aspx.cs" Inherits="DeskRegMgmtASP.Search_Mac_true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

   <asp:Table ID="EQ_Owner" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="System Information"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>

       <asp:TableRow ID ="Owner">
           <asp:TableCell Text="Owner:"  CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID ="Owner_Name" Text="filler" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow ID ="User_ID_Row" Visible="false">
           <asp:TableCell Text ="UserID:" CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID="User_ID" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

       <asp:TableRow ID ="Unique_ID_Row" Visible="false">
           <asp:TableCell Text ="UniqueID:" CssClass="Left_Cell1"></asp:TableCell>
           <asp:TableCell ID="Unique_ID_Number" CssClass="Right_Cell1"></asp:TableCell>
       </asp:TableRow>

   </asp:Table>




    <asp:Table ID ="System_Information" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">
        <asp:TableRow ID ="Mac_Address_Stuff">
            <asp:TableCell Text="Mac Address:" CssClass="Left_Cell1"> </asp:TableCell>
            <asp:TableCell ID ="Mac_Address" CssClass="Right_Cell1">
                 <asp:Label ID = "mac_lbl" runat="server" ></asp:Label>
                 <asp:Button runat="server" ID="delete_button" Text="Delete" CssClass="grid_button_style" OnClick="delete_button_Click"/>
            </asp:TableCell>
                   
        </asp:TableRow>

        <asp:TableRow ID ="Status_Stuff">
            <asp:TableCell Text="Status:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID ="Status_ID" CssClass="Right_Cell1">
                <asp:Label ID="status_lbl" runat="server"></asp:Label>
                <asp:Button runat="server" ID="Enable_Button" Text="Enable" Visible="false" CssClass="grid_button_style" OnClick="Enable_Button_Click"/>           
                <asp:Button runat="server" ID="Disable_Button" Text="Disable" Visible="false" CssClass="grid_button_style" OnClick="Disable_Button_Click"/>
                <asp:Button runat="server" ID="Block_Button" Text="Block" Visible="false" CssClass="grid_button_style" OnClick="Block_Button_Click" />
            </asp:TableCell>

           
                
           
        </asp:TableRow>

          <asp:TableRow ID ="EQ_Name_Stuff">
            <asp:TableCell Text="Equipment Name:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID ="EQ_Name"  CssClass="Right_Cell1">
                <asp:TextBox ID ="Text_Box_EQ_Name" runat="server" CssClass ="MAC_Address_Input_Box" Style="margin-bottom:0px"></asp:TextBox>
                <asp:Button runat="server" ID="Change_Name_Button" Text ="Change"  CssClass="grid_button_style" OnClick="Change_Name_Button_Click" />
            </asp:TableCell>

          
        </asp:TableRow>

        <asp:TableRow ID ="Device_Type_Stuff">
            <asp:TableCell Text="Device Type" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID ="Device_Type" CssClass="Right_Cell1">
                <asp:DropDownList ID="Device_Type_DropDown" runat="server" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px" Height="25px" Width="140px"></asp:DropDownList>
                <asp:Button runat="server" ID="Change_Type_Button" Text ="Change" CssClass="grid_button_style"  OnClick="Change_Type_Button_Click" />
            </asp:TableCell>
        </asp:TableRow>



         <asp:TableRow ID ="VLAN_Stuff">
            <asp:TableCell Text="VLAN:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID ="VLAN"  CssClass="Right_Cell1">
                <asp:DropDownList ID ="VLAN_Dropdown" runat="server" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px" Height="25px" Width="140px"></asp:DropDownList>
                <asp:Button runat="server" ID="Change_vlan_button" Text ="Change" CssClass="grid_button_style" OnClick="Change_vlan_button_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID ="Reg_Date_Stuff">
            <asp:TableCell Text="Registration Date:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID ="Reg_Date" CssClass="Right_Cell1"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID ="Exp_Date_Stuff">
            <asp:TableCell Text="Expiration Date:" CssClass="Left_Cell1"></asp:TableCell>
            <asp:TableCell ID ="Exp_Date" CssClass="Right_Cell1">
                <asp:DropDownList runat="server" ID="ddMonth_Input" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px" Height="25px" Width="50px"><asp:ListItem Text="MM"></asp:ListItem></asp:DropDownList> 
                <asp:Label runat="server" Width="2" Text= "/" Style="margin-left:3px; margin-right:3px" />
                <asp:DropDownList runat="server" ID="ddDay_Input" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px" Height="25px" Width="50px"><asp:ListItem Text="DD"></asp:ListItem></asp:DropDownList> 
                <asp:Label runat="server" Width="2" Text="/" Style="margin-left:3px; margin-right:3px" />
                <asp:DropDownList runat="server" ID="ddYear_Input" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px" Height="25px" Width="65px"><asp:ListItem Text="YYYY"></asp:ListItem></asp:DropDownList>
                <asp:Button runat="server" ID="Change_Exp_Date_button" Text="Change" CssClass="grid_button_style" Style="margin-left:1px" OnClick="Change_Exp_Date_button_Click"/>
                <asp:Button runat="server" ID="Delete_Exp_Date_button" Text ="Delete" CssClass="grid_button_style" Style="margin-left:1px"  OnClick="Delete_Exp_Date_button_Click" />
            </asp:TableCell>

        </asp:TableRow>



    </asp:Table>


    <style>
        .Title1{
            padding:5px;
            
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:auto;
            font-weight:600;
        }
        .Left_Cell1{
            padding:5px;
            margin-right:3px;
            text-align:right;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:30%;
        }

        .Right_Cell1{
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:left;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:auto;
        }

       

        .Flex_Parent{
            display:flex;
        }

        .Flex_Buttons{
            justify-content:center;
            margin-top:5px;
        }
        
    </style>
</asp:Content>
