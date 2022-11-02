using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HorariosTrabajo
    {
        public string Dia { get; set; }
        public int HorarioEntrada { get; set; }
        public int HorarioSalida { get; set; }
        public bool Libre { get; set; }
    }
}
