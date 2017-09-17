<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExternalForms.aspx.cs" Inherits="gui.Gui.ExternalForms" %>

<%@ Register Src="nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>MMT Project </title>

</head>

<body>
    <br />
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />


        <div class="container">
            <h2>טפסים חיצוניים</h2>
            <hr />
            <div class="row">

                <div class="list-group">
                    <a href="../volunteer/NewVolunteerForm.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">רישום מתנדבת</h4>
                        <p class="list-group-item-text">באתר מהממ"ט יהיה קישור שיוביל לדף זה. נרשמת חדשה תהיה בסטטוס "ללא הכשרה"</p>
                    </a>
                    <a href="../workshop/newSchoolWorkshop.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">טופס בקשת בית ספר לקיום סדנא</h4>
                        <p class="list-group-item-text">באתר יהיה קישור לדף זה. הוספת סדנא בסטטוס "לבדיקה" עבור בית ספר חדש או קיים</p>
                    </a>
                    <a href="../workshop/workshopPrepareform.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">טופס הכנה לסדנא עבור בית ספר</h4>
                        <p class="list-group-item-text">עבור כל בית ספר לאחר סיום שיבוץ נשלח אימייל עם הוראות הכנה. ניתן לראות את הטופס גם בעמוד ניהול סדנא.</p>
                    </a>
                    <a href="feedbackVolunteer.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">משוב לסדנא (מתנדבת)</h4>
                        <p class="list-group-item-text">לאחר סדנא כל מתנדבת מקבלת טופס מילוי משוב.</p>
                    </a>
                    <a href="feedbackTeacher.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">משוב לסדנא (מורה)</h4>
                        <p class="list-group-item-text">לאחר סדנא בבית ספר, המורה מקבלת טופס מילוי משוב.</p>
                    </a>
                    <a href="../Volunteer/volunteerAssignWorkshops.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">שיבוץ מתנדבות לסדנא</h4>
                        <p class="list-group-item-text">קישור לעמוד השיבוץ נשלח אוטומטית למתנדבות הנמצאות באותו אזור של הסדנא.</p>
                    </a>
                    <a href="../school/schoolSelectWorkshopFromIndustry.aspx" class="list-group-item" target="_blank">
                        <h4 class="list-group-item-heading">שיבוץ בית ספר לסדנה בחברה</h4>
                        <p class="list-group-item-text">קישור לעמוד השיבוץ נשלח אוטומטית לכל בתי הספר במאגר שנמצאים באזור הסדנא.</p>
                    </a>
                </div>

            </div>
        </div>

    </form>

   <script>   $(" .navbar a:contains('טפסים')").parent().addClass('active');</script>
</body>
</html>
