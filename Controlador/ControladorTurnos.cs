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
        public List<Turnos> Listar(string id = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turnos> lista = new List<Turnos>();

            try
            {
                if(id != "")
                {
                    datos.setConsulta("SELECT T.ID AS ID, M.ID AS IDMED, M.NOMBRES AS NOMBREMED, M.APELLIDOS AS APEMED, P.ID AS IDPAC, P.NOMBRES AS NOMBREPAC, P.APELLIDOS AS APEPAC, P.DNI AS DNI, E.ID AS IDESP, E.NOMBRE AS ESPECIALIDAD, T.ENTRADA AS ENTRADA, T.OBSERVACIONES AS OBSERVACIONES, T.ENTRADA AS HORARIOENTRADA, T.FECHA AS FECHA, T.ESTADO AS ESTADO FROM TURNOS T INNER JOIN MEDICOS M ON T.ID_MEDICO = M.ID INNER JOIN PACIENTES P ON T.ID_PACIENTE = P.ID INNER JOIN ESPECIALIDADES E ON T.ID_ESPECIALIDAD = E.ID WHERE T.ID = @ID");
                    datos.setParametro("@ID", id);
                }
                else
                {
                    datos.setConsulta("SELECT T.ID AS ID, M.ID AS IDMED, M.NOMBRES AS NOMBREMED, M.APELLIDOS AS APEMED, P.ID AS IDPAC, P.NOMBRES AS NOMBREPAC, P.APELLIDOS AS APEPAC, P.DNI AS DNI, E.ID AS IDESP, E.NOMBRE AS ESPECIALIDAD, T.ENTRADA AS ENTRADA, T.OBSERVACIONES AS OBSERVACIONES, T.ENTRADA AS HORARIOENTRADA, T.FECHA AS FECHA, T.ESTADO AS ESTADO FROM TURNOS T INNER JOIN MEDICOS M ON T.ID_MEDICO = M.ID INNER JOIN PACIENTES P ON T.ID_PACIENTE = P.ID INNER JOIN ESPECIALIDADES E ON T.ID_ESPECIALIDAD = E.ID");
                }
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
                    aux.Paciente.DNI = (string)datos.Lector["DNI"];
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

        public void AgregarTurno(Turnos aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimiento("SP_ALTA_TURNO");
                datos.setParametro("@IDMedico", aux.Medico.ID);
                datos.setParametro("@IDPaciente", aux.Paciente.ID);
                datos.setParametro("@IDEspecialidad", aux.Especialidad.ID);
                datos.setParametro("@HoraEntrada", aux.HoraEntrada);
                datos.setParametro("Fecha", aux.Fecha);
                datos.setParametro("@Observaciones", aux.Observaciones);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
