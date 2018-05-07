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
        public static List<int> GetSheetNumbers(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);

            List<int> sheetNumbers = new List<int>();
            for (int i = 0; i < xlWorkbook.Sheets.Count; i++)
            {
                sheetNumbers.Add(i + 1);
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
