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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Media.Animation;

namespace Xakep_v3
{
    public partial class GameMain : Form
    {
        //Int32Animation s
        #region Перенос окон
        bool isDown = false;

        Point MouseLocation = new Point();
        #endregion
        GameScript Game = new GameScript();
        #region Last Command
        List<string> lastcommand = new List<string>();
        
        int CountSelectCommand = 0;
        #endregion
        ListComp listComputer = new ListComp();
        int currentMail = 0;
        int TimeofEnd = 0;
        public GameMain()
        {

            InitializeComponent();
            this.Visible = false;
            
            EnemyComp.OnChanged += EnemyComp_onChanged;
            Player.GameOver += Player_GameOver;
        }

        void Player_GameOver()
        {
            DialogResult result = MessageBox.Show("Игра закончена! Хотите начать занаво?", "Проиграл", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No) 
                Application.Exit();
            else
            {
                Game = new GameScript();
                this.Controls.Clear();
                InitializeComponent();
                Scenarion();
                ReDrawMap();
                ReDrawComputer();
            }
        }



        void EnemyComp_onChanged(EnemyComp handleComp, ChangedBitEnemy flag)
        {
            switch (flag)
            {
                case ChangedBitEnemy.Visibled: ReDrawMap();
                    break;
                default: break;
            }
        }

        public void ReDrawMap()
        {
            Map.Controls.Clear();
            foreach (EnemyComp enC in Game.ListEnemy)
            {
                if (enC.isVisible)
                    Map.Controls.Add(enC.Label);
            }
            Map.Controls.Add(Game.player.Computer.Icon);
        }

        public void ReDrawComputer()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(Game.player.Computer.mboard.ToString());
            foreach (RAM c in Game.player.Computer.ram)
                if (c.name != string.Empty)
                    listBox1.Items.Add(c);
            foreach (CPU c in Game.player.Computer.cpu)
                if (c.name != string.Empty)
                listBox1.Items.Add(c);
            foreach (Hard c in Game.player.Computer.hdd)
                if (c.name != string.Empty)
                listBox1.Items.Add(c);
            listBox1.Items.Add("Lan: "+Game.player.Computer.lan);
            label3.Text = string.Format("HDD: {0}/{1} Free: {2} Mb", Game.player.Computer.CapacityFiles,
                Game.player.Computer.CapacityHDD, (Game.player.Computer.CapacityHDD - Game.player.Computer.CapacityFiles));
            ListFilePlayer.Items.Clear();
            foreach (FileX file in Game.player.Computer.FileList)
            {
                if (file.Type != FileXType.OSPROGRAM)
                    ListFilePlayer.Items.Add(string.Format("{0} \t {1} Mb",file.Name, file.Capacity));

            }
        }

        public void ReDrawMail()
        {
            if (Game.player.ListMail.Count > 0)
            {
                mailListlbl.Text = (currentMail+1).ToString() + "/" + Game.player.ListMail.Count.ToString();
                textBox2.Text = Game.player.ListMail[currentMail].Name;
                textBox3.Lines = Game.player.ListMail[currentMail].Body.ToArray<string>();
            }
            else
            {
                mailListlbl.Text = "0/0";
            }
        }
       

#pragma warning disable IDE1006 // Стили именования
        private void button1_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            currentMail++;
            if (currentMail >= Game.player.ListMail.Count)
                currentMail = Game.player.ListMail.Count-1;
            ReDrawMail();
            ConsoleInput.Focus();
        }

#pragma warning disable IDE1006 // Стили именования
        private void button2_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            currentMail--;
            if (currentMail < 0)
                currentMail = 0;
            ReDrawMail();
            ConsoleInput.Focus();
        }

