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
            ControladorMedicos controlador = new ControladorMedicos();
            listaMedicos = controlador.listar();
            Medicos aux = new Medicos();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaMedicos;
                repRepetidor.DataBind();
            }
        }
    }
}