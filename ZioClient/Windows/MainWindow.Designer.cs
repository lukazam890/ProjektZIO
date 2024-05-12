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
            this.components = new System.ComponentModel.Container();
            this.bnt_gettingQuestions = new System.Windows.Forms.Button();
            this.groupBox_gettingQuestions = new System.Windows.Forms.GroupBox();
            this.btn_results = new System.Windows.Forms.Button();
            this.label_userName = new System.Windows.Forms.Label();
            this.textBox_nick = new System.Windows.Forms.TextBox();
            this.numericUpDown_numberOfQuestions = new System.Windows.Forms.NumericUpDown();
            this.groupBox_question = new System.Windows.Forms.GroupBox();
            this.label_questionNumberLabel = new System.Windows.Forms.Label();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button_Instruction = new System.Windows.Forms.Button();
            this.groupBox_gettingQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberOfQuestions)).BeginInit();
            this.groupBox_question.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pictureOfQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // bnt_gettingQuestions
            // 
            this.bnt_gettingQuestions.Location = new System.Drawing.Point(507, 16);
            this.bnt_gettingQuestions.Name = "bnt_gettingQuestions";
            this.bnt_gettingQuestions.Size = new System.Drawing.Size(75, 23);
            this.bnt_gettingQuestions.TabIndex = 1;
            this.bnt_gettingQuestions.Text = "Losuj";
            this.bnt_gettingQuestions.UseVisualStyleBackColor = true;
            this.bnt_gettingQuestions.Click += new System.EventHandler(this.bnt_gettingQuestions_Click);
            // 
            // groupBox_gettingQuestions
            // 
            this.groupBox_gettingQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_gettingQuestions.Controls.Add(this.button_Instruction);
            this.groupBox_gettingQuestions.Controls.Add(this.btn_results);
            this.groupBox_gettingQuestions.Controls.Add(this.label_userName);
            this.groupBox_gettingQuestions.Controls.Add(this.textBox_nick);
            this.groupBox_gettingQuestions.Controls.Add(this.numericUpDown_numberOfQuestions);
            this.groupBox_gettingQuestions.Controls.Add(this.bnt_gettingQuestions);
            this.groupBox_gettingQuestions.Location = new System.Drawing.Point(12, 12);
            this.groupBox_gettingQuestions.Name = "groupBox_gettingQuestions";
            this.groupBox_gettingQuestions.Size = new System.Drawing.Size(776, 52);
            this.groupBox_gettingQuestions.TabIndex = 4;
            this.groupBox_gettingQuestions.TabStop = false;
            this.groupBox_gettingQuestions.Text = "Losowanie";
            // 
            // btn_results
            // 
            this.btn_results.Location = new System.Drawing.Point(300, 16);
            this.btn_results.Name = "btn_results";
            this.btn_results.Size = new System.Drawing.Size(75, 23);
            this.btn_results.TabIndex = 5;
            this.btn_results.Text = "Wyniki";
            this.btn_results.UseVisualStyleBackColor = true;
            this.btn_results.Click += new System.EventHandler(this.btn_results_Click);
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Location = new System.Drawing.Point(6, 21);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(105, 13);
            this.label_userName.TabIndex = 4;
            this.label_userName.Text = "Nazwa uzytkownika:";
            // 
            // textBox_nick
            // 
            this.textBox_nick.Location = new System.Drawing.Point(114, 16);
            this.textBox_nick.Name = "textBox_nick";
            this.textBox_nick.Size = new System.Drawing.Size(180, 20);
            this.textBox_nick.TabIndex = 3;
            // 
            // numericUpDown_numberOfQuestions
            // 
            this.numericUpDown_numberOfQuestions.Location = new System.Drawing.Point(381, 16);
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
            this.groupBox_question.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_question.Controls.Add(this.label_questionNumberLabel);
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
            this.groupBox_question.Size = new System.Drawing.Size(776, 388);
            this.groupBox_question.TabIndex = 5;
            this.groupBox_question.TabStop = false;
            this.groupBox_question.Text = "Pytanie";
            // 
            // label_questionNumberLabel
            // 
            this.label_questionNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_questionNumberLabel.AutoSize = true;
            this.label_questionNumberLabel.Location = new System.Drawing.Point(249, 358);
            this.label_questionNumberLabel.Name = "label_questionNumberLabel";
            this.label_questionNumberLabel.Size = new System.Drawing.Size(45, 13);
            this.label_questionNumberLabel.TabIndex = 10;
            this.label_questionNumberLabel.Text = "Pytanie:";
            // 
            // button_reset
            // 
            this.button_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_reset.Location = new System.Drawing.Point(168, 353);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 9;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label_questionNumber
            // 
            this.label_questionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_questionNumber.AutoSize = true;
            this.label_questionNumber.Location = new System.Drawing.Point(300, 358);
            this.label_questionNumber.Name = "label_questionNumber";
            this.label_questionNumber.Size = new System.Drawing.Size(26, 13);
            this.label_questionNumber.TabIndex = 9;
            this.label_questionNumber.Text = "X/Y";
            // 
            // bnt_previousQuestion
            // 
            this.bnt_previousQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnt_previousQuestion.Location = new System.Drawing.Point(6, 353);
            this.bnt_previousQuestion.Name = "bnt_previousQuestion";
            this.bnt_previousQuestion.Size = new System.Drawing.Size(75, 23);
            this.bnt_previousQuestion.TabIndex = 7;
            this.bnt_previousQuestion.Text = "Poprzednie";
            this.bnt_previousQuestion.UseVisualStyleBackColor = true;
            this.bnt_previousQuestion.Click += new System.EventHandler(this.bnt_previousQuestion_Click);
            // 
            // bnt_nextQuestion
            // 
            this.bnt_nextQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnt_nextQuestion.Location = new System.Drawing.Point(87, 353);
            this.bnt_nextQuestion.Name = "bnt_nextQuestion";
            this.bnt_nextQuestion.Size = new System.Drawing.Size(75, 23);
            this.bnt_nextQuestion.TabIndex = 8;
            this.bnt_nextQuestion.Text = "Następne";
            this.bnt_nextQuestion.UseVisualStyleBackColor = true;
            this.bnt_nextQuestion.Click += new System.EventHandler(this.bnt_nextQuestion_Click);
            // 
            // radioButton_answer4
            // 
            this.radioButton_answer4.Location = new System.Drawing.Point(6, 260);
            this.radioButton_answer4.Name = "radioButton_answer4";
            this.radioButton_answer4.Size = new System.Drawing.Size(540, 70);
            this.radioButton_answer4.TabIndex = 6;
            this.radioButton_answer4.TabStop = true;
            this.radioButton_answer4.Text = "Pytanie4";
            this.radioButton_answer4.UseVisualStyleBackColor = true;
            // 
            // radioButton_answer3
            // 
            this.radioButton_answer3.Location = new System.Drawing.Point(6, 184);
            this.radioButton_answer3.Name = "radioButton_answer3";
            this.radioButton_answer3.Size = new System.Drawing.Size(540, 70);
            this.radioButton_answer3.TabIndex = 5;
            this.radioButton_answer3.TabStop = true;
            this.radioButton_answer3.Text = "Pytanie3";
            this.radioButton_answer3.UseVisualStyleBackColor = true;
            // 
            // radioButton_answer2
            // 
            this.radioButton_answer2.Location = new System.Drawing.Point(6, 108);
            this.radioButton_answer2.Name = "radioButton_answer2";
            this.radioButton_answer2.Size = new System.Drawing.Size(540, 70);
            this.radioButton_answer2.TabIndex = 4;
            this.radioButton_answer2.TabStop = true;
            this.radioButton_answer2.Text = "Pytanie2";
            this.radioButton_answer2.UseVisualStyleBackColor = true;
            // 
            // radioButton_answer1
            // 
            this.radioButton_answer1.Location = new System.Drawing.Point(6, 32);
            this.radioButton_answer1.Name = "radioButton_answer1";
            this.radioButton_answer1.Size = new System.Drawing.Size(540, 70);
            this.radioButton_answer1.TabIndex = 3;
            this.radioButton_answer1.TabStop = true;
            this.radioButton_answer1.Text = "Pytanie1";
            this.radioButton_answer1.UseVisualStyleBackColor = true;
            // 
            // pictureBox_pictureOfQuestion
            // 
            this.pictureBox_pictureOfQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_pictureOfQuestion.Location = new System.Drawing.Point(552, 16);
            this.pictureBox_pictureOfQuestion.Name = "pictureBox_pictureOfQuestion";
            this.pictureBox_pictureOfQuestion.Size = new System.Drawing.Size(218, 347);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button_Instruction
            // 
            this.button_Instruction.Location = new System.Drawing.Point(671, 16);
            this.button_Instruction.Name = "button_Instruction";
            this.button_Instruction.Size = new System.Drawing.Size(99, 23);
            this.button_Instruction.TabIndex = 6;
            this.button_Instruction.Text = "Instrukcja Ie-1";
            this.button_Instruction.UseVisualStyleBackColor = true;
            this.button_Instruction.Click += new System.EventHandler(this.button_Instruction_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.groupBox_question);
            this.Controls.Add(this.groupBox_gettingQuestions);
            this.MinimumSize = new System.Drawing.Size(816, 509);
            this.Name = "MainWindow";
            this.Text = "Wskazania Sygnalizatorów Kolejowych";
            this.groupBox_gettingQuestions.ResumeLayout(false);
            this.groupBox_gettingQuestions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numberOfQuestions)).EndInit();
            this.groupBox_question.ResumeLayout(false);
            this.groupBox_question.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pictureOfQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bnt_gettingQuestions;
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
        private System.Windows.Forms.Label label_questionNumberLabel;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.TextBox textBox_nick;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_results;
        private System.Windows.Forms.Button button_Instruction;
    }
}

