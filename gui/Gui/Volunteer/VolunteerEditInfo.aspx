<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerEditInfo.aspx.cs" Inherits="gui.Gui.VolunteerEditInfo" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>פרטי מתנדבת</title>

</head>
<body>

    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />
        <br />


        <div class="container" style="padding-bottom:50px">
            <h2> פרטים אישיים של מתנדבת</h2>
              <hr />

                     <!-- Automatic-->
                    <label class="control-label" for="doneWorkshops">השתתפות בסדנאות: </label>
                    <asp:Label runat="server" Text="טקסט" ID="doneWorkshops" Font-Size="Small" class="label label-primary"></asp:Label>
                    <br />
                      <label class="control-label" for="doneWorkshops">סטטוס: </label>
                    <asp:Label runat="server" Text="טקסט" Font-Size="Small" class="label label-info" ID="Status"></asp:Label>
                    <!-- Hebrew First & Last Name-->
            <div class="row">
                <div class="col-md-4">
                   
                  
                    <div>
                        <label class="control-label">שם בעברית:</label>
                        <br />

                        <asp:TextBox ID="Firstname" class="form-control"
                            type="text"
                            runat="server"></asp:TextBox>
                        <br />

                        <asp:TextBox ID="Lastname" class="form-control"
                            type="text"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!-- English First & Last Name-->
                    <div>
                        <label class="control-label">שם באנגלית:</label>
                        <asp:TextBox ID="Firstnameeng" class="form-control"
                            type="text"
                            runat="server"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="Lastnameeng" class="form-control"
                            type="text"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!-- Email-->
                    <div>
                        <label class="control-label" for="email">אימייל:</label>
                        <asp:TextBox class="form-control" runat="server" ID="Email"  type="email"  />
                    </div>
                    <br />
                    



                </div>
                <div class="col-md-4">
                    <!--Phone-->
                    <div>
                        <label class="control-label" for="phone">
                            טלפון: 
                        </label>
                        <asp:TextBox class="form-control" ID="Phone"
                            type="tel"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <!--Occupation-->
                    <div>
                        <label class="control-label" for="DropDownListOccupation">עיסוק: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListOccupation" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListOccupation" required="required" runat="server">
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
                            runat="server"></asp:TextBox>
                    </div>
                    <br />
                   <!--Reference-->
                    <div>
                        <label class="control-label" for="DropDownListReference">איך הגעת אלינו: </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListReference" ErrorMessage="יש לבחור" InitialValue="בחרי" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:DropDownList class="form-control" ID="DropDownListReference" runat="server" required="required">
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
                                runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <br />
                 
                    <br />
                    </div>
                <div class="col-md-4">
                     


                    <!--ListAreas-->
                    <div>
                        <label class="control-label" for="CheckBoxListAreas">אזור פעילות מועדף: </label>
                        <!--AreaErrorMsg-->
                        <asp:Label ID="AreaErrorMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        <asp:CheckBoxList ID="CheckBoxListAreas" runat="server" ></asp:CheckBoxList>
                    </div>
                    <br />

                    <!--ListTraining-->
                    <div>
                        <label class="control-label" for="DropDownListTraining" >אזור מועדף להכשרה:</label>
                        <asp:DropDownList class="form-control" ID="DropDownListTraining" runat="server"  >
                        </asp:DropDownList>

                    </div>
                    <br />
                    <div>
                        <asp:Label  class="control-label" runat="server" ID="statuschangeLabel">סטטוס</asp:Label>
                        <asp:DropDownList class="form-control" ID="statuschange" runat="server"  >
  
                        </asp:DropDownList>
                    </div>

                </div>
                   
            </div>
            <a href="#" onclick="history.go(-1)" class="btn btn-default">חזור</a>
            <asp:Button runat="server" ID="update" Text="עדכני" />
        </div>


    </form>
</body>
</html>
