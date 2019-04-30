<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TeacherReport.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Admin.TeacherReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            border: solid 1px #ccc;
            padding-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="tbl">
   <tr>
        <td class="tblhead" style="text-align:center">
             Teacher Report</td>
    </tr>
    <tr>

        <td>
            &nbsp; Select Module Name:&nbsp;
            
             <asp:DropDownList ID="drpModuleName" runat="server" CssClass="auto-style1" Height="24px" Width="149px">
                                
             </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;Select Teacher Type:&nbsp;
            
             <asp:DropDownList ID="drpTeacherType" runat="server" CssClass="txt" Height="25px" Width="145px">
                                
             </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            
        </td>
        
    </tr>
         <tr>
             <td align="center">
            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="73px" OnClick="btnSearch_Click" />
        </td>
         </tr>
    <tr>
        <td class="style3">
            <br />
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GvTeacherReport" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GvTeacher_RowCancelingEdit" OnRowDeleting="GvTeacher_RowDeleting" OnRowEditing="GvTeacher_RowEditing" OnRowUpdating="GvTeacher_RowUpdating">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                           <asp:Label ID="lblID" runat="server" Text='<%# Bind("TeacherId") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("TeacherId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtname" runat="server" Text='<%# Bind("TeacherName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%# Bind("TeacherName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MobileNo">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtmobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblmobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtemail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblemail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Module">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtmassigned" runat="server" Text='<%# Bind("ModuleAssigned") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblmassigned" runat="server" Text='<%# Bind("ModuleAssigned") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teaching Hours">
                        <EditItemTemplate>
                            <asp:TextBox ID="txttHrs" runat="server" Text='<%# Bind("TeachingHrs") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbltHrs" runat="server" Text='<%# Bind("TeachingHrs") %>'></asp:Label>
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
        </td>
    </tr>
         <tr>
             <td>
                 <asp:GridView ID="GvTeacherType" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                 </asp:GridView>
             </td>
         </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
