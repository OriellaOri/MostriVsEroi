using MostriVsEroi.Core;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class LivelloDbRepository : ILivelloRepository
    {
        public Dictionary<int, int> GetLivelliConVita()
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            Dictionary<int, int> livelliVita = new Dictionary<int, int>();
            cmd.CommandText = "SELECT * from dbo.Livelli;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nLivello  = (int)reader[0];
                var puntiVita = (int)reader[1];
                livelliVita.Add(nLivello, puntiVita);
            }
            connection.Close();
            return livelliVita;
        }
    }
}
