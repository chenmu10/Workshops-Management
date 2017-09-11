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
            <p>
                <asp:Button runat="server" id="approve" class="btn btn-link" OnClick="Approve_Click" text="אישור מתנדבות חדשות"/>
               
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
                        
                        <asp:Button runat="server" id="filter" class="btn btn-info" OnClick="Filter_Click" text="סינון"/>

                    </div>
                </div>
                <!-- Search-->
                <div class="col-md-4">
                    <div class="form-inline">
                        <h3><span class="glyphicon glyphicon-search"></span>חיפוש</h3>
                        <asp:TextBox ID="nameText" runat="server" type="text" class="form-control" placeholder="שם" Width="100px"> </asp:TextBox>
                        או 
                        <asp:TextBox ID="emailText" runat="server" type="text" class="form-control" placeholder="אימייל" Width="100px"> </asp:TextBox>
                     
                        <asp:Button runat="server" id="search" class="btn btn-info" OnClick="Search_Click" text="חיפוש"/>
                    </div>
                    <br />
                </div>

            </div>
            <%--end row--%>
            <br />
            <!-- Table-->
            <asp:Table ID="volunteerTable" runat="server" CssClass="table table-hover">
                <asp:TableRow>
                    <asp:TableCell><asp:LinkButton OnClick="NameSort" ForeColor="Black" runat="server" ID="NameSortBtn">שם  <span class="glyphicon glyphicon-sort"></span></asp:LinkButton></asp:TableCell>
                    <asp:TableCell ><asp:LinkButton OnClick="StatusSort" ForeColor="Black" runat="server" ID="LinkButton1">סטטוס  <span class="glyphicon glyphicon-sort"></span></asp:LinkButton></asp:TableCell>
                    <asp:TableCell ><asp:LinkButton OnClick="OccupationSort" ForeColor="Black" runat="server" ID="LinkButton2">עיסוק  <span class="glyphicon glyphicon-sort"></span></asp:LinkButton></asp:TableCell>
                    <asp:TableCell Font-Bold="true">אימייל</asp:TableCell>
                    <asp:TableCell Font-Bold="true">טלפון</asp:TableCell>
                    <asp:TableCell Font-Bold="true">איזור פעילות</asp:TableCell>
                    <asp:TableCell Font-Bold="true">איזור הכשרה</asp:TableCell>
                    <asp:TableCell Font-Bold="true">סדנאות שהועברו <span class="glyphicon glyphicon-sort"></span></asp:TableCell>
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
