﻿using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class EroeDbRepository : IEroeRepository
    {
        public void AddNewEroe(Eroe newEroe, Utente utente)
        {
            /* RECUPERO ID UTENTE */
            int idUtente = FetchIdUtente(utente);
            /* RECUPERO ID CATEGORIA EROE*/
            int idCategoria = FetchIdCategoria(newEroe);         
            /* RECUPERO ID ARMA */
            int idArma = FetchIdArma(newEroe);

            /* AGGIUNGO EROE ALLA TABELLA*/
            // I VALORI NON INSERITI SONO ASSEGNATI DI DEFAULT NEL DB IN QUANTO NUOVI EROI
            ConnessioneDbRepository.Connessione(out SqlConnection cnt, out SqlCommand comand);
            comand.CommandText = "insert into dbo.Eroi (Nome,IdCategoriaEroe,IdUtente,IdArma) values (@Nome, @IdCategoriaEroe,@IdUtente,@IdArma)";
            comand.Parameters.AddWithValue("@Nome", newEroe.Nome);
            comand.Parameters.AddWithValue("@IdCategoriaEroe", idCategoria);
            comand.Parameters.AddWithValue("@IdUtente", idUtente);
            comand.Parameters.AddWithValue("@IdArma", idArma);
            comand.ExecuteNonQuery();
            cnt.Close();
        }

        public void DeleteEroe(Utente utente, Eroe eroe)
        {
            /* RECUPERO ID UTENTE */
            int idUtente = FetchIdUtente(utente);

            /* TRAMITE ID UTENTE ELIMINO L'EROE */
            ConnessioneDbRepository.Connessione(out SqlConnection con, out SqlCommand command);
            command.CommandText = "DELETE FROM dbo.Eroi WHERE Nome = @Nome AND IdUtente = @IdUtente; ";
            command.Parameters.AddWithValue("@Nome", eroe.Nome);
            command.Parameters.AddWithValue("@IdUtente", idUtente);
            command.ExecuteNonQuery();
            con.Close();
        }

        /* RECUPERO LISTA DEGLI ERORI DI UN UTENTE*/
        public List<Eroe> FetchEroi(Utente utente)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            List<Eroe> eroiUtente = new List<Eroe>();

            cmd.CommandText = "SELECT * FROM dbo.UtentiConEroi WHERE Username = @Username;";

            cmd.Parameters.AddWithValue("@Username", utente.Username);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var nomeEroe        = (string)reader[1];
                var categoriaEroe   = (string)reader[2];
                var livelloEroe     = (int)reader[3];
                var pvEroe          = (int)reader[4];
                var nomeArma        = (string)reader[5];
                var dannoArma       = (int)reader[6];
                var espereinza      = (int)reader[7];

                Eroe e = new Eroe(nomeEroe, categoriaEroe, new Arma(nomeArma, dannoArma), livelloEroe, pvEroe, espereinza);
                eroiUtente.Add(e);
            }
            connection.Close();
            return eroiUtente;
        }

        /* METODO PRIVATO PER RECUPARE ID-UTENTE*/
        private int FetchIdUtente(Utente utente)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select Id from dbo.Utenti WHERE Username = @Username;";
            cmd.Parameters.AddWithValue("@Username", utente.Username);
            SqlDataReader lettore = cmd.ExecuteReader();
            int idUtente = 0;
            while (lettore.Read())
            {
                var id = (int)lettore[0];
                idUtente = id;
            }
            connection.Close();
            return idUtente;
        }

        /* METODO PER RECUPERARE ID-CATEGORIA*/
        private int FetchIdCategoria(Eroe eroe)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select Id from dbo.CategorieEroi WHERE Nome = @Nome;";
            cmd.Parameters.AddWithValue("@Nome", eroe.Categoria);
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

        /* METODO PER RECUPERARE ID-ARMA*/
        private int FetchIdArma(Eroe eroe)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection con, out SqlCommand command);
            command.CommandText = "select Id from dbo.ArmiEroi WHERE Nome = @Nome;";
            command.Parameters.AddWithValue("@Nome", eroe.Arma.Nome);
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