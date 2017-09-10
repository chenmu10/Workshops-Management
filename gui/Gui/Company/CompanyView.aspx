<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyView.aspx.cs" Inherits="gui.Gui.CompanyView" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />

        <div class="container">
            <h2>חברות</h2>
            <hr />
            <p>
                <asp:Button runat="server" ID="approve" class="btn btn-link" OnClick="newComapnyWorkshopBtn_Click" Text="יצירת חברה חדשה" />
            </p>
            <div class="row">

                <!-- Filter -->
                <div class="col-md-8">
                    <div class="form-inline">
                        <h3><span class="glyphicon glyphicon-filter"></span>סינון</h3>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListStatus">
                            <asp:ListItem>סטטוס</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListAreas">
                            <asp:ListItem>אזור פעילות</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListTraining">
                            <asp:ListItem>אזור הכשרה</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Button runat="server" ID="filter" class="btn btn-info" Text="סינון" />

                    </div>
                </div>
                <!-- Search-->
                <div class="col-md-4">
                    <div class="form-inline">
                        <h3><span class="glyphicon glyphicon-search"></span>חיפוש</h3>
                        <asp:TextBox ID="name" runat="server" type="text" class="form-control" placeholder="שם" Width="100px"> </asp:TextBox>
                        או 
                        <asp:TextBox ID="email" runat="server" type="text" class="form-control" placeholder="אימייל" Width="100px"> </asp:TextBox>

                        <asp:Button runat="server" ID="search" class="btn btn-info" Text="חיפוש" />
                    </div>
                    <br />
                </div>

            </div>
            <%--end row--%>
            <br />
            <!-- Table-->
            <asp:Table ID="companyTable" runat="server" CssClass="table table-hover">
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true">#</asp:TableCell>
                    <asp:TableCell Font-Bold="true">שם החברה</asp:TableCell>
                    <asp:TableCell Font-Bold="true">כתובת</asp:TableCell>
                    <asp:TableCell Font-Bold="true"> איש קשר</asp:TableCell>
                    <asp:TableCell Font-Bold="true"> טלפון</asp:TableCell>
                    <asp:TableCell Font-Bold="true"> אימייל </asp:TableCell>
                    <asp:TableCell Font-Bold="true">פעולות</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
    <script>   $(" .navbar a:contains('חברות')").parent().addClass('active');</script>
</body>
</html>
