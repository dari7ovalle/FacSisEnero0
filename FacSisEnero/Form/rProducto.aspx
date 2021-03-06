﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProducto.aspx.cs" Inherits="FacSisEnero.Form.rProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Esto es para que funcione el ajaxtoolkit--%> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="card">
        <div class="card-header text-uppercase text-center text-primary">Registro Producto</div>
        <div class="card-body">
            <div class="row">
                <div class="form-group col-md-2">
                    <asp:Label Text="Id" class="text-primary" runat="server"></asp:Label>
                    <asp:TextBox ID="ProductoIdTextBox" class="form-control input-group" AutoCompleteType="None" TextMode="Number" placeholder="0" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVProductoId" ValidationGroup="Buscar" ControlToValidate="ProductoIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group"  runat="server" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="FechaTextBox"  Format="yyyy-MM-dd" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:LinkButton ID="BuscarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                        <span> </span> Buscar
                    </asp:LinkButton>
                </div>

            </div>
            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Nombres"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNombre" ValidationGroup="Guardar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor Digite Solo Letras" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>
               
            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label Text="TipoPRoductoId" runat="server" />
                    <asp:DropDownList ID="TipoProductoDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
                        <asp:ListItem Text="Nombre" />
                    </asp:DropDownList>
                    <%--<asp:CustomValidator ID="CiudadCustomValidator" runat="server" ValidationGroup="Guardar" ControlToValidate="CiudadDropDownList" ErrorMessage="Seleccione Un Ciudad" Display="Dynamic" ForeColor="Red" OnServerValidate="CustomValidator_ServerValidate" ></asp:CustomValidator>--%>
                </div>
                
             
                 <div class="form-row">
                <div class="form-group col-md-2">
                    <label for="CostoTextBox">Costo</label>
                    <asp:TextBox ID="CostoTextBox" class="form-control input-sm" AutoCompleteType="Disabled" TextMode="Number" placeholder="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CostoTextBox" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CostoCustomValidator" runat="server" ControlToValidate="CostoTextBox" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" ErrorMessage="El Costo No Puede Ser Mayor Que El Precio" ></asp:CustomValidator>
                </div>
                    
            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Precio" runat="server" />
                    <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" MaxLength="11" placeholder="Precio" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Guardar" ControlToValidate="PrecioTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="PrecioTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>
         
                  <div class="form-group col-md-2">
                    <label for="InventarioTextBox">Inventario</label>
                    <asp:TextBox ID="InventarioTextBox" class="form-control input-sm" TextMode="Number" ReadOnly="true" runat="server" placeholder="0"></asp:TextBox>
                </div>
            </div>    
            <div class="card-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click"  />
                        <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ValidationGroup="Guardar" ID="GuadarButton" OnClick="GuadarButton_Click"  />
                        <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click"  />
                    </div>
                </div>
            </div>


        </div>
    </div>

</div>
    </div>
    </div>
</asp:Content>
