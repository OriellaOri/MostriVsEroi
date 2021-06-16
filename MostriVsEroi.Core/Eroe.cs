using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVSEroi.Core
{
    public class Eroe
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public Arma Arma { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int PuntiEsperienza { get; set; }
        public Eroe(string nome, string categoria, Arma arma)
        {
            Nome = nome;
            Categoria = categoria;
            Arma = arma;
            Livello = 1;
            PuntiVita = 20;
            PuntiEsperienza = 0;
        }
        public Eroe(string nome, string categoria, Arma arma, int livello, int vita, int esp)
        {
            Nome = nome;
            Categoria = categoria;
            Arma = arma;
            Livello = 1;
            PuntiVita = 20;
            PuntiEsperienza = 0;
            Livello = livello;
            PuntiVita = vita;
            PuntiEsperienza = esp;

        }

        public void Attacca(Mostro mostro)
        {
            mostro.PuntiVita -= Arma.Danno ;
        }
    }
}
