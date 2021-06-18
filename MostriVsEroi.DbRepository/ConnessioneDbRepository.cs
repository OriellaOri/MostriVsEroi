using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    static class ConnessioneDbRepository
    {
        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;" +
            "Initial Catalog = MostriVsEroi;" +
            "integrated Security=true;";

        public static void Connessione(out SqlConnection connection, out SqlCommand cmd)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
            }
            catch (SqlException sqle)
            {
                Console.WriteLine("Problemi con DB/Query  \n\n");
                Console.WriteLine($"Dettaglio: {sqle.Message}\n\n");
                connection = null;
                cmd = null;
            }

        }

    }
}
