<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cCiudades.aspx.cs" Inherits="FacSisEnero.Consultas.cCiudades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <div class="col-md-2">
                    <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>CiudadId</asp:ListItem>
                        <asp:ListItem>Nombres</asp:ListItem>
                    </asp:DropDownList>
                </div>
        <div class = " col-md-6 ">
            <asp:TextBox ID="FiltroTextBox" runat="server" CssClass = " form-control input-sm "></asp:TextBox>
        </div>
        <div class=" col-md-1 col-ms-2 col-xs-4">

            <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
            <div class=" col-md-12">
        <asp:GridView ID="DatosGridView" runat="server" class=" table table-condensed table-borered table-responsive " CellPadding="4" ForeColor="#333333" GridLines="None"></asp:GridView>

            </div>
    </form>
    
    </div>
</body>
</html>
