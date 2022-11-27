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
            }
        }
    }
}