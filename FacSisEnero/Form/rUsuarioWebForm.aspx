<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarioWebForm.aspx.cs" Inherits="FacSisEnero.Form.rUsuarioWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">
        <h3>Registro Usuario</h3>
        <br />
        <br />
        <br />
        <br />


        <div class="row">

            <div class=" col- col-sm- 5 col-md-5  col-xs-5">
                <asp:TextBox ID="UsuarioIdTextBox" runat="server" placeholder="Ingrese un Id" CssClass="form-control"></asp:TextBox>

            </div>
            <div class=" col- col-sm- 3 col-md-3 col-xs-3">
                <asp:Button ID="BuscarButton" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />

            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-2 col-md-2">
            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
        </div>
        <div class="col-xs-10 col-md-5">
             <asp:TextBox ID="NombreTextBox"  required="required" type="text"  runat="server" CssClass="form-control " placeholder="Ingrese un Nombre"  minlength="5" maxlength="40"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="rfvTextBox" runat="server" ControlToValidate="NombreTextBox" ErrorMessage="Campo presupuesto obligatorio" ForeColor="Red" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo Monto obligatorio">Por favor llenar el campo ></asp:RequiredFieldValidator>
           --%> </div>
    </div>
    <div class="form-group">
        <div class="col-xs-2 col-md-2">
            <asp:Label ID="Label6" runat="server" Text="Contrasena:"></asp:Label>
        </div>
        <div class="col-xs-10 col-md-5">
            <asp:TextBox ID="ContrasenaTextBox"  required="required" runat="server" CssClass="form-control " placeholder="Ingrese una Contrasena"></asp:TextBox>
        </div>
        <div class="form-group">
        <div class="col-xs-2 col-md-2">
            <asp:Label ID="Labe2" runat="server" Text="Contraceña:"></asp:Label>
        </div>
        <div class="col-xs-10 col-md-5">
            <asp:TextBox ID="ConfirmarTextBox1"  required="required"  runat="server" CssClass="form-control " placeholder="Confirmar Contraceña "></asp:TextBox>
        </div>
      
    </div>
  
        <div class="form-group">
                        <label class="radio-inline">
                            <input type="radio"   required="required" name="optionsRadiosInline" id="HombreRadioButton" runat="server" value="Hombre"/>Hombre
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="optionsRadiosInline"  id="MujerRadioButton" runat="server" value="Mujer"/>Mujer
                        </label>
                    </div>
                
            </div>

 
            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-outline-secondary" OnClick="NuevoButton_Click" />
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" OnClick="GuardarButton_Click" />
            <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="EliminarButton_Click" />
</asp:Content>
