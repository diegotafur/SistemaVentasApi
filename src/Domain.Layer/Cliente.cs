using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string direccion { get; set; }
        public string celular1 { get; set; }
        public string celular2 { get; set; }
        public string email { get; set; }
        public string facebook { get; set; }
        public string oficina { get; set; }
        public string piso { get; set; }
        public string anexo { get; set; } 
        public string area { get; set; } 
        public int estado { get; set; }

        public List<Deuda> deudas { get; set; }
    }
}
