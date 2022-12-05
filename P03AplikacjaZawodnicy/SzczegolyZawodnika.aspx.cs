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
    public partial class SzczegolyZawodnika : System.Web.UI.Page
    {
        public Zawodnik Zaznaczony;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idStr = Request["id"];

            if (!string.IsNullOrEmpty(idStr))
            {
                int id = Convert.ToInt32(idStr);

                ZawodnicyRepository zr = new ZawodnicyRepository();
                Zaznaczony = zr.PodajZawodnika(id);
            }
        }
    }
}