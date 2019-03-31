<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rIventario.aspx.cs" Inherits="FacSisEnero.Form.rIventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%--Esto es para que funcione el ajaxtoolkit--%> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="card">
        <div class="card-header text-uppercase text-center text-primary">Registro Inventario</div>
        <div class="card-body">
            <div class="row">
                <div class="form-group col-md-2">
                    <asp:Label Text="Id" class="text-primary" runat="server"></asp:Label>
                    <asp:TextBox ID="InventarioIdTextBox" class="form-control input-group" AutoCompleteType="None" TextMode="Number" placeholder="0" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVClienteId" ValidationGroup="Buscar" ControlToValidate="InventarioIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Fecha" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group"  runat="server" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="FechaTextBox"  Format="yyyy-MM-dd" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:LinkButton ID="BuscarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click" >
                        <span> </span> Buscar
                    </asp:LinkButton>
                </div>

            </div>
           <%-- <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="NombreTextBox" class="form-control input-sm" AutoCompleteType="Disabled" runat="server" placeholder="Nombres"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNombre" ValidationGroup="Guardar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NombreTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor Digite Solo Letras" ValidationExpression="(^[a-zA-Z'.\s]{1,20}$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>--%>
                </div>
            <div class="row">
                <div class="form-group col-md-3">
                    <asp:Label Text="ProductoId" runat="server" />
                    <asp:DropDownList ID="ProductoIdDropDownList" class="form-control input-sm" runat="server">
                        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
                        <asp:ListItem Text="Nombre" />
                    </asp:DropDownList>
                    <%--<asp:CustomValidator ID="CiudadCustomValidator" runat="server" ValidationGroup="Guardar" ControlToValidate="CiudadDropDownList" ErrorMessage="Seleccione Un Ciudad" Display="Dynamic" ForeColor="Red" OnServerValidate="CustomValidator_ServerValidate" ></asp:CustomValidator>--%>
                </div>
                </div>
               

            <div class="row">
                <div class="form-group  col-md-3">
                    <asp:Label ID="Label5" runat="server" Text="Cantidad:"></asp:Label>
                    <asp:TextBox ID="CantidadTextBox1" type="text" runat="server" TextMode="Number" CssClass="form-control " placeholder="Ingrese un Cantidad " minlength="1" MaxLength="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Guardar" ControlToValidate="CantidadTextBox1" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="CantidadTextBox1" ForeColor="Red" Display="Dynamic" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                </div>

               </div>

            <div class="card-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button Text="Nuevo" class="btn btn-outline-info btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-outline-success btn-md" runat="server" ValidationGroup="Guardar" ID="GuadarButton" OnClick="GuadarButton_Click1"  />
                        <asp:Button Text="Eliminar" class="btn btn-outline-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>
