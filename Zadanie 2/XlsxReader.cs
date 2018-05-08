using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Zadanie_2
{
    public static class XlsxReader
    {
        public static List<Tuple<int,string>> GetSheetNumbers(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            //var asd = xlWorkbook.Sheets.Item[xlWorkbook.Sheets.Count].Name;
            List<Tuple<int, string>> sheetNumbers = new List<Tuple<int, string>> { };       
            for (int i = 1; i <= xlWorkbook.Sheets.Count; i++)
            {

                sheetNumbers.Add(new Tuple<int, string>(i, xlWorkbook.Sheets.Item[i].Name));
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            //close and release
            xlWorkbook.Close(false);
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return sheetNumbers;
        }
        
    }

}
