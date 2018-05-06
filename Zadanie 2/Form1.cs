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
        //TODO: Tworzenie przez fabryke nowych konfiguracji do wyszukiwania
        private void buttonGetFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(file);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    List<string> headers = new List<string>() { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };
                    Dictionary<string, int> headersPos = new Dictionary<string, int>();
                    headersPos = headers.ToDictionary(x => x, x => -1);
                    //dodaje miejsce dla listy dat
                    List<string> datesInHedaers = new List<string>();
                    List<string> line=new List<string>();
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
                        bool headersLine = !headers.Except(line).Any();
                        //trzeba sie wrocic i uzupelnic o daty i zapamietac ich indeksy
                        Console.WriteLine(headersLine);
                        if (headersLine) //trzeba teraz stworzy strukutre na podstawie lini ktora jest headerem ->line
                        {
                            foundHeaders = true;
                            //uzupelniam o indeksy znajome pola
                            for (int k = 0; k < headers.Count; k++)
                            {
                                headersPos[headers[k]]= line.FindIndex(x => x.StartsWith(headers[k]));
                            }
                            //dodaje daty do naglowkow
                            for (int k = 0; k < line.Count; k++)
                            {
                                string[] dates = line[k].Split('-');
                                if (dates.Length == 2)
                                {
                                    try
                                    {
                                        DateTime dtBegin = DateTime.ParseExact(dates[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                                        DateTime dtEnd = DateTime.ParseExact(dates[1], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                                        int days = (dtEnd - dtBegin).Days + 1;
                                        datesInHedaers.Add(line[k]);
                                    }
                                    catch (Exception){ }
                                }
                                
                            }
                        }
                        if (foundHeaders)
                        {
                            textBoxXlsxOutput.AppendText(String.Join(" ", line.Where(s => !String.IsNullOrEmpty(s))));
                            textBoxXlsxOutput.AppendText("\n");
                            if (line.Count == 0)
                            {
                                break;
                            }
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
                }
                catch (COMException)
                {
                    MessageBox.Show("Nie udało się otworzyć pliku: " + openFileDialog.FileName);
                }
            }
        }
    }
}
