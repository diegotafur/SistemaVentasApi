using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Deuda
    {
        
        public int idFiado { get; set; }
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        public int idEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaFiado { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        // public int estado { get; set; }
        //public double adelanto { get; set; }
        //public double resta { get; set; }
        public double importe { get; set; }
        //public DateTime fechaPago { get; set; }
       
        //public List<Producto> productos { get; set; }

    }
}
