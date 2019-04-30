<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Staff.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style4
    {
        width: 449px;
    }
    .style5
    {
        width: 387px;
    }
    .style7
    {
        text-align: right;
        color: Red;
        width: 242px;
    }
    .style6
    {
        width: 140px;
    }
    .style8
    {
        width: 242px;
    }
         .auto-style2 {
            border: solid 1px blue;
            padding-left: 3px;
            border-radius: 1px;
        }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl">
        <tr>
            <td class="tblhead" style="text-align:center">
                ADD STUDENT</td>
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
                        <td>
                        &nbsp;</td>
                        <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Student ID :</td>
                        <td>
                            <asp:TextBox ID="txtStudentId" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvStudentID" runat="server" ControlToValidate="txtStudentId" ErrorMessage="Student ID is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Student Name :</td>
                        <td>
                            <asp:TextBox ID="txtStudentName" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                            <%--<asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ControlToValidate="txtStudentName" ErrorMessage="Student Name is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Address : </td>
                        <td>
                            <asp:TextBox ID="txtAdd" runat="server" CssClass="txt" Height="33px" 
                                TextMode="MultiLine" Width="161px"></asp:TextBox>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAdd" ErrorMessage="Address is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td class="lbl">
                            Mobile :</td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Email :</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            DOB : </td>
                        <td>
                            <asp:TextBox ID="txtDOB" runat="server" CssClass="txt"></asp:TextBox>
                             <td>
                            &nbsp;<asp:Label ID="lblPlaceholder" runat="server" Text="mm/dd/yyyy"></asp:Label>
                                 </td>
                        </td>
                         <td>
                            <%--<asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtStudentId" ErrorMessage="DOB is required" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td class="lbl">
                            Gender : </td>
                        <td>
                            <asp:DropDownList ID="drpGender" runat="server" CssClass="auto-style2" Height="25px" Width="145px">
                                <asp:ListItem>SELECT</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="drpGender" ErrorMessage="Gender is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                
                    <tr>
                        <td class="lbl">
                            Enroll Date :</td>
                        <td>
                            <asp:TextBox ID="txtEnrollDate" runat="server" CssClass="txt"></asp:TextBox>
                             <td>
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="mm/dd/yyyy"></asp:Label>
                                 </td>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvEnrollDate" runat="server" ControlToValidate="txtEnrollDate" ErrorMessage="Enroll Date is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Course Name: </td>
                        <td>
                            <asp:DropDownList ID="drpCourseName" runat="server" CssClass="txt" Height="25px" Width="145px">
                                
                            </asp:DropDownList>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="drpCourseName" ErrorMessage="Student ID is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Module ID: </td>
                        <td>
                            <asp:DropDownList ID="drpModuleId" runat="server" CssClass="txt" Height="25px" Width="145px">
                                
                            </asp:DropDownList>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="drpCourseName" ErrorMessage="Student ID is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Group : </td>
                        <td>
                            <asp:DropDownList ID="drpGroup" runat="server" CssClass="txt" Height="25px" Width="145px">
                                
                            </asp:DropDownList>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="drpCourseName" ErrorMessage="Student ID is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            Year: </td>
                        <td>
                            <asp:DropDownList ID="drpYear" runat="server" CssClass="txt" Height="25px" Width="145px">
                                
                            </asp:DropDownList>
                        </td>
                         <td>
                           <%-- <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="drpCourseName" ErrorMessage="Student ID is required!" ForeColor="Red" SetFocusOnError="True">

                            </asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="lbl">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lbl" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        &nbsp;</td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn" Text="ADD" 
                                onclick="btnAdd_Click" />
                        </td>
                        <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        &nbsp;</td>
                        <td>
                        &nbsp;</td>
                        <td>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                        &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            &nbsp;</td>
        </tr>
    </table>

</asp:Content>
