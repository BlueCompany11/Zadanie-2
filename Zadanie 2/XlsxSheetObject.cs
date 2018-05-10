using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Zadanie_2
{
    public class XlsxSheetObject
    {
        //string nazwa;
        //string id;
        //string cena;
        //string pozycja;
        //string poziom;
        //string opis;
        //string nrZamowienia;
        //List<string> dates;
        public XlsxSheetObject()
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
        public double TaskCount()
        {
            double ret = 0;
            int days = 0;
            for (int i = 0; i < Daty.Count; i++)
            {
                string[] dates = Daty[i].Split('-');
                DateTime dtBegin = DateTime.ParseExact(dates[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime dtEnd = DateTime.ParseExact(dates[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                days += (dtEnd - dtBegin).Days + 1;
            }
            ret = Int32.Parse(Cena) / days;
            return ret;
        }

        public override string ToString()
        {
            List<string> list = new List<string> { Nazwa, Id, Cena, Pozycja, Poziom, Opis, NrZamowienia };
            list.AddRange(Daty);
            return String.Join(" ", list.ToArray());
        }

    } 
}
