<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfigEditor.aspx.cs" Inherits="ConfigEditor" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><asp:Label runat="server" ID="lblInfo" Text="" ForeColor="red"></asp:Label></p>
            <p>
                <asp:DropDownList runat="server" ID="dplDir" Width="100px" OnSelectedIndexChanged="dplDir_SelectedIndexChanged" AutoPostBack="True"/>
            </p>
            <p>
                <asp:TextBox ID="txtEditor" runat="server" Width="500px" Height="600px" TextMode="MultiLine"></asp:TextBox>
            </p>
            <p><asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_OnClick"/></p>
        </div>
    </form>
</body>
</html>
