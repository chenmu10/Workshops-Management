<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_Home.aspx.cs" Inherits="gui.Gui.Manager_Home"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MMT Project </title>
    <link href="../css/bootstrap-rtl.min.css" rel="stylesheet" />
</head>
    
<body>
<style> 
div.menu
{
     padding: .4px 0px 4px 0px;
}
div.menu ul
{
   list-style: none;
   margin: 0px;
   padding: 0px;
   width: auto;
}
div.menu ul li ul li
{
  display:block;
  width:250px;
}
div.menu ul li a, div.menu ul li a:visited
{
background-color: #203346;
border: 1px #4e667d solid;
color: #dde4ec;
display: block;
line-height: 1.35em;
padding: 4px 20px;
text-decoration: none;
white-space: nowrap;
}
div.menu ul li 
{
margin:0 4px 0px;
 }
div.menu ul li a:hover
{
       background-color: #bfcbd6;
        color: #465c71;
        text-decoration: none;
 }
div.menu ul li a:active
{
        background-color: #465c71;
        color: #cfdbe6;
        text-decoration: none;
}
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #cfdbe6;
}
    .auto-style1 {
        width: 100%;
        height: 316px;
    }
    .auto-style2 {
        height: 29px;
        text-align: right;
    }
    .auto-style3 {
        height: 29px;
        text-align: justify;
        width: 478px;
    }
    .auto-style4 {
        width: 35%;
        height: 127px;
    }
    .auto-style5 {
        width: 341px;
        text-align: center;
        font-size: large;
    }
    .auto-style6 {
        height: 24px;
        text-align: center;
        font-size: large;
    }
    .auto-style7 {
        width: 341px;
        height: 24px;
        text-align: center;
        font-size: large;
    }
    .auto-style8 {
        width: 174px;
        height: 24px;
        text-align: center;
        font-size: large;
    }
    .auto-style9 {
        width: 174px;
        text-align: center;
        font-size: large;
    }
    .auto-style10 {
        text-align: center;
        font-size: large;
    }
    .button {
    background-color: #4CAF50;
    border: none;
    color: white;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin : 4px 2px;
    cursor: pointer;  
}
.button:hover {
  background-color: #ddd;
  color: black;
}
</style>
    <form id="form1" runat="server">
    
<!--Img --> 
        <div>    
        <asp:Image ID="Image1" runat="server" Height="107px" ImageUrl="~/Contact/homepic.PNG" Width="208px" />
        </div>
<!--Menu --> 
  <div dir="rtl" id="Menu" runat="server" style="background-color:#464646">
      <asp:Button class="button" runat="server" id="HomeBtn" Text="בית" OnClick="HomeBtn_Click"/>
      <asp:Button class="button" runat="server" id="VolunteerBtn" Text="מתנדבות" OnClick="VolunteerBtn_Click"/>
      <asp:Button class="button" runat="server" id="SchoolBtn" Text="בתי ספר" OnClick="SchoolBtn_Click"/>
      <asp:Button class="button" runat="server" id="WorkShopsBtn" Text="סדנאות" OnClick="WorkShopsBtn_Click"/>
      <asp:Button class="button" runat="server" id="FormsBtn" Text="טפסים" OnClick="FormsBtn_Click"/>

 </div>
      






        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Narkisim" Font-Size="Large" ForeColor="Black" Height="271px" NextPrevFormat="FullMonth" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged" TitleFormat="Month" Width="478px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Black" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="הסבר:"></asp:Label>
                    <br />
                    <asp:TextBox ID="DateText" Enabled="false"  runat="server" Height="241px" Width="680px" TextMode="MultiLine" Font-Size="Large"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
    <table align="right" border="1" class="auto-style4">
        <tr>
            <td class="auto-style6" colspan="2" style="background-color: #99CCFF"><strong>התראות</strong></td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>&nbsp;פניות חדשות לקיום סדנא&nbsp;</strong></td>
            <td class="auto-style8">15</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>סדנאות בתהליך שיבות</strong></td>
            <td class="auto-style9">250</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>בקשות הצטרפות כמתנדבת</strong></td>
            <td class="auto-style9">14</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>סדנאת צפויות </strong></td>
            <td class="auto-style9">7</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>סדנאות שלא סוכמו</strong></td>
            <td class="auto-style9">3</td>
        </tr>
    </table>
</body>
</html>
