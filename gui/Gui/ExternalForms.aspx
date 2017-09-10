<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExternalForms.aspx.cs" Inherits="gui.Gui.ExternalForms" %>

<%@ Register Src="nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MMT Project </title>
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
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
                        <a href="../volunteer/NewVolunteerForm.aspx" class="list-group-item">
                            <h4 class="list-group-item-heading">רישום מתנדבת</h4>
                            <p class="list-group-item-text">באמת מהממ"ט יהיה קישור שיוביל לדף זה. נרשמת חדשה תהיה בסטטוס "ללא הכשרה"</p>
                        </a>
                        <a href="#" class="list-group-item active">
                            <h4 class="list-group-item-heading">בקשת בית ספר לקיום סדנא</h4>
                            <p class="list-group-item-text">Bootstrap is a powerful front-end framework for faster and easier web development. It is a collection of HTML and CSS based design template.</p>
                        </a>
                        <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading">טופס הכנה לסדנא עבור בית ספר</h4>
                            <p class="list-group-item-text">CSS stands for Cascading Style Sheet. CSS allows you to specify various style properties for a given HTML element such as colors, backgrounds, fonts etc.</p>
                        </a>
                         <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading">משוב לסדנא (מתנדבת)</h4>
                            <p class="list-group-item-text">CSS stands for Cascading Style Sheet. CSS allows you to specify various style properties for a given HTML element such as colors, backgrounds, fonts etc.</p>
                        </a>
                         <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading"> משוב לסדנא (מורה)</h4>
                            <p class="list-group-item-text">CSS stands for Cascading Style Sheet. CSS allows you to specify various style properties for a given HTML element such as colors, backgrounds, fonts etc.</p>
                        </a>
                        <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading"> שיבוץ מתנדבות לסדנא</h4>
                            <p class="list-group-item-text">CSS stands for Cascading Style Sheet. CSS allows you to specify various style properties for a given HTML element such as colors, backgrounds, fonts etc.</p>
                        </a>
                        <a href="#" class="list-group-item">
                            <h4 class="list-group-item-heading"> שיבוץ בית ספר לסדנא בתעשייה</h4>
                            <p class="list-group-item-text">CSS stands for Cascading Style Sheet. CSS allows you to specify various style properties for a given HTML element such as colors, backgrounds, fonts etc.</p>
                        </a>
                    </div>




             


            </div>
        </div>

    </form>

</body>
</html>
