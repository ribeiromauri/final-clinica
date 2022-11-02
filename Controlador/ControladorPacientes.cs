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
        public List<Pacientes> listar()
        {
            List<Pacientes> lista = new List<Pacientes>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setConsulta("SELECT ID, NOMBRES, APELLIDOS, DNI, DOMICILIO, EMAIL, FECHA_NACIMIENTO, ESTADO FROM PACIENTES");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Pacientes aux = new Pacientes();
                    aux.ID = (int)accesoDatos.Lector["ID"];
                    aux.Nombre = (string)accesoDatos.Lector["NOMBRES"];
                    aux.Apellido = (string)accesoDatos.Lector["APELLIDOS"];
                    aux.DNI = (int)accesoDatos.Lector["DNI"];
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
    }
}
