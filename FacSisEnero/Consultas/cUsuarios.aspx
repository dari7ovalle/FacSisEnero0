<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="FacSisEnero.Consultas.cUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
           <div class="container">
        <div class="bg-dark p-5 text-center">
            <h1 class="display-4 text-warning">  Usuarios</h1>
        </div>
    </div>
    <div class="form-row justify-content-center">
        
            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" class="text-primary" runat="server" />
                 <asp:DropDownList ID="BuscarDropDownList" CssClass="form-control " runat="server">
                             <asp:ListItem>Todo</asp:ListItem>
                             <asp:ListItem>UsuarioId</asp:ListItem>
                             <asp:ListItem>Nombre</asp:ListItem>
                         </asp:DropDownList>
                 
             
            </div>

            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
                <asp:TextBox runat="server" ID="FiltroTextBox" CssClass="form-control " placeholder="UsuarioId"/>
            </div>
            <div class="col-lg-1 p-0" >
               <asp:Button Text="Buscar"  for="FiltroTextBox" runat="server" ID="BuscarButton" CssClass="btn btn-primary" OnClick="BuscarButton_Click" />
                <span class="fas fa-search"></span>
              
            </div>
         <div class="col-lg-1 p-0">
            <asp:LinkButton ID="ImprimirLinkButton1" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="ImprimirLinkButton1_Click">
                <span class="fas fa-search"></span>
                 Imprimir
            </asp:LinkButton>
        </div>

        </div>
    
        <div class="form-group">
            <div class="form-row justify-content-center">
                <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="SkyBlue" />
                    <Columns>
                        <asp:BoundField DataField="UsuarioId" HeaderText="Usuario Id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                         <asp:BoundField DataField="NombreUsuario" HeaderText="NombreUsuario" />
                         <asp:BoundField DataField="Email" HeaderText="Email" />
                         <asp:BoundField DataField="Clave" HeaderText="Clave" />
                         <asp:BoundField DataField="ComprobarClave" HeaderText="ComprobarClave" />
                       <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                         <asp:BoundField DataField="Celular" HeaderText="Celular " />
                         <asp:BoundField DataField="Fecha" HeaderText="Fecha " />
                         <asp:BoundField DataField="TipoUsuario" HeaderText="TipoUsuario " />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
                
                     

                    
</asp:Content>
