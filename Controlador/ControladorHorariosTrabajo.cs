using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controlador;
using Dominio;

namespace Controlador
{
    public class ControladorHorariosTrabajo
    {
        public List<Medicos> ListaMedicos { get; set; }

        public List<HorariosTrabajo> listar(string id = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<HorariosTrabajo> lista = new List<HorariosTrabajo>();

            try
            {
                if (id != "")
                {
                    datos.setConsulta("SELECT D.ID, D.DIA FROM DIAS D INNER JOIN HORARIOS_TRABAJO HT ON HT.DIA = D.DIA WHERE HT.ID_MEDICO = @ID ");
                    datos.setParametro("@ID", id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, DIA FROM DIAS");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    HorariosTrabajo aux = new HorariosTrabajo();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Dia = (string)datos.Lector["DIA"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void AgregarHorariosPorMedico(Medicos aux)
        {
            AccesoDatos datos = new AccesoDatos();

            int id = 0;
            ControladorMedicos controlador = new ControladorMedicos();
            ListaMedicos = controlador.listar();

            foreach (Medicos medico in ListaMedicos)
            {
                if (aux.Matricula == medico.Matricula) //o comparar con el DNI
                {
                    id = medico.ID;
                }
            }
            try
            {
                foreach (HorariosTrabajo horarios in aux.HorariosTrabajo)
                {
                    datos.setConsulta("INSERT INTO HORARIOS_TRABAJO VALUES (@ID_MEDICO, @DIA, @H_ENTRADA, @H_SALIDA, 0)");
                    datos.setParametro("@ID_MEDICO", id);
                    datos.setParametro("@DIA", horarios.Dia);
                    datos.setParametro("@H_ENTRADA", aux.HorarioEntrada);
                    datos.setParametro("@H_SALIDA", aux.HorarioSalida);
                    datos.ejecutarAccion();
                    datos.limpiarParametros();
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AgregarHorariosPorMedico(Medicos aux, int ID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (HorariosTrabajo horarios in aux.HorariosTrabajo)
                {
                    datos.setConsulta("INSERT INTO HORARIOS_TRABAJO VALUES (@ID_MEDICO, @DIA, @H_ENTRADA, @H_SALIDA, 0)");
                    datos.setParametro("@ID_MEDICO", ID);
                    datos.setParametro("@DIA", horarios.Dia);
                    datos.setParametro("@H_ENTRADA", aux.HorarioEntrada);
                    datos.setParametro("@H_SALIDA", aux.HorarioSalida);
                    datos.ejecutarAccion();
                    datos.limpiarParametros();
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarHorariosPorMedico(int ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedimiento("SP_ELIMINAR_HORARIOSxMEDICO");
                datos.setParametro("@ID", ID);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
