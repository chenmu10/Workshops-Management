<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSchoolWorkshop.aspx.cs" Inherits="gui.Default1" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">

               <div class="page-header">
                <h1>פניה לתיאום סדנת מהממ"ט</h1>
                <br />
                <p class="lead">מורים? מנהלי בית ספר? אם אתם רוצים שנגיע אליכם, נשמח אם תמלאו את הטופס המצורף</p>
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
                            pattern="[0-9]{7}"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין סמל בית ספר')"
                            onchange="try{setCustomValidity('יש להזין סמל מוסד בעל 7 ספרות')}catch(e){}"
                            placeholder="סמל מוסד לפי משרד החינוך"
                            runat="server" AutoPostBack="True"
                            OnTextChanged="TextBox1_TextChanged" Width="220px">
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
                            class="custom-select"
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

                </fieldset>
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

            <!-- column 3-->
            <div class="col-md-4">
                <fieldset id="workshopDetails" runat="server">
                    <legend>פרטי סדנא</legend>
                    <label class="control-label" for="estimatedParticipants">כמות מחשבים תקינים שנוכל להשתמש בהם בסדנא: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="studentpredict"
                            type="number"
                            class="form-control"
                            min="0"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין מס' מחשבים תקינים')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="מס' מחשבים תקינים"
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="estimatedParticipants">להערכתך, כמה תלמידות יקחו חלק בסדנא: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="numberofcumputers"
                            type="number"
                            class="form-control"
                            min="0"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין מס' משתתפות צפוי')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            placeholder="מס' משתתפות צפוי"
                            runat="server" Width="220px"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="registrationComment">הערות: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="comments"
                            runat="server" Width="220px"
                            class="form-control"
                            TextMode="MultiLine"
                            Rows="5" Style="resize: none;"></asp:TextBox>
                    </div>
                    <br />
                    <label class="control-label" for="scientificWorkshop">האם הסדנא מיועדת לתלמידות עמ"ט?</label>
                    <asp:RadioButtonList ID="scientificWorkshop" runat="server">
                        <asp:ListItem Value="True"> כן</asp:ListItem>
                        <asp:ListItem Value="False">לא </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                </fieldset>
            </div>
            <br />
            <br />



            <!-- Date Region -->
            <div class="col-md-12">
                <fieldset id="Fieldset1" runat="server">
                    <legend>תאריכים אופציונליים לקיום סדנא (בחרו שלוש אפשרויות, עדיפות ליום שישי בבוקר)<small> *משך הסדנא 3 שעות.</small></legend>

                    <div class="col-md-4">
                        <label for="wantedWorkshopDate">אפשרות 1 : </label>
                        <asp:Calendar ID="Calendar1"
                            onchange=""
                            runat="server"></asp:Calendar>
                        <br />
                        <b>שעה</b>
                        <asp:TextBox ID="mm1"
                            type="number" min="0" max="60" runat="server" Width="13%" placeholder="MM" required="required">
                        </asp:TextBox>
                        <b>:</b>
                        <asp:TextBox ID="hh1"
                            type="number" min="0" max="24" runat="server" Width="13%" placeholder="HH" required="required">
                        </asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="Calendar2">אפשרות 2 : </label>
                        <asp:Calendar ID="Calendar2" runat="server" CssClass="auto-style32"></asp:Calendar>
                        <br />
                        <b>שעה</b>
                        <asp:TextBox ID="mm2"
                            type="number" min="0" max="60" runat="server" Width="13%" placeholder="MM">
                        </asp:TextBox>
                        <b>:</b>
                        <asp:TextBox ID="hh2"
                            type="number" min="0" max="24" runat="server" Width="13%" placeholder="HH">
                        </asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="control-label" for="Calendar3">אפשרות 3 : </label>
                        <asp:Calendar ID="Calendar3" runat="server" CssClass="yui" PopupButtonID="btnYui" Format="MMMM d, yyyy" TargetControlID="txtYui"></asp:Calendar>
                        <br />
                        <b>שעה</b>
                        <asp:TextBox ID="mm3"
                            type="number" min="0" max="60" runat="server" Width="13%" placeholder="MM">
                        </asp:TextBox>
                        <b>:</b>
                        <asp:TextBox ID="hh3"
                            type="number" min="0" max="24" runat="server" Width="13%" placeholder="HH">
                        </asp:TextBox>
                        <br />
                        <br />
                    </div>
                </fieldset>
            </div>
            <div class="col-md-10">
            </div>
            <div class="col-md-2">
                <!-- <button type="button" onclick="submit1()">submit</button>       -->
                <asp:Button ID="Buttonsen" class="btn btn-primary" runat="server" OnClick="ButtonSubmit_Click" Text="שליחה" />
                <!--  <input type=submit runat=server id=cmdSubmit value=Submit>-->
                <br />
            </div>
        </div>
    </form>
</body>
</html>


