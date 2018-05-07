using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Zadanie_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task<List<ExcelObject>> CreateobjectsFromExcel(List<string> headers,string file)
        {
           
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            #region open excel file
            try
            {
                xlWorkbook = xlApp.Workbooks.Open(file);
            }
            catch (COMException)
            {
                MessageBox.Show("Nie udało się otworzyć pliku: " + openFileDialog.FileName);
                return null;
            }
            #endregion
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[Int32.Parse(textBoxSheetNumber.Text)];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            List<ExcelObject> excelObjects = new List<ExcelObject>();
            //List<string> headers = new List<string>() { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };
            Dictionary<string, int> headersPos = headers.ToDictionary(x => x, x => -1);
            List<string> datesInHedaers = new List<string>();
            List<string> line = new List<string>();
            bool foundHeaders = false;
            for (int i = 1; i <= rowCount; i++)
            {
                line.Clear();
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        line.Add(xlRange.Cells[i, j].Value2.ToString().Trim());
                    }
                }
                if (line.Count == 0 && foundHeaders)
                {
                    break;
                }
                bool headersLine = !headers.Except(line).Any();
                if (headersLine) //trzeba teraz stworzy strukutre na podstawie lini ktora jest headerem ->line
                {
                    foundHeaders = true;
                    //uzupelniam o indeksy znajome pola
                    for (int k = 0; k < headers.Count; k++)
                    {
                        headersPos[headers[k]] = line.FindIndex(x => x.StartsWith(headers[k]));
                    }
                    //szukam dat
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
                                    headersPos[datesInHedaers[l]] = line.FindIndex(x => x.StartsWith(datesInHedaers[l]));
                                }

                            }
                            catch (Exception) { }
                        }
                    }
                    foreach (var item in headersPos)
                    {
                        Console.WriteLine(item.Key.ToString() + " : " + item.Value.ToString());
                    }
                }
                if (foundHeaders)
                {
                    if (!headersLine)
                    {
                        try
                        {
                            ExcelObject excelObject = new ExcelObject();
                            excelObject.Cena = line[headersPos["Cena"]]; //zrobic tak dla reszty
                            excelObject.Id = line[headersPos["ID"]];
                            excelObject.Nazwa = line[headersPos["Nazwa"]];
                            excelObject.NrZamowienia = line[headersPos["Nr Zamówienia"]];
                            excelObject.Opis = line[headersPos["Opis"]];
                            excelObject.Pozycja = line[headersPos["Pozycja"]];
                            excelObject.Poziom = line[headersPos["Poziom"]];
                            for (int j = 0; j < datesInHedaers.Count; j++)
                            {
                                try
                                {
                                    if (!String.IsNullOrEmpty(line[headersPos[datesInHedaers[j]]])) //zamienic na algorytm do sprawdzania czy zapisac date
                                        excelObject.Daty.Add(datesInHedaers[j]);
                                }
                                catch (Exception) { }
                            }
                            excelObjects.Add(excelObject);
                            Console.WriteLine(excelObject);
                        }
                        catch (Exception) { }   //dane niekompletne w linii, nic nie rob?
                    }
                    //textBoxXlsxOutput.AppendText(String.Join(" ", line.Where(s => !String.IsNullOrEmpty(s))));
                    //textBoxXlsxOutput.AppendText("\n");
                    Console.WriteLine("kolejna linia");
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return excelObjects;
        }

        private async Task<int> DoTask(string filePath)
        {
            List<string> headers = new List<string>() { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };
            var x = await CreateobjectsFromExcel(headers,filePath);
            return 5;
        }

        private string GetFilePath()
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                return file;
            }
            return null;
        }
        
        private async void buttonGetFile_Click(object sender, EventArgs e)
        {
            string filePath = GetFilePath();
            var result = await Task.Run(() => DoTask(filePath));
            //DialogResult result = openFileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string file = openFileDialog.FileName;
            //    try
            //    {
            //        Excel.Application xlApp = new Excel.Application();
            //        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
            //        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[Int32.Parse(textBoxSheetNumber.Text)];
            //        Excel.Range xlRange = xlWorksheet.UsedRange;

            //        int rowCount = xlRange.Rows.Count;
            //        int colCount = xlRange.Columns.Count;
            //        List<ExcelObject> excelObjects = new List<ExcelObject>();
            //        List<string> headers = new List<string>() { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };
            //        Dictionary<string, int> headersPos = headers.ToDictionary(x => x, x => -1);
            //        List<string> datesInHedaers = new List<string>();
            //        List<string> line=new List<string>();
            //        bool foundHeaders = false;
            //        for (int i = 1; i <= rowCount; i++)
            //        {
            //            line.Clear();
            //            for (int j = 1; j <= colCount; j++)
            //            {
            //                if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
            //                {
            //                    line.Add(xlRange.Cells[i, j].Value2.ToString().Trim());
            //                }
            //            }
            //            if (line.Count == 0 && foundHeaders)
            //            {
            //                break;
            //            }
            //            bool headersLine = !headers.Except(line).Any();
            //            if (headersLine) //trzeba teraz stworzy strukutre na podstawie lini ktora jest headerem ->line
            //            {
            //                foundHeaders = true;
            //                //uzupelniam o indeksy znajome pola
            //                for (int k = 0; k < headers.Count; k++)
            //                {
            //                    headersPos[headers[k]]= line.FindIndex(x => x.StartsWith(headers[k]));
            //                }
            //                //szukam dat
            //                for (int k = 0; k < line.Count; k++)
            //                {
            //                    string[] dates = line[k].Split('-');
            //                    if (dates.Length == 2)
            //                    {
            //                        try
            //                        {
            //                            DateTime dtBegin = DateTime.ParseExact(dates[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //                            DateTime dtEnd = DateTime.ParseExact(dates[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //                            //int days = (dtEnd - dtBegin).Days + 1;
            //                            datesInHedaers.Add(line[k]);
            //                            for (int l = 0; l < datesInHedaers.Count; l++)
            //                            {
            //                                headersPos[datesInHedaers[l]] = line.FindIndex(x => x.StartsWith(datesInHedaers[l]));
            //                            }

            //                        }
            //                        catch (Exception){ }
            //                    }
            //                }
            //                foreach (var item in headersPos)
            //                {
            //                    Console.WriteLine(item.Key.ToString()+ " : " + item.Value.ToString());
            //                }
            //            }
            //            if (foundHeaders)
            //            {
            //                if (!headersLine)
            //                {
            //                    try
            //                    {
            //                        ExcelObject excelObject = new ExcelObject();
            //                        excelObject.Cena = line[headersPos["Cena"]]; //zrobic tak dla reszty
            //                        excelObject.Id = line[headersPos["ID"]];
            //                        excelObject.Nazwa = line[headersPos["Nazwa"]];
            //                        excelObject.NrZamowienia = line[headersPos["Nr Zamówienia"]];
            //                        excelObject.Opis = line[headersPos["Opis"]];
            //                        excelObject.Pozycja = line[headersPos["Pozycja"]];
            //                        excelObject.Poziom = line[headersPos["Poziom"]];
            //                        for (int j = 0; j < datesInHedaers.Count; j++)
            //                        {
            //                            try
            //                            {
            //                                if (!String.IsNullOrEmpty(line[headersPos[datesInHedaers[j]]])) //zamienic na algorytm do sprawdzania czy zapisac date
            //                                    excelObject.Daty.Add(datesInHedaers[j]);
            //                            }
            //                            catch (Exception) { }
            //                        }
            //                        excelObjects.Add(excelObject);
            //                        Console.WriteLine(excelObject);
            //                    }
            //                    catch (Exception) { }   //dane niekompletne w linii, nic nie rob?
            //                }
            //                textBoxXlsxOutput.AppendText(String.Join(" ", line.Where(s => !String.IsNullOrEmpty(s))));
            //                textBoxXlsxOutput.AppendText("\n");
            //            }
            //        }

            //        //cleanup
            //        GC.Collect();
            //        GC.WaitForPendingFinalizers();

            //        //rule of thumb for releasing com objects:
            //        //  never use two dots, all COM objects must be referenced and released individually
            //        //  ex: [somthing].[something].[something] is bad

            //        //release com objects to fully kill excel process from running in the background
            //        Marshal.ReleaseComObject(xlRange);
            //        Marshal.ReleaseComObject(xlWorksheet);

            //        //close and release
            //        xlWorkbook.Close(false);
            //        Marshal.ReleaseComObject(xlWorkbook);

            //        //quit and release
            //        xlApp.Quit();
            //        Marshal.ReleaseComObject(xlApp);
            //    }
            //    catch (COMException)
            //    {
            //        MessageBox.Show("Nie udało się otworzyć pliku: " + openFileDialog.FileName);
            //    }
            //}
        }

        private void textBoxSheetNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int val = Int32.Parse(textBoxSheetNumber.Text);
                if (val < 1)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("To pole musi być liczbą naturalną większą od 0.");
                textBoxSheetNumber.Text = "1";
            }
        }
    }
}
