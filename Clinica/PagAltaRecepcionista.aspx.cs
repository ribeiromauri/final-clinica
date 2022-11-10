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
        Recepcionista aux = new Recepcionista();
        ControladorRecepcionista ctrlRecepcionista = new ControladorRecepcionista();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                aux.Nombre = nombreRecepcionista.Text;
                aux.Apellido = apellidoRecepcionista.Text;
                aux.DNI = dniRecepcionista.Text;
                aux.Email = emailRecepcionista.Text;
                aux.Contrasenia = passRecepcionista.Text;
                
                if(ValidarDatos(aux.DNI, aux.Email))
                {
                    if (ctrlRecepcionista.AgregarRecepcionista(aux))
                    {
                        Response.Redirect("PagPrincipal.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarDatos(string dni, string email)
        {
            List<Recepcionista> recepcionistas = ctrlRecepcionista.ListarRecepcionistas();
            if(recepcionistas.Exists(x => x.DNI == dni))
            {
                Validaciones.Text = "Ya existe registro con DNI " + aux.DNI;
                return false;
            }
            if(recepcionistas.Exists(x => x.Email == email))
            {
                Validaciones.Text = "Ya existe registro con email " + aux.Email;
                return false;
            }
            return true;
        }
    }
}