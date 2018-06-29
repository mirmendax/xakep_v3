using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace libgame
{
    [Serializable]
    public enum CryptBit : Byte
    {
        Bit0 = 4,
        Bit4 = 8,
        Bit8 = 16,
        Bit16 = 32,
        Bit24 = 48,
        Bit32 = 64
    }
    [Serializable]
    public enum ChangedBitEnemy : int
    {
        Visibled = 1,
        Scaning = 2,
        Cracking = 3,
        Run = 4,
        Stop = 5
    }
    [Serializable]
    public enum FileXType : int
    {
        NONE = 0,
        OSPROGRAM = 1,
        SCRIPT = 2,
        EXPLOIT = 3,
        ROOTKIT = 4,
        TXT = 5,
        DATA = 6,
        DB = 7,
        SSHKEY = 8
    }
    [Serializable]
    public enum TypeServiceX : int
    {
        NONE = 0,
        FTP = 1,
        FIREWALL = 2,
        ATM = 3,
        PROXY = 4,
        SSH = 5
    }
    [Serializable]
    public enum TypeQuest : int
    {
        
        None = 0,
        Scaning = 1,
        Wanteding = 2,
        File = 3,
        FileUpload = 4,
        Money = 5
    }
    [Serializable]
    public enum TypeOutEventX : int
    {
        None = 0,
        MAIL = 1,
        ENEMY = 2,
        WANTED = 3,
        FILE = 4
    }
    [Serializable]
    public enum TypeInEventX : int
    {
        None = 0,
        E_Scan = 1,
        E_Crack = 2,
        Time = 3,
        File = 4,
        Wanted = 5,
        Connected = 6,
        Service_off = 7
    }

    [Serializable]
    public static class Constance
    {
        public static int MAX_WANTED_LEVEL = 100;
        public static int MIN_COST = 0;
        public static float MIN_SPEED_RAM = 0f;
        public static float MIN_SPEED_CPU = 0f;
        public static float MIN_SPEED_LAN = 1.0f;

        
        static Constance()
        {
            Lua ConstLua = new Lua();
            
            try
            {
                ConstLua.DoFile("Data\\const.dat");
                MAX_WANTED_LEVEL = int.Parse(ConstLua["MAX_WANTED_LEVEL"].ToString());
                MIN_COST = int.Parse(ConstLua["MIN_COST"].ToString());
                MIN_SPEED_RAM = float.Parse(ConstLua["MIN_SPEED_RAM"].ToString());
                MIN_SPEED_CPU = float.Parse(ConstLua["MIN_SPEED_CPU"].ToString());
                MIN_SPEED_LAN = float.Parse(ConstLua["MIN_SPEED_LAN"].ToString());
            }
            catch (LuaException ex) { LOG.Error(ex.Message); }
            catch (Exception ex) { LOG.Error(ex.Message); }
        }

        public static byte WantedOfMoney(int money)
        {
            byte result = 0;
            if (money > 0 && money <= 500) result = 10;
            if (money > 500 && money <= 1000) result = 20;
            if (money > 1000 && money <= 1500) result = 30;
            if (money > 1500 && money <= 2500) result = 35;
            if (money > 2500) result = 40;
            return result;
        }
        public static string CryptToStr(CryptBit bit)
        {
            string result = string.Empty;
            switch (bit)
            {
                case CryptBit.Bit0: result = "Без шифрования";
                    break;
                case CryptBit.Bit4: result = "4 bit";
                    break;
                case CryptBit.Bit8: result = "8 bit";
                    break;
                case CryptBit.Bit16: result = "16 bit";
                    break;
                case CryptBit.Bit24: result = "24 bit";
                    break;
                case CryptBit.Bit32: result = "32 bit";
                    break;
            }
            return result;
        }

    }
}
