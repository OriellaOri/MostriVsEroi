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
            bool isWin = Partita(eroe, mostro);

            /* SE HA VINTO CALCOLO PUNTEGGIO + CALCOLO LIVELLO */
            if (isWin)
            {
                CalcolaPunteggioLivello(utente, eroe, mostro);
            }
            /* RICHIESTA SE GIOCARE ANCORA */
            GiocareAncora(utente, eroe, mostro);
        }

        private static void CalcolaPunteggioLivello(Utente utente, Eroe eroe, Mostro mostro)
        {
            /* CALCOLO L'ESPERIENZA CHE AGGIUNGO AL EROE */
            int espereinzaBattaglia = EroeServices.CalcoloEsperienza(mostro);
            Console.WriteLine($"Con queta vittoria guadagni {espereinzaBattaglia} punti espereinza");

            /* AGGIORNO LA NUOVA ESPEREINZA */
            eroe.AggiornaEsperienza(espereinzaBattaglia);
            /* GLI DICO I PUNTI ESPEREINZA RAGGIUNTI */
            Console.WriteLine($"La tua esperienza ora è  di {eroe.PuntiEsperienza} punti");

            /* CONTROLLO SE PASSATO DI LIVELLO*/
            // controllo i punti che mancano
            // >> NB. il metodo subito sotto in caso di numero negativo restiuisce 0 <<
            int puntiMancanti = EroeServices.PuntiProssimoLivello(eroe);

            if (puntiMancanti == -1)
            {
                Console.WriteLine("\n!!! Livllo Massimo Raggiunto !!! ");
            }
            // se ne mancano 0 >> aggiorno livello - vita - esperienza (diventa 0) - admin se LIV 3
            else if (puntiMancanti == 0)
            {
                EroeServices.UpdateEsperienzaLivelloEroe(utente, eroe);
                Console.WriteLine($"\n{eroe.Nome} passa a livello {eroe.Livello} !! Nuovi punti vita: {eroe.PuntiVita} - Punti Esperienza: {eroe.PuntiEsperienza}\n");
            }
            else // diversamente aggiorno solo  
            {
                EroeServices.UpdateEsperienzaEroe(utente, eroe);
                Console.WriteLine($"Ti mancano {puntiMancanti} punti per il {eroe.Livello + 1} livello");
            }
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
                else /* NON VUOLE CAMBIARE EROE*/
                {
                    /* RINNOVO IL MOSTRO */
                    mostro = MostroServices.SceltaMostro(eroe);
                    bool isWin = Partita(eroe, mostro);
                    if (isWin)
                    {
                        CalcolaPunteggioLivello(utente, eroe, mostro);
                    }
                    GiocareAncora(utente, eroe, mostro);
                }
            }
            else
            {
                if (utente.IsAdmin)
                {
                    Menu.MenuAdmin(utente);
                }
                Menu.MenuNonAdmin(utente);
            }
        }

        private static bool Partita(Eroe eroe, Mostro mostro)
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
                    if (mostro.PuntiVita > 0)
                    {
                        mostro.Attacca(eroe);
                    }

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

        }
    }
}
