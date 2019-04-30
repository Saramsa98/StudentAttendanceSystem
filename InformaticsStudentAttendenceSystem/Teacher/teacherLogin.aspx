<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherLogin.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Teacher.teacherLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">a#vlb{display:none}</style>
	
    <link href="~/Teacher/teacherlogin.css" rel="stylesheet" type="text/css" />
   <style type="text/css">
        .style1
        {
            width: 100px;
           
        }
        .style2
        {
            width: 4px;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 75px;
        }
        .style5
        {
            font-family: "Arial Rounded MT Bold";
            font-size: x-small;
            color: #006666;
        }
        .auto-style1 {
            height: 200px;
            width:200px;
            
        }
        .auto-style2 {
            width: 288px;
            height: 400px;
        }
        .auto-style3 {
            width: 206px;
            height: 229px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="aheader" class="auto-style1">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/assets/images/admin/attendance.png" Height="115px" Width="561px" />
            <br />
    </div>
    <div id="alogin" class="auto-style2">
        <table class="auto-style3">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="atitle">
                    &nbsp;&nbsp;&nbsp;
                    Teacher Login Panel</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:TextBox ID="txtuname" runat="server" placeholder="Enter UserName" 
                        CssClass="ltxt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:TextBox ID="txtupass" runat="server" placeholder="Enter Password" 
                        CssClass="ltxt" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnlogin" runat="server" CssClass="lbtn" Text="Login" OnClick="btnlogin_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="Invalid Username and Password!" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/index.aspx">Back to Home</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
