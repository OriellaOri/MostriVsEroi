using MostriVSEroi.Core;
using MostriVSEroi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.View
{
    class GiocaView
    {
        internal static void Gioca(Utente utente)
        {
            /* SCELTA EROE */
            Eroe eroe = SceltaEroe(utente);

            /* SCELTA MOSTRO */
            Mostro mostro = MostroServices.SceltaMostro(eroe);

            /* PARTITA */
            bool isWin = Partita(utente, eroe, mostro);

            /* SE HA VINTO CALCOLO PUNTEGGIO + CALCOLO LIVELLO */
            if (isWin)
            {
                //TODO 
                /* AGGIUNTA ESPEREINZA = LIV MOSTRO * 10 */
                // EroeServices.CalcoloEsperienza(eroe);

                // controllo se passaggio livello
                // EroeServices.CalcolaLivello(eroe);
            }

            /* RICHIESTA SE GIOCARE ANCORA */
            GiocareAncora(utente, eroe, mostro);
        }

        private static void GiocareAncora(Utente utente, Eroe eroe, Mostro mostro)
        {
            Console.WriteLine("Vuoi giocare ancora ? Premere S o N ");
            string giocareAncora = Console.ReadLine();

            /* CAMBIO EROE */
            if (giocareAncora.ToUpper() == "S")
            {
                Console.WriteLine("Vuoi cambiare EROE? S / N ");
                string cambioEroe = Console.ReadLine();
                if (cambioEroe.ToUpper() == "S")
                {
                    Gioca(utente);
                }
                else
                {
                    /* RINNOVO IL MOSTRO */
                    mostro = MostroServices.SceltaMostro(eroe);
                    Partita(utente, eroe, mostro);
                    GiocareAncora(utente, eroe, mostro);
                }
            }
            else
            {
                // TODO : TORNA AL MENU ADMIN O NONADMIN
                Menu.MenuNonAdmin(utente);
            }
        }

        private static bool Partita(Utente utente, Eroe eroe, Mostro mostro)
        {
            Console.WriteLine($"\n!! Ti sta attaccando {mostro.Nome} di LIV. {mostro.Livello} !!\n");
            int scelta;
            do
            {
                Console.WriteLine("1 x ATTACCARE \n2 x FUGGIRE ");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 2);

            /* ATTACCARE */
            if (scelta == 1)
            {
                do
                {
                    eroe.Attacca(mostro);
                    mostro.Attacca(eroe);

                } while (eroe.PuntiVita > 0 && mostro.PuntiVita > 0);

                /* EROE PERDE */
                if (eroe.PuntiVita <= 0)
                {
                    Console.WriteLine("Hai Perso!");
                    return false;

                }
                /* EROE VINCE */
                if (mostro.PuntiVita <= 0)
                {
                    Console.WriteLine("Hai Vinto!! ");
                    return true;
                }
            }
            /* FUGGIRE */
            else if (scelta == 2)
            {
                //TODO FUGGIRE
                /* SOTTRAZIONE ESPEREINZA = LIV MOSTRO * 5 */
                return false;
            }
            return true; ;
        }

        private static Eroe SceltaEroe(Utente utente)
        {
            // carico la lista degli eroi dell'utente 
            List<Eroe> eroi = EroeServices.GetEroi(utente);
            bool conversione = false;
            int eroeScelto;
            do
            {
                // contatore della lista
                int count = 1;
                foreach (Eroe eroe in eroi)
                {
                    //Console.WriteLine(e);
                    Console.WriteLine($"Premi {count++} per scelgliere l'eroe {eroe.Nome}, di tipo {eroe.Categoria} " +
                        $"con arma {eroe.Arma.Nome} che ha {eroe.Arma.Danno} punti danno di Liv. {eroe.Livello}");
                }
                conversione = int.TryParse(Console.ReadLine(), out eroeScelto);
            } while (!conversione || eroeScelto < 1 || eroeScelto > eroi.Count);

            return eroi[--eroeScelto];
            //Console.WriteLine("Inserisci nome del Eroe con cui vuoi giocare");
            //string nomeEroe = Console.ReadLine();
            //Eroe eroeScelto = EroeServices.RecuperaEroe(nomeEroe,utente);
            //if(eroeScelto == null)
            //{
            //    Console.WriteLine("Scelta non valida");
            //}
        }
    }
}
