<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCiudades.aspx.cs" Inherits="FacSisEnero.Form.rCiudades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card card-register mx-auto mt-5">
        <div class="card-header text-uppercase text-center text-primary">Registro Ciudades</div>
        <div class="card-body">
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:Label Text="Ciudad Id" class="text-primary" runat="server" />
                    <asp:TextBox ID="CiudadIdTextBox" class="form-control input-group" TextMode="Number" placeholder="0" runat="server" />
                </div>
                <div class="form-group">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span> Buscar  </asp:LinkButton>
                </div>
            </div>

            <div class="form-row justify-content-center">
                <div class="form-group col-md-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>


        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">
                    <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ValidationGroup="Guardar" ID="GuadarButton" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
