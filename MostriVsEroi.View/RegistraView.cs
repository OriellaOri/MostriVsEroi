using MostriVSEroi.Core;
using MostriVSEroi.Services;
using MostriVSEroi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.View
{
    public class RegistraView
    {
        public static void Registra()
        {
            Utente utente = RichiestaDati.InserisciUsernamePassword();
            UtenteServices.AddUtente(utente);
            Console.WriteLine($"Utente {utente.Username} aggiunto correttamente!\n");
            utente = UtenteServices.VerifyAuthentication(utente);
            if (utente.IsAuthenticated && utente.IsAdmin)
            {
                //TODO :MenuAdmin
            }
            else if (utente.IsAuthenticated && !utente.IsAdmin)
            {
                Menu.MenuNonAdmin(utente);
            }

        }
    }
}
