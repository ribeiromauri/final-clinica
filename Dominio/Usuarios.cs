using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        RECEPCIONISTA = 2,
        MEDICO = 3
    }
    public class Usuarios
    {
        public int ID { get; set; }
        public string DniUsuario { get; set; }
        public string Contrasenia { get; set; }
        public TipoUsuario Tipo { get; set; }
        public bool Estado { get; set; }

    }
}
