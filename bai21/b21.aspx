<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="b21.aspx.cs" Inherits="bai21.b21" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bai 21</title>
    <style>
        .content {
            width: 600px;
            height: 150px;
            margin: 20px 30%;
            border: 1px solid black;
            padding: 10px;
        }

        .flex {
            display: inline-block;
            margin-right: 15px;
        }

        .item {
            margin: 10px 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="item">
                <label>Lái xe</label>
                <asp:DropDownList ID="drpDriver" runat="server" OnSelectedIndexChanged="drpDriver_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
            </div>
            <div class="item">
                <label>Ngày</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RangeValidator ErrorMessage="Ngày đánh giá không hợp lệ." ControlToValidate="txtDate" ID="rvDate" runat="server" Type="Date" MinimumValue="01/01/2021" />
            </div>
            <table>
                <tr>
                    <td>Đánh giá</td>
                    <td>
                        <asp:RadioButtonList ID="rdbRate" runat="server" RepeatDirection="Horizontal" CssClass="flex">
                            <asp:ListItem Text="1 sao" Value="1" />
                            <asp:ListItem Text="2 sao" Value="2" />
                            <asp:ListItem Text="3 sao" Value="3" />
                            <asp:ListItem Text="4 sao" Value="4" />
                            <asp:ListItem Text="5 sao" Value="5" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ErrorMessage="Chưa đánh giá" ControlToValidate="rdbRate" runat="server" ID="RequiredFieldValidator1" />
                    </td>
                </tr>
            </table>

            <div style="float: right; margin-right: 20px;">
                <asp:Button ID="btnExecute" runat="server" Text="Thực hiện" OnClick="btnExecute_Click"  />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" OnClick="btnCancel_Click" />
            </div>
            <div>
                <asp:ValidationSummary runat="server" ForeColor="Red" />
            </div>
        </div>
    </form>
</body>
</html>
