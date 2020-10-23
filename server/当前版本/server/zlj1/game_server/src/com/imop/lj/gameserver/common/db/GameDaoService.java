package com.imop.lj.gameserver.common.db;

import java.net.URL;
import java.util.HashMap;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.event.EventListenerAdapter;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.orm.DBAccessEvent;
import com.imop.lj.core.orm.DBAccessEventListener;
import com.imop.lj.core.orm.DBService;
import com.imop.lj.core.orm.DBServiceBuilder;
import com.imop.lj.db.dao.AllocateActivityStorageDao;
import com.imop.lj.db.dao.ArenaLogDao;
import com.imop.lj.db.dao.ArenaMemberDao;
import com.imop.lj.db.dao.BaseDao;
import com.imop.lj.db.dao.CDKeyDao;
import com.imop.lj.db.dao.CDKeyPlansDao;
import com.imop.lj.db.dao.CommonTaskDao;
import com.imop.lj.db.dao.CorpsBossCountRankDao;
import com.imop.lj.db.dao.CorpsBossRankDao;
import com.imop.lj.db.dao.CorpsDao;
import com.imop.lj.db.dao.CorpsMemberDao;
import com.imop.lj.db.dao.CorpsTaskDao;
import com.imop.lj.db.dao.CorpsWarRankDao;
import com.imop.lj.db.dao.Day7TaskDao;
import com.imop.lj.db.dao.DbVersionDao;
import com.imop.lj.db.dao.DirtyWordsTypeDao;
import com.imop.lj.db.dao.ForageTaskDao;
import com.imop.lj.db.dao.GoodActivityDao;
import com.imop.lj.db.dao.GoodActivityUserDao;
import com.imop.lj.db.dao.HumanDao;
import com.imop.lj.db.dao.ItemCostRecordDao;
import com.imop.lj.db.dao.ItemDao;
import com.imop.lj.db.dao.MailDao;
import com.imop.lj.db.dao.MallDao;
import com.imop.lj.db.dao.MarryDao;
import com.imop.lj.db.dao.ModuleDataDao;
import com.imop.lj.db.dao.NvnRankDao;
import com.imop.lj.db.dao.OfflineRewardDao;
import com.imop.lj.db.dao.OvermanDao;
import com.imop.lj.db.dao.PetDao;
import com.imop.lj.db.dao.PlatformPrizeInfoDao;
import com.imop.lj.db.dao.PubTaskDao;
import com.imop.lj.db.dao.QQChargeOrderDao;
import com.imop.lj.db.dao.QQChargeReturnWorldDao;
import com.imop.lj.db.dao.QQInviteWorldDao;
import com.imop.lj.db.dao.QQMarketTaskTargetDao;
import com.imop.lj.db.dao.RedEnvelopeDao;
import com.imop.lj.db.dao.RelationDao;
import com.imop.lj.db.dao.SceneDao;
import com.imop.lj.db.dao.SiegeDemonTaskDao;
import com.imop.lj.db.dao.SysMailDao;
import com.imop.lj.db.dao.TheSweeneyTaskDao;
import com.imop.lj.db.dao.TimeLimitMonsterDao;
import com.imop.lj.db.dao.TimeLimitNpcDao;
import com.imop.lj.db.dao.TitleDao;
import com.imop.lj.db.dao.TowerDao;
import com.imop.lj.db.dao.TradeDao;
import com.imop.lj.db.dao.TreasureMapDao;
import com.imop.lj.db.dao.UserInfoDao;
import com.imop.lj.db.dao.UserOfflineDao;
import com.imop.lj.db.dao.UserPrizeDao;
import com.imop.lj.db.dao.UserSnapDao;
import com.imop.lj.db.dao.VipDao;
import com.imop.lj.db.dao.WingDao;
import com.imop.lj.db.dao.WorldBossDao;
import com.imop.lj.db.dao.WorldGiftDao;
import com.imop.lj.gameserver.common.config.GameServerConfig;

