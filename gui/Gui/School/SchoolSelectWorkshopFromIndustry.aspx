<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolSelectWorkshopFromIndustry.aspx.cs" Inherits="gui.Gui.SchoolSelectWorkshopFromIndustry" %>


<html>
<head runat="server">
    <title>שיבוץ בית ספר</title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            table-layout: fixed;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Image runat="server" ImageUrl="../../../Content/homepic.PNG" AlternateText="Picture not found" CssClass="center-block" />

            <div class="jumbotron">
                <h2>סדנאות בחברות: שיבוץ בתי ספר</h2>
                <b> לכל שאלה או בעיה מוזמנות לפנות אלינו ל <a href="mailto:mehamemet@cyber.org.il">mehamemet@cyber.org.il</a>  </b>
            </div>

            <!-- Workshops Table-->
            <h3>בחרו סדנא עבור שיבוץ:</h3>
            <br />
            <asp:Label runat="server" ID="Msg" ForeColor="Red" Font-Bold="true"></asp:Label>
            <br />

            <asp:Table ID="workshopTable" class="table table-striped" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>
                        #
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        מועד
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        כתובת
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        חברה
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        מס' משתתפות אפשרי
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        פעולות
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />

            <!-- School Assignment -->
             <asp:PlaceHolder ID="SchoolAssignPlaceHolder" runat="server">
            <h4 style="display: inline;">סדנא נבחרת: </h4>
            <asp:Label ID="workshopIdLabel" runat="server" class="label label-primary" Font-Size="Large"></asp:Label>

        
                <h3>מלאו פרטי רישום: </h3>
                <div style="display: table; border-spacing: 10px;"
                    class="auto-style1">

                    <asp:Label runat="server" ID="schoolName" Visible="true" Text=""></asp:Label>

                </div>
                <div style="display: table-cell;">
                    <!-- Choose School -->
                    <label class="control-label" for="schoolSymbol">סמל מוסד:</label>

                    <asp:TextBox ID="schoolSymbol"
                        class="form-control"
                        type="number"
                        pattern="[0-9]{7}"
                        placeholder="לפי משרד החינוך"
                        Width="200px"
                    
                        runat="server">
                    </asp:TextBox>

                </div>
                <br />
                <div style="display: table-cell;">
                    <asp:Button runat="server" ID="searchSchool" class="btn btn-info" Text="חיפוש סמל" OnClick="searchSchool_Click" />
                </div>

                <br />

                <!-- Fill Workshop Details -->
                <label class="control-label" for="finalParticipants">להערכתך, כמה תלמידות יקחו חלק בסדנא: </label>

                <asp:TextBox ID="finalParticipants"
                    type="number"
                    class="form-control"
                    min="0"
                    Width="200px"
                    runat="server"></asp:TextBox>

                <br />
                <label class="control-label" for="assignComment">הערות: </label>
                <asp:TextBox ID="comments"
                    runat="server"
                    class="form-control"
                    TextMode="MultiLine"
                    Width="200px"
                    Rows="3" Style="resize: none;"></asp:TextBox>
                <br />

                <asp:Button runat="server" class="btn btn-success" ID="assign" OnClick="Assign_Click" Text="שליחה" />
            </asp:PlaceHolder>
        </div>

    </form>
</body>
</html>
