--////////[Level 1: ver 1.0]///////////
version = "1.0"
name = "Level 1"
--///////////////////


luanet.load_assembly("libgame")
luanet.load_assembly("System.Drawing")
Point = luanet.import_type("System.Drawing.Point")

TypeServiceX = luanet.import_type("libgame.TypeServiceX")
CryptBit = luanet.import_type("libgame.CryptBit")
TypeQuest = luanet.import_type("libgame.TypeQuest")


FileX = luanet.import_type("libgame.FileX")
FileTxtX = luanet.import_type("libgame.FileTxtX")
FileDataX = luanet.import_type("libgame.FileDataX")

GameScript = luanet.import_type("libgame.GameScript")
ServiceX = luanet.import_type("libgame.ServiceX")
EnemyComp = luanet.import_type("libgame.EnemyComp")
Quest = luanet.import_type("libgame.Quest")


--GameScript
game = GameScript()
--Enemy load.co:23
enm = EnemyComp()
enm.Addr = "load.co"
enm.Position = Point(10, 23)
enm.isScaning = false
enm.isVisible = true
enm.Money = 300
	--Servive 23 FTP (12323)
	serv = ServiceX(10, 23)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "12323"
	serv.Desc = "FTP Server"
	serv.Crypt = CryptBit.Bit0
	serv.isHackPass = true
	serv.isDecrypt = true
		--File log.log
		file = FileTxtX()
		file.Name = "log.log"
		file.Body:Add("Password of load.co:133 = [g12ww]");
		file.Body:Add("Password is correct");
		file.Body:Add("Enter to FireWall");
		file.Capacity = 22
	serv:AddFile(file)
	--//
enm:AddService(serv)
--//
	--Service 133 FireWall (q12ww)
	serv = ServiceX(10, 133)
	serv.Type = TypeServiceX.FIREWALL
	serv.Pass = "g12ww"
	serv.Desc = "FireWall"
	serv.Crypt = CryptBit.Bit0
	serv.isDecrypt = true
enm:AddService(serv)
--//
game:AddEnemy(enm)
--//Enemy

--///Enemy atm-0234.bank-corp.co
enm = EnemyComp()
enm.Addr = "atm-0234.bank-corp.co"
enm.Position = Point(30, 200)
enm.isVisible = false
enm.isScaning = false
enm.Money = 1500
	--//Service 1834 ATM (nR43fXw2)
	serv = ServiceX(5, 1834)
	serv.Type = TypeServiceX.NONE
	serv.Pass = "nR43fXw2"
	serv.Desc = "ATM Terminal"
	serv.Crypt = CryptBit.Bit0
	serv.isDecrypt = true
enm:AddService(serv)
--//
game:AddEnemy(enm)
--//Enemy

--\\\Quests
--Quest Money!!!
q = Quest()
q.TypeQ = TypeQuest.Money
q.Money = 1500
q.Name = "Money!!!!"
q.About = { "Соберите 1500 $" }
game:AddQuest(q)
--//
--Quest File Log
q = Quest()
q.TypeQ = TypeQuest.File
	--File log
	file = FileTxtX()
	file.Name = "log.log"
	file.Body = {"str \t str", "log \t alo.co"}
	file.Capacity = 22
q.File = file
--//
q.Name = "File log"
q.About = { "download data.log" }
game:AddQuest(q)
--//
--//Quests

--Load GameScenario
LoadScena(game)
--//////////END//////////////