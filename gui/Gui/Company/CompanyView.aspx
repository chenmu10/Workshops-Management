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
                <div class="col-md-4">
                    <div class="col-md-6">
                        <b>אזור:</b>
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListAreas" Width="175px">
                            <asp:ListItem>אזור</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:Button runat="server" ID="filter" class="btn btn-info" OnClick="filter_Click" Text="סינון" Style="margin-top: 20px;" />
                    </div>
                </div>
                <!-- Search-->
                <div class="col-md-8" style="margin-top: 20px;">
                    <div class="form-inline">
                        <asp:TextBox ID="NameInput" runat="server" type="text" class="form-control" placeholder="שם" Width="140px"> </asp:TextBox>
                        <asp:Button runat="server" ID="search" OnClick="search_Click" class="btn btn-info" Text="חיפוש" />
                    </div>
                    <br />
                </div>

                 <div class="col-md-4">
                <asp:Button runat="server" Visible="false" ID="expot" class="btn btn-info" Text="ייצא לאקסל" OnClick="btnExportExcel_Click" />
                <asp:Button runat="server" ID="clear" class="btn btn-info" OnClick="clear_Click" Text="ניקוי" />
            </div>
            </div>
            <%--end row--%>
           
            <br />
            <br />
            <asp:Label runat="server" ID="Sum"></asp:Label>
            <br />
            <!-- Table-->
            <asp:Table ID="companyTable" runat="server" CssClass="table table-hover">
                <asp:TableRow>
                    <asp:TableCell Font-Bold="true">שם החברה</asp:TableCell>
                    <asp:TableCell Font-Bold="true">כתובת</asp:TableCell>
                    <asp:TableCell Font-Bold="true">
                        <asp:LinkButton ForeColor="Black" runat="server" ID="LinkButton1">אזור 
                            <span class="glyphicon glyphicon-sort"></span>
                        </asp:LinkButton>
                    </asp:TableCell>
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
