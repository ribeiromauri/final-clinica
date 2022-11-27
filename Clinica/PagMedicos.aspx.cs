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
    public partial class PagMedicos : System.Web.UI.Page
    {
        public List<Medicos> listaMedicos { get; set; }
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

            ControladorMedicos controlador = new ControladorMedicos();
            listaMedicos = controlador.listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaMedicos;
                repRepetidor.DataBind();
            }
        }
    }
}