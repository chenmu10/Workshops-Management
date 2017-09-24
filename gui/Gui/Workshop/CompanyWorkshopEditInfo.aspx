<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyWorkshopEditInfo.aspx.cs" Inherits="gui.Gui.Workshop.CompanyWorkshopEditInfo" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StatusBar.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />

        <div class="container">
            <div class="page-header">
                <h3>צפייה בפרטי סדנא בחברה</h3>
            </div>


            <label class="control-label" for="WorkShopID">מס' מזהה: </label>
            <asp:Label runat="server" ID="WorkShopID"></asp:Label>
            <br />

            <label class="control-label" for="WorkShopStatus">סטטוס נוכחי: </label>
            <asp:Label runat="server" ID="WorkShopStatus"></asp:Label>
            <br />

            <label class="control-label" for="WorkShopDate">מועד קיום: </label>
            <asp:Label runat="server" ID="WorkShopDate"></asp:Label>
            <br />
           
            <asp:Button runat="server" ID="cancelWorkshop" Text="ביטול סדנא" class="btn btn-danger" />


            <hr />
            <div class="checkout-wrap">
                <ul class="checkout-bar">
                    <li runat="server" id="bar1">שיבוץ בית ספר</li>
                    <li runat="server" id="bar2">בי"ס שובץ</li>
                    <li runat="server" id="bar3">שיבוץ מתנדבות</li>
                    <li runat="server" id="bar4">מתנדבות שובצו</li>
                    <li runat="server" id="bar6">ביצוע</li>
                    <li runat="server" id="bar7">מישוב</li>
                    <li runat="server" id="bar8">סגור</li>
                </ul>
            </div>
             <div class="form-inline"  style="margin-top:150px;">
                <label class="control-label" for="selectpicker">שינוי סטטוס: </label>
                <asp:DropDownList runat="server" ID="selectpicker" CssClass="form-control" Width="150px">
                    <asp:ListItem Value="1">לשיבוץ מתנדבות</asp:ListItem>
                    <asp:ListItem Value="7">לביצוע</asp:ListItem>
                    <asp:ListItem Value="8">למישוב</asp:ListItem>
                    <asp:ListItem Value="9">לסגור</asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" ID="Button2" Text="אישור שינוי" class="btn btn-link" />
            </div>
            <br />
            <div class="row">
                <div class="panel with-nav-tabs panel-default">
                    <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#companyWorkshop" data-toggle="tab">פרטי סדנא בחברה</a></li>
                            <li><a href="#school" data-toggle="tab">פרטי שיבוץ בי"ס</a></li>
                            <li><a href="#volunteers" data-toggle="tab">פרטי שיבוץ מתנדבות</a></li>
                            <li><a href="#execute" data-toggle="tab">פרטי ביצוע</a></li>
                            <li><a href="#feedback" data-toggle="tab">משובים</a></li>
                        </ul>
                    </div>

                    <div class="panel-body">
                        <div class="tab-content">

                            <%--TAB 1-Company Details--%>
                            <div class="tab-pane fade in active" id="companyWorkshop">

                                <!-- column 1-->
                                <div class="col-md-6">
                                    <fieldset id="companyDetails" runat="server">
                                        <legend>פרטי חברה</legend>
                                        <!-- Company Name -->
                                        <label class="control-label" for="companyName">שם:</label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="companyName" Enabled="false"
                                                required="required"
                                                class="form-control"
                                                oninvalid="setCustomValidity('יש להזין שם חברה')"
                                                onchange="try{setCustomValidity('')}catch(e){}"
                                                runat="server">
                                            </asp:TextBox>
                                        </div>
                                        <br />
                                        <!-- Company Address -->
                                        <label class="control-label" for="address">כתובת:</label>
                                        <div>
                                            <asp:TextBox ID="address" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        <br />
                                        <asp:LinkButton runat="server" ID="goToCompany" class="btn btn-link">מעבר לפרטי חברה</asp:LinkButton>
                                        <br />

                                        <a class="btn btn-link" href="../School/SchoolSelectWorkshopFromIndustry.aspx" target="_blank">מעבר לטופס שיבוץ בית ספר</a>


                                    </fieldset>
                                </div>

                                <!-- column 2-->
                                <div class="col-md-6">
                                    <fieldset id="workshopDetails" runat="server">
                                        <legend>פרטי סדנא</legend>
                                        <label class="control-label" for="possibleStudentsNum">מס' משתתפות אפשרי: </label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="possibleStudentsNum" Enabled="false"
                                                type="number"
                                                class="form-control"
                                                min="0"
                                                required="required"
                                                oninvalid="setCustomValidity('יש להזין מס' משתתפות אפשרי')"
                                                onchange="try{setCustomValidity('')}catch(e){}"
                                                runat="server" Width="220px"></asp:TextBox>
                                        </div>

                                        <br />
                                        <label class="control-label" for="companyComments">הערות: </label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="companyComments" Enabled="false"
                                                runat="server" Width="220px"
                                                class="form-control"
                                                TextMode="MultiLine"
                                                Rows="5" Style="resize: none;"></asp:TextBox>
                                        </div>
                                        <br />
                                        <label class="control-label" for="dateTime">תאריך ושעה: </label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="dateTime" Enabled="false"
                                                runat="server" Width="220px"
                                                class="form-control"></asp:TextBox>
                                        </div>
                                     
                                    </fieldset>
                                </div>
                            </div>

                            <%--TAB 2-School Details--%>
                            <div class="tab-pane fade" id="school">

                                <label class="control-label" for="schoolName">שם בי"ס :</label>
                                <div class="form-inline">
                                    <asp:TextBox ID="schoolname" Enabled="false"
                                        required="required"
                                        class="form-control"
                                        oninvalid="setCustomValidity('יש להזין שם בית ספר')"
                                        onchange="try{setCustomValidity('')}catch(e){}"
                                        runat="server">
                                    </asp:TextBox>

                                    <asp:LinkButton runat="server" ID="goToSchool" class="btn btn-link">מעבר לפרטי בי"ס</asp:LinkButton>
                                </div>

                                <br />

                                <label class="control-label" for="studentsPredictedNum">מספר בנות צפויות מבי"ס: </label>
                                <div>
                                    <asp:TextBox ID="studentsPredictedNum" Enabled="false"
                                        type="number"
                                        class="form-control"
                                        min="0"
                                        required="required"
                                        oninvalid="setCustomValidity('יש להזין מס' משתתפות')"
                                        onchange="try{setCustomValidity('')}catch(e){}"
                                        runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <label class="control-label" for="schoolComments">הערות: </label>
                                <div class="form-inline">
                                    <asp:TextBox ID="schoolComments" Enabled="false"
                                        runat="server"
                                        class="form-control"
                                        TextMode="MultiLine"
                                        Rows="5" Style="resize: none;"></asp:TextBox>
                                </div>



                            </div>

                            <%--  TAB 3 - VOLUNTEER ASSIGN--%>
                            <div class="tab-pane fade" id="volunteers">
                                <div class="col-md-6">
                                    <label class="control-label" for="volunteercount">מס' מתנדבות נוכחי: </label>
                                    <asp:Label runat="server" ID="volunteercount"></asp:Label>
                                    <br />
                                    <asp:LinkButton runat="server" ID="LinkVolunteerAssign" Text="מעבר לעמוד שיבוץ"></asp:LinkButton>
                                    <br />

                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend>פרטי מתנדבות</legend>
                                        <label class="control-label" for="VolunteerName1">מתנדבת 1: </label>
                                        <asp:Label runat="server" ID="VolunteerName1"></asp:Label>
                                        <br />
                                        <label class="control-label" for="VolunteerName2">מתנדבת 2: </label>
                                        <asp:Label runat="server" ID="VolunteerName2"></asp:Label>
                                        <br />
                                        <label class="control-label" for="VolunteerName3">מתנדבת 3: </label>
                                        <asp:Label runat="server" ID="VolunteerName3"></asp:Label>
                                        <br />
                                    </fieldset>
                                </div>

                                <asp:Button runat="server" ID="backToSchoolAssign" Text="חזרי לסטטוס שיבוץ בית ספר" class="btn btn-danger" />


                            </div>

                            <%--  TAB 4 - execute--%>
                            <div class="tab-pane fade" id="execute">
                                <asp:Label runat="server" ID="Label1" Text="תאריך הסדנא לא הגיע/תאריך הסדנא עבר."></asp:Label>
                                <br />
                                <br />




                            </div>

                            <%--  TAB 5 - FEEDBACK--%>
                            <div class="tab-pane fade" id="feedback">

                                <fieldset>
                                    <label class="control-label" for="VolunteerName1">מתנדבת 1: </label>
                                    <asp:Label runat="server" ID="Label2"></asp:Label>
                                    <asp:LinkButton runat="server" ID="LinkButton1" Text="משוב"></asp:LinkButton>
                                    <br />
                                    <label class="control-label" for="VolunteerName2">מתנדבת 2: </label>
                                    <asp:Label runat="server" ID="Label3"></asp:Label>
                                    <asp:LinkButton runat="server" ID="LinkButton2" Text="משוב"></asp:LinkButton>
                                    <br />
                                    <label class="control-label" for="VolunteerName3">מתנדבת 3: </label>
                                    <asp:Label runat="server" ID="Label4"></asp:Label>
                                    <asp:LinkButton runat="server" ID="LinkButton3" Text="משוב"></asp:LinkButton>
                                    <br />



                                </fieldset>
                            </div>

                        </div>

                    </div>


                </div>


            </div>
            <!--/row-->

        </div>
        <!--/container-->
    </form>
</body>
</html>