//import com.imop.lj.gameserver.battlereport.BattleReportDBConnection;
//import com.imop.lj.gameserver.battlereport.BattleReportDao;

/**
 * GameServer用到的数据库访问对象管理器
 * 
 */
public class GameDaoService {

	/** 辅助初始化类 */
	private DaoHelper daoHelper;

	private DBMultiTransactionHelper queryHelper;

	public GameDaoService(GameServerConfig config) {
		daoHelper = new DaoHelper(config);
		queryHelper = new DBMultiTransactionHelper(getDBService());
	}

	public DBMultiTransactionHelper getQueryHelper() {
		return queryHelper;
	}

	/**
	 * 获取CharacterInfoDao
	 * 
	 * @return
	 */
	public HumanDao getHumanDao() {
		return daoHelper.humanDao;
	}

	public UserInfoDao getUserInfoDao() {
		return daoHelper.userInfoDao;
	}

	public DBService getDBService() {
		if (daoHelper == null) {
			return null;
		}
		return daoHelper.dbService;
	}

	/**
	 * 获取场景 DAO
	 * 
	 * @return
	 */
	public SceneDao getSceneDao() {
		return daoHelper.sceneDao;
	}

	/**
	 * 根据PersistanceObject
	 * 
	 * @param poClass
	 * @return
	 */
	public BaseDao<?> getDaoByPOClass(Class<?> poClass) {
		return daoHelper.clazzDaoMap.get(poClass);
	}

//	/**
//	 * 获取战报DAO
//	 * 
//	 * @return
//	 */
//	public BattleReportDao getBattleReportDao() {
//		return daoHelper.battleReportDao;
//	}
	
	/**
	 * 获取MailDao
	 * @return
	 */
	public MailDao getMailDao() {
		return daoHelper.mailDao;
	}

	/**
	 * 获取ItemDao
	 * 
	 * @return
	 */
	public ItemDao getItemDao() {
		return daoHelper.itemDao;
	}

	/**
	 * 获取PetDao
	 * 
	 * @return
	 */
	public PetDao getPetDao() {
		return daoHelper.petDao;
	}


	
//	/**
//	 * 获取doingQuestDao
//	 * 
//	 * @return
//	 */
//	public DoingQuestDao getDoingQuestDao() {
//		return daoHelper.doingQuestDao;
//	}
//
//	/**
//	 * 获取finishedQuestDao
//	 * 
//	 * @return
//	 */
//	public FinishedQuestDao getFinishedQuestDao() {
//		return daoHelper.finishedQuestDao;
//	}
	
	/**
	 * 获取普通任务Dao
	 * @return
	 */
	public CommonTaskDao getCommonTaskDao() {
		return daoHelper.commonTaskDao;
	}
	
	/**
	 * 获取RelationDao
	 * 
	 * @return
	 */
	public RelationDao getRelationDao() {
		return daoHelper.relationDao;
	}
	
	/**
	 * 获取玩家离线数据Dao
	 * @return
	 */
	public UserSnapDao getUserSnapDao() {
		return daoHelper.userSnapDao;
	}
	
	/**
	 * 获取玩家离线数据2Dao
	 * @return
	 */
	public UserOfflineDao getUserOfflineDao() {
		return daoHelper.userOfflineDao;
	}
	
	/**
	 * 获取竞技场DAO
	 * @return
	 */
	public ArenaMemberDao getArenaMemberDao() {
		return daoHelper.arenaMemberDao;
	}
	
	/**
	 * 获取竞技场logDAO
	 * @return
	 */
	public ArenaLogDao getArenaLogDao() {
		return daoHelper.arenaLogDao;
	}

	/**
	 * 获取世界boss DAO
	 * @return
	 */
	public WorldBossDao getWorldBossDao() {
		return daoHelper.worldBossDao;
	}
	
