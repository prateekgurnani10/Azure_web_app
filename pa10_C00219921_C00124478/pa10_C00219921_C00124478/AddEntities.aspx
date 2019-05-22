<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEntities.aspx.cs" Inherits="pa10_C00219921_C00124478.AddEntities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Add Entities<br />
            <br />
            <br />
            <br />
            Enter the type of the book (Fiction or Non Fiction)
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 18px" Width="272px"></asp:TextBox>
            <br />
            <br />
            Enter the audience of the book (child or young adult)&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 18px" Width="272px"></asp:TextBox>
            <br />
            <br />
            Enter the media of the of the book (audio, print, electronic)
            <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 18px" Width="272px"></asp:TextBox>
            <br />
            <br />
            Enter the author of the book&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 18px" Width="272px"></asp:TextBox>
            <br />
            <br />
            Enter the title of the book&nbsp;
            <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 18px" Width="272px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
        </div>
    </form>
</body>
</html>
