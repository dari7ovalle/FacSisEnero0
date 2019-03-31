using BLL;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Form
{
    public partial class rClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombos();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
                    var cliente = repositorio.Buscar(id);

                    if (cliente == null)
                        Utils.ShowToastr(this, "Error  ", "Error", "error");
                    else
                        LlenaCampos(cliente);
                }
            }

        }
        private void LlenaCampos(Clientes cliente)
        {
            ClienteIdTextBox.Text = cliente.ClienteId.ToString();
            FechaTextBox.Text = cliente.Fecha.ToString("yyyy-MM-dd");//para traer la fecha se debe pasa un toString de atras para delante (ano-mes-dia)
            NombreTextBox.Text = cliente.Nombres;
            ApellidoTextBox.Text = cliente.Apellidos;
            DireccionTextBox.Text = cliente.Direccion;
            CelularTextBox1.Text = cliente.Celular;
            CedulaTextBox.Text = cliente.Cedula;
            CiudadDropDownList.SelectedIndex = cliente.CiudadId;
            TelefonoTextBox.Text = cliente.Telefono;
          
        }
        private Clientes LlenaClase(Clientes cliente)
        {
          
            cliente.ClienteId = Utils.ToInt(ClienteIdTextBox.Text);
            cliente.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            cliente.Nombres = NombreTextBox.Text;
            cliente.Apellidos = ApellidoTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Cedula = CedulaTextBox.Text;
            cliente.CiudadId = CiudadDropDownList.SelectedIndex;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Celular = CelularTextBox1.Text;

            return cliente;
        }
        void LlenarCombos()
        {
            RepositorioBase<Ciudades> repositorio = new RepositorioBase<Ciudades>();
            CiudadDropDownList.DataSource = repositorio.GetList(c => true);
            CiudadDropDownList.DataValueField = "CiudadId";
            CiudadDropDownList.DataTextField = "Nombres";
            CiudadDropDownList.DataBind();
        }
        private void Limpiar()
        {
            ClienteIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            CiudadDropDownList.SelectedIndex = 0;
            TelefonoTextBox.Text = "";
            CelularTextBox1.Text = " ";
           
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Clientes> repositorio = new BLL.RepositorioBase<Clientes>();
            Clientes clientes = new Clientes();
            bool paso = false;
            
            LlenaClase(clientes);

            if (IsValid)
            {
                if (clientes.ClienteId == 0)
                {
                    if (paso = repositorio.Guardar(clientes))

                        Utils.ShowToastr(this, "saved successfully", "Success", "success");
                    
                    else
                    {
                        Utils.ShowToastr(this, "No se pudo Guardar", "Error", "error");
                        
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(clientes))
                    {
                        Utils.ShowToastr(this, "Modificado ", "Info", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.ShowToastr(this, "ERROR AL MODIFICAR ", "Error", "error");

                    }
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Clientes> repositorio = new BLL.RepositorioBase<Clientes>();
            int id = Utils.ToInt(ClienteIdTextBox.Text);

            var clientes = repositorio.Buscar(id);

            if (clientes == null)
                Utils.ShowToastr(this, "no found", "Error", "error");
            
            else
                repositorio.Eliminar(id);
            Utils.ShowToastr(this, " ELIMINADO ", "Info", "info");
          
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes clientes = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            if (IsValid)
            {
                if (clientes != null)
                {

                    Utils.ShowToastr(this, " Encontrado ", "Success", "info");
                    Limpiar();
                    LlenaCampos(clientes);
                }
                else
                {
                    Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
                    Limpiar();
                }
            }
        }
    }
}