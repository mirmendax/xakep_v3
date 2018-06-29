namespace libgame
{
    partial class EnemyCompInterface
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.wantedlbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.layoutService = new System.Windows.Forms.FlowLayoutPanel();
            this.moneybtn = new System.Windows.Forms.Button();
            this.moneylbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addrlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxService = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openbtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.uploadbtn = new System.Windows.Forms.Button();
            this.downloadbtn = new System.Windows.Forms.Button();
            this.listfiles = new System.Windows.Forms.ListBox();
            this.logoffbtn = new System.Windows.Forms.Button();
            this.downloadtimer = new System.Windows.Forms.Timer(this.components);
            this.uploadtimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.filename = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.wantedlbl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.layoutService);
            this.groupBox1.Controls.Add(this.moneybtn);
            this.groupBox1.Controls.Add(this.moneylbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.addrlbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 219);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(154, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Чистить логи";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wantedlbl
            // 
            this.wantedlbl.AutoSize = true;
            this.wantedlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wantedlbl.ForeColor = System.Drawing.Color.OrangeRed;
            this.wantedlbl.Location = new System.Drawing.Point(93, 181);
            this.wantedlbl.Name = "wantedlbl";
            this.wantedlbl.Size = new System.Drawing.Size(17, 17);
            this.wantedlbl.TabIndex = 10;
            this.wantedlbl.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(16, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Розыск:";
            // 
            // layoutService
            // 
            this.layoutService.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.layoutService.AutoScroll = true;
            this.layoutService.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutService.Location = new System.Drawing.Point(9, 61);
            this.layoutService.Name = "layoutService";
            this.layoutService.Size = new System.Drawing.Size(275, 99);
            this.layoutService.TabIndex = 8;
            // 
            // moneybtn
            // 
            this.moneybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moneybtn.Location = new System.Drawing.Point(222, 37);
            this.moneybtn.Name = "moneybtn";
            this.moneybtn.Size = new System.Drawing.Size(75, 23);
            this.moneybtn.TabIndex = 7;
            this.moneybtn.Text = "Снять $";
            this.moneybtn.UseVisualStyleBackColor = true;
            this.moneybtn.Click += new System.EventHandler(this.moneybtn_Click);
            // 
            // moneylbl
            // 
            this.moneylbl.AutoSize = true;
            this.moneylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.moneylbl.ForeColor = System.Drawing.Color.Yellow;
            this.moneylbl.Location = new System.Drawing.Point(93, 41);
            this.moneylbl.Name = "moneylbl";
            this.moneylbl.Size = new System.Drawing.Size(17, 17);
            this.moneylbl.TabIndex = 4;
            this.moneylbl.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(16, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Деньги: ";
            // 
            // addrlbl
            // 
            this.addrlbl.AutoSize = true;
            this.addrlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addrlbl.ForeColor = System.Drawing.Color.Yellow;
            this.addrlbl.Location = new System.Drawing.Point(81, 17);
            this.addrlbl.Name = "addrlbl";
            this.addrlbl.Size = new System.Drawing.Size(42, 17);
            this.addrlbl.TabIndex = 2;
            this.addrlbl.Text = "Addr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cBoxService);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.openbtn);
            this.groupBox2.Controls.Add(this.deletebtn);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.uploadbtn);
            this.groupBox2.Controls.Add(this.downloadbtn);
            this.groupBox2.Controls.Add(this.listfiles);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.Magenta;
            this.groupBox2.Location = new System.Drawing.Point(312, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 416);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список файлов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(7, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сервис: ";
            // 
            // cBoxService
            // 
            this.cBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxService.FormattingEnabled = true;
            this.cBoxService.Location = new System.Drawing.Point(96, 24);
            this.cBoxService.Name = "cBoxService";
            this.cBoxService.Size = new System.Drawing.Size(199, 24);
            this.cBoxService.TabIndex = 7;
            this.cBoxService.SelectedIndexChanged += new System.EventHandler(this.cBoxService_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.ForeColor = System.Drawing.Color.Chocolate;
            this.groupBox4.Location = new System.Drawing.Point(4, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(304, 120);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ваши файлы";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.Red;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(291, 94);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // openbtn
            // 
            this.openbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openbtn.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.openbtn.Location = new System.Drawing.Point(6, 214);
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(289, 23);
            this.openbtn.TabIndex = 4;
            this.openbtn.Text = "Открыть";
            this.openbtn.UseVisualStyleBackColor = true;
            this.openbtn.Click += new System.EventHandler(this.openbtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deletebtn.ForeColor = System.Drawing.Color.Crimson;
            this.deletebtn.Location = new System.Drawing.Point(210, 243);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(85, 23);
            this.deletebtn.TabIndex = 3;
            this.deletebtn.Text = "Удалить";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.DimGray;
            this.progressBar1.ForeColor = System.Drawing.Color.OrangeRed;
            this.progressBar1.Location = new System.Drawing.Point(6, 274);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 32;
            // 
            // uploadbtn
            // 
            this.uploadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uploadbtn.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.uploadbtn.Location = new System.Drawing.Point(96, 243);
            this.uploadbtn.Name = "uploadbtn";
            this.uploadbtn.Size = new System.Drawing.Size(108, 23);
            this.uploadbtn.TabIndex = 2;
            this.uploadbtn.Text = "Загрузить";
            this.uploadbtn.UseVisualStyleBackColor = true;
            this.uploadbtn.Click += new System.EventHandler(this.uploadbtn_Click);
            // 
            // downloadbtn
            // 
            this.downloadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downloadbtn.ForeColor = System.Drawing.Color.Turquoise;
            this.downloadbtn.Location = new System.Drawing.Point(4, 243);
            this.downloadbtn.Name = "downloadbtn";
            this.downloadbtn.Size = new System.Drawing.Size(86, 23);
            this.downloadbtn.TabIndex = 1;
            this.downloadbtn.Text = "Скачать";
            this.downloadbtn.UseVisualStyleBackColor = true;
            this.downloadbtn.Click += new System.EventHandler(this.downloadbtn_Click);
            // 
            // listfiles
            // 
            this.listfiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listfiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listfiles.ForeColor = System.Drawing.Color.Tomato;
            this.listfiles.FormattingEnabled = true;
            this.listfiles.ItemHeight = 15;
            this.listfiles.Location = new System.Drawing.Point(6, 65);
            this.listfiles.Name = "listfiles";
            this.listfiles.ScrollAlwaysVisible = true;
            this.listfiles.Size = new System.Drawing.Size(291, 107);
            this.listfiles.TabIndex = 0;
            // 
            // logoffbtn
            // 
            this.logoffbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoffbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoffbtn.ForeColor = System.Drawing.Color.PaleGreen;
            this.logoffbtn.Location = new System.Drawing.Point(484, 434);
            this.logoffbtn.Name = "logoffbtn";
            this.logoffbtn.Size = new System.Drawing.Size(136, 45);
            this.logoffbtn.TabIndex = 2;
            this.logoffbtn.Text = "Отключиться";
            this.logoffbtn.UseVisualStyleBackColor = true;
            this.logoffbtn.Click += new System.EventHandler(this.logoffbtn_Click);
            // 
            // downloadtimer
            // 
            this.downloadtimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uploadtimer
            // 
            this.uploadtimer.Tick += new System.EventHandler(this.uplaodtimer_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.filename);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Location = new System.Drawing.Point(3, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 212);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Просмотр файлов";
            // 
            // filename
            // 
            this.filename.AutoSize = true;
            this.filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filename.ForeColor = System.Drawing.Color.LightSalmon;
            this.filename.Location = new System.Drawing.Point(6, 19);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(71, 15);
            this.filename.TabIndex = 1;
            this.filename.Text = "FIle name";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox1.Location = new System.Drawing.Point(6, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 169);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Содержимое файлов";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Turquoise;
            this.button2.Location = new System.Drawing.Point(342, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 45);
            this.button2.TabIndex = 6;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EnemyCompInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.logoffbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EnemyCompInterface";
            this.Size = new System.Drawing.Size(635, 496);
            this.Load += new System.EventHandler(this.EnemyCompInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button moneybtn;
        private System.Windows.Forms.Label moneylbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label addrlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button uploadbtn;
        private System.Windows.Forms.Button downloadbtn;
        private System.Windows.Forms.ListBox listfiles;
        private System.Windows.Forms.Button logoffbtn;
        private System.Windows.Forms.Button openbtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer downloadtimer;
        private System.Windows.Forms.Timer uploadtimer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label filename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxService;
        private System.Windows.Forms.FlowLayoutPanel layoutService;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label wantedlbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
    }
}
