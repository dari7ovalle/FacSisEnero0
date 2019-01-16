﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SisAgroVeterinaria.Entidades;

namespace DAL
{
    public class Contexto : DbContext
        
    {
        public DbSet<Ciudades> ciudades { get; set; }
        public DbSet<Clientes> clientes { get; set; }
       public DbSet<Configuraciones> configuraciones { get; set; }
        public DbSet<Inventario> inventario { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<TipoProductos> tipoProductos { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<VentaDetalles> ventaDetalles { get; set; }
        public DbSet<Ventas> ventas { get; set; }

        /*  public DbSet<Productos> Productos { get; set; }
          public DbSet<Usuarios> Usuarios { get; set; }
          public DbSet<Clientes> Clientes { get; set; }
          public DbSet<Inventarios> Inventarios { get; set; }
          public DbSet<Pagos> Pagos { get; set; }
          public DbSet<Facturas> Facturas { get; set; }
          public DbSet<FacturasDetalles> FacturasDetalles { get; set; }
          */
        public Contexto() : base("ConStr")
        {

        }
    }
}
