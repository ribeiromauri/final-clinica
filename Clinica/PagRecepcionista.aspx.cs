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
    public partial class PagRecepcionista : System.Web.UI.Page
    {
        public List<Recepcionista> ListaRecepcionistas { get; set; }
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

            ControladorRecepcionista controlador = new ControladorRecepcionista();
            ListaRecepcionistas = controlador.ListarRecepcionistas();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaRecepcionistas;
                repRepetidor.DataBind();
            }
        }
    }
}