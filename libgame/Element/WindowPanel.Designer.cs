namespace libgame.Element
{
    partial class WindowPanel
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
            this.Main = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.AutoSize = true;
            this.Main.Location = new System.Drawing.Point(3, 22);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(692, 362);
            this.Main.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.ForeColor = System.Drawing.Color.Aquamarine;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(40, 15);
            this.Title.TabIndex = 1;
            this.Title.Text = "Окно";
            // 
            // Close
            // 
            this.Close.AutoSize = true;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.ForeColor = System.Drawing.Color.Aquamarine;
            this.Close.Location = new System.Drawing.Point(677, 2);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(18, 17);
            this.Close.TabIndex = 2;
            this.Close.Text = "X";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // WindowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Main);
            this.Name = "WindowPanel";
            this.Size = new System.Drawing.Size(698, 387);
            this.VisibleChanged += new System.EventHandler(this.WindowPanel_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Close;
    }
}
