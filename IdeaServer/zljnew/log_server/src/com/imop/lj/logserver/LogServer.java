package com.imop.lj.logserver;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.URL;

import javax.script.Bindings;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.ScriptException;
import javax.script.SimpleBindings;

import org.apache.mina.core.buffer.IoBuffer;
import org.apache.mina.core.buffer.SimpleBufferAllocator;
import org.apache.mina.filter.codec.ProtocolCodecFilter;
import org.apache.mina.transport.socket.DatagramSessionConfig;
import org.apache.mina.transport.socket.nio.NioDatagramAcceptor;
import org.slf4j.Logger;

import com.imop.lj.core.codec.GameCodecFactory;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.server.ServerStatusLog;
import com.imop.lj.logserver.common.Globals;
import com.imop.lj.logserver.createtable.CreateTabaleTask;
import com.imop.lj.logserver.createtable.CreateTimer;
import com.imop.lj.logserver.createtable.ITableCreator;
import com.imop.lj.logserver.dao.DBConnection;
import com.imop.lj.logserver.telnet.TelnetIoHandler;
import com.imop.lj.logserver.telnet.TelnetServerProcess;
import com.imop.lj.logserver.telnet.command.LGStatusCommand;
import com.imop.lj.logserver.telnet.command.LoginCommand;
import com.imop.lj.logserver.telnet.command.QuitCommand;
import com.imop.lj.logserver.util.ResourcePathUtil;

/**
 * 定义LogServer,源自天书log_server的同名类,负责解析配置,并启动服务器
 *
 * @author <a href="mailto:fan.lin@opi-corp.com">lin fan<a>
 * @author <a href="mailto:yong.fang@opi-corp.com">fang yong<a>
 * @author Fancy
 */
public class LogServer {

	/** 日志服务器配置文件名,该文件应该在Classpath中可以找到 */
	private static final String LOG_SERVER_CFG_JS = "log_server.cfg.js";
	private static final Logger logger = org.slf4j.LoggerFactory
			.getLogger(LogServer.class);

	/** 日志服务器配置 */
	private static final LogServerConfig config = new LogServerConfig();

	/** 日志表创建器 */
	private ITableCreator iTableCreator;

	/** 日志消息处理接受器 */
	private NioDatagramAcceptor acceptor;

	/** Telnet进程*/
	private static TelnetServerProcess telnetProcess;

	public LogServer() {

	}

	public static LogServerConfig getLogServerConfig() {
		return LogServer.config;
	}

	/**
	 * 执行初始化操作
	 *
	 * @exception RuntimeException
	 *                如果在初始化的过程中出现错误,会抛出此异常
	 */
	public void initialize() {
		if (logger.isInfoEnabled()) {
			logger.info("Mina config:Disable Direct Byte Buffer and Buffer pool.");
			logger.info("Mina config:User SimpleByteBufferAllocator.");
		}
		IoBuffer.setUseDirectBuffer(false);
		IoBuffer.setAllocator(new SimpleBufferAllocator());

		final String _logConfigFile = ResourcePathUtil
				.getRootPathWithoutSlash(LOG_SERVER_CFG_JS);

		if (_logConfigFile == null) {
			throw new RuntimeException("Can't locate the config file "
					+ LOG_SERVER_CFG_JS + " in the classpath.");
		}

		if (logger.isInfoEnabled()) {
			logger.info("Load the config from file [" + _logConfigFile + "]");
		}
		runConfigScript(_logConfigFile);

		// 初始化数据库连接
		final URL _ibatisConfigFile = ResourcePathUtil
				.getRootPath(LogServer.config.getIbatisConfig());
		if (_ibatisConfigFile == null) {
			throw new RuntimeException("Can't locate the ibatis config file "
					+ LogServer.config.getIbatisConfig() + " in the classpath.");
		}

		DBConnection.initDBConnection(_ibatisConfigFile);

		if (DBConnection.getInstance().getTypes().isEmpty()) {
			if (logger.isWarnEnabled()) {
				logger.warn("No log type found.");
			}
		}

		iTableCreator = LogServer.config.getTableCreator();

		iTableCreator.setBaseTableNames(DBConnection.getInstance().getTypes());

		if (logger.isInfoEnabled()) {
			logger.info("Table creator class:" + this.iTableCreator);
			logger.info("Create log tables");
		}

		iTableCreator.buildTable();

		CreateTimer.scheduleTask(new CreateTabaleTask(iTableCreator),
				LogServer.config.getCreateTableTaskDelay(), LogServer.config
						.getCreateTableTaskPeriod());

		if (logger.isInfoEnabled()) {
			logger.info("Schedule create new log table task [Delay:"
					+ LogServer.config.getCreateTableTaskDelay() + "ms,period:"
					+ LogServer.config.getCreateTableTaskPeriod() + "ms]");
		}

		telnetProcess = new TelnetServerProcess(config.getTelnetServerName(),
				config.getTelnetBindIp(), config.getTelnetPort(),
				buildTelnetIoHandler());
		Globals.init(config);
	}