	/**
	 * 获取玩家离线奖励Dao
	 * @return
	 */
	public OfflineRewardDao getOfflineRewardDao() {
		return daoHelper.offlineRewardDao;
	}
	
	/**
	 * 获取全服邮件Dao
	 * @return
	 */
	public SysMailDao getSysMailDao() {
		return daoHelper.sysMailDao;
	}
	
	/**
	 * 获取VipDao
	 * 
	 * @return
	 */
	public VipDao getVipDao(){
		return daoHelper.vipDao;
	}
	
	/**
	 * 获取UserPirzeDao
	 * 
	 * @return
	 */
	public UserPrizeDao getUserPrizeDao(){
		return daoHelper.userPrizeDao;
	}
	
	/**
	 * 活动精彩活动Dao
	 * @return
	 */
	public GoodActivityDao getGoodActivityDao() {
		return daoHelper.goodActivityDao;
	}
	
	/**
	 * 获取玩家精彩活动Dao
	 * @return
	 */
	public GoodActivityUserDao getGoodActivityUserDao() {
		return daoHelper.goodActivityUserDao;
	}
	
	/**
	 * 获取商城DAO
	 * 
	 * @return
	 */
	public MallDao getMallDao(){
		return daoHelper.mallDao;
	}
	
	public ItemCostRecordDao getItemCostRecordDao() {
		return daoHelper.itemCostRecordDao;
	}
	
	public DirtyWordsTypeDao getDirtyWordsTypeDao() {
		return daoHelper.dirtyWordsTypeDao;
	}
	
	/**
	 * 得到平台奖励DAO
	 * @return
	 */
	public PlatformPrizeInfoDao getPlatformPrizeDao() {
		return daoHelper.platformPrizeDao;
	}
	
	public QQChargeOrderDao getQQChargeOrderDao() {
		return daoHelper.qqChargeOrderDao;
	}
	
	public QQInviteWorldDao getQQInviteWorldDao() {
		return daoHelper.qqInviteWorldDao;
	}
	
	public QQChargeReturnWorldDao getQQChargeReturnWorldDao() {
		return daoHelper.qqChargeReturnWorldDao;
	}

	public CDKeyDao getCDKeyDao() {
		return daoHelper.cdkeyDao;
	}
	
	public CDKeyPlansDao getCDKeyPlansDao() {
		return daoHelper.cdkeyPlansDao;
	}
	
	public WorldGiftDao getWorldGiftDao() {
		return daoHelper.worldGiftDao;
	}
	
	public QQMarketTaskTargetDao getQQMarketTaskTargetDao() {
		return daoHelper.qqMarketTaskTargetDao;
	}
	
	public ModuleDataDao getModuleDataDao(){
		return daoHelper.moduleDataDao;
	}

	public DbVersionDao getDbVersionDao() {
		return daoHelper.dbVersionDao;
	}
	
	public PubTaskDao getPubTaskDao() {
		return daoHelper.pubTaskDao;
	}
	
	public TradeDao getTradeDao() {
		return daoHelper.tradeDao;
	}
	
	public TheSweeneyTaskDao getTheSweeneyTaskDao() {
		return daoHelper.theSweeneyTaskDao;
	}
	
	public TreasureMapDao getTreasureMapDao() {
		return daoHelper.treasureMapDao;
	}

	public TitleDao getTitleDao(){
		return daoHelper.titleDao;
	}
	
	public ForageTaskDao getForageTaskDao(){
		return daoHelper.forageTaskDao;
	}
	
	public CorpsWarRankDao getCorpsWarRankDao() {
		return daoHelper.corpsWarRankDao;
	}
	
	public NvnRankDao getNvnRankDao() {
		return daoHelper.nvnRankDao;
	}
	
	public WingDao getWingDao() {
		return daoHelper.wingDao;
	}
	
	public CorpsTaskDao getCorpsTaskDao(){
		return daoHelper.corpsTaskDao;
	}
	
