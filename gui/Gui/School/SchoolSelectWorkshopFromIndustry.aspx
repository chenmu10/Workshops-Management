<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolSelectWorkshopFromIndustry.aspx.cs" Inherits="gui.Gui.SchoolSelectWorkshopFromIndustry" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MMT Project </title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="jumbotron">
                <h2>סדנאות בתעשייה: שיבוץ בתי ספר</h2>
            </div>

            <!-- Workshops Table-->
            <h3>בחרו סדנא עבור שיבוץ:</h3>
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
            <h4 style="display: inline;">סדנא נבחרת: </h4>
            <asp:Label ID="workshopIdLabel" runat="server" class="label label-primary" Font-Size="Large"></asp:Label>
            <h3>מלאו פרטי רישום: </h3>

            <!-- Choose School -->

            <div class="controls form-inline">
                <label class="control-label" for="schoolSymbol">סמל מוסד:</label>
                <asp:TextBox ID="schoolSymbol"
                    class="form-control"
                    type="number"
                    pattern="[0-9]{7}"
                    Width="100px"
                    runat="server">
                </asp:TextBox>

                <asp:Button runat="server" class="btn btn-link" ID="showSchool" OnClick="ShowSchool_Click" Text="הצג" />
                <br />
            </div>

            <label class="control-label" for="schoolName">שם בית ספר נבחר:</label>
            <asp:Label runat="server" ID="schoolName"></asp:Label>
            <br />
            <br />

            <!-- Fill Workshop Details -->
            <label class="control-label" for="estimatedParticipants">להערכתכם/ן, כמה תלמידות יקחו חלק בסדנא: </label>

            <asp:TextBox ID="numberofcumputers"
                type="number"
                class="form-control"
                min="0"
                Width="100px"
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
        </div>
    </form>
</body>
</html>
