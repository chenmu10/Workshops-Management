<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessForm.aspx.cs" Inherits="gui.Gui.SuccessForm" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-3.0.0.min.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <link href="../../css/bootstrap-rtl.min.css" rel="stylesheet" />
    <link href="../../css/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="row">
                <div class="jumbotron">
                    <h2>סדנאות מהממ"ט</h2>
                </div>

                <hr />
                <div class="text-center">
                    <em>
                        <asp:Label ID="Msg" Style="text-align: center" runat="server" CssClass="auto-style1">ההרשמה התבצעה בהצלחה!</asp:Label>
                    </em>
                </div>

            </div>

        </div>

    </form>
</body>
</html>


