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
                    datos.setConsulta("INSERT INTO HORARIOS_TRABAJO VALUES (@DIA, @ID_MEDICO, @H_ENTRADA, @H_SALIDA, 0)");
                    datos.setParametro("@DIA", horarios.Dia);
                    datos.setParametro("@ID_MEDICO", id);
                    datos.setParametro("@H_ENTRADA", horarios.HorarioEntrada);
                    datos.setParametro("@H_SALIDA", horarios.HorarioSalida);
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
    }
}
