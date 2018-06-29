using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace libgame
{
    [Serializable]
    public class ListComp
    {
        
        public List<MotherBoard> MBoarList = new List<MotherBoard>();
        public List<RAM> RAMList = new List<RAM>();
        public List<CPU> CPUList = new List<CPU>();
        public List<Hard> HDDList = new List<Hard>();
        public List<Ethernet> LANList = new List<Ethernet>();

        public ListComp()
        {

            InitializeMB();
            InitializeRAM();
            InitializeHDD();
            InitializeCPU();
            InitializeLan();
        }
        
        void InitializeMB()
        {
            MBoarList.Clear();
            MotherBoard mb = new MotherBoard();
            mb.name = "e-Dox M-32R-D11";
            mb.nRAM = 1;
            mb.nSATA = 1;
            mb.nSokets = 1;
            mb.isProtectedHard = false;
            mb.Cost = Constance.MIN_COST * 100;
            MBoarList.Add(mb);
            /////////
            mb = new MotherBoard();
            mb.name = "Iptel AA43-DX";
            mb.nRAM = 1;
            mb.nSATA = 2;
            mb.nSokets = 1;
            mb.isProtectedHard = false;
            mb.Cost = Constance.MIN_COST * 150;
            MBoarList.Add(mb);
            /////////
            mb = new MotherBoard();
            mb.name = "e-Dox M-35F-D10";
            mb.nRAM = 2;
            mb.nSATA = 2;
            mb.nSokets = 1;
            mb.isProtectedHard = false;
            mb.Cost = Constance.MIN_COST * 250;
            MBoarList.Add(mb);
            /////////
            mb = new MotherBoard();
            mb.name = "APUS R765D85F";
            mb.nRAM = 3;
            mb.nSATA = 2;
            mb.nSokets = 1;
            mb.isProtectedHard = false;
            mb.Cost = Constance.MIN_COST * 300;
            MBoarList.Add(mb);
            /////////
            mb = new MotherBoard();
            mb.name = "APUS D457H72SS";
            mb.nRAM = 4;
            mb.nSATA = 3;
            mb.nSokets = 1;
            mb.isProtectedHard = false;
            mb.Cost = Constance.MIN_COST * 400;
            MBoarList.Add(mb);
            /////////
            mb = new MotherBoard();
            mb.name = "DidoByte RKE-1000";
            mb.nRAM = 4;
            mb.nSATA = 3;
            mb.nSokets = 2;
            mb.isProtectedHard = false;
            mb.Cost = Constance.MIN_COST * 600;
            MBoarList.Add(mb);
            /////////
            mb = new MotherBoard();
            mb.name = "APD 43-D11F2 ProtectedHDD";
            mb.nRAM = 4;
            mb.nSATA = 4;
            mb.nSokets = 2;
            mb.isProtectedHard = true;
            mb.Cost = Constance.MIN_COST * 1000;
            MBoarList.Add(mb);
        }
        void InitializeRAM()
        {
            RAMList.Clear();
            RAM ram = new RAM();
            ram.name = "DDL 400";
            ram.speed = Constance.MIN_SPEED_RAM * 0.5f;
            ram.Cost = Constance.MIN_COST * 25;
            RAMList.Add(ram);
            ///////////
            ram = new RAM();
            ram.name = "DDL 560";
            ram.speed = Constance.MIN_SPEED_RAM * 0.75f;
            ram.Cost = Constance.MIN_COST * 35;
            RAMList.Add(ram);
            ///////////
            ram = new RAM();
            ram.name = "DDL 800";
            ram.speed = Constance.MIN_SPEED_RAM * 1.1f;
            ram.Cost = Constance.MIN_COST * 65;
            RAMList.Add(ram);
            ///////////
            ram = new RAM();
            ram.name = "DDL 1000";
            ram.speed = Constance.MIN_SPEED_RAM * 1.5f;
            ram.Cost = Constance.MIN_COST * 75;
            RAMList.Add(ram);
            ///////////
            ram = new RAM();
            ram.name = "DDL 1400";
            ram.speed = Constance.MIN_SPEED_RAM * 1.9f;
            ram.Cost = Constance.MIN_COST * 100;
            RAMList.Add(ram);
            ///////////
            ram = new RAM();
            ram.name = "DDL 1800";
            ram.speed = Constance.MIN_SPEED_RAM * 3f;
            ram.Cost = Constance.MIN_COST * 150;
            RAMList.Add(ram);
            
        }
        void InitializeHDD()
        {
            HDDList.Clear();
            Hard hdd = new Hard();
            hdd.name = "Balakuda DD0010";
            hdd.Capacity = 10000;
            hdd.Cost = Constance.MIN_COST * 20;
            HDDList.Add(hdd);
            //////////
            hdd = new Hard();
            hdd.name = "Balakuda DF50";
            hdd.Capacity = 50000;
            hdd.Cost = Constance.MIN_COST * 50;
            HDDList.Add(hdd);
            //////////
            hdd = new Hard();
            hdd.name = "WDD SL0100";
            hdd.Capacity = 100000;
            hdd.Cost = Constance.MIN_COST * 110;
            HDDList.Add(hdd);
            //////////
            hdd = new Hard();
            hdd.name = "WDD FE120RR";
            hdd.Capacity = 120000;
            hdd.Cost = Constance.MIN_COST * 180;
            HDDList.Add(hdd);
            //////////
        }
        void InitializeLan()
        {
            LANList.Clear();
            Ethernet e = new Ethernet();
            e.name = "Modem 24k";
            e.Cost = Constance.MIN_COST * 10;
            e.speed = Constance.MIN_SPEED_LAN * 1.0f;
            LANList.Add(e);
        }
        void InitializeCPU()
        {
            CPUList.Clear();
            CPU c = new CPU();
            c.name = "CPU AKD";
            c.core = 1;
            c.speed = Constance.MIN_SPEED_CPU * 1.0f;
            c.Cost = Constance.MIN_COST * 150;
            CPUList.Add(c);
        }

    }

  
}
