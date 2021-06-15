using MostriVSEroi.Core;
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
        internal static Utente InserisciUsernamePassword()
        {
            Console.WriteLine("Inserisci Username");
            string username = Console.ReadLine();
            Console.WriteLine("Inserisci Password");
            string password = Console.ReadLine();

            // CONTROLLARE CHE UTENTE SIA VALIDO
            return UtenteViewServices.GetUtente(username, password);

        }
    }
}
