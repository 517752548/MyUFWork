package com.imop.lj.deploy;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年1月10日 下午2:42:33
 * @version 1.0
 */

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.Reader;
import java.io.Writer;
import java.net.URL;
import java.nio.charset.Charset;
import java.text.MessageFormat;
import java.util.Properties;

import javax.script.Bindings;
import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;
import javax.script.SimpleBindings;

import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;

import com.imop.lj.deploy.config.ClientConfig;
import com.imop.lj.deploy.config.DeployConfig;
import com.imop.lj.deploy.config.GameManagerConfig;
import com.imop.lj.deploy.config.GameServerConfig;
import com.imop.lj.deploy.config.LogServerConfig;
import com.imop.lj.deploy.config.MergeConfig;
import com.imop.lj.deploy.config.Platform;
import com.imop.lj.deploy.config.ServerConfig;
import com.imop.lj.deploy.config.VersionConfig;
import com.imop.lj.deploy.genFiles.GenerateSqlFiles;
import com.imop.lj.deploy.parseChannel.ParseChannelTemplate;
import com.imop.lj.deploy.util.FileUtil;
import com.imop.lj.deploy.util.JAXBUtil;

/**
 * 生成部署配置工具
 * 
 * 
 */
public class Deploy {

	public static final String[] COPY_DIR = {"script"};
	/** 默认的配置文件 */
	private static final String DEFAULT_CONFIG = "deploy_config.xml";

	/** 合服配置文件 */
	private static final String MERGE_CONFIG = "merge_config.xml";
	/** 默认的服务器列表 */
	private static final String DEFAULT_SERVER_LIST = "/root/SERVER_LIST";
	/** 所有配置文件的根目录*/
	private static final String templateRootPath = "template";
	/** 生成sql放置文件夹 */
	public static final String SQL_ROOT = "sql";
	private static String USER_ROOT_DIR = "";
//	 private static final String DEFAULT_SERVER_LIST = "D:\\workspace\\server\\ceo\\deploy_tools\\SERVER_LIST";

