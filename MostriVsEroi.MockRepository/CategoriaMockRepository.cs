using MostriVsEroi.Core;
using MostriVsEroi.Core.Interfaces;
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

        public List<string> FetchCategorieEroi()
        {
            throw new NotImplementedException();
        }

        public List<string> FetchCategorieMostri()
        {
            throw new NotImplementedException();
        }
    }
}
