<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_Home.aspx.cs" Inherits="gui.Gui.Manager_Home" %>


<%@ Register Src="nav.ascx" TagName="nav" TagPrefix="uc1" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title>MMT Project </title>
   
</head>

<body>

    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />

      
        <div class="container">
            <br />
          <asp:Image ID="Image2" runat="server" Height="107px" ImageUrl="~/EmailMessages/homepic.PNG" Width="208px" />
            <div class="jumbotron">
                <h3>מעקב פעילות</h3>
                <br />

                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>סוג</th>
                            <th>כמות</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">בקשות בתי ספר לקיום סדנא</th>
                            <td> <asp:Label runat="server" ID="newSchoolWorkshops"><span class="badge">5</span></asp:Label></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות בחברות לשיבוץ בתי ספר</th>
                            <td> <asp:Label runat="server" ID="newCompanyWorkshops"><span class="badge">5</span></asp:Label></td>
                           
                        </tr>
                        <tr>
                            <th scope="row">סדנאות לשיבוץ מתנדבות</th>
                            <td><asp:Label runat="server" ID="assignVolunteers"><span class="badge">5</span></asp:Label></td>
                


                        </tr>
                        <tr>
                            <th scope="row">סדנאות בשיבוץ הושלם להכנה</th>
                            <td colspan="2"><asp:Label runat="server" ID="prepare"><span class="badge">5</span></asp:Label></td>

                        </tr>
                       
                        <tr>
                            <th scope="row">סדנאות לביצוע</th>
                              <td colspan="2"><asp:Label runat="server" ID="execute"><span class="badge">5</span></asp:Label></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות למישוב</th>
                              <td colspan="2"><asp:Label runat="server" ID="feedback"><span class="badge">5</span></asp:Label></td>

                        </tr>
                         <tr>
                            <th scope="row">סדנאות סגורות</th>
                            <td colspan="2"><asp:Label runat="server" ID="closed"><span class="badge">5</span></asp:Label></td>

                        </tr>
                        <tr>
                            <th scope="row">מתנדבות חדשות לאישור</th>
                            <td colspan="2"><asp:Label runat="server" ID="newVolunteers"><span class="badge">5</span></asp:Label></td>

                        </tr>
                    </tbody>
                </table>
                <a class="btn btn-lg btn-primary" href="../workshop/workshopsview.aspx" role="button">כל הסדנאות  &raquo;</a>

            </div>




        </div>
    </form>

 

</body>
</html>
