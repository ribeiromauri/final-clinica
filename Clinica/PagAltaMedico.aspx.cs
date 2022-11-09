using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Controlador;

namespace Clinica
{
    public partial class PagAltas : System.Web.UI.Page
    {
        private ControladorEspecialidades ctrlEspecialidades = new ControladorEspecialidades();
        private List<Especialidades> listaEspecialidades = new List<Especialidades>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    listaEspecialidades = ctrlEspecialidades.ListarEspecialidades();
                    chkEspecialidades.DataSource = listaEspecialidades;
                    chkEspecialidades.DataBind();
                    Session.Add("Especialidades", listaEspecialidades);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {

        }
    }
}