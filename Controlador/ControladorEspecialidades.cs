using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class ControladorEspecialidades
    {
        public List<Medicos> ListaMedicos { get; set; }

        AccesoDatos datos = new AccesoDatos();
        public List<Especialidades> ListarEspecialidades()
        {
            List<Especialidades> lista = new List<Especialidades>();
            try
            {
                datos.setConsulta("SELECT ID, NOMBRE FROM ESPECIALIDADES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidades aux = new Especialidades();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];

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
        public bool AgregarEspecialidadPorMedico(Medicos aux)
        {
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
                foreach (Especialidades especialidad in aux.Especialidad)
                {
                    datos.setConsulta("INSERT INTO ESPECIALIDAD_X_MEDICO VALUES (@ID_MEDICO, @ID_ESPECIALIDAD)");
                    datos.setParametro("@ID_MEDICO", id);
                    datos.setParametro("@ID_ESPECIALIDAD", especialidad.ID);
                    datos.ejecutarAccion();
                    datos.limpiarParametros();
                    datos.cerrarConexion();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
