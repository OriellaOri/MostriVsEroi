using MostriVsEroi.Core;
using MostriVsEroi.Core.Interfaces;
using MostriVsEroi.DbRepository;
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
        static ICategoriaRepository cmr = new CategoriaDbRepository();
        public static List<string> GetCategorieEroi()
        {
            return cmr.FetchCategorieEroi();
        }
        public static List<string> GetCategorieMostri()
        {
            return cmr.FetchCategorieMostri();
        }
    }
}
