using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class ControladorTurnos
    {
        public List<Turnos> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turnos> lista = new List<Turnos>();

            try
            {
                datos.setConsulta("SELECT T.ID AS ID, M.ID AS IDMED, M.NOMBRES AS NOMBREMED, M.APELLIDOS AS APEMED, P.ID AS IDPAC, P.NOMBRES AS NOMBREPAC, P.APELLIDOS AS APEPAC, E.ID AS IDESP, E.NOMBRE AS ESPECIALIDAD, T.ENTRADA AS ENTRADA, T.OBSERVACIONES AS OBSERVACIONES, T.ENTRADA AS HORARIOENTRADA, T.FECHA AS FECHA, T.ESTADO AS ESTADO FROM TURNOS T INNER JOIN MEDICOS M ON T.ID_MEDICO = M.ID INNER JOIN PACIENTES P ON T.ID_PACIENTE = P.ID INNER JOIN ESPECIALIDADES E ON T.ID_ESPECIALIDAD = E.ID\r\n");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turnos aux = new Turnos();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.Medico = new Medicos();
                    aux.Medico.ID = (int)datos.Lector["IDMED"];
                    aux.Medico.Nombre = (string)datos.Lector["NOMBREMED"];
                    aux.Medico.Apellido = (string)datos.Lector["APEMED"];
                    aux.Paciente = new Pacientes();
                    aux.Paciente.ID = (int)datos.Lector["IDPAC"];
                    aux.Paciente.Nombre = (string)datos.Lector["NOMBREPAC"];
                    aux.Paciente.Apellido = (string)datos.Lector["APEPAC"];
                    aux.Especialidad = new Especialidades();
                    aux.Especialidad.ID = (int)datos.Lector["IDESP"];
                    aux.Especialidad.Nombre = (string)datos.Lector["ESPECIALIDAD"];
                    aux.HoraEntrada = (int)datos.Lector["HORARIOENTRADA"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];
                    aux.Observaciones = (string)datos.Lector["OBSERVACIONES"];
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
    }
}
