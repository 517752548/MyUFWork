/*
 * Server基本信息
 */
config.serverType=1;
config.debug=${deployConfig.debug};
config.charset="UTF-8";
config.version="${versionConfig.serverVersion}";
config.resourceVersion="${versionConfig.resourceVersion}";
config.dbVersion="${versionConfig.dbVersion}";
config.regionId="${deployConfig.regionId}";
config.localHostId="${deployConfig.localHostId}";
config.serverGroupId="${deployConfig.serverGroupId}";
config.serverIndex=${server.id};
config.serverId="${deployConfig.localHostId}";
config.bindIp="${server.wanIp}";
config.ports="${server.wanPort}";
config.serverName="${server.name}";
config.serverHost="${server.wanIp}";
config.serverDomain="${deployConfig.name}";
config.ioProcessor=1;

config.language="${deployConfig.language}";
config.i18nDir="i18n";
config.baseResourceDir="${resource.dir}";
config.scriptDir="scripts";
config.battleReportRootPath="${battleReport.dir}";
config.battleReportServiceType=${deployConfig.gameServer.battleReportServiceType};

config.dbInitType=0;
config.dbConfigName="game_server_hibernate.cfg.xml,game_server_hibernate_query.xml";
config.battleReportDbConfigName="battle_report_ibatis_config.xml";
config.turnOnH2Cache=true;

config.flashSocketPolicy="<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"80-65535\" />\r\n </cross-domain-policy>\r\n";
config.gameServerCount=${deployConfig.gameServerCount};
//登陆类别 0:数据库验证 1:人人local验证 2:QQ验证 3:91ios登陆
config.authType=${deployConfig.authType};
config.platformName="${deployConfig.platformName}";

config.maxOnlineUsers=3000;
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
config.turnOnLocalInterface=true; //是否开服
config.requestDomain="http://${deployConfig.localDomain}/";
config.reportDomain="http://${deployConfig.localDomain}/";

config.operationCom="${deployConfig.gameServer.operationCom}";

config.probeConfig.turnOn=${deployConfig.gameServer.probeTurnOn};
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
config.wallowControlled = false;

config.scribeOnTurn = true;
