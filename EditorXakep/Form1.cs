using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libgame;

namespace EditorXakep
{
    public partial class Form1 : Form
    {
        public GameScript Scenario = new GameScript();
        public List<FileX> Files = new List<FileX>();
        public Form1()
        {
            InitializeComponent();
        }

        void ReDrawFile()
        {
            Fileslist.Items.Clear();
            
            foreach (var file in Files)
            {
                string s = string.Format("{0} \t{1}\t{2}", file.Name, file.Type.ToString(), file.Capacity);
                Fileslist.Items.Add(s);
            }

        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tabFile":
                    {
                        ReDrawFile();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
