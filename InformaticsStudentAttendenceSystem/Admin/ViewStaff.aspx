<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewStaff.aspx.cs" Inherits="InformaticsStudentAttendenceSystem.Admin.ViewStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tbl">
    <tr>
        <td class="tblhead">
            Staff Report</td>
    </tr>
    
    <tr>
        <td class="style3">
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="GvStaff" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Photo"> <ItemTemplate>
                    <asp:Image runat="server" ID="imgg" ImageUrl='<%#Eval("Photo") %>' Width="50px" Height="50px" />
                    </ItemTemplate>                 
                    </asp:TemplateField>
                    <%--<asp:ImageField DataImageUrlField="Photo" HeaderText="Photo"  Width="50px" Height="40px" />--%>
                    <asp:BoundField DataField="StaffName" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                    <asp:BoundField DataField="Qualification" HeaderText="Qualification" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>