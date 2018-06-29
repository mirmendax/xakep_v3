using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libgame
{
    #region LOG
    [Serializable]
    public static class LOG
    {
        public static readonly string ERROR_CALLED_FILE = "Ошибка ввода данных команды ";
        public static void Log(string logtext)
        {
            Console.WriteLine(logtext);
        }

        public static void Error(string errtext)
        {
            Console.WriteLine(errtext);
        }

        
    }
    #endregion

    [Serializable]
    /// <summary>
    /// Класс игрока
    /// </summary>
    public class Player
    {
        public string Name = string.Empty;
        public int Money = 0;
        public int XP = 0;
        private int wanted = 0;
        public List<MailX> ListMail = new List<MailX>();
        public delegate void OnWanted();
        public static event OnWanted GameOver;
        public Comp Computer = new Comp();
        public EnemyComp ConnectedEnemy = new EnemyComp();
        public ServiceX ConnectSSH = new ServiceX();
        public bool isConnected = false;
        public int Wanted
        {
            get { return wanted; }
            set
            {
                wanted = value;
                if (wanted < 0) wanted = 0;
                if (wanted >= Constance.MAX_WANTED_LEVEL)
                    if (GameOver != null)
                        GameOver();
            }
        }
        
        public Player()
        {
            Computer.OnSale += Computer_onSale;
        }

        void Computer_onSale(int _money)
        {
            Money += _money;
        }

    }


}
