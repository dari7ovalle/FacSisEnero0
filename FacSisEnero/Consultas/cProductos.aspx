<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CProductos.aspx.cs" Inherits="FacSisEnero.Consultas.CProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

    <div class="container">
        <div class="bg-dark p-5 text-center">
            <h1 class="display-4 text-warning">Producto</h1>
        </div>
    </div>
    <div class="form-row justify-content-center">
        <div class="form-row">

            <div class="form-row justify-content-center">
                <div class="form-group ">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
                <div class="form-group ">
                    <asp:Label Text="HastaTextBox" runat="server"></asp:Label>
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                </div>
            </div>

            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" class="text-primary" runat="server" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>ProductoId</asp:ListItem>
                    <asp:ListItem>Fecha</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>

                </asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" OnClick="BuscarLinkButton_Click"     runat="server">
                <span class="fa fa-search"></span>
                 Buscar
                    </asp:LinkButton>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-info mt-4"  runat="server" OnClick="ImprimirLinkButton_Click">
                            <span class="fa fa-print"></span>
                            Imprimir
                    </asp:LinkButton>
                </div>

               
              
            </div>
        </div>
       
        


    <div class="form-row justify-content-center">
        <asp:GridView ID="ProductoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None ">
            <AlternatingRowStyle BackColor="SkyBlue" />
            <Columns>
                <asp:BoundField DataField="ProductoId" HeaderText="Producto Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Costo" HeaderText="Costo" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="TipoProductoId" HeaderText="TipoProductoId" />
             

            </Columns>


        </asp:GridView>

    </div>

</asp:Content>
