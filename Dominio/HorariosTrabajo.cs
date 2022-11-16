using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class HorariosTrabajo
    {
        public int ID { get; set; }
        public string Dia { get; set; }
        public override string ToString()
        {
            return Dia;
        }
    }

}
