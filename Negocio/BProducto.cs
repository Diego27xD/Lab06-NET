using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BProducto
    {
        DProducto datos = new DProducto();

        public List<Producto> Listar()
        {


            var productos = datos.ListarDisponibles();
            
            
            return productos;

        }

        public List<Producto> ListarTodo(string nombre)
        {


            var productos = datos.ListarTodo();

            var result = productos.Where(x => x.Nombre.Trim() == nombre.Trim()
            || string.IsNullOrEmpty(nombre)
            ).ToList();
            return result;

        }


        public void Insertar(Producto region)
        {
            try
            {
                var productos = datos.ListarTodo();
                var max = productos.Select(x => x.IdProducto).Max();
                region.IdProducto = max + 1;

                datos.Insertar(region);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Actualizar (int id, Producto producto)
        {
            try
            {
                datos.Update(id, producto);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id, bool state)
        {
            try
            {
                int estado = 0;
                if (state == true) estado = 1;
                datos.Delete(id, estado);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
