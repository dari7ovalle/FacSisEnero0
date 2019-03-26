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
    public partial class rProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void LlenarCombos()
        {
            RepositorioBase<TipoProductos> repositorio = new RepositorioBase<TipoProductos>();
            TipoProductoDropDownList.DataSource = repositorio.GetList(c => true);
            TipoProductoDropDownList.DataValueField = "TipoProductoId";
            TipoProductoDropDownList.DataTextField = "Nombres";
            TipoProductoDropDownList.DataBind();
        }
        private void Limpiar()
        {
            ProductoIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            CostoTextBox.Text = "";
            NombreTextBox.Text = " ";
            PrecioTextBox.Text = "";
            TipoProductoDropDownList.SelectedIndex = 0;
            InventarioTextBox.Text = "";

        }
        private Productos LlenaClase(Productos producto)
        {
         

            producto.ProductoId = Utils.ToInt(ProductoIdTextBox.Text);
            producto.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            producto.Nombre = NombreTextBox.Text;
            producto.TipoProductoId = Utils.ToInt(TipoProductoDropDownList.SelectedValue);
            producto.Costo = Utils.ToInt(CostoTextBox.Text);
            producto.Precio = Utils.ToInt(PrecioTextBox.Text);
            producto.Activo = 0;
            producto.Inventario = Utils.ToInt(InventarioTextBox.Text);


            return producto;
        }
        private void LlenaCampos(Productos productos)
        {
            ProductoIdTextBox.Text = productos.ProductoId.ToString();
            FechaTextBox.Text = productos.Fecha.ToString("yyyy-MM-dd");
            TipoProductoDropDownList.Text = productos.TipoProductoId.ToString();
            NombreTextBox.Text = productos.Nombre.ToString();
            CostoTextBox.Text = productos.Costo.ToString();
            PrecioTextBox.Text = productos.Precio.ToString();
        
            InventarioTextBox.Text = productos.Inventario.ToString();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Productos> repositorio = new BLL.RepositorioBase<Productos>();
            Productos productos = new Productos();
            bool paso = false;

            //todo: validaciones adicionales
            LlenaClase(productos);

            if (IsValid)
            {
                if (productos.ProductoId == 0)
                {
                    if (paso = repositorio.Guardar(productos))

                        Utils.ShowToastr(this, "GUARDADO", "Success", "success");
                   
                    else
                    {
                        Utils.ShowToastr(this, "ERROR AL GUARDAR ", "Error", "error");

                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(productos))
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

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos producto = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));
            if (IsValid)
            {
                if (producto != null)
                {
                    Utils.ShowToastr(this, " Encontrado ", "Success", "info");
                    Limpiar();
                    LlenaCampos(producto);
                }
                else
                {
                    Utils.ShowToastr(this, "No Se Encontro  Resultado", "Error", "error");
                    Limpiar();
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos producto = repositorio.Buscar(Utils.ToInt(ProductoIdTextBox.Text));
            if (IsValid)
            {
                if (producto != null)
                {
                    repositorio.Eliminar(producto.ProductoId);
                    Utils.ShowToastr(this, " ELIMINADO ", "Info", "info");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, " ELIMINADO ", "Erroe", "error");
                    Limpiar();
                }
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void PrecioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}