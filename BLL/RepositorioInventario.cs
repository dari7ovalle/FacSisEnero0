using DAL;
using SisAgroVeterinaria.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class RepositorioInventario : RepositorioBase<Inventario>
    {
        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Inventario inventario = contexto.inventario.Find(id);

                if (inventario != null)
                {
                    contexto.productos.Find(inventario.ProductoId).Inventario -= inventario.Cantidad;
                    contexto.inventario.Remove(inventario);
                }


                if (contexto.SaveChanges() > 0)
                { paso = true; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public override bool Guardar(Inventario inventarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.inventario.Add(inventarios) != null)
                {
                    contexto.productos.Find(inventarios.ProductoId).Inventario += inventarios.Cantidad;
                    contexto.SaveChanges();
                    paso = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }


            return paso;
        }

        public override bool Modificar(Inventario inventario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioInventario repositorio = new RepositorioInventario();
            try
            {
                contexto.Entry(inventario).State = EntityState.Modified;
                Inventario Ant = repositorio.Buscar(inventario.InventarioId);
                var Producto = contexto.productos.Find(inventario.ProductoId);

                var ProductoAnt = contexto.productos.Find(Ant.ProductoId);

                if (inventario.ProductoId != Ant.ProductoId)
                {
                    ProductoAnt.Inventario -= Ant.Cantidad;
                    Producto.Inventario += inventario.Cantidad;
                }
                else
                {
                    int dif = inventario.Cantidad - Ant.Cantidad;
                    Producto.Inventario += dif;
                }
                contexto.Entry(inventario).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public override Inventario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Inventario inventario = new Inventario();

            try
            {
                inventario = contexto.inventario.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inventario;
        }

        public override List<Inventario> GetList(Expression<Func<Inventario, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Inventario> inventario = new List<Inventario>();

            try
            {
                inventario = contexto.inventario.Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return inventario;
        }
    }
}

