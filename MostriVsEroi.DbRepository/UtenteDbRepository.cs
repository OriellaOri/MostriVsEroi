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
            comand.CommandText = "insert into dbo.Utenti values (@Username, @Password)";
            comand.Parameters.AddWithValue("@Username", utente.Username);
            comand.Parameters.AddWithValue("@Password", utente.Password);
            comand.ExecuteNonQuery();
            cnt.Close();
        }

        /* DATO UN UTENTE CONTROLLO SE è PRESENTE NEL DB*/
        // SE è PRESENTE LO AUTENTICO COME VERO 
        // ALTRIMENTI RITORNO UTENTE CON PROPEIRTA' NON AUTENTICATA FALSO 
        public Utente GetUser(Utente utente)
        {
            ConnessioneDbRepository.Connessione(out SqlConnection connection, out SqlCommand cmd);

            cmd.CommandText = "SELECT * from dbo.Utenti WHERE Username = @Username AND Password = @Password;";
            cmd.Parameters.AddWithValue("@Username", utente.Username);
            cmd.Parameters.AddWithValue("@Password", utente.Password);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) 
            {
                utente.IsAuthenticated = true;
            }
            else
            {
                utente.IsAuthenticated = false;

            }
            connection.Close();
            return utente;
        }
    }
}
