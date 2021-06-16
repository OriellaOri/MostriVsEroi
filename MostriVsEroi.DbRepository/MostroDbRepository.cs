using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class MostroDbRepository : IMostroRepository
    {
        public List<Mostro> FetchMostri()
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<Mostro> mostri = new List<Mostro>();

            cmd.CommandText = "SELECT * from dbo.ListaMostri;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nome        = (string)reader[0];
                var categoria   = (string)reader[1];
                var livello     = (int)reader[2];
                var pv          = (int)reader[3];
                var nomeArma    = (string)reader[4];
                var dannoArma   = (int)reader[5];

                Mostro m = new Mostro(nome, categoria, livello, new Arma (nomeArma,dannoArma), pv);
                mostri.Add(m);
            }
            connection.Close();
            return mostri;
        }
    }
}
