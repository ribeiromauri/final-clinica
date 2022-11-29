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
    public partial class PagAltaRecepcionista : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        public bool BotonEliminar { get; set; }

        Recepcionista aux = new Recepcionista();
        ControladorRecepcionista ctrlRecepcionista = new ControladorRecepcionista();

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

            ConfirmarEliminacion = false;
            BotonEliminar = false;

            if (Request.QueryString["id"] != null)
            {
                BotonEliminar = true;
            }
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ControladorRecepcionista controlador = new ControladorRecepcionista();
                List<Recepcionista> lista = controlador.ListarRecepcionistas(Request.QueryString["id"].ToString());
                Recepcionista seleccionado = lista[0];

                nombreRecepcionista.Text = seleccionado.Nombre;
                apellidoRecepcionista.Text = seleccionado.Apellido;
                dniRecepcionista.Text = seleccionado.DNI;
                emailRecepcionista.Text = seleccionado.Email;
                passRecepcionista.Text = seleccionado.Contrasenia;
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                ControladorRecepcionista controlador = new ControladorRecepcionista();

                aux.Nombre = nombreRecepcionista.Text;
                aux.Apellido = apellidoRecepcionista.Text;
                aux.DNI = dniRecepcionista.Text;
                aux.Email = emailRecepcionista.Text;
                aux.Contrasenia = passRecepcionista.Text;

                if (Request.QueryString["id"] != null)
                {
                    aux.ID = int.Parse(Request.QueryString["id"].ToString());
                    controlador.modificarRecepcionista(aux);
                }
                else if (ValidarDatos(aux.DNI, aux.Email))
                {
                    ctrlRecepcionista.AgregarRecepcionista(aux);
                }
                Response.Redirect("PagRecepcionista.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarDatos(string dni, string email)
        {
            List<Recepcionista> recepcionistas = ctrlRecepcionista.ListarRecepcionistas();
            if (recepcionistas.Exists(x => x.DNI == dni))
            {
                Validaciones.Text = "Ya existe registro con DNI " + aux.DNI;
                return false;
            }
            if (recepcionistas.Exists(x => x.Email == email))
            {
                Validaciones.Text = "Ya existe registro con email " + aux.Email;
                return false;
            }
            return true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacionRecep.Checked)
                {
                    ControladorRecepcionista controlador = new ControladorRecepcionista();
                    controlador.eliminarRecepcionista(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("PagRecepcionista.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}