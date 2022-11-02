using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controlador
{
    public class Carro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public int CantidadItems { get; set; }

        public List<ItemsCarro> ListaCarrito {get; set;}

        public Carro()
        {
            ListaCarrito = new List<ItemsCarro>();
            Importe = 0;
            CantidadItems = 0;
        }

        public int posicionDelItem(int ID)
        {
            int pos = ListaCarrito.FindIndex(x => x.ID == ID);
            return pos;
        }
        public void agregarItemsCarroAlCarrito(ItemsCarro item)
        {
            int pos = posicionDelItem(item.ID);
            if (pos == -1)
                ListaCarrito.Add(item);
            else ListaCarrito[pos].sumarCantidad();
        }
        public void restarItemsCarroAlCarrito(int ID)
        {
            int pos = posicionDelItem(ID);
            ListaCarrito[pos].restarCantidad();
            if (ListaCarrito[pos].Cantidad == 0)
            {
                eliminarItemDelCarrito(ID);
            }
        }
        public void agregarCantidadItem(int ID)
        {
            ListaCarrito[posicionDelItem(ID)].sumarCantidad();
        }

        public bool eliminarItemDelCarrito(int id)
        {
            if (ListaCarrito.Remove(ListaCarrito[posicionDelItem(id)]))
                return true;
            else return false;
        }
        public void calcularImporte()
        {
            if (ListaCarrito.Any())
            {
                Importe = 0;
                foreach (var item in ListaCarrito)
                {
                    Importe += item.Importe;
                }
            }
            else
            {
                Importe = 0;
            }
        }

        public void calcularCantidadItems()
        {
            foreach (var item in ListaCarrito)
            {
                CantidadItems += item.Cantidad;
            }
        }
    }
}
