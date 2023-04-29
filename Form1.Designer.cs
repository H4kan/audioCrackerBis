namespace audioCrackerBis
{
    partial class Form1
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
            corrPlot = new ScottPlot.FormsPlot();
            dictSelectBtn = new Button();
            dictLabel = new Label();
            recordBtn = new Button();
            selectTargetBtn = new Button();
            label1 = new Label();
            panel1 = new Panel();
            numOfWordsLabel = new Label();
            panel2 = new Panel();
            durationLabel = new Label();
            filenameLabel = new Label();
            panel3 = new Panel();
            label2 = new Label();
            frameCountUpDown = new NumericUpDown();
            bestLabel = new Label();
            analyzeBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)frameCountUpDown).BeginInit();
            SuspendLayout();
            // 
            // corrPlot
            // 
            corrPlot.ForeColor = SystemColors.MenuBar;
            corrPlot.Location = new Point(86, 245);
            corrPlot.Margin = new Padding(4, 3, 4, 3);
            corrPlot.Name = "corrPlot";
            corrPlot.Size = new Size(1251, 359);
            corrPlot.TabIndex = 0;
            // 
            // dictSelectBtn
            // 
            dictSelectBtn.BackColor = SystemColors.ButtonHighlight;
            dictSelectBtn.Location = new Point(275, 103);
            dictSelectBtn.Name = "dictSelectBtn";
            dictSelectBtn.Size = new Size(113, 39);
            dictSelectBtn.TabIndex = 1;
            dictSelectBtn.Text = "Select";
            dictSelectBtn.UseVisualStyleBackColor = false;
            dictSelectBtn.Click += dictSelectBtn_Click;
            // 
            // dictLabel
            // 
            dictLabel.AutoSize = true;
            dictLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dictLabel.Location = new Point(57, 64);
            dictLabel.Name = "dictLabel";
            dictLabel.Size = new Size(64, 15);
            dictLabel.TabIndex = 2;
            dictLabel.Text = "Dictionary:";
            // 
            // recordBtn
            // 
            recordBtn.BackColor = SystemColors.ButtonHighlight;
            recordBtn.Location = new Point(63, 51);
            recordBtn.Name = "recordBtn";
            recordBtn.Size = new Size(113, 39);
            recordBtn.TabIndex = 3;
            recordBtn.Text = "Record";
            recordBtn.UseVisualStyleBackColor = false;
            // 
            // selectTargetBtn
            // 
            selectTargetBtn.BackColor = SystemColors.ButtonHighlight;
            selectTargetBtn.Location = new Point(637, 103);
            selectTargetBtn.Name = "selectTargetBtn";
            selectTargetBtn.Size = new Size(113, 39);
            selectTargetBtn.TabIndex = 4;
            selectTargetBtn.Text = "Select";
            selectTargetBtn.UseVisualStyleBackColor = false;
            selectTargetBtn.Click += selectTargetBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(182, 64);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 5;
            label1.Text = "or";
            // 
            // panel1
            // 
            panel1.Controls.Add(numOfWordsLabel);
            panel1.Controls.Add(dictLabel);
            panel1.Location = new Point(148, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(277, 187);
            panel1.TabIndex = 6;
            // 
            // numOfWordsLabel
            // 
            numOfWordsLabel.AutoSize = true;
            numOfWordsLabel.Location = new Point(57, 107);
            numOfWordsLabel.Name = "numOfWordsLabel";
            numOfWordsLabel.Size = new Size(89, 15);
            numOfWordsLabel.TabIndex = 0;
            numOfWordsLabel.Text = "Num of words: ";
            numOfWordsLabel.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(durationLabel);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(recordBtn);
            panel2.Controls.Add(filenameLabel);
            panel2.Location = new Point(431, 52);
            panel2.Name = "panel2";
            panel2.Size = new Size(369, 187);
            panel2.TabIndex = 7;
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new Point(63, 107);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new Size(53, 15);
            durationLabel.TabIndex = 2;
            durationLabel.Text = "Duration";
            // 
            // filenameLabel
            // 
            filenameLabel.AutoSize = true;
            filenameLabel.Location = new Point(206, 107);
            filenameLabel.Name = "filenameLabel";
            filenameLabel.Size = new Size(58, 15);
            filenameLabel.TabIndex = 1;
            filenameLabel.Text = "File name";
            filenameLabel.Visible = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(frameCountUpDown);
            panel3.Controls.Add(bestLabel);
            panel3.Controls.Add(analyzeBtn);
            panel3.Location = new Point(806, 52);
            panel3.Name = "panel3";
            panel3.Size = new Size(303, 187);
            panel3.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(77, 53);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 3;
            label2.Text = "Frames:";
            // 
            // frameCountUpDown
            // 
            frameCountUpDown.Location = new Point(131, 51);
            frameCountUpDown.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            frameCountUpDown.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            frameCountUpDown.Name = "frameCountUpDown";
            frameCountUpDown.Size = new Size(82, 23);
            frameCountUpDown.TabIndex = 10;
            frameCountUpDown.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // bestLabel
            // 
            bestLabel.AutoSize = true;
            bestLabel.Location = new Point(77, 134);
            bestLabel.Name = "bestLabel";
            bestLabel.Size = new Size(83, 15);
            bestLabel.TabIndex = 6;
            bestLabel.Text = "Best matching";
            bestLabel.Visible = false;
            // 
            // analyzeBtn
            // 
            analyzeBtn.BackColor = SystemColors.ButtonHighlight;
            analyzeBtn.Enabled = false;
            analyzeBtn.Location = new Point(100, 83);
            analyzeBtn.Name = "analyzeBtn";
            analyzeBtn.Size = new Size(113, 39);
            analyzeBtn.TabIndex = 9;
            analyzeBtn.Text = "Analyze";
            analyzeBtn.UseVisualStyleBackColor = false;
            analyzeBtn.Click += analyzeBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1473, 628);
            Controls.Add(panel3);
            Controls.Add(selectTargetBtn);
            Controls.Add(dictSelectBtn);
            Controls.Add(corrPlot);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Form1";
            Text = "audioCrackerBis";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)frameCountUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot corrPlot;
        private Button dictSelectBtn;
        private Label dictLabel;
        private Button recordBtn;
        private Button selectTargetBtn;
        private Label label1;
        private Panel panel1;
        private Label numOfWordsLabel;
        private Panel panel2;
        private Label durationLabel;
        private Label filenameLabel;
        private Panel panel3;
        private Button analyzeBtn;
        private Label bestLabel;
        private Label label2;
        private NumericUpDown frameCountUpDown;
    }
}