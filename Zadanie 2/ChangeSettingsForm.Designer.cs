namespace Zadanie_2
{
    partial class ChangeSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDateSettings = new System.Windows.Forms.Label();
            this.textBoxDateSettings = new System.Windows.Forms.TextBox();
            this.buttonDateSettingsSave = new System.Windows.Forms.Button();
            this.comboBoxDateSettings = new System.Windows.Forms.ComboBox();
            this.buttonDataSettingsDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelDateSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDateSettings, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDateSettingsSave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDateSettings, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDataSettingsDelete, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 416);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDateSettings
            // 
            this.labelDateSettings.AutoSize = true;
            this.labelDateSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDateSettings.Location = new System.Drawing.Point(3, 0);
            this.labelDateSettings.Name = "labelDateSettings";
            this.labelDateSettings.Size = new System.Drawing.Size(265, 13);
            this.labelDateSettings.TabIndex = 0;
            this.labelDateSettings.Text = "Dodaj nową akceptowalną wartość dla pól dat";
            // 
            // textBoxDateSettings
            // 
            this.textBoxDateSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDateSettings.Location = new System.Drawing.Point(3, 16);
            this.textBoxDateSettings.Name = "textBoxDateSettings";
            this.textBoxDateSettings.Size = new System.Drawing.Size(265, 20);
            this.textBoxDateSettings.TabIndex = 1;
            // 
            // buttonDateSettingsSave
            // 
            this.buttonDateSettingsSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDateSettingsSave.Location = new System.Drawing.Point(3, 42);
            this.buttonDateSettingsSave.Name = "buttonDateSettingsSave";
            this.buttonDateSettingsSave.Size = new System.Drawing.Size(265, 23);
            this.buttonDateSettingsSave.TabIndex = 2;
            this.buttonDateSettingsSave.Text = "Dodaj";
            this.buttonDateSettingsSave.UseVisualStyleBackColor = true;
            this.buttonDateSettingsSave.Click += new System.EventHandler(this.buttonDateSettingsSave_Click);
            // 
            // comboBoxDateSettings
            // 
            this.comboBoxDateSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxDateSettings.FormattingEnabled = true;
            this.comboBoxDateSettings.Location = new System.Drawing.Point(3, 71);
            this.comboBoxDateSettings.Name = "comboBoxDateSettings";
            this.comboBoxDateSettings.Size = new System.Drawing.Size(265, 21);
            this.comboBoxDateSettings.TabIndex = 3;
            this.comboBoxDateSettings.DropDown += new System.EventHandler(this.comboBoxDateSettings_DropDown);
            // 
            // buttonDataSettingsDelete
            // 
            this.buttonDataSettingsDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDataSettingsDelete.Location = new System.Drawing.Point(3, 98);
            this.buttonDataSettingsDelete.Name = "buttonDataSettingsDelete";
            this.buttonDataSettingsDelete.Size = new System.Drawing.Size(265, 23);
            this.buttonDataSettingsDelete.TabIndex = 4;
            this.buttonDataSettingsDelete.Text = "Usuń";
            this.buttonDataSettingsDelete.UseVisualStyleBackColor = true;
            this.buttonDataSettingsDelete.Click += new System.EventHandler(this.buttonDataSettingsDelete_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(271, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 416F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(263, 416);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ChangeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 416);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangeSettingsForm";
            this.Text = "ChangeSettingsForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelDateSettings;
        private System.Windows.Forms.TextBox textBoxDateSettings;
        private System.Windows.Forms.Button buttonDateSettingsSave;
        private System.Windows.Forms.ComboBox comboBoxDateSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonDataSettingsDelete;
    }
}