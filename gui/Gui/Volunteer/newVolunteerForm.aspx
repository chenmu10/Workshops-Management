<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewVolunteerForm.aspx.cs" Inherits="gui.Default" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <style type="text/css">
        
        .form-control {
            width: 70%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="row">
                <div class="col-sm-6">

                    <div class="page-header">
                        <h3>הצטרפות להתנדבות בסדנאות 
							<br />
                            <small>נעדכן אותך בסדנאות ובאירועי הכשרת מתנדבות.
                                <br />*כל השדות חובה
                            </small>
                        </h3>
                        <p>
                            מי אנחנו? מהממ"ט (מהממות בהנדסה, מדעים, מתמטיקה וטכנולוגיה) הוא פרויקט התנדבותי שמטרתו לעודד בנות לבחור מגמה מדעית טכנולוגית בתיכון.
                        <br />
                            מה אנחנו עושות? המתנדבות שלנו מעבירות סדנה בת 3 שעות לבנות כיתה ט' בבתי ספר ברחבי הארץ.
                    בסדנה הבנות לומדות לפתח את אפליקציית האנדרואיד הראשונה שלהן!
                    לא דרוש ידע קודם בפיתוח אפליקציות, אנחנו נלמד אתכן הכל בהכשרה.
                    לאחר ההכשרה את מוזמנת להירשם להעברת סדנה במועד ובמקום שמתאים לך.
                    אחת לחודש - חודשיים אנחנו מקיימות ערב הכשרה. את מוזמנת להירשם מטה ונודיע לך על ערב ההכשרה הבא שלנו.
                    הצטרפי אלינו בהובלת שינוי משמעותי בכמות הבנות הנרשמות למגמות טכנולוגיות!
                        </p>
                    </div>
                    <br />

                    <!-- Hebrew First & Last Name-->
                    <div>
                        <label class="control-label">שם בעברית:</label>
                        <br />

                        <asp:TextBox ID="Firstname" class="form-control"
                            type="text"
                            pattern="[\u0590-\u05FF''-'\s]{1,20}"
                            oninvalid="setCustomValidity('שם פרטי לא תקין, אנא נסי שם בעיברית')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            required="required" placeholder="שם פרטי"
                            runat="server"></asp:TextBox>
                        <br />

                        <asp:TextBox ID="Lastname" class="form-control"
                            type="text"
                            pattern="[\u0590-\u05FF''-'\s]{1,20}"
                            oninvalid="setCustomValidity('שם משפחה לא תקין, אנא נסי שם בעיברית ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            required="required" placeholder="שם משפחה"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!-- English First & Last Name-->
                    <div>
                        <label class="control-label">שם באנגלית:</label>
                        <asp:TextBox ID="Firstnameeng" class="form-control"
                            type="text" 
                            pattern="[/^[a-z ,.'-]+$/i]{1,20}"
                            oninvalid="setCustomValidity('שם באנגלית בבקשה ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            required="required" placeholder="first name"
                            runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="Lastnameeng" class="form-control"
                            type="text"
                            pattern="[/^[a-z ,.'-]+$/i]{1,20}"
                            oninvalid="setCustomValidity('שם באנגלית בבקשה ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            required="required" placeholder="last name"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!-- Email-->
                    <div>
                        <label class="control-label" for="email">אימייל:</label>
                        <asp:TextBox class="form-control" runat="server" ID="Email" placeholder="name@email.com" type="email" required="required" />
                    </div>
                    <br />
                    <!--Phone-->
                    <div>
                        <label class="control-label" for="phone">
                            טלפון: 
                        </label>
                        <asp:TextBox class="form-control" ID="Phone"
                            type="tel"
                            pattern="[0-9]{3}-[0-9]{7}"
                            required="required"
                            oninvalid="setCustomValidity('05X-XXXXXXX  הכנסי את הטלפון לפי הפורמט')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="05X-XXXXXXX "
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!--Occupation-->
                    <div>
                        <label class="control-label" for="DropDownListOccupation">עיסוק: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListOccupation" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListOccupation" required="required" runat="server">
                            <asp:ListItem Value="בחרי"></asp:ListItem>
                            <asp:ListItem Value="סטודנטית"></asp:ListItem>
                            <asp:ListItem Value="אקדמאית"></asp:ListItem>
                            <asp:ListItem Value="עובדת בתעשייה"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <br />
                    <!--Employer-->
                    <div>
                        <label class="control-label" for="employer">מעסיק או מוסד אקדמי נוכחי: </label>
                        <asp:TextBox class="form-control" ID="Employer"
                            type="text"
                            pattern="([A-z\u0590-\u05FF0-9\s]){2,}"
                            oninvalid="setCustomValidity('קלט לא תקין')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            required="required" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!--Reference-->
                    <div>
                        <label class="control-label" for="DropDownListReference">איך הגעת אלינו: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListReference" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListReference" runat="server" required="required">
                            <asp:ListItem Value="בחרי"></asp:ListItem>
                            <asp:ListItem Value="פייסבוק"></asp:ListItem>
                            <asp:ListItem Value="מכרים"></asp:ListItem>
                            <asp:ListItem Value="עבודה"></asp:ListItem>
                            <asp:ListItem Value="אחר"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <div>
                            <asp:Label for="otherRef" runat="server">פרטי אם סימנת "אחר":</asp:Label>
                            <asp:TextBox class="form-control" ID="otherRef"
                                type="text"
                                pattern="([A-z\u0590-\u05FF0-9\s]){2,}"
                                oninvalid="setCustomValidity('שדה חובה')"
                                onchange="try{setCustomValidity('')}catch(e){}"
                                runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <br />


                    <!--ListAreas-->
                    <div>
                        <label class="control-label" for="CheckBoxListAreas">אזור פעילות מועדף: </label>
                        <!--AreaErrorMsg-->
                        <asp:Label ID="AreaErrorMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxListAreas" runat="server" required="required"></asp:CheckBoxList>
                    </div>
                    <br />

                    <!--ListTraining-->
                    <div>
                        <label class="control-label" for="DropDownListTraining">אזור מועדף להכשרה:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListTraining" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListTraining" runat="server" required="required">
                           <asp:ListItem Value="x" Text="בחרי"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <br />


                    <asp:Button ID="Send" class="btn btn-success" runat="server" Text="שליחה"/>


                </div>

            </div>

        </div>

    </form>
</body>
</html>




