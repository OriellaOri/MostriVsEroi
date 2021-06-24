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
            /* RICHIESTA DI GIOCARE */
            bool isPlay;

            /* EROE DA RIEMPIRE SE LA PIRMA VOLTA CHE SI GIOCA*/
            Eroe eroe = null;

            /* ENTRO QUI DENTRO FINCHè VUOLE GIOCARE */
            do
            {
                /* SCELTA EROE */
                if (eroe == null)
                {
                    eroe = SceltaEroe(utente);
                }
                else
                {
                    /*CAMBIO EROE*/
                    Console.WriteLine("Vuoi cambiare EROE? S / N ");
                    string cambioEroe = Console.ReadLine();
                    if (cambioEroe.ToUpper() == "S")
                    {
                        eroe = SceltaEroe(utente);
                    }
                    else
                    /* RICARICO LA VITA */
                    {
                            eroe.PuntiVita = EroeServices.RicaricaVita(eroe);
                        if (eroe.PuntiVita == 0)
                            throw new ArgumentNullException(); 
                    }
                }                

                /* SCELTA MOSTRO */
                Mostro mostro = MostroServices.SceltaMostro(eroe);

                /* AVVISO MOSTRO  */
                Console.WriteLine($"\n!! Ti sta attaccando {mostro.Nome} di LIV. {mostro.Livello} !!\n");

                int scelta;
                /*RICHIESTA DI COSA FARE */
                do
                {
                    Console.WriteLine("1 x COMBATTERE \n2 x FUGGIRE ");

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 2);

                /* ATTACCARE */
                if (scelta == 1)
                {
                    /* PARTITA */
                    bool isWin = Combattimento(eroe, mostro);
                    /* SE HA VINTO CALCOLO PUNTEGGIO + CALCOLO LIVELLO */
                    if (isWin)
                    {
                        CalcolaPunteggioLivello(utente, eroe, mostro);
                    }
                }
                /* FUGA */
                else
                {
                    GiocoFuga(utente, eroe, mostro);
                }

                /* CHIEDO SE VUOLE GIOCA ANCORA*/
                isPlay = RichiestaGioco();

            } while (isPlay);
        }

        private static bool RichiestaGioco()
        {
            // chiediamo se vuole giocare 
            Console.WriteLine("Vuoi giocare ancora ? Premere S o N ");
            string giocareAncora = Console.ReadLine();
            if (giocareAncora.ToUpper() != "S")
            {
                return false;
            }
            return true;
        }

        private static void CalcolaPunteggioLivello(Utente utente, Eroe eroe, Mostro mostro)
        {
            /* CALCOLO L'ESPERIENZA CHE AGGIUNGO AL EROE */
            int espereinzaBattaglia = EroeServices.CalcoloEsperienza(mostro);
            Console.WriteLine($"Con queta vittoria guadagni {espereinzaBattaglia} punti espereinza");

            /* AGGIORNO LA NUOVA ESPEREINZA */
            eroe.AggiornaEsperienza(espereinzaBattaglia);
            /* GLI DICO I PUNTI ESPEREINZA RAGGIUNTI */
            Console.WriteLine($"La tua esperienza ora è di {eroe.PuntiEsperienza} punti");

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

        private static void CalcolaPerditaEspereinza(Utente utente, Eroe eroe, Mostro mostro)
        {
            /* CALCOLO ESPERIENZA DA TOGLIERE*/
            int espereinzaFuga = EroeServices.CalcoloEsperienzaFuga(mostro);
            Console.WriteLine($"Con questa fuga perdi {espereinzaFuga} punti espereinza");

            /* AGGIORNO LA NUOVA ESPEREINZA */
            if (eroe.PerditaEsperienza(espereinzaFuga) == 0)
            {
                Console.WriteLine("La tua esperienza rimane a 0");
            }
            else
            {
                Console.WriteLine($"La tua esperienza ora è di {eroe.PuntiEsperienza} punti");
            }

            /* AGGIORNO DATI NEL DB*/
            EroeServices.UpdateEsperienzaEroe(utente, eroe);
        }

        private static bool IsRun()
        {
            Random r = new();
            return Convert.ToBoolean(r.Next(0, 2));
        }

        private static bool Combattimento(Eroe eroe, Mostro mostro)
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
            Console.WriteLine("Hai Vinto!! ");
            return true;
        }

        private static void GiocoFuga(Utente utente, Eroe eroe, Mostro mostro)
        {
            bool fuga;
            int scelta;
            do
            {
                /* VEDO SE RIESCE A FUGGIRE */
                fuga = IsRun();

                /* SE LA FUGA VA A BUON FINE */
                if (fuga)
                {
                    Console.WriteLine("\n!!! SEI RIUCITO A SCAPPARE !!!\n");
                    /* SOTTRAZIONE ESPEREINZA */
                    CalcolaPerditaEspereinza(utente, eroe, mostro);
                }
                else
                {

                    Console.WriteLine("\n!!! NON SEI RIUCITO A SCAPPARE !!!\n");
                    mostro.Attacca(eroe);
                    Console.WriteLine($"{mostro.Nome} ti attacca! Ti toglie {mostro.Arma.Danno} punti vita. ");

                    if (eroe.PuntiVita > 0)
                    {
                        /* GLI DICO QUANTI PUNTI VITA HA */
                        Console.WriteLine($"Punti vita rimanenti {eroe.PuntiVita}\n");
                        /* CHIEDO SE VUOLE SCAPPARE DI NUOVO O COMBATTERE*/
                        do
                        {
                            Console.WriteLine("1 x COMBATTERE \n2 x FUGGIRE ");

                        } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 2);

                        if (scelta == 1)
                        {
                            /* PARTITA */
                            bool isWin = Combattimento(eroe, mostro);
                            /* SE HA VINTO CALCOLO PUNTEGGIO + CALCOLO LIVELLO */
                            if (isWin)
                            {
                                CalcolaPunteggioLivello(utente, eroe, mostro);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--- !!! IL TUO EROE HA FINITO LA VITA !!! ---");
                        /* avendo finto i punti vita per uscire dal ciclo gli metto la fuga a true*/
                        fuga = true;
                    }
                }
            } while (!fuga);
        }

        private static Eroe SceltaEroe(Utente utente)
        {
            // carico la lista degli eroi dell'utente 
            List<Eroe> eroi = EroeServices.GetEroi(utente);
            int eroeScelto;
            bool conversione;
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
