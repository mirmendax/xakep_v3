using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xakep_v3;

namespace libgame
{
    [Serializable]
    public class RAM
    {
        public string name = string.Empty;
        /// <summary>
        /// Скорость
        /// </summary>
        public float speed = 0.0f;
        /// <summary>
        /// Цена
        /// </summary>
        public int Cost = 0;
        public override bool Equals(object obj)
        {
            if ((obj as RAM) == null) return false;
            return this.name == (obj as RAM).name;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return name;
        }
    }
    [Serializable]
    public class CPU
    {
        public string name = string.Empty;
        public byte core = 1;
        public float speed = 0.0f;
        public int Cost = 0;

        public override bool Equals(object obj)
        {
            if ((obj as CPU) == null) return false;
            return (this.name == (obj as CPU).name);

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("CPU: {0} Core: {1}", name, core);
        }

    }
    [Serializable]
    public class MotherBoard
    {
        public string name = string.Empty;
        /// <summary>
        /// Кол-во гнезд под оперативную память
        /// </summary>
        public byte nRAM = 1;
        /// <summary>
        /// Кол-во гнезд под процессоры
        /// </summary>
        public byte nSokets = 1;
        /// <summary>
        /// Кол-во гнезд под винт
        /// </summary>
        public byte nSATA = 1;
        /// <summary>
        /// Есть ли защита винчестера
        /// </summary>
        public bool isProtectedHard = false;
        public int Cost = 0;
        public override bool Equals(object obj)
        {
            if ((obj as MotherBoard) == null) return false;
            return this.name == (obj as MotherBoard).name;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0} CPUx{1} RAMx{2} SATAx{3} {4}", name, nSokets, nRAM, nSATA, (isProtectedHard) ? "HDDSecurity" : "");
        }
    }
    [Serializable]
    public class Hard
    {
        public string name = string.Empty;
        public int Capacity = 0;
        public int Cost = 0;
        public override bool Equals(object obj)
        {
            if ((obj as Hard) == null) return false;
            return this.name == (obj as Hard).name;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return name;
        }
    }
    [Serializable]
    public class Ethernet
    {
        public string name = string.Empty;
        public float speed = 0.0f;
        public int Cost = 0;
        public override bool Equals(object obj)
        {
            if ((obj as Ethernet) == null) return false;
            return this.name == (obj as Ethernet).name;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return name;
        }
    }
    [Serializable]
    public class Comp : IInitialized
    {
        static public float PRICE_COST = 0.6f;
        static public byte MAX_nSOCKET = 2;
        static public byte MAX_nRAM = 4;
        static public byte MAX_nSATA = 4;
        public MotherBoard mboard = new MotherBoard();
        public List<CPU> cpu = new List<CPU>();
        public List<RAM> ram = new List<RAM>();
        public List<Hard> hdd = new List<Hard>();
        public Ethernet lan = new Ethernet();
        public List<FileX> FileList = new List<FileX>();
        public delegate void Sale(int _money);
        public event Sale OnSale;
        [NonSerialized]
        public EnemyCompElement Icon = new EnemyCompElement();
        public Point Position = new Point();

        public Comp()
        {
            cpu.Clear();
            for (int i = 0; i < MAX_nSOCKET; i++)
            {
                cpu.Add(new CPU());
            }
            ram.Clear();
            for (int i = 0; i < MAX_nRAM; i++)
            {
                ram.Add(new RAM());
            }
            hdd.Clear();
            for (int i = 0; i < MAX_nSATA; i++)
            {
                hdd.Add(new Hard());
            }
            mboard = new MotherBoard();
            lan = new Ethernet();
        }
        #region Property
        public int CapacityFiles
        {
            get
            {
                int res = 0;
                foreach (FileX f in FileList)
                {
                    res += f.Capacity;
                }
                return res;
            }
        }
        public float SpeedLan
        {
            get { return this.lan.speed; }
        }
        public float SpeedRAM
        {
            get
            {
                float result = 0.0f;
                foreach (RAM r in ram)
                {
                    result += r.speed;
                }
                return result;
            }
        }
        public float SpeedCPU
        {
            get
            {
                float result = 0.0f;
                foreach (CPU c in cpu)
                {
                    result += c.speed * c.core;
                }
                return result;
            }
        }
        public int CapacityHDD
        {
            get
            {
                int result = 0;
                foreach (Hard h in hdd)
                {
                    result += h.Capacity;
                }
                return result;
            }
        }
        #endregion

        public bool InstallMB(MotherBoard mb)
        {
            bool result = false;
            if (mboard.name != string.Empty)
            {
                int sale = (int)((int)mboard.Cost / (int)PRICE_COST);
                OnSale(sale);
                mboard = mb;
                result = true;
            }
            else
            {
                mboard = mb;
                result = true;
            }

            return result;
        }

        public bool InstallRAM(RAM _ram, byte nSock)
        {
            bool result = false;
            if (nSock <= mboard.nRAM)
            {
                try
                {
                    if (ram[nSock].name != string.Empty)
                    {
                        int sale = (int)(ram[nSock].Cost / PRICE_COST);
                        OnSale(sale);
                        ram[nSock] = _ram;
                        result = true;
                    }
                    else
                    {
                        ram[nSock] = _ram;
                        result = true;
                    }
                }
                catch (NullReferenceException e)
                {
                    LOG.Error(e.Message);
                }
            }
            else result = false;

            return result;
        }

        public bool InstallCPU(CPU _cpu, byte nSock)
        {
            bool result = false;
            if (nSock <= mboard.nSokets)
            {
                if (cpu[nSock].name != string.Empty)
                {
                    int sale = (int)(cpu[nSock].Cost / PRICE_COST);
                    OnSale(sale);
                    cpu[nSock] = _cpu;
                    result = true;
                }
                else
                {
                    cpu[nSock] = _cpu;
                    result = true;
                }
            }
            return result;
        }

        public bool InstallHDD(Hard _hdd, byte nSock)
        {
            bool result = false;
            if (mboard.nSATA >= nSock)
            {
                if (hdd[nSock].name != string.Empty)
                {
                    int sale = (int)(hdd[nSock].Cost / PRICE_COST);
                    OnSale(sale);
                    hdd[nSock] = _hdd;
                    result = true;
                }
                else
                {
                    hdd[nSock] = _hdd;
                    result = true;
                }
            }
            return result;
        }

        public void InstallEthernet(Ethernet _ethCard)
        {
            if (lan.name != string.Empty)
            {
                int sale = (int)(lan.Cost / PRICE_COST);
                OnSale(sale);
                lan = _ethCard;
            }
            else lan = _ethCard;
        }

        public void Initialize()
        {
            //
            this.Icon.Addr = "You Computer";
            this.Icon.label1.ForeColor = Color.Yellow;
            this.Icon.Location = Position;
            ///File Scan
            FileX file = new FileScanX
            {
                Name = "scan",
                Capacity = 47,
                Desc = "",
                Body = new string[3] { "FileX file = new FileScanX();", "file.Name = \"scan\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);
            ///File Open
            file = new FileOpenX
            {
                Name = "more",
                Capacity = 17,
                Desc = "",
                Body = new string[3] { "FileX file = new FileOpenX();", "file.Name = \"open\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);
            ///File Crack
            file = new FileCrackX
            {
                Name = "crack",
                Capacity = 31,
                Desc = "",
                Body = new string[3] { "FileX file = new FileCrackX();", "file.Name = \"crack\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);
            file = new FileListX
            {
                Name = "ls",
                Capacity = 11,
                Desc = "",
                Body = new string[3] { "FileX file = new FileListX();", "file.Name = \"ls\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);
            file = new FileConnectX
            {
                Name = "connect",
                Capacity = 12,
                Desc = "",
                Body = new string[3] { "FileX file = new FileConnectX();", "file.Name = \"connect\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);
            file = new FileLogoutX
            {
                Name = "logout",
                Capacity = 19,
                Desc = "",
                Body = new string[3] { "FileX file = new FileLogoutX();", "file.Name = \"logout\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);

            file = new FileLoginX
            {
                Name = "login",
                Capacity = 29,
                Desc = "",
                Body = new string[3] { "FileX file = new FileConnectX();", "file.Name = \"connect\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);

            file = new FileSSHX
            {
                Name = "ssh",
                Capacity = 49,
                Desc = "",
                Body = new string[3] { "FileX file = new FileSSHX();", "file.Name = \"ssh\";", "file.Type = FileXType.OSPROGRAM;" }.ToList()
            };
            FileList.Add(file);

            file = new FileSSHcFireWallX
            {
                Name = "firewall",
                Capacity = 29,
                Desc = "",
                Body = new string[2] { "%sec = ps firewall", "kill %sec" }.ToList()
            };
            FileList.Add(file);

            file = new FileNmapX
            {
                Name = "nmap",
                Capacity = 19,
                Desc = "",
                Body = new string[2] { "Set(nmap, visible) = true", "Redraw()" }.ToList()
            };
            FileList.Add(file);

            file = new FileMailX
            {
                Name = "mail",
                Capacity = 19,
                Desc = "",
                Body = new string[2] { "Set(mail, visible) = true", "Redraw()" }.ToList()
            };
            FileList.Add(file);

            file = new FileKillTraceX
            {
                Name = "killtrace",
                Capacity = 19,
                Desc = "",
                Body = new string[2] { "wanted - 30", "money - 500" }.ToList()
            };
            FileList.Add(file);
        }
    }

    

    
}
