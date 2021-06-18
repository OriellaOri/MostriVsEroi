using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class UtenteDbRepository : IUtenteRepository
    {
        public void AddUser(Utente utente)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection cnt, out SqlCommand comand);
            comand.CommandText = "insert into dbo.Utenti values (@Username, @Password,@IsAdmin)";
            comand.Parameters.AddWithValue("@Username", utente.Username);
            comand.Parameters.AddWithValue("@Password", utente.Password);
            comand.Parameters.AddWithValue("@IsAdmin", utente.IsAdmin);
            comand.ExecuteNonQuery();
            cnt.Close();
        }

        /* DATO UN UTENTE CONTROLLO SE è PRESENTE NEL DB*/
        // SE è PRESENTE LO AUTENTICO COME VERO 
        // ALTRIMENTI RITORNO UTENTE CON PROPEIRTA' NON AUTENTICATA FALSO 
        public Utente GetUser(Utente utente)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "SELECT IsAdmin from dbo.Utenti WHERE Username = @Username AND Password = @Password;";
            cmd.Parameters.AddWithValue("@Username", utente.Username);
            cmd.Parameters.AddWithValue("@Password", utente.Password);
            SqlDataReader reader = cmd.ExecuteReader();

            /* SE NON C SONO RIGHE AUTENTICAZIONE FALLITA */
            if (!reader.HasRows)
            {
                utente.IsAuthenticated = false;
                connection.Close();
                return null;
            }

            /* SE CI SONO LE LEGGO E VALORIZZO I DATI CHE MI SERVONO */
            while (reader.Read())
            {
                var isAdmin = (bool)reader[0];
                if (isAdmin)
                {
                    utente.IsAdmin = true;
                }
                utente.IsAuthenticated = true;
            }
            connection.Close();
            return utente;
        }

        public List<Utente> GetUtenti()
        {
            List<Utente> utenti = new List<Utente>();
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "SELECT Username, Password from dbo.Utenti;";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var username = (string)reader[0];
                var pass = (string)reader[1]; ;
                Utente u = new Utente(username, pass);
                utenti.Add(u);
            }
            connection.Close();
            return utenti;
        }

        public void UpdateAdmin(Utente utente)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "UPDATE dbo.Utenti SET IsAdmin = @IsAdmin WHERE Username = @Username ;";
            cmd.Parameters.AddWithValue("@IsAdmin", 1);
            cmd.Parameters.AddWithValue("@Username", utente.Username);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
