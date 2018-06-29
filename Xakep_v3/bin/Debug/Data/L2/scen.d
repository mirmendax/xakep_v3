--////////[Level 2: ver 1.0]///////////
version = "1.0"
name = "Level 2"
--///////////////////

luanet.load_assembly("libgame")
--luanet.load_assembly("System.Drawing")
luanet.load_assembly("System")
--Point = luanet.import_type("System.Drawing.Point")
Int = luanet.import_type("System.Int32")
Byte = luanet.import_type("System.Byte")

TypeServiceX = luanet.import_type("libgame.TypeServiceX")
CryptBit = luanet.import_type("libgame.CryptBit")
TypeQuest = luanet.import_type("libgame.TypeQuest")
TypeInEvent = luanet.import_type("libgame.TypeInEventX") --None, E_Scan, E_Crack, Time, File, Wanted, Service_off
TypeOutEvent = luanet.import_type("libgame.TypeOutEventX")--None, MAIL, ENEMY, WANTED


FileX = luanet.import_type("libgame.FileX")
FileTxtX = luanet.import_type("libgame.FileTxtX")
FileDataX = luanet.import_type("libgame.FileDataX")
FileSSHKeyX = luanet.import_type("libgame.FileSSHKeyX")
FileExploitX = luanet.import_type("libgame.FileExploitX")
FileScriptX = luanet.import_type("libgame.FileScriptX")

GameScript = luanet.import_type("libgame.GameScript")
ServiceX = luanet.import_type("libgame.ServiceX")
EnemyComp = luanet.import_type("libgame.EnemyComp")
Quest = luanet.import_type("libgame.Quest")
Event = luanet.import_type("libgame.EventGameX")
MailX = luanet.import_type("libgame.MailX")


game = GameScript()

--/Jibro Corp Link
enm = EnemyComp()
enm.Addr = "a.dc-jibro-corp.cc"
enm.Position = Point:Point(0.03, 0.02)
enm.isVisible = true
enm.isScaning = false
enm.Money = 0
--//Service FTP 21 (2dr4o8)
	serv = ServiceX(5, 21)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "2dr4o8"
	serv.Desc = "FTP of Log File"
	serv.Crypt = CryptBit.Bit0
	serv.isHackPass = false
	--///Files
		--////error_connected0.log
		file = FileTxtX()
		file.Name = "error_connected0.log"
		file.Capacity = 70
		file:AddText("[0x34]error connected.")
		file:AddText("[0x34]error connected.")
		file:AddText("[0x34]error connected.")
		file:AddText("[0xd4]error connected to [remote.dc-jibro-corp.cc] ping timeout.")
	serv:AddFile(file)
		--////error_connect1.log
		file = FileTxtX()
		file.Name = "error_connect1.log"
		file.Capacity = 50
		file:AddText("[0xb2]lost connected [remote.dc-jibro-corp.cc]")
		file:AddText("[0xb2]lost connected [remote.dc-jibro-corp.cc]")
		file:AddText("[0xb2]lost connected [remote.dc-jibro-corp.cc]")
		file:AddText("[0xb2]lost connected [t.dc-jibro-corp.cc] terminal off")
	serv:AddFile(file)
enm:AddService(serv)
a_dc_jibro = enm --/Для Event 1
	--///
--//

--||| srv.dc-jibro-corp.cc
enm = EnemyComp()
enm.Addr = "srv.dc-jibro-corp.cc"
enm.Position = Point:Point(0.3, 0.3)
enm.isVisible = false
enm.isScaning = false
enm.Money = 0
enm.Desc:Add("DNS Server (srv) \"dc-jibro-corp\"")
--//Service FTP 21 (2dr4o8)
	serv = ServiceX(5, 21)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "2dr4o8"
	serv.Desc = "DNS Server Info"
	serv.Crypt = CryptBit.Bit0
	serv.isHackPass = false
	--///Files
		--////error_connected0.log
		file = FileTxtX()
		file.Name = "status.log"
		file.Capacity = 17
		file:AddText("HOST\tSTATUS")
		file:AddText("a.dc-jibro-corp.cc\tOK")
		file:AddText("t.dc-jibro-corp.cc\tOK")
		file:AddText("a2.srv.dc-jibro-corp.cc\tOK")
		file:AddText("a23.srv.dc-jibro-corp.cc\tOK")
		file:AddText("a3.srv.dc-jibro-corp.cc\tOK")
		file:AddText("a9.srv.dc-jibro-corp.cc\tOK")
	serv:AddFile(file)
