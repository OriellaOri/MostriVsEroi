using MostriVsEroi.Core;
using MostriVsEroi.MockRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Services
{
    static public class CategoriaServices
    {
        static ICategoriaRepository cmr = new CategoriaMockRepository();
        public static List<string> GetCategorie()
        {
            return cmr.FetchCategorie();
        }
    }
}
