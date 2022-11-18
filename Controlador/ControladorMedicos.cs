using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Dominio;

namespace Controlador
{
    public class ControladorMedicos
    {
        private List<Especialidades> listaEspecialidades = new List<Especialidades>();
        private List<HorariosTrabajo> listaDias = new List<HorariosTrabajo>();
        private ControladorEspecialidades ctrlEspecialidades = new ControladorEspecialidades();
        private ControladorHorariosTrabajo ctrlDias = new ControladorHorariosTrabajo();
        public List<Medicos> listar(string id = "")
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Medicos> lista = new List<Medicos>();

            listaEspecialidades = ctrlEspecialidades.ListarEspecialidades();
            listaDias = ctrlDias.listar();
            
            try
            {
                if(id != "")
                {
                    accesoDatos.setConsulta("SELECT ID, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, MATRICULA, EMAIL, ESTADO FROM MEDICOS WHERE ID = @ID");
                    accesoDatos.setParametro("@ID", id);
                }
                else
                {
                    accesoDatos.setConsulta("SELECT ID, CONTRASEÑA, NOMBRES, APELLIDOS, DNI, MATRICULA, EMAIL, ESTADO FROM MEDICOS");
                }
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
                    aux.Contrasenia = (string)accesoDatos.Lector["CONTRASEÑA"];
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
                        foreach (Especialidades item in listaEspecialidades)
                        {
                            if(especialidades.Nombre == item.Nombre)
                            {
                                aux.Especialidad.Add(listaEspecialidades.Find(x => x.Nombre == item.Nombre));
                            }
                        }
                    }
                    accesoEspecialidades.cerrarConexion();

                    AccesoDatos accesoDias = new AccesoDatos();
                    accesoDias.setConsulta("SELECT HT.DIA as DIA FROM HORARIOS_TRABAJO HT INNER JOIN MEDICOS M ON M.ID = HT.ID_MEDICO WHERE M.ID = @ID");
                    accesoDias.setParametro("@ID", aux.ID);
                    accesoDias.ejecutarLectura();
                    
                    aux.HorariosTrabajo = new List<HorariosTrabajo>();

                    while (accesoDias.Lector.Read())
                    {
                        horariosTrabajo.Dia = (string)accesoDias.Lector["DIA"];
                        foreach (HorariosTrabajo item in listaDias)
                        {
                            if(horariosTrabajo.Dia == item.Dia)
                            {
                                aux.HorariosTrabajo.Add(listaDias.Find(x => x.Dia == item.Dia));
                            }
                        }
                    }
                    accesoDias.cerrarConexion();

                    //AccesoDatos accesoHorarios = new AccesoDatos();
                    //accesoHorarios.setConsulta("SELECT HT.H_ENTRADA AS H_ENTRADA, HT.H_SALIDA AS H_SALIDA, HT.LIBRE AS LIBRE FROM HORARIOS_TRABAJO HT INNER JOIN MEDICOS M ON M.ID = HT.ID_MEDICO WHERE M.ID = @ID");
                    //accesoHorarios.setParametro("@ID", aux.ID);
                    //accesoHorarios.ejecutarLectura();

                    //while (accesoHorarios.Lector.Read())
                    //{
                    //    aux.HorarioEntrada = (int)accesoHorarios.Lector["H_ENTRADA"];
                    //    aux.HorarioSalida = (int)accesoHorarios.Lector["H_SALIDA"];
                    //}
                    //accesoHorarios.cerrarConexion();

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

