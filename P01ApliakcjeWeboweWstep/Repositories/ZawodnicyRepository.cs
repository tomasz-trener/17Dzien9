using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;
using P01ApliakcjeWeboweWstep.Repositories;
using P02AplikacjaZawodnicy.Domain;

namespace P02AplikacjaZawodnicy.Repositories
{
    internal class ZawodnicyRepository
    {
        public ZawodnicyResult PodajZawodnikow(string filtr, int nrStrony, int wieloscStrony)
        {
            ZawodnicyResult zr = new ZawodnicyResult();

            ModelBazyDataContext db = new ModelBazyDataContext();
            filtr = filtr.ToLower();
            ZawodnikDB[] zawodnicy;
            
            if (string.IsNullOrEmpty(filtr))
                zawodnicy = db.ZawodnikDB.ToArray();
            else
                zawodnicy = db.ZawodnikDB.ToArray().Where(x =>
                    x.imie.ToLower().Contains(filtr) ||
                    x.nazwisko.ToLower().Contains(filtr) ||
                    x.kraj.ToLower().Contains(filtr) ||
                   (x.data_ur != null && x.data_ur.Value.ToString("ddMMyyyy").Contains(filtr)) ||
                    x.waga.ToString().Contains(filtr) ||
                    x.wzrost.ToString().Contains(filtr)
                    ).ToArray();
            // w momencie musimy tę wartośc policzyc 

            int liczbaElementwow = zawodnicy.Length;
            zr.MaksymalnaLiczbaElementow = liczbaElementwow;

            zawodnicy= zawodnicy.Skip(wieloscStrony * (nrStrony - 1)).Take(wieloscStrony).ToArray();

            Zawodnik[] wynik = new Zawodnik[zawodnicy.Length];
            for (int i = 0; i < zawodnicy.Length; i++)
            {
                wynik[i] = new Zawodnik()
                {
                    Id_zawodnika = zawodnicy[i].id_zawodnika,
                    Id_trenera = zawodnicy[i].id_trenera,
                    Imie = zawodnicy[i].imie,
                    Nazwisko = zawodnicy[i].nazwisko,
                    Kraj = zawodnicy[i].kraj,
                    Wzrost = zawodnicy[i].wzrost,
                    Waga = zawodnicy[i].waga,
                    DataUrodzenia = zawodnicy[i].data_ur
                };
            }
            zr.Zawodnicy = wynik;
            return zr;
        }

        public void Edytuj(Zawodnik z)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();
            ZawodnikDB zdb = db.ZawodnikDB.FirstOrDefault(x=>x.id_zawodnika==z.Id_zawodnika);

            zdb.id_trenera = z.Id_trenera;
            zdb.imie = z.Imie;
            zdb.nazwisko = z.Nazwisko;
            zdb.kraj = z.Kraj;
            zdb.data_ur = z.DataUrodzenia;
            zdb.wzrost = z.Wzrost;
            zdb.waga = z.Waga;

            db.SubmitChanges();
        }

        public void Usun(int id)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();
            ZawodnikDB zdb = db.ZawodnikDB.FirstOrDefault(x => x.id_zawodnika == id);
            db.ZawodnikDB.DeleteOnSubmit(zdb);
            db.SubmitChanges();
        }

        public void DodajNowego(Zawodnik zawodnik)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();

            ZawodnikDB zdb = new ZawodnikDB()
            {
                id_trenera = zawodnik.Id_trenera,
                id_zawodnika = zawodnik.Id_zawodnika,
                imie = zawodnik.Imie,
                nazwisko = zawodnik.Nazwisko,
                kraj = zawodnik.Kraj,
                waga = zawodnik.Waga,
                data_ur = zawodnik.DataUrodzenia,
                wzrost = zawodnik.Wzrost
            };
            db.ZawodnikDB.InsertOnSubmit(zdb);
            db.SubmitChanges();
        }

         
    }
}
