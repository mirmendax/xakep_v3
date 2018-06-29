namespace EditorXakep
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabName = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabComp = new System.Windows.Forms.TabPage();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.tabQuest = new System.Windows.Forms.TabPage();
            this.tabComplect = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.Nametbox = new System.Windows.Forms.TextBox();
            this.Desctbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Capacitynumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Bodytbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Typecbox = new System.Windows.Forms.ComboBox();
            this.constanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Clearbtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Fileslist = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabName.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tabComplect.SuspendLayout();
            this.tabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Capacitynumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabName);
            this.tabControl1.Controls.Add(this.tabComp);
            this.tabControl1.Controls.Add(this.tabFile);
            this.tabControl1.Controls.Add(this.tabQuest);
            this.tabControl1.Controls.Add(this.tabComplect);
            this.tabControl1.Location = new System.Drawing.Point(-1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(659, 528);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // tabName
            // 
            this.tabName.Controls.Add(this.label1);
            this.tabName.Controls.Add(this.textBox1);
            this.tabName.Location = new System.Drawing.Point(4, 25);
            this.tabName.Name = "tabName";
            this.tabName.Size = new System.Drawing.Size(651, 499);
            this.tabName.TabIndex = 3;
            this.tabName.Text = "Общее";
            this.tabName.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name file:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabComp
            // 
            this.tabComp.Location = new System.Drawing.Point(4, 25);
            this.tabComp.Name = "tabComp";
            this.tabComp.Padding = new System.Windows.Forms.Padding(3);
            this.tabComp.Size = new System.Drawing.Size(651, 499);
            this.tabComp.TabIndex = 0;
            this.tabComp.Text = "Компьютеры";
            this.tabComp.UseVisualStyleBackColor = true;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.Deletebtn);
            this.tabFile.Controls.Add(this.label7);
            this.tabFile.Controls.Add(this.Fileslist);
            this.tabFile.Controls.Add(this.Addbtn);
            this.tabFile.Controls.Add(this.Clearbtn);
            this.tabFile.Controls.Add(this.Typecbox);
            this.tabFile.Controls.Add(this.label6);
            this.tabFile.Controls.Add(this.Bodytbox);
            this.tabFile.Controls.Add(this.label5);
            this.tabFile.Controls.Add(this.label4);
            this.tabFile.Controls.Add(this.Capacitynumber);
            this.tabFile.Controls.Add(this.Desctbox);
            this.tabFile.Controls.Add(this.label3);
            this.tabFile.Controls.Add(this.Nametbox);
            this.tabFile.Controls.Add(this.label2);
            this.tabFile.Location = new System.Drawing.Point(4, 25);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(651, 499);
            this.tabFile.TabIndex = 1;
            this.tabFile.Text = "Файлы";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // tabQuest
            // 
            this.tabQuest.Location = new System.Drawing.Point(4, 25);
            this.tabQuest.Name = "tabQuest";
            this.tabQuest.Size = new System.Drawing.Size(651, 499);
            this.tabQuest.TabIndex = 2;
            this.tabQuest.Text = "Задания";
            this.tabQuest.UseVisualStyleBackColor = true;
            // 
            // tabComplect
            // 
            this.tabComplect.Controls.Add(this.tabControl2);
            this.tabComplect.Location = new System.Drawing.Point(4, 25);
            this.tabComplect.Name = "tabComplect";
            this.tabComplect.Size = new System.Drawing.Size(651, 499);
            this.tabComplect.TabIndex = 4;
            this.tabComplect.Text = "Комплектующие";
            this.tabComplect.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(645, 496);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(637, 470);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "MotherBoard";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(637, 470);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "RAM";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(637, 470);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "CPU";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(637, 470);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "HDD";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(637, 470);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "LAN";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name file:";
            // 
            // Nametbox
            // 
            this.Nametbox.Location = new System.Drawing.Point(72, 14);
            this.Nametbox.Name = "Nametbox";
            this.Nametbox.Size = new System.Drawing.Size(142, 20);
            this.Nametbox.TabIndex = 1;
            // 
            // Desctbox
            // 
            this.Desctbox.Location = new System.Drawing.Point(72, 40);
            this.Desctbox.Name = "Desctbox";
            this.Desctbox.Size = new System.Drawing.Size(142, 20);
            this.Desctbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // Capacitynumber
            // 
            this.Capacitynumber.Location = new System.Drawing.Point(72, 66);
            this.Capacitynumber.Name = "Capacitynumber";
            this.Capacitynumber.Size = new System.Drawing.Size(142, 20);
            this.Capacitynumber.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Capacity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Body:";
            // 
            // Bodytbox
            // 
            this.Bodytbox.Location = new System.Drawing.Point(72, 114);
            this.Bodytbox.Multiline = true;
            this.Bodytbox.Name = "Bodytbox";
            this.Bodytbox.Size = new System.Drawing.Size(298, 124);
            this.Bodytbox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Type:";
            // 
            // Typecbox
            // 
            this.Typecbox.FormattingEnabled = true;
            this.Typecbox.Items.AddRange(new object[] {
            "NONE",
            "OSPROGRAM",
            "SCRIPT",
            "EXPLOIT",
            "BOTNET",
            "TXT",
            "DATA",
            "DB"});
            this.Typecbox.Location = new System.Drawing.Point(72, 90);
            this.Typecbox.Name = "Typecbox";
            this.Typecbox.Size = new System.Drawing.Size(142, 21);
            this.Typecbox.TabIndex = 9;
            // 
            // constanceBindingSource
            // 
            this.constanceBindingSource.DataSource = typeof(libgame.Constance);
            // 
            // Clearbtn
            // 
            this.Clearbtn.Location = new System.Drawing.Point(12, 253);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(75, 23);
            this.Clearbtn.TabIndex = 10;
            this.Clearbtn.Text = "Clear";
            this.Clearbtn.UseVisualStyleBackColor = true;
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(93, 253);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 11;
            this.Addbtn.Text = "Add";
            this.Addbtn.UseVisualStyleBackColor = true;
            // 
            // Fileslist
            // 
            this.Fileslist.FormattingEnabled = true;
            this.Fileslist.Location = new System.Drawing.Point(12, 348);
            this.Fileslist.Name = "Fileslist";
            this.Fileslist.Size = new System.Drawing.Size(492, 134);
            this.Fileslist.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "List files:";
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(510, 348);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(75, 23);
            this.Deletebtn.TabIndex = 14;
            this.Deletebtn.Text = "Delete";
            this.Deletebtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 528);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabName.ResumeLayout(false);
            this.tabName.PerformLayout();
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.tabComplect.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Capacitynumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constanceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabComp;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TabPage tabQuest;
        private System.Windows.Forms.TabPage tabComplect;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox Desctbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Nametbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Typecbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Bodytbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Capacitynumber;
        private System.Windows.Forms.BindingSource constanceBindingSource;
        private System.Windows.Forms.Button Clearbtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox Fileslist;
        private System.Windows.Forms.Button Addbtn;
    }
}

