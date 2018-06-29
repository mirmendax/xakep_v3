using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakep_v3
{
    
    public partial class EnemyCompElement : UserControl
    {
        public string Addr = "";
        bool blink = true;

        public EnemyCompElement()
        {
            InitializeComponent();
            
        }

        private void EnemyCompElement_Load(object sender, EventArgs e)
        {
            AddrServ.Text = Addr;
            timer3.Enabled = true;
        }

        public void ServiceisOff()
        {
            timer1.Enabled = true;
        }

        public void ServiceisOn()
        {
            timer1.Enabled = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (blink)
                blink = false;
            else
                blink = true;
            label1.Enabled = blink;
        }

        private void EnemyCompElement_DragEnter(object sender, EventArgs e)
        {
            AddrServ.Visible = true;
            this.BringToFront();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            AddrServ.Visible = false;
            timer2.Enabled = false;
        }

        private void EnemyCompElement_DragLeave(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }
        float f = 0f;
        private void timer3_Tick(object sender, EventArgs e)
        {
            f += 0.5f;
            Font s = new Font(AddrServ.Font.FontFamily, f,FontStyle.Bold);
            label1.Font = s;
            if (f >= 12) timer3.Enabled = false;
        }
    }
}
