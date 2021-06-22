using MostriVsEroi.Core;
using MostriVSEroi.Core;
using MostriVSEroi.Services;
using MostriVSEroi.ViewServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.View
{
    class RichiestaDati
    {
        // CARICO LA LISTA DEGLI UTENTI NEL DB 
        static readonly List<Utente> utenti = UtenteServices.GetUtenti();

        internal static Utente InserisciUsernamePassword()
        {
            string username;
            do
            {
                Console.WriteLine("Inserisci Username");
                username = Console.ReadLine();

            } while (String.IsNullOrEmpty(username));

            string password;
            do
            {
                Console.WriteLine("Inserisci Password");
                password = Console.ReadLine();

            } while (String.IsNullOrEmpty(password));

            /* SE IL NOME ESISTE MA LA PASS SBAGLIATA ERRORE PER AVVISARE DELLO SBAGLIO */
            // e RICOMINCIA IL METODO
            foreach (Utente u in utenti)
            {             
                if(u.Username == username && u.Password != password)
                {
                    Console.WriteLine("Nickname o password errati");
                    InserisciUsernamePassword();
                }
                else if (u.Username != username && u.Password != password)
                {
                    throw new UtenteException();
                }
                else if (u.Username == username && u.Password == password)
                {
                    return UtenteViewServices.GetUtente(username, password);
                }
            }
            /* se nulla di tutto cià succede ritoro nullo */
            // TODO gestire recezione del null ma non succede
            return null;
        }

        internal static Utente InserisciNewUsernamePassword()
        {
            string username;
            do
            {
                Console.WriteLine("Inserisci Username");
                username = Console.ReadLine();

                /* CONTROLLARE CHE USERNAME NON SIA GIA PRESENTE */
                foreach (Utente u in utenti)
                {
                    if (u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase))
                    {
                        /* SE PRESENTE SCATENO ECCEZIONE BLOCCO INSERIMENTO */
                        // TODO gestire diversamente il controllo 
                        // non scatuire un eccezione 
                        throw new UtenteException();
                    }
                }

            } while (String.IsNullOrEmpty(username));

            string password;
            do
            {
                Console.WriteLine("Inserisci Password");
                password = Console.ReadLine();

            } while (String.IsNullOrEmpty(password));

            // CONTROLLARE CHE UTENTE SIA VALIDO
            return UtenteViewServices.GetUtente(username, password);
        }
    }
}
