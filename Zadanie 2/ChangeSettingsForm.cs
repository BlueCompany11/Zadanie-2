using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_2
{
    public partial class ChangeSettingsForm : Form
    {
        public ChangeSettingsForm()
        {
            InitializeComponent();
        }

        private void buttonDateSettingsSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AcceptableDateFieldValue.Add(textBoxDateSettings.Text);
        }

        private void buttonDataSettingsDelete_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AcceptableDateFieldValue.Remove(comboBoxDateSettings.SelectedItem.ToString());
        }

        private void comboBoxDateSettings_DropDown(object sender, EventArgs e)
        {
            comboBoxDateSettings.Items.Clear();
            var dataProperties = Properties.Settings.Default.AcceptableDateFieldValue;
            foreach (string item in dataProperties)
            {
                comboBoxDateSettings.Items.Add(item);
            }
        }
    }
}
