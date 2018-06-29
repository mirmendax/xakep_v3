using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libgame
{

    [Serializable]
    public class Quest: IQuest
    {
        public string id = string.Empty;
        public string Name = string.Empty;
        public TypeQuest TypeQ = TypeQuest.None;
        public List<string> About = new List<string>();
        /// <summary>
        /// Уровень розыска
        /// </summary>
        public int LevelWanted = 0;
        /// <summary>
        /// Связанный с заданием компьютер
        /// </summary>
        public EnemyComp Computer = new EnemyComp();
        /// <summary>
        /// Необходимый файл
        /// </summary>
        public FileX File = new FileX();
        /// <summary>
        /// Необходимая сумма
        /// </summary>
        public int Money = 0;

        public Player Player = new Player();

        public bool Complete = false;
        public Quest()
        {
            
            
        }

        public void AddAbout(string s)
        {
            About.Add(s);
        }

        public void CheckedComplete(GameScript handle)
        {
            
            switch (TypeQ)
            {
                case TypeQuest.Wanteding: 
                {
                    if (handle.player.Wanted <= LevelWanted)
                    {
                        this.Complete = true;
                    }
                    else
                    {
                        this.Complete = false;
                    }
                    break; 
                }
                case TypeQuest.Scaning:
                {
                    if (!Complete)
                        foreach (EnemyComp eC in handle.ListEnemy)
                        {
                            if (eC.Addr == Computer.Addr)
                            {
                                if (eC.isScaning)
                                    this.Complete = true;
                            }
                        }
                    break;
                }
                case TypeQuest.File:
                {
                    if (!Complete)
                        foreach (FileX f in handle.player.Computer.FileList)
                        {
                            if (f.Name == File.Name)
                            {
                                this.Complete = true;
                            }
                        }
                    break;
                }
                case TypeQuest.Money:
                {
                    if (handle.player.Money >= Money)
                    {
                        this.Complete = true;
                    }
                    else
                        Complete = false;
                    break;
                }
                case TypeQuest.FileUpload:
                {
                    if (!Complete)
                    {
                        foreach (EnemyComp enC in handle.ListEnemy)
                        {
                            if (enC.Addr == Computer.Addr)
                            {
                                foreach (var servX  in enC.Services)
                                {
                                    foreach (var file in servX.ListFile)
                                    {
                                        if (File.Name == file.Name)
                                        {
                                            this.Complete = true;
                                            break;
                                        }
                                    }
                                    
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }

        
        
    }
    [Serializable]
    public class GameScript
    {
        /// <summary>
        /// Список машин
        /// </summary>
        public List<EnemyComp> ListEnemy = new List<EnemyComp>();
        /// <summary>
        /// Задания
        /// </summary>
        public List<Quest> Questions = new List<Quest>();
        public Player player = new Player();
        public List<MailX> MailList = new List<MailX>();
        public List<EventGame> EventList = new List<EventGame>();
        public int Level = 1;
        public GameScript()
        {
            player = new Player();
            ListEnemy = new List<EnemyComp>();
            Questions = new List<Quest>();
            player.Computer = new Comp();
        }

        public EventGame AddEvent(TypeInEventX tIn, TypeOutEventX tOut, object dIn, object dOut)
        {
            EventGame b = new EventGame(TypeInEventX.None, TypeOutEventX.None);
            
            switch (tIn)
            {
                case TypeInEventX.E_Crack:
                case TypeInEventX.E_Scan:
                case TypeInEventX.Connected:
                    {
                        switch (tOut)
                        {
                            case TypeOutEventX.WANTED:
                                b = new EventGameX<EnemyComp, SByte>
                                (tIn, tOut, dIn as EnemyComp, (SByte)(dOut as E_Wanted).Wanted);
                                break;
                            case TypeOutEventX.ENEMY:
                                b = new EventGameX<EnemyComp, EnemyComp>
                                (tIn, tOut, dIn as EnemyComp, dOut as EnemyComp);
                                break;
                            case TypeOutEventX.MAIL:
                                b = new EventGameX<EnemyComp, MailX>
                                (tIn, tOut, dIn as EnemyComp, dOut as MailX);
                                break;
                            case TypeOutEventX.FILE:
                                b = new EventGameX<EnemyComp, FileX>
                                (tIn, tOut, dIn as EnemyComp, dOut as FileX);
                                break;

                        }
                        break;
                    }
                case TypeInEventX.File:
                    {
                        switch (tOut)
                        {
                            case TypeOutEventX.WANTED:
                                b = new EventGameX<FileX, SByte>
                                (tIn, tOut, dIn as FileX, (SByte)(dOut as E_Wanted).Wanted);
                                break;
                            case TypeOutEventX.ENEMY:
                                b = new EventGameX<FileX, EnemyComp>
                                (tIn, tOut, dIn as FileX, dOut as EnemyComp);
                                break;
                            case TypeOutEventX.MAIL:
                                b = new EventGameX<FileX, MailX>
                                (tIn, tOut, dIn as FileX, dOut as MailX);
                                break;
                            case TypeOutEventX.FILE:
                                b = new EventGameX<FileX, FileX>
                                (tIn, tOut, dIn as FileX, dOut as FileX);
                                break;
                        }
                        break;
                    }
                case TypeInEventX.Wanted:
                case TypeInEventX.Time:
                    {
                        switch (tOut)
                        {
                            case TypeOutEventX.WANTED:
                                b = new EventGameX<int, SByte>
                                (tIn, tOut, int.Parse(dIn.ToString()), (SByte)(dOut as E_Wanted).Wanted);
                                break;
                            case TypeOutEventX.ENEMY:
                                b = new EventGameX<int, EnemyComp>
                                (tIn, tOut, int.Parse(dIn.ToString()), dOut as EnemyComp);
                                break;
                            case TypeOutEventX.MAIL:
                                b = new EventGameX<int, MailX>
                                (tIn, tOut, int.Parse(dIn.ToString()), dOut as MailX);
                                break;
                            case TypeOutEventX.FILE:
                                b = new EventGameX<int, FileX>
                                (tIn, tOut, int.Parse(dIn.ToString()), dOut as FileX);
                                break;
                        }
                        break;
                    }
                case TypeInEventX.Service_off:
                    {
                        switch (tOut)
                        {
                            case TypeOutEventX.WANTED:
                                b = new EventGameX<ServiceX, SByte>
                                (tIn, tOut, dIn as ServiceX, (SByte)(dOut as E_Wanted).Wanted);
                                break;
                            case TypeOutEventX.ENEMY:
                                b = new EventGameX<ServiceX, EnemyComp>
                                (tIn, tOut, dIn as ServiceX, dOut as EnemyComp);
                                break;
                            case TypeOutEventX.MAIL:
                                b = new EventGameX<ServiceX, MailX>
                                (tIn, tOut, dIn as ServiceX, dOut as MailX);
                                break;
                            case TypeOutEventX.FILE:
                                b = new EventGameX<ServiceX, FileX>
                                (tIn, tOut, dIn as ServiceX, dOut as FileX);
                                break;
                        }
                        break;
                    }
            }
            
            EventList.Add(b);
            return b;
        }

        public void AddEnemy(EnemyComp enC)
        {
            if (enC != null)
            {
                ListEnemy.Add(enC);
            }
        }

        public void AddQuest(Quest q)
        {
            if (q != null)
                Questions.Add(q);
        }
    }
}
