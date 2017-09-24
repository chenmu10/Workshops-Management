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

                         <label class="control-label" for="id">ID:</label>
                        <asp:Label runat="server" ID="id"></asp:Label>
                        <br />
                        <label class="control-label" for="schoolSymbol">סמל מוסד:</label>
                        <asp:Label runat="server" Text="טקסט" ID="schoolSymbol"></asp:Label>
                        <br />

                        <label class="control-label" for="schoolName">שם בי"ס :</label>
                        <asp:Label runat="server" Text="טקסט" ID="schoolName"></asp:Label>

                        <br />
                        <label class="control-label" for="schooladdress">כתובת: </label>
                        <asp:Label runat="server" Text="טקסט" ID="schooladdress"></asp:Label>

                        <br />
                        <label class="control-label" for="schoolCity">עיר: </label>
                        <asp:Label runat="server" Text="טקסט" ID="schoolCity"></asp:Label>

                        <br />
                        <label class="control-label" for="schoolArea">אזור: </label>
                        <asp:Label runat="server" Text="טקסט" ID="schoolArea"></asp:Label>

                        <br />
                        <label class="control-label" for="parking">חנייה: </label>
                        <asp:Label runat="server" Text="טקסט" ID="parking"></asp:Label>

                        <br />
                        <label class="control-label" for="computercontactname">שם אחראי/ת מחשבים: </label>
                        <asp:Label runat="server" Text="טקסט" ID="computercontact"></asp:Label>

                        <br />
                        <label class="control-label" for="computercontactphone">טלפון אחראי/ת מחשבים: </label>
                        <asp:Label runat="server" Text="טקסט" ID="computercontactphone"></asp:Label>

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
                        <asp:Label runat="server" Text="טקסט" ID="contactname"></asp:Label>
                        <br />
                        <label class="control-label" for="contactphone">טלפון : </label>
                        <asp:Label runat="server" Text="טקסט" ID="contactphone"></asp:Label>

                        <br />
                        <label class="control-label" for="contactemail">כתובת אימייל : </label>
                        <asp:Label runat="server" Text="טקסט" ID="contactemail"></asp:Label>

                        <br />

                    </fieldset>
                </div>


            </div>
            <br />
            <a href="#" onclick="history.go(-1)" class="btn btn-default">חזור</a>
        </div>
    </form>

</body>
</html>
