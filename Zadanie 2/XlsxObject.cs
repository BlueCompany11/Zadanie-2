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
    public class XlsxObject
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkbook;
        Excel._Worksheet xlWorksheet;
        Excel.Range xlRange;
        int rowCount;
        int colCount;
        List<string> headers;
        List<string> acceptableValuesDateField;

        public XlsxObject(string filePath)
        {
            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(filePath);
            headers = new List<string>();
            acceptableValuesDateField = new List<string>();
        }

        ~XlsxObject()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (xlRange != null)
            {
                Marshal.ReleaseComObject(xlRange);
            }
            if (xlWorksheet != null)
            {
                Marshal.ReleaseComObject(xlWorksheet);
            }

            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        public List<Tuple<int, string>> GetSheetNumbers()
        {
            List<Tuple<int, string>> sheetNumbers = new List<Tuple<int, string>> { };
            for (int i = 1; i <= xlWorkbook.Sheets.Count; i++)
            {
                sheetNumbers.Add(new Tuple<int, string>(i, xlWorkbook.Sheets.Item[i].Name));
            }
            return sheetNumbers;
        }

        public void OpenSheet(int sheetNumber, List<string> usersHedaers, List<string> dateCorrectFields)
        {
            headers.Clear();
            acceptableValuesDateField.Clear();
            xlWorksheet = xlWorkbook.Sheets[sheetNumber];
            xlRange = xlWorksheet.UsedRange;
            rowCount = xlRange.Rows.Count;
            colCount = xlRange.Columns.Count;
            headers.AddRange(usersHedaers);
            acceptableValuesDateField.AddRange(dateCorrectFields);
        }

        public List<XlsxSheetObject> GenerateObjects()
        {
            List<XlsxSheetObject> sheetsObjects = new List<XlsxSheetObject>();
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
                            line.Add("");
                        }
                        else
                        {
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
                            XlsxSheetObject sheetsObject = new XlsxSheetObject();
                            sheetsObject.Cena = line[headersPositions["Cena"]];
                            sheetsObject.Id = line[headersPositions["ID"]];
                            sheetsObject.Nazwa = line[headersPositions["Nazwa"]];
                            sheetsObject.NrZamowienia = line[headersPositions["Nr Zamówienia"]];
                            sheetsObject.Opis = line[headersPositions["Opis"]];
                            sheetsObject.Pozycja = line[headersPositions["Pozycja"]];
                            sheetsObject.Poziom = line[headersPositions["Poziom"]];
                            for (int j = 0; j < datesInHedaers.Count; j++)
                            {
                                try
                                {
                                    string valueDateheader = line[headersPositions[datesInHedaers[j]]];
                                    if (acceptableValuesDateField.Contains(valueDateheader))
                                        sheetsObject.Daty.Add(datesInHedaers[j]);
                                }
                                catch (Exception) { }
                            }
                            sheetsObjects.Add(sheetsObject);
                        }
                        catch (Exception) { }   //dane niekompletne w linii, nic nie rob
                    }
                }
            }
            return sheetsObjects;
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
    }
}

