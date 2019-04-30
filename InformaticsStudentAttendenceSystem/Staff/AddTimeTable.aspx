<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="AddTimeTable.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Staff.AddTimeTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
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
                ADD TIME TABLE</td>
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
            <td class="auto-style3">&nbsp;Day:</td>
            <td>
                <asp:TextBox ID="txtDay" runat="server" CssClass="txt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Time:</td>
            <td>
                <asp:TextBox ID="txtTime" runat="server" CssClass="txt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Class type:</td>
            <td>
                <asp:TextBox ID="txtClass" runat="server" CssClass="txt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Year:</td>
            <td>
                <asp:DropDownList ID="drpYear" runat="server" CssClass="auto-style1" Height="25px" Width="145px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Course:</td>
            <td>
                <asp:DropDownList ID="drpCourse" runat="server" CssClass="auto-style1" Height="25px" Width="145px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Intake</td>
            <td>
                <asp:TextBox ID="txtIntake" runat="server" CssClass="txt" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Module Code</td>
            <td>
                <asp:DropDownList ID="drpModulecode" runat="server" CssClass="txt" Height="25px" Width="145px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Module Title</td>
            <td>
                <asp:DropDownList ID="drpModuletitle" runat="server" CssClass="txt" Height="25px" Width="145px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Lecturer</td>
            <td>
                <asp:TextBox ID="txtLecturer" runat="server" CssClass="txt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Group</td>
            <td>
                <%--<asp:TextBox ID="txtGroup" runat="server" CssClass="txt"></asp:TextBox>--%>
                <asp:DropDownList ID="drpGroup" runat="server" CssClass="txt" Height="25px" Width="145px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Room</td>
            <td>
                <asp:TextBox ID="txtRoom" runat="server" CssClass="txt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Label ID="lbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="btnTimetable" runat="server" CssClass="btn" OnClick="btnTimetable_Click" Text="ADD" Width="94px" />
            </td>
        </tr>
        <tr>
            <td> &nbsp;</td>
           
            <td> &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
     </table>
     
          <asp:GridView ID="GvTimeTable" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCancelingEdit="GvTimeTable_RowCancelingEdit" OnRowDeleting="GvTimeTable_RowDeleting" OnRowEditing="GvTimeTable_RowEditing" OnRowUpdating="GvTimeTable_RowUpdating">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Day">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDay" runat="server" Text='<%# Bind("Day") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDay" runat="server" Text='<%# Bind("Day") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTime" runat="server" Text='<%# Bind("Time") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTime" runat="server" Text='<%# Bind("Time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Class Type">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtClassType" runat="server" Text='<%# Bind("ClassType") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClassType" runat="server" Text='<%# Bind("ClassType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Year">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtYear" runat="server" Text='<%# Bind("Year") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblYear" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Intake">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtIntake" runat="server" Text='<%# Bind("Intake") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblIntake" runat="server" Text='<%# Bind("Intake") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Module Code">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtModuleCode" runat="server" Text='<%# Bind("ModuleCode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblModuleCode" runat="server" Text='<%# Bind("ModuleCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Module Title">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtModuleTitle" runat="server" Text='<%# Bind("ModuleTitle") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblModuleTitle" runat="server" Text='<%# Bind("ModuleTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lecturer">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtLecturer" runat="server" Text='<%# Bind("Lecturer") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLecturer" runat="server" Text='<%# Bind("Lecturer") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Group Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtGroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRoom" runat="server" Text='<%# Bind("Room") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRoom" runat="server" Text='<%# Bind("Room") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Action" ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
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
                </asp:GridView>
                
           
</asp:Content>
