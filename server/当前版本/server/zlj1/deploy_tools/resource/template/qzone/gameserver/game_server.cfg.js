/*
 * Server基本信息
 */
config.serverType=1;
// 是否debug
config.debug=${deployConfig.debug};
//配置文件是否加密
config.encryptResource=${versionConfig.encryptResource};
// 字符集编码格式
config.charset="UTF-8";
// 服务器版本号
config.version="${versionConfig.serverVersion}";
// 资源版本号
config.resourceVersion="${versionConfig.resourceVersion}";
// 数据库版本号
config.dbVersion="${versionConfig.dbVersion}";
// 大区ID
config.regionId="${deployConfig.regionId}";
// 本机id
config.localHostId="${deployConfig.localHostId}";
// 第几组服ID
config.serverGroupId="${deployConfig.serverGroupId}";
// 服id
config.serverIndex=${server.id};
//
config.serverId="${deployConfig.localHostId}";
// 外网的绑定IP
config.bindIp="0.0.0.0";
// 外网端口，支持多端口
config.ports="${server.wanPort}";
//
config.serverName="${server.name}";
// 
config.serverHost="${server.wanIp}";
//
config.serverDomain="${deployConfig.name}";
//
config.ioProcessor=1;

// 多语言
config.language="${deployConfig.language}";
// 国际化语言目录
config.i18nDir="i18n";
// 加载策划文件路径
config.baseResourceDir="${resource.dir}";
// 加载scriptes路径
config.scriptDir="scripts";
//
config.battleReportRootPath="${battleReport.dir}";
//
config.battleReportServiceType=${deployConfig.gameServer.battleReportServiceType};

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
config.gameServerCount=${deployConfig.gameServerCount};
//登陆类别 0:数据库验证 1:人人local验证 2:QQ验证 3:91ios登陆
config.authType=${deployConfig.authType};
//
config.platformName="${deployConfig.platformName}";
//
config.maxOnlineUsers=2000;
//
config.openNewerGuide=1;

/*
 *配置Log Server
 */
config.logConfig.logServerIp="${deployConfig.logServer.lanIp}";
config.logConfig.logServerPort=${deployConfig.logServer.lanPort};

/*
 *配置Telnet
 */
config.telnetServerName="GameServer_telnet";
config.telnetBindIp="${server.lanIp}";
config.telnetPort=${server.telnetPort};

/*
 *配置local接口相关参数
 */
config.localReportOnlinePeriod=300;
config.localReportStatusPeriod=60;
config.turnOnLocalInterface=false; //qq不用local，所以关闭
config.requestDomain="http://${deployConfig.localDomain}/";
config.reportDomain="http://${deployConfig.localDomain}/";

config.operationCom="${deployConfig.gameServer.operationCom}";

config.probeConfig.turnOn=true;
config.chargeEnabled=${deployConfig.gameServer.chargeEnabled};
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

config.apiRequestDomain="http://${deployConfig.apiDomain}/";

/** 是否开启给kaiying发送log*/
config.kaiyingLog = ${deployConfig.gameServer.kaiyingLog};

/** 先把采样打开，调试用，等正式上线需要关闭XXX */
config.collectStrategy = false;

config.scribeServerIp = "${deployConfig.scribeIp}";

config.probeConfig.reporterIp="${deployConfig.scribeIp}";

/**跨服战相关配置*/
//跨服服务器功能开关true表示需要连接跨服服务器false不需要连接跨服服务器
config.worldServerConfig.turnOn=${deployConfig.gameServer.worldServerConfigTurnOn};
//此服是不是跨服服务器0代表游戏服务器1代表跨服服务器
config.worldServerConfig.serverType=${deployConfig.gameServer.serverType};
//跨服服务器ip地址
config.worldServerConfig.ip="${deployConfig.gameServer.worldServerConfigIp}";
//跨服服务器端口号
config.worldServerConfig.port=${deployConfig.gameServer.worldServerConfigPort};
