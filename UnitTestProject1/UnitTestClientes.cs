using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SisAgroVeterinaria.Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestClientes
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            bool paso = false;
            cliente.ClienteId = 4;
            cliente.Fecha = DateTime.Now;
            cliente.Nombres = "juan";
            cliente.Telefono = "8098971234";
            cliente.Cedula = "00011111112";
            cliente.Direccion = "San jose";
            cliente.Apellidos = "gomez";
            cliente.CiudadId = 1;
            cliente.Celular = "8297762109";

            paso = repositorio.Guardar(cliente);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            var cliente = repositorio.Buscar(3);
            bool paso = false;
            cliente.Nombres = "Fernando";
            paso = repositorio.Modificar(cliente);
            Assert.AreEqual(true, paso);
        }
        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 3;
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            cliente = repositorio.Buscar(id);
            Assert.IsNotNull(cliente);
        }
        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            List<Clientes> lista = new List<Clientes>();
            Expression<Func<Clientes, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
