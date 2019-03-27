<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cProductos.aspx.cs" Inherits="FacSisEnero.Consultas.cProductos" %>

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
             
            <button type="button" class="btn btn-outline-info mt-4" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>

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
 <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" style="max-width:1000px!important;min-width:900px!important">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Reporte de Producto</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div id="div1">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <rsweb:ReportViewer ID="ProductoReportViewer1" runat="server" ProcessingMode="Remote" Height="718px" Width="1000px">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                            </rsweb:ReportViewer>
                        </div>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
