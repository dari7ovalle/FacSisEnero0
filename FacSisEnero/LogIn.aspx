<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="FacSisEnero.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" />
 
     
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/toastr.min.css" rel="stylesheet" />

    <script src="/js/jquery-3.3.1.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="/Scripts/toastr.min.js"></script>


</head>
<body>






     <div class="form-row justify-content-center">
       <br />
         <br />

            <div class="card mx-auto mt-5" >
                <div class="card-body">
                   
                    <h4 class="card-title mb-4 mt-1">Iniciar Sesión</h4>
                    <form runat="server">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Label">Email</asp:Label>
                            <asp:TextBox class="form-control" ID="emailTextBox" placeholder="micorreo@gmail.com" TextMode="Email" runat="server"></asp:TextBox>
                        </div>
                        <!-- form-group// -->
                        <div class="form-group">
                            
                            <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                            <asp:TextBox class="form-control" ID="passwordTextBox" placeholder="******" type="password" runat="server"></asp:TextBox>
                        </div>
                        
                        <!-- form-group// -->
                        <div class="form-group">
                            <asp:Button ID="iniciarSButton" type="submit" class="btn btn-primary btn-block" runat="server" Text="Iniciar Sesión" OnClick="iniciarSButton_Click"  />
                        </div>

                        <!-- form-group// -->
                    </form>
                </div>
            </div>
            <!-- card.// -->
    </div>
</body>
</html>
