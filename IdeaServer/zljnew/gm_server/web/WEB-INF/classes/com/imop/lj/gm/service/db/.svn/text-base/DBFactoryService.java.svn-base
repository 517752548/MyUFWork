package com.imop.lj.gm.service.db;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Properties;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import net.sf.json.JSONObject;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.AnnotationConfiguration;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import com.imop.lj.common.exception.ConfigException;
import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.db.model.CDKeyEntity;
import com.imop.lj.db.model.CDKeyPlansEntity;
import com.imop.lj.db.model.DbVersion;
import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.db.model.DoingQuestEntity;
import com.imop.lj.db.model.FinishedQuestEntity;
import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.db.model.MallEntity;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.db.model.QQMarketTaskTargetEntity;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.db.model.SceneEntity;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.db.model.WorldGiftEntity;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.model.notice.GameNotice;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;
import com.imop.lj.gm.utils.ErrorsUtil;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.platform.core.log.Loggers;

/**
 * 管理数据库服务器Service
 *
 */
public class DBFactoryService {
	
	public GmConfig gmConfig;
	public GmConfig getGmConfig() {
		return gmConfig;
	}

	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/** Hibernate sessionFactory */
	private static SessionFactory sessionFactory = null;

	/** 存放sessionFactory的HashMap,key是数据库服务器的id,value是对应配置的sessionFactory */
	private static TreeMap<String, TreeMap<String, SessionFactory>> mapRSF = new TreeMap<String, TreeMap<String, SessionFactory>>();

	/** 数据库服务器列表 */
	private static Map<String, List<DBServer>> dbServerList = new TreeMap<String, List<DBServer>>();

	/** 大区对象信息列表 */
	private static Map<String, String> regionMap = new TreeMap<String, String>();

	/** GM数据库DAO */
	private static ParamGenericDAO GMDAO;

	/** 数据库类型 */
	private static final int GM = 0;
	private static final int GAME = 1;
	private static final int LOG = 2;

	public static Map<String, String> getRegionMap() {

		return Collections.unmodifiableMap(regionMap);
	}

	public static void setRegionMap(Map<String, String> regionMap) {
		DBFactoryService.regionMap = regionMap;
	}

	private String rootPath = LangUtils.getRootPath();

	/** DBFactoryService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(DBFactoryService.class);

	/**
	 * 加载数据库的db.xml,初始化数据库
	 */
	public DBFactoryService() {

	}

	public List<File> readDBFile() {
		readRegionXML(rootPath + "/conf/region.xml");
		List<File> fileDirList = new ArrayList<File>();
		File dir = new File(rootPath + "/conf/");
		File file[] = dir.listFiles();
		if (file == null)
			return null;
		for (int i = 0; i < file.length; i++) {
			if (file[i].isDirectory() && file[i].getName().startsWith("db")) {
				fileDirList.add(file[i]);
			}
		}
		System.out.println("+++++++++++++++++++++++++++++++++++");
		for(File fileDir : fileDirList){
			System.out.println("server config fileDir: " + fileDir.getAbsolutePath());
		}
		System.out.println("+++++++++++++++++++++++++++++++++++");
		return fileDirList;
	}

	public void traverseDBconf(List<File> fileDirList) {
		for (int i = 0; i < fileDirList.size(); i++) {
			File dir =  fileDirList.get(i);
			File fileDir[] = dir.listFiles();
			TreeMap<String, SessionFactory> mapSF = new TreeMap<String, SessionFactory>();
			List<DBServer> dbServers = new ArrayList<DBServer>();
			String drName = dir.getName();
			String regionId;
			if (drName.endsWith("gm")) {
				// 默认无大区
				regionId = "0";
			} else {
				regionId = drName.replace("db", "");
			}

			for (int j = 0; j < fileDir.length; j++) {
				File file = fileDir[j];
				System.out.println("===================================");
				System.out.println("server config file" + j + ": " + file.getAbsolutePath());
				if (file.getName().endsWith("db.xml")) {
					readDBXML(file.getAbsolutePath(), mapSF, dbServers);
				}
				System.out.println("===================================");
			}
			String regex = "\\d+";
			Pattern p = Pattern.compile(regex);
			Matcher m = p.matcher(regionId);

			if (m.find()) {
				mapRSF.put(regionId, mapSF);
				dbServerList.put(regionId, dbServers);
			}
		}
		//验证gm库配置的dbName是否正确
		validateGmDbName();
		/** 初始化GM DAO */
		createGMDAO();
	}

