using Common.Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Services.Layer
{
    public class TestService
    {
        public static void TestConnection()
        {
            try
            {
                using (var context = new SqlConnection(Parameters.ConnectionString))
                {
                    context.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }


        }


    }
}
