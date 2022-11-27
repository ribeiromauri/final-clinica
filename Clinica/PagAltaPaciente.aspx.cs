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
    public partial class PagAltaPaciente : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        public bool BotonEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No hay ningún usuario logueado");
                Response.Redirect("PagError.aspx");
            }

            ConfirmarEliminacion = false;
            BotonEliminar = false;

            if (Request.QueryString["id"] != null)
            {
                BotonEliminar = true;
            }
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ControladorPacientes cont = new ControladorPacientes();
                List<Pacientes> lista = cont.listar(Request.QueryString["id"].ToString());
                Pacientes seleccionado = lista[0];

                txtNombre.Text = seleccionado.Nombre;
                txtApellido.Text = seleccionado.Apellido;
                txtDNI.Text = seleccionado.DNI;
                txtDomicilio.Text = seleccionado.Domicilio;
                txtEmail.Text = seleccionado.Email;
                txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("d");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pacientes nuevo = new Pacientes();
                ControladorPacientes controlador = new ControladorPacientes();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.DNI = txtDNI.Text;
                nuevo.Domicilio = txtDomicilio.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.ID = int.Parse(Request.QueryString["id"]);
                    controlador.modificarConSP(nuevo);
                }
                else
                {
                    controlador.agregarConSP(nuevo);
                }
                Response.Redirect("PagPacientes.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    ControladorPacientes controlador = new ControladorPacientes();
                    controlador.eliminar(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("PagPacientes.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }
    }
}