	private void validateGmDbName() {
		List<DBServer> gmDbList = dbServerList.get("0");
		if(!gmDbList.get(0).getDbName().equals(gmConfig.gmDbName)){
			throw new ConfigException("The gmDbName of gm.cfg.js configuration isn't consistent with the dbName of db library configuration !");
		}
	}

	private void readRegionXML(String path) {
		Document root = getDoc(path);
		NodeList regions = root.getElementsByTagName("region");
		for (int i = 0; i < regions.getLength(); i++) {
			Element region = (Element) regions.item(i);
			regionMap.put(region.getAttribute("id"), region
					.getAttribute("name"));
		}
	}

	private void readDBXML(String path, Map<String, SessionFactory> mapSF,
			List<DBServer> dbServers) {
		Document root = getDoc(path);
		NodeList databaseList = root.getElementsByTagName("database");
		for (int i = 0; i < databaseList.getLength(); i++) {
			Element database = (Element) databaseList.item(i);
			DBServer dbSvr = new DBServer();
			dbSvr.setId(database.getAttribute("id"));
			dbSvr.setRegionId(database.getAttribute("typeId"));
			dbSvr.setDbServerName(database.getAttribute("dbSrvName"));
			dbSvr.setServerId(database.getAttribute("svrId"));
			dbSvr.setServerURL(database.getAttribute("svrUrl"));
			dbSvr.setServerName(database.getAttribute("svrName"));
			dbSvr.setDbName(database.getAttribute("dbName"));
			if (dbSvr.getDbName().endsWith("gm")) {
				// GM数据库
				dbSvr.setDbType(GM);
			} else if (dbSvr.getDbName().endsWith("log")) {
				// Log数据库
				dbSvr.setDbType(LOG);
			} else {
				// 游戏数据库
				dbSvr.setDbType(GAME);
			}
			dbSvr.setDbIp(database.getAttribute("dbIp"));
			dbSvr.setDbport(database.getAttribute("dbPort"));
			dbSvr.setTelnetIp(database.getAttribute("telIp"));
			dbSvr.setDbUsername(database.getAttribute("u"));
			dbSvr.setDbPassword(database.getAttribute("ps"));
			dbSvr.setTelnetPort(database.getAttribute("telPort"));
			dbSvr.setRegionName(regionMap.get(dbSvr.getRegionId()));
			long start = System.currentTimeMillis();
			if (SvrStatusService.canConnect(dbSvr)) {
				long end = System.currentTimeMillis();
				System.out.println("RegionId:" + dbSvr.getRegionId()
						+ "\t ServerId:" + dbSvr.getId() + "\t DB:"
						+ dbSvr.getDbServerName()
						+ "\tDB(mmo) connect OK.cost " + (end - start) + " ms");
			} else {
				System.out.println("RegionId:" + dbSvr.getRegionId()
						+ "\t ServerId:" + dbSvr.getId() + "\t DB:"
						+ dbSvr.getDbServerName() + "\tDB(mmo) connect FAIL.");
			}
			dbServers.add(dbSvr);
			mapSF.put(String.valueOf(dbSvr.getId()), getSessionFactory(dbSvr));
		}
	}

	/**
	 * 根据svr_id,得到getServers
	 *
	 * @return
	 */
	public static List<DBServer> getServers(String svrIds, String regionId) {
		List<DBServer> servers = new ArrayList<DBServer>();
		// 游戏数据库默认region
		String[] svrIdsArray = svrIds.split(",");
		for (int i = 0; i < svrIdsArray.length; i++) {
			for (int j = 0; j < dbServerList.get(regionId).size(); j++) {
				DBServer dbServer = dbServerList.get(regionId).get(j);
				if (dbServer.getId().equals(svrIdsArray[i])) {
					servers.add(dbServer);
					break;
				}
			}
		}
		Collections.sort(servers, new Comparator<DBServer>() {
			public int compare(DBServer arg0, DBServer arg1) {
				int id1 = Integer.valueOf(arg0.getId());
				int id2 = Integer.valueOf(arg1.getId());
				return id1 - id2;
			}

		});
		return servers;
	}

