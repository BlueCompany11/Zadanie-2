using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2
{
    public class ExcelObject
    {
        string nazwa;
        string id;
        string cena;
        string pozycja;
        string poziom;
        string opis;
        string nrZamowienia;
        List<string> dates;
        public ExcelObject()
        {
            Daty = new List<string>();
        }
        public string Nazwa
        {
            get; set;
        }
        public string Id
        {
            get; set;
        }
        public string Cena
        {
            get; set;
        }
        public string Pozycja
        {
            get; set;
        }
        public string Poziom
        {
            get; set;
        }
        public string Opis
        {
            get; set;
        }
        public string NrZamowienia
        {
            get; set;
        }
        public List<string> Daty
        {
            get; set;
        }
        public override string ToString()
        {
            List<string> list = new List<string> { Nazwa, Id, Cena, Pozycja, Poziom, Opis, NrZamowienia };
            list.AddRange(Daty);
            return String.Join(" ", list.ToArray());
        }
    }
}
