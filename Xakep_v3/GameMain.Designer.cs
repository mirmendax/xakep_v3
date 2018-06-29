namespace Xakep_v3
{
    partial class GameMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMain));
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConsoleInput = new System.Windows.Forms.TextBox();
            this.Map = new System.Windows.Forms.Panel();
            this.ConsoleBox = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.ConsoleTxt = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ListFilePlayer = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mailListlbl = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.mapBox = new System.Windows.Forms.Panel();
            this.labelmap = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ConsoleBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mailBox.SuspendLayout();
            this.mapBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(332, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 43);
            this.listBox1.TabIndex = 1;
            this.listBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Tan;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(44, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.TabStop = false;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(6, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // ConsoleInput
            // 
            this.ConsoleInput.AllowDrop = true;
            this.ConsoleInput.AutoCompleteCustomSource.AddRange(new string[] {
            "nmap",
            "mail",
            "a.dc-jibro-corp.cc",
            "scan",
            "scan a.dc-jibro-corp.cc",
            "scan t.dc-jibro-corp.cc",
            "ls",
            "more"});
            this.ConsoleInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ConsoleInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ConsoleInput.BackColor = System.Drawing.SystemColors.InfoText;
            this.ConsoleInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.ConsoleInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleInput.ForeColor = System.Drawing.Color.Lime;
            this.ConsoleInput.Location = new System.Drawing.Point(67, 3);
            this.ConsoleInput.Name = "ConsoleInput";
            this.ConsoleInput.Size = new System.Drawing.Size(924, 16);
            this.ConsoleInput.TabIndex = 0;
            this.ConsoleInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.Black;
            this.Map.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Map.BackgroundImage")));
            this.Map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Map.Cursor = System.Windows.Forms.Cursors.Default;
            this.Map.Location = new System.Drawing.Point(3, 20);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(615, 310);
            this.Map.TabIndex = 8;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleBox.Controls.Add(this.label8);
            this.ConsoleBox.Controls.Add(this.ConsoleTxt);
            this.ConsoleBox.Controls.Add(this.flowLayoutPanel1);
            this.ConsoleBox.Location = new System.Drawing.Point(12, 351);
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.Size = new System.Drawing.Size(746, 409);
            this.ConsoleBox.TabIndex = 17;
            this.ConsoleBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseDown);
            this.ConsoleBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseMove);
            this.ConsoleBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseUp);
            this.ConsoleBox.Resize += new System.EventHandler(this.groupBox2_Resize);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Консоль";
            // 
            // ConsoleTxt
            // 
            this.ConsoleTxt.BackColor = System.Drawing.SystemColors.InfoText;
            this.ConsoleTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleTxt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleTxt.ForeColor = System.Drawing.Color.Lime;
            this.ConsoleTxt.Location = new System.Drawing.Point(6, 32);
            this.ConsoleTxt.Multiline = true;
            this.ConsoleTxt.Name = "ConsoleTxt";
            this.ConsoleTxt.ReadOnly = true;
            this.ConsoleTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsoleTxt.Size = new System.Drawing.Size(615, 341);
            this.ConsoleTxt.TabIndex = 11;
            this.ConsoleTxt.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.ConsoleInput);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 377);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(744, 30);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "localhost";
            // 
            // listBox3
            // 
            this.listBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listBox3.ForeColor = System.Drawing.Color.LightCoral;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(211, 19);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(161, 121);
            this.listBox3.TabIndex = 9;
            this.listBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.ListFilePlayer);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(755, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 395);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Компьютер";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(6, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 26);
            this.button3.TabIndex = 10;
            this.button3.TabStop = false;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ListFilePlayer
            // 
            this.ListFilePlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListFilePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListFilePlayer.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.ListFilePlayer.FormattingEnabled = true;
            this.ListFilePlayer.ItemHeight = 15;
            this.ListFilePlayer.Location = new System.Drawing.Point(6, 146);
            this.ListFilePlayer.Name = "ListFilePlayer";
            this.ListFilePlayer.Size = new System.Drawing.Size(373, 169);
            this.ListFilePlayer.TabIndex = 0;
            this.ListFilePlayer.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(9, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Письмо:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.DarkOrange;
            this.label6.Location = new System.Drawing.Point(9, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "От:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.Orange;
            this.textBox3.Location = new System.Drawing.Point(9, 85);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(418, 247);
            this.textBox3.TabIndex = 0;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Писем нет";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Orange;
            this.textBox2.Location = new System.Drawing.Point(44, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(383, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "-";
            // 
            // mailListlbl
            // 
            this.mailListlbl.AutoSize = true;
            this.mailListlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mailListlbl.ForeColor = System.Drawing.Color.DarkOrange;
            this.mailListlbl.Location = new System.Drawing.Point(203, 353);
            this.mailListlbl.Name = "mailListlbl";
            this.mailListlbl.Size = new System.Drawing.Size(27, 15);
            this.mailListlbl.TabIndex = 4;
            this.mailListlbl.Text = "0/0";
            // 
            // mailBox
            // 
            this.mailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mailBox.Controls.Add(this.label5);
            this.mailBox.Controls.Add(this.label7);
            this.mailBox.Controls.Add(this.textBox2);
            this.mailBox.Controls.Add(this.label6);
            this.mailBox.Controls.Add(this.button2);
            this.mailBox.Controls.Add(this.textBox3);
            this.mailBox.Controls.Add(this.button1);
            this.mailBox.Controls.Add(this.mailListlbl);
            this.mailBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.mailBox.Location = new System.Drawing.Point(891, 423);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(441, 403);
            this.mailBox.TabIndex = 15;
            this.mailBox.Visible = false;
            this.mailBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseDown);
            this.mailBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseMove);
            this.mailBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseUp);
            this.mailBox.Resize += new System.EventHandler(this.mailBox_Resize);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(184, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "П о ч т а";
            // 
            // mapBox
            // 
            this.mapBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapBox.Controls.Add(this.labelmap);
            this.mapBox.Controls.Add(this.Map);
            this.mapBox.ForeColor = System.Drawing.Color.Cyan;
            this.mapBox.Location = new System.Drawing.Point(12, 10);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(621, 335);
            this.mapBox.TabIndex = 16;
            this.mapBox.Visible = false;
            this.mapBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseDown);
            this.mapBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseMove);
            this.mapBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseUp);
            this.mapBox.Resize += new System.EventHandler(this.mapBox_Resize);
            // 
            // labelmap
            // 
            this.labelmap.AutoSize = true;
            this.labelmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelmap.Location = new System.Drawing.Point(3, 0);
            this.labelmap.Name = "labelmap";
            this.labelmap.Size = new System.Drawing.Size(48, 15);
            this.labelmap.TabIndex = 9;
            this.labelmap.Text = "Карта";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(793, 676);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GameMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1370, 887);
            this.ControlBox = false;
            this.Controls.Add(this.ConsoleBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameMain";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.Text = "}{akep 3.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ConsoleBox.ResumeLayout(false);
            this.ConsoleBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mailBox.ResumeLayout(false);
            this.mailBox.PerformLayout();
            this.mapBox.ResumeLayout(false);
            this.mapBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConsoleInput;
        private System.Windows.Forms.Panel Map;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ListFilePlayer;
        private System.Windows.Forms.TextBox ConsoleTxt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label mailListlbl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel mailBox;
        private System.Windows.Forms.Panel mapBox;
        private System.Windows.Forms.Label labelmap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel ConsoleBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
    }
}

