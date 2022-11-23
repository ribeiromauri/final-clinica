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
        protected void Page_Load(object sender, EventArgs e)
        {
            ControladorTurnos controlador = new ControladorTurnos();
            listaTurnos = controlador.Listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaTurnos;
                repRepetidor.DataBind();
            }
        }
    }
}