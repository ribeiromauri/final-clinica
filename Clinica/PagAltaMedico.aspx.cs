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
        private ControladorHorariosTrabajo ctrlHorariosTrabajo = new ControladorHorariosTrabajo();
        private List<Especialidades> listaEspecialidades = new List<Especialidades>();
        private List<string> dias = new List<string>();
        private Medicos auxMedico = new Medicos();
        private HorariosTrabajo auxHorarios = new HorariosTrabajo();

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
            BotonEliminar = false;

            dias.Add("Lunes");
            dias.Add("Martes");
            dias.Add("Miércoles");
            dias.Add("Jueves");
            dias.Add("Viernes");
            dias.Add("Sábado");

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

                    chkDiasTrabajo.DataSource = dias;
                    chkDiasTrabajo.DataBind();

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

                    chkDiasTrabajo.DataSource = dias;
                    chkDiasTrabajo.DataBind();
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
                List<HorariosTrabajo> htSeleccionados = new List<HorariosTrabajo>();

                auxMedico.Nombre = nombreMedico.Text;
                auxMedico.Apellido = apellidoMedico.Text;
                auxMedico.DNI = dniMedico.Text;
                auxMedico.Matricula = int.Parse(matriculaMedico.Text);
                auxMedico.Email = emailMedico.Text;
                auxMedico.DniUsuario = auxMedico.DNI;
                auxMedico.Tipo = TipoUsuario.MEDICO;
                auxMedico.Contrasenia = passMedico.Text;

                auxHorarios.HorarioEntrada = int.Parse(txtHorarioEntrada.Text);
                auxHorarios.HorarioSalida = int.Parse(txtHorarioSalida.Text);

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
                    foreach (ListItem item in chkDiasTrabajo.Items)
                    {
                        auxHorarios.Dia = item.Value;
                        htSeleccionados.Add(auxHorarios);
                    }

                    auxMedico.HorariosTrabajo = htSeleccionados;
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
                    foreach (ListItem item in chkDiasTrabajo.Items)
                    {
                        if (item.Selected == true)
                        {
                            auxHorarios.Dia = item.Value;
                            htSeleccionados.Add(auxHorarios); //Se guarda el ultimo Dia en todo el List
                        }
                    }

                    auxMedico.HorariosTrabajo = htSeleccionados;
                    auxMedico.Especialidad = espSeleccionadas;
                    if (ctrlMedico.AgregarMedico(auxMedico))
                    {
                        ctrlEspecialidades.AgregarEspecialidadPorMedico(auxMedico);
                        ctrlHorariosTrabajo.AgregarHorariosPorMedico(auxMedico);
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