using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace libgame
{
    [Serializable]
    public class EventGame : IEventX
    {
        public string id = string.Empty;
        protected TypeInEventX TypeInEvent = TypeInEventX.None;
        protected TypeOutEventX TypeOutEvent = TypeOutEventX.None;
        protected bool isOk = false;
        protected bool isEvented = false;
        public EventGame(TypeInEventX t1, TypeOutEventX t2)
        {
            TypeInEvent = t1;
            TypeOutEvent = t2;
            isOk = false;
        }

        public virtual ResponseData CheckedEvent(GameScript handle)
        {
            
            
            return new ResponseData("event");
        }
    }
    [Serializable]
    public class EventGameX<TInEvent, TOutEvent>:EventGame
    {
        TInEvent inEventData;
        

        TOutEvent outEventData;
        [NonSerialized]
        Timer timer = new Timer();

        public EventGameX(TypeInEventX typein, TypeOutEventX typeout, TInEvent inEvent, TOutEvent outEvent):base(typein, typeout)
        {
            inEventData = inEvent;
            outEventData = outEvent;
            if (typein == TypeInEventX.Time)
            {
                timer.Elapsed += timer_Elapsed;
                timer.Interval = int.Parse(inEventData.ToString()) * 1000;
                timer.Enabled = true;
            }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            isOk = true;
        }

        ResponseData EventedData(GameScript handle)
        {
            ResponseData result = new ResponseData("event");
            switch (this.TypeOutEvent)
            {
                case TypeOutEventX.ENEMY:
                    {
                        handle.ListEnemy.Add(outEventData as EnemyComp);
                        (outEventData as EnemyComp).Initialize();
                        break;
                    }
                case TypeOutEventX.MAIL:
                    {
                        handle.player.ListMail.Add(outEventData as MailX);
                        break;
                    }
                case TypeOutEventX.WANTED:
                    {

                        handle.player.Wanted += SByte.Parse(this.outEventData.ToString());
                        break;
                    }
                case TypeOutEventX.FILE:
                    {
                        FileX file = outEventData as FileX;
                        handle.player.Computer.FileList.Add(file);
                        break;
                    }
            }
            this.isEvented = true;
            result.Data.Add(true);
            return result;
        }

        public override ResponseData CheckedEvent(GameScript handle)
        {
            ResponseData result = new ResponseData("event");
            if (!isEvented)
            try
            {
                switch (this.TypeInEvent)
                {
                    case TypeInEventX.E_Crack:
                        {
                            EnemyComp e = inEventData as EnemyComp;
                            IEnumerable<EnemyComp> query = from ec in handle.ListEnemy
                                                           where ec.Addr == e.Addr
                                                           where ec.IsAllHack == true && ec.IsOffFirewall == true
                                                           select ec;
                            if (query.Count() > 0){
                                result = EventedData(handle);
                            }
                            break;
                        }
                    case TypeInEventX.E_Scan:
                        {
                            EnemyComp e = inEventData as EnemyComp;
                            IEnumerable<EnemyComp> query = from ec in handle.ListEnemy
                                                           where ec.Addr == e.Addr
                                                           where ec.isScaning == true
                                                           select ec;
                            if (query.Count() > 0)
                            {
                                result = EventedData(handle);
                            }
                            break;
                        }
                    case TypeInEventX.File:
                        {
                            FileX file = inEventData as FileX;
                            IEnumerable<FileX> query = from f in handle.player.Computer.FileList
                                                       where f.Name == file.Name
                                                       select f;
                            if (query.Count() > 0)
                            {
                                result = EventedData(handle);
                            }
                            break;
                        }
                    case TypeInEventX.Time:
                        {
                            if (isOk)
                            {
                                result = EventedData(handle);
                            }
                            break;
                        }
                    case TypeInEventX.Wanted:
                        {
                            int wanted = int.Parse(inEventData.ToString());
                            if (handle.player.Wanted >= wanted)
                                result = EventedData(handle);
                            break;
                        }
                    case TypeInEventX.Connected:
                        {
                            EnemyComp eComp = inEventData as EnemyComp;
                            if (eComp.isScaning)
                                if (handle.player.isConnected )
                                {
                                    if ((handle.player.ConnectedEnemy.IsOffFirewall) && (handle.player.ConnectedEnemy.IsAllHack))
                                        if (handle.player.ConnectedEnemy.Addr == eComp.Addr)
                                        {
                                            result = EventedData(handle);
                                        }
                                }
                            break;
                        }
                    case TypeInEventX.Service_off:
                        {
                            ServiceX serv = inEventData as ServiceX;
                            var servOff = from ec in handle.ListEnemy
                                       where ec.Addr == serv.Parrent.Addr
                                       select ec into enC
                                       from ser in enC.Services
                                       where ser.Port == serv.Port
                                       select ser;
                            if (servOff.Count() > 0)
                            {
                                ServiceX s = servOff.ElementAt<ServiceX>(0);
                                if (s.isRun == false)
                                    result = EventedData(handle);
                            }
                                       
                            
                            break;
                        }
                }
            }
            catch (Exception ex) { LOG.Error("Error event to: "+ex.Message);}
            
            return result;


        }
    }
}

