using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;
using System.IO;

namespace libgame
{
    public static class LoadLua
    {
        static byte Level = 1;
        public static string LoadScrpt(string name)
        {
            
            string result = string.Empty;
            StreamReader f = File.OpenText("Data\\L" + Level.ToString() + "\\" + name);
            result = f.ReadToEnd();
            //f.Re
            return result;
        }

        public static GameScript LoadScenario(byte level)
        {
            Level = level;
            RePoint point = new RePoint();
            Lua lua = new Lua();
            GameScript result = new GameScript();
            try
            {
                lua["Point"] = point;
                lua.DoString(LoadLua.LoadScrpt("scen.d"));
                result = lua["game"] as GameScript;
                LOG.Log(string.Format("Load level: {0} - version: {1}", lua["name"], lua["version"]));
            }
            catch (LuaException ex) { LOG.Error(ex.Message); }
            catch (Exception ex) { LOG.Error(ex.Message); }
            return result;
        }

    }
}
