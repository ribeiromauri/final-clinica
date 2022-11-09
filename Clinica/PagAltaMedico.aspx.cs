using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Controlador;

namespace Clinica
{
    public partial class PagAltas : System.Web.UI.Page
    {        
        private ControladorEspecialidades ctrlEspecialidades = new ControladorEspecialidades();
        private ControladorMedicos ctrlMedico = new ControladorMedicos();
        private List<Especialidades> listaEspecialidades = new List<Especialidades>();
        private Medicos auxMedico = new Medicos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (!IsPostBack)
                {
                    listaEspecialidades = ctrlEspecialidades.ListarEspecialidades();
                    chkEspecialidades.DataSource = listaEspecialidades;
                    chkEspecialidades.DataBind();
                    Session.Add("Especialidades", listaEspecialidades);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            //Agrega el médico pero no las especialidades x médico 
            try
            {
                listaEspecialidades = (List<Especialidades>)Session["Especialidades"];
                List<Especialidades> espSeleccionadas = new List<Especialidades>();
                auxMedico.Nombre = nombreMedico.Text;
                auxMedico.Apellido = apellidoMedico.Text;
                auxMedico.DNI = dniMedico.Text;
                auxMedico.Matricula = int.Parse(matriculaMedico.Text);
                auxMedico.Email = emailMedico.Text;
                auxMedico.DniUsuario = auxMedico.DNI;
                auxMedico.Tipo = TipoUsuario.MEDICO;
                auxMedico.Contrasenia = passMedico.Text;

                //Validar datos antes de cargar el registro

                foreach (ListItem item in chkEspecialidades.Items)
                {
                    if(item.Selected == true)
                    {
                        espSeleccionadas.Add(listaEspecialidades.Find(x => x.Nombre == item.Value));
                    }
                }

                auxMedico.Especialidad = espSeleccionadas;
                if (ctrlMedico.AgregarMedico(auxMedico)){
                    ctrlEspecialidades.AgregarEspecialidadPorMedico(auxMedico);
                    ValidacionMedico.Text = "Médico dado de alta con éxito";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}