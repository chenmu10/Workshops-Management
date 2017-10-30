<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolEditInfo.aspx.cs" Inherits="gui.Gui.SchoolEditInfo" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>פרטי בית ספר</title>

</head>
<body>

    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />


        <div class="container">
            <h2>צפייה בפרטי בית ספר</h2>
            <hr />

            <div class="row">
                <!-- column 1-->
                <div class="col-md-4">
                    <fieldset id="schoolDetails" runat="server">
                        <legend>פרטי מוסד חינוכי</legend>

                          <label class="control-label" for="schoolid">ID:</label>
                        <asp:TextBox runat="server" Text="טקסט" ID="schoolidText" Width="100%"></asp:TextBox>
                        <br />
                        <label class="control-label" for="schoolSymbol">סמל מוסד:</label>
                        <asp:TextBox runat="server" Text="טקסט" ID="schoolSymbolText" Width="100%"></asp:TextBox>
                        <br />

                        <label class="control-label" for="schoolName">שם בי"ס :</label>
                        <asp:TextBox runat="server" Text="טקסט" ID="schoolNameText" Width="100%"></asp:TextBox>

                        <br />
                        <label class="control-label" for="schooladdress">כתובת: </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="schooladdressText" Width="100%"></asp:TextBox>

                        <br />
                        <label class="control-label" for="schoolCity">עיר: </label>  <asp:TextBox runat="server"  Text="טקסט" ID="schoolCityText" Width="100%" ></asp:TextBox>                      

                        <br />
                        <label class="control-label" for="schoolArea">אזור: </label>
                        <asp:Label runat="server" Text="טקסט" ID="schoolArea" Width="100%"></asp:Label>

                        <br />
                        <label class="control-label" for="parking">חנייה: </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="parkingText" Width="100%"></asp:TextBox>

                        <br />
                        <label class="control-label" for="computercontactname">שם אחראי/ת מחשבים: </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="computercontactText" Width="100%"></asp:TextBox>

                        <br />
                        <label class="control-label" for="computercontactphone">טלפון אחראי/ת מחשבים: </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="computercontactphoneText" Width="100%"></asp:TextBox>

                        <br />
                        <label class="control-label" for="doneWorkshops">מספר סדנאות שהתקיימו: </label>
                        <asp:Label runat="server" Text="טקסט" ID="doneWorkshops"><span class="label label-primary">5</span></asp:Label>
                    </fieldset>
                </div>

                <!-- column 2-->
                <div class="col-md-4">
                    <fieldset id="ContactDetails" runat="server">
                        <legend>איש/ת קשר/רכז/ת עמ"ט</legend>
                        <label class="control-label" for="contactname">שם : </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="contactnameText" Width="100%"></asp:TextBox>
                        <br />
                        <label class="control-label" for="contactphone">טלפון : </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="contactphoneText" Width="100%"></asp:TextBox>

                        <br />
                        <label class="control-label" for="contactemail">כתובת אימייל : </label>
                        <asp:TextBox runat="server" Text="טקסט" ID="contactemailText" Width="100%"></asp:TextBox>

                        <br />

                    </fieldset>
                </div>


            </div>
         <div class="row">
            <a href="#" onclick="history.go(-1)" class="btn btn-default">חזור</a>
            <asp:Button runat="server" ID="UpdateSchoolBtn" OnClick="UpdateSchool_Click"  class="btn btn-default" Text="עדכני" Visible="false"/>
            
         </div>
                <br />
                <br />
        </div>
    </form>

</body>
</html>
