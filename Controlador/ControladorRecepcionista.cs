using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class ControladorRecepcionista
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Recepcionista> ListarRecepcionistas()
        {
            List<Recepcionista> lista = new List<Recepcionista>();
            try
            {
                datos.setConsulta("SELECT ID, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, EMAIL, ESTADO FROM RECEPCIONISTA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Recepcionista aux = new Recepcionista();
                    
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Contrasenia = (string)datos.Lector["CONTRASEÑA"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Apellido = (string)datos.Lector["APELLIDOS"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Email = (string)datos.Lector["EMAIL"];
                    aux.Estado = (bool)datos.Lector["ESTADO"];

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
        public bool AgregarRecepcionista(Recepcionista obj)
        {
            try
            {
                datos.setProcedimiento("SP_ALTA_MEDICO");
                datos.setParametro("@NOMBRE", obj.Nombre);
                datos.setParametro("@APELLIDO", obj.Apellido);
                datos.setParametro("@DNI", obj.DNI);
                datos.setParametro("@EMAIL", obj.Email);
                datos.setParametro("@CONTRASEÑA", obj.Contrasenia);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
    }
}
