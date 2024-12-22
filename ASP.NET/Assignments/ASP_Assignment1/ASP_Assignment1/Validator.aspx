<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ASP_Assignment1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Validator</title>

    <style>

        .error { color: red; }

        .success { color: green; }

    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div style="margin: 50px;">

            <h2>User Information</h2>

            <label for="txtName">Name:</label>

            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />

            <label for="txtFamilyName">Family Name:</label>

            <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox><br />

            <label for="txtAddress">Address:</label>

            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />

            <label for="txtCity">City:</label>

            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />

            <label for="txtZip">Zip Code:</label>

            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox><br />

            <label for="txtPhone">Phone:</label>

            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><br />

            <label for="txtEmail">E-mail:</label>

            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />

            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="checkBtn" /><br />

            <br />

            <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

        </div>

    </form>

</body>

</html>


