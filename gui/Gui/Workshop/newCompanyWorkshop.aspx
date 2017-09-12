<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newCompanyWorkshop.aspx.cs" Inherits="gui.Gui.Workshop.newCompanyWorkshop" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>הוספת סדנאות בתעשייה</title>
   
</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />
        <hr />
        <div class="container">

            <h2>הוספת סדנאות בחברה</h2>
            <hr />
            <asp:Label runat="server" ID="Msg" Font-Italic="true"></asp:Label>
            <!-- Choose Company By Name -->
            <label class="control-label" for="dropDownCompanyName">בחירת חברה: </label>
            <div>
                <asp:DropDownList ID="dropDownCompanyName" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="FillCompanyDetails"
                    class="form-control custom-select"
                    oninvalid="setCustomValidity('יש לבחור חברה')"
                    onchange=""
                    Width="220px">
                </asp:DropDownList>
            </div>
            <br />

            <!-- column 1-->
            <div class="col-md-4">
                <fieldset id="companyDetails" runat="server">
                    <legend>פרטי חברה</legend>
                    <!-- Company ID -->
                    <label class="control-label" for="companyID">מספר מזהה:</label>
                    <br />
                    <asp:TextBox ID="companyID" runat="server" type="number" Enabled="false" class="form-control"></asp:TextBox>
                    <br />
                    <!-- Company Address -->
                    <label class="control-label" for="address">כתובת:</label>
                    <br />
                    <asp:TextBox ID="address" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                    <br />
                    <!-- Company Area -->
                    <label class="control-label" for="area">אזור:</label>
                    <br />
                    <asp:TextBox ID="area" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                </fieldset>
            </div>

            <!-- column 2-->
            <div class="col-md-8">
                <fieldset id="workshopDetails" runat="server">
                    <legend>פרטי סדנא</legend>
                    <!-- Possible Students Num-->
                    <label class="control-label" for="possibleStudentsNum">מס' משתתפות אפשרי: </label>

                    <asp:TextBox ID="possibleStudentsNum"
                        type="number"
                        class="form-control"
                        min="0"
                        runat="server" Width="220px"></asp:TextBox>

                    <br />
                    <!-- Comments-->
                    <label class="control-label" for="comments">הערות: </label>

                    <asp:TextBox ID="comments"
                        runat="server" Width="220px"
                        class="form-control"
                        TextMode="MultiLine"
                        Rows="3" Style="resize: none;"></asp:TextBox>

                    <br />
                  
                       
                            <!-- Date -->
                            <asp:Label runat="server" ID="DateError" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                            <label for="calendar">תאריך : </label>

                            <asp:Calendar FirstDayOfWeek="Sunday" ID="calendar" runat="server" DayNameFormat="Shortest"  Width="200px" OnDayRender="calendar_DayRender">
                                <TodayDayStyle BackColor="Blue" ForeColor="Yellow"></TodayDayStyle>

                            </asp:Calendar>


                            <!-- Time -->
                            <b>שעה:</b>
                            <br />

                            <!-- Minutes -->
                            <asp:TextBox ID="minutes"
                                type="number" min="0" max="50" step="10"
                                class="form-control"
                                Text="0"
                                runat="server" CssClass="pull-right"></asp:TextBox>

                            <!-- Hour -->
                            <asp:Label runat="server" Style="float: right;">:</asp:Label>
                            <asp:TextBox ID="hour"
                                type="number" min="7" max="23" runat="server" Text="8"
                                class="form-control"
                                CssClass="pull-right"></asp:TextBox>
                       
                   
                </fieldset>

                <p class="tpbutton btn-toolbar text-center">

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="AddWorkshop" Text="הוספת סדנא" />
                    <a class="btn btn-default">חזרה לעמוד סדנאות</a>
                </p>

            </div>
        </div>

    </form>
</body>
</html>
