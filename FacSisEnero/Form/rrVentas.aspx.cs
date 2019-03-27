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
                LlenarDropDownListProductos();
                LlenarDropDownListClientes();
                LlenarConfiguracionesIdDropDownList1();
                ViewState["Detalle"] = new Ventas();
               

            }

        }
        private void Limpiar()
        {
            VentaIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedIndex = 0;
            ProductoDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";
            PrecioTextBox.Text = "";
            ImporteTextBox.Text = "";
            TotalVentaTextBox1.Text = "";
           DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
            //ViewState["Detalle"] = new Ventas();
            //BindGrid();

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
        private void LlenarCampos(Ventas venta)
        {
           Ventas ventass = (Ventas)ViewState["Detalle"];
            VentaDetalle ventaDetalle = new   VentaDetalle();
            ConfiguracionesIdDropDownList1.SelectedValue = venta.ConfiguracionId.ToString();
            ClienteDropDownList.SelectedValue = venta.ClienteId.ToString();
            DetalleGridView.DataSource = venta.Detalle;
          
            DetalleGridView.DataBind();
            
            TotalVentaTextBox1.Text = venta.TotalVenta.ToString();
        }


        protected void guardarButton_Click1(object sender, EventArgs e)
        {
            bool paso = false;
            VentaDetalle repositorio = new VentaDetalle();

            Ventas ventas = LlenaClase();

            if (Utils.ToInt(VentaIdTextBox.Text) == 0)
            {

                paso = repositorio.Guardar(ventas);
                Limpiar();
                // Utils.ShowToastr(this, "GUARDADO", "Success", "success");
            }
            else
            {
                paso = repositorio.Modificar(ventas);
                Utils.ShowToastr(this, "Modificado", "Info", "info");
            }
            if (paso)
            {
                Utils.ShowToastr(this, "Transacción exitosa", "Exito", "success");
                // Limpiar
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            var ventaAnt = FacturaRepositorio.Buscar(Utils.ToInt(VentaIdTextBox.Text));
            bool paso = false;

            //if (Utils.ToInt(ProductoDropDownList.SelectedValue == DetalleGridView.ro))
            if (DetalleGridView.Rows.Count > 0)
            {
                for (int i = 0; i < ((Ventas)ViewState["Detalle"]).Detalle.Count; i++)
                {
                    if (((Ventas)ViewState["Detalle"]).Detalle[i].ProductoId == Utils.ToInt(ProductoDropDownList.SelectedValue.ToString()))
                    {
                        ((Ventas)ViewState["Detalle"]).Detalle[i].Cantidad = ((Ventas)ViewState["Detalle"]).Detalle[i].Cantidad + Utils.ToInt(CantidadTextBox.Text.ToString());
                        ((Ventas)ViewState["Detalle"]).Detalle[i].Importe = ((Ventas)ViewState["Detalle"]).Detalle[i].Cantidad * ((Ventas)ViewState["Detalle"]).Detalle[i].Precio;
                        paso = true;
                        break;
                    }                  

                }
                if (!paso)
                {
                    if (ventaAnt == null)
                    {

                        venta = (Ventas)ViewState["Detalle"];
                        venta.AgregarProductos(Utils.ToInt(ProductoDropDownList.SelectedValue), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToInt(CantidadTextBox.Text) * Utils.ToInt(PrecioTextBox.Text));

                    }
                    else
                    {
                        Utils.ShowToastr(this, "Agregado", "Exito!!", "info");
                        ventaAnt = (Ventas)ViewState["Detalle"];
                        ventaAnt.AgregarProductos(Utils.ToInt(ProductoDropDownList.SelectedValue), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToInt(CantidadTextBox.Text)* Utils.ToInt(PrecioTextBox.Text));

                    }

                }
            }
            else
            {
                if (ventaAnt == null)
                {

                    venta = (Ventas)ViewState["Detalle"];
                    venta.AgregarProductos(Utils.ToInt(ProductoDropDownList.SelectedValue), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToDouble(ImporteTextBox.Text));

                }
                else
                {
                    Utils.ShowToastr(this, "Agregado", "Exito!!", "info");
                    ventaAnt = (Ventas)ViewState["Detalle"];
                    ventaAnt.AgregarProductos(Utils.ToInt(ProductoDropDownList.SelectedValue), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToDouble(ImporteTextBox.Text));

                }
            }

            
                ViewState["Venta"] = venta;
                DetalleGridView.DataSource = ((Ventas)ViewState["Detalle"]).Detalle;
                DetalleGridView.DataBind();
                SubTotal();
        }

        protected void ProductoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltraPrecio();
            ImporteTextBox.Text = Calculos.Importe(Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(CantidadTextBox.Text)).ToString();
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            ImporteTextBox.Text = Calculos.Importe(Utils.ToDecimal(PrecioTextBox.Text), Utils.ToDecimal(CantidadTextBox.Text)).ToString();
        }

        private string SubTotal()
        {
            decimal total = 0;
            foreach (var item in ((Ventas)ViewState["Detalle"]).Detalle)
            {
                total += Calculos.CalcularSubTotal(Convert.ToDecimal(item.Importe));
                
            }
            return TotalVentaTextBox1.Text = total.ToString();
        }


        protected void ImporteTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ImporteTextBox.Text != " ")
                TotalVentaTextBox1.Text = Calculos.CalcularSubTotal(Utils.ToDecimal(ImporteTextBox.Text)).ToString();
            else
                TotalVentaTextBox1.Text = " ";
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

        protected void eliminarutton_Click(object sender, EventArgs e)
        {

            VentaDetalle repositorio = new VentaDetalle();
            Ventas vent = repositorio.Buscar(Utils.ToInt(VentaIdTextBox.Text));

            if (vent != null)
            {
                repositorio.Eliminar(vent.VentaId);
                Utils.ShowToastr(this, "Registro eliminado", "Exito", "success");
                Limpiar();
            }
            else
            {
                Utils.ShowToastr(this, "Error al   eliminr", "Error", "error");

                Limpiar();
            }
        }

       

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
