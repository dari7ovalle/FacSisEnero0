<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rClientes.aspx.cs" Inherits="FacSisEnero.Css.Form.rClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../bootstrap.min.css" rel="stylesheet" />
    <script src="../../js/jquery.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <div class="panel panel-primary">
    <title>Registro De Cliente</title>
    <style type="text/css">
        #form1 {
            height: 517px;
            width: 273px;
        }
    </style>
</head>
<body style="width: 267px; height: 556px;">

    <form id="form1" runat="server">
         <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="form-group">

        <asp:TextBox ID="ClienteTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        CiudadId<br />
        <asp:DropDownList ID="ClienteIdDropDownList" CssClass="form-control" runat="server">
        </asp:DropDownList>
         <br />
        Nombre<br />
        <asp:TextBox ID="NombresTextBox"  CssClass="form-control" runat="server" ></asp:TextBox>
        
        Apellido<br />

        <asp:TextBox ID="ApellidosTextBox" CssClass="form-control" runat="server"></asp:TextBox>

        <br />
        <br />
        Cedula<br />
        <asp:TextBox ID="CedulaTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="DireccionTextBox" CssClass="form-control" runat="server"></asp:TextBox>

        <br />
        Celular<br />
        <asp:TextBox ID="CelularTextBox" CssClass="form-control"  runat="server"></asp:TextBox>

        Telefono<br />
        <asp:TextBox ID="TelefonoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" />
        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />

        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" />
    </form>
</body>
</html>