	public TowerDao getTowerDao(){
		return daoHelper.towerDao;
	}
	
	public CorpsBossRankDao getCorpsBossRankDao(){
		return daoHelper.corpsBossRankDao;
	}
	
	public CorpsBossCountRankDao getCorpsBossCountRankDao(){
		return daoHelper.corpsBossCountRankDao;
	}
	
	public TimeLimitMonsterDao getTimeLimitMonsterDao(){
		return daoHelper.timeLimitMonsterDao;
	}
	
	public TimeLimitNpcDao getTimeLimitNpcDao(){
		return daoHelper.timeLimitNpcDao;
	}
	
	public Day7TaskDao getDay7TaskDao() {
		return daoHelper.day7TaskDao;
	} 
	
	public RedEnvelopeDao getRedEnvelopeDao(){
		return daoHelper.redEnvelopeDao;
	}
	
	public AllocateActivityStorageDao getAllocateActivityStorageDao(){
		return daoHelper.allocateActivityStorageDao;
	}
	
	public SiegeDemonTaskDao getSiegeDemonTaskDao(){
		return daoHelper.siegeDemonTaskDao;
	}
	
	
	
	/**
	 * 获取军团Dao
	 * 
	 * @return
	 */
	public CorpsDao getCorpsDao(){
		return daoHelper.corpsDao;
	}
	
	/**
	 * 获取军团成员Dao
	 * 
	 * @return
	 */
	public CorpsMemberDao getCorpsMemberDao(){
		return daoHelper.corpsMemberDao;
	}

	/**
	 * 获取师徒dao
	 */
	public  OvermanDao getOvermanDao(){ return daoHelper.overmanDao;}
	
	/**
	 * 获取结婚dao
	 */
	public MarryDao getMarryDao(){
		return daoHelper.marryDao;
	}
	/**
	 * 快速登陆
	 * 
	 * @return
	 */
	public DaoHelper getDaoHelper() {
		return daoHelper;
	}

	/**
	 * Dao 配置，初始化 - dao
	 * 
	 * @author Fancy
	 * @version 2009-7-8 下午01:49:33
	 */
	private static final class DaoHelper {

		/** 数据库连接 */
		private final DBService dbService;

		private final UserInfoDao userInfoDao;

		private final HumanDao humanDao;

		private final ItemDao itemDao;

		private final PetDao petDao;
		

//		/** 战报DAO */
//		private final BattleReportDao battleReportDao;

		private HashMap<Class<? extends PersistanceObject<?, ?>>, BaseDao<?>> clazzDaoMap;

		private final SceneDao sceneDao;

//		private final DoingQuestDao doingQuestDao;
//
//		private final FinishedQuestDao finishedQuestDao;
		
		private final CommonTaskDao commonTaskDao;
		
		/** 关系系统DAO */
		private final RelationDao relationDao;
		
		/** 玩家离线数据DAO */
		private final UserSnapDao userSnapDao;
		private final UserOfflineDao userOfflineDao;
		
