using MostriVsEroi.DbRepository;
using MostriVsEroi.Services;
using MostriVSEroi.Core;
using MostriVSEroi.MockRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Services
{
    public static class EroeServices
    {
        // LIVELLI - PUNTI ESPERIENZa >> opprotuno mettere nel DB 
        static readonly Dictionary<int, int> livelliEsperienza = new() { { 1, 0 }, { 2, 30 }, { 3, 60 }, { 4, 90 }, { 5, 120 } };

        /* DICTIONARY --- KEY: LIVELLI || VALUE : PUNTI VITA >> RECUPERATI DAL DB */
        static readonly Dictionary<int, int> livelliPuntiVita = LivelloServices.GetLivelliVita();

        static readonly IEroeRepository emr = new EroeDbRepository();

        public static List<Eroe> GetEroi(Utente utente)
        {
            return emr.FetchEroi(utente);
        }
        public static Dictionary<Eroe, Utente> GetEroiClassifca()
        {
            return emr.FetchEroiUtenti();
        }
        public static void AddEroe(Eroe newEroe, Utente utente)
        {
            emr.AddNewEroe(newEroe, utente);
        }

        public static void RemoveEroe(Utente utente, Eroe eroe)
        {
            emr.DeleteEroe(utente, eroe);
        }

        public static int CalcoloEsperienza(Mostro mostro)
        {
            /* CALCOLO QUANTO ESPEREINZA OTTENGO DALLA BATTAGLIA*/
            return mostro.Livello * 10;
        }

        [Obsolete("Optato per PuntiProssimoLivello")]
        public static bool IsLevelUp(Eroe eroe)
        {
            if (eroe.Livello == livelliEsperienza.Keys.Last())
            {
                Console.WriteLine("Livllo Massimo Raggiunto");
                return false;
            }
            else
            {
                // tramite il livello dell'eroe aggiungo +1, che è il livello successivo a cui può ambire,
                // tramite questo recupero i punti espereinza che servono per aumentare di livello 
                // se punti esperienza del eroe sono maggiori o uguali a i punti che servono per passare 
                // allora il livello può aumentare 
                if (eroe.PuntiEsperienza >= livelliEsperienza[eroe.Livello + 1])
                {
                    return true;
                }
            }
            return false;
        }

        public static int PuntiProssimoLivello(Eroe eroe)
        {
            /*SE EROE LIVELLO MASSIMO RITORNO -1 PER GESTIONE SUCCESSIVA CON AVVISO */
            if (eroe.Livello == livelliEsperienza.Keys.Last())
            {
                return -1;
            }
            else
            {
                int puntiMancanti = livelliEsperienza[eroe.Livello + 1] - eroe.PuntiEsperienza;
                // Se il risultato è minordi zero ritorno comunque 0
                if (puntiMancanti < 0)
                {
                    return 0;
                }
                return puntiMancanti;
            }
        }

        public static void UpdateEsperienzaLivelloEroe(Utente utente, Eroe eroe)
        {
            // aggiorno livello - vita - esperienza che si deve azzerare
            /* LIVELLO AUMENTA DI UNO */
            eroe.Livello++;
            /* SE NON ERA ANCORA ADMIN VEDO SE PUò DIVENTARLO */
            if (!utente.IsAdmin)
            {
                if (eroe.Livello >= 3)
                {
                    UtenteServices.UpdateAdmin(utente);
                }
            }
            /* LA VITA CAMBIA */
            eroe.PuntiVita = livelliPuntiVita[eroe.Livello + 1];
            /* ESPEREINZA SI AZZERA*/
            eroe.PuntiEsperienza = 0;

            /* AGGIORNO IL DB*/
            emr.UpdateEsperienzaLivelloEroe(utente, eroe);
        }

        public static void UpdateEsperienzaEroe(Utente utente, Eroe eroe)
        {
            emr.UpdateEsperienzaEroe(utente, eroe);
        }

        public static int CalcoloEsperienzaFuga(Mostro mostro)
        {
            return mostro.Livello * 5;
        }
    }
}
