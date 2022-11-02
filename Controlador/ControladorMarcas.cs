using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class ControladorMarcas
    {
        public List<Marcas> listar()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select Id, Descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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
                datos.cerrarConexion();
            }
        }
    }
}
