//是否是调试模式
config.debug=true;
//服务器的版本号
config.version="0.1.0.0"
//服务器名称
config.serverName = "LogServer"
//
config.serverHost="127.0.0.1"
//
config.serverDomain="test.d.mop.com"
// 数据库
config.database="tr_log";
// 金钱表存活时间(单位：天)
config.moneyLogLiveTime=30;
// 物品生成表存活时间
config.itemGenLogLiveTime=30;
// 默认存活时间
config.defLiveTime=15;
//服务绑定的IP
config.bindIp="127.0.0.1";
//服务绑定的端口
config.port=9890;
//定时创建每日日志表任务启动的延迟时间
config.createTableTaskDelay = 1000*60*24;
//定时创建每日日志表任务的执行周期
config.createTableTaskPeriod = 1000*60*24;
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
config.serverId="10125"
//服务器索引
config.serverIndex=25


/*
 *配置Telnet
 */
config.telnetServerName="LogServer_telnet"
config.telnetBindIp="39.96.37.184"
config.telnetPort=7001
