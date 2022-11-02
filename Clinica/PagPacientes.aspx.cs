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