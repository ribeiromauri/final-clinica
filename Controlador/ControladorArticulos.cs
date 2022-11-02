using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;

namespace Controlador
{
    public class ControladorArticulos
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.IdMarca, A.IdCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.ID = (int)accesoDatos.Lector["ID"];
                    aux.Codigo = (string)accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.ID = (int)accesoDatos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)accesoDatos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.ID = (int)accesoDatos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)accesoDatos.Lector["Categoria"];
                    if (!(accesoDatos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)accesoDatos.Lector["ImagenUrl"];
                    }
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
