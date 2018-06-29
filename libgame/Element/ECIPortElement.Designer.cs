namespace libgame.Element
{
    partial class ECIPortElement
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
            this.portlbl = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // portlbl
            // 
            this.portlbl.AutoSize = true;
            this.portlbl.ContextMenuStrip = this.contextMenuStrip1;
            this.portlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portlbl.ForeColor = System.Drawing.Color.Yellow;
            this.portlbl.Location = new System.Drawing.Point(143, 0);
            this.portlbl.Name = "portlbl";
            this.portlbl.Size = new System.Drawing.Size(17, 17);
            this.portlbl.TabIndex = 8;
            this.portlbl.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStart,
            this.menuStop,
            this.menuRestart});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 92);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // menuStart
            // 
            this.menuStart.BackColor = System.Drawing.Color.DimGray;
            this.menuStart.ForeColor = System.Drawing.Color.LimeGreen;
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(127, 22);
            this.menuStart.Text = "Запуск";
            // 
            // menuStop
            // 
            this.menuStop.BackColor = System.Drawing.Color.DarkGray;
            this.menuStop.ForeColor = System.Drawing.Color.Red;
            this.menuStop.Name = "menuStop";
            this.menuStop.Size = new System.Drawing.Size(127, 22);
            this.menuStop.Text = "Останов";
            // 
            // menuRestart
            // 
            this.menuRestart.BackColor = System.Drawing.Color.DimGray;
            this.menuRestart.ForeColor = System.Drawing.Color.Aqua;
            this.menuRestart.Name = "menuRestart";
            this.menuRestart.Size = new System.Drawing.Size(127, 22);
            this.menuRestart.Text = "Перезапуск";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ContextMenuStrip = this.contextMenuStrip1;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Открытый порт: ";
            // 
            // ECIPortElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.portlbl);
            this.Controls.Add(this.label4);
            this.Name = "ECIPortElement";
            this.Size = new System.Drawing.Size(163, 24);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label portlbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripMenuItem menuStop;
        private System.Windows.Forms.ToolStripMenuItem menuRestart;
    }
}
