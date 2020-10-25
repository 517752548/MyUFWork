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
//日志数据库
config.database="${log_db.database}";
//金钱表存活时间(单位：天)
config.moneyLogLiveTime=7;
// 物品生成表存活时间
config.itemGenLogLiveTime=7;
//充值日志存活时间,如果是worldserver全部保留，如果是gameserver保留7天
config.chargeLogLiveTime=#if($deployConfig.gameServer.serverType==1) -1 #else 7#end;
//默认存活时间
config.defLiveTime=7;
//定时创建每日日志表任务启动的延迟时间
config.createTableTaskDelay = 1000*60*60*24;
//定时创建每日日志表任务的执行周期
config.createTableTaskPeriod = 1000*60*60*24;
//定時刪除每日日志表任务启动时间,相对于每日零点时间：例如每日两点：2 * 24 * 60 * 1000
config.dropTableTaskStartTime=2 * 60 * 60 * 1000;
//定时删除每日日志任务表任务的执行周期
config.dropTableTaskPeriod=24 * 60 * 60 * 1000;
//是否删除过期日志表
config.dropLogTables=true;
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

