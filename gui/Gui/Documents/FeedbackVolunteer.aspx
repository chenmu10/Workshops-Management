<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackVolunteer.aspx.cs" Inherits="gui.Gui.Documents.FeedbackVolunteer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <div class="page-header">
                     <asp:Image runat="server" Height="107px" Width="402px" ImageUrl="../../../Content/homepic.PNG" AlternateText="Picture not found"/>
                    <h3>משוב עבור סדנת מהממ"ט-מתנדבת
                        <br />
                        <small> *-דרוש</small></h3>
                        מזהה סדנא: <asp:Label id="workshopIDLabel" runat="server"></asp:Label>
                        <br />
                        שם בי"ס: <asp:Label id="schoolNameLabel" runat="server"></asp:Label>
                        <br />
                        שם חברה: <asp:Label id="companyNameLabel" runat="server"></asp:Label>
                        <br />
                        כתובת: <asp:Label id="addressLabel" runat="server"></asp:Label>
                        <br />
                        מועד: <asp:Label id="dateLabel" runat="server"></asp:Label>
                        <br />
                        מתנדבת: <asp:Label id="volNameLabel" runat="server"></asp:Label>
                        <br />
                </div>
                  <br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadioButtonListteachePresent" runat="server" ErrorMessage="יש לבחור נוכחות מורה" ForeColor="Red"></asp:RequiredFieldValidator><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="RadioButtonListlistenLevel" runat="server" ErrorMessage="יש לבחור רמת שיתוף פעולה" ForeColor="Red"></asp:RequiredFieldValidator>
                <!--teacher present yes/no-->
                <br />
                <label class="control-label" for="RadioButtonListteachePresent">*נוכחות מורה:</label>
                <asp:RadioButtonList ID="RadioButtonListteachePresent" runat="server">
                    <asp:ListItem Value="כן"></asp:ListItem>
                    <asp:ListItem Value="לא"></asp:ListItem>
                    <asp:ListItem Value="אחר"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadioButtonListteachePresent" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <div>
                    <label class="control-label" for="teacherPresentOther">אם סימנת "אחר", פרטי בבקשה:</label>
                    <asp:TextBox ID="teacherPresentOther" class="form-control"
                        type="text"
                        placeholder="מה הייתה זמינות המורה?"
                        runat="server"></asp:TextBox>
                    <br />

                    <!--listenLevel rate-->
                    <label class="control-label" for="RadioButtonListlistenLevel">*רמת הקשבה ושיתוף פעולה: 1-נמוכה מאד 5-גבוהה מאד</label>
                    <asp:RadioButtonList ID="RadioButtonListlistenLevel" runat="server">
                        <asp:ListItem Value="1"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="3"></asp:ListItem>
                        <asp:ListItem Value="4"></asp:ListItem>
                        <asp:ListItem Value="5"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RadioButtonListlistenLevel" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                    <!--difficulties-->
                    <label class="control-label" for="difficulties">*נושאים/קשיים עיקריים שעלו: </label>
                    <div>
                        <asp:TextBox
                            ID="difficulties"
                            class="form-control"
                            TextMode="multiline"
                            Columns="50"
                            Rows="5"
                            runat="server">
                        </asp:TextBox>
                    </div>
                    <br />

                    <!--tech problems-->
                    <label class="control-label" for="techProblems">*תקלות טכניות(מקרן/אמולטור/רשת אינטרנט): </label>
                    <div>
                        <asp:TextBox
                            ID="techProblems"
                            class="form-control"
                            TextMode="multiline"
                            Columns="50"
                            Rows="5"
                            runat="server">
                        </asp:TextBox>
                    </div>
                    <br />

                    <!--comments-->
                    <label class="control-label" for="comments">*התרשמות והערות כלליות: </label>
                    <div>
                        <asp:TextBox
                            ID="comments"
                            class="form-control"
                            TextMode="multiline"
                            Columns="50"
                            Rows="5"
                            runat="server">
                        </asp:TextBox>
                    </div>
                    <br />
                   <asp:Label runat="server" ID="msg" Font-Italic="true" Font-Color="red"></asp:Label>
                    <asp:Button runat="server" ID="Send" CssClass="btn btn-success center-block" Text="שליחה" OnClick="Send_Click" />
                    <br />
                  </div>
            </div>

        </div>


    </div>

    </form>
</body>
</html>
