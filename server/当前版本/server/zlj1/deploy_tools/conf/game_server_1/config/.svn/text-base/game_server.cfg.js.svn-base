/*
 * Server基本信息
 */
config.serverType=1;
// 是否debug
config.debug=0;
//配置文件是否加密
config.encryptResource=false;
// 字符集编码格式
config.charset="UTF-8";
// 服务器版本号
config.version="@server.version@";
// 资源版本号
config.resourceVersion="@resource.version@";
// 数据库版本号
config.dbVersion="@db.version@";
// 大区ID
config.regionId="2";
// 本机id
config.localHostId="2003";
// 第几组服ID
config.serverGroupId="3";
// 服id
config.serverIndex=1;
//
config.serverId="2003";
// 外网的绑定IP
config.bindIp="0.0.0.0";
// 外网端口，支持多端口
config.ports="8080";
//
config.serverName="game_server_2";
// 
config.serverHost="60.29.249.160";
//
config.serverDomain="s1.zlj.renren.com";
//
config.ioProcessor=1;

// 多语言
config.language="zh_CN";
// 国际化语言目录
config.i18nDir="i18n";
// 加载策划文件路径
config.baseResourceDir="/data/resource/csj/1.0.0.35.2";
// 加载scriptes路径
config.scriptDir="scripts";
//
config.battleReportRootPath="/data/www_index/reports";
//
config.battleReportServiceType=0;

//
config.dbInitType=0;
//
config.dbConfigName="game_server_hibernate.cfg.xml,game_server_hibernate_query.xml";
//
config.battleReportDbConfigName="battle_report_ibatis_config.xml";
//
config.turnOnH2Cache=true;

//
config.flashSocketPolicy="<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"80-65535\" />\r\n </cross-domain-policy>\r\n";
//
config.gameServerCount=1;
//登陆类别 0:数据库验证 1:人人local验证 2:QQ验证 3:91ios登陆
config.authType=1;
//
config.platformName="renren";
//
config.maxOnlineUsers=2000;
//
config.openNewerGuide=1;

/*
 *配置Log Server
 */
config.logConfig.logServerIp="10.30.36.160";
config.logConfig.logServerPort=9001;

/*
 *配置Telnet
 */
config.telnetServerName="GameServer_telnet";
config.telnetBindIp="10.30.36.160";
config.telnetPort=7000;

/*
 *配置local接口相关参数
 */
config.localReportOnlinePeriod=300;
config.localReportStatusPeriod=60;
config.turnOnLocalInterface=false; //qq不用local，所以关闭
config.requestDomain="http://local.csj.mop.com/";
config.reportDomain="http://local.csj.mop.com/";

config.operationCom="qzone";

config.probeConfig.turnOn=true;
config.chargeEnabled=true;
config.localKey="C6F82E33A258FF5BD892DDF5804B7F58";
/*
 * iso充值环境
 */
config.appleStoreType="buy";

/**充值 人人豆兑换元宝的比率是1：10 ***/
config.chargeMM2DiamondRate =10;

/**
 * 登陆墙,默认打开，阻止普通用户登陆
 */
config.loginWallEnabled = false;

/** 防沉迷配置,默认打开 */
config.wallowControlled = true;

config.scribeOnTurn = true;

config.zlj37wanwanConfig.url="http://api.zlj.37wanwan.com/api/otherplatformlogin";

config.zlj37wanwanConfig.localkey = "9d2f990b299cd29a8f93b606ccabca08";

/** 自身的logserver默认开启 */
config.selfLogServer = true;

config.apiRequestDomain="http://127.0.0.1:8080/";

/** 是否开启给kaiying发送log*/
config.kaiyingLog = false;

/** 先把采样打开，调试用，等正式上线需要关闭XXX */
config.collectStrategy = false;

config.scribeServerIp = "192.168.1.20";

config.probeConfig.reporterIp="192.168.1.20";

/**跨服战相关配置*/
//跨服服务器功能开关true表示需要连接跨服服务器false不需要连接跨服服务器
config.worldServerConfig.turnOn=false;
//此服是不是跨服服务器0代表游戏服务器1代表跨服服务器
config.worldServerConfig.serverType=1;
//跨服服务器ip地址
config.worldServerConfig.ip="${deployConfig.gameServer.worldServerConfigIp}";
//跨服服务器端口号
config.worldServerConfig.port=0;