        public List<Medicos> ListarPorEspecialidad(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Medicos> lista = new List<Medicos>();

            listaEspecialidades = ctrlEspecialidades.ListarEspecialidades();
            listaDias = ctrlDias.listar();

            try
            {
                accesoDatos.setConsulta("SELECT M.ID, M.CONTRASEÑA, M.NOMBRES, M.APELLIDOS, M.DNI, M.MATRICULA, M.EMAIL, M.ESTADO FROM MEDICOS M INNER JOIN ESPECIALIDAD_X_MEDICO EXM ON EXM.ID_MEDICO = M.ID INNER JOIN ESPECIALIDADES E ON E.ID = EXM.ID_ESPECIALIDAD WHERE E.ID = @ID");
                accesoDatos.setParametro("@ID", id);
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
                    aux.Contrasenia = (string)accesoDatos.Lector["CONTRASEÑA"];
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
                        foreach (Especialidades item in listaEspecialidades)
                        {
                            if (especialidades.Nombre == item.Nombre)
                            {
                                aux.Especialidad.Add(listaEspecialidades.Find(x => x.Nombre == item.Nombre));
                            }
                        }
                    }
                    accesoEspecialidades.cerrarConexion();

                    AccesoDatos accesoDias = new AccesoDatos();
                    accesoDias.setConsulta("SELECT HT.DIA as DIA FROM HORARIOS_TRABAJO HT INNER JOIN MEDICOS M ON M.ID = HT.ID_MEDICO WHERE M.ID = @ID");
                    accesoDias.setParametro("@ID", aux.ID);
                    accesoDias.ejecutarLectura();

                    aux.HorariosTrabajo = new List<HorariosTrabajo>();

                    while (accesoDias.Lector.Read())
                    {
                        horariosTrabajo.Dia = (string)accesoDias.Lector["DIA"];
                        foreach (HorariosTrabajo item in listaDias)
                        {
                            if (horariosTrabajo.Dia == item.Dia)
                            {
                                aux.HorariosTrabajo.Add(listaDias.Find(x => x.Dia == item.Dia));
                            }
                        }
                    }
                    accesoDias.cerrarConexion();

                    //AccesoDatos accesoHorarios = new AccesoDatos();
                    //accesoHorarios.setConsulta("SELECT HT.H_ENTRADA AS H_ENTRADA, HT.H_SALIDA AS H_SALIDA, HT.LIBRE AS LIBRE FROM HORARIOS_TRABAJO HT INNER JOIN MEDICOS M ON M.ID = HT.ID_MEDICO WHERE M.ID = @ID");
                    //accesoHorarios.setParametro("@ID", aux.ID);
                    //accesoHorarios.ejecutarLectura();

                    //while (accesoHorarios.Lector.Read())
                    //{
                    //    aux.HorarioEntrada = (int)accesoHorarios.Lector["H_ENTRADA"];
                    //    aux.HorarioSalida = (int)accesoHorarios.Lector["H_SALIDA"];
                    //}
                    //accesoHorarios.cerrarConexion();

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

        public List<HorariosTrabajo> ListarDias(int ID)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<HorariosTrabajo> lista = new List<HorariosTrabajo>();
            listaDias = ctrlDias.listar();

            try
            {
                accesoDatos.setConsulta("SELECT D.ID AS ID, HT.DIA AS DIA FROM HORARIOS_TRABAJO HT INNER JOIN DIAS D ON D.DIA = HT.DIA WHERE ID_MEDICO = @ID");
                accesoDatos.setParametro("@ID", ID);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    HorariosTrabajo aux = new HorariosTrabajo();

                    aux.ID = (int)accesoDatos.Lector["ID"];
                    aux.Dia = (string)accesoDatos.Lector["DIA"];

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
            AccesoDatos accesoDatos = new AccesoDatos();
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

        public void ModificarMedico(Medicos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimiento("SP_MODIFICAR_MEDICO");

                datos.setParametro("@Nombres", nuevo.Nombre);
                datos.setParametro("@Apellidos", nuevo.Apellido);
                datos.setParametro("@DNI", nuevo.DNI);
                datos.setParametro("@Matricula", nuevo.Matricula);
                datos.setParametro("@Email", nuevo.Email);
                datos.setParametro("Contraseña", nuevo.Contrasenia);
                datos.setParametro("@ID", nuevo.ID);

                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarMedico(int ID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setProcedimiento("SP_ELIMINAR_MEDICO");
                datos.setParametro("ID", ID);
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
