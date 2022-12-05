using P02AplikacjaZawodnicy.Domain;
using P02AplikacjaZawodnicy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P01ApliakcjeWeboweWstep
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "hej";

            ZawodnicyRepository zr = new ZawodnicyRepository();
            //ZawodnicyResult zawodnicy= zr.PodajZawodnikow(null, null, null);
            ZawodnicyResult zawodnicy = zr.PodajZawodnikow();
            foreach (var z in zawodnicy.Zawodnicy)
            {
                lbDane.Items.Add(z.ImieNazwisko);
            }
        }
    }
}