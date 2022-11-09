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
        AccesoDatos accesoDatos = new AccesoDatos();
        public List<Medicos> listar()
        {
            List<Medicos> lista = new List<Medicos>();
            

            try
            {
                accesoDatos.setConsulta("SELECT ID, NOMBRES, APELLIDOS, DNI, MATRICULA, EMAIL, ESTADO FROM MEDICOS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Medicos aux = new Medicos();
                    Especialidades especialidades = new Especialidades();
                    HorariosTrabajo horariosTrabajo = new HorariosTrabajo();

                    aux.ID = (int)accesoDatos.Lector["ID"];
                    aux.Nombre = (string)accesoDatos.Lector["NOMBRES"];
                    aux.Apellido = (string)accesoDatos.Lector["APELLIDOS"];
                    aux.DNI = (string)accesoDatos.Lector["DNI"];
                    aux.Matricula = (int)accesoDatos.Lector["MATRICULA"];
                    aux.Email = (string)accesoDatos.Lector["EMAIL"];
                    aux.Estado = (bool)accesoDatos.Lector["ESTADO"];

                    AccesoDatos accesoEspecialidades = new AccesoDatos();
                    accesoEspecialidades.setConsulta("SELECT E.ID as IDE, E.NOMBRE as ESPECIALIDAD FROM ESPECIALIDADES E INNER JOIN ESPECIALIDAD_X_MEDICO ExM ON ExM.ID_ESPECIALIDAD = E.ID INNER JOIN MEDICOS M ON M.ID = ExM.ID_MEDICO WHERE M.ID = @ID");
                    accesoEspecialidades.setParametro("@ID", aux.ID);
                    accesoEspecialidades.ejecutarLectura();
                    aux.Especialidad = new List<Especialidades>();

                    while (accesoEspecialidades.Lector.Read())
                    {
                        especialidades.ID = (int)accesoEspecialidades.Lector["IDE"];
                        especialidades.Nombre = (string)accesoEspecialidades.Lector["ESPECIALIDAD"];
                        aux.Especialidad.Add(especialidades);
                    }

                    AccesoDatos accesoHorarios = new AccesoDatos();
                    accesoHorarios.setParametro("@ID", aux.ID);
                    accesoHorarios.setConsulta("SELECT HT.DIA, HT.H_ENTRADA, HT.H_SALIDA, HT.LIBRE FROM HORARIOS_TRABAJO HT INNER JOIN MEDICOS M ON M.ID = HT.ID_MEDICO WHERE M.ID = @ID");
                    accesoHorarios.ejecutarLectura();
                    aux.HorariosTrabajo = new List<HorariosTrabajo>();

                    while (accesoHorarios.Lector.Read())
                    {
                        horariosTrabajo.Dia = (string)accesoDatos.Lector["DIA"];
                        horariosTrabajo.HorarioEntrada = (int)accesoDatos.Lector["H_ENTRADA"];
                        horariosTrabajo.HorarioSalida = (int)accesoDatos.Lector["H_SALIDA"];
                        horariosTrabajo.Libre = (bool)accesoDatos.Lector["LIBRE"];
                        aux.HorariosTrabajo.Add(horariosTrabajo);
                    }

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

        public bool AgregarMedico(Medicos obj)
        {
            try
            {
                accesoDatos.setProcedimiento("SP_ALTA_MEDICO");
                accesoDatos.setParametro("@NOMBRE", obj.Nombre);
                accesoDatos.setParametro("@APELLIDO", obj.Apellido);
                accesoDatos.setParametro("@MATRICULA", obj.Matricula);
                accesoDatos.setParametro("@DNI", obj.DNI);
                accesoDatos.setParametro("@EMAIL", obj.Email);
                accesoDatos.setParametro("@CONTRASEÑA", obj.Contrasenia);
                accesoDatos.ejecutarAccion();
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
