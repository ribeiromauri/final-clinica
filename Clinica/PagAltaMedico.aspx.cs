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
        private List<HorariosTrabajo> listaDias = new List<HorariosTrabajo>();
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

                    listaDias = ctrlHorariosTrabajo.listar();
                    chkDiasTrabajo.DataSource = listaDias;
                    chkDiasTrabajo.DataBind();
                    Session.Add("Dias", listaDias);

                    List<Medicos> lista = ctrlMedico.listar(Request.QueryString["id"].ToString());
                    auxMedico = lista[0];

                    nombreMedico.Text = auxMedico.Nombre;
                    apellidoMedico.Text = auxMedico.Apellido;
                    dniMedico.Text = auxMedico.DNI;
                    matriculaMedico.Text = auxMedico.Matricula.ToString();
                    emailMedico.Text = auxMedico.Email;
                    passMedico.Text = auxMedico.Contrasenia;
                    txtHorarioEntrada.Text = auxMedico.HorarioEntrada.ToString();
                    txtHorarioSalida.Text = auxMedico.HorarioSalida.ToString();

                    //Agregar los chkEspecialidades del Medico que se quiere modificar
                    List<Especialidades> listaFiltrada = ctrlEspecialidades.ListarEspecialidadPorMedico(int.Parse(Request.QueryString["id"]));

                    foreach (ListItem item in chkEspecialidades.Items)
                    {
                        if (listaFiltrada.Exists(x => x.Nombre.ToUpper() == item.Value.ToUpper()))
                        {
                            item.Selected = true;
                        }
                    }
                }
                else if (!IsPostBack)
                {
                    listaEspecialidades = ctrlEspecialidades.ListarEspecialidades();
                    chkEspecialidades.DataSource = listaEspecialidades;
                    chkEspecialidades.DataBind();
                    Session.Add("Especialidades", listaEspecialidades);

                    listaDias = ctrlHorariosTrabajo.listar();
                    chkDiasTrabajo.DataSource = listaDias;
                    chkDiasTrabajo.DataBind();
                    Session.Add("Dias", listaDias);
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
                listaDias = (List<HorariosTrabajo>)Session["Dias"];
                List<Especialidades> espSeleccionadas = new List<Especialidades>();
                List<HorariosTrabajo> diasSeleccionados = new List<HorariosTrabajo>();

                auxMedico.Nombre = nombreMedico.Text;
                auxMedico.Apellido = apellidoMedico.Text;
                auxMedico.DNI = dniMedico.Text;
                auxMedico.Matricula = int.Parse(matriculaMedico.Text);
                auxMedico.Email = emailMedico.Text;
                auxMedico.DniUsuario = auxMedico.DNI;
                auxMedico.Tipo = TipoUsuario.MEDICO;
                auxMedico.Contrasenia = passMedico.Text;

                auxMedico.HorarioEntrada = int.Parse(txtHorarioEntrada.Text);
                auxMedico.HorarioSalida = int.Parse(txtHorarioSalida.Text);

                if (Request.QueryString["id"] != null)
                {
                    //Elimino de la base de datos las especialidades x medicos asi a la hora de volver a cargarlas las "pisa"
                    ctrlEspecialidades.EliminarEspecialidadPorMedico(int.Parse(Request.QueryString["id"]));
                    ctrlHorariosTrabajo.EliminarHorariosPorMedico(int.Parse(Request.QueryString["id"]));

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
                            diasSeleccionados.Add(listaDias.Find(x => x.Dia == item.Value));
                        }
                    }

                    auxMedico.HorariosTrabajo = diasSeleccionados;
                    auxMedico.Especialidad = espSeleccionadas;

                    auxMedico.ID = int.Parse(Request.QueryString["id"]);

                    ctrlMedico.ModificarMedico(auxMedico);
                    ctrlEspecialidades.AgregarEspecialidadPorMedico(auxMedico, auxMedico.ID);
                    ctrlHorariosTrabajo.AgregarHorariosPorMedico(auxMedico, auxMedico.ID);
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
                            diasSeleccionados.Add(listaDias.Find(x => x.Dia == item.Value));
                        }
                    }

                    auxMedico.HorariosTrabajo = diasSeleccionados;
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