using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class ListaDelivery
    {

        public int  idVenta { get; set; }
        public string  nombreCliente { get; set; }
        public string celular { get; set; }
        public string anexo { get; set; }
        public string piso { get; set; }
        public string area { get; set; }
        public string oficina { get; set; }
        public string  producto { get; set; }
        public double  importe { get; set; }
        public DateTime  fecha { get; set; }
        public string  responsable { get; set; }

        //public Cliente cliente { get; set; }


    }
}
