package com.imop.lj.gameserver;

import java.io.IOException;
import java.net.URL;

import org.apache.mina.core.buffer.IoBuffer;
import org.apache.mina.core.buffer.SimpleBufferAllocator;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.core.msg.recognizer.IMessageRecognizer;
import com.imop.lj.core.server.AbstractIoHandler;
import com.imop.lj.core.server.IMessageProcessor;
import com.imop.lj.core.server.ServerProcess;
import com.imop.lj.core.server.ServerStatusLog;
import com.imop.lj.core.util.MemUtils;
import com.imop.lj.gameserver.across.msg.SchedulePingWorldServer;
import com.imop.lj.gameserver.acrossserver.MinaServerClientSession;
import com.imop.lj.gameserver.acrossserver.WGlobals;
import com.imop.lj.gameserver.acrossserver.WorldServerIoHandler;
import com.imop.lj.gameserver.acrossserver.msg.GWMessageRecognizer;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.config.GameServerConfig;
import com.imop.lj.gameserver.common.msg.PlayerPingChecker;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.startup.ClientMessageRecognizer;
import com.imop.lj.gameserver.startup.GameServerIoHandler;
import com.imop.lj.gameserver.startup.GameServerRuntime;
import com.imop.lj.gameserver.startup.GameServerVersionCheck;
import com.imop.lj.gameserver.startup.MinaGameClientSession;
import com.imop.lj.gameserver.startup.ServerShutdownService;
import com.imop.lj.gameserver.status.ScheduleCheckISessions;
import com.imop.lj.gameserver.status.ScheduleReportOnlines;
import com.imop.lj.gameserver.status.ScheduleReportStatus;
import com.imop.lj.gameserver.telnet.TelnetIoHandler;
import com.imop.lj.gameserver.telnet.TelnetServerProcess;
import com.imop.lj.gameserver.telnet.command.AddVipExpCommand;
import com.imop.lj.gameserver.telnet.command.ChangeCurrencyCommand;
import com.imop.lj.gameserver.telnet.command.ChangeMallTimeLimitQueueCommand;
import com.imop.lj.gameserver.telnet.command.CharStatusCommand;
import com.imop.lj.gameserver.telnet.command.ChargeNoticeCommand;
import com.imop.lj.gameserver.telnet.command.DelItemCommand;
import com.imop.lj.gameserver.telnet.command.DirtyWordsRefreshCommand;
import com.imop.lj.gameserver.telnet.command.DirtyWordsSetCommand;
import com.imop.lj.gameserver.telnet.command.ForceKickOutCommand;
import com.imop.lj.gameserver.telnet.command.ForibedTalkTelnetCommand;
import com.imop.lj.gameserver.telnet.command.GSListCommand;
import com.imop.lj.gameserver.telnet.command.GSStatusCommand;
import com.imop.lj.gameserver.telnet.command.GameStatusCommand;
import com.imop.lj.gameserver.telnet.command.GenLogCommand;
import com.imop.lj.gameserver.telnet.command.GoodActivityAvailableCommand;
import com.imop.lj.gameserver.telnet.command.GoodActivityCloseAllGoingCommand;
import com.imop.lj.gameserver.telnet.command.GoodActivityForceEndCommand;
import com.imop.lj.gameserver.telnet.command.GoodActivityStartCommand;
import com.imop.lj.gameserver.telnet.command.GoodActivityUpdateCommand;
import com.imop.lj.gameserver.telnet.command.GroovyCommand;
import com.imop.lj.gameserver.telnet.command.HttpCommand;
import com.imop.lj.gameserver.telnet.command.ItemCommand;
import com.imop.lj.gameserver.telnet.command.KickOutCommand;
import com.imop.lj.gameserver.telnet.command.LoginCommand;
import com.imop.lj.gameserver.telnet.command.LoginOpenWallCommand;
import com.imop.lj.gameserver.telnet.command.NoticeCommand;
import com.imop.lj.gameserver.telnet.command.OnlinePlayerCommand;
import com.imop.lj.gameserver.telnet.command.OnlinePlayerSizeCommand;
import com.imop.lj.gameserver.telnet.command.ProbeCommand;
import com.imop.lj.gameserver.telnet.command.QuitCommand;
import com.imop.lj.gameserver.telnet.command.ShutdownCmd;
import com.imop.lj.gameserver.telnet.command.StopServerCommand;
import com.imop.lj.gameserver.telnet.command.WallowProtectCommand;
import com.imop.lj.probe.PIProbeCollector;

/**
 * 负责游戏服务器的初始化，基础资源的加载，服务器进程的启动
 * 
 */
public class GameServer {

