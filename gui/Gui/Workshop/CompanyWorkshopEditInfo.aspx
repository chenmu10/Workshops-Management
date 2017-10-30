<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyWorkshopEditInfo.aspx.cs" Inherits="gui.Gui.Workshop.CompanyWorkshopEditInfo" %>

<%@ Register Src="../Documents/nav.ascx" TagName="nav" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StatusBar.css" rel="stylesheet" type="text/css" />
</head>
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
<body>
    <form id="form1" runat="server">

        <uc1:nav ID="nav1" runat="server" />

        <div class="container">
            <div class="page-header">
                <h3>צפייה בפרטי סדנא בחברה</h3>
            </div>


            <label class="control-label" for="WorkShopID">מס' מזהה: </label>
            <asp:Label runat="server" ID="WorkShopID"></asp:Label>
            <br />

            <label class="control-label" for="WorkShopStatus">סטטוס נוכחי: </label>
            <asp:Label runat="server" ID="WorkShopStatus"></asp:Label>
            <br />

            <label class="control-label" for="WorkShopDate">מועד קיום: </label>
            <asp:Label runat="server" ID="WorkShopDate"></asp:Label>
            <br />
             <asp:Label runat="server" ID="volunteerfinishedlabel" Text="יש כמות קטנה של מתנדבות,האם להמשיך?"></asp:Label>
                <br />
                <asp:Button runat="server" ID="yesToVolunteerFinished" Text="כן" class="btn btn-success" OnClick="yesToVolunteerFinished_Click" />
                <asp:Button runat="server" ID="noToVolunteerFinished" Text="לא" class="btn btn-danger" />
            <br />
            <asp:Button runat="server" ID="cancelWorkshop" Text="ביטול סדנא" class="btn btn-danger"  OnClientClick="return confirm('האם למחוק את הסנא ? ');" OnClick="cancelWorkshop_Click"/>
            <br />
            <asp:Button runat="server" ID="backToSchoolAssign" Text="חזרה לשיבוץ בית ספר\איפוס סדנא" OnClientClick="return confirm('האם לאפס את הסנא ? ');" class="btn " OnClick="backToSchoolAssign_Click"/>



            <hr />
            <div class="checkout-wrap">
                <ul class="checkout-bar">
                    <li runat="server" id="bar1">שיבוץ בית ספר</li>
                    <li runat="server" id="bar2">בי"ס שובץ</li>
                    <li runat="server" id="bar3">שיבוץ מתנדבות</li>
                    <li runat="server" id="bar4">מתנדבות שובצו</li>
                    <li runat="server" id="bar5">ביצוע</li>
                    <li runat="server" id="bar6">מישוב</li>
                    <li runat="server" id="bar7">סגור</li>
                </ul>
            </div>
           
             <div class="form-inline" style="padding-top:100px;">
                <label class="control-label" for="selectpicker">שינוי סטטוס: </label>
                <asp:DropDownList runat="server" ID="selectpicker" CssClass="form-control" Width="150px">
                    <asp:ListItem Value="1">שיבוץ מתנדבות</asp:ListItem>
                    <asp:ListItem Value="2">מתנדבות שובצו</asp:ListItem>
                    <asp:ListItem Value="3">ביצוע</asp:ListItem>
                    <asp:ListItem Value="4">מישוב</asp:ListItem>
                    <asp:ListItem Value="5">סגירה</asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" ID="Button2" Text="אישור שינוי" class="btn btn-link" OnClick="updateStatus_Click" />

            </div>

