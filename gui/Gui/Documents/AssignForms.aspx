<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignForms.aspx.cs" Inherits="gui.Gui.AssignForms" %>

<%@ Register Src="nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>שיבוצים </title>

</head>

<body>
    <br />
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />


        <div class="container">
            <h2>טפסי שיבוץ שנשלחים במייל</h2>
            <hr />
            <div class="row">

                <div class="list-group">
                   
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
</body>
</html>
