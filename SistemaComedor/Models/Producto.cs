using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaComedor.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int idCategoria { get; set; }
        public int idPresentacion { get; set; }
        public bool ventaEstado { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }
        public bool caducaDia { get; set; }

        

    }
}
