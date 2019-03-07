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

            return producto;
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

                        Utils.ShowToastr(this, "saved successfully", "Success", "success");
                   
                    else
                    {
                        Response.Write("<script>alert('Error al Guardar');</script>");
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(productos))
                    {
                        Response.Write("<script>alert('Modificado Correctamente');</script>");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Modificar');</script>");
                    }
                }
            }
        }
    }
}