using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medicos : Usuarios
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Matricula { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Especialidades> Especialidad { get; set; }
        public List<HorariosTrabajo> HorariosTrabajo { get; set; }
    }
}
