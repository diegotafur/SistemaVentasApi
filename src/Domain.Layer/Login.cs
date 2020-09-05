using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Layer
{
    public class Login
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }

        public string token { set; get; }
        public DateTime expiracion { set; get; }
    }
}
