<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyEditInformation.aspx.cs" Inherits="gui.Gui.CompanyViewInformation" %>


<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
    

</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />

        <div class="container">
            <div class="jumbotron">
                <h2>צפייה בפרטי חברה</h2>
            </div>
            <!-- column 1 - Company Details-->
            <div class="col-md-6">
                <fieldset id="companyDetails" runat="server">
                    <legend>פרטי החברה</legend>
                    <table class="auto-style13">
                        <tr>
                            <td class="auto-style17">מזהה</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="companyID"
                                    type="number"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">שם:</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="companyName"
                                    type="text"
                                    pattern="[A-Za-z\u0590-\u05FF''-'\s]{1,40}"
                                    placeholder="עדיף באנגלית כדי להקל על חיפוש"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">כתובת:</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="companyAddress"
                                    type="text"
                                    placeholder="רחוב, מספר ועיר"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">אזור:</td>
                            <td class="auto-style12">
                                <asp:DropDownList ID="DropDownListArea" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">מס&#39; סדנאות שהתקיימו:</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="doneWorkshopsNum"
                                    type="number"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                </fieldset>
            </div>

            <!-- column 2-->
            <div class="col-md-6">
                <fieldset id="ContactDetails" runat="server">
                    <legend>פרטי איש/אשת קשר</legend>
                    <table class="auto-style14">
                        <tr>
                            <td class="auto-style15">שם:</td>
                            <td>
                    <asp:TextBox ID="contactname"
                        type="text"
                        pattern="[A-Za-z\u0590-\u05FF''-'\s]{1,40}"
                        runat="server">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">טלפון:</td>
                            <td>
                    <asp:TextBox ID="contactphone"
                        type="tel"
                        pattern="[0-9]{3}-[0-9]{7}"
                        placeholder="05X-XXXXXXX לא לשכוח מקף "
                        runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">אימייל:</td>
                            <td>
                    <asp:TextBox ID="contactemail"
                        type="email"
                        runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <br />
            <br />
            <div class="col-md-12 text-center">
                <asp:Label runat="server" ID="Msg" Font-Italic="true"></asp:Label>
                <br />
                <asp:Button ID="Button2" class="btn btn-info" runat="server" Text="חזרה" />
                <br />
            </div>
        </div>


        <script src="../../js/jquery-3.0.0.min.js"></script>
        <script src="../../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
