using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Common.Layer
{
    public static class ValidarString
    {

        public static  string ValidarStringDataReader(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }


    }
}
