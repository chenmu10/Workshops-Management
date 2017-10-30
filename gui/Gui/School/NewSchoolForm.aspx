<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSchoolForm.aspx.cs" Inherits="gui.Gui.NewSchoolForm" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <asp:Image runat="server" ImageUrl="../../../Content/mmtlogo.png" AlternateText="Picture not found" CssClass="center-block" />
            <div class="jumbotron">
                <h2>רישום בית ספר חדש</h2>
                <p>
               
                    *כל השדות חובה
                </p>
            </div>

            <asp:Label runat="server" ID="DateError"></asp:Label>
            <!-- column 1-->
            <div class="col-md-4">
                <fieldset id="schoolDetails" runat="server">
                    <legend>פרטי מוסד חינוכי</legend>
                    <label class="control-label" for="schoolSymbol">
                        סמל מוסד:
                    </label>
                    <div class="form-inline">
                        <asp:TextBox ID="schoolSymbol"
                            class="form-control"
                            type="number"
                            required="required"
                            placeholder="סמל מוסד לפי משרד החינוך"
                            runat="server" AutoPostBack="false"
                           Width="220px">
                        </asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="schoolName">
                        שם בי"ס : 
                    </label>
                    <div class="form-inline">
                        <asp:TextBox ID="schoolname"
                            required="required"
                            class="form-control"
                            oninvalid="setCustomValidity('יש להזין שם בית ספר')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="שם בית ספר"
                            runat="server" Width="220px">
                        </asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="schooladdress">כתובת: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="schooladdress"
                            type="text"
                            required="required"
                            class="form-control"
                            oninvalid="setCustomValidity('יש להזין כתובת')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="רחוב ומספר"
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="schoolCity">עיר: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="city"
                            type="text"
                            required="required"
                            class="form-control"
                            oninvalid="setCustomValidity('יש להזין עיר')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="עיר"
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="schoolArea">אזור: </label>
                    <div class="form-inline">
                        <asp:DropDownList ID="SchoolArea" runat="server"
                            required="required"
                            class="form-control custom-select" Width="220px"
                            oninvalid="setCustomValidity('יש לבחור איזור פעילות')"
                            onchange="try{setCustomValidity('')}catch(e){}">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <label class="control-label" for="computercontact">שם אחראי/ת מחשבים: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="computercontact"
                            type="text"
                            class="form-control"
                            pattern="[A-Za-z\u0590-\u05FF''-'\s]{1,40}"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין שם אחראי/ת מחשבים')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="שם אחראי/ת מחשבים"
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="computercontact">טלפון אחראי/ת מחשבים: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="computercontactphone"
                            type="tel"
                            class="form-control"
                            pattern="[0-9]{3}-[0-9]{7}"
                            required="required"
                            oninvalid="setCustomValidity('05X-XXXXXXX  הכנס/י את הטלפון לפי הפורמט  ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="05X-XXXXXXX כולל מקף "
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
 <asp:Button ID="Buttonsend" class="btn btn-primary pull-left" runat="server" OnClick="Buttonsend_Click"  Text="שליחה"/>
                    <br />
                    <br />
                </fieldset>
                <br />
            </div>


            <!-- column 2-->
            <div class="col-md-4">
                <fieldset id="ContactDetails" runat="server">
                    <legend>איש/ת קשר/רכז/ת עמ"ט</legend>
                    <label class="control-label" for="contactname">שם : </label>
                    <div class="form-inline">
                        <asp:TextBox ID="contactname"
                            type="text"
                            class="form-control"
                            pattern="[A-Za-z\u0590-\u05FF''-'\s]{1,40}"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין שם ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="שם מלא"
                            runat="server" Width="220px">
                        </asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="contactphone">טלפון : </label>
                    <div class="form-inline">
                        <asp:TextBox ID="contactphone"
                            type="tel"
                            class="form-control"
                            pattern="[0-9]{3}-[0-9]{7}"
                            required="required"
                            oninvalid="setCustomValidity('05X-XXXXXXX  הכנס/י את הטלפון לפי הפורמט  ')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="05X-XXXXXXX כולל מקף "
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="contactemail">כתובת אימייל : </label>
                    <div class="form-inline">
                        <asp:TextBox ID="contactemail"
                            type="email"
                            required="required"
                            class="form-control"
                            placeholder="אימייל"
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />

                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
