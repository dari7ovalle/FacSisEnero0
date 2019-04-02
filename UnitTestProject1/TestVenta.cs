using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
   public class TestVenta
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = new Ventas();
            bool paso = false;
            ventas.ClienteId = 2;
            ventas.Fecha = DateTime.Now;
            ventas.TipoVenta = "1";
            ventas.TotalVenta = 500;
            ventas.UsuarioId = 1;
            ventas.VentaId = 15;
            ventas.Detalle.Add(new VentaDetalles(15, 2, 150, 300));
            paso = repositorio.Guardar(ventas);
            Assert.AreEqual(true, paso);
        }
        
        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            var ventas = repositorio.Buscar(3);
            bool paso = false;
            ventas.ClienteId = 2;
            paso = repositorio.Modificar(ventas);
            Assert.AreEqual(true, paso);
        }
        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = new Ventas();
            ventas = repositorio.Buscar(id);
            Assert.IsNotNull(ventas);
        }
        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            List<Ventas> lista = new List<Ventas>();
            Expression<Func<Ventas, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
