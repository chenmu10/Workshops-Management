<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveNewVolunteerForm.aspx.cs" Inherits="gui.Gui.ApproveNewVolunteerForm" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MMT Project </title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />

    <style type="text/css"> 
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
 ltr-style {
            direction: ltr;
        }
</style>

</head>
    
<body>
<form id="form1" runat="server">

    <div class="jumbotron">
        <h2>סדנאות: שיבוץ מתנדבות</h2>
        <asp:Button ID="ButtonSearch" class="btn btn-primary" runat="server" Text="חיפוש" />
        <asp:Button ID="ButtonFillter" class="btn btn-primary" runat="server" Text="סינון" />
    </div>
    <!-- workshop table-->
    <div class="container">
        <h3>סדנא נבחרת לשיבוץ:</h3>
        <div class="col-md-8">
            <asp:Table ID="worckshopTable" class="table table-striped" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>
                        בי"ס
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        כתובת
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        תאריך
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        כתובת
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                
                    </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <!-- volunteers assignment -->
            <asp:PlaceHolder ID="VolunterAsiignPlaceHolder" runat="server"> 
                <h5 style="display: inline;">הסדנא הנבחרת הינה</h5>
                <asp:Label ID="workshopIdLabel" runat="server" class="label label-primary"></asp:Label>
                <h5>הכניסי את פרטייך באחד מהמקומות הפנויים: </h5>
                
                <!-- volunteer1 -->
                <div class="col-md-4">
                <fieldset id="Volunteer1" runat="server">
                <legend>מתנדבת 1 - ותיקה</legend>
                    <asp:DropDownList ID="Voluntter1DropDownList" runat="server" onchange="try{setCustomValidity('')}catch(e){}" class="custom-select"></asp:DropDownList>
                <div class="form-inline">
                    <label class="control-label" for="volunteer1Ride">פרטי טרמפ: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="volunteer1Ride" type="text" class="form-control" placeholder="יציאה+חזרה, מאיפה ומתי" runat="server" Width="220px"></asp:TextBox>
                    </div>
                </div>
                </fieldset>
                </div>
               
                <!-- volunteer2 -->
                <div class="col-md-4">
                <fieldset id="Volunteer2" runat="server">
                <legend>מתנדבת 2 - ותיקה</legend>
                    <asp:DropDownList ID="Voluntter2DropDownList" runat="server" oninvalid="setCustomValidity('יש לבחור איזור פעילות')" onchange="try{setCustomValidity('')}catch(e){}" class="custom-select"></asp:DropDownList>
                    <div class="form-inline">
                        <label class="control-label" for="volunteer2Ride">פרטי טרמפ: </label>
                        <div class="form-inline">
                             <asp:TextBox ID="volunteer2Ride" type="text" class="form-control" placeholder="יציאה+חזרה, מאיפה ומתי" runat="server" Width="220px"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>
                </div>
                <!-- volunteer3 -->
                <div class="col-md-4">   
                <fieldset id="Volunteer3" runat="server">
                   <legend>מתנדבת 3 - ותיקה</legend>
                   <asp:DropDownList ID="Voluntter3DropDownList" runat="server" oninvalid="setCustomValidity('יש לבחור איזור פעילות')" onchange="try{setCustomValidity('')}catch(e){}" class="custom-select"></asp:DropDownList>
                   <div class="form-inline">
                       <label class="control-label" for="volunteer3Ride">פרטי טרמפ: </label>
                       <div class="form-inline">
                           <asp:TextBox ID="volunteer3Ride" type="text" class="form-control" placeholder="יציאה+חזרה, מאיפה ומתי" runat="server" Width="220px"></asp:TextBox>
                       </div>
                   </div>
                </fieldset>
                </div>
            </asp:PlaceHolder>
        </div>
       
    <!-- calander-->
    <div class="col-md-4">
    </div>

    </div>
</form>
</body>
</html>


