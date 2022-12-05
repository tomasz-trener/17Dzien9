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

            if (!string.IsNullOrEmpty(idStr) && !Page.IsPostBack)
            {
                int id = Convert.ToInt32(idStr);

                ZawodnicyRepository zr = new ZawodnicyRepository();
                Zaznaczony = zr.PodajZawodnika(id);

                txtIdZawodnika.Text = Convert.ToString(Zaznaczony.Id_zawodnika);
                txtImie.Text = Zaznaczony.Imie;
                txtNazwisko.Text = Zaznaczony.Nazwisko;
                txtKraj.Text = Zaznaczony.Kraj;
                txtWaga.Text = Convert.ToString(Zaznaczony.Waga);
                txtWzrost.Text = Convert.ToString(Zaznaczony.Wzrost);
                //txtDataUr.Text = Zaznaczony.DataSformatowana;
                txtIdTrenera.Text = Convert.ToString(Zaznaczony.Id_trenera);
            }
        }

        protected void btnZapisz_Click(object sender, EventArgs e)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();

            Zawodnik zawodnik = new Zawodnik();
            zawodnik.Imie = txtImie.Text;
            zawodnik.Nazwisko = txtNazwisko.Text;
            zawodnik.Kraj = txtKraj.Text;

            string dataS = Request["txtDataUr"];
            zawodnik.DataUrodzenia = Convert.ToDateTime(dataS);

           /* zawodnik.DataUrodzenia = Convert.ToDateTime(txtDataUr.Text);*/
            zawodnik.Waga = Convert.ToInt32(txtWaga.Text);
            zawodnik.Wzrost = Convert.ToInt32(txtWzrost.Text);

            
            //  zawodnik.Id_trenera = Zaznaczony.Id_trenera;
            //  zawodnik.Id_zawodnika = Zaznaczony.Id_zawodnika;

            if (string.IsNullOrEmpty(txtIdZawodnika.Text))
                zr.DodajNowego(zawodnik);
            else
            {
                zawodnik.Id_zawodnika = Convert.ToInt32(txtIdZawodnika.Text);
                if(!string.IsNullOrEmpty(txtIdTrenera.Text))
                    zawodnik.Id_trenera = Convert.ToInt32(txtIdTrenera.Text);
                zr.Edytuj(zawodnik);
            }

            Response.Redirect("Default.aspx");

        }

        protected void btnUsun_Click(object sender, EventArgs e)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            int id = Convert.ToInt32(txtIdZawodnika.Text);
            zr.Usun(id);
            Response.Redirect("Default.aspx");
        }
    }
}