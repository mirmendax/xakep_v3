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
    
    public partial class ECIPortElement : UserControl
    {
        public delegate void onChangeState(ServiceX serv, byte state);
        /// <summary>
        /// 1 - Start, 2 - Stop, 3 - Restart
        /// </summary>
        public event onChangeState ChangedState;
        ServiceX service;

        public ECIPortElement()
        {
            InitializeComponent();
        }

        public ECIPortElement(ServiceX serv)
        {
            InitializeComponent();
            this.service = serv;
            portlbl.Text = serv.Port.ToString();
            if (service.isRun)
                portlbl.ForeColor = Color.Yellow;
            else
                portlbl.ForeColor = Color.Red;
            if (service.Desc != "") label4.Text = service.Desc;
            service.Change += delegate
            {
                if (service.isRun)
                {
                    portlbl.ForeColor = Color.Yellow;
                }
                else
                {
                    portlbl.ForeColor = Color.Red;
                }
            };
        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "menuStart":
                        {
                            if (service.isHackPass && service.isDecrypt)
                                ChangedState(service, 1);
                            break;
                        }
                    case "menuStop":
                        {
                            if (service.isHackPass && service.isDecrypt)
                                ChangedState(service, 2);
                            break;
                        }
                    case "menuRestart":
                        {
                            if (service.isHackPass && service.isDecrypt)
                                ChangedState(service, 3);
                            break;
                        }
                }
            }
            catch { }
        }
    }
}
