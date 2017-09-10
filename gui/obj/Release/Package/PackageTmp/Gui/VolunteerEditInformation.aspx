<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VolunteerEditInformation.aspx.cs" Inherits="gui.Gui.VolunteerEditInformation"  MasterPageFile="~/Site.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server" >
    <!DOCTYPE html>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <script src="../js/jquery-3.0.0.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    הכנסי את פרטייך:<br />
    <br />
  

    <table class="nav-justified">
        <tr>
            <td class="auto-style1">שם פרטי:</td>
            <td class="auto-style2">
                <asp:TextBox ID="firstname"  
                    oninvalid="setCustomValidity('הכנסי את שמך בבקשה ')"
                 required="required" placeholder="הכנסי את שמך הפרטי כאן" runat="server" Width="370px" ></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">שם פרטי (באנגלית):</td>
            <td class="auto-style2">
                <asp:TextBox ID="firstnameeng" required="required" 
                    oninvalid="setCustomValidity('הכנסי את שם פרטי באנגלית בבקשה ')"
                  placeholder="הכנסי את שם הפרטי באנגלית כאן"  runat="server" Width="370px"></asp:TextBox>
            </td>
            <td>
      
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">שם משפחה:</td>
            <td class="auto-style2">
                <asp:TextBox ID="lastname" required="required" 
                    oninvalid="setCustomValidity('הכנסי את שם המשפחה בבקשה ')"
                  placeholder="הכנסי את שם המשפחה בעברית כאן"  runat="server" Width="370px"></asp:TextBox>
            </td>
            <td>
      
            </td>
        </tr>
        <tr>
            <td class="auto-style1">שם משפחה (באנגלית):</td>
            <td class="auto-style2">
                <asp:TextBox runat="server" id="lastnameeng"  placeholder="הכנסי את שם המשפחה באנגלית כאן" type="text" required="required" Width="370px"/></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">אימייל:</td>
            <td class="auto-style2">
                <asp:TextBox runat="server" id="email" placeholder="email@email.com הכנסי את האימייל" type="email" required="required" Width="370px"/></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">טלפון:</td>
            <td class="auto-style2">
                <asp:TextBox ID="phone" 
                    type="tel" 
                    pattern="[0-9]{3}-[0-9]{7}"
                    required="required" 
                    oninvalid="setCustomValidity('05X-XXXXXXX  הכנסי את הטלפון לפי הפורמט  ')"
                    onchange="try{setCustomValidity('')}catch(e){}" 
                    placeholder="05X-XXXXXXX הכנסי את מספרך " 
                    runat="server" Width="370px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">עיסוק:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="DropDownList1" required="required"  runat="server" >
                    <asp:ListItem>בחרי</asp:ListItem>
                    <asp:ListItem>סטודנטית</asp:ListItem>
                    <asp:ListItem>אקדמאית</asp:ListItem>
                    <asp:ListItem>עובדת בתעשייה</asp:ListItem>
                    <asp:ListItem>אחר</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator" InitialValue="-1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">מעסיק או מוסד אקדמאי נוכחי:</td>
            <td class="auto-style2">
                <asp:TextBox ID="employee" required="required" placeholder="הכנסי את מעסקיך או מוסד אקדמאי" runat="server" Width="370px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">איך הגעת אלינו:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>בחרי</asp:ListItem>
                    <asp:ListItem>מכרים</asp:ListItem>
                    <asp:ListItem>פייסבוק</asp:ListItem>
                    <asp:ListItem>עבודה</asp:ListItem>
                    <asp:ListItem>אחר</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">איזור פעילות מועדף</td>
            <td class="auto-style2" id="Areas">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
                </asp:CheckBoxList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <span id="ErrorMsg" style="font-style:italic" runat="server"></span>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
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

   
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 257px;
        }
        .auto-style2 {
            width: 376px;
        }
    </style>
</asp:Content>

