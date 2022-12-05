using P02AplikacjaZawodnicy.Domain;
using P02AplikacjaZawodnicy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P03AplikacjaZawodnicy
{
    public partial class Default : System.Web.UI.Page
    {
        public Zawodnik[] Dane;
        protected void Page_Load(object sender, EventArgs e)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            ZawodnicyResult dane= zr.PodajZawodnikow();
            Dane = dane.Zawodnicy;
        }
    }
}