	/** 日志 */
	private static final Logger logger = Loggers.gameLogger;

	/** 服务器配置信息 */
	private GameServerConfig config;

	/** 服务器进程 */
	private ServerProcess serverProcess;

	// /** http进程 */
	// private HttpServerProcessor httpServerProcess;

	/** Telnet进程 */
	private TelnetServerProcess telnetProcess;

	/**
	 * @param cfgPath
	 *            主配置文件路径
	 */
	public GameServer(String cfgPath) {
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		URL url = classLoader.getResource(cfgPath);
		config = ConfigUtil.buildConfig(GameServerConfig.class, url);
	}

	/**
	 * 初始化各种资源和服务
	 * 
	 * @throws Exception
	 */
	public void init() throws Exception {
		logger.info("Begin to initialize Globals");
		Globals.init(config);
		logger.info("Globals initialized");
		if (!new GameServerVersionCheck(config).check()) {
			throw new RuntimeException("Check version fail");
		}
		
		if(config.getWorldServerConfig().getServerType() == SharedConstants.AcrossServer_type){
			logger.info("initWorldServer()");
			this.initWorldServer();
		}else{
			logger.info("initGameServer()");
			this.initServer();
		}
	}

	private void initServer() {

		IMessageRecognizer msgRecognizer = new ClientMessageRecognizer();
		AbstractIoHandler<MinaGameClientSession> ioHandler = new GameServerIoHandler(config.getFlashSocketPolicy(), Globals.getExecutorService(),
				Globals.getSessionService());

		IMessageProcessor msgProcessor = Globals.getMessageProcessor();
		serverProcess = new ServerProcess(config.getBindIp(), config.getServerName(), config.getPorts(), msgRecognizer, ioHandler, msgProcessor,
				config.getIoProcessor(), config.getMisIps(), config.isFloodControl());
		// 新加的telnet process
		telnetProcess = new TelnetServerProcess(config.getTelnetServerName(), config.getTelnetBindIp(), config.getTelnetPort(),
				buildTelnetIoHandler());

		// HttpIoHandler httpIoHandler = buildHttpIoHandler();
		// IQueueExtMsgProcessor iextMsgProcessor =
		// buildIQueueExtMsgProcessor();
		// httpServerProcess = new
		// HttpServerProcessor(config.getHttpServerName(),
		// config.getHttpBindIp(),
		// config.getHttpPort(),httpIoHandler,iextMsgProcessor);
	}
	
	/**
	 * 初始化跨服服务器
	 * @return
	 */
	private void initWorldServer() {

		IMessageRecognizer msgRecognizer = new GWMessageRecognizer();
		AbstractIoHandler<MinaServerClientSession> ioHandler = new WorldServerIoHandler(config.getFlashSocketPolicy(), Globals.getExecutorService(),
				WGlobals.getSessionService());

		IMessageProcessor msgProcessor = WGlobals.getMessageServerProcessor();
		serverProcess = new ServerProcess(config.getBindIp(), config.getServerName(), config.getPorts(), msgRecognizer, ioHandler, msgProcessor,
				config.getIoProcessor(), config.getMisIps(),false);
		// 新加的telnet process
		telnetProcess = new TelnetServerProcess(config.getTelnetServerName(), config.getTelnetBindIp(), config.getTelnetPort(), buildWorldServerTelnetIoHandler());

	}

