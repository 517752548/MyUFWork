/*
 * Server基本信息
 */
config.serverType=1;
config.debug=1;
config.charset="UTF-8";
config.version="0.2.0.1";
config.resourceVersion="0.2.0.1";
config.dbVersion="0.2.0.1";
config.regionId="1";
config.localHostId="1002";
config.serverGroupId="2";
config.serverIndex=1;
config.serverId="10021";
config.bindIp="0.0.0.0";
config.ports="7070";
config.serverName="GameServer";
config.serverHost="0.0.0.0";
config.serverDomain="test2.csj.renren.com";
config.ioProcessor=1;
config.language="zh_CN";
config.i18nDir="i18n";
config.baseResourceDir="D:\\eclipse\\workspace\\lj\\resources";
config.scriptDir="scripts";
config.battleReportRootPath="./report";
config.battleReportServiceType=0;

config.dbInitType=0;
config.dbConfigName="game_server_hibernate.cfg.xml,game_server_hibernate_query.xml";
config.battleReportDbConfigName="battle_report_ibatis_config.xml";
config.turnOnH2Cache=true;

config.flashSocketPolicy="<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"80-65535\" />\r\n </cross-domain-policy>\r\n";
config.gameServerCount=1;
//登陆类别 0:数据库验证 1:人人local验证 2:QQ验证 3:91ios登陆
config.authType=0
config.platformName="renren.com";

config.maxOnlineUsers=3500;
config.openNewerGuide=1;
config.gameId="csj";

/*
 *配置Log Server
 */
config.logConfig.logServerIp="39.96.37.184";
config.logConfig.logServerPort=9890;

/*
 *配置Telnet
 */
config.telnetServerName="GameServer_telnet";
config.telnetBindIp="0.0.0.0";
config.telnetPort=7000;

/*
 *配置local接口相关参数
 */
config.localReportOnlinePeriod=300;
config.localReportStatusPeriod=60;
config.turnOnLocalInterface=false; //是否开服

/**local 配置*/
//config.requestDomain="http://local.game.io8.org/";
//config.reportDomain="http://local.game.io8.org/";
//config.localKey="c762000b3eb6955de0862f435b28a8eb"

config.requestDomain="http://test.local.rrgdev.org/";
config.reportDomain="http://test.local.rrgdev.org/";
config.localKey="2D940190C62CD4EE64D206E8A4B1148A";

	
config.operationCom="qzone";

config.probeConfig.turnOn=false;
config.probeConfig.reporterIp="192.168.1.118";
config.chargeEnabled=true;
config.templateXorLoad=false;

/*
 * iso充值环境
 */
config.appleStoreType="buy";

/**充值 人人豆兑换元宝的比率是1：10 ***/
config.chargeMM2DiamondRate =10;
config.scribeServerIp = "192.168.1.118";
config.scribeOnTurn = false;

/** 过滤词，下载地址 */
config.dirtyWordsPartUrl = "";
config.dirtyWordsFullUrl = "";

/**db存储策略*/
config.upgradeDbStrategy = false;
/**日志采集*/
config.collectStrategy = false;

/**直冲*/
config.zhichongFlag = true;

config.selfLogServer = false;

config.kaiyingLog = true;

/**跨服战相关配置*/
//跨服服务器功能开关true表示需要连接跨服服务器false不需要连接跨服服务器
config.worldServerConfig.turnOn=false;
//此服是不是跨服服务器0代表游戏服务器1代表跨服服务器
config.worldServerConfig.serverType=1;
//跨服服务器ip地址
config.worldServerConfig.ip="127.0.0.1";
//跨服服务器端口号
config.worldServerConfig.port=7070;