enm:AddService(serv)
game:AddEnemy(enm)

--||| srv.mega.dc-jibro-corp.cc
enm = EnemyComp()
enm.Addr = "srv.mega.dc-jibro-corp.cc"
enm.Position = Point:Point(0.6, 0.8)
enm.isVisible = false
enm.isScaning = false
enm.Money = 0
enm.Desc:Add("DNS Server (srv.mega) \"dc-jibro-corp\"")
--//Service FTP 21 (2dr4o8)
	serv = ServiceX(5, 21)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "2rd1"
	serv.Desc = "DNS Server Info"
	serv.Crypt = CryptBit.Bit0
	serv.isHackPass = false
	--///Files
		--////error_connected0.log
		file = FileTxtX()
		file.Name = "status.log"
		file.Capacity = 70
		file:AddText("HOST														STATUS")
		file:AddText("a19.srv.mega.dc-jibro-corp.cc				OK")
	serv:AddFile(file)
enm:AddService(serv)
game:AddEnemy(enm)
 
--|||||||
enm = EnemyComp()
enm.Addr = "t.dc-jibro-corp.cc"
enm.Position = Point:Point(0.1, 0.1)
enm.isVisible = false
enm.isScaning = false
enm.Money = 0
	--//Service FIREWALL 174 (i5d433k1)
	serv = ServiceX(25, 174)
	serv.Type = TypeServiceX.FIREWALL
	serv.Pass = "i5d433k1"
	serv.Desc = "FireWall FileSystem"
	serv.Crypt = CryptBit.Bit0
	serv.isHackPass = false
	--//
enm:AddService(serv)
	--//Service FTP 221 (hda01)
	serv = ServiceX(15, 221)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "hda01"
	serv.Desc = "Terminal Config Data"
	serv.Crypt = CryptBit.Bit0
		--///Files 
			--////a.conf
			file = FileTxtX()
			file.Name = "a.conf"
			file.Capacity = 64
			file:AddText("ERROR=on")
			file:AddText("NAME=a")
			file:AddText("IP_LOCAL=92.12.2.21")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=dc-jibro-corp.cc")
			file:AddText("STATUS=off")
	serv:AddFile(file)
			--////b.conf
			file = FileTxtX()
			file.Name = "b.conf"
			file.Capacity = 60
			file:AddText("ERROR=off")
			file:AddText("NAME=b")
			file:AddText("IP_LOCAL=92.22.2.213")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=dc-jibro-corp.cc")
			file:AddText("STATUS=off")
	serv:AddFile(file)
			--////a2-srv.conf
			file = FileTxtX()
			file.Name = "a2-srv.conf"
			file.Capacity = 59
			file:AddText("ERROR=off")
			file:AddText("NAME=a2")
			file:AddText("IP_LOCAL=92.12.2.21")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=srv.dc-jibro-corp.cc")
			file:AddText("STATUS=on")
	serv:AddFile(file)
			--////a23-srv.conf
			file = FileTxtX()
			file.Name = "a23-srv.conf"
			file.Capacity = 63
			file:AddText("ERROR=off")
			file:AddText("NAME=a23")
			file:AddText("IP_LOCAL=92.12.2.23")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=srv.dc-jibro-corp.cc")
			file:AddText("STATUS=on")
	serv:AddFile(file)
			--////a19-srv.conf
			file = FileTxtX()
			file.Name = "a19-srv.conf"
			file.Capacity = 66
			file:AddText("ERROR=off")
			file:AddText("NAME=a19")
			file:AddText("IP_LOCAL=92.12.4.11")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=srv.mega.dc-jibro-corp.cc")
			file:AddText("STATUS=on")
	serv:AddFile(file)
			--////a3-srv.conf
			file = FileTxtX()
			file.Name = "a3-srv.conf"
			file.Capacity = 62
			file:AddText("ERROR=off")
			file:AddText("NAME=a3")
			file:AddText("IP_LOCAL=92.12.2.3")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=srv.dc-jibro-corp.cc")
			file:AddText("STATUS=on")
	serv:AddFile(file)
			--////a9-srv.conf
			file = FileTxtX()
			file.Name = "a9-srv.conf"
			file.Capacity = 69
			file:AddText("ERROR=off")
			file:AddText("NAME=a9")
			file:AddText("IP_LOCAL=92.12.2.91")
			file:AddText("FIREWALL=on")
			file:AddText("DNS=srv.dc-jibro-corp.cc")
			file:AddText("STATUS=on")
	serv:AddFile(file)
			
