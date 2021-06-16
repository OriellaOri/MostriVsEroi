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
            /* RICHIESTA USERNAME E PASSWORD */
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
                /* UNA VOLTA REGISTRATO GLI FACCIO CREARE UN EROE PER INZIARE A GIOCARE*/
                Console.WriteLine("--- IL TUO PRIMO EROE ---\n");
                EroeView.CreaEroe(utente);
                Menu.MenuNonAdmin(utente);
            }

        }
    }
}
