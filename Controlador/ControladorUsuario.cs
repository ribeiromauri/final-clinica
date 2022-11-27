using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class ControladorUsuario
    {
        public bool Loguear(Usuarios usuario)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setConsulta("SELECT ID_USUARIO, TIPO_USUARIO, DNI_USUARIO, CONTRASEÑA FROM ADM_USUARIOS WHERE DNI_USUARIO = @dniuser AND CONTRASEÑA = @pass");
				datos.setParametro("@dniuser", usuario.DniUsuario);
				datos.setParametro("@pass", usuario.Contrasenia);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					usuario.ID = (int)datos.Lector["ID_USUARIO"];
					usuario.Tipo = (int)(datos.Lector["TIPO_USUARIO"]) == 1 ? TipoUsuario.ADMIN : ((int)(datos.Lector["TIPO_USUARIO"]) == 2 ? TipoUsuario.RECEPCIONISTA : TipoUsuario.MEDICO);

					return true;
				}
				return false;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
