﻿namespace Zadanie_2
{
    partial class Form1
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGetFilePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSheetNumber = new System.Windows.Forms.ComboBox();
            this.buttonMakeSummary = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxXlsxOutput = new System.Windows.Forms.TextBox();
            this.buttonChangeSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Zadanie praca.xlsx";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(789, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 371);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(789, 371);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.buttonGetFilePath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxSheetNumber, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonChangeSettings, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.buttonMakeSummary, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(112, 365);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // buttonGetFilePath
            // 
            this.buttonGetFilePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGetFilePath.Location = new System.Drawing.Point(3, 3);
            this.buttonGetFilePath.Name = "buttonGetFilePath";
            this.buttonGetFilePath.Size = new System.Drawing.Size(106, 23);
            this.buttonGetFilePath.TabIndex = 0;
            this.buttonGetFilePath.Text = "Wybierz plik";
            this.buttonGetFilePath.UseVisualStyleBackColor = true;
            this.buttonGetFilePath.Click += new System.EventHandler(this.buttonGetFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numer arkusza";
            // 
            // comboBoxSheetNumber
            // 
            this.comboBoxSheetNumber.FormattingEnabled = true;
            this.comboBoxSheetNumber.Location = new System.Drawing.Point(3, 45);
            this.comboBoxSheetNumber.Name = "comboBoxSheetNumber";
            this.comboBoxSheetNumber.Size = new System.Drawing.Size(106, 21);
            this.comboBoxSheetNumber.TabIndex = 3;
            this.comboBoxSheetNumber.Text = "Wybierz numer arkusza";
            // 
            // buttonMakeSummary
            // 
            this.buttonMakeSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonMakeSummary.Location = new System.Drawing.Point(3, 339);
            this.buttonMakeSummary.Name = "buttonMakeSummary";
            this.buttonMakeSummary.Size = new System.Drawing.Size(106, 23);
            this.buttonMakeSummary.TabIndex = 4;
            this.buttonMakeSummary.Text = "Podsumuj";
            this.buttonMakeSummary.UseVisualStyleBackColor = true;
            this.buttonMakeSummary.Click += new System.EventHandler(this.buttonMakeSummary_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.textBoxXlsxOutput, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(121, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(665, 365);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // textBoxXlsxOutput
            // 
            this.textBoxXlsxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxXlsxOutput.Location = new System.Drawing.Point(3, 3);
            this.textBoxXlsxOutput.Multiline = true;
            this.textBoxXlsxOutput.Name = "textBoxXlsxOutput";
            this.textBoxXlsxOutput.Size = new System.Drawing.Size(659, 359);
            this.textBoxXlsxOutput.TabIndex = 0;
            // 
            // buttonChangeSettings
            // 
            this.buttonChangeSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonChangeSettings.Location = new System.Drawing.Point(3, 72);
            this.buttonChangeSettings.Name = "buttonChangeSettings";
            this.buttonChangeSettings.Size = new System.Drawing.Size(106, 23);
            this.buttonChangeSettings.TabIndex = 5;
            this.buttonChangeSettings.Text = "Zmień ustawienia";
            this.buttonChangeSettings.UseVisualStyleBackColor = true;
            this.buttonChangeSettings.Click += new System.EventHandler(this.buttonChangeSettings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(789, 371);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(100, 200);
            this.Name = "Form1";
            this.Text = "Zadanie 2";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonGetFilePath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox textBoxXlsxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSheetNumber;
        private System.Windows.Forms.Button buttonMakeSummary;
        private System.Windows.Forms.Button buttonChangeSettings;
    }
}

