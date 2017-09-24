<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerAssignWorkshops.aspx.cs" Inherits="gui.Gui.VolunteerAssignWorkshops" %>


<html>
<head runat="server">
    <title>שיבוץ מתנדבות </title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h2>סדנאות: שיבוץ מתנדבות</h2>
            </div>
              

            <!-- Workshops Table-->
            <h3>בחרי סדנא עבור שיבוץ:</h3>
            <asp:Table ID="workshopTable" class="table table-striped" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>
                         #
                    </asp:TableHeaderCell>
                   
                    <asp:TableHeaderCell>
                        מועד
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        כתובת
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        בי"ס
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        חברה
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        פעולות
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <!-- Volunteers Assignment -->
            <asp:PlaceHolder ID="VolunteerAssignPlaceHolder" runat="server">
                <h4>סדנא נבחרת:
                    <asp:Label ID="workshopIdLabel" runat="server" class="label label-primary" Font-Size="Large"></asp:Label>   
                </h4>
                
                <h3>הכניסי את פרטייך באחד מהמקומות הפנויים:<br />
                    <small>אם מישהי מילאה פרטי טרמפ, תוכלי ליצור איתה קשר דרך המייל הרשום.</small>
                </h3>
                <!-- volunteer1 -->
                <div class="col-md-4">
                    <fieldset id="Volunteer1" runat="server">
                        <legend>מתנדבת 1 - ותיקה</legend>
                         <asp:Label runat="server" ID="VolunteerName1" Text="" ></asp:Label>
                        <br />
                        <asp:DropDownList
                            Width="250px"
                            ID="Voluntter1DropDownList"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="Voluntter1DropDownList_SelectedIndexChanged"
                            runat="server"
                            class="form-control">
                        </asp:DropDownList>
                       <br />
                        <label class="control-label" for="volunteer1Ride">פרטי טרמפ: </label>
                         <br />   
                        <asp:TextBox
                            ID="volunteer1Ride"
                            type="text"
                            class="form-control"
                            placeholder="יציאה+חזרה, מאיפה ומתי"
                            runat="server"
                            Width="250px">
                        </asp:TextBox>
                    </fieldset>
                </div>
                <!-- volunteer2 -->
                <div class="col-md-4">
                    <fieldset id="Volunteer2" runat="server">
                        <legend>מתנדבת 2 </legend>
                        <asp:Label runat="server" ID="VolunteerName2" Text="" ></asp:Label>
                        <br />
                        <asp:DropDownList ID="Voluntter2DropDownList"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="Voluntter2DropDownList_SelectedIndexChanged"
                            Width="250px"
                            runat="server"
                           class="form-control">
                        </asp:DropDownList>     
                        <br />                 
                        <label class="control-label" for="volunteer2Ride">פרטי טרמפ: </label>
                         <br />   
                        <asp:TextBox
                            ID="volunteer2Ride"
                            type="text"
                            class="form-control"
                            placeholder="יציאה+חזרה, מאיפה ומתי"
                            runat="server"
                            Width="250px">
                        </asp:TextBox>
                    </fieldset>
                </div>

                <!-- volunteer3 -->
                <div class="col-md-4">
                    <fieldset id="Volunteer3" runat="server">
                        <legend>מתנדבת 3</legend>
                         <asp:Label runat="server" ID="VolunteerName3" Text="" ></asp:Label>    
                        <br />                    
                        <asp:DropDownList
                            AutoPostBack="true"
                            ID="Voluntter3DropDownList" OnSelectedIndexChanged="Voluntter3DropDownList_SelectedIndexChanged"
                            Width="250px"
                            runat="server"
                          class="form-control">
                        </asp:DropDownList>    
                        <br />                    
                        <label class="control-label" for="volunteer3Ride">פרטי טרמפ: </label>
                         <br />   
                        <asp:TextBox
                            ID="volunteer3Ride"
                            type="text"
                            class="form-control"
                            placeholder="יציאה+חזרה, מאיפה ומתי"
                            runat="server"
                            Width="250px">
                        </asp:TextBox>
                    </fieldset>
                </div>               
            </asp:PlaceHolder>
        </div>           
        <div style="margin-right:50%;margin-top:25px" >
<asp:Button runat="server"  class="btn btn-success" ID="assign" Text="עדכני" OnClick="assign_Click" />
            <asp:Label runat="server" ID="DupLabel" Text="יש כפילות בבחירת המתנדבות,אנא בחרי שנית" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="succsess" Text="ההרשמה הצליחה" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="nonSelected" Text="יש לבחור מתנדבת על מנת לעדכן" Visible="false"></asp:Label>
        </div>        
    </form>
    
</body>
</html>