#pragma warning disable IDE1006 // Стили именования
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            try
            {
                
                if (!string.IsNullOrWhiteSpace(ConsoleInput.Text))
                {

                    if (e.KeyCode == Keys.Enter)
                    {
                        AddToLog(">" + ConsoleInput.Text);
                        if (ConsoleInput.Text[0] == ' ') ConsoleInput.Text = ConsoleInput.Text.Remove(0, 1);
                        string[] comnum = ConsoleInput.Text.Split(new Char[] { '|' });
                        if (comnum.Length == 1)
                        {

                            string[] comm = ConsoleInput.Text.Split(new Char[] { ' ' });
                            ResponseData response = new ResponseData();
                            Action<IFileX> command = delegate(IFileX file)
                            {
                                ResponseData re = file.Run(Game, comm);
                                if (re.Data.Count > 0) response = re;
                            };
                            Game.player.Computer.FileList.ForEach(command);
                            Response(response);
                            lastcommand.Add(ConsoleInput.Text);
                            CountSelectCommand = lastcommand.Count;
                            ConsoleInput.Text = "";
                        }
                        else
                        {
                            foreach (var com1 in comnum)
                            {
                                string com = com1;
                                if (com[0] == ' ') com = com.Remove(0, 1);
                                string[] comm = com.Split(new Char[] { ' ' });

                                ResponseData response = new ResponseData();
                                Action<IFileX> command = delegate(IFileX file)
                                {
                                    ResponseData re = file.Run(Game, comm);
                                    if (re.Data.Count > 0) response = re;
                                };
                                Game.player.Computer.FileList.ForEach(command);
                                Response(response);
                                lastcommand.Add(ConsoleInput.Text);
                                CountSelectCommand = lastcommand.Count;
                                ConsoleInput.Text = "";
                            }
                        }
                    }


                }

                if (e.KeyCode == Keys.Up)
                {
                    CountSelectCommand--;
                    if (CountSelectCommand >= 0)
                        ConsoleInput.Text = lastcommand[CountSelectCommand];
                    else CountSelectCommand++;
                    ConsoleInput.Text += " ";
                    ConsoleInput.SelectionStart = ConsoleInput.TextLength;
                    
                }
                if (e.KeyCode == Keys.Down)
                {
                    CountSelectCommand++;
                    if (CountSelectCommand < lastcommand.Count)
                        ConsoleInput.Text = lastcommand[CountSelectCommand];
                    else CountSelectCommand--;
                    ConsoleInput.Text += " ";
                    ConsoleInput.SelectionStart = ConsoleInput.TextLength;
                }
            }
            catch (Exception ex) { LOG.Error(ex.Message); }
        }

#pragma warning disable IDE1006 // Стили именования
        public void isConnEnemy(string addr, bool isConn)
#pragma warning restore IDE1006 // Стили именования
        {
            IEnumerable<EnemyComp> s = from cc in Game.ListEnemy
                                       where cc.Addr == addr
                                       select cc;
            EnemyComp en = s.ElementAt<EnemyComp>(0);
            if (isConn)
            {
                en.Label.label1.ForeColor = Color.Gold;
                
            }
            else
            {
                en.Label.label1.ForeColor = Color.Red;
            }
        }

