using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Arma
    {
        public string Nome { get; set; }
        public int Danno { get; set; }
        public Arma(string nome, int danno)
        {
            Nome = nome;
            Danno = danno;
        }
    }
}
