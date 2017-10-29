<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolWorkshopEditInfo.aspx.cs" Inherits="gui.Gui.Workshop.SchoolWorkshopEditInfo" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link href="../../css/StatusBar.css" rel="stylesheet" />
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <style>
    .tabs
  {
  
      padding-right: 40px;
      width:600px;
  }
      .tab
  {
     padding-right: 40px;
     
  }
    .selected{
        border-style: solid;
        background-color:white ;
        color:gray;
             
    }
    #Menu1 a.static{
        padding-left:40px;
        height:50px;
        display: table-cell;
        vertical-align: middle;
        text-align:center;
  
    }
    #Menu1 a.static.selected{
    border-top-style: solid;
    border-top-left-radius:5px;
    border-top-right-radius:5px;
    border-right-style: solid;
    border-bottom-style: none;
    border-left-style: solid;
    border-color:lightgray;
  
    }
    </style>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />

        <br />

        <div class="container">
            <div class="page-header">
                <h3>צפייה בפרטי סדנא בבית ספר</h3>
                <hr />

                <label class="control-label" for="WorkShopID">מס' מזהה: </label>
                <asp:Label runat="server" ID="WorkShopID"></asp:Label>
                <br />

                <label class="control-label" for="WorkShopStatus">סטטוס נוכחי: </label>
                <asp:Label runat="server" ID="WorkShopStatus"></asp:Label>
                <br />

                <label class="control-label" for="WorkShopDate">מועד קיום: </label>
                <asp:Label runat="server" ID="WorkShopDate"></asp:Label>
                <br />


                <asp:Label runat="server" ID="PrepareFormCreate" Text="נוצר טופס הכנה, ניתן לראות ב'פרטי הכנה'"></asp:Label>
                <br />
                <br />
                <asp:Label runat="server" Visible="false" ID="volunteerfinishedlabel" Text="יש כמות קטנה של מתנדבות,האם להמשיך?"></asp:Label>
                <br />
                <asp:Button runat="server" Visible="false" ID="yesToVolunteerFinished" Text="כן" class="btn btn-success" OnClick="yesToVolunteerFinished_Click" />
                <asp:Button runat="server" Visible="false" ID="noToVolunteerFinished" Text="לא" class="btn btn-danger" />
                <asp:Button runat="server" ID="cancelWorkshop" Text="ביטול סדנא" class="btn btn-danger" OnClientClick="return confirm('האם למחוק את הסדנא ? ');" OnClick="cancelWorkshop_Click" />

            </div>

            <div class="checkout-wrap">

                <ul class="checkout-bar">

                    <li runat="server" id="bar1">פניית בית ספר</li>
                    <li runat="server" id="bar2">בדיקת תאריכים</li>
                    <li runat="server" id="bar3">שיבוץ מתנדבות</li>
                    <li runat="server" id="bar4">שיבוץ הושלם</li>
                    <li runat="server" id="bar5">הכנה</li>
                    <li runat="server" id="bar6">ביצוע</li>
                    <li runat="server" id="bar7">מישוב</li>
                    <li runat="server" id="bar8">סגור</li>

                </ul>
            </div>

            <div class="form-inline" style="padding-top: 100px;">
                <label class="control-label" for="selectpicker">שינוי סטטוס: </label>
                <asp:DropDownList runat="server" ID="selectpicker" CssClass="form-control" Width="150px">
                    <asp:ListItem Value="1">בדיקת תאריכים</asp:ListItem>
                    <asp:ListItem Value="2">שיבוץ מתנדבות</asp:ListItem>
                    <asp:ListItem Value="3">שיבוץ הושלם</asp:ListItem>
                    <asp:ListItem Value="4">הכנה</asp:ListItem>
                    <asp:ListItem Value="5">ביצוע</asp:ListItem>
                    <asp:ListItem Value="6">מישוב</asp:ListItem>
                    <asp:ListItem Value="7">סגירה</asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" OnClick="updateStatus_Click" ID="updateStatus" Text="אישור שינוי" class="btn btn-link" />
            </div>
            <br />
            <asp:Label runat="server" ForeColor="Red" ID="msg"></asp:Label>

            <br />
            <div class="row" style="padding-bottom: 65px;">


                <div class="panel with-nav-tabs panel-default">

                    <div dir="rtl">
                        <asp:Menu
                            ID="Menu1"
                            Orientation="Horizontal"
                            StaticSelectedStyle-CssClass="selectedTab"
                            CssClass="tabs"
                            OnMenuItemClick="Menu1_MenuItemClick"
                            runat="server">
                            <Items>
                                <asp:MenuItem Text="פרטי בית ספר" Value="0" Selected="true" />
                                <asp:MenuItem Text="פרטי שיבוץ מתנדבות" Value="1" />
                                <asp:MenuItem Text="פרטי הכנה" Value="2" />
                                <asp:MenuItem Text="משובים" Value="3" />
                            </Items>
                            <StaticSelectedStyle CssClass="selectedItem" />
                            <StaticMenuItemStyle CssClass="tab" />
                        </asp:Menu>
                    </div>
                    <div class="tabContents">
                        <asp:MultiView
                            ID="MultiView1"
                            ActiveViewIndex="0"
                            runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="col-md-6">
                                    <asp:LinkButton runat="server" ID="goToSchool" OnClick="goToSchool_Click" class="btn btn-link">מעבר לפרטי בי"ס</asp:LinkButton>

                                    <br />
                                    <br />

                                    <label class="control-label" for="schoolName">
                                        שם בי"ס : 
                                    </label>
                                    <div class="form-inline">
                                        <asp:TextBox ID="schoolname" Enabled="false"
                                            required="required"
                                            class="form-control"
                                            oninvalid="setCustomValidity('יש להזין שם בית ספר')"
                                            onchange="try{setCustomValidity('')}catch(e){}"
                                            runat="server" Width="220px">
                                        </asp:TextBox>
                                    </div>
                                    <br />

                                    <label class="control-label" for="numberofcumputers">מס' מחשבים תקינים: </label>
                                    <div class="form-inline">
                                        <asp:TextBox ID="numberofcumputers" Enabled="false"
                                            type="number"
                                            class="form-control"
                                            min="0"
                                            required="required"
                                            oninvalid="setCustomValidity('יש להזין מס' מחשבים תקינים')"
                                            onchange="try{setCustomValidity('')}catch(e){}"
                                            runat="server" Width="220px"></asp:TextBox>
                                    </div>
                                    <br />
                                    <label class="control-label" for="studentpredict">מס' משתתפות צפוי: </label>
                                    <div class="form-inline">
                                        <asp:TextBox ID="studentpredict" Enabled="false"
                                            type="number"
                                            class="form-control"
                                            min="0"
                                            required="required"
                                            oninvalid="setCustomValidity('יש להזין מס' משתתפות צפוי')"
                                            onchange="try{setCustomValidity('')}catch(e){}"
                                            runat="server" Width="220px"></asp:TextBox>
                                    </div>
                                    <br />
                                    <label class="control-label" for="registrationComment">הערות: </label>
                                    <div class="form-inline">
                                        <asp:TextBox ID="comments" Enabled="false"
                                            runat="server" Width="220px"
                                            class="form-control"
                                            TextMode="MultiLine"
                                            Rows="5" Style="resize: none;"></asp:TextBox>
                                    </div>
                                    <br />
                                    <label class="control-label" for="scientificWorkshop">האם הסדנא מיועדת לתלמידות עמ"ט?</label>
                                    <asp:RadioButtonList ID="scientificWorkshop" Enabled="false" runat="server">
                                        <asp:ListItem Value="True"> כן</asp:ListItem>
                                        <asp:ListItem Value="False">לא </asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <fieldset>

                                        <legend>תאריכים אפשריים</legend>
                                        <label class="control-label" for="date1">תאריך 1: </label>
                                        <asp:Label runat="server" ID="date1"></asp:Label>
                                        <br />
                                        <label class="control-label" for="date2">תאריך 2: </label>
                                        <asp:Label runat="server" ID="date2"></asp:Label>
                                        <br />
                                        <label class="control-label" for="date3">תאריך 3: </label>
                                        <asp:Label runat="server" ID="date3"></asp:Label>
                                        <br />
                                        <asp:Label class="control-label" runat="server" ID="dateselecting">בחרי תאריך רצוי </asp:Label>
                                        <div>
                                            <asp:DropDownList runat="server" ID="dateselector" CssClass="form-control" Width="220px">
                                                <asp:ListItem Value="0" Text="בחרי תאריך"></asp:ListItem>
                                                <asp:ListItem Value="1"></asp:ListItem>
                                                <asp:ListItem Value="2"></asp:ListItem>
                                                <asp:ListItem Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button Visible="false" ID="UpdateWorkshopDate" runat="server" OnClick="DateButton_Click" Text="בחירה" CssClass="btn btn-link"/>
                                        </div>

                                    </fieldset>

                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="col-md-12">

                                    <label class="control-label" for="volunteercount">מס' מתנדבות נוכחי: </label>
                                    <asp:Label runat="server" ID="volunteercount"></asp:Label>
                                    <br />

                                    <a href="../Volunteer/VolunteerAssignWorkshops.aspx" class="btn btn-link" target="_blank">מעבר לעמוד שיבוץ</a>
                                    <br />

                                    <fieldset>
                                        <legend>פרטי מתנדבות משובצות</legend>
                                        <div class="col-md-4">
                                            <fieldset id="Volunteer1" runat="server">
                                                <legend>מתנדבת 1 - ותיקה</legend>
                                                <asp:Label runat="server" ID="volunteerName1" Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList
                                                    Width="250px"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="Voluntter1DropDownList_SelectedIndexChanged"
                                                    ID="Voluntter1DropDownList"
                                                    runat="server"
                                                    class="form-control">
                                                </asp:DropDownList>
                                                <br />
                                                <label class="control-label" for="volunteer1Ride">פרטי טרמפ: </label>
                                                <br />
                                                <asp:TextBox
                                                    ID="volunteer1Ride"
                                                    type="text"
                                                    class="form-control"
                                                    placeholder="יציאה+חזרה, מאיפה ומתי"
                                                    runat="server"
                                                    Width="250px">
                                                </asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="col-md-4">
                                            <fieldset id="Fieldset1" runat="server">
                                                <legend>מתנדבת 2</legend>
                                                <asp:Label runat="server" ID="volunteerName2" Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList
                                                    Width="250px"
                                                    ID="Voluntter2DropDownList"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="Voluntter2DropDownList_SelectedIndexChanged"
                                                    runat="server"
                                                    class="form-control">
                                                </asp:DropDownList>
                                                <br />
                                                <label class="control-label" for="volunteer1Ride">פרטי טרמפ: </label>
                                                <br />
                                                <asp:TextBox
                                                    ID="volunteer2Ride"
                                                    type="text"
                                                    class="form-control"
                                                    placeholder="יציאה+חזרה, מאיפה ומתי"
                                                    runat="server"
                                                    Width="250px">
                                                </asp:TextBox>
                                            </fieldset>
                                        </div>
                                        <div class="col-md-4">
                                            <fieldset id="Fieldset2" runat="server">
                                                <legend>מתנדבת 3</legend>
                                                <asp:Label runat="server" ID="volunteerName3" Text=""></asp:Label>
                                                <br />
                                                <asp:DropDownList
                                                    Width="250px"
                                                    ID="Voluntter3DropDownList"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="Voluntter3DropDownList_SelectedIndexChanged"
                                                    runat="server"
                                                    class="form-control">
                                                </asp:DropDownList>
                                                <br />
                                                <label class="control-label" for="volunteer1Ride">פרטי טרמפ: </label>
                                                <br />
                                                <asp:TextBox
                                                    ID="volunteer3Ride"
                                                    type="text"
                                                    class="form-control"
                                                    placeholder="יציאה+חזרה, מאיפה ומתי"
                                                    runat="server"
                                                    Width="250px">
                                                </asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </fieldset>
                                    <br />
                                    <asp:Button runat="server" Text="אשרי שינוי" OnClick="submitVolnteers" />
                                    <asp:Label runat="server" ID="updateVolunteerLabel" Text="העדכון התבצע בהצלחה" Visible="false"></asp:Label>
                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="PrepareFormReadey"></asp:Label>
                                    <br />
                                    <asp:Button CssClass="btn btn-link" runat="server" ID="prepareForm" OnClick="prepareForm_Click" Text="טופס הכנה" />
                                    <br />

                                    <!--Participants number-->
                                    <label class="control-label" for="finalParticipants">מס' משתתפות סופי: </label>
                                    <div>
                                        <asp:TextBox ID="finalParticipants" Width="20%" Enabled="false"
                                            type="number"
                                            class="form-control"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <br />

                                    <!--Computers with emulators number-->
                                    <label class="control-label" for="numOfCompWithEmulator">מס' מחשבים עם אימולטור: </label>
                                    <div>
                                        <asp:TextBox ID="numOfCompWithEmulator" Width="20%" Enabled="false"
                                            type="number"
                                            class="form-control"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <br />

                                    <!--DidPrepare PDF yes/no-->
                                    <asp:Label runat="server" class="control-label" ID="RadioButtonListDidPrepareLabel" for="RadioButtonListDidPrepare">בוצעו הוראות PDF:</asp:Label>

                                    <asp:RadioButtonList ID="RadioButtonListDidPrepare" runat="server">
                                        <asp:ListItem Value="True" Text="כן"></asp:ListItem>
                                        <asp:ListItem Value="False" Text="לא"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />

                                    <!--Answer_PerWorkshop yes/no-->
                                    <label class="control-label" for="RadioButtonListAnswer_PerWorkshop">
                                        האם כל התלמידות ענו על השאלון המקדים לסדנה? השאלון נמצא ב:
                         https://docs.google.com/forms/d/17vFUdE_wN4RuuGp4J1OC_Au5zK_DqIKqXExwVeaYCa8/viewform</label>
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
                                    <asp:Label runat="server" ID="RadioButtonListProjectOrControlLabel" idclass="control-label" for="RadioButtonListProjectOrControl">קיום מקרן/תוכנת השתלטות</asp:Label>

                                    <asp:RadioButtonList ID="RadioButtonListProjectOrControl" runat="server">
                                        <asp:ListItem Value="True"> כן</asp:ListItem>
                                        <asp:ListItem Value="False">לא </asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />

                                    <!--Seniors coming yes/no -->
                                    <asp:Label runat="server" ID="RadioButtonListSeniorsLabel" class="control-label" for="RadioButtonListSeniors">מגיעות בוגרות מגמה:</asp:Label>

                                    <asp:RadioButtonList ID="RadioButtonListSeniors" runat="server">
                                        <asp:ListItem Value="True">כן </asp:ListItem>
                                        <asp:ListItem Value="False">לא </asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />

                                    <!--Show video yes/no -->
                                    <asp:Label runat="server" ID="RadioButtonListShowVideoLabel" class="control-label" for="RadioButtonListShowVideo">אפשר להראות וידאו</asp:Label>
                                    <asp:RadioButtonList ID="RadioButtonListShowVideo" runat="server">
                                        <asp:ListItem Value="True">כן</asp:ListItem>
                                        <asp:ListItem Value="False">לא</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />

                                    <label class="control-label" for="prepareComments">הערות: </label>
                                    <div class="form-inline">
                                        <asp:TextBox ID="prepareComments" Enabled="false" Text="הערות שהזינו בטופס ועכשיו רק מוצגות"
                                            runat="server" Width="220px"
                                            class="form-control"
                                            TextMode="MultiLine"
                                            Rows="3" Style="resize: none;"></asp:TextBox>
                                    </div>
                                    <br />
                                </div>
                                <div class="col-md-6">
                                    <!-- Teacher Details-->
                                    <div>
                                        <fieldset>
                                            <legend>מורה נוכח/ת בפעילות</legend>
                                            <!-- Name-->
                                            <label class="control-label">שם מלא:</label>
                                            <br />
                                            <asp:TextBox ID="teacherName" class="form-control" Width="40%"
                                                type="text" Enabled="false"
                                                runat="server"></asp:TextBox>
                                            <br />
                                            <!-- Email-->
                                            <label class="control-label" for="teacherEmail">אימייל:</label>
                                            <br />
                                            <asp:TextBox Enabled="false" class="form-control" runat="server" Width="40%" ID="teacherEmail" type="email" required="required" />
                                            <br />
                                            <!--Phone-->
                                            <label class="control-label" for="teacherPhone">טלפון:</label>
                                            <br />
                                            <asp:TextBox Enabled="false" class="form-control" ID="teacherPhone" Width="40%"
                                                type="tel"
                                                runat="server"></asp:TextBox>
                                        </fieldset>
                                    </div>
                                    <br />
                                    <br />
                                </div>

                            </asp:View>
                            <asp:View ID="View4" runat="server">
                                <fieldset>

                                    <label class="control-label" for="VolunteerName1">מתנדבת 1: </label>
                                    <asp:Label runat="server" ID="Name1FeedBack"></asp:Label>
                                    <asp:LinkButton runat="server" OnClick="FeedBack1_Click" ID="FeedBack1" Text="משוב"></asp:LinkButton>
                                    <br />
                                    <label class="control-label" for="VolunteerName2">מתנדבת 2: </label>
                                    <asp:Label runat="server" ID="Name2FeedBack"></asp:Label>
                                    <asp:LinkButton runat="server" OnClick="FeedBack2_Click" ID="FeedBack2" Text="משוב"></asp:LinkButton>
                                    <br />
                                    <label class="control-label" for="VolunteerName3">מתנדבת 3: </label>
                                    <asp:Label runat="server" ID="Name3FeedBack"></asp:Label>
                                    <asp:LinkButton runat="server" OnClick="FeedBack3_Click" ID="FeedBack3" Text="משוב"></asp:LinkButton>
                                    <br />
                                    <label class="control-label" for="teacherName">מורה: </label>
                                    <asp:Label runat="server" ID="Name4FeedBack"></asp:Label>
                                    <asp:LinkButton runat="server" OnClick="FeedBack4_Click" ID="FeedBack4" Text="משוב"></asp:LinkButton>
                                </fieldset>
                                <br />
                            </asp:View>
                        </asp:MultiView>
                    </div>



                </div>

            </div>

        </div>
        <!--panel with-nav-tabs panel-default-->

        </div>
            <!--row-->

        </div>
        <!--container-->

    </form>
</body>

</html>
<script>
    document.getElementById("home").setAttribute("class", "active")
</script>

