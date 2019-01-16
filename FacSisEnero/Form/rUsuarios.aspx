<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="FacSisEnero.Form.rUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="../js/jquery.js"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>

    <title>Registro de Usuarios</title>
</head>
<body>

    <form id="form1"  runat="server" >
        
        <div class="container">
            <h3>Registro Usuario</h3>
<br />
 <br />
 <br />
 <br />
 

  

  <div class="row">
   
    <div class="col-md-5 col-xs-5">
                     <asp:TextBox ID="UsuarioIdTextBox" runat="server" placeholder="Ingrese un Id" CssClass="form-control" ></asp:TextBox>
                                               
                          </div>
    <div class="col-md-5 col-xs-5">
     <asp:TextBox ID="BuscarTextBox" runat="server" class="btn btn-primary mb-2" Text="Buscar" ></asp:TextBox>
                          </div>
  </div>
</div>
    
                        
     
                       
                      
                      
                             
                         
     
 
                       <div class="form-group">
                        <div class="col-xs-2 col-md-2">
                            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                        </div>
                        <div class="col-xs-10 col-md-10">
                            <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control " placeholder="Ingrese un Nombre"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-2 col-md-2">
                            <asp:Label ID="Label6" runat="server" Text="Contrasena:"></asp:Label>
                        </div>
                        <div class="col-xs-10 col-md-10">
                            <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control " placeholder="Ingrese una Contrasena" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-2 col-md-2">
                            <asp:Label ID="Label7" runat="server" Text="TipoUsuario:"></asp:Label>
                        </div>
                        <div class="col-xs-10 col-md-10">
                            <asp:TextBox ID="TipoUsuarioTextBox" runat="server" CssClass="form-control " placeholder="Ingrese tipo de usuario"></asp:TextBox>
                        </div>
                    </div>
                      <asp:Button ID="NuevoButton" runat="server" Text="Nuevo"  class="btn btn-outline-secondary"  />
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar"  class="btn btn-success" />
                    <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger"  />
                  

               
  
        
        

  
    </form>
</body>
</html>
