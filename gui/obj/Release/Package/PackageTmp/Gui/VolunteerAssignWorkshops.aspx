<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerAssignWorkshops.aspx.cs" Inherits="gui.Gui.VolunteerAssignWorkshops" %>


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
  <div dir="rtl" id="SubMenu" runat="server" style="background-color:#464646">
      <asp:Button class="button" runat="server" id="Button2" Text="הוספת סדנא חדשה" />

 </div>
        <hr />



                <asp:Table id="mainTable"  CssClass="auto-style1" runat="server" Width="969px" >
           <asp:TableRow>
                <asp:TableCell >
                    <asp:Calendar ID="Calendar" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Narkisim" Font-Size="Large" ForeColor="Black" Height="289px" NextPrevFormat="FullMonth" OnDayRender="Calendar_DayRender" OnSelectionChanged="Calendar_SelectionChanged" TitleFormat="Month" Width="509px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" ForeColor="Black" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                        <TodayDayStyle BackColor="#CCCC99" />
                    </asp:Calendar>
                </asp:TableCell>
                <asp:TableCell >
                    <br />
                </asp:TableCell>
            </asp:TableRow>        
           <asp:TableRow>
                <asp:TableCell >
                    סנדאות עבור התאריך :
                    <asp:TextBox ID="TextBox16"  runat="server"></asp:TextBox>
                            </asp:TableCell>
                <asp:TableCell >
                    &nbsp;
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow BorderStyle="Solid" BorderWidth="2px">
                <asp:TableCell ColumnSpan="1">
                    <asp:Table runat="server"  
                         id="exampletable1" >
                        <asp:TableRow>
                            <asp:TableCell >מס סדנא</asp:TableCell>
                            <asp:TableCell >54353</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell ></asp:TableCell>
                            <asp:TableCell ></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell >בית ספר</asp:TableCell>
                            <asp:TableCell>בית ספר טוב </asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell >מועד</asp:TableCell>
                            <asp:TableCell >1/7/2017</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell >בחרי שיבוץ</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                            <asp:TableCell >&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" >מתנדבת וותיקה</asp:TableCell>
                            <asp:TableCell >מתנדבת</asp:TableCell>
                            <asp:TableCell >מתנדבת</asp:TableCell>
                            <asp:TableCell >מתנדבת</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" >
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="220px">
                                </asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="220px">
                                </asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:DropDownList ID="DropDownList3" runat="server" Width="220px">
                                </asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:DropDownList ID="DropDownList4" runat="server" Width="220px">
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" >האם מגיע עם רכב ומהיכן?</asp:TableCell>
                            <asp:TableCell >האם מגיע עם רכב ומהיכן?</asp:TableCell>
                            <asp:TableCell >האם מגיע עם רכב ומהיכן?</asp:TableCell>
                            <asp:TableCell >האם מגיע עם רכב ומהיכן?</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" >
                                <asp:TextBox ID="TextBox1" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:TextBox ID="TextBox10" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:TextBox ID="TextBox12" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:TextBox ID="TextBox14" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell   ColumnSpan="2">האם זקוקה לטרמפ ומהיכן?</asp:TableCell>
                            <asp:TableCell >האם זקוקה לטרמפ ומהיכן?</asp:TableCell>
                            <asp:TableCell >האם זקוקה לטרמפ ומהיכן?</asp:TableCell>
                            <asp:TableCell >האם זקוקה לטרמפ ומהיכן?</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell  ColumnSpan="2">
                                <asp:TextBox ID="TextBox9" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:TextBox ID="TextBox11" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:TextBox ID="TextBox13" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell >
                                <asp:TextBox ID="TextBox15" runat="server" Width="220px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="Button1" runat="server" Text="עדכני" Width="108px" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>

