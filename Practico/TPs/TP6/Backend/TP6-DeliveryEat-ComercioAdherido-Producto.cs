using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP6_Historia_PedidoComercioAdherido.RepoHard;

namespace TP6_Historia_PedidoComercioAdherido.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Comercio comercio { get; set; }
        public float precioUnitario { get; set; }
        public int cantidad { get; set; }

        public static Producto obtenerProductoHard()
        {
            ObjetosHardcodeados obhc = ObjetosHardcodeados.getInstancia();
            return obhc.obtenerProductoRnd();
        }
    }
}