namespace LIfeManager
{
    partial class HealthAndFitnessForm
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
            tbDataInput = new TextBox();
            btnUploadData = new Button();
            dgvHealthData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHealthData).BeginInit();
            SuspendLayout();
            // 
            // tbDataInput
            // 
            tbDataInput.Location = new Point(21, 30);
            tbDataInput.Name = "tbDataInput";
            tbDataInput.Size = new Size(794, 23);
            tbDataInput.TabIndex = 0;
            // 
            // btnUploadData
            // 
            btnUploadData.Location = new Point(835, 30);
            btnUploadData.Name = "btnUploadData";
            btnUploadData.Size = new Size(75, 23);
            btnUploadData.TabIndex = 1;
            btnUploadData.Text = "button1";
            btnUploadData.UseVisualStyleBackColor = true;
            btnUploadData.Click += btnUploadData_Click;
            // 
            // dgvHealthData
            // 
            dgvHealthData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHealthData.Location = new Point(21, 83);
            dgvHealthData.Name = "dgvHealthData";
            dgvHealthData.ReadOnly = true;
            dgvHealthData.Size = new Size(889, 325);
            dgvHealthData.TabIndex = 2;
            // 
            // HealthAndFitnessForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1520, 825);
            Controls.Add(dgvHealthData);
            Controls.Add(btnUploadData);
            Controls.Add(tbDataInput);
            Name = "HealthAndFitnessForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zdraví a fitness";
            ((System.ComponentModel.ISupportInitialize)dgvHealthData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbDataInput;
        private Button btnUploadData;
        private DataGridView dgvHealthData;
    }
}