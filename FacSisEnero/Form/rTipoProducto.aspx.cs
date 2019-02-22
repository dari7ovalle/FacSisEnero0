﻿using BLL;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Form
{
    public partial class rTipoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private TipoProductos LlenaClase(TipoProductos tipoProductos)
        {

            tipoProductos.Nombres = NombreTextBox.Text;

            return tipoProductos;

        }
        private void LlenaCampos(TipoProductos tipoProductos)
        {

            NombreTextBox.Text = tipoProductos.Nombres;


        }
        private void Limpiar()
        {
            TipoProductoIdTextBox.Text = " ";
            NombreTextBox.Text = "";


        }


        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<TipoProductos> repositorio = new BLL.RepositorioBase<TipoProductos>();
            TipoProductos tipoProductos = new TipoProductos();
            bool paso = false;

            LlenaClase(tipoProductos);

            if (IsValid)
            {
                if (tipoProductos.TipoProductoId == 0)
                {
                    if (paso = repositorio.Guardar(tipoProductos))
                    {

                        Utils.ShowToastr(this, "saved successfully", "Success", "success");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al Guardar');</script>");
                    }
                    Limpiar();
                }

                else
                {
                    if (paso = repositorio.Modificar(tipoProductos))
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

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<TipoProductos> repositorio = new BLL.RepositorioBase<TipoProductos>();
            int id = Utils.ToInt(TipoProductoIdTextBox.Text);

            var tipoProductos = repositorio.Buscar(id);

            if (tipoProductos == null)
                Utils.ShowToastr(this, "no found", "Error", "error");

            else
                repositorio.Eliminar(id);
            Utils.ShowToastr(this, " Eliminated ", "Success", "info");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoProductos> repositorio = new RepositorioBase<TipoProductos>();
            TipoProductos tipoProductos = repositorio.Buscar(Utils.ToInt(TipoProductoIdTextBox.Text));

            if (IsValid)
            {
                if (tipoProductos != null)
                {

                    Utils.ShowToastr(this, " Encontrado ", "Success", "info");
                    Limpiar();
                    LlenaCampos(tipoProductos);
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
