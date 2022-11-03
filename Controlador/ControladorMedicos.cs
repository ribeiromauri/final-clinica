using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Dominio;

namespace Controlador
{
    public class ControladorMedicos
    {
        public List<Medicos> listar()
        {
            List<Medicos> lista = new List<Medicos>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setConsulta("SELECT M.ID, M.NOMBRES, M.APELLIDOS, M.DNI, M.MATRICULA, M.DOMICILIO, M.EMAIL, M.FECHA_NACIMIENTO, M.ESTADO, E.ID as IDE, E.NOMBRE AS ESPECIALIDAD, HT.DIA, HT.H_ENTRADA, HT.H_SALIDA, HT.LIBRE FROM MEDICOS M INNER JOIN ESPECIALIDAD_X_MEDICO ExM ON ExM.ID_MEDICO = M.ID INNER JOIN ESPECIALIDADES E ON E.ID = ExM.ID_ESPECIALIDAD INNER JOIN HORARIOS_TRABAJO HT ON HT.ID_MEDICO = M.ID");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medicos aux = new Medicos();
                    Especialidades especialidades = new Especialidades();
                    HorariosTrabajo horariosTrabajo = new HorariosTrabajo();

                    aux.ID = (int)accesoDatos.Lector["ID"];
                    aux.Nombre = (string)accesoDatos.Lector["NOMBRES"];
                    aux.Apellido = (string)accesoDatos.Lector["APELLIDOS"];
                    aux.DNI = (int)accesoDatos.Lector["DNI"];
                    aux.Matricula = (int)accesoDatos.Lector["MATRICULA"];
                    aux.Domicilio = (string)accesoDatos.Lector["DOMICILIO"];
                    aux.Email = (string)accesoDatos.Lector["EMAIL"];
                    aux.FechaNacimiento = (DateTime)accesoDatos.Lector["FECHA_NACIMIENTO"];
                    aux.Estado = (bool)accesoDatos.Lector["ESTADO"];

                    aux.Especialidad = new List<Especialidades>();
                    especialidades.ID = (int)accesoDatos.Lector["IDE"];
                    especialidades.Nombre = (string)accesoDatos.Lector["ESPECIALIDAD"];
                    aux.Especialidad.Add(especialidades);

                    aux.HorariosTrabajo = new List<HorariosTrabajo>();
                    horariosTrabajo.Dia = (string)accesoDatos.Lector["DIA"];
                    horariosTrabajo.HorarioEntrada = (int)accesoDatos.Lector["H_ENTRADA"];
                    horariosTrabajo.HorarioSalida = (int)accesoDatos.Lector["H_SALIDA"];
                    horariosTrabajo.Libre = (bool)accesoDatos.Lector["LIBRE"];
                    aux.HorariosTrabajo.Add(horariosTrabajo);

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