	public static void main(String[] args) throws IOException {
		try {
			USER_ROOT_DIR = System.getProperty("user.dir") + File.separator + "resource" + File.separator;
			String _config = DEFAULT_CONFIG;
			String _out = ".";
			String _serverListOut = DEFAULT_SERVER_LIST;
			boolean _genGmCfg = false;
			boolean _unenc = true;
			boolean _mergeCfg = false;
			boolean _dbsql = false;
			if (args.length >= 1) {
				for (int i = 0; i < args.length; i++) {
					if (args[i].equals("-f")) {
						_config = args[i + 1];
						i++;
					} else if (args[i].equals("-d")) {
						_out = args[i + 1];
						i++;
					} else if (args[i].equals("--ue")) {
						_unenc = false;
					} else if (args[i].equals("--serverlist")) {
						_serverListOut = args[i + 1];
						i++;
					} else if (args[i].equals("--gm")) {
						_genGmCfg = true;
					}else if (args[i].equals("--merge")) {
						_mergeCfg = true;
					} else if(args[i].equals("--sql")) {
						_dbsql = true;
					}
				}
			}
			File _outDir = null;
			if (_out.equals(".")) {
				_out = System.getProperty("user.dir");
				_outDir = new File(_out);
			} else {
				_outDir = new File(_out);
				FileUtil.createDir(_outDir);
			}

			// 初始化
			VersionConfig _versionConfig = loadVersionConfig("version.js");
			System.out.println("Config file:" + _config);
			System.out.println("Output dir :" + _out);
			// 通过xml生成DeployConfig对象
			DeployConfig _deployConfig = parseDeployConfig(_config);

			if (_deployConfig == null) {
				System.err.println("Failed to parse the config xml [" + _config + "]");
				System.exit(1);
			}

			// 域名的目录
			File _configOut = new File(_outDir, "conf");
			FileUtil.delete(_configOut);
			FileUtil.createDir(_configOut);
			// System.out.println("Generate config files for " + _deployConfig.getName());
			System.out.println("Generate config files for " + "conf");

			initVelocity();

			// 文件根目录
			String _templateRootPath = ParseChannelTemplate.getTemplateRootPathByChannelName(templateRootPath, _deployConfig);
			if (_genGmCfg) {
				generateStaticGameManagerConfigFile(_versionConfig, _configOut, _deployConfig, _templateRootPath);
			}
			if(_mergeCfg){
				MergeConfig mergeConfig = parseMergeConfig(MERGE_CONFIG);
				generateMergeDbConfigFile(_versionConfig, _configOut, mergeConfig, _templateRootPath);
				System.out.println(mergeConfig);
			}
			
			// 生成各Server的配置
			generateServerConfig(_versionConfig, _configOut, _deployConfig, _deployConfig.getLogServer(), _unenc);
			generateServerConfig(_versionConfig, _configOut, _deployConfig, _deployConfig.getGameServer(), _unenc);
			
			// XXX 2014-3-27新增 将logServer的配置文件拷贝到gameserver中，因为合并了
			copyLogServerFileToGameServer(_configOut, _deployConfig);
			/**
			 *  生成sql文件
			 */
//			ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
//			URL url = classLoader.getResource("template");
//			System.out.println("========" + url == null ? "null" : url.getPath());
			
			if(_dbsql) {
//				String serverId = _deployConfig.getName().split("\\.")[0];
				GenerateSqlFiles.generateSqlFiles(_versionConfig, _configOut,_deployConfig, "sql" );
			}

			// 创建客户端的配置
			if (_deployConfig.getClientConfig() != null) {
				System.out.println("Generate config files for client");
				generateStaticServerConfig(_versionConfig, _configOut, _deployConfig, _templateRootPath);
			}
			File _zipOut = new File(_outDir, _deployConfig.getName() + ".zip");
			FileUtil.zip(_configOut, _zipOut);
			System.out.println("Generate zip file [" + _zipOut + "]");

			// 创建资源列表
			File _serverListFile = new File(_serverListOut);
			generateServerList(_deployConfig, _serverListFile);
		} catch (Exception e) {
			e.printStackTrace();
			System.err.println("ERROR:" + e.getMessage());
			System.exit(1);
		}
	}
	
	/**
	 * 将logserver的配置文件拷贝到gameserver中，因为合并了
	 * @param _configOut
	 * @param _deployConfig
	 */
	private static void copyLogServerFileToGameServer(File _configOut, DeployConfig _deployConfig) {
		String gameServerName = _deployConfig.getGameServer().getServerName();
		File gameServerOutDir = new File(_configOut, gameServerName + "_" + _deployConfig.getGameServer().getId()); 
		String gameServerOutPath = gameServerOutDir.getPath() + File.separator + "config" + File.separator;
		
		String logServerName = _deployConfig.getLogServer().getServerName();
		File logFile1 = new File(_configOut, logServerName + File.separator + "config" + File.separator + "log_ibatis_config.xml");
		File logFile2 = new File(_configOut, logServerName + File.separator + "config" + File.separator + "log_server.cfg.js");
		
		System.out.println("logFile1=" + logFile1.getPath() + " TO " + gameServerOutPath);
		System.out.println("logFile2=" + logFile2.getPath() + " TO " + gameServerOutPath);
		FileUtil.copyFile(logFile1, gameServerOutPath);
		FileUtil.copyFile(logFile2, gameServerOutPath);
	}

	private static void generateServerList(DeployConfig _deployConfig, File out) {
		System.out.println("Generate server list file [" + out + "] begin");
		StringBuilder _serverListsb = new StringBuilder();
		{
			// log
			LogServerConfig _log = _deployConfig.getLogServer();
			addServerList(_log.getLanIp(), _log.getServerName(), _serverListsb);
		}

		{
			// game servers
			GameServerConfig _gameServer = _deployConfig.getGameServer();
			addServerList(_gameServer.getLanIp(), _gameServer.getServerName() + "_" + _gameServer.getId(), _serverListsb);
		}

		{
			// client
			ClientConfig _clientConfig = _deployConfig.getClientConfig();
			addServerList(_clientConfig.getIp(), _clientConfig.getResourceUrl(), _serverListsb);
		}

		{
			// domain
			final String domainName = _deployConfig.getName();
			_serverListsb.append(domainName).append(" domain");
		}

		OutputStreamWriter _outStream = null;
		try {
			_outStream = new OutputStreamWriter(new FileOutputStream(out), "UTF-8");
			_outStream.write(_serverListsb.toString());
			System.out.println("Generate server list file [" + out + "] end");
		} catch (Exception e) {
			System.err.println("Generate server list file fail [" + e + "]");
		} finally {
			if (_outStream != null) {
				try {
					_outStream.close();
				} catch (IOException e) {
				}
			}
		}

	}

