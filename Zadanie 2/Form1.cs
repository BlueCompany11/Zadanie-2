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
        private XlsxObject xlsxObject;
        public Form1()
        {
            InitializeComponent();
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
            var headers = Properties.Settings.Default.ConstHeaders.Cast<string>().ToList();
            var dateFields = Properties.Settings.Default.AcceptableDateFieldValue.Cast<string>().ToList();
            try
            {
                xlsxObject.OpenSheet(sheetNumber, headers, dateFields);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var generatedObjects = await Task.Run(() => xlsxObject.GenerateObjects());
            foreach (var item in generatedObjects)
            {
                try
                {
                    double costValue = item.TaskCount();
                    if (costValue == -1)
                    {
                        textBoxXlsxOutput.AppendText("Ilość dni emisji dla obiektu " + item.Nazwa + " wynosi 0." + "\n");
                    }
                    else
                    {
                        textBoxXlsxOutput.AppendText("Wynik dla obiektu " + item.Nazwa + " to " + item.TaskCount() + "\n");
                    }
                    
                }
                catch (Exception)
                {
                    textBoxXlsxOutput.AppendText("Niepoprawna wartosc ceny: " + item.Cena + "\n");
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
            string pickedFilePath = GetFilePath();
            if (!String.IsNullOrEmpty(pickedFilePath))
            {
                comboBoxSheetNumber.Items.Clear();
                var task = await Task.Run(() => xlsxObject = new XlsxObject(pickedFilePath));
                //xlsxObject = new XlsxObject(pickedFilePath);
                var sheetNumbers = await Task.Run(() => xlsxObject.GetSheetNumbers());
                for (int i = 0; i < sheetNumbers.Count; i++)
                {
                    comboBoxSheetNumber.Items.Add(sheetNumbers[i].Item1+". "+sheetNumbers[i].Item2);
                }
            }
        }

        private void buttonChangeSettings_Click(object sender, EventArgs e)
        {
            ChangeSettingsForm changeSettingsForm = new ChangeSettingsForm();
            changeSettingsForm.Show();
        }
    }
}
