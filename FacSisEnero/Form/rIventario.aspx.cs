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
    public partial class rIventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                LlenaDropDown();
                if (id > 0)
                {
                    RepositorioInventario repositorio = new RepositorioInventario();
                    var inventario = repositorio.Buscar(id);

                    if (inventario != null)
                        Utils.ShowToastr(this, " Encontrado ", "Info", "info");
                    LlenaCampos(inventario);
                }
            }
        }

        private Inventario LlenaClase()
        {
            Inventario inventarios = new Inventario();

            inventarios.InventarioId = Utils.ToInt(InventarioIdTextBox.Text);
              inventarios.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            inventarios.ProductoId = Utils.ToInt(ProductoIdDropDownList.SelectedValue);
             inventarios.Nombre = NombreTextBox.Text;
            inventarios.Cantidad = Utils.ToInt(CantidadTextBox1.Text);


            return inventarios;
        }

        private void LlenaCampos(Inventario inventario)
        {
            InventarioIdTextBox.Text = inventario.InventarioId.ToString();
            FechaTextBox.Text = inventario.Fecha.ToShortDateString();
            ProductoIdDropDownList.Text = inventario.ProductoId.ToString();
            CantidadTextBox1.Text = inventario.Cantidad.ToString();
        }

        private void LlenaDropDown()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            ProductoIdDropDownList.DataSource = repositorio.GetList(p => true);
            ProductoIdDropDownList.DataValueField = "ProductoId";
            ProductoIdDropDownList.DataTextField = "Nombre";
            ProductoIdDropDownList.AppendDataBoundItems = true;
            ProductoIdDropDownList.DataBind();
        }

        private void Limpiar()
        {
            InventarioIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ProductoIdDropDownList.SelectedIndex = 0;
            CantidadTextBox1.Text = "";

        }
        

        protected void GuadarButton_Click1(object sender, EventArgs e)
        {
            RepositorioInventario repositorio = new RepositorioInventario();
            Inventario inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (IsValid)
            {
                if (inventario == null)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        Utils.ShowToastr(this, "Transacción exitosa", "Exito", "success");
                        Limpiar();
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No Guardado", "Error", "error");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        Utils.ShowToastr(this, "Modificado", "Exito!!", "info");
                        Limpiar();
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No Modificado", "Error", "error");
                        Limpiar();
                    }

                }
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioInventario repositorio = new RepositorioInventario();
            Inventario inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (IsValid)
            {
                if (inventario != null)
                {
                    Utils.ShowToastr(this, " Encontrado ", "Success", "info");
                    Limpiar();
                    LlenaCampos(inventario);
                }
                else
                {
                    Utils.ShowToastr(this, "No Se Encontro  Resultado", "Error", "error");
                    Limpiar();
                }
            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioInventario repositorio = new RepositorioInventario();
            Inventario inventario = repositorio.Buscar(Utils.ToInt(InventarioIdTextBox.Text));

            if (IsValid)
            {
                if (inventario != null)
                {
                    repositorio.Eliminar(inventario.InventarioId);
                    Utils.ShowToastr(this, "Eliminado", "Exito!!", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, "No Eliminado", "Error", "error");
                    Limpiar();
                }
            }
        }
    }
}