<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.Master" AutoEventWireup="true" CodeBehind="StudentReport.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Staff.StudentReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 116%;
            border: solid 1px #6699ff;
            margin-right: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
    <tr>
        <td class="tblhead" style="text-align:center">
            Manage Student</td>
    </tr>
    <tr>

        <td>
            
             &nbsp; Select Course Name:&nbsp;
            
             <asp:DropDownList ID="drpCourseName" runat="server" CssClass="txt" Height="25px" Width="145px">
                                
             </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
          <asp:GridView ID="GvStudent" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="StudentId" HeaderText=" ID" />
                  <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                  <asp:BoundField DataField="Address" HeaderText="Address" />
                  <asp:BoundField DataField="Email" HeaderText="Email" />
                  <asp:BoundField DataField="Gender" HeaderText="Gender" />
                  <asp:BoundField DataField="EnrollDate" HeaderText="Enroll Date" />
                  <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
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
          <asp:GridView ID="GvSearch" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="StudentId" HeaderText=" ID" />
                  <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                  <asp:BoundField DataField="Address" HeaderText="Address" />
                  <asp:BoundField DataField="Email" HeaderText="Email" />
                  <asp:BoundField DataField="Gender" HeaderText="Gender" />
                  <asp:BoundField DataField="EnrollDate" HeaderText="Enroll Date" />
                  <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
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
