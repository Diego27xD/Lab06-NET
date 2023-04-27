using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Security.Cryptography;

namespace Datos
{
    public class DProducto
    {

        public List<Producto> ListarDisponibles()
        {

            //Obtengo la conexión

            SqlParameter param = null;
            List<Producto> Productos = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlDataReader reader = SqlHelper.ExecuteReader("ListarProductos", param);
                Productos = new List<Producto>();


                while (reader.Read())
                {

                    Producto Producto = new Producto();
                    Producto.IdProducto = (int)reader["IdProducto"];
                    Producto.Nombre = reader["Nombre"].ToString();
                    Producto.Precio = (decimal)reader["Precio"];
                    Producto.Estado = (bool)reader["Estado"];

                    Productos.Add(Producto);

                }

                //Muestro la información
                return Productos;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                param = null;
                Productos = null;

            }
        }

        public List<Producto> ListarTodo()
        {

            //Obtengo la conexión

            SqlParameter param = null;
            List<Producto> Productos = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlDataReader reader = SqlHelper.ExecuteReader("ListarTodosProducto", param);
                Productos = new List<Producto>();


                while (reader.Read())
                {

                    Producto Producto = new Producto();
                    Producto.IdProducto = (int)reader["IdProducto"];
                    Producto.Nombre = reader["Nombre"].ToString();
                    Producto.Precio = (decimal)reader["Precio"];
                    Producto.Estado = (bool)reader["Estado"];

                    Productos.Add(Producto);

                }

                //Muestro la información
                return Productos;


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                param = null;
                Productos = null;

            }
        }

        public void Insertar(Producto producto)
        {
            try
            {
                                  
                List<SqlParameter> parameters = new List<SqlParameter>();
                int state = 0;
                if(producto.Estado == true)
                {
                    state = 1;
                }
                parameters.Add(new SqlParameter("@IdProducto", producto.IdProducto));
                parameters.Add(new SqlParameter("@Nombre", producto.Nombre));
                parameters.Add(new SqlParameter("@Precio", producto.Precio));
                parameters.Add(new SqlParameter("@Estado", state));
                SqlHelper.ExecuteNonQuery("InsertProduct", parameters);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Update(int IdProducto, Producto producto)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                int state = 0;
                if (producto.Estado == true)
                {
                    state = 1;
                }
                parameters.Add(new SqlParameter("@IdProducto", IdProducto));
                parameters.Add(new SqlParameter("@Nombre", producto.Nombre));
                parameters.Add(new SqlParameter("@Precio", producto.Precio));
                parameters.Add(new SqlParameter("@Estado", state));
                SqlHelper.ExecuteNonQuery("ActualizarProducto", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int IdProducto, int state)
        {
            try
            {
                
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@IdProducto", IdProducto));
                parameters.Add(new SqlParameter("@Estado", state));
                SqlHelper.ExecuteNonQuery("EliminarProducto", parameters);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
