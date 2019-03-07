<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="FacSisEnero.Form.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card card-register mx-auto mt-5">
            <div class="card-header text-uppercase text-center text-primary">Venta</div>
            <div class="card-body">
                <div class="form-row">
                    <div class="form-group col-md-1">
                        <asp:Label Text="Id" class="text-primary" runat="server" />
                        <asp:TextBox ID="VentaIdTextBox" class="form-control input-sm" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVId" ValidationGroup="Buscar" ControlToValidate="VentaIdTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label Text="Fecha" runat="server" />
                        <asp:TextBox ID="FechaTextBox" class="form-control input-sm" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-lg-1 p-0">
                        <asp:LinkButton ID="BuscarLinkButton" ValidationGroup="Buscar" CssClass="btn btn-outline-info mt-4" runat="server">
                                <span class="fas fa-search"></span>
                                     Buscar
                        </asp:LinkButton>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Label Text="Cliente" runat="server" />
                            <asp:DropDownList ID="ClienteDropDownList" AutoPostBack="true" class="form-control input-sm" runat="server">
                                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CVClientes" runat="server" ErrorMessage="Seleccione Un Cliente" ControlToValidate="ClienteDropDownList" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVClientes_ServerValidate"></asp:CustomValidator>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <asp:Label Text="Configuraciones" runat="server" />
                                <asp:DropDownList ID="ConfiguracionesIdDropDownList1" AutoPostBack="true" class="form-control input-sm" runat="server">
                                    <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                                </asp:DropDownList>
                                <asp:CustomValidator ID="CVCConfiguracionesId" runat="server" ErrorMessage="Seleccione Un Configuraciones" ControlToValidate="ConfiguracionesIdDropDownList1" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVClientes_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div class="form-row">
                        <div class="form-group col-md-3">
                            <asp:Label Text="Usuarios" runat="server" />
                            <asp:DropDownList ID="UsuariosDropDownList1" AutoPostBack="true" class="form-control input-sm" runat="server">
                                <asp:ListItem Selected="True">[Seleccione]</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Seleccione Un Usuarios" ControlToValidate="ConfiguracionesIdDropDownList1" ValidationGroup="Guardar" ForeColor="Red" Display="Dynamic" OnServerValidate="CVClientes_ServerValidate"></asp:CustomValidator>
                        </div> 
                            <div class="form-row">
                                <div class="form-group col-md-5 col-md-offset-4">
                                    <asp:Label ID="Label8" runat="server" Text="Tipo de venta"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="tipoVentaDropDownList" runat="server">
                                        <asp:ListItem>Devito</asp:ListItem>
                                        <asp:ListItem>Credito</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">

                                <div class="form-group col-xs-10 col-md-5">
                                    <asp:Label ID="Label5" runat="server" Text="TotalVenta:"></asp:Label>
                                    <asp:TextBox ID="TotalVentaTextBox1" type="text" runat="server" TextMode="Number" ReadOnly="true" CssClass="form-control " placeholder="0.00"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-md-1">
                                <asp:Label Text="Precio" runat="server" />
                                <asp:TextBox ID="PrecioTextBox" class="form-control input-sm" AutoPostBack="true" ReadOnly="true" TextMode="Number" runat="server" placeholder="0"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-1">
                                <asp:Label Text="Cantidad" runat="server" />
                                <asp:TextBox ID="CantidadTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" placeholder="0" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="No Hay Cantidad"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CVCantidad" ForeColor="Red" Display="Dynamic" runat="server" ValidationGroup="Agregar" ControlToValidate="CantidadTextBox" ErrorMessage="Cantidad Invalida" OnServerValidate="CVCantidad_ServerValidate"></asp:CustomValidator>

                            </div>




                            <div class="col-lg-1 p-0">
                                <asp:LinkButton ID="LinkButton" CssClass="btn btn-outline-success mt-4" ValidationGroup="Agregar" runat="server" OnClick="LinkButton_Click">
                                <span class="fa fa-plus"></span>
                                     Add
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <asp:GridView ID="DetalleGridView" CssClass=" col-md-offset-4 col-sm-offset-4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="244px" AutoGenerateColumns="true">
                                <AlternatingRowStyle BackColor="White" />

                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            <div class="form-row">
                <%--Monto--%>
                <div class="form-group col-md-3">
                    <label for="MontoTextBox">Monto</label>
                    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">--%>
                    <%--<ContentTemplate>--%>
                    <asp:TextBox ID="MontoTextBox" class="form-control input-sm" AutoPostBack="true" AutoCompleteType="Disabled" TextMode="Number" runat="server" OnTextChanged="MontoTextBox_TextChanged"></asp:TextBox>
                    <%--</ContentTemplate>--%>
                    <%--</asp:UpdatePanel>--%>
                </div>

            </div>
    </asp:Content>
