namespace ZioClient
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textbox_nick = new System.Windows.Forms.TextBox();
            this.bnt_gettingQuestions = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_gettingQuestions = new System.Windows.Forms.GroupBox();
            this.numericUpDown_numberOfQuestions = new System.Windows.Forms.NumericUpDown();
            this.groupBox_question = new System.Windows.Forms.GroupBox();
            this.button_reset = new System.Windows.Forms.Button();
            this.label_questionNumber = new System.Windows.Forms.Label();
            this.bnt_previousQuestion = new System.Windows.Forms.Button();
            this.bnt_nextQuestion = new System.Windows.Forms.Button();
            this.radioButton_answer4 = new System.Windows.Forms.RadioButton();
            this.radioButton_answer3 = new System.Windows.Forms.RadioButton();
            this.radioButton_answer2 = new System.Windows.Forms.RadioButton();
            this.radioButton_answer1 = new System.Windows.Forms.RadioButton();
            this.pictureBox_pictureOfQuestion = new System.Windows.Forms.PictureBox();
            this.label_questionContent = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox_gettingQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberOfQuestions)).BeginInit();
            this.groupBox_question.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pictureOfQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textbox_nick
            // 
            this.textbox_nick.Location = new System.Drawing.Point(15, 57);
            this.textbox_nick.Name = "textbox_nick";
            this.textbox_nick.Size = new System.Drawing.Size(162, 20);
            this.textbox_nick.TabIndex = 1;
            // 
            // bnt_gettingQuestions
            // 
            this.bnt_gettingQuestions.Location = new System.Drawing.Point(6, 19);
            this.bnt_gettingQuestions.Name = "bnt_gettingQuestions";
            this.bnt_gettingQuestions.Size = new System.Drawing.Size(75, 23);
            this.bnt_gettingQuestions.TabIndex = 1;
            this.bnt_gettingQuestions.Text = "Losuj";
            this.bnt_gettingQuestions.UseVisualStyleBackColor = true;
            this.bnt_gettingQuestions.Click += new System.EventHandler(this.bnt_gettingQuestions_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_nick);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(192, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 102);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "test";
            // 
            // groupBox_gettingQuestions
            // 
            this.groupBox_gettingQuestions.Controls.Add(this.numericUpDown_numberOfQuestions);
            this.groupBox_gettingQuestions.Controls.Add(this.bnt_gettingQuestions);
            this.groupBox_gettingQuestions.Location = new System.Drawing.Point(12, 12);
            this.groupBox_gettingQuestions.Name = "groupBox_gettingQuestions";
            this.groupBox_gettingQuestions.Size = new System.Drawing.Size(223, 52);
            this.groupBox_gettingQuestions.TabIndex = 4;
            this.groupBox_gettingQuestions.TabStop = false;
            this.groupBox_gettingQuestions.Text = "Losowanie";
            // 
            // numericUpDown_numberOfQuestions
            // 
            this.numericUpDown_numberOfQuestions.Location = new System.Drawing.Point(87, 19);
            this.numericUpDown_numberOfQuestions.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown_numberOfQuestions.Name = "numericUpDown_numberOfQuestions";
            this.numericUpDown_numberOfQuestions.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_numberOfQuestions.TabIndex = 2;
            this.numericUpDown_numberOfQuestions.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox_question
            // 
            this.groupBox_question.Controls.Add(this.button_reset);
            this.groupBox_question.Controls.Add(this.label_questionNumber);
            this.groupBox_question.Controls.Add(this.bnt_previousQuestion);
            this.groupBox_question.Controls.Add(this.bnt_nextQuestion);
            this.groupBox_question.Controls.Add(this.radioButton_answer4);
            this.groupBox_question.Controls.Add(this.radioButton_answer3);
            this.groupBox_question.Controls.Add(this.radioButton_answer2);
            this.groupBox_question.Controls.Add(this.radioButton_answer1);
            this.groupBox_question.Controls.Add(this.pictureBox_pictureOfQuestion);
            this.groupBox_question.Controls.Add(this.label_questionContent);
            this.groupBox_question.Location = new System.Drawing.Point(12, 70);
            this.groupBox_question.Name = "groupBox_question";
            this.groupBox_question.Size = new System.Drawing.Size(639, 291);
            this.groupBox_question.TabIndex = 5;
            this.groupBox_question.TabStop = false;
            this.groupBox_question.Text = "Pytanie";
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(276, 256);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 6;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label_questionNumber
            // 
            this.label_questionNumber.AutoSize = true;
            this.label_questionNumber.Location = new System.Drawing.Point(84, 261);
            this.label_questionNumber.Name = "label_questionNumber";
            this.label_questionNumber.Size = new System.Drawing.Size(35, 13);
            this.label_questionNumber.TabIndex = 9;
            this.label_questionNumber.Text = "label1";
            // 
            // bnt_previousQuestion
            // 
            this.bnt_previousQuestion.Location = new System.Drawing.Point(0, 256);
            this.bnt_previousQuestion.Name = "bnt_previousQuestion";
            this.bnt_previousQuestion.Size = new System.Drawing.Size(75, 23);
            this.bnt_previousQuestion.TabIndex = 7;
            this.bnt_previousQuestion.Text = "Poprzednie";
            this.bnt_previousQuestion.UseVisualStyleBackColor = true;
            this.bnt_previousQuestion.Click += new System.EventHandler(this.bnt_previousQuestion_Click);
            // 
            // bnt_nextQuestion
            // 
            this.bnt_nextQuestion.Location = new System.Drawing.Point(195, 256);
            this.bnt_nextQuestion.Name = "bnt_nextQuestion";
            this.bnt_nextQuestion.Size = new System.Drawing.Size(75, 23);
            this.bnt_nextQuestion.TabIndex = 8;
            this.bnt_nextQuestion.Text = "Następne";
            this.bnt_nextQuestion.UseVisualStyleBackColor = true;
            this.bnt_nextQuestion.Click += new System.EventHandler(this.bnt_nextQuestion_Click);
            // 
            // radioButton_answer4
            // 
            this.radioButton_answer4.Location = new System.Drawing.Point(6, 200);
            this.radioButton_answer4.Name = "radioButton_answer4";
            this.radioButton_answer4.Size = new System.Drawing.Size(453, 50);
            this.radioButton_answer4.TabIndex = 6;
            this.radioButton_answer4.TabStop = true;
            this.radioButton_answer4.Text = "radioButton4";
            this.radioButton_answer4.UseVisualStyleBackColor = true;
            // 
            // radioButton_answer3
            // 
            this.radioButton_answer3.Location = new System.Drawing.Point(6, 144);
            this.radioButton_answer3.Name = "radioButton_answer3";
            this.radioButton_answer3.Size = new System.Drawing.Size(453, 50);
            this.radioButton_answer3.TabIndex = 5;
            this.radioButton_answer3.TabStop = true;
            this.radioButton_answer3.Text = "radioButton3";
            this.radioButton_answer3.UseVisualStyleBackColor = true;
            // 
            // radioButton_answer2
            // 
            this.radioButton_answer2.Location = new System.Drawing.Point(6, 88);
            this.radioButton_answer2.Name = "radioButton_answer2";
            this.radioButton_answer2.Size = new System.Drawing.Size(453, 50);
            this.radioButton_answer2.TabIndex = 4;
            this.radioButton_answer2.TabStop = true;
            this.radioButton_answer2.Text = "radioButton2";
            this.radioButton_answer2.UseVisualStyleBackColor = true;
            // 
            // radioButton_answer1
            // 
            this.radioButton_answer1.Location = new System.Drawing.Point(6, 32);
            this.radioButton_answer1.Name = "radioButton_answer1";
            this.radioButton_answer1.Size = new System.Drawing.Size(453, 50);
            this.radioButton_answer1.TabIndex = 3;
            this.radioButton_answer1.TabStop = true;
            this.radioButton_answer1.Text = "radioButton1";
            this.radioButton_answer1.UseVisualStyleBackColor = true;
            // 
            // pictureBox_pictureOfQuestion
            // 
            this.pictureBox_pictureOfQuestion.Location = new System.Drawing.Point(465, 16);
            this.pictureBox_pictureOfQuestion.Name = "pictureBox_pictureOfQuestion";
            this.pictureBox_pictureOfQuestion.Size = new System.Drawing.Size(168, 269);
            this.pictureBox_pictureOfQuestion.TabIndex = 1;
            this.pictureBox_pictureOfQuestion.TabStop = false;
            // 
            // label_questionContent
            // 
            this.label_questionContent.AutoSize = true;
            this.label_questionContent.Location = new System.Drawing.Point(6, 16);
            this.label_questionContent.Name = "label_questionContent";
            this.label_questionContent.Size = new System.Drawing.Size(71, 13);
            this.label_questionContent.TabIndex = 0;
            this.label_questionContent.Text = "Treść pytania";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox_question);
            this.Controls.Add(this.groupBox_gettingQuestions);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "Wskazania Sygnalizatorów Kolejowych";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_gettingQuestions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberOfQuestions)).EndInit();
            this.groupBox_question.ResumeLayout(false);
            this.groupBox_question.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pictureOfQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textbox_nick;
        private System.Windows.Forms.Button bnt_gettingQuestions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_gettingQuestions;
        private System.Windows.Forms.NumericUpDown numericUpDown_numberOfQuestions;
        private System.Windows.Forms.GroupBox groupBox_question;
        private System.Windows.Forms.RadioButton radioButton_answer4;
        private System.Windows.Forms.RadioButton radioButton_answer3;
        private System.Windows.Forms.RadioButton radioButton_answer2;
        private System.Windows.Forms.RadioButton radioButton_answer1;
        private System.Windows.Forms.PictureBox pictureBox_pictureOfQuestion;
        private System.Windows.Forms.Label label_questionContent;
        private System.Windows.Forms.Button bnt_previousQuestion;
        private System.Windows.Forms.Button bnt_nextQuestion;
        private System.Windows.Forms.Label label_questionNumber;
        private System.Windows.Forms.Button button_reset;
    }
}