		/** 邮件DAO */
		private final MailDao mailDao;
		/** 竞技场DAO */
		private final ArenaMemberDao arenaMemberDao;
		/** 竞技场Log DAO */
		private final ArenaLogDao arenaLogDao;
		/** 世界boss Dao */
		private final WorldBossDao worldBossDao;
		/** 玩家离线奖励Dao */
		private final OfflineRewardDao offlineRewardDao;
		/** 全服邮件Dao */
		private final SysMailDao sysMailDao;
		/**Vip Dao*/
		private final VipDao vipDao;
		/**补偿奖励DAO*/
		private final UserPrizeDao userPrizeDao;
		/** 精彩活动Dao*/
		private final GoodActivityDao goodActivityDao;
		/** 玩家精彩活动Dao*/
		private final GoodActivityUserDao goodActivityUserDao;
		/**商城DAO*/
		private final MallDao mallDao;
		/**玩家道具消耗DAO*/
		private final ItemCostRecordDao itemCostRecordDao;
		/**过滤词DAO*/
		private final DirtyWordsTypeDao dirtyWordsTypeDao;
		/** 平台奖励DAO */
		private final PlatformPrizeInfoDao platformPrizeDao;
		/** qq充值订单Dao */
		private final QQChargeOrderDao qqChargeOrderDao;
		/** qq的成功邀请数据，WorldServer使用 */
		private final QQInviteWorldDao qqInviteWorldDao;
		/** qq返利数据记录表，WorldServer使用 */
		private final QQChargeReturnWorldDao qqChargeReturnWorldDao;
		/** cdkeyDao */
		private final CDKeyDao cdkeyDao;
		private final CDKeyPlansDao cdkeyPlansDao;
		private final WorldGiftDao worldGiftDao;
		
		private final QQMarketTaskTargetDao qqMarketTaskTargetDao;
		
		private final ModuleDataDao moduleDataDao;
		private final DbVersionDao dbVersionDao;
		
		private final PubTaskDao pubTaskDao;
		
		private final TradeDao tradeDao;
		
		private final TheSweeneyTaskDao theSweeneyTaskDao;
		
		private final TreasureMapDao treasureMapDao;
		
		private final ForageTaskDao forageTaskDao;

		private final TitleDao titleDao;
		/**军团成员DAO*/
		private final CorpsMemberDao corpsMemberDao;
		/**军团DAO*/
		private final CorpsDao corpsDao;
		
		private final CorpsWarRankDao corpsWarRankDao;

		private final OvermanDao overmanDao;
		/**结婚dao*/
		private final MarryDao marryDao;
		
		private final NvnRankDao nvnRankDao;
		
		private final WingDao wingDao;
		/**帮派任务*/
		private final CorpsTaskDao corpsTaskDao;
		/**通天塔*/
		private final TowerDao towerDao;
		/**帮派boss进度榜排名*/
		private final CorpsBossRankDao corpsBossRankDao;
		/**帮派boss挑战次数榜排名*/
		private final CorpsBossCountRankDao corpsBossCountRankDao;
		/**限时杀怪活动*/
		private final TimeLimitMonsterDao timeLimitMonsterDao;
		/**限时挑战Npc活动*/
		private final TimeLimitNpcDao timeLimitNpcDao;
		/**七日目标任务Dao*/
		private final Day7TaskDao day7TaskDao;
		/** 红包*/
		private final RedEnvelopeDao redEnvelopeDao;
		/** 活动分配仓库*/
		private final AllocateActivityStorageDao allocateActivityStorageDao;
		/** 围剿魔族Dao*/
		private final SiegeDemonTaskDao siegeDemonTaskDao;
		
