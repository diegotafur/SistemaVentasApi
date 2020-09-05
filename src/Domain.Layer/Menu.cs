using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Menu
    {

        public int IdMenuDia { get; set; }
        public DateTime FechaServir { get; set; }

        public string Categoria { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

    }
}
