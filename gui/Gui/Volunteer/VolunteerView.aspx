<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerView.aspx.cs" Inherits="gui.Gui.VolunteerView" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Volunteers Table</title>

</head>
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />
        <div class="container">
            <h2>מתנדבות</h2>
            <hr />
            <p>
                <asp:Button runat="server" ID="approve" Visible="false" class="btn btn-link" OnClick="Approve_Click" Text="אישור מתנדבות חדשות" />

            </p>
            <div class="row">

                <!-- Filter -->
                <div class="col-md-8">
                    <h3><span class="glyphicon glyphicon-filter"></span>סינון</h3>
                    <div class="col-md-3">
                        <b>סטטוס:</b>
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListStatus" Width="150px">
                            <asp:ListItem>סטטוס</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <b>אזור פעילות:</b>
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListAreas" Width="150px">
                            <asp:ListItem>אזור פעילות</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <b>אזור הכשרה:</b>
                        <asp:DropDownList class="form-control" runat="server" ID="DropDownListTraining" Width="150px">
                            <asp:ListItem>אזור הכשרה</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div class="col-md-3">
                        <asp:Button runat="server" ID="filter" class="btn btn-info" OnClick="Filter_Click" Text="סינון" Style="margin-top: 20px;" />
                    </div>

                </div>
                <!-- Search-->
                <div class="col-md-4">
                      <h3><span class="glyphicon glyphicon-search"></span>חיפוש</h3>
                    <div class="form-inline" Style="margin-top: 30px;">
                      
                        <asp:TextBox ID="nameText" runat="server" type="text" class="form-control" placeholder="שם" Width="100px"> </asp:TextBox>
                        או 
                        <asp:TextBox ID="emailText" runat="server" type="text" class="form-control" placeholder="אימייל" Width="100px"> </asp:TextBox>

                        <asp:Button runat="server" ID="search" class="btn btn-info" OnClick="Search_Click" Text="חיפוש" />
                    </div>
                    <br />
                </div>

            </div>
            <%--end row--%>
            <div class="row" style="margin-right: 15px;">
                <asp:Button runat="server" Visible="false" ID="expot" class="btn btn-info" Text="ייצא לאקסל" OnClick="btnExportExcel_Click" />
                <asp:LinkButton runat="server" ID="clear" class="btn btn-info" href="VolunteerView.aspx" Text="ניקוי" />
            </div>
            <br />
            <asp:Label runat="server" ID="Sum"></asp:Label>
            <br />
            <!-- Table-->
            <asp:Table ID="volunteerTable" runat="server" CssClass="table table-hover">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:LinkButton OnClick="NameSort" ForeColor="Black" runat="server" ID="NameSortBtn">שם  <span class="glyphicon glyphicon-sort"></span></asp:LinkButton></asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton OnClick="StatusSort" ForeColor="Black" runat="server" ID="LinkButton1">סטטוס  <span class="glyphicon glyphicon-sort"></span></asp:LinkButton></asp:TableCell>
                    <asp:TableCell Font-Bold="true">עיסוק </asp:TableCell>
                    <asp:TableCell Font-Bold="true">אימייל</asp:TableCell>
                    <asp:TableCell Font-Bold="true">טלפון</asp:TableCell>
                    <asp:TableCell Font-Bold="true">איזור פעילות</asp:TableCell>
                    <asp:TableCell Font-Bold="true">איזור הכשרה</asp:TableCell>
                    <asp:TableCell Font-Bold="true">סדנאות שהועברו </asp:TableCell>
                    <asp:TableCell Font-Bold="true">צפייה</asp:TableCell>
                </asp:TableRow>

            </asp:Table>

        </div>

        <br />
        <br />
    </form>
    <script>   $(" .navbar a:contains('מתנדבות')").parent().addClass('active');</script>
</body>
</html>
