using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoUsuario
    {
        public int ID { get; set; }
        public string[] Tipo = new string[3];
        public TipoUsuario()
        {
            Tipo[0] = "admin";
            Tipo[1] = "recepcionista";
            Tipo[2] = "medico";
        }
        public string VerTipoUsuario(int ID)
        {
            return Tipo[ID - 1];
        }

    }
}
