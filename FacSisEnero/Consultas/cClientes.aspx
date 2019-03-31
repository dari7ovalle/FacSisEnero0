<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cClientes.aspx.cs" Inherits="FacSisEnero.Consultas.cClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="bg-dark p-5 text-center">
            <h1 class="display-4 text-warning">Cliente</h1>
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
                        <asp:ListItem>ClienteId </asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                        <asp:ListItem>Nombres</asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
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
                    <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-info mt-4" OnClick="ImprimirLinkButton_Click" runat="server">
                            <span class="fa fa-print"></span>
                            Imprimir
                    </asp:LinkButton>
                </div>


            </div>

        </div>
    </div>


    <div class="form-row justify-content-center">
        <asp:GridView ID="ClienteGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None ">
            <AlternatingRowStyle BackColor="SkyBlue" />
            <Columns>
                <asp:BoundField DataField="ClienteId" HeaderText="Cliente Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos " />
                <asp:BoundField DataField="CiudadId" HeaderText="Ciudad" />
                <asp:BoundField DataField="Cedula" HeaderText="Cedula " />


            </Columns>


        </asp:GridView>

    </div>


</asp:Content>
