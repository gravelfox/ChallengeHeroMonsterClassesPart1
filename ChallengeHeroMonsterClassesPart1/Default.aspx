<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeHeroMonsterClassesPart1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 130px;
            height: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="display: inline-block; text-align: center;">
        <img alt="" class="auto-style1" src="images/eleven.jpg" /><br />
        <asp:Label ID="elevenLabel" runat="server"></asp:Label>
    </div>
    <div style="margin-left: 100px; display: inline-block; text-align: center;">
        <img alt="" class="auto-style1" src="images/dg.jpg" /><br />
        
        <asp:Label ID="demogorgonLabel" runat="server"></asp:Label>
        
    </div>

    <div style="margin-top: 50px;">
        <asp:Label ID="actionLabel" runat="server"></asp:Label>
    </div>

    </form>
</body>
</html>