	private static void addServerList(String lanIp, String serverName, StringBuilder sb) {
		sb.append(lanIp);
		sb.append("\t");
		sb.append(serverName);
		sb.append("\n");
	}

	/**
	 * 加载版本号的配置文件
	 *
	 * @return
	 */
	private static VersionConfig loadVersionConfig(String versionConfigFile) {
		ScriptEngine _scriptEngine = new ScriptEngineManager().getEngineByName("JavaScript");
		if (_scriptEngine == null) {
			System.err.println("ScriptEngine is null!");
			System.exit(1);
		}
		InputStream _versionInput = Thread.currentThread().getContextClassLoader().getResourceAsStream(versionConfigFile);
		if (_versionInput == null) {
			System.err.println("Can't find the [version.js] file in the class path.");
			System.exit(1);
		}
		
		Reader _reader = null;
		VersionConfig _config = new VersionConfig();
		try {
			_reader = new InputStreamReader(_versionInput, "UTF-8");
			Bindings _bindings = new SimpleBindings();
			_bindings.put("config", _config);
			_scriptEngine.eval(_reader, _bindings);
			_config.validate();
		} catch (Exception e) {
			System.err.println("Cant't load the [version.js] because the exception [" + e + "]");
			e.printStackTrace();
			System.exit(1);
		} finally {
			if (_reader != null) {
				try {
					_reader.close();
				} catch (IOException e) {
				}
			}
		}
		return _config;
	}

	/**
	 *
	 */
	private static void initVelocity() {
		Properties _vp = new Properties();
		_vp.put("resource.loader", "class");
		_vp.put("class.resource.loader.class", "org.apache.velocity.runtime.resource.loader.ClasspathResourceLoader");
		try {
			Velocity.init(_vp);
		} catch (Exception e) {
			e.printStackTrace();
			throw new RuntimeException(e);
		}
	}

	private static void generateServerConfig(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig, ServerConfig serverConfig,
			boolean encyrptShell) {
		final String _serverName = serverConfig.getServerName();
		System.out.println("Generate config files for " + _serverName);
		if (serverConfig.getXms() <= 0) {
			throw new IllegalArgumentException("xms must be >0 server:" + _serverName);
		}
		if (serverConfig.getXmx() <= 0) {
			throw new IllegalArgumentException("xmx must be >0 server:" + _serverName);
		}
		if (serverConfig.getXss() <= 0) {
			throw new IllegalArgumentException("xss must be >0 server:" + _serverName);
		}

		File _ipDir = outRoot;
		// FileUtil.createDir(_ipDir);
		File _serverOutDir = null;
		if (serverConfig instanceof GameServerConfig) {
			// 每组服务的Game Server可能有多个,目录名后增加id进行区分
			_serverOutDir = new File(_ipDir, _serverName + "_" + serverConfig.getId());
		} else {
			_serverOutDir = new File(_ipDir, _serverName);
		}
		FileUtil.createDir(_serverOutDir);
		FileUtil.createDir(new File(_serverOutDir, "config"));
		// 创建配置文件,所有配置文件都放在config子目录中
		String[] _configs = serverConfig.getConfigs();
		
		String _templatePath = ParseChannelTemplate.getTemplateByChannelName(templateRootPath, serverConfig, deployConfig);
		for (String _config : _configs) {
			File _outFile = new File(_serverOutDir, "config" + File.separator + _config);
			// 取模板对象，这个位置，根据配置xml中的 channelName起区分
//			String _template = serverConfig.getTemplatePackage() + _config;
			String _template = _templatePath + _config;
			System.out.println("模板 路径  _template" + _template);
			generateServerConfigFile(versionConfig, _outFile, deployConfig, serverConfig, _template);
		}
		// 创建加密配置
		String _templateRootPath = ParseChannelTemplate.getTemplateRootPathByChannelName(templateRootPath, deployConfig);
		{
			File _outFile = new File(_serverOutDir, "config" + File.separator + "launch.cfg.js");
//			String _template = "template/launch.cfg.js";
			String _template = _templateRootPath + "launch.cfg.js";
			generateServerConfigFile(versionConfig, _outFile, deployConfig, serverConfig, _template);
		}

		if (encyrptShell) {
			File _outFile = new File(_serverOutDir, "launch" + ".sh");
			generateServerConfigFile(versionConfig, _outFile, deployConfig, serverConfig, _templateRootPath + "server_launch.sh.tmpl");
		} else {
			File _outFile = new File(_serverOutDir, "launch" + ".sh");
			generateServerConfigFile(versionConfig, _outFile, deployConfig, serverConfig, _templateRootPath +  "server.sh.tmpl");

			File _outbatFile = new File(_serverOutDir, "launch" + ".bat");
			generateServerConfigFile(versionConfig, _outbatFile, deployConfig, serverConfig, _templateRootPath + "server.bat.tmpl");
		}
		
		// 拷贝模板文件夹下的所有文件
		FileUtil.copyDict(USER_ROOT_DIR + _templatePath, _serverOutDir.getPath());
	}

