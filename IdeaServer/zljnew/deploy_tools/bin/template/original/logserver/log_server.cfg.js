//是否是调试模式
config.debug=false;
//服务器的版本号
config.version="${versionConfig.serverVersion}"
//服务器名称
config.serverName = "${server.name}"
//
config.serverDomain="${deployConfig.name}"
//
config.serverHost="${server.lanIp}";
//服务绑定的IP
config.bindIp="${server.lanIp}";
//服务绑定的端口
config.port="${server.lanPort}";
//定时创建每日日志表任务启动的延迟时间
config.createTableTaskDelay = 1000*60*60*24;
//定时创建每日日志表任务的执行周期
config.createTableTaskPeriod = 1000*60*60*24;
//配置IBatis的配置文件名
config.ibatisConfig="log_ibatis_config.xml";
//配置消息类型识别器
config.messageRecognizer=new com.imop.lj.logserver.LogMessageRecognizer();
//配置消息处理器
config.logMessageHandler=new com.imop.lj.logserver.LogMessageHandler();
//配置建立日志表的策略
config.tableCreator = new com.imop.lj.logserver.createtable.TodayAndTommorowTableCreator();
//服务器ID
config.serverId="${deployConfig.localHostId}${server.id}"
//索引
config.serverIndex="${server.id}"

/*
 *配置Telnet
 */
config.telnetServerName="LogServer_telnet"
config.telnetBindIp="${server.lanIp}"
config.telnetPort=${server.telnetPort}

