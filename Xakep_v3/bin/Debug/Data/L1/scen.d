--////////[Level 1: ver 1.0]///////////
version = "1.0"
name = "Level 1"
--///////////////////


luanet.load_assembly("libgame")
luanet.load_assembly("System")
--Point = luanet.import_type("libgame.RePoint")
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

--Point = RePoint()
--GameScript
game = GameScript()

--Enemy load.co:23
enm = EnemyComp()
enm.Addr = "load.co"
enm.Position = Point:Point(0.01, 0.23)
enm.isScaning = false
enm.isVisible = true
enm.Money = 200
	--Servive 23 FTP (a4x12)
	serv = ServiceX(10, 21)
	serv.Type = TypeServiceX.FTP
	serv.Pass = "a4x12"
	serv.Desc = "FTP Server"
	serv.Crypt = CryptBit.Bit0
	serv.isHackPass = false
	ev3serv = serv
	--//
enm:AddService(serv)
ev1enemy = enm --//Для События 2, 3, 4
--//
game:AddEnemy(enm)

--\\\Quests
--Quest Money!!!
q = Quest()
q.TypeQ = TypeQuest.Money
q.Money = 2500
q.Name = "Money!!!!"
q.About = { "Соберите 1500 $" }
game:AddQuest(q)

--//
--//Quests
--/////////Events
--Event 1
	enm = EnemyComp()
	enm.Addr = "atm-0234.load.co"
	enm.Position = Point:Point(100, 200)
	enm.isVisible = true
	enm.isScaning = false
	enm.Money = 800
		--//Service 183 ATM (Z$x2w@6)
		serv = ServiceX(5, 183)
		serv.Type = TypeServiceX.ATM
		serv.Pass = "Z$x2w@6"
		serv.Desc = "ATM Terminal"
		serv.Crypt = CryptBit.Bit0
	enm:AddService(serv)
	ev2enemy = enm --// to Event 7
	--//
game:AddEvent(TypeInEvent.Connected, TypeOutEvent.ENEMY, ev1enemy, enm)
--//
--//Event 2
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Привет!")
	mail:AddText("Это тренеровочная миссия. Одно задание это заработать 2500$, для этого нужно сливать деньги со взломанных серверов.")
	mail:AddText("Тебе необходимо взломать сервер load.co. Но всё по порядку.")
	mail:AddText("Для того чтобы узнать о запущеных сервисах используйте команду: scan <host>")
	mail:AddText("")
	mail:AddText("  scan load.co")
game:AddEvent(TypeInEvent.Time, TypeOutEvent.MAIL, 2, mail)
--//Event 3
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Отлично!")
	mail:AddText("")
	mail:AddText("Теперь необходимо подобрать пороль к FTP Server`у [port: 21] для этого есть комманда: crack <host> <port>")
	mail:AddText("")
	mail:AddText("  crack load.co 21")
game:AddEvent(TypeInEvent.E_Scan, TypeOutEvent.MAIL, ev1enemy, mail)
--//Event 4
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Превосходно!")
	mail:AddText("Но за такие действия твой уровень розыска будет увеличиваться. Но об этом потом.")
	mail:AddText("Теперь нужно подключиться к серверу [connect <host>]:")
	mail:AddText("  connect load.co")
	mail:AddText("А затем подключившись можно слить все деньги. Но за это ваш уровень розыска будет увеличен.")
	mail:AddText("От того на сколько вы наследили на сервере будет написанно в интерфейсе подключения.")
	mail:AddText("Чтобы уменьшить ур-нь розыска нажми на кнопку: [Чистить логи]")
	mail:AddText("")
game:AddEvent(TypeInEvent.E_Crack, TypeOutEvent.MAIL, ev1enemy, mail)
--//Event 5
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Это просто. Теперь у нас новая цель: atm-0234.load.co")
	mail:AddText("Это банкомат. И у него кажется есть деньги.")
	mail:AddText("Давай посмотри что у него есть и попробуй взломать его.")
game:AddEvent(TypeInEvent.Connected, TypeOutEvent.MAIL, ev1enemy, mail)
--//Event 6
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Упс... Неудача.")
	mail:AddText("Теперь твой ур-нь розыска вырос ещё сильнее. Когда ты терпишь неудачи со взломом то ты получаешь больше очков розыска.")
	mail:AddText("Тут нужно воспользоваться чем то другим... О у меня кажется есть кое что.")
	mail:AddText("Я вот тебе скинул один файлик: exploit_atm.expl. Это эксплоит он настроен на взлом 183 порта (ATM Terminal) для этого сервера.")
	mail:AddText("Проверь свои файлы с помощью команды: ls")
	mail:AddText("Затем открой эксплоит что бы прочитать его настройки с помошью команды: more <nameFile>")
	mail:AddText("")
	mail:AddText("  more exploit_atm.expl")
	mail:AddText("")
	mail:AddText("Эксплойты настроены на определенные сервера. Адрес сервер указан в первой строке файла.")
	mail:AddText("Для того что бы его запустить необходимо написать название файла в консоли: exploit_atm.expl")
	mail:AddText("А затем проверь atm-0234.load.co ещё раз.")
	mail:AddText("Кстати в консоли можно писать несколько команд подряд для поочередного выполнения, для этого их нужно разделять: | ")
	mail:AddText("Например: exploit_atm.expl | scan atm-0234.load.co")
