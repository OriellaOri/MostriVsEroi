using MostriVsEroi.Core;
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
            try
            {
                /* RICHIESTA USERNAME E PASSWORD */
                Utente utente = RichiestaDati.InserisciNewUsernamePassword();

                /* INSERIMENTO DB */
                UtenteServices.AddUtente(utente);

                /* CONFERMA INSERIMENTO */
                Console.WriteLine($"Utente {utente.Username} aggiunto correttamente!\n");

                /* UNA VOLTA REGISTRATO CREA UN EROE PER INZIARE A GIOCARE */
                Console.WriteLine("--- IL TUO PRIMO EROE ---\n");
                EroeView.CreaEroe(utente);

                /* GLI MOSTRO IL MENU PER COMINCIARE A GIOCARE */
                Menu.MenuNonAdmin(utente);
            }
            catch (UtenteException)
            {
                /* GESTISCO ECCEZIONE */
                Console.WriteLine("\n\n!! Username già presente !!\n\n");
                Registra();
            }

        }
    }
}
