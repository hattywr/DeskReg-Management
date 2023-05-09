<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegSearchEQName_List.aspx.cs" Inherits="DeskRegMgmtASP.RegSearchEQName_List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" Style="max-width:80em">
    <asp:Table ID="Search_Results_Table" runat="server" Width="100%" HorizontalAlign="Center" CssClass="Table_Style">

        <asp:TableRow ID ="Title">
            <asp:TableCell Text ="Search Results"  ColumnSpan="4" HorizontalAlign="Center"  CssClass="Title1"></asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID = "Header">
            <asp:TableCell Text = "Name" runat="server" CssClass="Left_Title_Cell1"></asp:TableCell>
            <asp:TableCell Text = "MAC" runat="server" CssClass="Left_Title_Cell1"></asp:TableCell>
            <asp:TableCell Text = "Type" runat="server" CssClass="Right__Title_Cell1"></asp:TableCell>
            <asp:TableCell Text = "VLAN" runat = "server" CssClass="Right__Title_Cell1"></asp:TableCell>
        </asp:TableRow>

        


       

   </asp:Table>

    <script type="text/javascript" >
        function changesize()
        {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "85em";
        }
    </script>



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
        .Left_Title_Cell1{
            font-weight:600;
            padding:5px;
            margin-right:3px;
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:25%;
            color:#006633;
            text-decoration: underline
            
        }

        .Right__Title_Cell1{
            font-weight:600;
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:center;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:20%;
            color:#006633;
            text-decoration: underline;
            text-align:left
        }


        .Left_Cell1{
          
            padding:5px;
            margin-right:3px;
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:30%;
            text-align:left;
            font-size:15px;
        }

        .Left_Cell2{
          
            padding:5px;
            margin-right:3px;
            text-align:center;
            border-color: #006633;
            border-spacing:3px;
            border-style:solid;
            border-width:1px;
            width:25%;
            text-align:left;
            font-size:15px;
            text-decoration:underline;
        }

      
        
        .Right_Cell1{
           
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:center;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:20%;
            text-align:left;
            font-size:15px;
        }

        .Right_Cell2{
            
            padding:5px;
            margin-left:3px;
            border-spacing:3px;
            text-align:center;
            border-color:#006633;
            border-width:1px;
            border-style:solid;
            width:25%;
            text-align:left;
            font-size:15px;
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
