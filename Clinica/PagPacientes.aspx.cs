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
    public partial class PagPacientes : System.Web.UI.Page
    {
        public List<Pacientes> ListaPacientes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No hay ningún usuario logueado");
                Response.Redirect("PagError.aspx");
            }
            if (((Usuarios)Session["usuario"]).Tipo == TipoUsuario.MEDICO)
            {
                Session.Add("error", "No tenés permisos para ingresar a esta pantalla");
                Response.Redirect("PagError.aspx", false);
            }

            ControladorPacientes controlador = new ControladorPacientes();
            ListaPacientes = controlador.listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaPacientes;
                repRepetidor.DataBind();
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Visible = false;
            List<Pacientes> listaFiltrada = new List<Pacientes>();
            if(Filtro.Text != "")
            {
                listaFiltrada = ListaPacientes.FindAll(x => x.Nombre.ToLower().Contains(Filtro.Text.ToLower()) || x.Apellido.ToLower().Contains(Filtro.Text.ToLower()) || x.DNI.Contains(Filtro.Text));
                if (listaFiltrada.Any())
                {
                    repRepetidor.DataSource = listaFiltrada;
                    repRepetidor.DataBind();
                }
                else
                {
                    txtBusqueda.Visible = true;
                    txtBusqueda.Text = "No hay pacientes que coincidan con tu búsqueda";
                    repRepetidor.DataSource = ListaPacientes;
                    repRepetidor.DataBind();
                }
            }
        }
    }
}