--/
enm:AddService(serv)
game:AddEnemy(enm)
--||| "a2.srv.dc-jibro-corp.cc"
enm = EnemyComp()
enm.Addr = "a2.srv.dc-jibro-corp.cc"
enm.Position = Point:Point(0.2, 0.1)
enm.isScaning = false
enm.isVisible = false
enm.Money = 0
	--//Service FTP 211 (h3d89s2)
	serv = ServiceX(15, 211)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "h3d89s2"
	serv.Crypt = CryptBit.Bit0
	serv.Desc = "File Share"
enm:AddService(serv)
--//
game:AddEnemy(enm)

--||| "a23.srv.dc-jibro-corp.cc"
enm = EnemyComp()
enm.Addr = "a23.srv.dc-jibro-corp.cc"
enm.Position = Point:Point(0.05, 0.3)
enm.isScaning = false
enm.isVisible = false
enm.Money = 0
enm.Desc:Add("Kapersky Lob SeSurity")
	--//Service FireWall 11 (r3l0a27)
	serv = ServiceX(15, 11)
	serv.Type = TypeServiceX.FIREWALL
	serv.Pass = "r3l0a27"
	serv.Crypt = CryptBit.Bit0
	serv.Desc = "Kapersky Lob FireWall service"
enm:AddService(serv)
	--//Service FTP 11 (r3l0a28)
	serv = ServiceX(15, 911)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "r3l0a28"
	serv.Crypt = CryptBit.Bit0
	serv.Desc = "Kapersky antivirus base"
		--///FileS
		file = FileDataX()
		file.Name = "base01.b"
		file.Capacity = 221
		file:AddText("MZP0Nòdkj*#KLJSD:GH#$UKLF&TKLDSJFGBVJK<SDGFKL&#")
		file:AddText("*HJKLNSFLT&O@LJN<KASFRK@#&TKAGJ@*&NQWGK@FV@^FDB")
		file:AddText("MYIBBSFI&@^GFASGFDAF+_))))))000000023908ASF*@NZ")
	serv:AddFile(file)
		file = FileDataX()
		file.Name = "base04.b"
		file.Capacity = 224
		file:AddText("MZP0Nòdkj*#KLJSD:GH#$UKLF&TKLDSJFGBVJK<SDGFKL&#")
		file:AddText("*HJKLNSFLT&O@LJN<KASFRK@#&TKAGJ@*&NQWGK@FV@^FDB")
		file:AddText("MYILKJHLGMSDNGFJK@#BGFJKNGSDMFDKU#FU3908ASF*@NZ")
	serv:AddFile(file)
		file = FileDataX()
		file.Name = "base07.b"
		file.Capacity = 268
		file:AddText("MZP0Nòdkj&*#$GHKSDGBFKASD&TKLDSJFGBVJK<SDGFKL&#")
		file:AddText("*HJKLNSFLT&O@LJN<KASFRK@#&TKAGJ@*&NQWGK@FV@^FDB")
		file:AddText("MYIBBSFI&@^GFASGFDAF+_))))))000000023908ASF*@NZ")
	serv:AddFile(file)
		file = FileDataX()
		file.Name = "base02.b"
		file.Capacity = 292
		file:AddText("MZP0Nòdkj*#KLJSD:GH#$UKLF&TKLDSJFGBVJK<SDGFKL&#")
		file:AddText("*HJKLIYB#KIG#FK&#^GFVBMJS&TKAGJ@*&NQWGK@FV@^FDB")
		file:AddText("MYIBBSFI&@^GFASGFDAF+_))))))000000023908ASF*@NZ")
	serv:AddFile(file)
		file = FileTxtX()
		file.Name = "logchat.log"
		file.Capacity = 30
		file:AddText("dor>Это бессмысленные файлы с базами данных.")
		file:AddText("bow>Да их ещё никто не проверял!")
		file:AddText("dor>Я просто их скопировал у Dr.Beb и переименовал :)")
		file:AddText("bow>Нас не уволят за это?...")
		file:AddText("admin>Я вас прикрою.")
	serv:AddFile(file)
enm:AddService(serv)
--//
game:AddEnemy(enm)

