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
            Mostro mostro = MostroServices.SceltaMostro();

            /* PARTITA */

            /* CALCOLO PUNTEGGIO + CALCOLO LIVELLO */

            /* RICHIESTA SE GIOCARE ANCORA */

        }

        private static Eroe SceltaEroe(Utente utente)
        {
            // carico la lista degli eroi dell'utente 
            List<Eroe> eroi = EroeServices.GetEroi(utente);
            // contatore della lista
            int count = 1;
            bool conversione = false;
            int eroeScelto;
            do
            {
                foreach (Eroe e in eroi)
                {
                    //Console.WriteLine(e);
                    Console.WriteLine($"Premi{count} per scelgliere 'eore {e.Nome}, di tipo {e.Categoria} " +
                        $"con arma {e.Arma.Nome} che ha {e.Arma.Danno} punti danno di Liv. {e.Livello}");
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
