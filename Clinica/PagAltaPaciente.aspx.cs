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
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                controlador.agregarConSP(nuevo);
                Response.Redirect("PagPacientes.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}