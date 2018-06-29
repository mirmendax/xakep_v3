using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libgame.Element
{
    public partial class WindowPanel : UserControl
    {
        
        delegate void CloseWin();
        event CloseWin OnClose;

        public WindowPanel()
        {
            InitializeComponent();
        }

        public WindowPanel(int width, int height, Control main, string title, bool enableClose = false)
        {
            InitializeComponent();
            if (!enableClose) Close.Visible = false;
            else Close.Visible = true;
            this.Visible = false;
            Main.Size = new Size(width, height);
            Main.Location = new Point(1, Title.Size.Height + 2);
            Main.Controls.Add(main);
            //BringToFront();
            Title.Text = title;
            this.Visible = true;
        }

        private void WindowPanel_VisibleChanged(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (OnClose != null)
            {
                this.OnClose();
            }
        }


      
    }
}
