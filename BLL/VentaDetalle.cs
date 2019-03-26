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
    public class VentaDetalle : RepositorioBase<Ventas>
    {
        public override Ventas Buscar(int id)
        {
            Ventas facturas = new Ventas();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.ventas.Find(id);

                if (facturas != null)
                {
                    facturas.Detalle.Count();
                    foreach (var item in facturas.Detalle)
                    {
                        string p = item.producto.Nombre;
                    }
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


            return facturas;
        }

        public override List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Ventas> lista = new List<Ventas>();
            try
            {
                lista = contexto.ventas.Where(expression).ToList();
                foreach (var item in lista)
                {
                    item.Detalle.Count();
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

            return lista;
        }

        public override bool Modificar(Ventas ventas)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.ventas.Find(ventas.VentaId);
                foreach (var item in Anterior.Detalle)
                {
                    if (!ventas.Detalle.Exists(d => d.Id == item.Id))
                    {
                        item.producto = null;
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in ventas.Detalle)
                {
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(ventas).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


    }
}
