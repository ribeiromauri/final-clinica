using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pacientes
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
        }
    }
}
