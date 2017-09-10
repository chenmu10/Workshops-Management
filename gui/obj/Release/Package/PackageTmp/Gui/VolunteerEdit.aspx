<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerEdit.aspx.cs" Inherits="gui.Gui.VolunteerEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        height: 347px;
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
    table {
    border-collapse: collapse;
    width: 100%;
}

th, td {
    text-align: left;
    padding: 8px;
}

tr:nth-child(even){background-color: #f2f2f2}

    th {
        background-color: #4CAF50;
        color: white;
    }
    .alnright { text-align: right; }

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
      




        <hr />
        <asp:Table  ID="volunteerTable" runat="server" >
            <asp:TableRow >
                <asp:TableCell Font-Bold="true" CssClass =" alnright"> שם</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">סטטוס</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">עיסוק</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">אימייל</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">טלפון</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">איזור פעילות</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">סדנאות שהועברו</asp:TableCell>
                <asp:TableCell Font-Bold="true" CssClass =" alnright">  עריכה</asp:TableCell>
            </asp:TableRow>




        </asp:Table>

    </form>
</body>
</html>
