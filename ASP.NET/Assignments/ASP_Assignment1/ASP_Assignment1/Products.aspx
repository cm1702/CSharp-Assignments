<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ASP_Assignment1.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Product Selection</title>

</head>

<body>

    <form id="form1" runat="server">

        <div style="margin: 50px;">

            <h2>Select a Product</h2>

            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true"

                OnSelectedIndexChanged="ddlProducts_1">

            </asp:DropDownList><br /><br />

            <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />

            <br /><br />

            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" /><br /><br />

            <asp:Label ID="lblPrice" runat="server" Font-Bold="True" ></asp:Label>

        </div>

    </form>

</body>

</html>