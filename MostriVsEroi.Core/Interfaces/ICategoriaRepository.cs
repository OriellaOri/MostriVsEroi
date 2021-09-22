using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        // carica tutte le categorie presenti nel DB
        public List<string> FetchCategorie();
        public List<string> FetchCategorieEroi();
        public List<string> FetchCategorieMostri();
    }
}
