--///// Script Add SSH Service
name = "autorun_ssh.sh"
version = "0.1"
--/////////////////
luanet.load_assembly("libgame")

--//class
ServiceX = luanet.import_type("libgame.ServiceX")
TypeServiceX = luanet.import_type("libgame.TypeServiceX")
CryptBit = luanet.import_type("libgame.CryptBit")

service = ServiceX(25, 144, false)
service.Type = TypeServiceX.SSH
service.Pass = "123"
service.isHackPass = true
service.Crypt = CryptBit.Bit0
service.Desc = "SSH Terminal (script)"
service:Run()