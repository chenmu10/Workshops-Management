<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nav.ascx.cs" Inherits="gui.Gui.Documents.nav" %>

<link href="../../css/bootstrap.css" rel="stylesheet" />
<link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
<script src="../../js/jquery-3.0.0.min.js"></script>
<script src="../../js/bootstrap.min.js"></script>
<style>
    .navbar-default .navbar-nav > li > a {
        font-size:18px;
    }
  
}
</style>
<!--Img -->
<%--<div>
    <asp:Image ID="Image2" runat="server" Height="107px" ImageUrl="~/Contact/homepic.PNG" Width="208px" />
</div>--%>
<!--Menu -->

<!-- Fixed navbar -->
<nav class="navbar navbar-default navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="../documents/Manager_Home.aspx">MMT</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li><a href="../volunteer/VolunteerView.aspx">מתנדבות</a></li>
                <li><a href="../company/CompanyView.aspx">חברות</a></li>
                <li><a href="../school/SchoolsView.aspx">בתי ספר</a></li>
                <li><a href="../workshop/WorkshopsView.aspx">סדנאות</a></li>
            </ul>
            <ul class="nav navbar-nav navbar-right flip">
               <li><a href="../documents/ExternalForms.aspx">טפסים</a></li>
				<li><a href="../documents/AssignForms.aspx">שיבוצים</a></li>
				<%--<li><a href="reports.html">דוחות</a></li>--%>
				<li><a href="../Documents/LoginManager.aspx">ניהול<span class="sr-only"></span></a></li>
            </ul>
        </div>
        <!--/.nav-collapse -->
    </div>
</nav>
<br /><br />

<script>
    $(".nav a").on("mouseover", function () {
        $(".nav").find(".active").removeClass("active");
        $(this).parent().addClass("active");
    });
</script>

