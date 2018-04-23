namespace Zadanie_2
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
            this.buttonGetFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxXlsxOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGetFile
            // 
            this.buttonGetFile.Location = new System.Drawing.Point(13, 13);
            this.buttonGetFile.Name = "buttonGetFile";
            this.buttonGetFile.Size = new System.Drawing.Size(75, 23);
            this.buttonGetFile.TabIndex = 0;
            this.buttonGetFile.Text = "Wybierz plik";
            this.buttonGetFile.UseVisualStyleBackColor = true;
            this.buttonGetFile.Click += new System.EventHandler(this.buttonGetFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Wybierz plik";
            // 
            // textBoxXlsxOutput
            // 
            this.textBoxXlsxOutput.Location = new System.Drawing.Point(13, 43);
            this.textBoxXlsxOutput.Multiline = true;
            this.textBoxXlsxOutput.Name = "textBoxXlsxOutput";
            this.textBoxXlsxOutput.Size = new System.Drawing.Size(396, 314);
            this.textBoxXlsxOutput.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 369);
            this.Controls.Add(this.textBoxXlsxOutput);
            this.Controls.Add(this.buttonGetFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxXlsxOutput;
    }
}

