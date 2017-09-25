<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager_Home.aspx.cs" Inherits="gui.Gui.Manager_Home" %>


<%@ Register Src="nav.ascx" TagName="nav" TagPrefix="uc1" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>MMT Project </title>
   <style>
       /*body{
           background-image: url("../../../Content/photo_bg.jpg");
           background-size: cover;
       }*/
      

   </style>
</head>

<body>

    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />

      
        <div class="container">
            <br />
          <asp:Image ID="Image2" runat="server" Height="107px" ImageUrl="../../../Content/homepic.PNG" AlternateText="Picture not found" Width="208px" />
            <br />
            <asp:Label runat="server" ID="user"></asp:Label>
            <br />
            <%--<div class="jumbotron" style="background-color:rgba(255, 255, 255,0.8); width:75%; height:80%; margin:auto;">--%>
            <div class="jumbotron">
                <h2>מעקב פעילות</h2>
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
                            <td> <asp:Label runat="server" ID="newSchoolWorkshops" class="badge"> </asp:Label></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות בחברות לשיבוץ בתי ספר</th>
                            <td> <asp:Label runat="server" ID="newCompanyWorkshops" class="badge"> </asp:Label></td>
                           
                        </tr>
                         <tr>
                            <th scope="row">סדנאות בחברות בי"ס שובץ</th>
                            <td><asp:Label runat="server" ID="schoolAssigned" class="badge"> </asp:Label></td>
                


                        </tr>
                        <tr>
                            <th scope="row">סדנאות לשיבוץ מתנדבות</th>
                            <td><asp:Label runat="server" ID="assignVolunteers" class="badge"> </asp:Label></td>
                


                        </tr>
                        <tr>
                            <th scope="row">סדנאות בבי"ס בשיבוץ הושלם להכנה</th>
                            <td colspan="2"><asp:Label runat="server" ID="prepare" class="badge"> </asp:Label></td>

                        </tr>
                       
                        <tr>
                            <th scope="row">סדנאות לביצוע</th>
                              <td colspan="2"><asp:Label runat="server" ID="execute" class="badge"> </asp:Label></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות למישוב</th>
                              <td colspan="2"><asp:Label runat="server" ID="feedback" class="badge"> </asp:Label></td>

                        </tr>
                         <tr>
                            <th scope="row">סדנאות סגורות</th>
                            <td colspan="2"><asp:Label runat="server" ID="closed" class="badge"> </asp:Label></td>

                        </tr>
                        <tr>
                            <th scope="row">מתנדבות חדשות לאישור</th>
                            <td colspan="2"><asp:Label runat="server" ID="newVolunteers" class="badge"> </asp:Label></td>

                        </tr>
                    </tbody>
                </table>
                <a class="btn btn-lg btn-primary" href="../workshop/workshopsview.aspx" role="button">כל הסדנאות  &raquo;</a>

            </div>
            <br />
            <br />



        </div>
    </form>

 

</body>
</html>
