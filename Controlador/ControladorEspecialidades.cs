using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class ControladorEspecialidades
    {
        public List<Especialidades> ListarEspecialidades()
        {
            List<Especialidades> lista = new List<Especialidades>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT ID, NOMBRE FROM ESPECIALIDADES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidades aux = new Especialidades();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];

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
