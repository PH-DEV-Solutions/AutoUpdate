namespace LIfeManager
{
    partial class mainContentPanel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainContentPanel));
            btnOsobniZivot = new Button();
            btnPrace = new Button();
            btnFinance = new Button();
            btnZdraviAFitness = new Button();
            btnStavbaDomu = new Button();
            statusIndicator = new PictureBox();
            lb_activities_for_today = new ListBox();
            lb_activities_for_tomorrow = new ListBox();
            lb_activities_for_tomorrow_tomorrow = new ListBox();
            lbl_today = new Label();
            lbl_tomorrow_date = new Label();
            lbl_tomorrow_tomorrow_date = new Label();
            panel1 = new Panel();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btn_removeActivity = new Button();
            btn_editActivity = new Button();
            btn_addActivity = new Button();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            richTextBoxMe = new RichTextBox();
            btnSendToGpt = new Button();
            webViewGPT = new Microsoft.Web.WebView2.WinForms.WebView2();
            pictureBoxGPTSpeaking = new PictureBox();
            panel2 = new Panel();
            btnEnableMicrophoneManually = new Button();
            richTextBoxCrossroads = new RichTextBox();
            lbl_activatedgpt = new Label();
            lbl_timer = new Label();
            lblVersion = new Label();
            ((System.ComponentModel.ISupportInitialize)statusIndicator).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webViewGPT).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGPTSpeaking).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnOsobniZivot
            // 
            btnOsobniZivot.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold);
            btnOsobniZivot.Location = new Point(-54, 15);
            btnOsobniZivot.Name = "btnOsobniZivot";
            btnOsobniZivot.Size = new Size(1501, 50);
            btnOsobniZivot.TabIndex = 0;
            btnOsobniZivot.Text = "Osobní život";
            btnOsobniZivot.UseVisualStyleBackColor = true;
            btnOsobniZivot.Visible = false;
            // 
            // btnPrace
            // 
            btnPrace.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold);
            btnPrace.Location = new Point(12, 575);
            btnPrace.Name = "btnPrace";
            btnPrace.Size = new Size(1501, 50);
            btnPrace.TabIndex = 1;
            btnPrace.Text = "Práce";
            btnPrace.UseVisualStyleBackColor = true;
            btnPrace.Visible = false;
            // 
            // btnFinance
            // 
            btnFinance.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold);
            btnFinance.Location = new Point(16, 631);
            btnFinance.Name = "btnFinance";
            btnFinance.Size = new Size(1501, 50);
            btnFinance.TabIndex = 2;
            btnFinance.Text = "Finance";
            btnFinance.UseVisualStyleBackColor = true;
            btnFinance.Visible = false;
            // 
            // btnZdraviAFitness
            // 
            btnZdraviAFitness.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold);
            btnZdraviAFitness.Location = new Point(12, 687);
            btnZdraviAFitness.Name = "btnZdraviAFitness";
            btnZdraviAFitness.Size = new Size(1501, 50);
            btnZdraviAFitness.TabIndex = 3;
            btnZdraviAFitness.Text = "Zdraví a fitness";
            btnZdraviAFitness.UseVisualStyleBackColor = true;
            btnZdraviAFitness.Visible = false;
            btnZdraviAFitness.Click += btnZdraviAFitness_Click;
            // 
            // btnStavbaDomu
            // 
            btnStavbaDomu.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold);
            btnStavbaDomu.Location = new Point(12, 743);
            btnStavbaDomu.Name = "btnStavbaDomu";
            btnStavbaDomu.Size = new Size(1501, 50);
            btnStavbaDomu.TabIndex = 4;
            btnStavbaDomu.Text = "Stavba domu";
            btnStavbaDomu.UseVisualStyleBackColor = true;
            btnStavbaDomu.Visible = false;
            // 
            // statusIndicator
            // 
            statusIndicator.BackColor = Color.Gray;
            statusIndicator.BorderStyle = BorderStyle.Fixed3D;
            statusIndicator.Location = new Point(1137, 1);
            statusIndicator.Name = "statusIndicator";
            statusIndicator.Size = new Size(16, 13);
            statusIndicator.TabIndex = 8;
            statusIndicator.TabStop = false;
            // 
            // lb_activities_for_today
            // 
            lb_activities_for_today.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_activities_for_today.ForeColor = Color.FromArgb(0, 64, 64);
            lb_activities_for_today.FormattingEnabled = true;
            lb_activities_for_today.ItemHeight = 15;
            lb_activities_for_today.Location = new Point(95, 22);
            lb_activities_for_today.Name = "lb_activities_for_today";
            lb_activities_for_today.Size = new Size(334, 154);
            lb_activities_for_today.TabIndex = 9;
            // 
            // lb_activities_for_tomorrow
            // 
            lb_activities_for_tomorrow.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_activities_for_tomorrow.ForeColor = Color.FromArgb(255, 128, 0);
            lb_activities_for_tomorrow.FormattingEnabled = true;
            lb_activities_for_tomorrow.ItemHeight = 15;
            lb_activities_for_tomorrow.Location = new Point(435, 22);
            lb_activities_for_tomorrow.Name = "lb_activities_for_tomorrow";
            lb_activities_for_tomorrow.Size = new Size(334, 154);
            lb_activities_for_tomorrow.TabIndex = 10;
            // 
            // lb_activities_for_tomorrow_tomorrow
            // 
            lb_activities_for_tomorrow_tomorrow.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_activities_for_tomorrow_tomorrow.ForeColor = Color.RoyalBlue;
            lb_activities_for_tomorrow_tomorrow.FormattingEnabled = true;
            lb_activities_for_tomorrow_tomorrow.ItemHeight = 15;
            lb_activities_for_tomorrow_tomorrow.Location = new Point(95, 196);
            lb_activities_for_tomorrow_tomorrow.Name = "lb_activities_for_tomorrow_tomorrow";
            lb_activities_for_tomorrow_tomorrow.Size = new Size(334, 154);
            lb_activities_for_tomorrow_tomorrow.TabIndex = 11;
            // 
            // lbl_today
            // 
            lbl_today.AutoSize = true;
            lbl_today.Location = new Point(95, 4);
            lbl_today.Name = "lbl_today";
            lbl_today.Size = new Size(36, 15);
            lbl_today.TabIndex = 12;
            lbl_today.Text = "Dnes:";
            // 
            // lbl_tomorrow_date
            // 
            lbl_tomorrow_date.AutoSize = true;
            lbl_tomorrow_date.Location = new Point(435, 4);
            lbl_tomorrow_date.Name = "lbl_tomorrow_date";
            lbl_tomorrow_date.Size = new Size(34, 15);
            lbl_tomorrow_date.TabIndex = 13;
            lbl_tomorrow_date.Text = "XXX :";
            // 
            // lbl_tomorrow_tomorrow_date
            // 
            lbl_tomorrow_tomorrow_date.AutoSize = true;
            lbl_tomorrow_tomorrow_date.Location = new Point(95, 178);
            lbl_tomorrow_tomorrow_date.Name = "lbl_tomorrow_tomorrow_date";
            lbl_tomorrow_tomorrow_date.Size = new Size(34, 15);
            lbl_tomorrow_tomorrow_date.TabIndex = 14;
            lbl_tomorrow_tomorrow_date.Text = "XXX :";
            // 
            // panel1
            // 
            panel1.Controls.Add(webView21);
            panel1.Controls.Add(btn_removeActivity);
            panel1.Controls.Add(btn_editActivity);
            panel1.Controls.Add(lbl_tomorrow_tomorrow_date);
            panel1.Controls.Add(btn_addActivity);
            panel1.Controls.Add(lb_activities_for_tomorrow_tomorrow);
            panel1.Controls.Add(lbl_tomorrow_date);
            panel1.Controls.Add(btnOsobniZivot);
            panel1.Controls.Add(lb_activities_for_today);
            panel1.Controls.Add(lbl_today);
            panel1.Controls.Add(lb_activities_for_tomorrow);
            panel1.Location = new Point(56, 540);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 417);
            panel1.TabIndex = 15;
            panel1.Visible = false;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(-40, -161);
            webView21.Name = "webView21";
            webView21.Size = new Size(422, 430);
            webView21.TabIndex = 26;
            webView21.ZoomFactor = 1D;
            // 
            // btn_removeActivity
            // 
            btn_removeActivity.Location = new Point(14, 74);
            btn_removeActivity.Name = "btn_removeActivity";
            btn_removeActivity.Size = new Size(75, 23);
            btn_removeActivity.TabIndex = 2;
            btn_removeActivity.Text = "Remove";
            btn_removeActivity.UseVisualStyleBackColor = true;
            btn_removeActivity.Click += btn_removeActivity_Click;
            // 
            // btn_editActivity
            // 
            btn_editActivity.Location = new Point(14, 45);
            btn_editActivity.Name = "btn_editActivity";
            btn_editActivity.Size = new Size(75, 23);
            btn_editActivity.TabIndex = 1;
            btn_editActivity.Text = "Edit";
            btn_editActivity.UseVisualStyleBackColor = true;
            btn_editActivity.Click += btn_editActivity_Click;
            // 
            // btn_addActivity
            // 
            btn_addActivity.Location = new Point(14, 16);
            btn_addActivity.Name = "btn_addActivity";
            btn_addActivity.Size = new Size(75, 23);
            btn_addActivity.TabIndex = 0;
            btn_addActivity.Text = "Add";
            btn_addActivity.UseVisualStyleBackColor = true;
            btn_addActivity.Click += btn_addActivity_Click;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Location = new Point(9, 212);
            webView.Name = "webView";
            webView.Size = new Size(449, 524);
            webView.TabIndex = 15;
            webView.ZoomFactor = 1D;
            webView.Click += webView21_Click;
            // 
            // richTextBoxMe
            // 
            richTextBoxMe.Location = new Point(68, 32);
            richTextBoxMe.Name = "richTextBoxMe";
            richTextBoxMe.Size = new Size(208, 44);
            richTextBoxMe.TabIndex = 17;
            richTextBoxMe.Text = "";
            // 
            // btnSendToGpt
            // 
            btnSendToGpt.Location = new Point(68, 88);
            btnSendToGpt.Name = "btnSendToGpt";
            btnSendToGpt.Size = new Size(218, 25);
            btnSendToGpt.TabIndex = 18;
            btnSendToGpt.Text = "Send";
            btnSendToGpt.UseVisualStyleBackColor = true;
            btnSendToGpt.Click += btnSendToGpt_Click;
            // 
            // webViewGPT
            // 
            webViewGPT.AllowExternalDrop = true;
            webViewGPT.BackColor = Color.FromArgb(33, 33, 33);
            webViewGPT.CreationProperties = null;
            webViewGPT.DefaultBackgroundColor = Color.White;
            webViewGPT.ForeColor = Color.FromArgb(226, 226, 226);
            webViewGPT.Location = new Point(2, 49);
            webViewGPT.Name = "webViewGPT";
            webViewGPT.Size = new Size(501, 131);
            webViewGPT.TabIndex = 19;
            webViewGPT.ZoomFactor = 1D;
            // 
            // pictureBoxGPTSpeaking
            // 
            pictureBoxGPTSpeaking.Image = (Image)resources.GetObject("pictureBoxGPTSpeaking.Image");
            pictureBoxGPTSpeaking.Location = new Point(82, 186);
            pictureBoxGPTSpeaking.Name = "pictureBoxGPTSpeaking";
            pictureBoxGPTSpeaking.Size = new Size(256, 256);
            pictureBoxGPTSpeaking.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxGPTSpeaking.TabIndex = 21;
            pictureBoxGPTSpeaking.TabStop = false;
            pictureBoxGPTSpeaking.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(webView);
            panel2.Controls.Add(btnEnableMicrophoneManually);
            panel2.Controls.Add(richTextBoxMe);
            panel2.Controls.Add(btnSendToGpt);
            panel2.Controls.Add(richTextBoxCrossroads);
            panel2.Location = new Point(1042, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(461, 747);
            panel2.TabIndex = 16;
            // 
            // btnEnableMicrophoneManually
            // 
            btnEnableMicrophoneManually.Location = new Point(68, 3);
            btnEnableMicrophoneManually.Name = "btnEnableMicrophoneManually";
            btnEnableMicrophoneManually.Size = new Size(208, 23);
            btnEnableMicrophoneManually.TabIndex = 25;
            btnEnableMicrophoneManually.Text = "Aktivovat mikrofon manualně";
            btnEnableMicrophoneManually.UseVisualStyleBackColor = true;
            btnEnableMicrophoneManually.Click += btnEnableMicrophoneManually_Click;
            // 
            // richTextBoxCrossroads
            // 
            richTextBoxCrossroads.Location = new Point(68, 119);
            richTextBoxCrossroads.Name = "richTextBoxCrossroads";
            richTextBoxCrossroads.Size = new Size(218, 87);
            richTextBoxCrossroads.TabIndex = 22;
            richTextBoxCrossroads.Text = "";
            // 
            // lbl_activatedgpt
            // 
            lbl_activatedgpt.AutoSize = true;
            lbl_activatedgpt.Location = new Point(739, 139);
            lbl_activatedgpt.Name = "lbl_activatedgpt";
            lbl_activatedgpt.Size = new Size(38, 15);
            lbl_activatedgpt.TabIndex = 23;
            lbl_activatedgpt.Text = "label1";
            // 
            // lbl_timer
            // 
            lbl_timer.AutoSize = true;
            lbl_timer.Location = new Point(739, 105);
            lbl_timer.Name = "lbl_timer";
            lbl_timer.Size = new Size(34, 15);
            lbl_timer.TabIndex = 24;
            lbl_timer.Text = "00:00";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(630, 1);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(72, 15);
            lblVersion.TabIndex = 25;
            lblVersion.Text = "Version 1.0.2";
            // 
            // mainContentPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.crossroads_gigapixel_high_fidelity_v2_1024w;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1520, 825);
            Controls.Add(lblVersion);
            Controls.Add(webViewGPT);
            Controls.Add(pictureBoxGPTSpeaking);
            Controls.Add(lbl_timer);
            Controls.Add(lbl_activatedgpt);
            Controls.Add(btnStavbaDomu);
            Controls.Add(btnZdraviAFitness);
            Controls.Add(btnFinance);
            Controls.Add(btnPrace);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(statusIndicator);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "mainContentPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Life Manager";
            TopMost = true;
            Load += mainContentPanel_Load;
            Paint += DrawAnimationsPaintEvent;
            ((System.ComponentModel.ISupportInitialize)statusIndicator).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ((System.ComponentModel.ISupportInitialize)webViewGPT).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGPTSpeaking).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOsobniZivot;
        private Button btnPrace;
        private Button btnFinance;
        private Button btnZdraviAFitness;
        private Button btnStavbaDomu;
        private TextBox textBox2;
        private TextBox textBox3;
        private PictureBox statusIndicator;
        private ListBox lb_activities_today;
        private ListBox lb_activities_for_today;
        private ListBox lb_activities_for_tomorrow;
        private ListBox lb_activities_for_tomorrow_tomorrow;
        private Label lbl_today;
        private Label lbl_tomorrow_date;
        private Label lbl_tomorrow_tomorrow_date;
        private Panel panel1;
        private Button btn_removeActivity;
        private Button btn_editActivity;
        private Button btn_addActivity;
        private TextBox textBox4;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private RichTextBox richTextBoxMe;
        private Button btnSendToGpt;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewGPT;
        private PictureBox pictureBoxGPTSpeaking;
        private Panel panel2;
        private RichTextBox richTextBoxCrossroads;
        private Label lbl_activatedgpt;
        private Label lbl_timer;
        private Button btnEnableMicrophoneManually;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Label lblVersion;
    }
}
