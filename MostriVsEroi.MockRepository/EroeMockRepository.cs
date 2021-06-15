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
        public List<Eroe> FetchEroi(Utente utente)
        {
            List<Eroe> eroi = new List<Eroe>();
            // EROE APPENA CREATO BASE
            Eroe e = new Eroe("Elfo", "Guerriero", new Arma("Alabarda", 15));
            // EROE CON ESPERIENZA 
            Eroe e1 = new Eroe("Maga Magò", "Maga", new Arma("Bastone Magico", 10), 5, 100, 20);
            eroi.Add(e);
            eroi.Add(e1);
            return eroi;
        }
    }
}
