using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuarios
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public TipoUsuario Tipo { get; set; }
        public bool Estado { get; set; }
    }
}
