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
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListStatus" Width="150px">
                            <asp:ListItem>סטטוס</asp:ListItem>
                            <asp:ListItem>לשיבוץ מתנדבות</asp:ListItem>
                            <asp:ListItem>לשיבוץ בית ספר</asp:ListItem>
                            <asp:ListItem>מתנדבות שובצו</asp:ListItem>
                            <asp:ListItem>בית ספר שובץ</asp:ListItem>
                            <asp:ListItem>לבדיקת תאריכים</asp:ListItem>
                            <asp:ListItem>להכנה</asp:ListItem>
                            <asp:ListItem>לביצוע</asp:ListItem>
                            <asp:ListItem>למישוב</asp:ListItem>
                            <asp:ListItem>סגור</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListType" Width="110px">
                            <asp:ListItem>סוג</asp:ListItem>
                            <asp:ListItem>בתעשייה</asp:ListItem>
                            <asp:ListItem>בבתי ספר</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListAreas" Width="150px">
                            <asp:ListItem>אזור</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListSchool" Width="120px">
                            <asp:ListItem>שם בית ספר</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListCompany" Width="120px">
                            <asp:ListItem>שם חברה</asp:ListItem>
                        </asp:DropDownList>

                        מתאריך:
                        <asp:TextBox class="form-control" ID="from_Date" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
                        עד תאריך:
                        <asp:TextBox class="form-control" ID="to_Date" runat="server" TextMode="Date" Width="150px"></asp:TextBox>

                        <asp:Button runat="server" ID="filter" class="btn btn-info" OnClick="Filter_Click" Text="סינון" />
                    </div>

                
                <br />
                        
                <asp:Button runat="server" Visible="false" ID="expot" class="btn btn-info" Text="ייצא לאקסל" OnClick="btnExportExcel_Click" />
                <asp:Button runat="server" ID="Clear" class="btn btn-info" Text="ניקוי" OnClick="Clear_Click" />

                <br /> <br />
                <asp:Label runat="server" ID="Sum"></asp:Label>
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




