<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyWorkshopEditInfo.aspx.cs" Inherits="gui.Gui.Workshop.CompanyWorkshopEditInfo" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <div class="container">
            <div class="page-header">
                <h3>צפייה בפרטי סדנא בחברה<br />
                </h3>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <label class="control-label" for="WorkShopID">מס' מזהה: </label>
                    <asp:Label runat="server" ID="WorkShopID"></asp:Label>
                    <br />

                    <label class="control-label" for="WorkShopStatus">סטטוס: </label>
                    <asp:Label runat="server" ID="WorkShopStatus"></asp:Label>
                    <br />

                    <label class="control-label" for="estimatedParticipants">מועד קיום: </label>
                    --
                <br />
                                 
                

                    <br />
                    <br />
                    <label class="control-label" for="DropDownListStatus">שינוי סטטוס: </label>
                    <select class="selectpicker" id="DropDownListStatus">
                        <option value="1" disabled>לשיבוץ בי"ס</option>
                        <option value="2">לשיבוץ מתנדבות</option>
                        <option value="3" disabled>מתנדבות שובצו</option>
                        <option value="6" disabled>לביצוע</option>
                    </select>
                    <br />
                    <br />

                    <button id="updateStatus" class="btn btn-success">עדכון סטטוס</button>
                    <br />
                    <br />
                    <button id="cancelWorkshop" class="btn btn-danger">ביטול סדנא</button>
                </div>


                <div class="col-md-9">

                    <div class="panel with-nav-tabs panel-default">
                        <div class="panel-heading">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#tab1default" data-toggle="tab">פרטי סדנא בחברה</a></li>
                                <li><a href="#tab2default" data-toggle="tab">פרטי שיבוץ בי"ס</a></li>
                                <li><a href="#tab3default" data-toggle="tab">פרטי שיבוץ מתנדבות</a></li>
                            </ul>
                        </div>

                        <div class="panel-body">
                            <div class="tab-content">

                                <%--TAB 1-Company Details--%>
                                <div class="tab-pane fade in active" id="tab1default">

                                    <!-- column 1-->
                                    <div class="col-md-6">
                                        <fieldset id="companyDetails" runat="server">
                                            <legend>פרטי חברה</legend>
                                            <!-- Company Name -->
                                            <label class="control-label" for="companyName">שם:</label>
                                            <div class="form-inline">
                                                <asp:TextBox ID="companyName" Enabled="false" Text="גוגל"
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
                                                <asp:TextBox ID="address" runat="server" Enabled="false" Text="יגאל אלון"></asp:TextBox>
                                            </div>
                                            <br />

                                            <button id="goToCompany" class="btn btn-link">מעבר לפרטי חברה</button>
                                        </fieldset>
                                    </div>

                                    <!-- column 2-->
                                    <div class="col-md-6">
                                        <fieldset id="workshopDetails" runat="server">
                                            <legend>פרטי סדנא</legend>
                                            <label class="control-label" for="possibleStudentsNum">מס' משתתפות אפשרי: </label>
                                            <div class="form-inline">
                                                <asp:TextBox ID="possibleStudentsNum" Enabled="false" Text="50"
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
                                                <asp:TextBox ID="companyComments" Enabled="false" Text="הערות שהזינו בטופס ועכשיו רק מוצגות"
                                                    runat="server" Width="220px"
                                                    class="form-control"
                                                    TextMode="MultiLine"
                                                    Rows="5" Style="resize: none;"></asp:TextBox>
                                            </div>
                                            <br />
                                            <label class="control-label" for="dateTime">תאריך ושעה: </label>
                                            <div class="form-inline">
                                                <asp:TextBox ID="dateTime" Enabled="false" Text="1/1/17 10:00"
                                                    runat="server" Width="220px"
                                                    class="form-control"></asp:TextBox>
                                            </div>
                                            <!-- Time -->
                                            <b>שעה</b>
                                            <div>
                                                <!-- Minutes -->
                                                <asp:TextBox ID="minutes"
                                                    type="number" min="0" max="55" step="5"
                                                    class="form-control"
                                                    placeholder="MM"
                                                    runat="server" CssClass="pull-right"></asp:TextBox>
                                                <!-- Hour -->
                                                <asp:Label runat="server" Style="float: right;">:</asp:Label>
                                                <asp:TextBox ID="hour"
                                                    type="number" min="0" max="23" runat="server" placeholder="HH"
                                                    class="form-control"
                                                    CssClass="pull-right"></asp:TextBox>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>

                                <%--TAB 2-School Details--%>
                                <div class="tab-pane fade" id="tab2default">
                                    <label class="control-label" for="schoolName">שם בי"ס :</label>
                                    <div class="form-inline">
                                        <asp:TextBox ID="schoolname" Enabled="false" Text="החורש"
                                            required="required"
                                            class="form-control"
                                            oninvalid="setCustomValidity('יש להזין שם בית ספר')"
                                            onchange="try{setCustomValidity('')}catch(e){}"
                                            runat="server" Width="220px">
                                        </asp:TextBox>
                                        <button id="goToSchool" class="btn btn-link">מעבר לפרטי בי"ס</button>
                                    </div>

                                    <br />

                                    <label class="control-label" for="studentsPredictedNum">מספר בנות צפויות מבי"ס: </label>
                                    <div>
                                        <asp:TextBox ID="studentsPredictedNum" Enabled="false" Text="20"
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
                                        <asp:TextBox ID="schoolComments" Enabled="false" Text="הערות שהזינו בטופס ועכשיו רק מוצגות"
                                            runat="server" Width="220px"
                                            class="form-control"
                                            TextMode="MultiLine"
                                            Rows="5" Style="resize: none;"></asp:TextBox>
                                    </div>

                                </div>

                                <%--TAB 3-Volunteer Assign Details--%>
                                <div class="tab-pane fade" id="tab3default">
                                    <div class="col-md-6">
                                        <label class="control-label" for="currentVolNum">מס' מתנדבות נוכחי:   123</label>
                                        <br />
                                        <button type="button" class="btn btn-link" id="aassignPage">מעבר לעמוד שיבוץ</button>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="col-md-6">
                                        <fieldset>
                                            <legend>פרטי מתנדבות</legend>
                                            <label class="control-label" for="vol1">מתנדבת 1: </label>
                                            <button type="button" class="btn btn-link">שם1</button>
                                            <button type="button" class="btn btn-link">משוב1</button>
                                            <br />
                                            <label class="control-label" for="vol2">מתנדבת 2: </label>
                                            <button type="button" class="btn btn-link">שם2</button>
                                            <button type="button" class="btn btn-link">משוב2</button>
                                            <br />
                                            <label class="control-label" for="vol3">מתנדבת 3: </label>
                                            <button type="button" class="btn btn-link">שם3</button>
                                            <button type="button" class="btn btn-link">משוב3</button>
                                            <br />
                                        </fieldset>
                                    </div>

                                </div>

                            </div>
                            <!--tab-content-->
                        </div>
                        <!--panel-body-->

                    </div>
                    <!--panel with-nav-tabs panel-default-->
                </div>
                <!--col-md-10-->
            </div>
            <!--row-->

        </div>
        <!--container-->
    </form>
</body>
</html>
