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
   public class UnitTest
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            bool paso = false;
            productos.Nombre = "Cafe";
            productos.Fecha = DateTime.Now;
            productos.Costo = 10;
            productos.Activo = 0;
            productos.Precio = 15;
            productos.ProductoId = 6;
            productos.Inventario = 5;
            productos.TipoProductoId = 1;
            

            paso = repositorio.Guardar(productos);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            var productos = repositorio.Buscar(3);
            bool paso = false;
            productos.Nombre = "Casabe";
            paso = repositorio.Modificar(productos);
            Assert.AreEqual(true, paso);
        }
        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            productos = repositorio.Buscar(id);
            Assert.IsNotNull(productos);
        }
        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> lista = new List<Productos>();
            Expression<Func<Productos, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

    }
}
