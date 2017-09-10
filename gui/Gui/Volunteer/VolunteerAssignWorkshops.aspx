<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerAssignWorkshops.aspx.cs" Inherits="gui.Gui.VolunteerAssignWorkshops" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MMT Project </title>
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
            <br />

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
            <br />

            <!-- Volunteers Assignment -->
            <asp:PlaceHolder ID="VolunteerAssignPlaceHolder" runat="server">
                <h4>סדנא נבחרת: </h4>
                <asp:Label ID="workshopIdLabel" runat="server" class="label label-primary" Font-Size="Large"></asp:Label>
                <h3>הכניסי את פרטייך באחד מהמקומות הפנויים:<br />
                    <small>אם מישהי מילאה פרטי טרמפ, תוכלי ליצור איתה קשר דרך המייל הרשום.</small>
                </h3>
                <br />
                <!-- volunteer1 -->
                <div class="col-md-4">
                    <fieldset id="Volunteer1" runat="server">
                        <legend>מתנדבת 1 - ותיקה</legend>
                        <asp:DropDownList
                            Width="250px"
                            ID="Voluntter1DropDownList"
                            runat="server"
                            class="form-control">
                        </asp:DropDownList>
                         <br />
                        <label class="control-label" for="volunteer1Ride">פרטי טרמפ: </label>
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
                        <asp:DropDownList ID="Voluntter2DropDownList"
                            Width="250px"
                            runat="server"
                           class="form-control">
                        </asp:DropDownList>
                        <br />

                        <label class="control-label" for="volunteer2Ride">פרטי טרמפ: </label>
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
                        <asp:DropDownList
                            ID="Voluntter3DropDownList"
                            Width="250px"
                            runat="server"
                          class="form-control">
                        </asp:DropDownList>
                        <br />
                        <label class="control-label" for="volunteer3Ride">פרטי טרמפ: </label>
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
      

                    <br />
                 
          
                <br />
                <br />
                
            </asp:PlaceHolder>
        </div>

     
        <br />
        <div style="margin-right:50%">
<asp:Button runat="server"  class="btn btn-success" ID="assign" Text="עדכני" />

        </div>
        
    </form>
    <br />
</body>
</html>
