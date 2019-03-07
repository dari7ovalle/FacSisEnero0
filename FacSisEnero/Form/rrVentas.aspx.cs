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
    public partial class rrVentas : System.Web.UI.Page
    {
        private Ventas venta = new Ventas();
        private RepositorioBase<Clientes> repositorioCliente = new RepositorioBase<Clientes>();
        private RepositorioBase<Productos> repositorioProducto = new RepositorioBase<Productos>();
        private VentaDetalle FacturaRepositorio = new VentaDetalle();
        private RepositorioBase<Configuraciones> repositorioConfiguraciones = new RepositorioBase<Configuraciones>();
        string condicion = "[Seleccione]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                ViewState["Detalle"] = new Ventas();
                LlenarDropDownListProductos();
                LlenarDropDownListClientes();
                LlenarConfiguracionesIdDropDownList1();
               


            }

        }

        private void FiltraPrecio()
        {
            if (ProductoDropDownList.Text != condicion)
            {
                int id = Convert.ToInt32(ProductoDropDownList.SelectedValue);
                PrecioTextBox.Text = repositorioProducto.Buscar(id).Precio.ToString();
            }
            else
            {
                PrecioTextBox.Text = "";
            }
        }
        private void LlenarDropDownListProductos()
        {
            ProductoDropDownList.DataSource = repositorioProducto.GetList(x => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Nombre";
            ProductoDropDownList.AppendDataBoundItems = true;
            ProductoDropDownList.DataBind();
            FiltraPrecio();

        }
        private void LlenarDropDownListClientes()
        {
            ClienteDropDownList.DataSource = repositorioCliente.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.AppendDataBoundItems = true;
            ClienteDropDownList.DataBind();
        }

        private void LlenarConfiguracionesIdDropDownList1()
        {
            ConfiguracionesIdDropDownList1.DataSource = repositorioConfiguraciones.GetList(x => true);
            ConfiguracionesIdDropDownList1.DataValueField = "ConfiguracionId";
            ConfiguracionesIdDropDownList1.DataTextField = "NCF";
            ConfiguracionesIdDropDownList1.AppendDataBoundItems = true;
            ConfiguracionesIdDropDownList1.DataBind();
        }
        

        private Ventas LlenaClase()
        {
            venta = (Ventas)ViewState["Detalle"];
            venta.UsuarioId = UserRepositorio.id_Usuario;
            venta.ClienteId = Utils.ToInt(ClienteDropDownList.SelectedValue);
            venta.TotalVenta = Utils.ToDouble(TotalVentaTextBox1.Text);
            venta.ConfiguracionId = Utils.ToInt(ConfiguracionesIdDropDownList1.SelectedValue);
            venta.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            venta.TipoVenta = tipoVentaDropDownList.SelectedValue;
            venta.VentaId = Utils.ToInt(VentaIdTextBox.Text);

            return venta;
        }
        private void LlenarCampos(Ventas ventas)
        {
           // ConfiguracionesIdDropDownList1.SelectedValue = venta.ConfiguracionId.ToString();
            ClienteDropDownList.SelectedValue = ventas.ClienteId.ToString();
            DetalleGridView.DataSource = ventas.Detalle;
            DetalleGridView.DataBind();
            TotalVentaTextBox1.Text = ventas.TotalVenta.ToString();
        }


        protected void guardarButton_Click1(object sender, EventArgs e)
        {
            bool paso = false;
            VentaDetalle repositorio = new VentaDetalle();
            //todo: agregar demas validaciones
            Ventas ventas = LlenaClase();

            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
                paso = repositorio.Guardar(ventas);

            else
                paso = repositorio.Modificar(ventas);

            if (paso)
            {
                Utils.ShowToastr(this, "Transacción exitosa", "Exito", "success");
               // Limpiar
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            var ventaAnt = FacturaRepositorio.Buscar(Utils.ToInt(VentaIdTextBox.Text));

            if(ventaAnt == null)
            {
                Utils.ShowToastr(this, "Agregado", "Exito!!", "info");
                venta = (Ventas)ViewState["Detalle"];
                venta.AgregarProductos(Utils.ToInt(ProductoDropDownList.SelectedValue), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToDouble(ImporteTextBox.Text));
            }
            else
            {
                Utils.ShowToastr(this, "Agregado", "Exito!!", "info");
                ventaAnt = (Ventas)ViewState["Modificado"];
                ventaAnt.AgregarProductos(Utils.ToInt(ProductoDropDownList.SelectedValue), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToDouble(ImporteTextBox.Text));


            }

            ViewState["Venta"] = venta;
            DetalleGridView.DataSource = ((Ventas)ViewState["Detalle"]).Detalle;
            DetalleGridView.DataBind();
            SubTotal();
        }

        protected void ProductoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltraPrecio();
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            ImporteTextBox.Text = Calculos.Importe(Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(CantidadTextBox.Text)).ToString();
        }

        private string SubTotal()
        {
            decimal total = 0;
            foreach (var item in venta.Detalle)
            {
                total += Calculos.CalcularSubTotal(Convert.ToDecimal(item.Importe));
            }
            return TotalVentaTextBox1.Text = total.ToString();
        }

        protected void ImporteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ImporteTextBox.Text != "")
                TotalVentaTextBox1.Text = Calculos.CalcularSubTotal(Utils.ToDecimal(ImporteTextBox.Text)).ToString();
            else
                TotalVentaTextBox1.Text = "";
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
          
            VentaDetalle repositorio = new VentaDetalle();
            var ventas = repositorio.Buscar(
            Utils.ToInt(VentaIdTextBox.Text));
            if (ventas != null)
            {
                LlenarCampos(ventas);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito");
            }
            else
            {
                //Limpiar();
                     Utils.ShowToastr(this,
                    "No se pudo encontrar el presupuesto especificado",
                    "Error", "error");
            }
        }
    }
}
