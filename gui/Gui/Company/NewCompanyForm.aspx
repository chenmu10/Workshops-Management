<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCompanyForm.aspx.cs" Inherits="gui.Gui.NewCompanyForm" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />

        <div class="container">
            <div class="jumbotron">
                <h2>יצירת חברה חדשה</h2>
            </div>
            <!-- column 1-->
            <div class="col-md-6">
                <fieldset id="companyDetails" runat="server">
                    <legend>פרטי החברה</legend>

                    <!-- Company Name-->
                    <label class="control-label" for="companyName">שם:</label>
                    <asp:TextBox ID="companyName"
                        type="text"
                        class="form-control"
                        pattern="[A-Za-z\u0590-\u05FF''-'\s]{1,40}"
                        placeholder="עדיף באנגלית כדי להקל על חיפוש"
                        runat="server" Width="220px">
                    </asp:TextBox>
                    <br />
                    <label class="control-label" for="companyAddress">כתובת: </label>
                    <asp:TextBox ID="companyAddress"
                        type="text"
                        class="form-control"
                        placeholder="רחוב, מספר ועיר"
                        runat="server" Width="220px">
                    </asp:TextBox>
                    <br />

                    <!--ListArea-->
                    <div>
                        <label class="control-label" for="DropDownListArea">אזור:</label>

                        <asp:DropDownList class="form-control" ID="DropDownListArea" runat="server" Width="220px">
                            <asp:ListItem Value="בחרי"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <%-- <!--Comments-->
                    <div>
                        <label class="control-label" for="comments">הערות:</label>
                         <asp:TextBox
                        ID="comments"
                        class="form-control"
                        TextMode="multiline"
                        Columns="50"
                        Rows="4"
                        runat="server">
                    </asp:TextBox>
                    </div>--%>
                </fieldset>
            </div>

            <!-- column 2-->
            <div class="col-md-6">
                <fieldset id="ContactDetails" runat="server">
                    <legend>פרטי איש/אשת קשר</legend>
                    <label class="control-label" for="contactname">שם: </label>
                    <asp:TextBox ID="contactname"
                        type="text"
                        class="form-control"
                        pattern="[A-Za-z\u0590-\u05FF''-'\s]{1,40}"
                        runat="server" Width="220px">
                    </asp:TextBox>
                    <br />
                    <label class="control-label" for="contactphone">טלפון: </label>
                    <asp:TextBox ID="contactphone"
                        type="tel"
                        class="form-control"
                        pattern="[0-9]{3}-[0-9]{7}"
                        placeholder="05X-XXXXXXX לא לשכוח מקף "
                        runat="server" Width="220px"></asp:TextBox>
                    <br />
                    <label class="control-label" for="contactemail">כתובת מייל : </label>
                    <asp:TextBox ID="contactemail"
                        type="email"
                        class="form-control"
                        runat="server" Width="220px"></asp:TextBox>
                </fieldset>
            </div>
            <br /><br />
            <div class="col-md-12 text-center">
                <asp:Label runat="server" ID="Msg" Font-Italic="true"></asp:Label>
                <br />
                <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="AddCompany" Text="הוספת חברה" />
                <asp:Button ID="Button2" class="btn btn-info" runat="server" Text="ביטול" />
                <br />
            </div>
        </div>


     
        <script src="../../js/jquery-3.0.0.min.js"></script>
        <script src="../../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
