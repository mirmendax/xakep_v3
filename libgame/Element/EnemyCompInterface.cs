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
    public partial class EnemyCompInterface : UserControl
    {
        //public List<ServiceX> ServXList = new List<ServiceX>();
        public EnemyComp ThisComp = new EnemyComp();
        List<FileX> listFilePlayer = new List<FileX>();
        int _speed = 0;
        FileX tempFile = new FileX();
        bool isUpload = false;
        ServiceX SelectService = new ServiceX();
        

        public delegate bool OnDownload(FileX file);//OnDownload(FileX file, bool offFirewall)
        public delegate void OnLogout();
        public delegate void OnUpload(EnemyComp comp, ServiceX servX, FileX file);//OnUpload(EnemyComp comp, ServiceX servX, FileX file, bool offFirewall)
        public delegate void OnCash(int money);
        public delegate void OnReWanted(int wantedscore);
        


         public event OnDownload onDownload;
         public event OnLogout onLogout;
         public event OnUpload onUpload;
         public event OnCash onCash;
         public event OnReWanted onReWanted;
        public EnemyCompInterface()
        {
            InitializeComponent();
        }
        public EnemyCompInterface(List<FileX> flistPlayer,EnemyComp eC, int speed)
        {
            
            InitializeComponent();
            ThisComp = eC;
            EnemyComp.OnChanged += delegate
            {
                RefreshData();
            };
            listFilePlayer = flistPlayer;
            _speed = speed;
            SelectService = null;
        }

        void RefreshFileList()
        {
            listfiles.Items.Clear();
            if (SelectService != null)
            {
                foreach (var item in SelectService.ListFile)
                {
                    listfiles.Items.Add(item.Name + " \t" + item.Capacity + " Mb");
                }
            }
            listBox1.Items.Clear();
            foreach (FileX file in listFilePlayer)
            {
                if (file.Type != FileXType.OSPROGRAM)
                    listBox1.Items.Add(file.Name);
            }
        }

        void RefreshData()
        {
            addrlbl.Text = ThisComp.Addr;
            moneylbl.Text = ThisComp.Money.ToString();
            wantedlbl.Text = ThisComp.reWanted.ToString();
            layoutService.Controls.Clear();
            cBoxService.Items.Clear();
            foreach (ServiceX serV in ThisComp.Services)
            {
                cBoxService.Items.Add(string.Format("[{0}] - {1}", serV.Port, serV.Desc));
                Element.ECIPortElement se = new Element.ECIPortElement(serV);
                se.ChangedState += delegate(ServiceX serv, byte state)
                {
                    int i = ThisComp.Services.IndexOf(serv);
                    switch (state)
                    {
                        case 1: 
                            ThisComp.Services[i].Restart();
                            if (serv.Port == SelectService.Port)
                                SelectService = null;
                            break;
                        case 2: 
                            ThisComp.Services[i].Stop();
                            if (serv.Port == SelectService.Port)
                                SelectService = null;
                            break;
                        case 3: 
                            ThisComp.Services[i].Restart();
                            if (serv.Port == SelectService.Port)
                                SelectService = null;
                            break;
                        default: break;

                    }
                    RefreshData();
                };
                layoutService.Controls.Add(se);
            }
            RefreshFileList();
        }

        void Start()
        {
            foreach (Control c in Parent.Controls)
            {
                if (c != this)
                    c.Visible = false;
            }
            
        }

        void Stop()
        {
            foreach (Control c in Parent.Controls)
                c.Visible = true;
            downloadtimer.Enabled = false;
        }

        private void EnemyCompInterface_Load(object sender, EventArgs e)
        {
            Point n = new Point();
            n.X = (int)(Parent.Width / 2) - this.Width / 2;
            n.Y = (Parent.Height / 2) - this.Height / 2;
            Location = n;
            //this.Size = new Size(this.Size.Width, 376);
            progressBar1.Value = 0;
            RefreshData();
            Start();
        }

        private void downloadbtn_Click(object sender, EventArgs e)
        {
            int i = listfiles.SelectedIndex;
            if (i != -1)
            {
                if (SelectService != null)
                {
                    tempFile = SelectService.ListFile[i];
                    progressBar1.Maximum = tempFile.Capacity;
                    downloadtimer.Enabled = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value += _speed;
            }
            catch (ArgumentException ex)
            {
                downloadtimer.Enabled = false;
                progressBar1.Value = progressBar1.Maximum;
				//bool offFirewall = ThisComp.isOffFirewall
                try
                {
                    if (!onDownload(tempFile))//(!onDownload(tempFile, offFirewall))
                    {
                        MessageBox.Show("Не хватает места на жестком диске!");
                    }
                    
                }
                catch { }
                RefreshFileList();
                Console.WriteLine(ex);
            }
            
        }

        private void uplaodtimer_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value += _speed;
            }
            catch (ArgumentException ex)
            {
                uploadtimer.Enabled = false;
                isUpload = false;
                progressBar1.Value = progressBar1.Maximum;
				//bool offFirewall = ThisComp.isOffFirewall;
                try
                {
                    onUpload(ThisComp, SelectService, tempFile);//onUpload(ThisComp, SelectService, tempFile, offFirewall)
                }
                catch { }
                Console.WriteLine(ex);
                //ThisComp.ListFile.Add(tempFile);
                RefreshFileList();
            }
        }

        private void logoffbtn_Click(object sender, EventArgs e)
        {
            try
            {
                onLogout();
                SelectService = null;
            }
            catch { }
            Stop();
            Dispose();
        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            //this.Size = new Size(this.Size.Width, 480);
            if (SelectService != null)
            isUpload = true;
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpload)
            {
                ListBox lb = (ListBox)sender;
                if (lb.SelectedIndex != -1)
                {
                    string s = lb.Items[lb.SelectedIndex].ToString();
                    foreach (FileX file in listFilePlayer)
                    {
                        if (file.Name == s)
                        {
                            tempFile = file;
                            progressBar1.Maximum = file.Capacity;
                            progressBar1.Value = 0;
                            uploadtimer.Enabled = true;
                            listBox1.SelectedIndex = -1;
                            isUpload = false;
                        }
                    }
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            int i = listfiles.SelectedIndex;
            if (i != -1)
            {
                if (SelectService != null)
                {
                    SelectService.ListFile.Remove(SelectService.ListFile[i]);
                    RefreshFileList();
                }
            }
        }

        private void moneybtn_Click(object sender, EventArgs e)
        {
            if (ThisComp.IsAllHack && ThisComp.IsOffFirewall)
            {
                if (ThisComp.Money > 0)
                {
                    ThisComp.reWanted += (byte)(Constance.WantedOfMoney(ThisComp.Money) / 2);
                    onCash(ThisComp.Money);
                    ThisComp.Money = 0;
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Не все сервисы на данном компьютере взломаны или FireWall не отключен.");
            }
        }

        private void openbtn_Click(object sender, EventArgs e)
        {
            int i = listfiles.SelectedIndex;
            if (i != -1)
            {
                if (SelectService != null)
                {
                    textBox1.Lines = SelectService.ListFile[i].Body.ToArray();
                }
            }
        }

        private void cBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box != null)
            {
                int select = box.SelectedIndex;
                if (select != -1)
                {
                    if (ThisComp.Services[select].isDecrypt != false && ThisComp.Services[select].isHackPass != false &&
                        ThisComp.Services[select].isRun != false)
                        SelectService = ThisComp.Services[select];
                    else
                        MessageBox.Show("Этот сервис ещё не взломан или не запущен.");
                    RefreshFileList();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ThisComp.IsAllHack && ThisComp.IsOffFirewall)
            {
                if (ThisComp.reWanted > 0)
                {
                    onReWanted(ThisComp.reWanted);
                    ThisComp.reWanted = 0;
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Не все сервисы на данном компьютере взломаны или FireWall не отключен.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

    }
}
