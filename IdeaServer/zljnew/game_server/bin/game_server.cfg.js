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
config.localHostId="9010";
config.serverGroupId="1";
config.serverIndex=1;
config.serverId="9010";
config.bindIp="0.0.0.0";
config.ports="8085";
config.serverName="GameServer";
config.serverHost="0.0.0.0";
config.serverDomain="s1.csj.renren.com";
config.ioProcessor=1;

config.language="zh_CN";
config.i18nDir="i18n";
config.baseResourceDir="../resources";
config.scriptDir="scripts";
config.mapDir="maps";
config.battleReportRootPath="./report";
config.battleReportServiceType=0;

config.dbInitType=0;
config.dbConfigName="game_server_hibernate.cfg.xml,game_server_hibernate_query.xml";
config.battleReportDbConfigName="battle_report_ibatis_config.xml";
config.turnOnH2Cache=true;

config.flashSocketPolicy="<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"80-65535\" />\r\n </cross-domain-policy>\r\n";
config.gameServerCount=1;
//登陆类别 0:数据库验证 1:人人local验证 2:QQ验证 3:91ios登陆
config.authType=1
config.platformName="hf-game.com";

config.maxOnlineUsers=2000;
config.maxMonsterWarUsersNum = 4000;
config.maxBossWarUsersNum = 4000;
config.openNewerGuide=1;

/*
 *配置Log Server
 */
config.logConfig.logServerIp="127.0.0.1";
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
config.turnOnLocalInterface=true; //是否开服
//config.accountRoleDebug=true;//是否自动创建debug用户

/**local 配置*/
//config.requestDomain="http://local.game.io8.org/";
//config.reportDomain="http://local.game.io8.org/";
//config.localKey="c762000b3eb6955de0862f435b28a8eb"

config.requestDomain="http://192.168.1.219:8082/qqapi/";
config.reportDomain="http://192.168.1.219:8082/qqapi/";
config.localKey="2D940190C62CD4EE64D206E8A4B1148A";
config.gameId="csj";
	
config.operationCom="hithere";

config.probeConfig.turnOn=false;//scribe
config.chargeEnabled=true;
config.templateXorLoad=false;
config.dirtyWordsPartUrl="";
config.dirtyWordsFullUrl="";

/*
 * iso充值环境
 */
config.appleStoreType="buy";

/**充值 人人豆兑换元宝的比率是1：10 ***/
config.chargeMM2DiamondRate =10;
config.scribeServerIp = "127.0.0.1";
config.scribeOnTurn = false;
//直冲开关
config.zhichongFlag = false;

config.selfLogServer=true;

