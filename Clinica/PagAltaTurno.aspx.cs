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

        public ControladorEspecialidades ctrlEsp = new ControladorEspecialidades();
        public ControladorMedicos ctrlMedicos = new ControladorMedicos();
        public ControladorPacientes ctrlPacientes = new ControladorPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            ControladorMedicos controladorMedicos = new ControladorMedicos();

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
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEspecialidades.SelectedItem.Value);

            ddlMedicos.DataSource = ctrlMedicos.ListarPorEspecialidad(id);
            ddlMedicos.DataTextField = "Apellido";
            ddlMedicos.DataValueField = "ID";
            ddlMedicos.DataBind();

            //Revisar
            ddlMedicos_SelectedIndexChanged(sender, e);

            if(ddlMedicos.Items.Count == 0)
            {
                ddlHorarios.Items.Clear();
            }
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlMedicos.SelectedItem.Value);

            repDias.DataSource = ctrlMedicos.ListarDias(id);
            repDias.DataBind();

            ddlHorarios.DataSource = ctrlMedicos.ListarHorarios(id);
            ddlHorarios.DataBind();
        }

        protected void buscarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pacientes> listaPacientes = ctrlPacientes.listar();
                List<Pacientes> listaFiltrada = listaPacientes.FindAll(x => x.DNI.Contains(DNI.Text));
                if (listaFiltrada.Count == 0)
                {
                    paciente.Visible = false;
                    seleccionar.Visible = false;
                    cancelar.Visible = false;

                    txtValidar.Visible = true;
                    txtValidar.Text = "No existen registros para el DNI " + DNI.Text;
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
            }
        }
    }
}