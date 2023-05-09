<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegResnetEQ_SearchUser.aspx.cs" Inherits="DeskRegMgmtASP.RegResnetEQ_SearchUser"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
       

        <asp:Table ID="RegEQ_User" runat="server" width="100%"   HorizontalAlign="Center" CssClass="Table_Style">
        
            <asp:TableRow ID ="Title">
            <asp:TableCell Text ="New System Details:"  ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title"></asp:TableCell>
            </asp:TableRow>


            <asp:TableRow ID="User">
                <asp:TableCell   Text="User: " CssClass="Left_Cell"></asp:TableCell> 
                <asp:TableCell ID="U_Name"  CssClass ="Right_Cell" ></asp:TableCell> 
            </asp:TableRow>

        <asp:TableRow ID="ID"  >
            <asp:TableCell    Text="UniqueID: " CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell ID="Unique_ID" CssClass="Right_Cell"></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="Status">
          <asp:TableCell Text="Status: " CssClass="Left_Cell"></asp:TableCell> 
          <asp:TableCell ID="User_Status" CssClass="Right_Cell"></asp:TableCell>
        </asp:TableRow>
     
        <asp:TableRow ID="Mac_Address">
          <asp:TableCell Text="Mac Address:" CssClass="Left_Cell"></asp:TableCell>
          <asp:TableCell ID="Mac_Txt_Box" CssClass="Right_Cell"> 
                <asp:TextBox runat="server" ID="Mac_Address_Text_Input" Style ="text-align:center; border-width:1px; border-radius:15px; margin-bottom:1px" Height="25px" Width="200px"  />
          </asp:TableCell>
        </asp:TableRow>   

        <asp:TableRow ID="EQ_Name">
            <asp:TableCell Text="Equipment Name: " CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell ID="EQ_Name_Txt_Box" CssClass="Right_Cell">
                <asp:TextBox runat="server" ID="EQ_Name_Text_Input" Style ="text-align:center; border-width:1px; border-radius:15px; margin-bottom:1px" Height="25px" Width="200px"  />
            </asp:TableCell>
        </asp:TableRow>  

        <asp:TableRow ID="Dev_Type">
            <asp:TableCell Text="Device Type: " CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell ID="Dev_Type_DD" CssClass="Right_Cell">
                   <asp:DropDownList runat="server" ID="ddDeviceType_Input" AppendDataBoundItems="true" Style ="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px"  Height="25px" Width="140px"><asp:ListItem Text="Choose Type"></asp:ListItem></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>        

    <%--    <asp:TableRow ID="Exp_Date">
            <asp:TableCell Text="Expiration Date: " CssClass="Left_Cell"></asp:TableCell>
            <asp:TableCell ID="Exp_Date_DD_Menus" CssClass="Right_Cell">

                <asp:DropDownList runat="server" ID="ddMonth_Input" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px" Height="25px" Width="50px"><asp:ListItem Text="MM"></asp:ListItem></asp:DropDownList> 
                <asp:Label runat="server" Width="2" Text= "/" Style="margin-left:3px; margin-right:3px" />
                <asp:DropDownList runat="server" ID="ddDay_Input" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px" Height="25px" Width="50px"><asp:ListItem Text="DD"></asp:ListItem></asp:DropDownList> 
                <asp:Label runat="server" Width="2" Text="/" Style="margin-left:3px; margin-right:3px" />
                <asp:DropDownList runat="server" ID="ddYear_Input" AppendDataBoundItems="true" Style="text-align:center; border-width:1px; border-radius:10px; margin-bottom:1px" Height="25px" Width="65px"><asp:ListItem Text="YYYY"></asp:ListItem></asp:DropDownList>

            </asp:TableCell>
        </asp:TableRow>--%>

    </asp:Table>

    <div class="Flex_Parent Flex_Buttons">
        <asp:Button ID="Submit_User_Reg" runat="server" Text="Submit" CssClass="button_style" Style="margin-right:5px" OnClick="Submit_User_Reg_Click"   />
        <asp:Button ID="Reset_User_Reg" runat="server" Text="Reset" CssClass="button_style" OnClick="Reset_User_Reg_Click"  />
    </div>
    

    <style>
        .Left_Cell{
            padding:5px;
            margin-right:3px;
            text-align:right;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:30%;
        }

        .Right_Cell{
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:left;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
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
