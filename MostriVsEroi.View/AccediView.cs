using MostriVsEroi.Core;
using MostriVSEroi.Core;
using MostriVSEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.View
{
    static class AccediView
    {
        public static void Accedi()
        {
            try
            {
                Utente utente = RichiestaDati.InserisciUsernamePassword();
                // mi ritorno l'utente con le sue proprietà corrette
                utente = UtenteServices.VerifyAuthentication(utente);

                if (utente.IsAuthenticated && utente.IsAdmin)
                {
                    Menu.MenuAdmin(utente);
                }
                else if (utente.IsAuthenticated && !utente.IsAdmin)
                {
                    Menu.MenuNonAdmin(utente);
                }
            }
            catch (UtenteException)
            {
                Console.WriteLine("\n\n!! Devi Prima Registrati !!\n\n");
                //TODO chiedere se si vuole registare 
                Menu.MainMenu();
            }          
        }
    }
}
