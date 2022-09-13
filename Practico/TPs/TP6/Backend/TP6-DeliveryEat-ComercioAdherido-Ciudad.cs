using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP6_Historia_PedidoComercioAdherido.RepoHard;

namespace TP6_Historia_PedidoComercioAdherido.Models
{
    public class Ciudad
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public static List<Ciudad> obtenerCiudades()
        {
            var obhc = ObjetosHardcodeados.getInstancia();
            List<Ciudad> resp = obhc.obtenerCiudades();
            if (resp.Count == 0)
                throw new ApplicationException("No se encontaron ciudades");
            return resp;
        }
        public bool esCiudadValida()
        {
            List<Ciudad> ciudadesValidas = ObjetosHardcodeados.getInstancia().obtenerCiudades();
            foreach (var ciudad in ciudadesValidas)
            {
                if (this.id == ciudad.id)
                    return true;
            }
            return false;
        }
    }
}