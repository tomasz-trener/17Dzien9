using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02AplikacjaZawodnicy.Domain
{
    internal class ZawodnicyResult
    {
        public Zawodnik[] Zawodnicy { get; set; }
        public int MaksymalnaLiczbaElementow { get; set; } 
    }
}