	/**
	 * 启动服务
	 *
	 * @throws IOException
	 */
	public void start() throws IOException {
		// 启动心跳线程
		Globals.getHeartbeatThread().start();
		
		acceptor = new NioDatagramAcceptor();
		
		DatagramSessionConfig sessionConfig = acceptor.getSessionConfig();
		sessionConfig.setReuseAddress(true);
		sessionConfig.setReadBufferSize(IMessage.UDP_READBUFF_SIZE);
		sessionConfig.setReceiveBufferSize(IMessage.UDP_READBUFF_SIZE);
		
		if (logger.isInfoEnabled()) {
			logger.info("[#LogServer.LogServer.start] [Default receive buffer size"	+ IMessage.UDP_READBUFF_SIZE + "]");
		}

		// 停机时停止主线程的处理
		Globals.getShutdownHooker().register(new Runnable() {
			@Override
			public void run() {
				acceptor.unbind();
				telnetProcess.stop();
				Globals.getHeartbeatThread().shutdown();
			}
		});

		// 增加JVM停机时的处理
		Runtime.getRuntime().addShutdownHook(new Thread() {
			@Override
			public void run() {
				try {
					ServerStatusLog.getDefaultLog().logStoppping();
					Globals.getShutdownHooker().run();
				} finally {
					ServerStatusLog.getDefaultLog().logStopped();
				}
			}
		});

		// Mina的socket接收缓冲和Session的接收缓冲是同一个,暂时先去掉改配置,等找到好办法在改(在量大的情况下会可能会丢包)
		// cfg.getSessionConfig().setReceiveBufferSize(recBufferSize*8);
		if (logger.isInfoEnabled()) {
			logger.info("[#LogServer.LogServer.start] [New receive buffer size"	+ IMessage.UDP_READBUFF_SIZE + "]");
		}
		acceptor.getFilterChain().addLast(
				"codec",
				new ProtocolCodecFilter(new GameCodecFactory(LogServer.config
						.getMessageRecognizer())));

		acceptor.setHandler(LogServer.config.getLogMessageHandler());
		
		// 启动log服务器监听
		InetSocketAddress _bindAddress = new InetSocketAddress(InetAddress
				.getByName(LogServer.config.getBindIp()), LogServer.config
				.getPort());
		acceptor.bind(_bindAddress);
		if (logger.isInfoEnabled()) {
			logger.info("Log server listening on " + _bindAddress.toString());
		}
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		LogServer _server = new LogServer();
		try {
			ServerStatusLog.getDefaultLog().logStarting();
			_server.initialize();
			_server.start();
			telnetProcess.start();
			ServerStatusLog.getDefaultLog().logRunning();
		} catch (Exception e) {
			ServerStatusLog.getDefaultLog().logStartFail();
			e.printStackTrace();
			System.exit(1);
		}
	}

	/**
	 * 执行配置脚本
	 *
	 * @param logConfigFile
	 */
	private void runConfigScript(String logConfigFile) {
		Bindings _bindings = new SimpleBindings();
		_bindings.put("config", LogServer.config);

		ScriptEngineManager _factory = new ScriptEngineManager();
		ScriptEngine _scriptEngine = _factory.getEngineByName("JavaScript");
		Reader _reader = null;
		try {
			_reader = new InputStreamReader(new FileInputStream(logConfigFile),
					"UTF-8");
			_scriptEngine.eval(_reader, _bindings);
			LogServer.config.validate();
		} catch (IOException ioe) {
			throw new RuntimeException("Load the log server config file ["
					+ logConfigFile + "] fail.", ioe);
		} catch (ScriptException e) {
			throw new RuntimeException("Run the log server config file ["
					+ logConfigFile + "] fail.", e);
		} finally {
			if (_reader != null) {
				try {
					_reader.close();
				} catch (IOException e) {
				}
			}
		}
	}

	public static TelnetIoHandler buildTelnetIoHandler() {
		TelnetIoHandler _ioHandler = new TelnetIoHandler();
		_ioHandler.register(new LGStatusCommand());
		_ioHandler.register(new LoginCommand());
		_ioHandler.register(new QuitCommand());
		return _ioHandler;
	}
}