		private DaoHelper(GameServerConfig config) {
			/** 资源初始化 */
			EventListenerAdapter eventAdapter = new EventListenerAdapter();
			eventAdapter.addListener(DBAccessEvent.class, new DBAccessEventListener(config));
			ClassLoader _classLoader = Thread.currentThread().getContextClassLoader();
			int daoType = config.getDbInitType();

			// db
			String[] _dbConfig = config.getDbConfigName().split(",");
			URL _dbUrl = _classLoader.getResource(_dbConfig[0]);
			String[] _dbResources = new String[_dbConfig.length - 1];
			if (_dbConfig.length > 1) {
				System.arraycopy(_dbConfig, 1, _dbResources, 0, _dbConfig.length - 1);
			}

			/* 数据库类初始化 */
			dbService = DBServiceBuilder.buildDirectDBService(eventAdapter, daoType, _dbUrl, _dbResources);

			Loggers.gameLogger.info("DBService instance:" + dbService);

			/* dao管理类初始化 */
			userInfoDao = new UserInfoDao(dbService);
			humanDao = new HumanDao(dbService);
			sceneDao = new SceneDao(dbService);
			itemDao = new ItemDao(dbService);
			petDao = new PetDao(dbService);
			mailDao = new MailDao(dbService);

//			doingQuestDao = new DoingQuestDao(dbService);
//			finishedQuestDao = new FinishedQuestDao(dbService);
			commonTaskDao = new CommonTaskDao(dbService);

//			/* 单独建立战报dao */
//			URL _battleReportDbUrl = _classLoader.getResource(config.getBattleReportDbConfigName());
//			BattleReportDBConnection battleReportDBConnection = new BattleReportDBConnection(_battleReportDbUrl);
//			battleReportDao = new BattleReportDao(battleReportDBConnection);
			
			/** 关系dao */
			relationDao = new RelationDao(dbService);
			/** 玩家离线数据DAO */
			userSnapDao = new UserSnapDao(dbService);
			userOfflineDao = new UserOfflineDao(dbService);
			
			arenaMemberDao = new ArenaMemberDao(dbService);
			arenaLogDao = new ArenaLogDao(dbService);

			worldBossDao = new WorldBossDao(dbService);
			offlineRewardDao = new OfflineRewardDao(dbService);
			sysMailDao = new SysMailDao(dbService);
			vipDao = new VipDao(dbService);
			userPrizeDao = new UserPrizeDao(dbService);
			goodActivityDao = new GoodActivityDao(dbService);
			goodActivityUserDao = new GoodActivityUserDao(dbService);
			mallDao = new MallDao(dbService);
			itemCostRecordDao = new ItemCostRecordDao(dbService);
			dirtyWordsTypeDao = new DirtyWordsTypeDao(dbService);
			platformPrizeDao = new PlatformPrizeInfoDao(dbService);
			qqChargeOrderDao = new QQChargeOrderDao(dbService);
			qqInviteWorldDao = new QQInviteWorldDao(dbService);
			qqChargeReturnWorldDao = new QQChargeReturnWorldDao(dbService);
			cdkeyDao = new CDKeyDao(dbService);
			cdkeyPlansDao = new CDKeyPlansDao(dbService);
			qqMarketTaskTargetDao = new QQMarketTaskTargetDao(dbService);
			moduleDataDao = new ModuleDataDao(dbService);
			dbVersionDao = new DbVersionDao(dbService);
			worldGiftDao = new WorldGiftDao(dbService);
			pubTaskDao = new PubTaskDao(dbService);
			tradeDao = new TradeDao(dbService);
			theSweeneyTaskDao = new TheSweeneyTaskDao(dbService);
			treasureMapDao = new TreasureMapDao(dbService);
			corpsMemberDao = new CorpsMemberDao(dbService);
			corpsDao = new CorpsDao(dbService);
            titleDao = new TitleDao(dbService);
            forageTaskDao = new ForageTaskDao(dbService);
            corpsWarRankDao = new CorpsWarRankDao(dbService);
			overmanDao = new OvermanDao(dbService);
			nvnRankDao = new NvnRankDao(dbService);
			marryDao = new MarryDao(dbService);
			wingDao = new WingDao(dbService);
			corpsTaskDao = new CorpsTaskDao(dbService);
			towerDao = new TowerDao(dbService);
			corpsBossRankDao = new CorpsBossRankDao(dbService);
			corpsBossCountRankDao = new CorpsBossCountRankDao(dbService);
			timeLimitMonsterDao = new TimeLimitMonsterDao(dbService);
			timeLimitNpcDao = new TimeLimitNpcDao(dbService);
			day7TaskDao = new Day7TaskDao(dbService);
			redEnvelopeDao = new RedEnvelopeDao(dbService);
			allocateActivityStorageDao = new AllocateActivityStorageDao(dbService);
			siegeDemonTaskDao = new SiegeDemonTaskDao(dbService);
		}

		
	}
}
