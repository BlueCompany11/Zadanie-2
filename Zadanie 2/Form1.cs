using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                    string[] headers = { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };
                    List<string> line=new List<string>();
                    for (int i = 1; i <= rowCount; i++)
                    {
                        line.Clear();
                        for (int j = 1; j <= colCount; j++)
                        {
                            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                                line.Add(xlRange.Cells[i, j].Value2.ToString().Trim());
                        }
                        var ret = !headers.Except(line).Any();
                        Console.WriteLine(ret);
                        textBoxXlsxOutput.AppendText(String.Join(" ", line.Where(s => !String.IsNullOrEmpty(s))));
                        textBoxXlsxOutput.AppendText("\n");
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
                catch (IOException)
                {
                    MessageBox.Show("Nie udało się otworzyć pliku: " + openFileDialog.FileName);
                }
            }
        }
    }
}
