<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teacher.Master" AutoEventWireup="true" CodeBehind="StudentIndividualReport.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Teacher.StudentIndividualReport" %>
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
            INDIVIDUAL ATTENDANCE SYSTEM</td>
    </tr>
    <tr>
        <td class="auto-style2">
        </td>
    </tr>
       <tr>
            <td class="auto-style2">
                Select Student ID:&nbsp;&nbsp;
                <asp:DropDownList ID="drpStudentId" runat="server" Height="26px" Width="127px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="drpIndividualReportType" runat="server" Height="26px" Width="127px">
                    <asp:ListItem>SELECT</asp:ListItem>
                    <asp:ListItem>Daily</asp:ListItem>
                    <asp:ListItem>Weekly</asp:ListItem>
                    <asp:ListItem>Monthly</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="listStudentReport" runat="server" Text="Show Report" OnClick="listStudentReport_Click" />
            </td>
           
        </tr>
     
     <tr>
         <td class="auto-style2">
             <asp:Label ID="lbl" runat="server"></asp:Label>

         </td>
         <td>&nbsp;</td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td>
             <asp:GridView ID="GvIndividualReport" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
         <td>
             &nbsp;</td>
        
        
     </tr>
    
    
</table>
</asp:Content>
