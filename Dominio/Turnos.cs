using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turnos
    {
        public int ID { get; set; }
        public Medicos Medico { get; set; }
        public Pacientes Paciente { get; set; }
        public Especialidades Especialidad { get; set; }
        public int HoraEntrada { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
    }
}
