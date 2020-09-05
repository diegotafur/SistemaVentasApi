using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaComedor.Data
{
    public class Respuesta
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Error = false;
        }
    }
}
