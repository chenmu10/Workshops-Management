<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkShopPrepareForm.aspx.cs" Inherits="gui.Gui.WorkShopPrepareForm" %>

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
            <div class="row">
                <div class="col-sm-6">
                    <div class="page-header">
                        <asp:Image runat="server" Height="107px" Width="402px" ImageUrl="../../../Content/homepic.PNG" AlternateText="Picture not found" />
                        <h3>הכנה לסדנת מהממ"ט בבי"ס<br />
                        </h3>
                        מס' סדנא: <span id="workshopID" runat="server">
                            <asp:Label runat="server" ID="_workshopID"></asp:Label>
                        </span>
                        <br />
                        שם בי"ס: <span id="schoolName" runat="server">
                            <asp:Label runat="server" ID="_schoolName"></asp:Label>
                        </span>
                        <br />
                        כתובת: <span id="schoolLoc" runat="server">
                            <asp:Label runat="server" ID="_schoolAddress"></asp:Label>
                        </span>
                        <br />
                        מועד: <span id="WorkshopDate" runat="server">
                            <asp:Label runat="server" ID="_WorkshopDate"></asp:Label>
                        </span>
                        <br />
                    </div>


                 
                  
                    <br />
                    <br />
                    <!--Participants number-->
                    <label class="control-label" for="estimatedParticipants">מספר התלמידות הסופי שיקחו חלק בסדנה: </label>


                    <div>
                        <asp:TextBox ID="estimatedParticipants" Width="20%"
                            type="number"
                            class="form-control"
                            min="0"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין מס' משתתפות')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <!--Computers with emulators number-->
                    <label class="control-label" for="numOfCompWithEmulator">כמות מחשבים בחדר מחשבים עליהם מותקן אימולטור: </label>
                    <div>
                        <asp:TextBox ID="numOfCompWithEmulator" Width="20%"
                            type="number"
                            class="form-control"
                            min="0"
                            required="required"
                            oninvalid="setCustomValidity('יש להזין מס' מחשבים')"
                            onchange="try{setCustomValidity('')}catch(e){}"
                            runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <!--Parking text -->
                    <label class="control-label" for="schoolparking">אפשרויות חנייה (בבי"ס או מסביב ואם יש עלות): </label>
                    <div>
                        <asp:TextBox ID="schoolparking"
                            type="text" Width="40%"
                            class="form-control"
                            placeholder="לדוג' חנייה ברחוב X בתשלום 20 ליום.."
                            runat="server"></asp:TextBox>
                    </div>
                    <br />

                    <label class="control-label" for="prepareComment">הערות: </label>
                    <div class="form-inline">
                        <asp:TextBox ID="prepareComment"
                            runat="server" Width="220px"
                            class="form-control"
                            TextMode="MultiLine"
                            Rows="5" Style="resize: none;"></asp:TextBox>
                    </div>
                    <br />


                    <!--DidPrepare PDF yes/no-->
                    <label class="control-label" for="RadioButtonListDidPrepare">בוצעו כלל הוראות מסמך ההכנה?</label>
                    <asp:RadioButtonList ID="RadioButtonListDidPrepare" runat="server">
                        <asp:ListItem Value="True" Text="כן"></asp:ListItem>
                        <asp:ListItem Value="False" Text="לא"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadioButtonListDidPrepare" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                    <!--Answer_PerWorkshop yes/no-->
                    <label class="control-label" for="RadioButtonListAnswer_PerWorkshop">
                        האם כל התלמידות ענו על השאלון המקדים לסדנה? השאלון נמצא ב:
                        <a href="https://docs.google.com/forms/d/17vFUdE_wN4RuuGp4J1OC_Au5zK_DqIKqXExwVeaYCa8/viewform">קישור</a>
                         </label>
                    <asp:RadioButtonList ID="RadioButtonListAnswer_PerWorkshop" runat="server">
                        <asp:ListItem Value="True" Text="כן"></asp:ListItem>
                        <asp:ListItem Value="False" Text="לא"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="RadioButtonListAnswer_PerWorkshop" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                    <!--Student_Gmail yes/no-->
                    <label class="control-label" for="RadioButtonListStudent_Gmail">האם לכל התלמידות נפתח חשבון ג'ימייל (והן זוכרות את הסיסמה)? זה הכרחי לפעילות.</label>
                    <asp:RadioButtonList ID="RadioButtonListStudent_Gmail" runat="server">
                        <asp:ListItem Value="True" Text="כן"></asp:ListItem>
                        <asp:ListItem Value="False" Text="לא"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="RadioButtonListStudent_Gmail" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                    <!--Projector\contorl program yes/no -->
                    <label class="control-label" for="RadioButtonListProjectOrControl">האם יש מחשב מורה מחובר למקרן תקין (כולל סאונד) או לחילופין תוכנת השתלטות על המחשבים?</label>
                    <asp:RadioButtonList ID="RadioButtonListProjectOrControl" runat="server">
                        <asp:ListItem Value="True"> כן</asp:ListItem>
                        <asp:ListItem Value="False">לא </asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RadioButtonListProjectOrControl" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                    <!--Seniors coming yes/no -->
                    <label class="control-label" for="RadioButtonListSeniors">האם יגיעו תיכוניסטיות מהמגמה לשיחת הסיכום על מנת לשתף את התלמידות מחוויותיהן וניסיונן?</label>
                    <asp:RadioButtonList ID="RadioButtonListSeniors" runat="server">
                        <asp:ListItem Value="True">כן </asp:ListItem>
                        <asp:ListItem Value="False">לא </asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadioButtonListSeniors" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                    <!--Show video yes/no -->
                    <label class="control-label" for="RadioButtonListShowVideo">במהלך הסדנה אנו מקרינות סרטון מאתר YouTube. האם ווידאתם/ן כי ניתן לגשת לאתר וכן כי האודיו עובד?</label>
                    <asp:RadioButtonList ID="RadioButtonListShowVideo" runat="server">
                        <asp:ListItem Value="True">כן</asp:ListItem>
                        <asp:ListItem Value="False">לא</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="RadioButtonListShowVideo" runat="server" ErrorMessage="יש לבחור" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                     <!--Phone Computer Person-->
                            <label class="control-label" for="compManagerPhone">מהו מס' הטלפון של אחראי/ת המחשבים?</label>
                            <asp:TextBox class="form-control" ID="compManagerPhone"
                                type="tel"
                                pattern="[0-9]{3}-[0-9]{7}"
                                required="required"
                                oninvalid="setCustomValidity('05X-XXXXXXX  הכניסי את הטלפון לפי הפורמט')"
                                onchange="try{setCustomValidity('')}catch(e){}"
                                placeholder="05X-XXXXXXX" Width="40%"
                                runat="server"></asp:TextBox>
                          <br />
                    <!-- Teacher Details-->
                    <div>
                        <fieldset>
                            <legend>מורה נוכח/ת בפעילות</legend>
                            <p>
                                חשוב לציין שמתנדבות הפרויקט אינן מטפלות בבעיות משמעת.
                            </p>
                            <!-- Name-->
                            <label class="control-label">שם מלא:</label>
                            <br />
                            <asp:TextBox ID="teacherName" class="form-control"
                                type="text"
                                pattern="[\u0590-\u05FF''-'\s]{1,20}"
                                oninvalid="setCustomValidity('שם פרטי לא תקין, אנא נסי שם בעברית')"
                                onchange="try{setCustomValidity('')}catch(e){}"
                                required="required" placeholder="שם מלא" Width="40%"
                                runat="server"></asp:TextBox>
                            <br />
                            <!-- Email-->
                            <label class="control-label" for="teacherEmail">אימייל:</label>
                            <asp:TextBox class="form-control" runat="server" ID="teacherEmail" placeholder="example@gmail.com" type="email" required="required" Width="40%" />
                            <br />
                            <!--Phone-->
                            <label class="control-label" for="teacherPhone">טלפון:</label>
                            <asp:TextBox class="form-control" ID="teacherPhone"
                                type="tel"
                                pattern="[0-9]{3}-[0-9]{7}"
                                required="required"
                                oninvalid="setCustomValidity('05X-XXXXXXX  הכניסי את הטלפון לפי הפורמט')"
                                onchange="try{setCustomValidity('')}catch(e){}"
                                placeholder="05X-XXXXXXX" Width="40%"
                                runat="server"></asp:TextBox>
                        </fieldset>
                    </div>
                    <br />
                    <br />

                    <asp:Button runat="server" CssClass="btn btn-success center-block" Text="שליחה" OnClick="UpdatePrepareToWorkshop" />

                    <span id="msg" style="font-style: italic" runat="server"></span>
                     <br />
                    <br />
                </div>



            </div>

        </div>

    </form>
</body>
</html>


