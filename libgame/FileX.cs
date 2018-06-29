using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace libgame
{
    
    /// <summary>
    /// Класс возвращения данных от приложений
    /// </summary>
    [Serializable]
    public class ResponseData
    {
        /// <summary>
        /// Список объектов данных
        /// </summary>
        List<Object> data = new List<object>();
        /// <summary>
        /// Время затраченное на выполнение
        /// </summary>
        public float speedOperation = 0.0f;
        /// <summary>
        /// Заголовок (название программы вернувшей данные)
        /// </summary>
        public string Head = string.Empty;
        
        public List<Object> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                
            }
        }

        public ResponseData() { }
        public ResponseData(string head) => this.Head = head;
        public ResponseData(string head, List<Object> data)
        {
            this.Head = head;
            this.Data = data;
        }
       

    }
    /// <summary>
    /// Базовый класс для файлов
    /// </summary>
    [Serializable]
    public class FileX: IFileX
    {
        /// <summary>
        /// Уникальный идентиификатор
        /// </summary>
        public string id = string.Empty;
        /// <summary>
        /// Название программы (имя файла)
        /// </summary>
        string name = string.Empty;
        /// <summary>
        /// Размер занимаемого диского пространства
        /// </summary>
        public int Capacity = 1;
        /// <summary>
        /// Тип файла для системы
        /// </summary>
        public FileXType Type = FileXType.NONE;
        public string Desc = string.Empty;
        public List<string> Body = new List<string>();
        public int ExplPort = 0;
        #region override
        public override bool Equals(object obj)
        {
            return this.Name == (obj as FileX).Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual ResponseData Run(GameScript handleGame, string[] args)
        {
            
            return new ResponseData();
        }

        public void AddText(string str)
        {
            Body.Add(str);
        }

    }
    [Serializable]
    public class FileScanX: FileX
    {
        public FileScanX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            if (args[0] == this.Name)
            {
                try
                {
                    if (args[1] != "")
                    {
                        List<String> r = new List<string>();
                        foreach (EnemyComp e in handleGame.ListEnemy)
                        {
                            if (args[1] == e.Addr)
                            {
                                result.speedOperation = handleGame.player.Computer.lan.speed;
                                string[] sdata = e.ScanComp();
                                foreach (var s in sdata)
                                    r.Add(s);
                                r.Add(string.Format("Денег: {0}", e.Money));
                                result.Data.Add(true);
                                result.Data.Add(r.ToArray());
                            }
                        }
                        if (result.Data.Count == 0)
                        {
                            result.Data.Add(false);
                            result.Data.Add(new string[] { "Сервер [" + args[1] + "] не найден." });
                        }
                    }
                }
                catch
                {
                    LOG.Log(LOG.ERROR_CALLED_FILE + this.Name); 
                    result.Data.Add(false);
                    result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
                }
            }
            return result;
        }
    }
    [Serializable]
    public class FileOpenX : FileX
    {
        public FileOpenX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            if (args[0] == this.Name)
                try
                {
                    if (!handleGame.player.isConnected)
                    {
                        List<string> r = new List<string>();
                        foreach (FileX f in handleGame.player.Computer.FileList)
                        {
                            if (args[1] == f.Name)
                            {
                                result.Data.Add(true);
                                r.Add("Содержимое файла: " + f.Name);
                                foreach (var s in f.Body)
                                    r.Add(s);
                                result.Data.Add(r.ToArray());
                            }
                        }
                        if (result.Data.Count == 0)
                        {
                            result.Data.Add(false);
                            result.Data.Add("Файл [" + args[1] + "] не найден.");
                        }
                    }

                }
                catch
                {
                    LOG.Log(LOG.ERROR_CALLED_FILE + this.Name);
                    result.Data.Add(false);
                    result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
                }
            return result;
        }
    }
    [Serializable]
    public class FileLoginX : FileX
    {
        public FileLoginX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                {
                    if (args.Length >= 3)
                    {
                        IEnumerable<EnemyComp> lEc = from ec in handleGame.ListEnemy
                                                     where ec.Addr == args[1]
                                                     select ec;
                        if (lEc.Count() > 0)
                        {
                            EnemyComp loginEnemy = lEc.ElementAt(0);
                            IEnumerable<ServiceX> lS = from serv in loginEnemy.Services
                                                       where serv.Pass == args[2]
                                                       select serv;
                            if (lS.Count() > 0)
                            {
                                ServiceX LoginService = lS.ElementAt(0);
                                LoginService.isHackPass = true;
                                LoginService.Parrent.isVisible = true;
                                
                                result.Data.Add(true);
                                result.Data.Add(LoginService.Parrent.Addr+ ":" + LoginService.Port + " ["+LoginService.Desc+"] защита отключена");
                            }
                            else
                            {
                                result.Data.Add(false);
                                result.Data.Add("На серевере ["+args[1]+"] нет сервиса с паролем ["+args[2]+"]");
                            }
                        }
                        else
                        {
                            result.Data.Add(false);
                            result.Data.Add("Сервер ["+args[1]+"] не найден");
                        }
                    }
                    else
                    {
                        result.Data.Add(false);
                        result.Data.Add("Не верный синтаксис. Использование: login <host> <password>");
                    }
                }
            }
            catch
            {
                LOG.Log(LOG.ERROR_CALLED_FILE + this.Name);
                result.Data.Add(false);
                result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
            }
            return result;
        }
    }

    [Serializable]
    public class FileLogoutX : FileX
    {
        public FileLogoutX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                {
                    if (handleGame.player.isConnected)
                        result.Data.Add(true);
                    else
                    {
                        result.Data.Add(false);
                        result.Data.Add("Вы не подключены.");
                    }
                }
            }
            catch
            {
                LOG.Log(LOG.ERROR_CALLED_FILE + this.Name);
                result.Data.Add(false);
                result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
            }
            return result;
        }
    }
    [Serializable]
    public class FileCrackX : FileX
    {
        public FileCrackX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            if (args[0] == this.Name)
            {
                try
                {
                    if (args[1] != "")
                    {
                        if (args.Length < 3)
                        {
                            result.Data.Add(false);
                            result.Data.Add("Не верное количество параметров (crack address port)");
                        }
                        else
                            foreach (EnemyComp e in handleGame.ListEnemy)
                            {
                                if (e.Addr == args[1])
                                {
                                    ServiceX serv = e.PortToService(int.Parse(args[2]));
                                    if (serv != null)
                                        if (!serv.isHackPass)
                                        {
                                            result.speedOperation = handleGame.player.Computer.SpeedCPU +
                                                handleGame.player.Computer.SpeedRAM +
                                                handleGame.player.Computer.SpeedLan+10;///////////////////Исправить
                                            //System.Windows.Forms.MessageBox.Show(result.speedOperation.ToString());
                                            e.ScanComp();
                                            result.Data.Add(true);
                                            result.Data.Add(e);
                                            result.Data.Add(serv);

                                        }
                                        else
                                        {
                                            result.Data.Add(false);
                                            result.Data.Add("Компьютер уже взломан");
                                        }
                                    else
                                    {
                                        result.Data.Add(false);
                                        result.Data.Add("На этом компьютере не открыт порт: " + args[2]);
                                    }
                                }
                            }
                    }
                }
                catch
                {
                    LOG.Log(LOG.ERROR_CALLED_FILE + this.Name);
                    result.Data.Add(false);
                    result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
                }
            }
            return result;
        }
    }
    [Serializable]
    public class FileListX : FileX
    {
        public FileListX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                {   //На какомто компе
                    
                        string[] list = new string[1000];
                        int i = 0;
                        result.Data.Add("Список файлов");
                        foreach (FileX file in handleGame.player.Computer.FileList)
                        {
                            if (file.Type != FileXType.OSPROGRAM)
                                list[i] = string.Format("{0} \t{1} Mb \t{2}", file.Name, file.Capacity,
                                    file.Type.ToString());
                            i++;
                        }
                        result.Data.Add(list);
                
                }
            }
            catch
            {
                LOG.Log(LOG.ERROR_CALLED_FILE + this.Name); 
                result.Data.Add(false);
                result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
            }
            return result;
        }
    }
    [Serializable]
    public class FileDataX : FileX
    {
        public FileDataX()
        {
            this.Type = FileXType.DATA;
        }
    }
    [Serializable]
    public class FileTxtX : FileX
    {
        public FileTxtX()
        {
            this.Type = FileXType.TXT;
        }
    }
    [Serializable]
    public class FileConnectX : FileX
    {
        public FileConnectX()
        {
            this.Type = FileXType.OSPROGRAM;
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                {
                    if (args[1] != "")
                    {
                        if (!handleGame.player.isConnected)
                        {
                            foreach (var item in handleGame.ListEnemy)
                            {
                                if (item.Addr == args[1])
                                {
                                    item.ScanComp();
                                    result.Data.Add(true);
                                    result.Data.Add(item);
                                    break;
                                }
                                
                            }
                            if (result.Data.Count == 0)
                            {
                                result.Data.Add(false);
                                result.Data.Add("Сервер не найден");
                            }
                        }
                        else
                        {
                            result.Data.Add(false);
                            result.Data.Add("Вы уже подключены к "+handleGame.player.ConnectedEnemy.Addr);
                        }

                    }
                    else
                    {
                        result.Data.Add(false);
                        result.Data.Add("Введите адрес.");
                    }
                }
            }
            catch
            {
                LOG.Error(LOG.ERROR_CALLED_FILE + this.Name); 
                result.Data.Add(false);
                result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
            }
            return result;
        }
    }
    [Serializable]
    public class FileExploitX : FileX
    {
        
        public FileExploitX()
        {
            this.Type = FileXType.EXPLOIT;
        }

        public FileExploitX(ServiceX service)
        {
            ExplPort = service.Port;
            this.Name = "exploit_" + this.ExplPort.ToString();
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData("exploit");
            try
            {
                
                if (args[0] == this.Name)
                {
                    if (args.Length != 1)
                    {
                        //Console.WriteLine(args[0]);
                        Lua explLua = new Lua();
                        foreach (var enC in handleGame.ListEnemy)
                        {
                            if (enC.Addr == args[1] && enC.isVisible == true)
                            {//if (enC.isVisible) {}
                                explLua["enemy"] = enC;
                                //explLua["handleScript"] = handleGame; //Доделать!!!
                                explLua.DoString(LoadLua.LoadScrpt(this.Body[1]));
                                if ((bool)explLua["isOk"] == true)
                                {
                                    result.Data.Add(true);
                                    EnemyComp newenem = new EnemyComp();
                                    newenem = (EnemyComp)explLua["enemy"];
                                    result.Data.Add(enC);
                                    result.Data.Add(newenem);
                                    result.Data.Add(explLua["resulttext"].ToString());
                                }
                                else
                                {
                                    result.Data.Add(false);
                                    result.Data.Add(explLua["resulttext"].ToString());
                                }
                                break;
                            }
                        }
                        if (result.Data.Count == 0)
                        {
                            result.Data.Add(false);
                            result.Data.Add("Нет компьютера к которому можно применить данный эксплойт");
                        }
                    }
                    else
                    {
                        result.Data.Add(false);
                        result.Data.Add("Введите адрес.");
                    }
                }
            }
            catch (LuaException e) { LOG.Error(this.Name + " err: " + e.Message); }
            catch (Exception e)
            {
                LOG.Log(LOG.ERROR_CALLED_FILE + " exploit");
                LOG.Error(e.Message);
                result.Data.Add(false);
                result.Data.Add(LOG.ERROR_CALLED_FILE + this.Name);
            }
            return result;
        }
    }
    [Serializable]
    public class FileSSHX : FileX
    {
        public FileSSHX()
        {
            this.Type = FileXType.OSPROGRAM;
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                {
                    switch (args[1])
                    {
                        case "-l":
                            {
                                IEnumerable<EnemyComp> queryE = from eC in handleGame.ListEnemy
                                                                where eC.Addr == args[2]
                                                                select eC;
                                if (queryE.Count() > 0)
                                {
                                    EnemyComp e = queryE.ElementAt<EnemyComp>(0);
                                    IEnumerable<ServiceX> querySSH = from SSH in e.Services
                                                                     where SSH.Type == TypeServiceX.SSH && SSH.isRun == true
                                                                     select SSH;
                                    if (querySSH.Count() > 0)
                                    {
                                        ServiceX s = querySSH.ElementAt<ServiceX>(0);
                                        if (s.Pass == args[3])
                                        {
                                            result.Data.Add(true);
                                            result.Data.Add(e);
                                            result.Data.Add(s);
                                        }
                                        else
                                        {
                                            result.Data.Add(false);
                                            result.Data.Add("Неверный пороль");
                                        }
                                    }
                                    else
                                    {
                                        result.Data.Add(false);
                                        result.Data.Add("У сервера: " + e.Addr + " нет открытого SSH");
                                    }
                                }
                                else
                                {
                                    result.Data.Add(false);
                                    result.Data.Add("Сервер не найден");
                                }
                                break;
                            }
                        case "-k":
                            {
                                var qE = from eC in handleGame.ListEnemy
                                         where eC.Addr == args[2]
                                         select eC;
                                if (qE.Count() > 0)
                                {
                                    EnemyComp e = qE.ElementAt<EnemyComp>(0);
                                    IEnumerable<ServiceX> querySSH = from SSH in e.Services
                                                                     where SSH.Type == TypeServiceX.SSH && SSH.isRun == true
                                                                     select SSH;
                                    if (querySSH.Count() > 0)
                                    {
                                        ServiceX s = querySSH.ElementAt<ServiceX>(0);
                                        var qfile = from f in handleGame.player.Computer.FileList
                                                    where f.Name == args[3]
                                                    select f;
                                        if (qfile.Count() > 0)
                                        {
                                            FileX file = qfile.ElementAt<FileX>(0);
                                            if (file is FileSSHKeyX)
                                            {
                                                if (file.Body[0] == "sshKey" && e.Addr == file.Body[1] && s.Port == int.Parse(file.Body[2]) && s.Pass == file.Body[3])
                                                {
                                                    result.Data.Add(true);
                                                    result.Data.Add(e);
                                                    result.Data.Add(s);
                                                }
                                                else
                                                {
                                                    result.Data.Add(false);
                                                    result.Data.Add("Сервер отверг подключение с этим ключем.");
                                                }
                                            }
                                            else
                                            {
                                                result.Data.Add(false);
                                                result.Data.Add("Файл ["+file.Name+"] не является ssh ключем");
                                            }
                                        }
                                        else
                                        {
                                            result.Data.Add(false);
                                            result.Data.Add("Файл ["+args[3]+"] не найден");
                                        }
                                    }
                                    else
                                    {
                                        result.Data.Add(false);
                                        result.Data.Add("У сервера: " + e.Addr + " нет открытого SSH");
                                    }

                                }
                                else
                                {
                                    result.Data.Add(false);
                                    result.Data.Add("Сервер не найден");
                                }
                                break;
                            }
                        default:
                            {
                                result.Data.Add(false);
                                result.Data.Add("Не верный синтаксис команды ssh");
                                break;
                            }
                    }
                }
            }
            catch
            {
                LOG.Error(LOG.ERROR_CALLED_FILE + this.Name);
                result.Data.Add(false);
                result.Data.Add("Не верный синтаксис команды ssh");
            }
            return result;
        }
    }
    [Serializable]
    public class FileSSHKeyX : FileX
    {
        public FileSSHKeyX()
        {
            this.Type = FileXType.SSHKEY;
        }
    }

