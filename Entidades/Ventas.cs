using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
    [Serializable]
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public int ConfiguracionId { get; set; }
        public string TipoVenta { get; set; }
        public double TotalVenta { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<VentaDetalles> Detalle { get; set; }


        public Ventas()
        {
            this.VentaId = 0;
            this.ClienteId = 0;
            this.Fecha = DateTime.Now;
            this.ConfiguracionId = 0;
            this.TipoVenta = string.Empty;
            this.TotalVenta = 0;
            this.UsuarioId = 0;
            this.Detalle = new List<VentaDetalles>();
        }

        public void AgregarProductos(int productoId,int cantidad,int precio,double importe)
        {
            this.Detalle.Add( new VentaDetalles(productoId,cantidad,precio,importe));
        }

        public void LimpiarList()
        {
            this.Detalle.Clear();
        }

        public Ventas(int VentaId, int ClienteId, DateTime Fecha, int ConfiguracionId, string TipoVenta, double TotalVenta, int UsuarioId, List<VentaDetalles> detalle)
        {
            this.VentaId = VentaId;
            this.ClienteId = ClienteId;
            this.Fecha = DateTime.Now;
            this.ConfiguracionId = ConfiguracionId;
            this.TipoVenta = TipoVenta;
            this.TotalVenta = TotalVenta;
            this.UsuarioId = UsuarioId;
            this.Detalle = detalle;
        }
    }
}