	public static TelnetIoHandler buildTelnetIoHandler() {
		TelnetIoHandler _ioHandler = new TelnetIoHandler();
		_ioHandler.register(new LoginCommand());
		_ioHandler.register(new QuitCommand());
		_ioHandler.register(new ShutdownCmd());
		_ioHandler.register(new HttpCommand());
		_ioHandler.register(new GSStatusCommand());
		_ioHandler.register(new KickOutCommand());
		_ioHandler.register(new ForceKickOutCommand());
		_ioHandler.register(new CharStatusCommand());
		_ioHandler.register(new WallowProtectCommand());
		_ioHandler.register(new NoticeCommand());
		_ioHandler.register(new LoginOpenWallCommand());
		_ioHandler.register(new ProbeCommand());
		// _ioHandler.register(new PrizeClearCacheCommand());
		_ioHandler.register(new GSListCommand());
		_ioHandler.register(new GameStatusCommand());
		// _ioHandler.register(new DirectChargeCommand());
		// _ioHandler.register(new SetVipLevelCommand());
		// _ioHandler.register(new OnSellCommand());
		_ioHandler.register(new StopServerCommand());
		// 游戏内活动控制
		// _ioHandler.register(new ActivityCommand());
		// _ioHandler.register(new ActivityStatusCommand());
		_ioHandler.register(new GroovyCommand()); // 外部调用，动态代码执行
		// _ioHandler.register(new BrosorUrlCommand());
		_ioHandler.register(new ForibedTalkTelnetCommand());
		_ioHandler.register(new ChangeMallTimeLimitQueueCommand());
		_ioHandler.register(new DirtyWordsRefreshCommand());
		_ioHandler.register(new DirtyWordsSetCommand());
		_ioHandler.register(new GoodActivityUpdateCommand());
		_ioHandler.register(new GoodActivityAvailableCommand());
		_ioHandler.register(new GoodActivityForceEndCommand());
		_ioHandler.register(new GoodActivityCloseAllGoingCommand());
		_ioHandler.register(new ItemCommand());
		_ioHandler.register(new DelItemCommand());
		_ioHandler.register(new ChangeCurrencyCommand());
//		_ioHandler.register(new CardActivityForceEndCommand());
//		_ioHandler.register(new CardActivityCreateCommand());
//		_ioHandler.register(new CardActivityCloseCurCommand());
//		_ioHandler.register(new TurntableActivityForceEndCommand());
//		_ioHandler.register(new TurntableActivityCreateCommand());
//		_ioHandler.register(new QQMarketTaskTargetUpdateCommand());
//		_ioHandler.register(new AddVipExpCommand());
//		_ioHandler.register(new QQChargeCommand());
//		_ioHandler.register(new QQLoginCommand());
//		_ioHandler.register(new DisbandCorpsCommand());
		_ioHandler.register(new OnlinePlayerCommand());
		_ioHandler.register(new OnlinePlayerSizeCommand());
		_ioHandler.register(new GoodActivityStartCommand());
		_ioHandler.register(new ChargeNoticeCommand());
		_ioHandler.register(new AddVipExpCommand());
		_ioHandler.register(new GenLogCommand());
		
		return _ioHandler;
	}
	
	/**
	 * 返回跨服服务器telnet
	 * @return
	 */
	private TelnetIoHandler buildWorldServerTelnetIoHandler() {
		TelnetIoHandler _ioHandler = new TelnetIoHandler();
		_ioHandler.register(new LoginCommand());
		_ioHandler.register(new QuitCommand());
		_ioHandler.register(new ShutdownCmd());
		_ioHandler.register(new HttpCommand());
		_ioHandler.register(new GSStatusCommand());
		_ioHandler.register(new KickOutCommand());
		_ioHandler.register(new ForceKickOutCommand());
		_ioHandler.register(new CharStatusCommand());
		_ioHandler.register(new WallowProtectCommand());
		_ioHandler.register(new NoticeCommand());
		_ioHandler.register(new LoginOpenWallCommand());
		_ioHandler.register(new ProbeCommand());
		_ioHandler.register(new GSListCommand());
		_ioHandler.register(new GameStatusCommand());
		_ioHandler.register(new StopServerCommand());
		_ioHandler.register(new GroovyCommand()); //外部调用，动态代码执行
//		_ioHandler.register(new CDKeyCommand()); // cdkey
//		//跨服赛
//		_ioHandler.register(new CeowarCraftWorldTelCommand());
//		_ioHandler.register(new SummitPKWorldCommand());
//		_ioHandler.register(new ModifySecPropertyCommand());
//		_ioHandler.register(new ModifySysBondCommand());
//		_ioHandler.register(new DelSecItemCommand());
//		_ioHandler.register(new ChangeCurrencyCommand());
//		_ioHandler.register(new ChatWorldCommand());
//		_ioHandler.register(new ActionPrizeProtectCommand());
		return _ioHandler;
	}