#region SSH Command
    [Serializable]
    public class FileSSHcFireWallX : FileX
    {
        public FileSSHcFireWallX()
        {
            this.Type = FileXType.OSPROGRAM;
        }
        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData("sshCom");
            try
            {
                if (args[0] == this.Name)
                {
                    if (handleGame.player.isConnected)
                    {
                        if (args[1] == "stop")
                        {
                            var d = from s in handleGame.player.ConnectedEnemy.Services
                                    where s.Type == TypeServiceX.FIREWALL && s.isRun == true
                                    select s;
                            if (d.Count() > 0)
                            {
                                ServiceX serv = d.ElementAt<ServiceX>(0);
                                result.Data.Add(true);
                                result.Data.Add("F_STOP");
                                result.Data.Add(serv);
                            }
                            else
                            {
                                result.Data.Add(false);
                                result.Data.Add("Запущенный сервис FireWall не найден");
                            }
                        }
                    }
                    else
                    {
                        result.Data.Add(false);
                        result.Data.Add("SSH not connected");
                    }
                }
            }
            catch { result.Data.Add(false); result.Data.Add(LOG.ERROR_CALLED_FILE+this.Name); }
            return result;
        }
    }
#endregion
    [Serializable]
    public class FileScriptX : FileX
    {
        public FileScriptX()
        {
            this.Type = FileXType.SCRIPT;
        }

        public ResponseData Run(ServiceX serv)
        {
            ResponseData result = new ResponseData("script");
            Lua lScript = new Lua();
            try
            {
                lScript.DoString(LoadLua.LoadScrpt(this.Body[1]));
                result.Data.Add(true);
                ServiceX sN = lScript["service"] as ServiceX;
                result.Data.Add(sN);
                result.Data.Add(lScript["addr"].ToString());
            }
            catch (Exception e) { result.Data.Add(false); LOG.Error(e.Message); }
            return result;
        }
    }

    public class FileNmapX : FileX
    {
        public FileNmapX()
        {
            this.Type = FileXType.OSPROGRAM;
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                    result.Data.Add(true);
                
            }
            catch { }
            return result;
        }
    }

    public class FileMailX : FileX
    {
        public FileMailX()
        {
            this.Type = FileXType.OSPROGRAM;
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                    result.Data.Add(true);

            }
            catch { }
            return result;
        }
    }

    public class FileKillTraceX : FileX
    {

        public FileKillTraceX()
        {
            this.Type = FileXType.OSPROGRAM;
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {
                if (args[0] == this.Name)
                {
                    if (handleGame.player.Money >= 500)
                    {
                        result.Data.Add(true);
                        handleGame.player.Money -= 500;
                        handleGame.player.Wanted -= 30;
                        result.Data.Add("Розыск уменьшен на 30 пунктов за 500 $");

                    }
                    else
                    {
                        result.Data.Add(false);
                        result.Data.Add("Недостаточно денег.");
                    }
                }
            }
            catch
            {

            }
            return result;
        }
    }

    public class FileFilesX : FileX
    {

        public FileFilesX()
        {
            this.Type = FileXType.OSPROGRAM;
        }

        public override ResponseData Run(GameScript handleGame, string[] args)
        {
            ResponseData result = new ResponseData(this.Name);
            try
            {

            }
            catch
            {
                LOG.Error("ERROR: Files....");
            }
            return result;
        }
    }
}
