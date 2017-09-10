<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerViewInformation.aspx.cs" Inherits="gui.Gui.VolunteerViewInformation"   %>


<%@ Register src="../Documents/nav.ascx" tagname="nav" tagprefix="uc1" %>

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

        <uc1:nav ID="nav1" runat="server" />


        עדכון&nbsp; הפרטים:<br />
    <br />
  

    <table class="nav-justified">
        <tr>
            <td class="auto-style14">שם פרטי:</td>
            <td class="auto-style15">
                <asp:TextBox ID="firstname"  
                    oninvalid="setCustomValidity('הכנסי את שמך בבקשה ')"
                 required="required" placeholder="הכנסי את שמך הפרטי כאן" runat="server" Width="370px" ></asp:TextBox>
            </td>
            <td class="auto-style16">
                </td>
        </tr>
        <tr>
            <td class="auto-style17">שם פרטי (באנגלית):</td>
            <td class="auto-style18">
                <asp:TextBox ID="firstnameeng" required="required" 
                    oninvalid="setCustomValidity('הכנסי את שם פרטי באנגלית בבקשה ')"
                  placeholder="הכנסי את שם הפרטי באנגלית כאן"  runat="server" Width="370px"></asp:TextBox>
            </td>
            <td class="auto-style19">
      
                </td>
        </tr>
        <tr>
            <td class="auto-style20">שם משפחה:</td>
            <td class="auto-style21">
                <asp:TextBox ID="lastname" required="required" 
                    oninvalid="setCustomValidity('הכנסי את שם המשפחה בבקשה ')"
                  placeholder="הכנסי את שם המשפחה בעברית כאן"  runat="server" Width="370px"></asp:TextBox>
            </td>
            <td class="auto-style22">
      
            </td>
        </tr>
        <tr>
            <td class="auto-style23">שם משפחה (באנגלית):</td>
            <td class="auto-style24">
                <asp:TextBox runat="server" id="lastnameeng"  placeholder="הכנסי את שם המשפחה באנגלית כאן" type="text" required="required" Width="370px"/></td>
            <td class="auto-style25">
                </td>
        </tr>
        <tr>
            <td class="auto-style26">אימייל:</td>
            <td class="auto-style27">
                <asp:TextBox runat="server" id="email" placeholder="email@email.com הכנסי את האימייל" type="email" required="required" Width="370px"/></td>
            <td class="auto-style28">
                </td>
        </tr>
        <tr>
            <td class="auto-style29">טלפון:</td>
            <td class="auto-style30">
                <asp:TextBox ID="phone" 
                    type="tel" 
                    pattern="[0-9]{3}-[0-9]{7}"
                    required="required" 
                    oninvalid="setCustomValidity('05X-XXXXXXX  הכנסי את הטלפון לפי הפורמט  ')"
                    onchange="try{setCustomValidity('')}catch(e){}" 
                    placeholder="05X-XXXXXXX הכנסי את מספרך " 
                    runat="server" Width="370px"></asp:TextBox>
            </td>
            <td class="auto-style31">
                </td>
        </tr>
        <tr>
            <td class="auto-style32">עיסוק:</td>
            <td class="auto-style33">
                <asp:DropDownList ID="DropDownList1" required="required"  runat="server" >
                    <asp:ListItem>בחרי</asp:ListItem>
                    <asp:ListItem Value="1">סטודנטית</asp:ListItem>
                    <asp:ListItem Value="2">אקדמאית</asp:ListItem>
                    <asp:ListItem Value="3">עובדת בתעשייה</asp:ListItem>
                    <asp:ListItem Value="4">אחר</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style34">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator" InitialValue="-1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style35">מעסיק או מוסד אקדמאי נוכחי:</td>
            <td class="auto-style36">
                <asp:TextBox ID="employee" required="required" placeholder="הכנסי את מעסקיך או מוסד אקדמאי" runat="server" Width="370px"></asp:TextBox>
            </td>
            <td class="auto-style37"></td>
        </tr>
        <tr>
            <td class="auto-style38">איך הגעת אלינו:</td>
            <td class="auto-style39">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>בחרי</asp:ListItem>
                    <asp:ListItem>מכרים</asp:ListItem>
                    <asp:ListItem>פייסבוק</asp:ListItem>
                    <asp:ListItem>עבודה</asp:ListItem>
                    <asp:ListItem>אחר</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style40"></td>
        </tr>
        <tr>
            <td class="auto-style32">איזור פעילות מועדף</td>
            <td class="auto-style33" id="Areas">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
                </asp:CheckBoxList>
            </td>
            <td class="auto-style34"></td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style12"></td>
            <td class="auto-style13"></td>
        </tr>
        <tr>
            <td class="auto-style41"><strong>הכשרה</strong></td>
            <td class="auto-style42">
                <asp:DropDownList ID="TraningList" runat="server">
                    <asp:ListItem Value="1">ללא הכשרה</asp:ListItem>
                    <asp:ListItem Value="2">עברה הכשרה</asp:ListItem>
                    <asp:ListItem Value="3">וותיקה</asp:ListItem>
                </asp:DropDownList>
               
            </td>
            <td class="auto-style43"></td>
        </tr>
    </table>
     <span id="ErrorMsg" style="font-style:italic" runat="server"></span>
    <br />
  <!-- <button type="button" onclick="submit1()">submit</button> -->

    <asp:Button  ID="Button1" runat="server" Height="44px"  OnClick="Button1_Click" Text="עדכני" Width="84px" BackColor="#99FF33" Font-Bold="True" Font-Size="Medium" />
   <!--  <input type=submit runat=server id=cmdSubmit value=Submit>-->
    <asp:Button ID="Button2" runat="server" BackColor="#FF3300" Font-Bold="True" Font-Size="Medium" Height="44px" Text="מחיקה" Width="84px" />
    <br />

	<script>

	    function check() {
	        //do something
	        alert("sart");
            document.getElementById("lastname")
	        //document.forms[0].checkValidity();
	        //document.forms[0].submit();
	        return true;
	    }
	</script>

   

    <style type="text/css">
        .auto-style1 {
            width: 257px;
        }
        .auto-style2 {
            width: 376px;
        }
        .auto-style11 {
            width: 257px;
            height: 49px;
        }
        .auto-style12 {
            height: 49px;
            text-align: right;
            width: 376px;
        }
        .auto-style13 {
            height: 49px;
        }
        .auto-style14 {
            width: 257px;
            height: 57px;
        }
        .auto-style15 {
            height: 57px;
            text-align: right;
            width: 376px;
        }
        .auto-style16 {
            height: 57px;
        }
        .auto-style17 {
            width: 257px;
            height: 82px;
        }
        .auto-style18 {
            height: 82px;
            text-align: right;
            width: 376px;
        }
        .auto-style19 {
            height: 82px;
        }
        .auto-style20 {
            width: 257px;
            height: 79px;
        }
        .auto-style21 {
            height: 79px;
            text-align: right;
            width: 376px;
        }
        .auto-style22 {
            height: 79px;
        }
        .auto-style23 {
            width: 257px;
            height: 83px;
        }
        .auto-style24 {
            height: 83px;
            text-align: right;
            width: 376px;
        }
        .auto-style25 {
            height: 83px;
        }
        .auto-style26 {
            width: 257px;
            height: 81px;
        }
        .auto-style27 {
            height: 81px;
            text-align: right;
            width: 376px;
        }
        .auto-style28 {
            height: 81px;
        }
        .auto-style29 {
            width: 257px;
            height: 87px;
        }
        .auto-style30 {
            height: 87px;
            text-align: right;
            width: 376px;
        }
        .auto-style31 {
            height: 87px;
        }
        .auto-style32 {
            width: 257px;
            height: 53px;
        }
        .auto-style33 {
            height: 53px;
            text-align: right;
            width: 376px;
        }
        .auto-style34 {
            height: 53px;
        }
        .auto-style35 {
            width: 257px;
            height: 72px;
        }
        .auto-style36 {
            height: 72px;
            text-align: right;
            width: 376px;
        }
        .auto-style37 {
            height: 72px;
        }
        .auto-style38 {
            width: 257px;
            height: 55px;
        }
        .auto-style39 {
            height: 55px;
            text-align: right;
            width: 376px;
        }
        .auto-style40 {
            height: 55px;
        }
        .auto-style41 {
            width: 257px;
            height: 42px;
        }
        .auto-style42 {
            height: 42px;
            text-align: right;
            width: 376px;
        }
        .auto-style43 {
            height: 42px;
        }
    </style>
    </form>
</body>
</html>


