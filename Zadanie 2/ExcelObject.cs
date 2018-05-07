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
    public class ExcelObject
    {
        public static List<string> headers = new List<string>() { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };
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

        private static Tuple<List<string>, List<string>, Dictionary<string, int>> FindDatesInHeaders(
            List<string> line, List<string> datesInHedaers, Dictionary<string, int> headersPositions)
        {
            for (int k = 0; k < line.Count; k++)
            {
                string[] dates = line[k].Split('-');
                if (dates.Length == 2)
                {
                    try
                    {
                        DateTime dtBegin = DateTime.ParseExact(dates[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        DateTime dtEnd = DateTime.ParseExact(dates[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        //int days = (dtEnd - dtBegin).Days + 1;
                        datesInHedaers.Add(line[k]);
                        for (int l = 0; l < datesInHedaers.Count; l++)
                        {
                            headersPositions[datesInHedaers[l]] = line.FindIndex(x => x.StartsWith(datesInHedaers[l]));
                        }

                    }
                    catch (Exception) { }
                }
            }
            return new Tuple<List<string>, List<string>, Dictionary<string, int>>(line, datesInHedaers, headersPositions);
        }

        public static async Task<List<ExcelObject>> CreateObjectsFromExcel(List<string> headers, string file, int sheetNumber)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            xlWorkbook = xlApp.Workbooks.Open(file);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[sheetNumber];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            List<ExcelObject> excelObjects = new List<ExcelObject>();
            Dictionary<string, int> headersPositions = headers.ToDictionary(x => x, x => -1);
            List<string> datesInHedaers = new List<string>();
            List<string> line = new List<string>();
            bool foundHeaders = false;
            for (int i = 1; i <= rowCount; i++)
            {
                line.Clear();
                for (int j = 1; j <= colCount; j++)
                {
                    if ((xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null) || (line.Any() && foundHeaders))
                    {
                        if (xlRange.Cells[i, j].Value2 == null)
                        {
                            Console.WriteLine("puste pole");
                            line.Add("");
                        }
                        else
                        {
                            Console.WriteLine(xlRange.Cells[i, j].Value2.ToString().Trim());
                            line.Add(xlRange.Cells[i, j].Value2.ToString().Trim());
                        }
                        
                    }
                }
                //warunek zakonczenia dalszego przeszukiwania pliku
                if (line.Count == 0 && foundHeaders)
                {
                    break;
                }
                //czy aktualnie przeszukiwana linia to headery
                bool headersLine = !headers.Except(line).Any();
                if (headersLine) 
                {
                    foundHeaders = true;
                    //uzupelniam o indeksy znajome pola
                    for (int k = 0; k < headers.Count; k++)
                    {
                        headersPositions[headers[k]] = line.FindIndex(x => x.StartsWith(headers[k]));
                    }
                    var afterDatesSearches = FindDatesInHeaders(line, datesInHedaers, headersPositions);
                    line = afterDatesSearches.Item1;
                    datesInHedaers = afterDatesSearches.Item2;
                    headersPositions = afterDatesSearches.Item3;
                }
                if (foundHeaders)
                {   //gdy znalezlismy headery, ale jestesmy juz w wartosciach
                    if (!headersLine)
                    {
                        try
                        {
                            ExcelObject excelObject = new ExcelObject();
                            excelObject.Cena = line[headersPositions["Cena"]]; 
                            excelObject.Id = line[headersPositions["ID"]];
                            excelObject.Nazwa = line[headersPositions["Nazwa"]];
                            excelObject.NrZamowienia = line[headersPositions["Nr Zamówienia"]];
                            excelObject.Opis = line[headersPositions["Opis"]];
                            excelObject.Pozycja = line[headersPositions["Pozycja"]];
                            excelObject.Poziom = line[headersPositions["Poziom"]];
                            for (int j = 0; j < datesInHedaers.Count; j++)
                            {
                                try
                                {
                                    //Console.WriteLine(datesInHedaers[j]);
                                    //Console.WriteLine(headersPositions[datesInHedaers[j]]);
                                    string x = line[headersPositions[datesInHedaers[j]]];
                                    //Console.WriteLine(x);
                                    //if (!String.IsNullOrEmpty(x)) //zamienic na algorytm do sprawdzania czy zapisac date
                                    if (x =="x")
                                        excelObject.Daty.Add(datesInHedaers[j]);
                                }
                                catch (Exception) { }
                            }
                            excelObjects.Add(excelObject);
                            Console.WriteLine(excelObject);
                        }
                        catch (Exception) { }   //dane niekompletne w linii, nic nie rob
                    }
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return excelObjects;
        }

        public override string ToString()
        {
            List<string> list = new List<string> { Nazwa, Id, Cena, Pozycja, Poziom, Opis, NrZamowienia };
            list.AddRange(Daty);
            return String.Join(" ", list.ToArray());
        }
    }
}
