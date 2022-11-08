using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Dominio;

namespace Controlador
{
    public class ControladorPacientes
    {
        public List<Pacientes> listar(string id = "")
        {
            List<Pacientes> lista = new List<Pacientes>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if(id != "")
                {
                    accesoDatos.setConsulta("SELECT ID, NOMBRES, APELLIDOS, DNI, DOMICILIO, EMAIL, FECHA_NACIMIENTO, ESTADO FROM PACIENTES WHERE ID = @ID");
                    accesoDatos.setParametro("@ID", id);
                }
                else{
                    accesoDatos.setConsulta("SELECT ID, NOMBRES, APELLIDOS, DNI, DOMICILIO, EMAIL, FECHA_NACIMIENTO, ESTADO FROM PACIENTES");
                }
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Pacientes aux = new Pacientes();
                    aux.ID = (int)accesoDatos.Lector["ID"];
                    aux.Nombre = (string)accesoDatos.Lector["NOMBRES"];
                    aux.Apellido = (string)accesoDatos.Lector["APELLIDOS"];
                    aux.DNI = (string)accesoDatos.Lector["DNI"];
                    aux.Domicilio = (string)accesoDatos.Lector["DOMICILIO"];
                    aux.Email = (string)accesoDatos.Lector["EMAIL"];
                    aux.FechaNacimiento = (DateTime)accesoDatos.Lector["FECHA_NACIMIENTO"];
                    aux.Estado = (bool)accesoDatos.Lector["ESTADO"];

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

        public void agregarConSP(Pacientes nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimiento("SP_ALTA_PACIENTE");
                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Apellido", nuevo.Apellido);
                datos.setParametro("@DNI", nuevo.DNI);
                datos.setParametro("@Domicilio", nuevo.Domicilio);
                datos.setParametro("@Email", nuevo.Email);
                datos.setParametro("@FechaNacimiento", nuevo.FechaNacimiento);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarConSP(Pacientes nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimiento("SP_MODIFICAR_PACIENTE");
                datos.setParametro("@Nombre", nuevo.Nombre);
                datos.setParametro("@Apellido", nuevo.Apellido);
                datos.setParametro("@DNI", nuevo.DNI);
                datos.setParametro("@Domicilio", nuevo.Domicilio);
                datos.setParametro("@Email", nuevo.Email);
                datos.setParametro("@FechaNacimiento", nuevo.FechaNacimiento);
                datos.setParametro("@ID", nuevo.ID);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM PACIENTES WHERE ID = @id");
                datos.setParametro("@id", ID);
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
