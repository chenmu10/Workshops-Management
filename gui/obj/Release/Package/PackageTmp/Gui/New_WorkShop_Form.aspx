<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_WorkShop_Form.aspx.cs" Inherits="gui.Default1" MasterPageFile="~/Site.Master" %>


<asp:Content ID="BodyContent"  ContentPlaceHolderID="BodyContent" runat="server" >

    הרשמת בתי ספר מעתודה מדעית לסדנת מהממ&quot;ט<table class="auto-style1">
        <tr>
            <td class="auto-style15"><strong>פרטי בית ספר</strong></td>
            <td class="auto-style14"><strong>פרטי איש קשר</strong></td>
            <td class="auto-style16"><strong>פרטי סדנא</strong></td>
        </tr>
        <tr>
            <td class="auto-style35">סמל מוסד</td>
            <td class="auto-style34">שם רכז/ת ע.מ.ט</td>
            <td class="auto-style16">מס&#39; בנות מכיתה ט&#39; שישתתפו</td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:TextBox ID="schoolSymbol"
                 required="required"  
                 oninvalid="setCustomValidity('יש להזין סמל בית ספר')" 
                 placeholder="הכנס/י סמל בית ספר" 
                 onchange="try{setCustomValidity('')}catch(e){}" 
                 runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style34">
                <asp:TextBox ID="contactname" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:TextBox ID="studentpredict" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">שם מוסד</td>
            <td class="auto-style14">מס&#39; טלפון של רכז/ת ע.מ.ט</td>
            <td class="auto-style16">מס&#39; מחשבים תקינים</td>
        </tr>
        <tr>

            
            <td class="auto-style8">
                <asp:TextBox ID="schoolname" 
                    required="required"  
                 oninvalid="setCustomValidity('יש להזין שם בית ספר')" 
                    onchange="try{setCustomValidity('')}catch(e){}" 
                 placeholder="הכנס/י שם בית ספר" 
                    runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="contactphone"
                    type="tel" 
                    pattern="[0-9]{3}-[0-9]{7}"
                    required="required" 
                    oninvalid="setCustomValidity('05X-XXXXXXX  הכנס/י את הטלפון לפי הפורמט  ')"
                    onchange="try{setCustomValidity('')}catch(e){}" 
                    placeholder="05X-XXXXXXX הכנס/י את מספרך " 
                     runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style13">
                <asp:TextBox ID="numberofcumputers" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">עיר</td>
            <td class="auto-style14">כתובת מייל&nbsp; של הרכז/ת</td>
            <td class="auto-style36">
                הערות</td>
        </tr>
        <tr>
            <td class="auto-style11">
                <asp:TextBox ID="schoolcity" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="contactemail" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style36">
                <asp:TextBox ID="comments" runat="server" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">כתובת</td>
            <td class="auto-style12">שם אחראי/ת מחשבים</td>
            <td class="auto-style36">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:TextBox ID="schooladdress" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style34">
                <asp:TextBox ID="computercontact" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style36">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style34">מס&#39; טלפון של אחראי/ת מחשבים</td>
            <td class="auto-style36">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style35">
                &nbsp;</td>
            <td class="auto-style34">
                <asp:TextBox ID="computercontactphone" runat="server" Width="220px"></asp:TextBox>
            </td>
            <td class="auto-style36">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style35">
                &nbsp;</td>
            <td class="auto-style34">
                &nbsp;</td>
            <td class="auto-style36">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style35">
                תאריך אופציונאלי ראשון</td>
            <td class="auto-style34">
                תאריך אופציונאלי שני</td>
            <td class="auto-style36">תאריך אופציונאלי ראשון שלישי</td>
        </tr>
        <tr>
            <td class="auto-style35">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
            <td class="auto-style18"> 
                <asp:Calendar ID="Calendar4" runat="server" CssClass="auto-style32"></asp:Calendar>
            </td>
            <td class="auto-style19">
                <asp:Calendar ID="Calendar3" runat="server" CssClass="auto-style32"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                 שעה<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style4">שעה<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2">שעה<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
    <br />
  <!-- <button type="button" onclick="submit1()">submit</button> -->

    <asp:Button  ID="Buttonsen" runat="server" Height="44px" OnClick="Button1_Click" Text="שליחה" Width="84px" />
   <!--  <input type=submit runat=server id=cmdSubmit value=Submit>-->
    <br />
    <div id="dialog" style="display: none">
</div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
	<script>

	    function check() {
	        //do something
	        alert("sart");
            document.getElementById("lastname")
	        //document.forms[0].checkValidity();
	        //document.forms[0].submit();
	        return true;
	    }
	    function ShowPopup(message) {
	        $(function () {
	            $("#dialog").html(message);
	            $("#dialog").dialog({
	                title: "בחירת תאריכים",
	                buttons: {
	                    Close: function () {
	                        $(this).dialog('close');
	                    }
	                },
	                modal: true
	            });
	        });
	    };
	</script>

   
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 74%;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            width: 320px;
            text-align: right;
        }
        .auto-style4 {
            text-align: right;
            width: 296px;
        }
        .auto-style8 {
            width: 320px;
            text-align: center;
            height: 27px;
        }
        .auto-style9 {
            text-align: center;
            width: 296px;
            height: 27px;
        }
        .auto-style10 {
            text-align: center;
            height: 27px;
        }
        .auto-style11 {
            width: 320px;
            text-align: center;
            height: 29px;
        }
        .auto-style12 {
            text-align: center;
            width: 296px;
            height: 29px;
        }
        .auto-style13 {
            text-align: center;
            height: 29px;
        }
        .auto-style14 {
            text-align: center;
            width: 296px;
            height: 20px;
        }
        .auto-style15 {
            width: 320px;
            text-align: center;
            height: 20px;
        }
        .auto-style16 {
            text-align: center;
            height: 20px;
        }
        .auto-style18 {
            text-align: center;
            width: 296px;
            height: 22px;
        }
        .auto-style19 {
            text-align: center;
            height: 22px;
        }
        .auto-style32 {
            margin-top: 0px;
        }
        .auto-style34 {
            text-align: center;
            width: 296px;
        }
        .auto-style35 {
            width: 320px;
            text-align: center;
        }
        .auto-style36 {
            text-align: center;
        }
    </style>
</asp:Content>

