using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libgame;
using System.Drawing;
using LuaInterface;

namespace Xakep_v3
{
    partial class GameMain
    {
        public void ScenaLoad(GameScript g)
        {
            
            foreach (EnemyComp e in g.ListEnemy)
                Game.AddEnemy(e);
            foreach (Quest q in g.Questions)
                Game.AddQuest(q);
            foreach (EventGame e in g.EventList)
                Game.EventList.Add(e);
            
        }

        #region Scenario
        public void Scenarion()
        {
            
            RePoint p = new RePoint();
#pragma warning disable IDE0017 // Упростите инициализацию объекта
            Game.player = new Player();
#pragma warning restore IDE0017 // Упростите инициализацию объекта
            Game.player.Name = "Mendax";
            Game.player.Money = 1000;
            Game.player.Wanted = 45;
            Game.player.Computer.Position = p.Point(0.33f, 0.5f);
            /////Load Scenario
            Game.Level = 1;
            //ScenaLoad(LoadLua.LoadScenario((byte)Game.Level));
            //ScenaLoad();
            //<<<<<<<<<<<<<<=================

            XMLScenario ss = new XMLScenario();
            ss.ReadEnemy("Data\\LL2\\comp.xml");
            foreach (EnemyComp e in ss.X_Enemies)
            {
                Game.ListEnemy.Add(e);
            }
            ss.ReadQuest("Data\\LL2\\quest.xml");
            foreach (Quest q in ss.X_Quests)
            {
                Game.Questions.Add(q);
            }
            ss.ReadEvent("Data\\LL2\\event.xml");
            foreach (EventGame e in ss.X_Event)
            {
                Game.EventList.Add(e);
            }
            Action<IInitialized> Init = delegate(IInitialized e)
            {
                e.Initialize();
            };
            Game.ListEnemy.ForEach(Init);

            ////////Computer
            Game.player.Computer.InstallMB(listComputer.MBoarList[0]);
            Game.player.Computer.InstallHDD(listComputer.HDDList[0], 0);
            Game.player.Computer.InstallCPU(listComputer.CPUList[0], 0);
            Game.player.Computer.InstallRAM(listComputer.RAMList[0], 0);
            Game.player.Computer.InstallEthernet(listComputer.LANList[0]);
            Game.player.Computer.Initialize();

        }
        #endregion
    }
}
