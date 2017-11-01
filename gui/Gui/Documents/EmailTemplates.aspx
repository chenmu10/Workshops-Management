<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplates.aspx.cs" Inherits="gui.Gui.Documents.EmailTemplates" %>

<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc1" %>

<!DOCTYPE html>
<html>
<head >
    <title>MMT Project </title>
   <style>
       body{
           background-image: url("../../../Content/back.jpg");
           background-size: cover;
       }
.mybutton {
    background-color: rgba(0,0,0,0.08); /* gray */
    border: none;
    color: black;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 4px 2px;
    cursor: pointer;
    -webkit-transition-duration: 0.4s; /* Safari */
    transition-duration: 0.4s;
}
.button2:hover {
    box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
}
.myText{
    width: 100%;
    height: auto;
    padding: 12px 20px;
    box-sizing: border-box;
    border: 2px solid #ccc;
    border-radius: 4px;
    background-color: #f8f8f8;
    resize: none;
}
   </style>
</head>

<body>

         <form id="form1" runat="server">
        <uc1:nav ID="nav1" runat="server" />
         <div class="container">
            <div  class="jumbotron" style="background-color:rgba(255, 255, 255,0.8); width:80%; height:80%; margin:auto;">
            
                 <asp:Image ID="Image2" runat="server" Height="107px" ImageUrl="../../../Content/homepic.PNG" AlternateText="Picture not found" Width="402px" CssClass="center-block" />
                <h3>תבנית מיילים</h3>
                <br />
       
            <asp:Button runat="server" 
                Text="מייל אישור כללי - במעבר לסטטוס &quot;שיבוץ הושלם&quot; נשלח לבית הספר ולמתנבות ששבוצו" 
                Width="100%" 
                OnClientClick=" myfunc1();return false;"
                CssClass="mybutton button2"/>
                <br />
                <label
                id="p1" 
                hidden="hidden"
                class="myText">
                היי , X <br />
                בתאריך X, תתקיים סדנא במיקום X  <br />
                פרטים נוספים ישלחו בהמשך <br />

                </label>

                 <asp:Button runat="server" 
                Text="בקשה למשוב מתנדבות "
                Width="100%" 
                OnClientClick=" myfunc2();return false;"
                CssClass="mybutton button2"/>
                <br />
                <label
                id="p2" 
                hidden="hidden"
                class="myText">
                היי , X <br />
                בקישור הבא נשמח אם תמלאי משוב עבור הסדנא X <br />
                <u> <b> קישור</b></u>  <br />
                </label>
                <asp:Button runat="server" 
                Text="מייל ביטול סדנא"
                Width="100%" 
                OnClientClick=" myfunc3();return false;"
                CssClass="mybutton button2"/>
                <br />
                <label
                id="p3" 
                hidden="hidden"
                class="myText">
                היי , X <br />
                הסדנא בתאריך X מבוטלת <br />
                </label>
                  <asp:Button runat="server" 
                Text="הכנות לקראת סדנא"
                Width="100%" 
                OnClientClick=" myfunc4();return false;"
                CssClass="mybutton button2"/>
                <br />
                <label
                id="p4" 
                hidden="hidden"
                class="myText">
                 X,<br />
                בבקשה מלאו את טופס ההכנה לסדנא <br />
                <br />
                לקראת סדנת מהממ"ט בתאריך ה-XXX, בין השעות XXX (תזכורת -המתנדבות צריכות להכנס לחדרי המחשבים חצי שעה לפני תחילת הסדנה), נשמח לקבל ממך מספר פרטים כהכנה לקראת הסדנה. <br />
                הוראות התקנת אימולטור ניתן לעקוב אחר ההוראות בלינק <b><u> הבא</u></b> (<b><u> לינק</u></b> זה מפורטת ההתקנה לווינדאוס). למייל זה מצורף מדריך המאפשר לבדוק אם ההתקנה הצליחה. <br />
                האם לכל התלמידות נפתח חשבון ג'ימייל (והן זוכרות את הסיסמה)? זה חשוב מאוד על מנת לא לעכב את הפעילות, בלי ג'ימייל אי אפשר להתחבר לתוכנה בה אנחנו משתמשות. אנא וודאו עם כל התלמידות שמגיעות שיש להן חשבון והן גם זוכרות את הסיסמה אליו. <br />
                טרם כל סדנה אנו מעבירות שאלון מקדים לתלמידות. אנא וודאו שהתלמידות עונות על השאלון הבא לפני הסדנה: <b><u> לינק</u></b> <br />
                 <br />
                 קבצים מצורפים: חומרים לסדנא, הוראות הפעלה אימולטור<br />
                <b><u>קישור </u></b> לטופס אישור הכנה<br />
                 <br />
                </label>
                 <asp:Button runat="server" 
                Text="ביצוע סדנא"
                Width="100%" 
                OnClientClick=" myfunc5();return false;"
                CssClass="mybutton button2"/>
                <br />
                <label
                id="p5" 
                hidden="hidden"
                class="myText">
                                                  שלום לכולן! <br />
                        ביום X הקרוב, ה-X מתקיימת סדנת מהממ"ט בבית ספרX.<br />
                        הסדנה מתחילה ב-X בבוקר, אנא הגיעו בשעה-X  להכין את הכל. <br />
 <br />
                        כתובת בי"ס: X <br />
                        חנייה: X<br />
                        מורה מלווה: X<br />
                        טלפון המורה : X<br />
                        שיחת סיכום עם תלמידות ממגמת טכ"מ: X<br />
 <br />
                        פרטי המתנדבות:<br />
                        * X<br />
                        * X<br />
                        * X<br />
 <br />
                        אחראית מהממ"ט: כרמית 0584125124<br />
 <br />
                        בהצלחה!<br />
                </label>
                <asp:Button runat="server" 
                Text="מייל משוב ממורה מלווה "
                Width="100%" 
                OnClientClick=" myfunc6();return false;"
                CssClass="mybutton button2"/>
                <br />
                <label
                id="p6" 
                hidden="hidden"
                class="myText">
                היי , X <br />
                        בקישור הבא נשמח אם תמלא/י משוב עבור הסדנא X <br />
                      <u> <b> קישור</b></u>  <br />
                </label>
          </div>
        </div>
         </form>
    <script>
        function myfunc1() {
            document.getElementById("p1").hidden = !document.getElementById("p1").hidden;
        };
        function myfunc2() {
            document.getElementById("p2").hidden = !document.getElementById("p2").hidden;
        };
        function myfunc3() {
            document.getElementById("p3").hidden = !document.getElementById("p3").hidden;
        };
        function myfunc4() {
            document.getElementById("p4").hidden = !document.getElementById("p4").hidden;
        };
        function myfunc5() {
            document.getElementById("p5").hidden = !document.getElementById("p5").hidden;
        };
        function myfunc6() {
            document.getElementById("p6").hidden = !document.getElementById("p6").hidden;
        };
    </script>
</body>

</html>

