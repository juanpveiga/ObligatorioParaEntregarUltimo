using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligTallerObjDominio
{
    public class OrdenamientoXcosto : IComparer<Rodaje>
    {
        public int Compare(Rodaje x, Rodaje y)
        {
         return   x.calcularCosto().CompareTo(y.calcularCosto());
        }
    }
}
