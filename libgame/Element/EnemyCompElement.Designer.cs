﻿namespace Xakep_v3
{
    partial class EnemyCompElement
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
            this.label1 = new System.Windows.Forms.Label();
            this.AddrServ = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(-2, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.MouseEnter += new System.EventHandler(this.EnemyCompElement_DragEnter);
            this.label1.MouseLeave += new System.EventHandler(this.EnemyCompElement_DragLeave);
            // 
            // AddrServ
            // 
            this.AddrServ.AutoSize = true;
            this.AddrServ.BackColor = System.Drawing.Color.Transparent;
            this.AddrServ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddrServ.ForeColor = System.Drawing.Color.Transparent;
            this.AddrServ.Location = new System.Drawing.Point(-3, 18);
            this.AddrServ.Name = "AddrServ";
            this.AddrServ.Size = new System.Drawing.Size(51, 15);
            this.AddrServ.TabIndex = 1;
            this.AddrServ.Text = "addres";
            this.AddrServ.Visible = false;
            this.AddrServ.MouseEnter += new System.EventHandler(this.EnemyCompElement_DragEnter);
            this.AddrServ.MouseLeave += new System.EventHandler(this.EnemyCompElement_DragLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // EnemyCompElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddrServ);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "EnemyCompElement";
            this.Size = new System.Drawing.Size(51, 33);
            this.Load += new System.EventHandler(this.EnemyCompElement_Load);
            this.MouseEnter += new System.EventHandler(this.EnemyCompElement_DragEnter);
            this.MouseLeave += new System.EventHandler(this.EnemyCompElement_DragLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AddrServ;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}