	// private HttpIoHandler buildHttpIoHandler()
	// {
	// HttpIoHandler _ioHandler = new HttpIoHandler();
	// _ioHandler.setOpen(true); //TODO 根据配置文件确定是否开启
	// return _ioHandler;
	// }
	// private IQueueExtMsgProcessor buildIQueueExtMsgProcessor(){
	// IExtResponseContext _context = new ExtResponseContext();
	// ExtMessageHandler _handler = new ExtMessageHandler(_context);
	//
	// return new QueueExtMsgProcessor(_handler);
	//
	// }
	/**
	 * 启动服务器
	 * 
	 * @throws IOException
	 */
	private void start() throws IOException {
		Globals.getLogServerService().start();
		
		Globals.getSceneService().start();

		logger.info("Begin to start Server Process");
		serverProcess.start();
		telnetProcess.start();
		logger.info("Begin to start http Server Process");
		// httpServerProcess.start();
		logger.info("Begin to start Globals");
		Globals.start();
		logger.info("Globals started");

		if(config.getWorldServerConfig().isTurnOn() && config.getWorldServerConfig().getServerType() == SharedConstants.GameServer_type){
			logger.info("Globals.getWorldServerSession().open()");
			Globals.getWorldServerSession().open();
		}
		
		logger.info("Begin to schedule fixed rate task");
		// 周期任务

		Globals.getScheduleService().scheduleWithFixedDelay(new PlayerPingChecker(Globals.getTimeService().now()), PlayerPingChecker.CHECK_PERIOD,
				PlayerPingChecker.CHECK_PERIOD);
		Globals.getScheduleService().scheduleWithFixedDelay(new ScheduleReportStatus(Globals.getTimeService().now()),
				config.getLocalReportStatusPeriod() * 1000, config.getLocalReportStatusPeriod() * 1000);
		Globals.getScheduleService().scheduleWithFixedDelay(new ScheduleReportOnlines(Globals.getTimeService().now()),
				config.getLocalReportOnlinePeriod() * 1000, config.getLocalReportOnlinePeriod() * 1000);
		// 检查非法session的定时任务
		Globals.getScheduleService().scheduleWithFixedDelay(
				new ScheduleCheckISessions(Globals.getTimeService().now()),
				config.getCheckSessionExpireTime() * 1000,
				config.getCheckSessionExpireTime() * 1000);
		// 检查和wolrdserver的连接
		Globals.getScheduleService().scheduleWithFixedDelay(
				new SchedulePingWorldServer(Globals.getTimeService().now()),
				config.getPingWorldServerPeriod() * 1000,
				config.getPingWorldServerPeriod() * 1000);

		logger.info("Scheduled fixed rate task");
		
		// 注册停服监听器，用于执行资源的销毁等停服时的处理工作
		Runtime.getRuntime().addShutdownHook(new Thread() {
			@Override
			public void run() {
				logger.info("Begin to shutdown Game Server ");
				// 设置GameServer关闭状态
				GameServerRuntime.setShutdowning();

				// 设置为STOPPING状态
				Globals.getServerStatusService().stopping();
				Globals.getServerStatusService().reportToLocal();

				Globals.getLogServerService().stop();
				Globals.getSceneService().stop();
				Globals.getTimeQueueService().stop();

				// 踢掉所有在线玩家，这个操作在shutdowning状态下不做正常下线的同步存库操作
				Globals.getOnlinePlayerService().offlineAllPlayers(PlayerExitReason.SERVER_SHUTDOWN);
				// 关闭服务器消息接受
				serverProcess.stop();
				telnetProcess.stop();
				// 关闭异步操作服务，这个操作会等5分钟，尽量确保各异步存库任务执行完再关闭线程池
				Globals.getAsyncService().stop();
				logger.info("Begin to syn save all online player data.");
				// 最后做一遍全部数据的同步存库，将PlayerDataUpdater的尚未更新的数据同步到dbs
				new ServerShutdownService().synSaveAllPlayerOnShutdown();
				logger.info("syn save complete.");
				// 关闭系统维护线程池服务
				Globals.getExecutorService().stop();

				// 设置为STOPPED状态
				Globals.getServerStatusService().stopped();
				Globals.getServerStatusService().reportToLocalSync();

//				//dataeye数据汇报关闭
//				DCAgent.stop();
				
				// 注销性能收集
				PIProbeCollector.stop();
				logger.info("Game Server shutdowned");
			}
		});
		GameServerRuntime.setOpenOn();
	}

	public static void main(String[] args) {
		logger.info("Starting Game Server");
		logger.info(MemUtils.memoryInfo());
		String configFile = "game_server.cfg.js";
		//TODO 以后要删掉
		if(args != null && args.length == 1){
			configFile = args[0];
		}
		try {
			System.setProperty("java.util.Arrays.useLegacyMergeSort", "true");
			/**
			 * 程序初始化程序缓存模块
			 */
			// TODO:今后使用CacheLoader类进行参数初始化，先使用TrackCache进行赛道初始化

			ServerStatusLog.getDefaultLog().logStarting();
			IoBuffer.setUseDirectBuffer(false);
			IoBuffer.setAllocator(new SimpleBufferAllocator());
			GameServer server = new GameServer(configFile);

			server.init();
			server.start();
			ServerStatusLog.getDefaultLog().logRunning();
		} catch (Exception e) {
			logger.error("Failed to start server", e);
			System.err.println(e);
			ServerStatusLog.getDefaultLog().logStartFail();
			System.exit(1);
			return;
		}
		logger.info(MemUtils.memoryInfo());
		logger.info("Game Server started");
	}
}
