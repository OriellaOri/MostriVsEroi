using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Core
{
    public class Mostro
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Livello { get; set; }
        public Arma Arma { get; set; }
        public int PuntiVita { get; set; }
        public Mostro(string nome, string categoria, int livello, Arma arma, int vita)
        {
            Nome = nome;
            Categoria = categoria;
            Livello = livello;
            Arma = arma;
            PuntiVita = vita;
        }
        public void Attacca(Eroe eroe)
        {
            eroe.PuntiVita = eroe.PuntiVita - Arma.Danno ;
        }
    }
}
