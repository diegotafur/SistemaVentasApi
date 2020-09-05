using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Pedido
    {
        public int IdVenta { set; get; }
        public string NombreCliente { set; get; }
        public string Celular { set; get; }
        public string Anexo { set; get; }
        public string Piso { set; get; }
        public string Area { set; get; }
        public string Oficina { set; get; }
        public string NombreProducto { set; get; }
        public int Cantidad { set; get; }
        public double PrecioVenta { set; get; }
        public double Importe { set; get; }
        public DateTime Fecha { set; get; }
        public string NombreEmpleado { set; get; }
    }
}
