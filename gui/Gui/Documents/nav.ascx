<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nav.ascx.cs" Inherits="gui.Gui.Documents.nav" %>

<link href="../../css/bootstrap.css" rel="stylesheet" />
<link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
<script src="../../js/jquery-3.0.0.min.js"></script>
<script src="../../js/bootstrap.min.js"></script>
<style>
    .navbar-default .navbar-nav > li > a {
        font-size:18px;
    }
.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    text-align: left;
}

.dropdown-content a:hover {background-color: #f1f1f1}

.dropdown:hover .dropdown-content {
    display: block;
}
</style>


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
            <asp:LinkButton runat="server"  class="navbar-brand" href="../documents/Manager_Home.aspx">MMT</asp:LinkButton>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          
           <ul class="nav navbar-nav">

              <li  class="dropdown">
                <asp:Label runat="server" ID="ManagerLink1"  Cssclass="dropbtn">טבלאות תשתית</asp:Label>
                <div class="dropdown-content">
                <asp:LinkButton runat="server" ID="LinkButton1" href="../volunteer/VolunteerView.aspx">מתנדבות</asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButton2" href="../company/CompanyView.aspx">חברות</asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButton3" href="../school/SchoolsView.aspx">בתי ספר</asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButton4" href="../workshop/WorkshopsView.aspx">סדנאות</asp:LinkButton>
                </div>
              </li>
            </ul>

            <ul class="nav navbar-nav">
       
                <li><asp:LinkButton runat="server" ID="volunter" href="../volunteer/VolunteerView.aspx">מתנדבות</asp:LinkButton></li>
                <li><asp:LinkButton runat="server" ID="company" href="../company/CompanyView.aspx">חברות</asp:LinkButton></li>
                <li><asp:LinkButton runat="server" ID="school" href="../school/SchoolsView.aspx">בתי ספר</asp:LinkButton></li>
                <li><asp:LinkButton runat="server" ID="workshop" href="../workshop/WorkshopsView.aspx">סדנאות</asp:LinkButton></li>
            </ul>
            <ul class="nav navbar-nav navbar-right flip">
               <li><asp:LinkButton runat="server" ID="forms" href="../documents/ExternalForms.aspx">טפסים</asp:LinkButton></li>
				<li><asp:LinkButton runat="server" ID="shobech" href="../documents/AssignForms.aspx">שיבוצים</asp:LinkButton></li>
				<li><a href="../school/NewSchoolForm.aspx">דוחות</a></li>
				<li><asp:LinkButton runat="server" ID="manager" href="../Documents/LoginManager.aspx">ניהול<span class="sr-only"></span></asp:LinkButton></li>
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

