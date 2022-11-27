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
            if (((Usuarios)Session["usuario"]).Tipo != TipoUsuario.ADMIN)
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
    }
}