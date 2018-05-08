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
        private string lastPickedFilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private async Task<List<ExcelObject>> CreateObjectsFromExcel(string filePath,int sheetNumber)
        {
            List<ExcelObject> rowsAsObjects = await ExcelObject.CreateObjectsFromExcel(ExcelObject.headers,filePath, sheetNumber);
            return rowsAsObjects;
        }

        private async void buttonMakeSummary_Click(object sender, EventArgs e)
        {
            int sheetNumber = -1;
            try
            {
                sheetNumber = Int32.Parse(comboBoxSheetNumber.SelectedItem.ToString().Split('.')[0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Wybierz plik, a pozniej numer arkusza");
            }
            if (!String.IsNullOrEmpty(lastPickedFilePath))
            {
                var excelObjects = await Task.Run(() => CreateObjectsFromExcel(lastPickedFilePath, sheetNumber));
                foreach (var item in excelObjects)
                {
                    try
                    {
                        textBoxXlsxOutput.AppendText("Wynik dla obiektu "+item.Nazwa+" to "+ item.TaskCount()+"\n".ToString());
                    }
                    catch (Exception)
                    {
                        textBoxXlsxOutput.AppendText("Niepoprawna wartosc ceny: "+item.Cena + "\n");
                    }
                }
            }
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
            lastPickedFilePath = GetFilePath();
            if (!String.IsNullOrEmpty(lastPickedFilePath))
            {
                var sheetNumbers =  await Task.Run(() => XlsxReader.GetSheetNumbers(lastPickedFilePath));
                for (int i = 0; i < sheetNumbers.Count; i++)
                {
                    comboBoxSheetNumber.Items.Add(sheetNumbers[i].Item1+". "+sheetNumbers[i].Item2);
                }
            }
        }
    }
}
