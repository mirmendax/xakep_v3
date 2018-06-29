using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libgame
{
    [Serializable]
    public partial class BForceElement : UserControl
    {
        public delegate void OnEnd(bool b, int sec);
        public event OnEnd onEnd;
        public delegate void OnCancel();
        public event OnCancel onCancel;
        public string pass = string.Empty;
        public string symbols = "11234567890aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ!#@&*%$";
        int countchars = 0;
        int countpass = 0;
        Label[] chars;
        int MAX_TIME_OPERATION = 0;
        int time = 0;

        public BForceElement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор класа брутофорсинга
        /// </summary>
        /// <param name="_pass">пароль</param>
        /// <param name="maxtime">максимальное время до обнаружения</param>
        /// <param name="speed">скорость поиска эелемента(от 50 до 150)</param>
        public BForceElement(string _pass, int maxtime, int speed)
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(_pass))
            {
                this.pass = _pass;
                MAX_TIME_OPERATION = maxtime;
                if (speed < 50)
                    speed = 50;
                if (speed > 150)
                    speed = 150;
                timer1.Interval = speed;
                
            }
            else
                this.pass = "1";
        }

        void Start()
        {
            foreach (Control c in Parent.Controls)
            {
                if (c != this)
                    c.Visible = false;
            }
            button1.Enabled = true;
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        void Stop()
        {
            foreach (Control c in Parent.Controls)
                c.Visible = true;
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void CheckChars(char a)
        {
            chars[countpass].Text = a.ToString();
            
            if (pass[countpass] == a)
            {
                countpass++;
                countchars = 0;
                progressBar1.Value = countpass;
                if (countpass == pass.Length)
                {

                    Stop();
                    onEnd(true, MAX_TIME_OPERATION - time);
                    Dispose();
                }
            }


        }

        private void BForceElement_Load(object sender, EventArgs e)
        {
            chars = new Label[pass.Length];
            Point n = new Point();
            n.X = (int)(Parent.Width / 2) - this.Width / 2;
            n.Y = (Parent.Height / 2) - this.Height / 2;
            Location = n;
            for (int i = 0; i < pass.Length; i++)
            {
                chars[i] = new Label();
                chars[i].Text = "*";
                Font f = new Font(new FontFamily("Microsoft Sans Serif"), 10.0f, FontStyle.Bold);
                chars[i].ForeColor = Color.Red;
                chars[i].Font = f;
                chars[i].AutoSize = true;
                progressBar1.Maximum = pass.Length;
                progressBar2.Maximum = symbols.Length;
                panel.Controls.Add(chars[i]);
            }
            Start();
            time = MAX_TIME_OPERATION;
            label2.Text = "Time left: " + time.ToString() + " sec";
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = true;
            CheckChars(symbols[countchars]);
            countchars++;
            if (countchars == symbols.Length)
            {
                countchars = 0;
            }
            label3.Text = string.Format("Ост. : {0} из {1} символов", (pass.Length - countpass).ToString(), pass.Length);
            progressBar2.Value = countchars;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time--;
            label2.Text = "Time left: " + time.ToString() + " sec";
            if (time < 5)
            {
                label2.ForeColor = Color.Red;
            }
            if (time <= 0)
            {
                Stop();
                onEnd(false, 0);
                Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stop();
            onCancel();
            this.Dispose();
        }
    }
}
