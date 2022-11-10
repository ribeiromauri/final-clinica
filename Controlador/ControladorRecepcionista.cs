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
        public List<Recepcionista> ListarRecepcionistas(string id = "")
        {
            List<Recepcionista> lista = new List<Recepcionista>();
            try
            {
                if (id != "")
                {
                    datos.setConsulta("SELECT ID, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, EMAIL, ESTADO FROM RECEPCIONISTA WHERE ID = @ID");
                    datos.setParametro("@ID", id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, EMAIL, ESTADO FROM RECEPCIONISTA");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Recepcionista aux = new Recepcionista();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Contrasenia = (string)datos.Lector["CONTRASEÑA"];
                    aux.Nombre = (string)datos.Lector["NOMBRES"];
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
                datos.setProcedimiento("SP_ALTA_RECEPCIONISTA");
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

        public void modificarRecepcionista(Recepcionista nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimiento("SP_MODIFICAR_RECEPCIONISTA");

                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Apellido", nuevo.Apellido);
                datos.setParametro("@DNI", nuevo.DNI);
                datos.setParametro("@Email", nuevo.Email);
                datos.setParametro("Contrasenia", nuevo.Contrasenia);
                datos.setParametro("@ID", nuevo.ID);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarRecepcionista(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimiento("SP_ELIMINAR_RECEPCIONISTA");
                datos.setParametro("@ID", ID);
                datos.ejecutarLectura();
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
