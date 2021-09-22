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
    public class CategoriaDbRepository : ICategoriaRepository
    {
        [Obsolete]
        public List<string> FetchCategorie()
        {
            throw new NotImplementedException();
            /* NON IMPLEMENTO MI SERVIVA PER LA MOCK */
        }

        public List<string> FetchCategorieEroi()
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<string> categorie = new List<string>();

            cmd.CommandText = "SELECT Nome FROM dbo.CategorieEroi;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nome = (string)reader[0];

                categorie.Add(nome);
            }
            connection.Close();
            return categorie;
        }

        public List<string> FetchCategorieMostri()
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<string> categorie = new List<string>();

            cmd.CommandText = "SELECT Nome FROM dbo.CategorieMostri;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nome = (string)reader[0];

                categorie.Add(nome);
            }
            connection.Close();
            return categorie;
        }

    }
}
