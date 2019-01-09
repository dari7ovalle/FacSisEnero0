﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rCiudad.aspx.cs" Inherits="FacSisEnero.Css.Form.rCiudad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link href="../bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="../js/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="container ">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-2 col-md-2">
                                <asp:Label ID="Label1"  runat="server" Text="ID"></asp:Label>
                            </div>
                               <div class="form-group">
                            <div class="col-sm-9 col-md-9">
                                <asp:TextBox ID="IdciudadTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class=" col-sm-3 col-md-3">
                                <asp:Button ID="BuscarBotton"  CssClass="btn btn-primary" Text="Buscar"  runat="server" OnClick="BuscarBotton_Click" />
                            </div> 
                            </div>
                                                
                      
                             
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>

                            <asp:TextBox ID="NombreTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="El Nombre es un campo requerido" ControlToValidate="NombreTextBox"></asp:RequiredFieldValidator>
                            <asp:Button ID="GuardarButton" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="GuardarButton_Click" />
                            <asp:Button ID="ButtonNuevo" runat="server" CssClass="btn-outline-info" Text="Nuevo" OnClick="ButtonNuevo_Click" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                        </div>
                    </div>
                      </div>
                </div>
            </div>
      
        </div>
    </form>
</body>
</html>

