<%@ Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DeskRegMgmtASP.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server" ID="thank_you_table"  Width="100%"  CssClass="Table_Style">
          <asp:TableRow ID ="Title">
            <asp:TableCell ID="table_title" Text="CONGRATULATIONS!!!! YOU FOUND THE BONUS PAGE!!!! (not that it was insanely difficult)" ColumnSpan="2" HorizontalAlign="Center"  CssClass="Title">
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="thanks_text">
            <asp:TableCell ID="thanks_a_bunch" Text="To the men and women of Le Moyne IT - thank you for your time, patience, dedication, and devotion to your students. I know I speak for more
                than just myself when I say that I would not be where I am today without Le Moyne IT and its efforts to cultivate talent and 
                create hardworking individuals. I woudl like to personally thank my past supervisors for putting up with me throughout the years
                as I know I probably deserved to be fired more times than not XD. Luis, Cas, Mykayla, and David - thank you for your efforts in forming me and my career path. 
                It is appreciated more than you know. Below are a few memes which I find particularly epic - including a throwback to my brother Tom's time here. We hope you will remember
                us! Thank you again for all you have done for us!" ColumnSpan="2" HorizontalAlign="Center" CssClass="generic_table_cell" Width="100%" Font-Size="Medium"></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/Happy-Dolphins-game-Sea-fish-coral-waves-summer-Wallpaper-HD-for-Desktop-1920x1200-1366x768.jpg"  Style="width:97em; height:50em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/1000002145.jpg" Style="width:48em; height:48em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/55a8edbd-a18e-4cf3-9570-827e14249835.jpg"  Style="width:48em; height:48em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />
   
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/image_bd6dc7a8-285e-4efb-b9ea-4bb176c5362720221115_152723.jpg"  Style="width:21em; height:21em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/image7081.jpg"  Style="width:21em; height:21em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/Screenshot 2022-03-02 at 7.56.34 PM.jpeg"  Style="width:30em; height:20em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />
    <asp:Image runat="server" ImageUrl="~/Images/Will test images/this-is-fine.jpg"  Style="width:21em; height:21em; padding:5px; border-style:solid; border-width:2px; border-radius:15px; border-color:#D4BF95;margin:5px" />

      <script type="text/javascript" >
        function changesize() {
            var element = document.getElementById("maincenter");
            element.style.maxWidth = "100em";
        }
      </script>

</asp:Content>
