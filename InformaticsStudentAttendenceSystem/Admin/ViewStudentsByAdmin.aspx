<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewStudentsByAdmin.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Admin.ViewStudentsByAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl">
    <tr>
        <td class="tblhead" style="text-align:center">
            Manage Student</td>
    </tr>
    
    <tr>
        <td class="style3">
            <br />
            <asp:Label ID="lbl" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
          <asp:GridView ID="GvStudent" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCancelingEdit="GvStudent_RowCancelingEdit" OnRowDeleting="GvStudent_RowDeleting" OnRowEditing="GvStudent_RowEditing" OnRowUpdating="GvStudent_RowUpdating">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:TemplateField HeaderText="Student ID">
                      <EditItemTemplate>
                           <asp:Label ID="lblStudentId" runat="server" Text='<%# Bind("StudentId") %>'></asp:Label>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblStudentId" runat="server" Text='<%# Bind("StudentId") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Student Name">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtStudentName" runat="server" Text='<%# Bind("StudentName") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblStudentName" runat="server" Text='<%# Bind("StudentName") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Address">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtStudentAdd" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblStudentAdd" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Mobile">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtStudentMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblStudentMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Email">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtStudentEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="lblStudentEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
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
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