	/**
	 * 根据svrId,得到getServers
	 *
	 * @return
	 */
	public DBServer getServer(String svrId) {
		String rid = LoginUserService.getLoginRegionId();
		return getServer(rid, svrId);
	}

	/**
	 * 根据server 的id 得到DBServer
	 *
	 * @param id
	 * @return DBServer
	 */
	public DBServer getServer(String rid, String id) {
		for (int i = 0; i < dbServerList.get(rid).size(); i++) {
			DBServer svr = (DBServer) dbServerList.get(rid).get(i);
			if (svr.getId().equals(id))
				return svr;
		}

		return null;
	}

	/**
	 * 排除日志数据DBServer 得到getDBServers
	 *
	 * @return DBServers
	 */
	public List<DBServer> getServerList(String rid) {
		List<DBServer> serversList = new ArrayList<DBServer>();
		try {
			for (int i = 0; i < dbServerList.get(rid).size(); i++) {
				DBServer dbServer = dbServerList.get(rid).get(i);
				if (!dbServer.getId().startsWith("log_")) {
					serversList.add(dbServer);
				}
			}
			Collections.sort(serversList, new Comparator<DBServer>() {
				public int compare(DBServer arg0, DBServer arg1) {
					int id1 = Integer.valueOf(arg0.getId());
					int id2 = Integer.valueOf(arg1.getId());
					return id1 - id2;
				}

			});
		} catch (Exception e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),
					"getServerList", e.getMessage()));
			logger.error(e.toString());
			e.printStackTrace();
		}

		return serversList;
	}

	/**
	 * 除去现登录大区,得到其他大区的第一组服
	 *
	 * @return 其他大区
	 */
	public List<DBServer> getRegionS1List() {
		String loginRid = LoginUserService.getLoginRegionId();
		List<DBServer> s1List = new ArrayList<DBServer>();
		Iterator<Entry<String, String>> it = regionMap.entrySet().iterator();
		while (it.hasNext()) {
			Entry<String, String> enty = (Entry<String, String>) it.next();
			String rid = (String) enty.getKey();
			if (!loginRid.equals(rid)) {
				List<DBServer> serverList = getServerList(rid);
				if (!serverList.isEmpty()) {
					s1List.add(serverList.get(0));
				}
			}
		}
		return s1List;
	}

	/**
	 * 初始化Hibernate,创建SessionFactory实例,只在该类被加载到内存时执行一次
	 *
	 * @param ip
	 *            访问数据库的ip地址
	 * @param u
	 *            访问数据库的用户名
	 * @param p
	 *            访问数据库的密码
	 * @param database
	 *            访问数据库
	 * @return sessionFactory
	 */
	private SessionFactory getSessionFactory(DBServer dbSvr) {
		AnnotationConfiguration _config = new AnnotationConfiguration();
		Properties po = new Properties();
		String dbCommonPropertiesPath = rootPath + "/dbCommon.properties";
		try {
			InputStream in = new BufferedInputStream(new FileInputStream(
					dbCommonPropertiesPath));
			po.load(in);
			in.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		po.setProperty("hibernate.connection.driver_className",
				"com.mysql.jdbc.Driver");
		po
				.setProperty("hibernate.connection.url", "jdbc:mysql://"
						+ dbSvr.getDbIp() + ":" + dbSvr.getDbport() + "/"
						+ dbSvr.getDbName()
						+ "?useUnicode=true&characterEncoding=utf8");
		po.setProperty("hibernate.connection.username", dbSvr.getDbUsername());
		po.setProperty("hibernate.connection.password", dbSvr.getDbPassword());
		_config.setProperties(po);
		// GM库
		if (dbSvr.getDbName().equals(gmConfig.gmDbName)) {
			_config.addClass(SysUser.class);
			_config.addFile(this.getClass().getClassLoader().getResource("gm.hbm.xml").getFile());
		} else {
			_config.addAnnotatedClass(UserInfo.class);
//			_config.addAnnotatedClass(BranchEntity.class);
			_config.addAnnotatedClass(HumanEntity.class);
			_config.addAnnotatedClass(PetEntity.class);
			_config.addAnnotatedClass(ItemEntity.class);
			//_config.addAnnotatedClass(HumanBattleSnapEntity.class);
			_config.addAnnotatedClass(MailEntity.class);
			//_config.addAnnotatedClass(MissionEnemyEntity.class);
			_config.addAnnotatedClass(SceneEntity.class);
			//_config.addAnnotatedClass(FarmEntity.class);
//			_config.addAnnotatedClass(ShopmallEntity.class);
			//_config.addAnnotatedClass(SilveroreEntity.class);
			//_config.addAnnotatedClass(MissionEnemyEntity.class);
//			_config.addAnnotatedClass(DailyQuestEntity.class);
			//_config.addAnnotatedClass(FestivalEntity.class);
			_config.addAnnotatedClass(DoingQuestEntity.class);
			_config.addAnnotatedClass(FinishedQuestEntity.class);
//			_config.addAnnotatedClass(CommerceEntity.class);
//			_config.addAnnotatedClass(CommerceMemberEntity.class);
			_config.addAnnotatedClass(PrizeInfo.class);
			_config.addAnnotatedClass(UserPrize.class);
			_config.addClass(TimeNotice.class);
			_config.addClass(GameNotice.class);
//			_config.addAnnotatedClass(EmployeeEntity.class);
//			_config.addAnnotatedClass(BattleSnapEntity.class);
			_config.addAnnotatedClass(ArenaSnapEntity.class);
//			_config.addAnnotatedClass(BossEntity.class);
			_config.addAnnotatedClass(DbVersion.class);
//			_config.addAnnotatedClass(EscortHelpSnapEntity.class);
			_config.addAnnotatedClass(RelationEntity.class);
			_config.addAnnotatedClass(MallEntity.class);
//			_config.addAnnotatedClass(EscortSnapEntity.class);
//			_config.addAnnotatedClass(SecretaryEntity.class);
//			_config.addAnnotatedClass(HunterEntity.class);
//			_config.addAnnotatedClass(TempHuntBagEntity.class);
//			_config.addAnnotatedClass(SortArenaLevelEntity.class);

			//TODO
			_config.addAnnotatedClass(GoodActivityEntity.class);
			_config.addAnnotatedClass(DirtyWordsTypeEntity.class);
//			_config.addAnnotatedClass(CardActivityEntity.class);
//			_config.addAnnotatedClass(TurntableActivityEntity.class);
			_config.addAnnotatedClass(QQMarketTaskTargetEntity.class);
			_config.addAnnotatedClass(CDKeyEntity.class);
			_config.addAnnotatedClass(WorldGiftEntity.class);
			_config.addAnnotatedClass(CDKeyPlansEntity.class);
			
			_config.addFile(this.getClass().getClassLoader().getResource(
					"sql.hbm.xml").getFile());
		}
		sessionFactory = _config.buildSessionFactory();
		return sessionFactory;

	}

	public SessionFactory selectSessionFactory(String regionId, String svrId) {
		Loggers.getGmLogger().error(String.format("regionId %s, svrid %s", regionId, svrId));
		for(TreeMap<String, SessionFactory> map : mapRSF.values()){
			for(Entry<String, SessionFactory> entry : map.entrySet()){
				Loggers.getGmLogger().error(String.format("key %s, value %s", entry.getKey(), entry.getValue() ) );
			}
		}
		TreeMap<String, SessionFactory> treeMap = mapRSF.get(regionId);
		if (treeMap == null) {
			throw new ConfigException("未找到regionId[" + regionId + "]对应的服务器信息");
		}
		return mapRSF.get(regionId).get(svrId);
	}
	
	public String getS1DbId(String regionId) {
		String s1 = "";
		TreeMap<String, SessionFactory> treeMap = mapRSF.get(regionId);
		if (treeMap == null) {
			throw new ConfigException("未找到regionId[" + regionId + "]对应的服务器信息");
		}
		for (String s : mapRSF.get(regionId).keySet()) {
			s1 = s;
			break;
		}
		return s1;
	}

	public Map<String, List<DBServer>> getDbServerList() {
		return Collections.unmodifiableMap(dbServerList);
	}

	public JSONObject getDbJson(){
		JSONObject js = new JSONObject();
		for(String key:this.getDbServerList().keySet()){
			List<DBServer> dbserver = getDbServerList().get(key);
			for (int j = 0; j < dbserver.size(); j++) {
				DBServer d = dbserver.get(j);
				if(d.getDbName().endsWith("log") || d.getDbName().endsWith("gm")){
					continue;
				}
				JSONObject serverjson = new JSONObject();
				serverjson.put("ip",d.getTelnetIp());
				serverjson.put("port",d.getTelnetPort());
				js.put(d.getServerId(),serverjson);
			}
		}
		return js;
	}

	public ParamGenericDAO getGMDAO() {
		return GMDAO;
	}

	private Document getDoc(String filePath) {
		File inFile = new File(filePath);
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		try {
			db = dbf.newDocumentBuilder();
			if(db == null){
				System.out.println("XXXXXXXXXXXXXXXXXXXXXXXXXX");
				System.out.println("DocumentBuilder is null");
				System.out.println("XXXXXXXXXXXXXXXXXXXXXXXXXX");
			}
			doc = (Document) db.parse(inFile);
			if(doc == null){
				System.out.println("XXXXXXXXXXXXXXXXXXXXXXXXXX");
				System.out.println("Document is null");
				System.out.println("XXXXXXXXXXXXXXXXXXXXXXXXXX");
			}
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		} catch (NullPointerException nullex) {
			logger.error("NullPointerException:", nullex);
		} catch (SAXException saxe) {
			logger.error("ParserConfigurationException:", saxe);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		} catch (Exception e) {
			logger.error("Exception:", e);
		}
		return doc;
	}

	/**
	 * 初始化GM数据库DAO
	 */
	public void createGMDAO() {
		GMDAO = new ParamGenericDAO();
		GMDAO.setRId(SystemConstants.GM_REGION);
		GMDAO.setSId(SystemConstants.GM);
		GMDAO.setDbFactoryService(this);
	}

	/**
	 * 设置模板serverID
	 * @param dbFactoryService
	 * @param serverId
	 */
	public static void setTemplateServerID(DBFactoryService dbFactoryService,String serverId){
		dbFactoryService.getGMDAO().changeTemplateServer(serverId);
	}

	/**
	 * 获取模板serverID
	 *
	 * @param dbFactoryService2
	 */
	public static void loadTemplateServerID(DBFactoryService dbFactoryService, String regionId) {
		int _serverID = dbFactoryService.getGMDAO().getTemplateDBID();
		System.out.println("Load template id from db. ID : " + _serverID);
		if (dbFactoryService.getServer(regionId, "" + _serverID) == null) {
			System.out.println("Region 1 doesn't contain " + _serverID + ". DB template use default s1.");
			return;
		}
		SystemConstants.DB_TEMPLATE = "" + _serverID;
		System.out.println("Region 1 contain " + _serverID + ". DB template use " + _serverID + ".");
	}
	
	public DBServer getServerByServerId(String rid, String serverId) {
		for (int i = 0; i < dbServerList.get(rid).size(); i++) {
			DBServer svr = (DBServer) dbServerList.get(rid).get(i);
			if (svr.getServerId().endsWith(serverId))
				return svr;
		}

		return null;
	}
	
	public SysUser getUserByName(String u, String regionId) {
		List<SysUser> sysUserList = getGMDAO().getSysUserNoRegion(u);
		if (sysUserList != null && !sysUserList.isEmpty()) {
			for (SysUser sysUser : sysUserList) {
				if (sysUser.getRegionId() == null) {
					continue;
				}
				// 玩家是该大区的或是全部大区的
				if (regionId.equalsIgnoreCase(sysUser.getRegionId()) || 
						sysUser.getRegionId().equalsIgnoreCase(SystemConstants.ALL_REGION_PRIVILEGE)) {
					return sysUser;
				}
			}
		}
		return null;
	}
}
