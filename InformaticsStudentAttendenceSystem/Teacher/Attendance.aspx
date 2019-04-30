<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Teacher.Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
            color: #fff;
            text-align: left;
            font-size: 20px;
            font-weight: bold;
            background: blue;
            padding-left: 10px;
            width: 785px;
        }
        .auto-style2 {
            width: 785px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl">
    <tr>
        <td class="auto-style1" style="text-align:center">
            ATTENDANCE</td>
    </tr>
    <tr>
        <td class="auto-style2">
        </td>
    </tr>
       <tr>
            <td class="auto-style2">
                Select Module ID:&nbsp;&nbsp;
                <asp:DropDownList ID="drpModuleId" runat="server" Height="26px" Width="127px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Select Group:&nbsp;&nbsp;
                <asp:DropDownList ID="drpGroup" runat="server" Height="33px" Width="132px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="listStudent" runat="server" Text="List Students" OnClick="listStudent_Click" />
            </td>
           
        </tr>
     <%--<tr>
         <td class="auto-style2">
                Select Module ID:&nbsp;&nbsp;
                <asp:DropDownList ID="drpModuleCode" runat="server" Height="26px" Width="127px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Year:&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="drpYear" runat="server" Height="33px" Width="132px">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="listStudents" runat="server" Text="List Students" OnClick="listStudents_Click" />
            </td>
         
     </tr>--%>
     <tr>
         <td class="auto-style2">
             <asp:Label ID="lbl" runat="server"></asp:Label>

         </td>
         <td>&nbsp;</td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td>
             <asp:GridView ID="GvAttendance" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                 <AlternatingRowStyle BackColor="White" />
                 <EditRowStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EFF3FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 <Columns>
                <asp:TemplateField HeaderText="Student ID">
                    <ItemTemplate>
                        <asp:Label ID="sID" Text='<%# Eval("STUDENTID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                    <ItemTemplate>
                        <asp:Label ID="sName" Text='<%# Eval("STUDENTNAME") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="drpstatusList" runat="server">
                            <asp:ListItem>Present</asp:ListItem>
                            <asp:ListItem>Late</asp:ListItem>
                            <asp:ListItem>Absent</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
         </asp:GridView>
             <asp:Button ID="btnSave" runat="server" Text="Save Report" OnClick="btnSave_Click" />
         </td>
         <td>
             &nbsp;</td>
        
        
     </tr>
    <%--<tr>
         <td>
             <asp:GridView ID="GvAttendanceByYear" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                 <AlternatingRowStyle BackColor="White" />
                 <EditRowStyle BackColor="#2461BF" />
                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#EFF3FB" />
                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 <Columns>
                <asp:TemplateField HeaderText="Student ID">
                    <ItemTemplate>
                        <asp:Label ID="sID" Text='<%# Eval("STUDENTID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Name">
                    <ItemTemplate>
                        <asp:Label ID="sName" Text='<%# Eval("STUDENTNAME") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="drpstatusList" runat="server">
                            <asp:ListItem>Present</asp:ListItem>
                            <asp:ListItem>Late</asp:ListItem>
                            <asp:ListItem>Absent</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
         </asp:GridView>
         <asp:Button ID="btnSaveLecture" runat="server" Text="Save Report" OnClick="btnSaveLecture_Click" />
         </td>
        
     </tr>--%>
    
</table>
</asp:Content>

