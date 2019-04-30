<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="passwordChange.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Teacher.passwordChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    .style3
    {
        height: 19px;
    }
    .style2
    {
        width: 475px;
    }
        .auto-style1 {
            width: 183px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl" >
    <tr>
        <td class="tblhead">
          Change Password</td>
    </tr>
    <tr>
        <td class="style3">
        </td>
    </tr>
    <tr>
        <td>
            <table align="center" class="style2">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="lbl">
                       Old Password :</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtOldpwd" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                    </td>
                    <td>
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldpwd" ErrorMessage="Old password is required!" ForeColor="Red" SetFocusOnError="True" >

                        </asp:RequiredFieldValidator>--%>
                    </td>
                    
                    <td>
                        &nbsp;</td>
                </tr>
               
                <tr>
                    <td class="lbl">
                       New Password :</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtNewpwd" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
                    </td>
                    <td>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewpwd" ErrorMessage="New password is required!" ForeColor="Red" SetFocusOnError="True">

                        </asp:RequiredFieldValidator>--%>
                    <td>
                    </td>
                    
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td class="lbl">
                       Confirm Password :</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtConfirmpwd" runat="server" TextMode="Password" CssClass="txt" ForeColor="Red"></asp:TextBox>
                    </td>
                     <td>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtconfirmpwd" ErrorMessage="Confirm Password is required!" ForeColor="Red" SetFocusOnError="True">

                         </asp:RequiredFieldValidator>--%>
                         <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewpwd" ControlToValidate="txtConfirmpwd" ErrorMessage="Password Not Same" ForeColor="Red">

                         </asp:CompareValidator>--%>
                     </td>
                     
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn" Text="Update" 
                            onclick="btnUpdate_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style1">
                        <asp:Label ID="lbl" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                
            </table>
            
        </td>

    </tr>
    
</table>
</asp:Content>
