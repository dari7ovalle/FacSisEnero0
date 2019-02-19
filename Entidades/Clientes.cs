using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAgroVeterinaria.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int CiudadId { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }




        public Clientes()
        {
            this.ClienteId = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.CiudadId = 0;
            this.Cedula = string.Empty;
            this.Direccion = string.Empty;
            this.Celular = string.Empty;
            this.Telefono = string.Empty;
            this.Fecha = DateTime.Now;
        }
        public Clientes(int ClienteId, string Nombres, string Apellido, int CiudadId, string Cedula, string Direccion, string Celular, string Telefono)
        {
            this.ClienteId = ClienteId;
            this.Nombres = Nombres;
            this.Apellidos = Apellido;
            this.CiudadId = CiudadId;
            this.Cedula = Cedula;
            this.Direccion = Direccion;
            this.Celular = Celular;
            this.Telefono = Telefono;
        }

    }
}
