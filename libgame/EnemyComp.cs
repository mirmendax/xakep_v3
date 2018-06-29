using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Xakep_v3;

namespace libgame
{
    [Serializable]
    public class EnemyComp : IInitialized, IDisposable
    {
        /// <summary>
        /// ID XML
        /// </summary>
        public string id = string.Empty;
        /// <summary>
        /// Положение на карте
        /// </summary>
        public Point Position = Point.Empty;
        /// <summary>
        /// Видимость объекта
        /// </summary>
        public bool isVisible = false;
        /// <summary>
        /// Адрес объекта
        /// </summary>
        public string Addr = string.Empty;
        /// <summary>
        /// Сканирован ли компьютер
        /// </summary>
        public bool isScaning = false;
        /// <summary>
        /// Кол-во денег
        /// </summary>
        public int Money = 0;
        /// <summary>
        /// Список сервисов открытых (портов)
        /// </summary>
        public List<ServiceX> Services = new List<ServiceX>();


        public delegate void _OnChanged(EnemyComp handleComp, ChangedBitEnemy flag);
        public static event _OnChanged OnChanged;

        [NonSerialized]
        public EnemyCompElement Label = new EnemyCompElement();
        public int reWanted = 0;
        public List<string> Desc = new List<string>(); // Для вывода информации о компьютере

        private string[] GetScanData()
        {
            IEnumerable<ServiceX> query = from service in Services
                                          where service.isRun == true
                                          select service;
            List<string> str = new List<string>();
            str = str.Concat(Desc).ToList<string>();
            str.Add("Результат сканирования :" + this.Addr);

            foreach (var s in query)
            {
                string cry = "";
                if (s.Crypt != CryptBit.Bit0)
                    if (!s.isDecrypt)
                    {
                        cry = Constance.CryptToStr(s.Crypt);
                    }
                    else cry = "Отключено";
                else cry = "Не используется";
                string pss = "";
                if (!s.isHackPass)
                {
                    if (s.Pass != string.Empty)
                    {
                        pss = "Да (" + s.Pass.Length.ToString() + " символов)";
                    }
                    else
                        pss = "Нет";
                }
                else pss = s.Pass;
                str.Add("Открытый порт: " + s.Port.ToString() + " " + s.Desc + " "/* + " Шифрование: " + cry*/ + " Пароль: " + pss);

            }


            return str.ToArray();
        }

        public void AddService(ServiceX serv)
        {
            if (serv.Crypt == CryptBit.Bit0) serv.isDecrypt = true;
            if (serv.Type == TypeServiceX.FTP)
            {
                serv.Autorun += delegate(ServiceX servadd, string addr)
                {
                    if (this.Addr == addr)
                        this.AddService(servadd);
                };
            }
            serv.Parrent = this;
            Services.Add(serv);
        }

        public EnemyComp()
        {
            
        }


        #region override
        public override bool Equals(object obj)
        {
            return this.Addr == (obj as EnemyComp).Addr;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        public string[] ScanComp()
        {
            string[] result = this.GetScanData();

            isVisible = true;
            isScaning = true;
            try
            {
                OnChanged(this, ChangedBitEnemy.Visibled);
                OnChanged(this, ChangedBitEnemy.Scaning);
            }
            catch { }
            return result;
        }

        public bool IsAllHack
        {
            get
            {
                IEnumerable<ServiceX> query = from ishack in Services
                                              where ishack.Type != TypeServiceX.FIREWALL
                                              select ishack into nishack
                                              where nishack.isDecrypt == false || nishack.isHackPass == false
                                              select nishack;
                if (query.Count() == 0) return true;
                else
                    return false;
            }
        }

        public bool IsOffFirewall
        {
            get
            {
                IEnumerable<ServiceX> query = from ishack in Services
                                              where ishack.Type == TypeServiceX.FIREWALL
                                              select ishack into ninahck
                                              where ninahck.isRun == true
                                              select ninahck;
                if (query.Count() == 0) return true;
                else
                    return false;
            }
        }

        public ServiceX PortToService(int port)
        {
            ServiceX result = null;
            foreach (var ser in Services)
            {
                if (ser.Port == port)
                {
                    result = ser;
                    break;
                }
            }
            return result;
        }

        public void Initialize()
        {
            Label.Addr = this.Addr;
            Label.Location = Position;
        }

        public void Dispose()
        {
            Services = null;
        }

        
    }
}
