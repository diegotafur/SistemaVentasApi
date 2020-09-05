using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Layer
{
    public class ResponseHelper
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }



        public ResponseHelper()
        {
            this.Error = false;
        }


    }
}
