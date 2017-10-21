<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeedbackTeacher.aspx.cs" Inherits="gui.Gui.Documents.FeedbackTeacher" %>

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
                    <h3>משוב עבור סדנת מהממ"ט-מורה
                        <br />
                        <small>*-דרוש</small></h3>
                        מזהה סדנא: <asp:Label id="workshopIDLabel" runat="server"></asp:Label>
                    <br />
                        שם בי"ס: <asp:Label id="schoolNameLabel" runat="server"></asp:Label>
                    <br />
                        כתובת: <asp:Label id="addressLabel" runat="server"></asp:Label>
                    <br />
                        מועד: <asp:Label id="dateLabel" runat="server"></asp:Label>
                    <br />
                        מורה: <asp:Label id="TeacherNameLabel" runat="server"></asp:Label>
                    <br />
                </div>
                <br />

                <!--highschool 1-5-->
                <label class="control-label" for="RadioButtonListHighschool">*עד כמה לדעתך הסדנה תתרום לבחירת מגמה טכנולוגית בתיכון? 1-מעט מאד 5-הרבה מאד</label>
                <asp:RadioButtonList ID="RadioButtonListHighschool" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem Value="2"></asp:ListItem>
                    <asp:ListItem Value="3"></asp:ListItem>
                    <asp:ListItem Value="4"></asp:ListItem>
                    <asp:ListItem Value="5"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RadioButtonListHighschool" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <!--future workshops 1-5-->
                <label class="control-label" for="RadioButtonListMoreWorkshops">*עד כמה תהיי/ה מעוניין/ת לקיים פעילות זו שוב בבית ספרך? 1-מעט מאד 5-הרבה מאד</label>
                <asp:RadioButtonList ID="RadioButtonListMoreWorkshops" runat="server">
                    <asp:ListItem Value="1"></asp:ListItem>
                    <asp:ListItem Value="2"></asp:ListItem>
                    <asp:ListItem Value="3"></asp:ListItem>
                    <asp:ListItem Value="4"></asp:ListItem>
                    <asp:ListItem Value="5"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadioButtonListMoreWorkshops" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <!--opinion-->
                <label class="control-label" for="opinion">*מה דעתך על הסדנה? </label>
                <div>
                    <asp:TextBox
                        ID="opinion"
                        class="form-control"
                        TextMode="multiline"
                        Columns="50"
                        Rows="5"
                        required="required"
                        oninvalid="setCustomValidity('יש להזין')"
                        onchange="try{setCustomValidity('')}catch(e){}"
                        runat="server">
                    </asp:TextBox>
                </div>
                <br />

                <!--Improve-->
                <label class="control-label" for="improve">*מה היית משפר/ת בסדנה?: </label>
                <div>
                    <asp:TextBox
                        ID="improve"
                        class="form-control"
                        TextMode="multiline"
                        Columns="50"
                        Rows="5"
                        required="required"
                        oninvalid="setCustomValidity('יש להזין')"
                        onchange="try{setCustomValidity('')}catch(e){}"
                        runat="server">
                    </asp:TextBox>
                </div>
                <br />

                <!--comments-->
                <label class="control-label" for="comments">הערות נוספות?  </label>
                <div>
                    <asp:TextBox
                        ID="comments"
                        class="form-control"
                        TextMode="multiline"
                        Columns="50"
                        Rows="5"
                        required="required"
                        oninvalid="setCustomValidity('יש להזין')"
                        onchange="try{setCustomValidity('')}catch(e){}"
                        runat="server">
                    </asp:TextBox>
                </div>
                <br />

                <!--ok to publish-->
                <label class="control-label" for="RadioButtonListOkToPublish">*האם נוכל לפרסם משוב זה?</label>
                <asp:RadioButtonList ID="RadioButtonListOkToPublish" runat="server">
                    <asp:ListItem Value="כן"></asp:ListItem>
                    <asp:ListItem Value="לא"></asp:ListItem>
                    <asp:ListItem Value="כן אך ללא ציון שמי"></asp:ListItem>
                    <asp:ListItem Value="כן אך ללא ציון שמי ובית ספרי"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadioButtonListOkToPublish" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />

                <asp:Label runat="server" ID="msg" Font-Italic="true"></asp:Label>
                <button id="submit" class="btn btn-success center-block">שליחה</button>
            </div>
        </div>
    </div>

    </form>
</body>
</html>
