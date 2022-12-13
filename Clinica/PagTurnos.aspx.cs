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
    public partial class PagTurnos : System.Web.UI.Page
    {
        public List<Turnos> listaTurnos { get; set; }
        public List<Medicos> listaMedicos { get; set; }

        public ControladorTurnos ctrlTurnos = new ControladorTurnos();
        protected void Page_Load(object sender, EventArgs e)
        {           

            if (Session["usuario"] == null)
            {
                Session.Add("error", "No hay ningún usuario logueado");
                Response.Redirect("PagError.aspx");
            }
            if (((Usuarios)Session["usuario"]).Tipo != TipoUsuario.MEDICO)
            {
                listaTurnos = ctrlTurnos.Listar();
            }
            else
            {
                string dni = "";
                ControladorMedicos medicos = new ControladorMedicos();
                listaMedicos = medicos.listar();
                foreach (Medicos item in listaMedicos)
                {
                    if (item.DNI == ((Usuarios)Session["usuario"]).DniUsuario)
                    {
                        dni = item.DNI;
                    }
                }
                listaTurnos = ctrlTurnos.ListarPorMedico(dni);
            }

            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaTurnos;
                repRepetidor.DataBind();
                habilitarBotones(false);
            }
        }
        public bool TurnoVigente(object Estado)
        {
            if ((bool)Estado) return true;
            return false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Visible = false;
            List<Turnos> listaFiltrada = new List<Turnos>();
            if (Filtro.Text != "")
            {
                listaFiltrada = listaTurnos.FindAll(x => x.Medico.Nombre.ToLower().Contains(Filtro.Text.ToLower()) || x.Especialidad.Nombre.ToLower().Contains(Filtro.Text.ToLower()) || x.Paciente.Nombre.ToLower().Contains(Filtro.Text.ToLower()));
                if (listaFiltrada.Any())
                {
                    repRepetidor.DataSource = listaFiltrada;
                    repRepetidor.DataBind();
                }
                else
                {
                    txtBusqueda.Visible = true;
                    txtBusqueda.Text = "No hay turnos que coincidan con tu busqueda";
                    repRepetidor.DataSource = listaTurnos;
                    repRepetidor.DataBind();
                }
            }
            else
            {
                listaTurnos = ctrlTurnos.Listar();

                repRepetidor.DataSource = listaTurnos;
                repRepetidor.DataBind();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            habilitarBotones(true);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            List<Turnos> listaFiltrada = new List<Turnos>();
            if (rdVigente.Checked)
            {
                listaFiltrada = listaTurnos.FindAll(x => x.Estado == true);
                if (listaFiltrada.Any())
                {
                    repRepetidor.DataSource = listaFiltrada;
                    repRepetidor.DataBind();
                }
                else
                {
                    Response.Redirect("PagTurnos.aspx", true);
                }
            }
            else
            {
                listaFiltrada = listaTurnos.FindAll(x => x.Estado == false);
                if (listaFiltrada.Any())
                {
                    repRepetidor.DataSource = listaFiltrada;
                    repRepetidor.DataBind();
                }
                else
                {
                    Response.Redirect("PagTurnos.aspx", true);
                }
            }
        }

        public void habilitarBotones(bool estado)
        {
            if (estado)
            {
                rdVigente.Visible = true;
                rdFinalizados.Visible = true;
                //txtResultados.Visible = true;
                btnEnviar.Visible = true;
            }
            else
            {
                rdVigente.Visible = false;
                rdFinalizados.Visible = false;
                //txtResultados.Visible = false;
                btnEnviar.Visible = false;
            }
        }
    }
}