--||| a3.srv.dc-jibro-corp.cc
enm = EnemyComp()
enm.Addr = "a3.srv.dc-jibro-corp.cc"
enm.Position = Point:Point(0.4, 0.06)
enm.isScaning = false
enm.isVisible = false
enm.Money = 500
	--///Service FTP 321 (12345678)
	serv = ServiceX(10, 321)
	serv.Type = TypeServiceX.FTP
	serv.Desc = "Заработок в интернете"
	serv.isHackPass = false
	serv.Pass = "12345678"
	serv.Crypt = CryptBit.Bit0
		--////Files
		file = FileTxtX()
		file.Name = "freeJob.txt"
		file.Capacity = 100
		file:AddText("Привет, хочешь заработать в интернете 100$ за 10 минут?")
		file:AddText("Тогда заходи ко мне на сайт я расскажу тебе как!")
		file:AddText("http://2dk0.kdf2sf.su")
	serv:AddFile(file)
enm:AddService(serv)
game:AddEnemy(enm)

--||| a9.srv.dc-jibro-corp.cc
enm = EnemyComp()
enm.Addr = "a9.srv.dc-jibro-corp.cc"
enm.Position = Point:Point(0.6, 0.1)
enm.isScaning = false
enm.isVisible = false
enm.Desc:Add("Hacker Room")
	--//Service FTP 2292 (c2h5oh)
	serv = ServiceX(15, 2292)
	serv.Type = TypeServiceX.FTP
	serv.Desc = "Free crack STAFF"
	serv.isHackPass = false
	serv.Crypt = CryptBit.Bit0
		--////Files
		file = FileExploitX()
		file.Name = "off_3143.expl"
		file:AddText("if ($args[1] != null) {")
		file:AddText("expl_f_off.expl")
		file:AddText("$firewall = cd ../../../firewall")
		file:AddText("$f->Run($firewall)")
		file:AddText("kill $pid($f) | cc | grep firewall")
		file:AddText("rm off_firewall.expl }")
		file.Desc = "exploit_3143"
	serv:AddFile(file)
enm:AddService(serv)
game:AddEnemy(enm)

--|||"a19.srv.mega.dc-jibro-corp.cc"
enm = EnemyComp()
enm.Addr = "a19.srv.mega.dc-jibro-corp.cc"
enm.Position = Point:Point(0.6, 0.9)
enm.isScaning = false
enm.isVisible = false
	--//Service FireWall 3143 (*HJKLIYB#KIG#FK&#)
	serv = ServiceX(100, 3143)
	serv.Type = TypeServiceX.FIREWALL
	serv.Pass = "*HJKLIYB#KIG#FK&#"
	serv.Desc = "FireWall System"
	serv.isHackPass = false
	serv.Crypt = CryptBit.Bit0
enm:AddService(serv)
	--//Service FTP 2211 (rH13oz238)
	serv = ServiceX(200, 2211)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "rH13oz23s8"
	serv.Desc = "BIN Data"
	serv.isHackPass = false
	serv.Crypt = CryptBit.Bit0
		--///Files
		file = FileDataX()
		file.Name = "img-vAmmel_v4.0.223.1.bin"
		file.Capacity = 123
		file:AddText("Просмотр содержимого не доступен")
		quest1_file = file --/ Of Quest 1
	serv:AddFile(file)
		file = FileTxtX()
		file.Name = "Data.txt"
		file.Capacity = 23
		file:AddText("Прошивка для контроллера aLMega C30F1 - Проверена")
	serv:AddFile(file)
enm:AddService(serv)
game:AddEnemy(enm)

		
--Quest
--/Quest 1 File Upload
q1 = Quest()
q1.TypeQ = TypeQuest.File
q1.File = quest1_file
q1.Name = "Промышленый шпионаж!?"
q1.About:Add("Найти сервер AlMega c прошивкой нового контроллера, и скачать её.")
game:AddQuest(q1)

--\Quest\\

--//Event 1 and 1.1 Boss mail
mail = MailX("boss@refato.dom")
mail:AddText("Добрый день. Нужны твои \"особые навыки\". У нас проблемма с нашим продуктом. Мы в тупике, нам нужно что-то новое.")
mail:AddText("Я слышал что AlMega сделали новую прошивку для своих контроллеров. Нам она нужна!!!! Достань её!!!")
mail:AddText("Мне подсказали что их сервера находятся в дата-центре Jibro! Действуй на тебя вся надежда.")
mail:AddText("---------------")
mail:AddText("С Уважением Олег Иванович Ширма (Директор)")

game:AddEvent(TypeInEvent.Time, TypeOutEvent.MAIL, 1, mail)
game:AddEvent(TypeInEvent.Time, TypeOutEvent.ENEMY, 1, a_dc_jibro)
