using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libgame;
using System.Timers;

namespace Xakep_v3
{
    partial class GameMain
    {
        List<string> LOG_DATA = new List<string>();
        Timer timeofrun = new Timer();
        const int MAX_RUN_TIME = 15000;
        const float MAX_SPEED_RUN = 5.0f;
       
        public void Response(ResponseData data)
        {
            
            switch (data.Head)
            {
                case "scan":
                    {
                        #region Scan
                        bool isOk = (bool)data.Data[0];
                        if (isOk)
                        {
                            string[] ss = data.Data[1] as string[];
                            foreach (string s in ss)
                            {
                                if (!string.IsNullOrWhiteSpace(s))
                                    AddToLog(s);
                            }
                        }
                        else
                        {
                            string ss = data.Data[1] as string;
                            AddToLog(ss);
                        }
                        #endregion
                        break; 
                }
                case "more":
                    {
                        #region Open
                        try
                        {
                            bool isOk = (bool)data.Data[0];

                            if (isOk)
                            {
                                string[] ss = data.Data[1] as string[];
                                
                                foreach (var item in ss)
                                {
                                    AddToLog(item);
                                }
                                AddToLog("==============Конец==============");
                            }
                            else
                            {
                                string s = data.Data[1] as string;
                                AddToLog(s);
                            }
                                
                                
                            
                            
                        }
                        catch { AddToLog("Ошибка открытия"); }
                            
                        #endregion
                        break; 
                }
                case "ls":
                    {
                        #region ListFiles
                        try
                        {
                            if (data.Data.Count == 1)
                            {
                                AddToLog(data.Data[0]);
                            }
                            else
                            {
                                AddToLog(data.Data[0]);
                                string[] ss = data.Data[1] as string[];
                                foreach (string s in ss)
                                {
                                    if (!string.IsNullOrWhiteSpace(s))
                                        AddToLog(s);
                                }
                            }
                        }
                        catch
                        {
                            AddToLog("Ошибка загрузки списка.");
                        }
                        #endregion
                        break;
                    }
                case "connect":
                    {
                        #region Connect
                        //try
                        //{

                            bool isOk = (bool)(data.Data[0]);
                            if (!Game.player.isConnected)
                                if (isOk)
                                {
                                    EnemyComp en = data.Data[1] as EnemyComp;
                                    //ServiceX servX = data.Data[2] as ServiceX;
                                    if (en != null)
                                    {
                                        Game.player.ConnectedEnemy = en;
                                        Game.player.isConnected = true;
                                        EnemyCompInterface eci = new EnemyCompInterface(Game.player.Computer.FileList, en, (int)Game.player.Computer.SpeedLan);
                                        libgame.Element.WindowPanel p = new libgame.Element.WindowPanel(eci.Width, eci.Height, eci, en.Addr);
                                        eci.onReWanted += delegate(int r)
                                        {
                                            Game.player.Wanted -= r;
                                        };
                                        eci.onLogout += delegate()
                                        {
                                            ResponseData d = new ResponseData("logout");
                                            d.Data.Add(true);
                                            Response(d);
                                            this.Controls.Remove(p);
                                            isConnEnemy(en.Addr, false);
                                        };
                                        eci.onDownload += delegate(FileX file)
                                        {
                                            bool ok = false;
                                            int freehdd = Game.player.Computer.CapacityHDD - Game.player.Computer.CapacityFiles;
                                            if (freehdd >= file.Capacity)
                                            {
                                                Game.player.Computer.FileList.Add(file);
                                                ReDrawComputer();
                                                ok = true;
                                            }
											//if (!offFirewall) Game.player.Wanted += 5;
                                            return ok;
                                        };
                                        eci.onUpload += delegate(EnemyComp comp, ServiceX servX, FileX file)
                                        {
                                            foreach (EnemyComp eComp in Game.ListEnemy)
                                            {
                                                if (eComp.Addr == comp.Addr)
                                                {
                                                    int i = eComp.Services.IndexOf(servX);
                                                    eComp.Services[i].ListFile.Add(file);
                                                    break;
                                                }
                                            }
											//if (!offFirewall) Game.player.Wanted += 5;
                                        };
                                        eci.onCash += delegate(int money)
                                        {
                                            int i = Game.ListEnemy.IndexOf(en);
                                            Game.player.Money += money;
                                            Game.player.Wanted += Constance.WantedOfMoney(money);
                                        };
                                        isConnEnemy(en.Addr, true);
                                        p.MouseMove += mapBox_MouseMove;
                                        p.MouseUp += mapBox_MouseUp;
                                        p.MouseDown += mapBox_MouseDown;
                                        p.Location = new System.Drawing.Point(34, 124);
                                        this.Controls.Add(p);
                                        AddToLog("Вы подключились к " + en.Addr);
                                    }


                                }
                                else
                                {
                                    string ss = data.Data[1].ToString();
                                    AddToLog(ss);
                                }
                            else
                            {
                                AddToLog("Вы уже подключены к " + Game.player.ConnectedEnemy.Addr);
                            }
                        //}
                        //catch
                        //{
                         //   AddToLog("Ошибка подключения.");
                        //}
                        #endregion
                        break;
                    }
                case "login":
                    {
                        #region Login
                        AddToLog(data.Data[1].ToString());
                        #endregion
                        break;
                    }

                case "logout":
                    {
                        #region Logout
                        try
                        {
                            bool isOk = (bool)data.Data[0];
                            if (isOk)
                            {
                                AddToLog("Отключение от " + Game.player.ConnectedEnemy.Addr);
                                Game.player.isConnected = false;
                                Game.player.ConnectedEnemy = null;
                                Game.player.ConnectSSH = null;
                            }
                            else
                                AddToLog(data.Data[1].ToString());
                        }
                        catch { AddToLog("Ошибка logout"); }
                        #endregion
                        break;
                    }
                case "crack":
                    {
                        #region Crack
                        try
                        {
                            bool isOk = (bool)data.Data[0];
                            if (isOk)
                            {
                                EnemyComp enComp = data.Data[1] as EnemyComp;
                                ServiceX enService = data.Data[2] as ServiceX;
                                if (enComp != null)
                                {
                                    int speed = (int)data.speedOperation * 10;
                                    BForceElement crack = new BForceElement(enService.Pass, enService.Pass.Length * 4, speed);
                                    libgame.Element.WindowPanel p = new libgame.Element.WindowPanel(crack.Width, crack.Height, crack, "Crack [" + enComp.Addr + "]");

                                    crack.onEnd += delegate(bool b, int time)
                                    {
                                        int i = Game.ListEnemy.IndexOf(enComp);
                                        int t = Game.ListEnemy[i].Services.IndexOf(enService);
                                        if (b)
                                        {
                                            Game.player.Wanted += 10;

                                            enService.Parrent.isScaning = true;
                                            Game.ListEnemy[i].Services[t].isHackPass = true;
                                            Game.ListEnemy[i].reWanted = 5;
                                            AddToLog("Пароль подобран ["+enService.Pass+"] за " + time + " сек");
                                        }
                                        else
                                        {
                                            Game.player.Wanted += 45;
                                            Game.ListEnemy[i].reWanted = 22;
                                            AddToLog("Неудачно! Время вышло");

                                        }
                                        this.Controls.Remove(p);
                                    };
                                    crack.onCancel += delegate
                                    {
                                        this.Controls.Remove(p);
                                        AddToLog("Отмена операции подбора пороля");
                                    };
                                    p.MouseMove += mapBox_MouseMove;
                                    p.MouseUp += mapBox_MouseUp;
                                    p.MouseDown += mapBox_MouseDown;
                                    p.Location = new System.Drawing.Point(34, 124);
                                    this.Controls.Add(p);
                                    //p.BringToFront();
                                    AddToLog("Подбор пароля...");
                                }
                            }
                            else
                            {
                                string ss = data.Data[1].ToString();
                                AddToLog(ss);
                            }
                        }
                        catch { AddToLog("Ошибка взлома"); }
                        #endregion
                        break;
                    }
                case "exploit":
                    {
                        #region Exploit
                        try
                        {
                            AddToLog("Запуск эксплойта...");
                            bool isOk = (bool)data.Data[0];
                            if (isOk)
                            {
                                EnemyComp enc = (EnemyComp)data.Data[1];
                                EnemyComp ennew = (EnemyComp)data.Data[2];
                                foreach (var enemy in Game.ListEnemy)
                                {
                                    if (enemy.Addr == enc.Addr)
                                    {
                                        Game.ListEnemy.Remove(enemy);
                                        Game.AddEnemy(ennew);
                                        break;
                                    }
                                }
                                AddToLog(data.Data[3].ToString());
                                
                                
                                /*
                                foreach (var ee in Game.ListEnemy)
                                {
                                    if (ee.Addr == enc.Addr)
                                    {
                                        ServiceX sX = ee.PortToService((int)data.Data[2]);
                                        if (sX != null)
                                        {
                                            sX.isDecrypt = true;
                                            sX.isHackPass = true;
                                            AddToLog("Защиты " + ee.Addr + ":" + sX.Port.ToString() + " полностью отключены с помощью эксплойта.");
                                        }
                                    }
                                }
                                 */
                            }
                            else
                            {
                                AddToLog("Ошибка выполнения эксплойта.");
                                AddToLog(data.Data[1]);
                            }
                        }
                        catch
                        {
                            AddToLog("Ошибка эксплойта.");
                        }
                        #endregion
                        break;
                    }
                case "ssh":
                    {
                        #region SSH
                        try
                        {
                            bool isOk = (bool)data.Data[0];
                            if (isOk)
                            {
                                Game.player.isConnected = true;
                                EnemyComp e = data.Data[1] as EnemyComp;
                                ServiceX s = data.Data[2] as ServiceX;
                                Game.player.ConnectedEnemy = e;
                                Game.player.ConnectSSH = s;
                                AddToLog(string.Format("Вы подключилсь к {0} по SSH", e.Addr));
                                AddToLog(string.Format("Для отключения FireWall и выхода напишите: firewall stop | logout"));
                                //ServiceX sF = e.PortToService(324);
                                //sF.isRun = false;
                            }
                            else
                            {
                                AddToLog(data.Data[1].ToString());
                            }
                        }
                        catch { }
                        #endregion
                        break;
                    }
                case "sshCom":
                    {
                        #region SSH Command
                        bool isOk = (bool)data.Data[0];
                        if (isOk)
                        {
                            switch (data.Data[1].ToString())
                            {
                                case "F_STOP":
                                    {
                                        int i = Game.ListEnemy.IndexOf(Game.player.ConnectedEnemy);
                                        
                                        int d = Game.ListEnemy[i].Services.IndexOf((data.Data[2] as ServiceX));
                                        Game.ListEnemy[i].Services[d].isRun = false;
                                        AddToLog("Firewall отключен");
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            AddToLog(data.Data[1].ToString());
                        }
                        #endregion
                        break;
                    }
                case "event":
                    {
                        #region Event
                        if ((bool)data.Data[0])
                        {
                            this.ReDrawMap();
                            this.ReDrawComputer();
                              
                            currentMail = Game.player.ListMail.Count - 1;
                            this.ReDrawMail();
                        }
                        #endregion
                        break;
                    }
                case "nmap":
                    {
                        bool isOk = (bool)data.Data[0];
                        if (isOk)
                        {
                            mapBox.Visible = true;
                            mapBox.BringToFront();
                            ReDrawMap();
                            System.Windows.Forms.MessageBox.Show(Game.ListEnemy.Count.ToString());
                            AddToLog("Открытие и обновление карты.");
                        }
                        break;
                    }
                case "mail":
                    {
                        bool isOk = (bool)data.Data[0];
                        if (isOk)
                        {
                            mailBox.Visible = true;
                            mailBox.BringToFront();
                            AddToLog("Открытие и обновление почты.");
                        }
                        break;
                    }
                case "killtrace":
                    {
                        AddToLog(data.Data[1].ToString());
                        break;
                    }

                default:
                    {
                        
                        AddToLog("Неизвестная комманда");
                        break;
                    }
            }
            
        }

        private void AddToLog(object s)
        {
            if (s != null)
                LOG_DATA.Add(s.ToString());

            ConsoleTxt.Lines = LOG_DATA.ToArray();
            ConsoleTxt.SelectionStart = ConsoleTxt.TextLength;
            ConsoleTxt.ScrollToCaret();
            

        }
       
    }
}
