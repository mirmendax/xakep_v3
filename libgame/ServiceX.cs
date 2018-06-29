using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using LuaInterface;

namespace libgame
{
    [Serializable]
    public class ServiceX: IDisposable
    {
        public delegate void onChanged();
        public event onChanged Change;
        public delegate void onAutorun(ServiceX serv, string addrComp);
        public event onAutorun Autorun;
        public EnemyComp Parrent = new EnemyComp();

        /// <summary>
        /// ID XML
        /// </summary>
        public string id = string.Empty;
        public int Port = 0;
        public bool isRun = true;
        public string Desc = string.Empty;
        public TypeServiceX Type = TypeServiceX.NONE;
        public string Pass = string.Empty;
        public bool isHackPass = false;
        public CryptBit Crypt = CryptBit.Bit0;
        public bool isDecrypt = false;
        public List<FileX> ListFile = new List<FileX>();
        /// <summary>
        /// Время запуска сервиса
        /// </summary>
        public int TimeStart = 1;
        [NonSerialized]
        Timer timerStart = null;
        #region ovveride
        public override bool Equals(object obj)
        {
            return Port == (obj as ServiceX).Port;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        public ServiceX()
        {
            isRun = true;
            timerStart = new Timer(TimeStart * 1000);
            timerStart.Elapsed += timerStart_Elapsed;
        }

        public ServiceX(int timeStart, int _port = 0, bool runOnce = true)
        {
            timerStart = new Timer(timeStart * 1000);
            timerStart.Elapsed += timerStart_Elapsed;
            isRun = runOnce;
            Port = _port;
        }

        public void AddFile(FileX file)
        {
            ListFile.Add(file);
        }

        public void Restart()
        {
            this.Stop();
            timerStart.Enabled = true;
            Change?.Invoke();
        }

        public void Stop()
        {
            isRun = false;
            Change?.Invoke();
            Parrent.Label.ServiceisOff();
        }

        public void Start()
        {
            if (this.ListFile.Count > 0)
            {
                if (this.Type == TypeServiceX.FTP)
                foreach (var f_run in ListFile)
                {
                    if (f_run.Name.Contains("autorun"))
                    {
                        LOG.Log(Parrent.Addr+"=> Autorun start...");
                        if (f_run is FileScriptX)
                        {
                            if (f_run.Body[0] == Parrent.Addr)
                            {
                                ResponseData data = (f_run as FileScriptX).Run(this);
                                if ((bool)data.Data[0])
                                {
                                    if (data.Data[2].ToString() == Parrent.Addr)
                                    {
                                        ServiceX nServ = data.Data[1] as ServiceX;
                                        if (Autorun != null)
                                        {
                                            Autorun(nServ, data.Data[2].ToString());
                                            this.ListFile.Remove(f_run);
                                            LOG.Log(Parrent.Addr + "=> File is deleted");
                                        }
                                    }
                                    else LOG.Log(Parrent.Addr + "=> File is not Data to Computer");
                                }
                            }
                            else LOG.Log(Parrent.Addr + "=> File is not Data to Computer");
                        }
                        break;
                    }
                }
            }
            isRun = true;
            Change?.Invoke();
            Parrent.Label.ServiceisOn();
        }

#pragma warning disable IDE1006 // Стили именования
        void timerStart_Elapsed(object sender, ElapsedEventArgs e)
#pragma warning restore IDE1006 // Стили именования
        {
            if (!isRun)
            {
                timerStart.Enabled = false;
                Start();
            }
        }

        public void CrackedService()
        {
            isHackPass = true;
        }

        public void DecryptService()
        {
            isDecrypt = true;
        }
        public void Dispose()
        {
            ListFile = null;
        }
    }
}