#pragma warning disable IDE1006 // Стили именования
        private void timer1_Tick(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            //try
            {
                TimeofEnd++;
                if (Game.player.isConnected)
                {
                    label4.Text = Game.player.ConnectedEnemy.Addr + ">";
                    ConsoleBox.Enabled = false;
                }
                else
                {
                    label4.Text = "localhost>";
                    ConsoleBox.Enabled = true;
                }

                Action<IQuest> chQuest = delegate(IQuest q)
                {
                    q.CheckedComplete(Game);
                };
                Game.Questions.ForEach(chQuest);

                listBox3.Items.Clear();
                foreach (Quest q in Game.Questions)
                {
                    string compl = (q.Complete) ? " Успешно" : " ";
                    listBox3.Items.Add(q.Name + compl);
                }
                var ComplGame = from q in Game.Questions
                                where q.Complete == false
                                select q;
                if (ComplGame.Count() == 0)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Вы прошли уровень за "+TimeofEnd.ToString()+" сек");
                    Application.Exit();
                }
                Action<IEventX> cheven = delegate(IEventX ev)
                {
                    ResponseData r = new ResponseData();
                    r = ev.CheckedEvent(Game);
                    if (r.Data.Count > 0) Response(r);
                };

                Game.EventList.ForEach(cheven);


                label2.Text = "Розыск: " + Game.player.Wanted.ToString();
                label1.Text = "Деньги: " + Game.player.Money.ToString();
            }
           // catch (Exception ex) { LOG.Error(ex.Message); }
        }

        public void SizeFormOnStart()
        {
            
            this.Visible = false;
            int screenX, screenY;
            screenX = this.Size.Width;
            screenY = this.Size.Height;
            Size gb1, gb2, gb3/*, gb4*/;
            gb1 = new Size();
            gb2 = new Size();
#pragma warning disable IDE0017 // Упростите инициализацию объекта
            gb3 = new Size();
#pragma warning restore IDE0017 // Упростите инициализацию объекта
                               //gb4 = new System.Drawing.Size();
                               //Size
                               //===Map

            gb3.Width = (int)(screenX * 0.6f);
            gb3.Height = (int)(screenY * 0.53f);
            //===Console
            gb2.Width = (int)(screenX * 0.4f);
            gb2.Height = (int)(screenY * 0.51f);
            //==Mail
            //gb4.Width = (int)(screenX * 0.385f);
            //gb4.Height = (int)(screenY * 0.43f);
            //===Computer
            gb1.Width = (int)(screenX * 0.37f);
            gb1.Height = (int)(screenY * 0.51f);
            //Location
            Point Lgb2, Lgb3, Lgb4;
            //Map
            //int x1, y1 = 0;
            Random re = new Random();

            Lgb3 = new Point(re.Next(0, screenX-gb3.Width), re.Next(0, screenY-gb3.Height));
            //Console
            //Lgb2 = new Point(0, gb3.Height + 1);
            Lgb2 = new Point(0, 0);
            //Mail
            //Lgb4 = new Point(gb3.Width + 1, -1);
            Lgb4 = new Point(screenX-mailBox.Size.Width-2, 0);
            //Computer
            //Lgb1 = new Point(gb2.Width + 1, gb4.Height + 1);
            //Init
            //groupBox1.Location = Lgb1;
            //groupBox1.Size = gb1;
            ConsoleBox.Location = Lgb2;
            ConsoleBox.Size = gb2;
            mapBox.Location = Lgb3;
            mapBox.Size = gb3;
            mailBox.Location = Lgb4;
            //mailBox.Size = gb4;

            this.Visible = true;
            RePoint r = new RePoint(Map.Size.Width, Map.Size.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReDrawMap();
            ReDrawComputer();
            SizeFormOnStart();
            Scenarion();
        }

#pragma warning disable IDE1006 // Стили именования
        private void groupBox2_Resize(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            ConsoleTxt.Size = new Size(ConsoleBox.Size.Width - 10, (int)((ConsoleBox.Size.Height *0.75)));
        }


#pragma warning disable IDE1006 // Стили именования
        private void button3_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            Application.Exit();
        }


#pragma warning disable IDE1006 // Стили именования
        private void mailBox_Resize(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            textBox2.Size = new Size((int)(mailBox.Size.Width * 0.81f), 17);
            textBox3.Size = new Size((int)(mailBox.Size.Width * 0.95f), (int)(mailBox.Size.Height * 0.57f));
            button2.Location = new Point(9, textBox3.Location.Y + textBox3.Size.Height + 5);
            mailListlbl.Location = new Point(168, button2.Location.Y + 4);
            button1.Location = new Point(297, textBox3.Location.Y + textBox3.Size.Height + 5);
        }

#pragma warning disable IDE1006 // Стили именования
        private void mapBox_Resize(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            Map.Size = new Size((int)(mapBox.Size.Width * 0.99f), (int)(mapBox.Size.Height * 0.90f));
            Map.Location = new Point(1, labelmap.Location.Y + labelmap.Size.Height + 2);
        }
        #region New Location
#pragma warning disable IDE1006 // Стили именования
        private void mapBox_MouseDown(object sender, MouseEventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            isDown = true;
            MouseLocation = e.Location;
        }

#pragma warning disable IDE1006 // Стили именования
        private void mapBox_MouseUp(object sender, MouseEventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            isDown = false;
            ConsoleInput.Focus();
        }

#pragma warning disable IDE1006 // Стили именования
        private void mapBox_MouseMove(object sender, MouseEventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            if (isDown)
            {
                Control c = sender as Control;

                Point t = this.PointToClient(Control.MousePosition);
                Point nt = new Point(t.X - MouseLocation.X, t.Y - MouseLocation.Y);
                c.Location = nt;
                c.BringToFront();
            }
        }
        #endregion

#pragma warning disable IDE1006 // Стили именования
        private void button4_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            libgame.Element.PlayerFiles pl = new libgame.Element.PlayerFiles();
            libgame.Element.WindowPanel p = new libgame.Element.WindowPanel(pl.Width, pl.Height, pl, "sdsd");
            this.Controls.Add(p);
        }

        



    }
}
