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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Session.Add("error", "Ya hay un usuario logueado");
                Response.Redirect("PagError.aspx");
            }
        }

        protected void btnLoguear_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            ControladorUsuario controlador = new ControladorUsuario();

            try
            {
                usuario.DniUsuario = dniUsuario.Text;
                usuario.Contrasenia = passUsuario.Text;
                if (controlador.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("PagPrincipal.aspx", false);
                }
                else
                {
                    Session.Add("error", "DNI o Contraseña incorrectos");
                    Response.Redirect("PagError.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}