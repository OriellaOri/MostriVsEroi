using MostriVSEroi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.MockRepository
{
    public class MostroMockRepository : IMostroRepository
    {
        public List<Mostro> FetchMostri()
        {
            List<Mostro> mostri = new List<Mostro>();
            Mostro m1 = new Mostro("Ron", "Cultista", 1, new Arma("Imprecazione", 5), 20);
            Mostro m2 = new Mostro("BellaTrix", "Signora del Male", 2, new Arma("Fulmine", 10), 40);
            Mostro m3 = new Mostro("Ermione", "Signora del Male", 3, new Arma("Divinazione", 15), 60);
            Mostro m4 = new Mostro("Malfoy", "Cultista", 4, new Arma("Farneticazione", 7), 80);
            Mostro m5 = new Mostro("Asterix", "Orco", 5, new Arma("Spada Rotta", 3), 100);
            mostri.Add(m1); mostri.Add(m2); mostri.Add(m3); mostri.Add(m4); mostri.Add(m5);
            return mostri;
        }
    }
}
