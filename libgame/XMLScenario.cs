using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace libgame
{

    public class E_Wanted
    {
        public string id = string.Empty;
        public int Wanted = 0;

        public E_Wanted(string id, int w)
        {
            this.id = id;
            this.Wanted = w;
        }
    }

    public class XMLScenario
    {
        public List<EnemyComp> X_Enemies = new List<EnemyComp>();
        public List<Quest> X_Quests = new List<Quest>();
        public List<EventGame> X_Event = new List<EventGame>();

        #region Event outs Ev_enemy, Ev_Mail, Ev_File, Ev_Wanted;
        List<EnemyComp> Ev_Enemy = new List<EnemyComp>();
        List<MailX> Ev_Mail = new List<MailX>();
        List<FileX> Ev_File = new List<FileX>();
        List<E_Wanted> Ev_Wanted = new List<E_Wanted>();
        #endregion

        public object FindEventOut(string id, out TypeOutEventX type)
        {
            object result = null;
            type = TypeOutEventX.None;
            foreach (EnemyComp e in Ev_Enemy)
            {
                if (e.id == id)
                {
                    type = TypeOutEventX.ENEMY;
                    return e;
                    
                }
            }
            foreach (MailX m in Ev_Mail)
            {
                if (m.ids == id)
                {
                    type = TypeOutEventX.MAIL;
                    return m;
                    
                }
            }
            foreach (FileX f in Ev_File)
            {
                if (f.id == id)
                {
                    type = TypeOutEventX.FILE;
                    return f;
                }
            }
            foreach (E_Wanted w in Ev_Wanted)
            {
                if (w.id == id)
                {
                    type = TypeOutEventX.WANTED;
                    return w;
                }
            }
            return result;
        }

        public FileX FindFileId(string id)
        {
            FileX result = null;
            foreach (EnemyComp e in X_Enemies)
            {
                foreach (ServiceX s in e.Services)
                {
                    foreach (FileX f in s.ListFile)
                    {
                        if (f.id == id)
                        {
                            return f;
                        }
                    }
                }
            }
            return result;
        }

        public ServiceX FindServiceId(string id)
        {
            ServiceX serv = null;
            foreach (EnemyComp e in X_Enemies)
            {
                foreach (ServiceX s in e.Services)
                {
                    if (s.id == id)
                    {
                        return s;
                    }
                }
            }
            return serv;
        }

        public Quest FindQuestId(string id)
        {
            Quest result = null;
            foreach (Quest e in X_Quests)
            {
                if (e.id == id)
                {
                    result = e;
                    break;
                }
            }
            return result;
        }

        public EnemyComp FindEnemyId(string id)
        {
            EnemyComp result = null;
            foreach (EnemyComp e in X_Enemies)
            {
                if (e.id == id)
                {
                    result = e;
                    break;
                }
            }
            return result;
        }

        

        public void ReadEvent(string path)
        {
            XDocument xDoc = XDocument.Load(path);
            GameScript game = new GameScript();
            foreach (XElement ev in xDoc.Root.Elements("outs"))
            {
                EventGame Event = new EventGame(TypeInEventX.None, TypeOutEventX.None);
                foreach (XElement file in ev.Element("files").Elements("file"))
                {
                    FileX f = null;
                    switch (file.Attribute("type").Value)
                    {
                        case "TXT": f = new FileTxtX();
                            break;
                        case "SCRIPT": f = new FileScriptX();
                            break;
                        case "EXPLOIT": f = new FileExploitX();
                            break;
                        case "DATA": f = new FileDataX();
                            break;
                        case "SSHKEY": f = new FileSSHKeyX();
                            break;
                        default: f = new FileX();
                            break;
                    }
                    f.id = file.Attribute("id").Value;
                    f.Capacity = int.Parse(file.Attribute("capacity").Value);
                    f.Name = file.Attribute("name").Value;
                    f.AddText(file.Value);
                    Ev_File.Add(f);
                }
                foreach (XElement enem in ev.Element("enemies").Elements("enemy"))
                {
                    EnemyComp x_enemy = new EnemyComp();
                    x_enemy.id = enem.Attribute("id").Value;
                    x_enemy.Addr = enem.Attribute("address").Value;
                    RePoint r = new RePoint();
                    x_enemy.Position = r.Point(float.Parse(enem.Element("position").Attribute("x").Value), float.Parse(enem.Element("position").Attribute("y").Value));
                    x_enemy.isScaning = bool.Parse(enem.Element("isscan").Value);
                    x_enemy.isVisible = bool.Parse(enem.Element("isvisible").Value);
                    x_enemy.Money = int.Parse(enem.Element("money").Value);
                    foreach (XElement sx in enem.Element("services").Elements("service"))
                    {
                        ServiceX service = new ServiceX(int.Parse(sx.Element("timestart").Value), int.Parse(sx.Element("port").Value));
                        service.id = sx.Attribute("id").Value;
                        service.Desc = sx.Element("name").Value;
                        switch (sx.Element("type").Value)
                        {
                            case "NONE": service.Type = TypeServiceX.NONE;
                                break;
                            case "FTP": service.Type = TypeServiceX.FTP;
                                break;
                            case "FIREWALL": service.Type = TypeServiceX.FIREWALL;
                                break;
                            case "ATM": service.Type = TypeServiceX.ATM;
                                break;
                            case "PROXY": service.Type = TypeServiceX.PROXY;
                                break;
                            case "SSH": service.Type = TypeServiceX.SSH;
                                break;
                            default: service.Type = TypeServiceX.NONE;
                                break;
                        }
                        service.Pass = sx.Element("pass").Value;
                        service.isHackPass = bool.Parse(sx.Element("ishackpass").Value);
                        foreach (XElement fx in sx.Element("files").Elements("file"))
                        {
                            FileX file = null;
                            switch (fx.Attribute("type").Value)
                            {
                                case "TXT": file = new FileTxtX();
                                    break;
                                case "SCRIPT": file = new FileScriptX();
                                    break;
                                case "EXPLOIT": file = new FileExploitX();
                                    break;
                                case "DATA": file = new FileDataX();
                                    break;
                                case "SSHKEY": file = new FileSSHKeyX();
                                    break;
                                default: file = new FileX();
                                    break;
                            }
                            file.id = fx.Attribute("id").Value;
                            file.Capacity = int.Parse(fx.Attribute("capacity").Value);
                            file.Name = fx.Attribute("name").Value;
                            file.AddText(fx.Value);
                            service.AddFile(file);
                        }
                        x_enemy.AddService(service);
                    }
                    Ev_Enemy.Add(x_enemy);
                }
                foreach (XElement m in ev.Element("mails").Elements("mail"))
                {
                    MailX mail = new MailX(m.Attribute("name").Value);
                    mail.ids = m.Attribute("id").Value;
                    mail.AddText(m.Value);
                    Ev_Mail.Add(mail);
                }
                foreach (XElement w in ev.Element("wanteds").Elements("wanted"))
                {
                    Ev_Wanted.Add(new E_Wanted(w.Attribute("id").Value, int.Parse(w.Value)));

                }
                foreach (XElement even in xDoc.Root.Element("ev").Elements("event"))
                {
                    TypeInEventX t_in = TypeInEventX.None;
                    object obj_inn = null;
                    switch (even.Element("in").Attribute("type").Value)
                    {
                        case "E_Scan":
                            {
                                t_in = TypeInEventX.E_Scan;
                                obj_inn = FindEnemyId(even.Element("in").Element("enemy").Value);
                                break;
                            }
                        case "E_Crack":
                            {
                                t_in = TypeInEventX.E_Crack;
                                obj_inn = FindEnemyId(even.Element("in").Element("enemy").Value);
                                break;
                            }
                        case "Time":
                            {
                                t_in = TypeInEventX.Time;
                                obj_inn = int.Parse(even.Element("in").Element("time").Value);
                                break;
                            }
                        case "File":
                            {
                                t_in = TypeInEventX.File;
                                obj_inn = FindFileId(even.Element("in").Element("file").Value);
                                break;
                            }
                        case "Wanted":
                            {
                                t_in = TypeInEventX.Wanted;
                                obj_inn = int.Parse(even.Element("in").Element("wanted").Value);
                                break;
                            }
                        case "Connected":
                            {
                                t_in = TypeInEventX.Connected;
                                obj_inn = FindEnemyId(even.Element("in").Element("enemy").Value);
                                break;
                            }
                        case "Service_off":
                            {
                                t_in = TypeInEventX.Service_off;
                                obj_inn = FindServiceId(even.Element("in").Element("service").Value);
                                break;
                            }

                        default: t_in = TypeInEventX.None;
                            break;
                    }
                    object obj_out = null;
                    TypeOutEventX t_out = TypeOutEventX.None;
                    obj_out = FindEventOut(even.Element("out").Attribute("id").Value, out t_out);
                    X_Event.Add(game.AddEvent(t_in, t_out, obj_inn, obj_out));
                }
            }
            
            
        }

        public void ReadQuest(string path)
        {
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement quest in xDoc.Root.Elements())
            {
                Quest q = new Quest();
                q.Name = quest.Element("name").Value;
                q.AddAbout(quest.Element("about").Value);
                switch (quest.Attribute("type").Value)
                {
                    case "File":
                        {
                            q.TypeQ = TypeQuest.File;
                            q.File = FindFileId(quest.Element("file").Value);
                            break;
                        }
                    case "Money":
                        {
                            q.TypeQ = TypeQuest.Money;
                            q.Money = int.Parse(quest.Element("money").Value);
                            break;
                        }
                    case "Wanteding":
                        {
                            q.TypeQ = TypeQuest.Wanteding;
                            q.LevelWanted = int.Parse(quest.Element("wanted").Value);
                            break;
                        }
                    case "Scaning":
                        {
                            q.TypeQ = TypeQuest.Scaning;
                            q.Computer = FindEnemyId(quest.Element("enemy").Value);
                            break;
                        }
                    case "FileUpload":
                        {
                            q.TypeQ = TypeQuest.FileUpload;
                            q.File = q.File = FindFileId(quest.Element("file").Value);
                            q.Computer = FindEnemyId(quest.Element("enemy").Value);
                            break;
                        }
                    default:
                        break;
                }
                X_Quests.Add(q);
            }
        }

        public void ReadEnemy(string path)
        {
            try
            {
                XDocument xDoc = XDocument.Load(path);
                foreach (XElement enem in xDoc.Root.Elements())
                {
                    EnemyComp x_enemy = new EnemyComp();
                    x_enemy.id = enem.Attribute("id").Value;
                    x_enemy.Addr = enem.Attribute("address").Value;
                    RePoint r = new RePoint();
                    x_enemy.Position = r.Point(float.Parse(enem.Element("position").Attribute("x").Value), float.Parse(enem.Element("position").Attribute("y").Value));
                    x_enemy.isScaning = bool.Parse(enem.Element("isscan").Value);
                    x_enemy.isVisible = bool.Parse(enem.Element("isvisible").Value);
                    x_enemy.Money = int.Parse(enem.Element("money").Value);
                    foreach (XElement sx in enem.Element("services").Elements("service"))
                    {
                        ServiceX service = new ServiceX(int.Parse(sx.Element("timestart").Value), int.Parse(sx.Element("port").Value));
                        service.id = sx.Attribute("id").Value;
                        service.Desc = sx.Element("name").Value;
                        switch (sx.Element("type").Value)
                        {
                            case "NONE": service.Type = TypeServiceX.NONE;
                                break;
                            case "FTP": service.Type = TypeServiceX.FTP;
                                break;
                            case "FIREWALL": service.Type = TypeServiceX.FIREWALL;
                                break;
                            case "ATM": service.Type = TypeServiceX.ATM;
                                break;
                            case "PROXY": service.Type = TypeServiceX.PROXY;
                                break;
                            case "SSH": service.Type = TypeServiceX.SSH;
                                break;
                            default: service.Type = TypeServiceX.NONE; 
                                break;
                        }
                        service.Pass = sx.Element("pass").Value;
                        service.isHackPass = bool.Parse(sx.Element("ishackpass").Value);
                        foreach (XElement fx in sx.Element("files").Elements("file"))
                        {
                            FileX file = null;
                            switch (fx.Attribute("type").Value)
                            {
                                case "TXT": file = new FileTxtX();
                                    break;
                                case "SCRIPT": file = new FileScriptX();
                                    break;
                                case "EXPLOIT": file = new FileExploitX();
                                    break;
                                case "DATA": file = new FileDataX();
                                    break;
                                case "SSHKEY": file = new FileSSHKeyX();
                                    break;
                                default: file = new FileX();
                                    break;
                            }
                            file.id = fx.Attribute("id").Value;
                            file.Capacity = int.Parse(fx.Attribute("capacity").Value);
                            file.Name = fx.Attribute("name").Value;
                            file.AddText(fx.Value);
                            service.AddFile(file);
                        }
                        x_enemy.AddService(service);
                    }
                    X_Enemies.Add(x_enemy);
                }
            }
            catch (Exception ex) { LOG.Error("ERROR LOAD comp.xml: {"+ex.Message+"}"); }
            
        }
    }
}
