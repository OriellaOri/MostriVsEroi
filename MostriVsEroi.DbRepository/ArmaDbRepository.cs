using MostriVsEroi.Core;
using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MostriVsEroi.DbRepository
{
    public class ArmaDbRepository : IArmaRepository
    {
        [Obsolete]
        public List<Arma> FetchArmiEroi()
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<Arma> armiEroi = new List<Arma>();

            cmd.CommandText = "SELECT nome,danno FROM dbo.ArmiEroi";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nome = (string)reader[0];
                var danno = (int)reader[1];

                Arma a = new Arma(nome, danno);
                armiEroi.Add(a);
            }
            connection.Close();
            return armiEroi;
        }

        public List<Arma> FetchArmiEroe(string categoria)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<Arma> armiEroi = new List<Arma>();

            cmd.CommandText = "SELECT Nome, Danno FROM dbo.ArmiPerCategoriaEroe WHERE CategoriaEroe = @CategoriaEroe;";

            cmd.Parameters.AddWithValue("@CategoriaEroe", categoria);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nome = (string)reader[0];
                var danno = (int)reader[1];

                Arma a = new Arma(nome, danno);
                armiEroi.Add(a);
            }
            connection.Close();
            return armiEroi;
        }

        public List<Arma> FetchArmiMostro(Mostro mostro)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<Arma> armi = new List<Arma>();

            cmd.CommandText = "SELECT Nome, Danno" +
                              "FROM dbo.ArmiPerCategoriaMostro WHERE CategoriaMostro = @CategoriaMostro;";

            cmd.Parameters.AddWithValue("@CategoriaMostro", mostro);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nome = (string)reader[0];
                var danno = (int)reader[1];

                Arma a = new Arma(nome, danno);
                armi.Add(a);
            }
            connection.Close();
            return armi;
        }
    }
}
