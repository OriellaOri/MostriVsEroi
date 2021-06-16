using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.MockRepository
{
    public class EroeMockRepository : IEroeRepository
    {
        // fake lista eroi di qualsiasi utente logga 
        static List<Eroe> eroi = new List<Eroe>()
        {
            new Eroe("Elfo", "Guerriero", new Arma("Alabarda", 15)),
            new Eroe("Maga Magò", "Maga", new Arma("Bastone Magico", 10), 5, 100, 20)
        };

        public void AddNewEroe(Eroe newEroe, Utente utente)
        {
            // recupero i suoi eroi dal DB
            //List<Eroe> eroiUtente = FetchEroi(utente);
            // aggiungo alla lista l'eroe creato
            eroi.Add(newEroe);
        }

        public List<Eroe> FetchEroi(Utente utente)
        {
            return eroi;
        }

        public void DeleteEroe(Utente utente, Eroe eroe)
        {
            eroi.Remove(eroe);
        }
    }
}
