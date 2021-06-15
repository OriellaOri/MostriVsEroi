using MostriVsEroi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.MockRepository
{
    public class CategoriaMockRepository : ICategoriaRepository
    {
        public List<string> FetchCategorie()
        {
            /* LISTA DI CATEGORIE CHE SARANNO POI UNA TABELLA */
            return new List<string> { "Guerriero", "Mago" };
            
        }
    }
}
