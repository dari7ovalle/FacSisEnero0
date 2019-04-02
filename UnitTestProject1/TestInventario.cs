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
   public class TestInventario
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
            Inventario inventario = new Inventario();
            bool paso = false;
            inventario.Cantidad = 5;
            inventario.Fecha = DateTime.Now;
            inventario.InventarioId = 5;
            inventario.Nombre = "jugos";
            inventario.ProductoId = 3;
          

            paso = repositorio.Guardar(inventario);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
            var inventario = repositorio.Buscar(3);
            bool paso = false;
            inventario.Nombre = "leche";
            paso = repositorio.Modificar(inventario);
            Assert.AreEqual(true, paso);
        }
        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
            Inventario inventario = new Inventario();
            inventario = repositorio.Buscar(id);
            Assert.IsNotNull(inventario);
        }
        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Inventario> repositorio = new RepositorioBase<Inventario>();
            List<Inventario> lista = new List<Inventario>();
            Expression<Func<Inventario, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

    }
}
