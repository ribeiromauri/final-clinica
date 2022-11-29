using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Dominio;

namespace Clinica
{
    public partial class PagAltaTurno : System.Web.UI.Page
    {
        public List<Especialidades> listaEspecialidades { get; set; }
        public List<Medicos> listaMedicos { get; set; }
        public List<Pacientes> listaPacientes { get; set; }
        public List<Turnos> listaTurnos { get; set; }
        public bool ValidarDias { get; set; }
        public int IDMedico { get; set; }

        public ControladorEspecialidades ctrlEsp = new ControladorEspecialidades();
        public ControladorMedicos ctrlMedicos = new ControladorMedicos();
        public ControladorPacientes ctrlPacientes = new ControladorPacientes();
        public ControladorTurnos ctrlTurnos = new ControladorTurnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No hay ningún usuario logueado");
                Response.Redirect("PagError.aspx");
            }

            ControladorMedicos controladorMedicos = new ControladorMedicos();
            ValidarDias = true;

            if (!IsPostBack)
            {
                listaMedicos = ctrlMedicos.listar();
                Session["listaMedicos"] = listaMedicos;

                listaEspecialidades = ctrlEsp.ListarEspecialidades();

                ddlEspecialidades.DataSource = listaEspecialidades;
                ddlEspecialidades.DataTextField = "Nombre";
                ddlEspecialidades.DataValueField = "ID";
                ddlEspecialidades.DataBind();

            }
            if(!IsPostBack && Request.QueryString["id"] != null)
            {
                listaTurnos = ctrlTurnos.Listar(Request.QueryString["id"]);
                Turnos seleccionado = listaTurnos[0];

                txtDNI.Text = seleccionado.Paciente.DNI;

                ddlEspecialidades.SelectedValue = seleccionado.Especialidad.ID.ToString();

                ddlMedicos.DataSource = ctrlMedicos.listar(seleccionado.Medico.ID.ToString());
                ddlMedicos.DataTextField = "Apellido";
                ddlMedicos.DataValueField = "ID";
                ddlMedicos.DataBind();

                repDias.DataSource = ctrlMedicos.ListarDias(int.Parse(seleccionado.Medico.ID.ToString()));
                repDias.DataBind();

                txtFecha.Text = seleccionado.Fecha.ToShortDateString();

                ddlHorarios.DataSource = ctrlMedicos.ListarHorarios(int.Parse(seleccionado.Medico.ID.ToString()));
                ddlHorarios.DataBind();

                ddlHorarios.SelectedValue = seleccionado.HoraEntrada.ToString();

                txtObservaciones.Text = seleccionado.Observaciones;

            }
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEspecialidades.SelectedItem.Value);

            ddlMedicos.DataSource = ctrlMedicos.ListarPorEspecialidad(id);
            ddlMedicos.DataTextField = "Apellido";
            ddlMedicos.DataValueField = "ID";
            ddlMedicos.DataBind();

            //Revisar
            if(ddlMedicos.Items.Count != 0)
            {
                ddlMedicos_SelectedIndexChanged(sender, e);
            }
            if(ddlMedicos.Items.Count == 0)
            {
                ddlHorarios.Items.Clear();
            }
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDMedico = int.Parse(ddlMedicos.SelectedItem.Value);

            repDias.DataSource = ctrlMedicos.ListarDias(IDMedico);
            repDias.DataBind();

            ddlHorarios.DataSource = ctrlMedicos.ListarHorarios(IDMedico);
            ddlHorarios.DataBind();

            if (repDias.Items.Count == 0)
            {
                ValidarDias = false;
            }
            else
            {
                ValidarDias = true;
            }
        }

        protected void buscarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pacientes> listaPacientes = ctrlPacientes.listar();
                List<Pacientes> listaFiltrada = listaPacientes.FindAll(x => x.DNI.Contains(txtDNI.Text));
                if (listaFiltrada.Count == 0)
                {
                    paciente.Visible = false;
                    seleccionar.Visible = false;
                    cancelar.Visible = false;

                    txtValidar.Visible = true;
                    txtValidar.Text = "No existen registros para el DNI " + txtDNI.Text;
                    txtAlta.Visible = true;
                    txtAlta.Text = "Registrar paciente";

                }
                else
                {
                    txtValidar.Visible = false;
                    txtAlta.Visible = false;

                    //Sin funcionalidad aun 
                    paciente.DataSource = listaFiltrada;
                    paciente.DataBind();
                    paciente.Visible = true;
                    //Se puede crear un metodo onlick con el boton y que quede seleccionado el paciente para registrar
                    seleccionar.Visible = true;
                    cancelar.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagTurnos.aspx", false);
        }

        protected void calDias_SelectionChanged(object sender, EventArgs e)
        {
            if(calDias.SelectedDate < calDias.TodaysDate)
            {
                lblValidarDia.Text = "La fecha ya pasó. Seleccione otra";
                lblTest.Text = " ";
                txtFecha.Text = " ";
            }
            else
            {
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Monday")
                {
                    lblTest.Text = "Lunes";
                }
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Tuesday")
                {
                    lblTest.Text = "Martes";
                }
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Wednesday")
                {
                    lblTest.Text = "Miércoles";
                }
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Thursday")
                {
                    lblTest.Text = "Jueves";
                }
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Friday")
                {
                    lblTest.Text = "Viernes";
                }
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Saturday")
                {
                    lblTest.Text = "Sábado";
                }
                if (calDias.SelectedDate.DayOfWeek.ToString() == "Sunday")
                {
                    lblTest.Text = "Domingo";
                }

                lblValidarDia.Text = " ";

                txtFecha.Text = calDias.SelectedDate.ToShortDateString();

                IDMedico = int.Parse(ddlMedicos.SelectedValue.ToString());

                List<int> horariosMedico = ctrlMedicos.ListarHorarios(IDMedico);
                List<int> horariosEntradaNoDisponibles = ctrlTurnos.HorariosNoDisponibles(IDMedico, DateTime.Parse(calDias.SelectedDate.ToShortDateString()));

                foreach (int horarios in horariosEntradaNoDisponibles)
                {
                    horariosMedico.Remove(horarios);
                }

                ddlHorarios.DataSource = horariosMedico;
                ddlHorarios.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Turnos turnos = new Turnos();
            listaPacientes = ctrlPacientes.listar();

            try
            {
                turnos.Medico = new Medicos();
                turnos.Medico.ID = int.Parse(ddlMedicos.SelectedItem.Value);

                turnos.Paciente = new Pacientes();
                foreach (Pacientes item in listaPacientes)
                {
                    if(item.DNI == txtDNI.Text)
                    {
                        turnos.Paciente.ID = item.ID;
                    }
                }

                turnos.Especialidad = new Especialidades();
                turnos.Especialidad.ID = int.Parse(ddlEspecialidades.SelectedItem.Value);

                turnos.HoraEntrada = int.Parse(ddlHorarios.SelectedValue.ToString());
                turnos.Fecha = DateTime.Parse(txtFecha.Text);
                turnos.Observaciones = txtObservaciones.Text;

                ctrlTurnos.AgregarTurno(turnos);
                Response.Redirect("PagTurnos.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }                
    }
}