<div dir="rtl" style="padding-top:20px"> 
      <asp:Menu
        id="Menu1"
        Orientation="Horizontal"
        StaticSelectedStyle-CssClass="selectedTab"
        CssClass="tabs"
        OnMenuItemClick="Menu1_MenuItemClick"
        Runat="server">
        <Items>
        <asp:MenuItem   Text="פרטי סדנא בחברה" Value="0" Selected="true" />
        <asp:MenuItem Text="פרטי שיבוץ בית ספר" Value="1" />
        <asp:MenuItem Text="פרטי שיבוץ מתנדבות" Value="2" />
         <asp:MenuItem Text="משובים" Value="3" />
        </Items>   
        <StaticSelectedStyle CssClass="selectedItem" />
          <StaticMenuItemStyle CssClass="tab" />
    </asp:Menu>
    </div>
    <div class="tabContents">
    <asp:MultiView
        id="MultiView1"
        ActiveViewIndex="0"
        Runat="server">
        <asp:View ID="View1" runat="server">
           <!-- column 1-->
                                <div class="col-md-6">
                                    <fieldset id="companyDetails" runat="server">
                                        <legend>פרטי חברה</legend>
                                        <!-- Company Name -->
                                        <label class="control-label" for="companyName">שם:</label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="companyName" Enabled="false"
                                                required="required"
                                                CssClass="form-control disabled"
                                                oninvalid="setCustomValidity('יש להזין שם חברה')"
                                                onchange="try{setCustomValidity('')}catch(e){}"
                                                runat="server">
                                            </asp:TextBox>
                                        </div>
                                        <br />
                                        <!-- Company Address -->
                                        <label class="control-label" for="address">כתובת:</label>
                                        <div>
                                            <asp:TextBox ID="address" runat="server" Enabled="false" Width="220px" CssClass="form-control disabled"></asp:TextBox>
                                        </div>
                                        <br />
                                        <asp:LinkButton runat="server" ID="goToCompany" class="btn btn-link">מעבר לפרטי חברה</asp:LinkButton>
                                        <br />

                                        <a class="btn btn-link" href="../School/SchoolSelectWorkshopFromIndustry.aspx" target="_blank">מעבר לטופס שיבוץ בית ספר</a>


                                    </fieldset>
                                </div>

                                <!-- column 2-->
                                <div class="col-md-6">
                                    <fieldset id="workshopDetails" runat="server">
                                        <legend>פרטי סדנא</legend>
                                        <label class="control-label"  for="studentsPredictedNum">מס' משתתפות אפשרי: </label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="studentsPredictedNum" Enabled="false"
                                                type="number"
                                               CssClass="form-control disabled"
                                                min="0"
                                                required="required"
                                                oninvalid="setCustomValidity('יש להזין מס' משתתפות אפשרי')"
                                                onchange="try{setCustomValidity('')}catch(e){}"
                                                runat="server" Width="220px"></asp:TextBox>
                                        </div>

                                        <br />
                                        <label class="control-label" for="companyComments">הערות: </label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="companyComments" Enabled="false"
                                                runat="server" Width="220px"
                                               CssClass="form-control disabled"
                                                TextMode="MultiLine"
                                                Rows="5" Style="resize: none;"></asp:TextBox>
                                        </div>
                                        <br />
                                        <label class="control-label" for="dateTime">תאריך ושעה: </label>
                                        <div class="form-inline">
                                            <asp:TextBox ID="dateTime" Enabled="false"
                                                runat="server" Width="220px"
                                               CssClass="form-control disabled"></asp:TextBox>
                                        </div>
                                     
                                    </fieldset>
                                </div>
        </asp:View>        
        <asp:View ID="View2" runat="server">
         <div class="tab-pane" id="school">

                                <label class="control-label" for="schoolName">שם בי"ס :</label>
                                <div class="form-inline">
                                    <asp:TextBox ID="schoolname" Enabled="false"
                                        required="required"
                                        CssClass="form-control disabled"
                                        oninvalid="setCustomValidity('יש להזין שם בית ספר')"
                                        onchange="try{setCustomValidity('')}catch(e){}"
                                        runat="server">
                                    </asp:TextBox>

                                    <asp:LinkButton runat="server" ID="goToSchool" OnClick="goToSchool_Click" class="btn btn-link">מעבר לפרטי בי"ס</asp:LinkButton>
                                </div>

                                <br />

                                <label class="control-label" for="FinalStudentsNum">מספר בנות צפויות מבי"ס: </label>
                                <div>
                                    <asp:TextBox ID="FinalStudentsNum" Enabled="false"
                                        type="number"
                                        CssClass="form-control disabled"
                                        min="0" Width="220px"
                                        required="required"
                                        oninvalid="setCustomValidity('יש להזין מס' משתתפות')"
                                        onchange="try{setCustomValidity('')}catch(e){}"
                                        runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <label class="control-label" for="schoolComments">הערות: </label>
                                <div class="form-inline">
                                    <asp:TextBox ID="schoolComments" Enabled="false"
                                        runat="server"
                                        CssClass="form-control disabled"
                                        TextMode="MultiLine"
                                        Rows="5" Style="resize: none;"></asp:TextBox>
                                </div>



                            </div>                    
        </asp:View>        
        <asp:View ID="View3" runat="server">
         <div class="" id="volunteers">

                               <div class="col-md-12">
                                   
                                    <label class="control-label" for="volunteercount">מס' מתנדבות נוכחי: </label>
                                    <asp:Label runat="server" ID="Label1"></asp:Label>
                                    <br />
                               
                                    <a href="../Volunteer/VolunteerAssignWorkshops.aspx" class="btn btn-link" target="_blank">מעבר לעמוד שיבוץ</a>
                                    <br />

                                    <fieldset>
                                         <legend>פרטי מתנדבות משובצות</legend>
                                         <div class="col-md-4">
                                            <fieldset id="Volunteer1" runat="server">
                                                <legend>מתנדבת 1 - ותיקה</legend>
                                                 <asp:Label runat="server" ID="VolunteerName1" Text="" ></asp:Label>
                                                <br />
                                                <asp:DropDownList
                                                    Width="250px"
                                                    ID="Voluntter1DropDownList"
                                                    AutoPostBack="true"
                                                    OnSelectedIndexChanged="Voluntter1DropDownList_SelectedIndexChanged"
                                                    runat="server"
                                                    class="form-control">
                                                </asp:DropDownList>
                                               <br />
                                                <Label  class="control-label" for="Volunteer1Ride">פרטי טרמפ: </Label>
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
                                                 <asp:Label runat="server" ID="VolunteerName2" Text="" ></asp:Label>
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
                                                <asp:Label runat="server" class="control-label" for="volunteer2Ride">פרטי טרמפ: </asp:Label>
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
                                                 <asp:Label runat="server" ID="VolunteerName3" Text="" ></asp:Label>
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
                                                <asp:Label runat="server" class="control-label" for="volunteer3Ride">פרטי טרמפ: </asp:Label>
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
                                    <asp:Button runat="server" Text="אשרי שינוי" OnClick="submitVolnteers"/>
                                <asp:Label runat="server" ID="updateVolunteerLabel" Text="העדכון התבצע בהצלחה" Visible="false"></asp:Label>

                                </div>



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




                                </fieldset>
        </asp:View>      
    </asp:MultiView>
    </div>

            <br />
          
            <!--/row-->

        </div>
        <!--/container-->
          <br />
            <br />
    </form>
</body>
</html>