game:AddEvent(TypeInEvent.Wanted, TypeOutEvent.MAIL, 50, mail)
--//Event 6.1
	file = FileExploitX()
	file.Name = "exploit_atm.expl"
	file.Capacity = 23
	file:AddText("atm-0234.load.co")
	file:AddText("expl-atm0234.expl")
	file:AddText("%if (host.addr=atm-0234.load.co)")
	file:AddText("$script->Run()")
	file:AddText("*JKSCNBILY#@OL#MFHL&#FYT(#&*BFOHN&OM")
	file:AddText("*EDO*Y$O#:J<L)#ENMVL#$GHLN(S<H$GKNB*S")
	file.Desc = "exploit_1834"
game:AddEvent(TypeInEvent.Wanted, TypeOutEvent.FILE, 50, file)
--//Event 7
game:AddEvent(TypeInEvent.E_Crack, TypeOutEvent.WANTED, ev2enemy, -70)
--//Event 7.1
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Ну вот и всё объект взломан, забирай деньги.")
	mail:AddText("Я позаботился о твоем уровне розыска. ")
	mail:AddText("Но помни если твой ур-нь станет выше 100 то тебя посадят в тюрьму.")
	mail:AddText("Вот ещё один сервер который можно взломать и слить деньги.")
game:AddEvent(TypeInEvent.E_Crack, TypeOutEvent.MAIL, ev2enemy, mail)	
--//Event 7.2
	enm = EnemyComp()
	enm.Addr = "at19-atm.load.co"
	enm.Position = Point:Point(180, 90)
	enm.isVisible = true
	enm.isScaning = false
	enm.Money = 100
		--//Service 134 ATM (J223123)
		serv = ServiceX(5, 134)
		serv.Type = TypeServiceX.ATM
		serv.Pass = "J223123"
		serv.Desc = "ATM Terminal"
		serv.Crypt = CryptBit.Bit0
	enm:AddService(serv)
		--//Service 144 FIREWALL (5XcG#kL2xq)
		serv = ServiceX(10, 144)
		serv.Type = TypeServiceX.FIREWALL
		serv.Pass = "5XcG#kL2xq"
		serv.Crypt = CryptBit.Bit0
		serv.isHackPass = true
		serv.Desc = "FireWall"
		ev7serv = serv
	enm:AddService(serv)
	ev4enemy = enm --// to Event 7
game:AddEvent(TypeInEvent.E_Crack, TypeOutEvent.ENEMY, ev2enemy, ev4enemy)
--//Event 8
	mail = MailX("admin@n-soft.ru")
	mail:AddText("У него стоит FireWall он не даст тебе слить деньги даже если ты его взломаешь. Необходимо его отключить.")
	mail:AddText("Отключать сервисы можно из меню интерфейса подключения, если взломаны.")
	mail:AddText("Для этого нажми правой кнопкой на выбранном сервисе и выбери соответствующий пункт. Попробую.")
game:AddEvent(TypeInEvent.E_Scan, TypeOutEvent.MAIL, ev4enemy, mail)
--//Event 8.1
	enm = EnemyComp()
	enm.Addr = "at9-atm.load.co"
	enm.Position = Point:Point(10, 190)
	enm.isVisible = true
	enm.isScaning = false
	enm.Money = 400
		--//Service 1834 ATM (1457533222)
		serv = ServiceX(5, 1834)
		serv.Type = TypeServiceX.ATM
		serv.Pass = "1457533222"
		serv.Desc = "ATM Terminal"
		serv.Crypt = CryptBit.Bit0
	enm:AddService(serv)
		--//Service 44 FIREWALL (5SX$j#kxq)
		serv = ServiceX(10, 44)
		serv.Type = TypeServiceX.FIREWALL
		serv.Pass = "5SX$j#kxq"
		serv.Crypt = CryptBit.Bit0
		serv.Desc = "FireWall"
	enm:AddService(serv)
		--//Service 923 SSH (1xjd2)
		serv = ServiceX(10, 923)
		serv.Type = TypeServiceX.SSH
		serv.Pass = "1xjd2"
		serv.Crypt = CryptBit.Bit0
		serv.Desc = "SSH Terminal"
	enm:AddService(serv)
	ev5enemy = enm --// to Event 8
game:AddEvent(TypeInEvent.Service_off, TypeOutEvent.ENEMY, ev7serv, ev5enemy)
--// Event 8.2
	mail = MailX("admin@n-soft.ru")
	mail:AddText("Вот тебе новая цель с FireWall'ом ")
	mail:AddText("Обычно у FireWall сложные пороли, поэтому необходимо использовать эксплойты или если есть SSH Terminal то можно взломать его.")
	mail:AddText("А затем подключиться к нему через: ssh -l <host> <pass> или ssh -k <host> <sshKeyFile> (если есть файл-ключ)")
	mail:AddText("Действуй.")
game:AddEvent(TypeInEvent.Service_off, TypeOutEvent.MAIL, ev7serv, mail)
--//////////END//////////////