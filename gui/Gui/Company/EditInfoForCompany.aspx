<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditInfoForCompany.aspx.cs" Inherits="gui.Gui.Company.EditInfoForCompan" %>

<%@ Register src="../Documents/nav.ascx" tagname="nav" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:nav ID="nav1" runat="server" />

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
                                    Width="200px"
                                    type="number"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">שם:</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="companyName"
                                    Width="200px"
                                    type="text"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">כתובת:</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="companyAddress"
                                    Width="200px"
                                    type="text"
                                    runat="server">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">אזור:</td>
                            <td class="auto-style12">
                                <asp:DropDownList Width="200px" ID="DropDownListArea" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">מס&#39; סדנאות שהתקיימו:</td>
                            <td class="auto-style12">
                                <asp:TextBox ID="doneWorkshopsNum"
                                    Width="200px"
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
                    <asp:TextBox ID="contactnameLabel"
                        Width="200px"
                        type="text"
                        runat="server">
                    </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">טלפון:</td>
                            <td>
                    <asp:TextBox ID="contactphoneLabel"
                        Width="200px"
                        type="tel"
                        pattern="[0-9]{3}-[0-9]{7}"
                        placeholder="05X-XXXXXXX לא לשכוח מקף "
                        runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">אימייל:</td>
                            <td>
                               
                    <asp:TextBox ID="contactemailLabel"
                        Width="200px"
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
                <asp:Button ID="back" class="btn btn-info" runat="server" Text="חזרה" />
                 <asp:Button ID="Update" class="btn btn-info" runat="server" Text="עדכון" />
                <br />
            </div>
        </div>      
    </form>
</body>
</html>