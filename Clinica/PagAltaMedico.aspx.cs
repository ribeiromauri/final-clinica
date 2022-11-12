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
        public bool ConfirmarEliminacion { get; set; }
        public bool BotonEliminar { get; set; }

        private ControladorEspecialidades ctrlEspecialidades = new ControladorEspecialidades();
        private ControladorMedicos ctrlMedico = new ControladorMedicos();
        private List<Especialidades> listaEspecialidades = new List<Especialidades>();
        private Medicos auxMedico = new Medicos();

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
            BotonEliminar = false;

            try
            {
                if (Request.QueryString["id"] != null)
                {
                    BotonEliminar = true;
                }
                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    listaEspecialidades = ctrlEspecialidades.ListarEspecialidades();
                    chkEspecialidades.DataSource = listaEspecialidades;
                    chkEspecialidades.DataBind();
                    Session.Add("Especialidades", listaEspecialidades);

                    List<Medicos> lista = ctrlMedico.listar(Request.QueryString["id"].ToString());
                    auxMedico = lista[0];

                    nombreMedico.Text = auxMedico.Nombre;
                    apellidoMedico.Text = auxMedico.Apellido;
                    dniMedico.Text = auxMedico.DNI;
                    matriculaMedico.Text = auxMedico.Matricula.ToString();
                    emailMedico.Text = auxMedico.Email;
                    passMedico.Text = auxMedico.Contrasenia;

                    //Agregar los chkEspecialidades del Medico que se quiere modificar

                }
                else if (!IsPostBack)
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

                if (Request.QueryString["id"] != null)
                {
                    //Elimino de la base de datos las especialidades x medicos asi a la hora de volver a cargarlas las "pisa"
                    ctrlEspecialidades.EliminarEspecialidadPorMedico(int.Parse(Request.QueryString["id"]));

                    foreach (ListItem item in chkEspecialidades.Items)
                    {
                        if (item.Selected == true)
                        {
                            espSeleccionadas.Add(listaEspecialidades.Find(x => x.Nombre == item.Value));
                        }
                    }

                    auxMedico.Especialidad = espSeleccionadas;
                    auxMedico.ID = int.Parse(Request.QueryString["id"]);
                    ctrlMedico.ModificarMedico(auxMedico);
                    ctrlEspecialidades.AgregarEspecialidadPorMedico(auxMedico, int.Parse(Request.QueryString["id"]));
                } //Validar datos antes de cargar el registro
                else if (ValidarDatos(auxMedico.Matricula, auxMedico.Email, auxMedico.DNI))
                {
                    foreach (ListItem item in chkEspecialidades.Items)
                    {
                        if (item.Selected == true)
                        {
                            espSeleccionadas.Add(listaEspecialidades.Find(x => x.Nombre == item.Value));
                        }
                    }

                    auxMedico.Especialidad = espSeleccionadas;
                    if (ctrlMedico.AgregarMedico(auxMedico))
                    {
                        ctrlEspecialidades.AgregarEspecialidadPorMedico(auxMedico);
                    }
                }
                Response.Redirect("PagMedicos.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool ValidarDatos(int matricula, string email, string dni)
        {
            List<Medicos> listaMedicos = ctrlMedico.listar();
            if (listaMedicos.Exists(x => x.Matricula == matricula))
            {
                Validaciones.Text = "Ya existe registro con número de matrícula " + auxMedico.Matricula.ToString();
                return false;
            }
            if (listaMedicos.Exists(x => x.Email == email))
            {
                Validaciones.Text = "Ya existe registro con mail " + auxMedico.Email;
                return false;
            }
            if (listaMedicos.Exists(x => x.DNI == dni))
            {
                Validaciones.Text = "Ya existe registro con DNI " + auxMedico.DNI;
                return false;
            }
            return true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacionMed.Checked)
                {
                    ControladorMedicos controlador = new ControladorMedicos();
                    controlador.EliminarMedico(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("PagMedicos.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}