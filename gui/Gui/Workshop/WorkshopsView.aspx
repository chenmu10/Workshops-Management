<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkshopsView.aspx.cs" Inherits="gui.Gui.Workshop.WorkshopsView" %>


<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
   
</head>
<body>

    <form id="form1" runat="server">
        <uc1:nav ID="nav1" runat="server" />
        <br />

        <div class="container">
            <h2>סדנאות</h2>
            <hr />
            <p>
                <asp:Button class="btn btn-link" runat="server" ID="NewComapnyWorkshopBtn" Text="סדנא חדשה בחברה" OnClick="NewComapnyWorkshop_Click" />
            </p>
            <div class="row">
                <div class="col-md-12">
                    <!-- Filter -->

                    <div class="form-inline">
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListStatus">
                            <asp:ListItem>סטטוס</asp:ListItem>
                            <asp:ListItem>לבחירת תאריכים</asp:ListItem>
                            <asp:ListItem>לשיבוץ מתנדבות</asp:ListItem>
                            <asp:ListItem>מתנדבות שובצו</asp:ListItem>
                            <asp:ListItem>להכנה</asp:ListItem>
                             <asp:ListItem>לביצוע</asp:ListItem>
                             <asp:ListItem>למישוב</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListType">
                            <asp:ListItem>סוג</asp:ListItem>
                              <asp:ListItem>בתעשייה</asp:ListItem>
                              <asp:ListItem>בבתי ספר</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListAreas">
                            <asp:ListItem>אזור</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListSchool">
                            <asp:ListItem>בי"ס</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListCompany">
                            <asp:ListItem>חברה</asp:ListItem>
                        </asp:DropDownList>

                        מתאריך:
                        <asp:TextBox class="form-control" ID="from_Date" runat="server" TextMode="Date"></asp:TextBox>
                        עד תאריך:
                        <asp:TextBox class="form-control" ID="to_Date" runat="server" TextMode="Date"></asp:TextBox>
       
                        <asp:Button runat="server" ID="filter" class="btn btn-info" OnClick="Filter_Click" Text="סינון" />
                    </div>

                </div>



                <br />
                <br />
                <br />
                <%--Table--%>
                <asp:Table ID="workshopTable" runat="server" CssClass="table table-hover">
                    <asp:TableRow>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">#</asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">סוג</asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">סטטוס <span class="glyphicon glyphicon-sort"></span></asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">מועד</asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">בי"ס<span class="glyphicon glyphicon-sort"></span></asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">חברה</asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">מתנדבות משובצות</asp:TableCell>
                        <asp:TableCell Font-Bold="true" CssClass=" alnright">פעולות</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
    </form>
        <script>   $(" .navbar a:contains('סדנאות')").parent().addClass('active');</script>
</body>

</html>




