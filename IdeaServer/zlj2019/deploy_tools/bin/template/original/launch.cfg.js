#if(${server.serverName}=="game_server")
config.setProperty("jar.file", "lib/server_lib.encrypt");
config.setProperty("jar.main", "com.imop.lj.gameserver.GameServer");
#end
#if(${server.serverName}=="log_server")
config.setProperty("jar.file", "lib/server_lib.encrypt");
config.setProperty("jar.main", "com.imop.lj.logserver.LogServer");
#end
