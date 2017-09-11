<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVolunteerInfo.aspx.cs" Inherits="gui.Gui.Volunteer.EditVolunteerInfo" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
            <div class="row">
                <div class="col-sm-6">

                    <div class="page-header">
                        <h3>פרטי מתנדבת 
                        </h3>
                    </div>
                    <br />
                     <!-- ID-->
                    <div>
                        <label class="control-label" for="email">מספר מזהה:</label>
                        <asp:TextBox class="form-control" runat="server" ID="id" type="number" Enabled="false" />
                    </div>
                    <br />
                     <!-- Status-->
                    <div>
                        <label class="control-label" for="email">סטטוס הכשרה:</label>
                        <asp:TextBox class="form-control" runat="server" ID="status" />
                    </div>
                    <br />
                      <!-- doneWorkshops-->
                    <div>
                        <label class="control-label" for="email">מספר סדנאות שביצעה:</label>
                        <asp:TextBox class="form-control" runat="server" ID="doneWorkshops" type="number" Enabled="false" />
                    </div>
                    <br />
                    <!-- Hebrew First & Last Name-->
                    <div>
                        <label class="control-label">שם בעברית:</label>
                        <br />

                        <asp:TextBox ID="Firstname" class="form-control"
                            type="text"
                            pattern="[\u0590-\u05FF''-'\s]{1,20}"
                            oninvalid="setCustomValidity('שם פרטי לא תקין, אנא נסי שם בעיברית')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="שם פרטי"
                            runat="server"></asp:TextBox>
                        <br />

                        <asp:TextBox ID="Lastname" class="form-control"
                            type="text"
                            pattern="[\u0590-\u05FF''-'\s]{1,20}"
                            oninvalid="setCustomValidity('שם משפחה לא תקין, אנא נסי שם בעיברית ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="שם משפחה"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!-- English First & Last Name-->
                    <div>
                        <label class="control-label">שם באנגלית:</label>
                        <asp:TextBox ID="Firstnameeng" class="form-control"
                            type="text"
                            pattern="[/^[a-z ,.'-]+$/i]{1,20}"
                            oninvalid="setCustomValidity('שם באנגלית בבקשה ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                             placeholder="first name"
                            runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="Lastnameeng" class="form-control"
                            type="text"
                            pattern="[/^[a-z ,.'-]+$/i]{1,20}"
                            oninvalid="setCustomValidity('שם באנגלית בבקשה ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="last name"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!-- Email-->
                    <div>
                        <label class="control-label" for="email">אימייל:</label>
                        <asp:TextBox class="form-control" runat="server" ID="Email" placeholder="name@email.com" type="email"   />
                    </div>
                    <br />
                    <!--Phone-->
                    <div>
                        <label class="control-label" for="phone">
                            טלפון: 
                        </label>
                        <asp:TextBox class="form-control" ID="Phone"
                            type="tel"
                            pattern="[0-9]{3}-[0-9]{7}"
                            oninvalid="setCustomValidity('05X-XXXXXXX  הכנסי את הטלפון לפי הפורמט')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="05X-XXXXXXX "
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!--Occupation-->
                    <div>
                        <label class="control-label" for="DropDownListOccupation">עיסוק: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListOccupation" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListOccupation"   runat="server">
                            <asp:ListItem Value="בחרי"></asp:ListItem>
                            <asp:ListItem Value="סטודנטית"></asp:ListItem>
                            <asp:ListItem Value="אקדמאית"></asp:ListItem>
                            <asp:ListItem Value="עובדת בתעשייה"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <br />
                    <!--Employer-->
                    <div>
                        <label class="control-label" for="employer">מעסיק או מוסד אקדמי נוכחי: </label>
                        <asp:TextBox class="form-control" ID="Employer"
                            type="text"
                            pattern="([A-z\u0590-\u05FF0-9\s]){2,}"
                            oninvalid="setCustomValidity('קלט לא תקין')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                              runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!--Reference-->
                    <div>
                        <label class="control-label" for="DropDownListReference">איך הגעת אלינו: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListReference" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListReference" runat="server"  >
                            <asp:ListItem Value="בחרי"></asp:ListItem>
                            <asp:ListItem Value="פייסבוק"></asp:ListItem>
                            <asp:ListItem Value="מכרים"></asp:ListItem>
                            <asp:ListItem Value="עבודה"></asp:ListItem>
                            <asp:ListItem Value="אחר"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <div>
                            <asp:Label for="otherRef" runat="server">פרטי אם סימנת "אחר":</asp:Label>
                            <asp:TextBox class="form-control" ID="otherRef"
                                type="text"
                                pattern="([A-z\u0590-\u05FF0-9\s]){2,}"
                                oninvalid="setCustomValidity('שדה חובה')"
                                onchange="try{setCustomValidity('')}catch(e){}"
                                runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <br />


                    <!--ListAreas-->
                    <div>
                        <label class="control-label" for="CheckBoxListAreas">אזור פעילות מועדף: </label>
                        <!--AreaErrorMsg-->
                        <asp:Label ID="AreaErrorMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxListAreas" runat="server"  ></asp:CheckBoxList>
                    </div>
                    <br />

                    <!--ListTraining-->
                    <div>
                        <label class="control-label" for="DropDownListTraining">אזור מועדף להכשרה:</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListTraining" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListTraining" runat="server"  >
                            <asp:ListItem Value="0" Text="בחרי"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <br />


                    <asp:Button ID="send" class="btn btn-success" runat="server" Text="שליחה" />


                </div>

            </div>

        </div>

    </form>
</body>
</html>
