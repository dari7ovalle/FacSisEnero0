﻿using BLL;
using Microsoft.Reporting.WebForms;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacSisEnero.Consultas
{
    public partial class cVentas : System.Web.UI.Page
    {
        Expression<Func<Ventas, bool>> filtro;// = p => true;
        RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
        public  static List<Ventas> listFacturas= new  List<Ventas>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
           

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {

            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            if (hasta < desde)
            {
                Utils.ShowToastr(this, "No Sera Posible Hacer Una Consulta Si El Rango Hasta Es Menor Que El Desde!!", "Fechas Invalidas!!", "warning");
                return;
            }
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 1://FacturaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.VentaId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://ClienteId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ClienteId.Equals(id) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                //case 3://monto
                //    decimal monto = Utils.ToDecimal(CriterioTextBox.Text);
                //    filtro = p => p.ClienteId.Equals(monto) && p.Fecha >= desde && p.Fecha <= hasta;
                //    break;
            }

            listFacturas = repositorio.GetList(filtro);
            ProductoGridView.DataSource = listFacturas;
            ProductoGridView.DataBind();
        }

        protected void ImprimirLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/VentasView.aspx");
        }
    }
    }