	private static void generateServerConfigFile(VersionConfig versionConfig, File outFile, DeployConfig deployConfig, ServerConfig serverConfig,
			String configTemplate) {
		VelocityContext context = new VelocityContext();
		try {
			Writer w = new OutputStreamWriter(new FileOutputStream(outFile), "UTF-8");
			context.put("resource", deployConfig.getResConfig());
			context.put("battleReport", deployConfig.getReportConfig());
			context.put("mmo_db", deployConfig.getMmoDb());
			context.put("log_db", deployConfig.getLogDb());
			context.put("battle_report_db", deployConfig.getBattleReportDb());
			context.put("deployConfig", deployConfig);
			context.put("server", serverConfig);
			context.put("versionConfig", versionConfig);
			context.put("server_id", deployConfig.getPrefixServerName());
			Velocity.mergeTemplate(configTemplate, "UTF-8", context, w);
			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		// 拷贝模板文件夹下的所有文件
//		FileUtil.copyDict(configTemplate, outFile.getPath());
	}

	private static void generateStaticServerConfig(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig, String _templateRootPath) {
		File _ipDir = new File(outRoot, deployConfig.getClientConfig().getIp());
		FileUtil.createDir(_ipDir);
		File _staticServerOutDir = new File(_ipDir, "client");
		FileUtil.createDir(_staticServerOutDir);

		// 获取客户端配置
		ClientConfig clientCfg = deployConfig.getClientConfig();
		
		if (clientCfg == null) {
			throw new RuntimeException("客户端配置为空");
		}

		String platform = clientCfg.getOperationCom();
		String lang = deployConfig.getLanguage();

		if (platform == null || platform.isEmpty()) {
			throw new RuntimeException("client 标记中未指定运营商! 请修改 operationCom 属性");
		}

		if (lang == null || lang.isEmpty()) {
			throw new RuntimeException("deploy_config 标记中未指定语言名称");
		}

		/* 生成 config.xml */{
			// 设置模版文件名称
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/config.xml", platform, lang);
	
			File _outFile = new File(_staticServerOutDir, "config.xml");
			// 生成 config.xml 文件
			generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
		}

		/* 生成 index.html */{
			// 设置模版文件名称
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/index.html", platform, lang);

			File _outFile = new File(_staticServerOutDir, "index.html");
			// 生成 index.html 文件
			generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
		}
		/* 生成 game.html */{
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/game.html", platform, lang);
			File tmplFile = new File(tmplFilename);
			System.out.println(tmplFile.getAbsolutePath());
			
			File _outFile = new File(_staticServerOutDir, "game.html");
			// 生成 index.html 文件
			generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
		}
		
		/* 生成game_fun.js */{
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/script/game_fun.js", platform, lang);
			ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
			URL url = classLoader.getResource(tmplFilename);
			if (url != null) {
				FileUtil.createDir(new File(_staticServerOutDir + File.separator + "script"));
				File _outFile = new File(_staticServerOutDir + File.separator + "script", "game_fun.js");
				// 生成 index.html 文件
				generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
			}
		}
		
		/* 生成game_fun.js */{
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/script/qzone.js", platform, lang);
			ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
			URL url = classLoader.getResource(tmplFilename);
			if (url != null) {
				FileUtil.createDir(new File(_staticServerOutDir + File.separator + "script"));
				File _outFile = new File(_staticServerOutDir + File.separator + "script", "qzone.js");
				// 生成 index.html 文件
				generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
			}
		}
		
//		String scriptFile = MessageFormat.format("template" + File.separator + "client" + File.separator + "platform" + File.separator + "{0}" + File.separator + "{1}", platform, lang);
//		if(new File(scriptFile).exists()){
//			System.out.println("ddddddddddddddddd");
//		}else{
//			System.out.println("eeeeeeeeeeeeeeeee");
//		}
		
		
		// /* 生成index2.html */ {
		// String tmplFilename = MessageFormat.format(
		// "template/client/platform/{0}/{1}/index2.html", platform, lang);
		//
		// File _outFile = new File(_staticServerOutDir, "index2.html");
		// // 生成 index.html 文件
		// generateStaticServerConfigFile(
		// versionConfig, _outFile, deployConfig, tmplFilename);
		// }

		/* 生成 facebook-index.html */{
			// 设置模版文件名称
			String tmplFilename = MessageFormat.format(_templateRootPath + "template/client/platform/{0}/{1}/facebook-index.html", platform, lang);

			if ((new File(tmplFilename)).exists()) {
				// 目标文件
				File _outFile = new File(_staticServerOutDir, "facebook-index.html");

				// 生成 facebook-index 页面!
				// XXX 注意, 不是所有运营商都支持 Facebook 的!
				// 如果没有 facebook-index.html 文件,
				// 那么就不执行下面的操作
				generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
			}
		}
		
//		String copyFile = MessageFormat.format("template" + File.separator + "client" + File.separator + "platform" + File.separator + "{0}" + File.separator + "{1}", platform, lang);
//		if ((new File(copyFile)).exists()) {
//			System.out.println("bbbbb" + copyFile );
//		}
//		
//		// 拷贝模板文件夹下的所有文件
//		System.out.println("aaaaaa" + copyFile );
//		FileUtil.copyDict(copyFile, _staticServerOutDir.getPath());
	}

	@SuppressWarnings("unused")
	private static void generateStaticServerConfig(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig) {
		File _ipDir = new File(outRoot, deployConfig.getClientConfig().getIp());
		FileUtil.createDir(_ipDir);
		File _staticServerOutDir = new File(_ipDir, "client");
		FileUtil.createDir(_staticServerOutDir);

		// 获取客户端配置
		ClientConfig clientCfg = deployConfig.getClientConfig();

		if (clientCfg == null) {
			throw new RuntimeException("客户端配置为空");
		}

		String platform = clientCfg.getOperationCom();
		String lang = deployConfig.getLanguage();

		if (platform == null || platform.isEmpty()) {
			throw new RuntimeException("client 标记中未指定运营商! 请修改 operationCom 属性");
		}

		if (lang == null || lang.isEmpty()) {
			throw new RuntimeException("deploy_config 标记中未指定语言名称");
		}

		/* 生成 config.xml */{
			// 设置模版文件名称
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/config.xml", platform, lang);

			File _outFile = new File(_staticServerOutDir, "config.xml");
			// 生成 config.xml 文件
			generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
		}

		/* 生成 index.html */{
			// 设置模版文件名称
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/index.html", platform, lang);

			File _outFile = new File(_staticServerOutDir, "index.html");
			// 生成 index.html 文件
			generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
		}
		/* 生成 game.html */{
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/game.html", platform, lang);

			File _outFile = new File(_staticServerOutDir, "game.html");
			// 生成 index.html 文件
			generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
		}
		// /* 生成index2.html */ {
		// String tmplFilename = MessageFormat.format(
		// "template/client/platform/{0}/{1}/index2.html", platform, lang);
		//
		// File _outFile = new File(_staticServerOutDir, "index2.html");
		// // 生成 index.html 文件
		// generateStaticServerConfigFile(
		// versionConfig, _outFile, deployConfig, tmplFilename);
		// }

		/* 生成 facebook-index.html */{
			// 设置模版文件名称
			String tmplFilename = MessageFormat.format("template/client/platform/{0}/{1}/facebook-index.html", platform, lang);

			if ((new File(tmplFilename)).exists()) {
				// 目标文件
				File _outFile = new File(_staticServerOutDir, "facebook-index.html");

				// 生成 facebook-index 页面!
				// XXX 注意, 不是所有运营商都支持 Facebook 的!
				// 如果没有 facebook-index.html 文件,
				// 那么就不执行下面的操作
				generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, tmplFilename);
			}
		}
	}
	private static void generateMergeDbConfigFile(VersionConfig versionConfig,  File outRoot, MergeConfig mergeConfig, String _templateRootPath) {

		File _mergeDir = new File(outRoot, "mergedb");
		FileUtil.createDir(_mergeDir);
		File _outFromDbFile = new File(_mergeDir, "from_db.cfg.xml");
		File _outToDbFile = new File(_mergeDir, "to_db.cfg.xml");
		File _outNewDbFile = new File(_mergeDir, "new_db.cfg.xml");
		File _outMergeConfigFile = new File(_mergeDir, "mergedb.cfg.js");
		File _outMergeLogConfigFile = new File(_mergeDir, "log4j.properties");

		// generate gm.cfg.js
		String _outFromDbTemplateFile = _templateRootPath + "mergedb/from_db.cfg.xml";
		String _outToDbTemplateFile = _templateRootPath + "mergedb/to_db.cfg.xml";
		String _outNewDbTemplateFile = _templateRootPath + "mergedb/new_db.cfg.xml";
		String _outMergeConfigTemplateFile = _templateRootPath + "mergedb/mergedb.cfg.js";
		String _outMergeLogConfigTemplateFile = _templateRootPath + "mergedb/log4j.properties";

		VelocityContext context = new VelocityContext();
		context.put("mergeConfig", mergeConfig);
		context.put("versionConfig", versionConfig);
		context.put("fromDbConfig", mergeConfig.getFromDbConfig());
		context.put("toDbConfig", mergeConfig.getToDbConfig());
		context.put("newDbConfig", mergeConfig.getNewDbConfig());
		Writer w = null;
		try {
			w = new OutputStreamWriter(new FileOutputStream(_outFromDbFile), "UTF-8");
			Velocity.mergeTemplate(_outFromDbTemplateFile, "UTF-8", context, w);

			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}

		try {
			w = new OutputStreamWriter(new FileOutputStream(_outToDbFile), "UTF-8");
			Velocity.mergeTemplate(_outToDbTemplateFile, "UTF-8", context, w);

			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}

		try {
			w = new OutputStreamWriter(new FileOutputStream(_outNewDbFile), "UTF-8");
			Velocity.mergeTemplate(_outNewDbTemplateFile, "UTF-8", context, w);

			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}

		try {
			w = new OutputStreamWriter(new FileOutputStream(_outMergeConfigFile), "UTF-8");
			Velocity.mergeTemplate(_outMergeConfigTemplateFile, "UTF-8", context, w);

			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}

		try {
			w = new OutputStreamWriter(new FileOutputStream(_outMergeLogConfigFile), "UTF-8");
			Velocity.mergeTemplate(_outMergeLogConfigTemplateFile, "UTF-8", context, w);

			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		
		// 拷贝模板文件夹下的所有文件
		FileUtil.copyDict(USER_ROOT_DIR + _templateRootPath + "mergedb", _mergeDir.getPath());
	}

	private static void generateStaticServerConfigFile(VersionConfig versionConfig, File outFile, DeployConfig deployConfig, String configTemplate) {
		VelocityContext context = new VelocityContext();
		try {
			Writer w = new OutputStreamWriter(new FileOutputStream(outFile), "UTF-8");
			context.put("deployConfig", deployConfig);
			context.put("versionConfig", versionConfig);
			context.put("getScript", "$.getScript(qqScriptUrl);");
			context.put("server_id", deployConfig.getPrefixServerName());
			Velocity.mergeTemplate(configTemplate, "UTF-8", context, w);
			w.close();
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
	}

	private static void generateStaticGameManagerConfigFile(VersionConfig versionConfig, File outRoot, DeployConfig deployConfig
			, String rootPath) {
		GameManagerConfig _gmConfig = GameManagerConfig.buildFromDeployConfig(deployConfig);
		System.out.println("Generate config files for gmserver");
		
		File _gmDir = new File(outRoot, "gmserver");
		FileUtil.createDir(_gmDir);
		// generate gm.cfg.js
		File _outFile = new File(_gmDir, "gm.cfg.js");
		generateStaticServerConfigFile(versionConfig, _outFile, deployConfig, rootPath + "gmserver/gm.cfg.js");

		// generate dbconf
		File _confdir = new File(_gmDir, "conf");
		FileUtil.createDir(_confdir);
		File _dbCfgfdir = new File(_confdir, "db" + deployConfig.getRegionId());
		FileUtil.createDir(_dbCfgfdir);
		try {

			String _deployName = deployConfig.getName();
			File _gmCfgOutDir = new File(_dbCfgfdir, _deployName.substring(0, _deployName.indexOf('.')) + "_db.xml");

			VelocityContext context = new VelocityContext();

			Writer w = new OutputStreamWriter(new FileOutputStream(_gmCfgOutDir), "UTF-8");
			context.put("gmMmoDb", _gmConfig.getGmMmoDBConfig());
			context.put("gmLogDb", _gmConfig.getGmLogDBConfig());
			Velocity.mergeTemplate(rootPath + "gmserver/gm_db.cfg.xml", "UTF-8", context, w);
			w.close();

		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		// 拷贝模板文件夹下的所有文件
		FileUtil.copyDict(USER_ROOT_DIR + rootPath + "gmserver", _confdir.getPath());
	}

	/**
	 * 从指定的配置文件中解析
	 *
	 * @param config
	 * @return
	 */
	private static DeployConfig parseDeployConfig(String config) {
		DeployConfig _deployConfig = null;
		Reader _configReader = null;
		try {
			_configReader = new InputStreamReader(new FileInputStream(config), Charset.forName("UTF-8"));
			_deployConfig = JAXBUtil.read(DeployConfig.class, _configReader);

			String platformName = _deployConfig.getPlatformName().trim();
			Platform platform = null;
			for (Platform p : Platform.values()) {
				if (p.getName().equalsIgnoreCase(platformName)) {
					platform = p;
					break;
				}
			}
			if (platform == null) {
				platform = Platform.CN_RENREN;
				_deployConfig.setPlatformName(Platform.CN_RENREN.getName());
			}
			_deployConfig.setAuthType(platform.getAuthType());
		} catch (FileNotFoundException e) {
			System.err.println("Can't locate the config xml file [" + config + "]");
			System.exit(1);
		} finally {
			try {
				_configReader.close();
			} catch (IOException e) {
			}
		}
		return _deployConfig;
	}

	/**
	 * 从指定的配置文件中解析
	 *
	 * @param config
	 * @return
	 */
	private static MergeConfig parseMergeConfig(String config) {
		MergeConfig _mergeConfig = null;
		Reader _configReader = null;
		try {
			_configReader = new InputStreamReader(new FileInputStream(config), Charset.forName("UTF-8"));
			_mergeConfig = JAXBUtil.read(MergeConfig.class, _configReader);

		} catch (FileNotFoundException e) {
			System.err.println("Can't locate the config xml file [" + config + "]");
			System.exit(1);
		} finally {
			try {
				_configReader.close();
			} catch (IOException e) {
			}
		}
		return _mergeConfig;
	}
}
