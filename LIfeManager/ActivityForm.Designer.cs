namespace LIfeManager
{
    partial class ActivityForm
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
            tb_title = new TextBox();
            tb_description = new TextBox();
            lvl_title = new Label();
            lbl_description = new Label();
            lbl_ActivityDate = new Label();
            dtpActivityDate = new DateTimePicker();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // tb_title
            // 
            tb_title.Location = new Point(156, 53);
            tb_title.Name = "tb_title";
            tb_title.Size = new Size(411, 23);
            tb_title.TabIndex = 0;
            // 
            // tb_description
            // 
            tb_description.Location = new Point(156, 94);
            tb_description.Name = "tb_description";
            tb_description.Size = new Size(411, 23);
            tb_description.TabIndex = 1;
            // 
            // lvl_title
            // 
            lvl_title.AutoSize = true;
            lvl_title.Location = new Point(64, 56);
            lvl_title.Name = "lvl_title";
            lvl_title.Size = new Size(86, 15);
            lvl_title.TabIndex = 3;
            lvl_title.Text = "Název aktivity :";
            // 
            // lbl_description
            // 
            lbl_description.AutoSize = true;
            lbl_description.Location = new Point(64, 97);
            lbl_description.Name = "lbl_description";
            lbl_description.Size = new Size(83, 15);
            lbl_description.TabIndex = 4;
            lbl_description.Text = "Popis aktivity :";
            // 
            // lbl_ActivityDate
            // 
            lbl_ActivityDate.AutoSize = true;
            lbl_ActivityDate.Location = new Point(64, 140);
            lbl_ActivityDate.Name = "lbl_ActivityDate";
            lbl_ActivityDate.Size = new Size(83, 15);
            lbl_ActivityDate.TabIndex = 5;
            lbl_ActivityDate.Text = "Popis aktivity :";
            // 
            // dtpActivityDate
            // 
            dtpActivityDate.Location = new Point(156, 140);
            dtpActivityDate.Name = "dtpActivityDate";
            dtpActivityDate.Size = new Size(200, 23);
            dtpActivityDate.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(411, 191);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 8;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(492, 191);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ActivityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 242);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(dtpActivityDate);
            Controls.Add(lbl_ActivityDate);
            Controls.Add(lbl_description);
            Controls.Add(lvl_title);
            Controls.Add(tb_description);
            Controls.Add(tb_title);
            Name = "ActivityForm";
            Text = "ActivityForm";
            Load += ActivityForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_title;
        private TextBox tb_description;
        private Label lvl_title;
        private Label lbl_description;
        private Label lbl_ActivityDate;
        private DateTimePicker dtpActivityDate;
        private Button btnOK;
        private Button btnCancel;
    }
}