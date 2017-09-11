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
                            <th scope="row">בקשות לסדנא</th>
                            <td><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות בשיבוץ בי"ס</th>
                            <td><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות בשיבוץ מתנדבות</th>
                            <td><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">מתדנבות שובצו</th>
                            <td colspan="2"><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות להכנה/אושרה הכנה</th>
                            <td colspan="2"><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות לביצוע</th>
                            <td colspan="2"><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">סדנאות למישוב</th>
                            <td colspan="2"><span class="badge">2</span></td>

                        </tr>
                        <tr>
                            <th scope="row">מתנדבות חדשות לאישור</th>
                            <td colspan="2"><span class="badge">2</span></td>

                        </tr>
                    </tbody>
                </table>
                <a class="btn btn-lg btn-primary" href="../workshop/workshopsview.aspx" role="button">כל הסדנאות  &raquo;</a>

            </div>




        </div>
    </form>

 

</body>
</html>
