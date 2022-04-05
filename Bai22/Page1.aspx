<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="Bai22.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>DANH MỤC LOẠI SÁCH</h2>
            <asp:GridView runat="server" ID="gvBookType" Width="40%" CellPadding="4" ForeColor="Orange"></asp:GridView>
            <asp:Button runat="server" Text="Tiếp tục" style="margin-top: 10px"/>
        </div>
    </form>
</body>
</html>
