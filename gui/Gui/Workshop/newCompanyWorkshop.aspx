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

        <div class="container">

            <h2>הוספת סדנאות בחברה</h2>
            <hr />

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
                    <asp:TextBox ID="companyID" runat="server" type="number" Enabled="false" CssClass="form-control disabled" Width="220px"></asp:TextBox>
                    <br />
                    <!-- Company Address -->
                    <label class="control-label" for="address">כתובת:</label>
                    <br />
                    <asp:TextBox ID="address" runat="server" Enabled="false" CssClass="form-control disabled" Width="220px"></asp:TextBox>
                    <br />
                    <!-- Company Area -->
                    <label class="control-label" for="area">אזור:</label>
                    <br />
                    <asp:TextBox ID="area" runat="server" Enabled="false" CssClass="form-control disabled" Width="220px"></asp:TextBox>
                </fieldset>
            </div>

            <!-- column 2-->
            <div class="col-md-8">
                <fieldset id="workshopDetails" runat="server">
                    <legend>פרטי סדנא</legend>
                    <!-- Possible Students Num-->
                    <label class="control-label" for="PredictedStudentsNum">מס' משתתפות אפשרי: </label>

                    <asp:TextBox ID="PredictedStudentsNum"
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
                    <br />
                    <asp:TextBox type="date" runat="server" ID="datePicker" CssClass="form-control" Width="220px"></asp:TextBox>
                    <br />
                  
                    <div class="form-inline">
                        <b>שעה:</b>
                        <!-- Minutes -->
                        <asp:TextBox ID="minutes" type="number" min="0" max="50" step="10" CssClass="form-control"
                            Text="0" Width="60px" required="required"
                            runat="server"></asp:TextBox>
                        <b>:</b>
                        <!-- Hour -->
                        <asp:TextBox ID="hour"
                            type="number" min="7" max="23" runat="server" CssClass="form-control"
                            Width="60px" placeholder="H" required="required"></asp:TextBox>
                    </div>



                </fieldset>

                <p class="tpbutton btn-toolbar text-center">

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" OnClick="AddWorkshop" Text="הוספת סדנא" />
                    <a class="btn btn-default" href="WorkshopsView.aspx">חזרה לעמוד סדנאות</a>
                </p>

            </div>
        </div>

    </form>
</body>
</html>
