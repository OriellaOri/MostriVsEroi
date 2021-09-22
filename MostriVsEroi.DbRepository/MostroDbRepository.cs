using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
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
        public void AddNewMostro(Mostro m)
        {
            int idCategoria = FetchIdCategoria(m);
            /* RECUPERO ID ARMA */
            int idArma = FetchIdArma(m);

            /* AGGIUNGO MOSTRO ALLA TABELLA*/
            ConnessioneDbRepository.Connessione(out SqlConnection cnt, out SqlCommand comand);
            comand.CommandText = "insert into dbo.Mostri values (@Nome, @IdLivello,@IdArma,@IdCategoriaMostri)";
            comand.Parameters.AddWithValue("@Nome", m.Nome);
            comand.Parameters.AddWithValue("@IdLivello", m.Livello);
            comand.Parameters.AddWithValue("@IdArma", idArma);
            comand.Parameters.AddWithValue("@IdCategoriaMostri", idCategoria);
            comand.ExecuteNonQuery();
            cnt.Close();
        }

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

        private int FetchIdCategoria(Mostro m)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select Id from dbo.CategorieMostri WHERE Nome = @Nome;";
            cmd.Parameters.AddWithValue("@Nome", m.Categoria);
            SqlDataReader lettore = cmd.ExecuteReader();
            int idCategoria = 0;
            while (lettore.Read())
            {
                var id = (int)lettore[0];
                idCategoria = id;
            }
            connection.Close();
            return idCategoria;
        }

        private int FetchIdArma(Mostro m)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection con, out SqlCommand command);
            command.CommandText = "select Id from dbo.ArmiMostri WHERE Nome = @Nome;";
            command.Parameters.AddWithValue("@Nome", m.Arma.Nome);
            SqlDataReader reader = command.ExecuteReader();
            int idArma = 0;
            while (reader.Read())
            {
                var id = (int)reader[0];
                idArma = id;
            }
            con.Close();
            return idArma;
        }
    }
}
