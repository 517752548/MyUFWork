package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.HumanEntity;

/**
 * 人物角色数据管理操作类
 *
 *
 */
public class HumanDao extends BaseDao<HumanEntity> {

	/** 查询语句名称 ： 根据账号ID获取所有 characterInfo */
	public static final String QUERY_GET_CHARACTERS_BY_PID = "queryCharactersByPid";

	/** 查询语句名称 ： 根据姓名获取 CharacterInfo */
	public static final String QUERY_GET_CHARACTER_BY_NAME = "queryCharacterByName";

	/** 查询语句名称 ： 根据角色ID集合获取 CharacterInfo列表 */
	public static final String QUERY_GET_CHARACTERS_BY_CHARIDS = "queryCharacterByCharIdSet";

	/** 更新玩家当日累计在线时间 */
	public static final String UPDATE_USER_ONLINE_TIME = "updateUserOnlineTime";
	
	/** 更新激活信息 */
	public static final String UPDATE_ACTIVITY = "updateActivity";

	/** 查询：根据角色ID查询character */
	public static final String QUERY_CHARACTER_BY_UUID = "queryCharacterByUUID";

	/** 根据场景 Id 查询玩家角色列表 */
	public static final String QUERY_HUMANS_BY_SCENE_ID = "queryHumansBySceneId";
	/** 更新玩家银币 */
	public static final String UPDATE_HUMAN_COPPER = "updateHumanCopper";
	/** 更新玩家 buffs */
	public static final String UPDATE_BUFFS = "updateBuffs";

	/**查询所有玩家 */
	public static final String QUERY_ALL_CHARACTERS = "queryAllCharacter";

	/** 更新玩家的vip等级*/
	public static final String UPDATE_HUMAN_VIPLEVEL = "updateHumanVipLevel";

	/** 更新区域 */
	public static final String UPDATE_DISTRICT = "updateDistrict";

	/** 更新角色BOSS车轮战奖励信息 */
	public static final String UPDATE_HUMAN_BOSSWARPACK="updateHumanBossWarPack";

	/** 查询所有玩家的剩余钻石总和 */
	public static final String QUERY_ALL_LEFT_BOND = "queryAllLeftBond";

	public static final String UPDATE_USER_NAME= "updateUserName";
	
	/** 查询所有玩家的剩余物品价值消耗 */
	public static final String QUERY_ALL_LEFT_ITEM_BOND = "queryAllLeftItemBond";
	
	/** 查询所有玩家的永久非消耗物品价值 */
	public static final String QUERY_ALL_LEFT_ETERNAL_COST_MONEY_BOND = "queryAllEternalCostMoneyBond";
	
	/** 查询所有玩家的国家 */
	public static final String QUERY_ALL_COUNTRY = "queryAllCountry";
	
	/** 更新金子 */
	public static final String UPDATE_HUMAN_BOND = "updateHumanBond";

	public HumanDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<HumanEntity> getEntityClass() {
		return HumanEntity.class;
	}

	/**
	 * 根据角色名获取第一个HumanEntity
	 *
	 * @param name
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public HumanEntity loadHuman(String name) {
		List<HumanEntity> _charList = dbService.findByNamedQueryAndNamedParam(
				QUERY_GET_CHARACTER_BY_NAME, new String[] { "name" },
				new Object[] { name });
		if (_charList.size() > 0) {
			return (HumanEntity) _charList.get(0);
		}
		return null;
	}


	/**
	 * 根据账号ID从数据库获取所有角色
	 *
	 * @param passportId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<HumanEntity> loadHumans(String passportId) {
		return dbService.findByNamedQueryAndNamedParam(
				QUERY_GET_CHARACTERS_BY_PID, new String[] { "passportId" },
				new Object[] { passportId });
	}

	/**
	 * 更新玩家当日在线累计时间
	 *
	 * @param playerId
	 * @param onlineTime
	 */
	public void updatePlayerOnlineTime(String passportId,java.sql.Timestamp lastLoginTime , java.sql.Timestamp todayOnlineUpdateTime, int onlineTime, String qqData) {
		dbService.queryForUpdate(UPDATE_USER_ONLINE_TIME,
				new String[] { "passportId", "lastLoginTime", "todayOnlineUpdateTime", "onlineTime", "qqData" }, new Object[] {
						passportId,lastLoginTime , todayOnlineUpdateTime, onlineTime, qqData });
	}
	
	/**
	 * 更新激活信息
	 * 
	 * @param passportId
	 * @param activity
	 */
	public void updateActivity(String passportId, int activity) {
		dbService.queryForUpdate(UPDATE_ACTIVITY,
				new String[] { "passportId", "activity"}, new Object[] {passportId, activity});
	}

	/**
	 * 更新玩家名称
	 *
	 * @param playerId
	 * @param onlineTime
	 */
	public void updateUserName(String passportId,String userName) {
		dbService.queryForUpdate(UPDATE_USER_NAME,
				new String[] { "passportId", "name" }, new Object[] {
						passportId,userName });
	}

	/**
	 * 根据UUID从数据库中查询相应角色
	 *
	 * @param UUID
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<HumanEntity> queryHumanByUUID(long UUID) {
		return dbService.findByNamedQueryAndNamedParam(QUERY_CHARACTER_BY_UUID,
				new String[] { "id" }, new Object[] { UUID });
	}

	/**
	 * 根据场景 Id 加载玩家角色列表
	 *
	 * @param sceneId 场景 Id, 场景配置模版中的 Id
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<HumanEntity> queryHumansBySceneId(int sceneId) {
		return dbService.findByNamedQueryAndNamedParam(
			QUERY_HUMANS_BY_SCENE_ID,
			new String[] { "sceneId" }, new Object[] { sceneId }
		);
	}

	/**
	 * 给玩家角色增加银币数量
	 *
	 * @param humanUUId 玩家角色 Id
	 * @param addCopper 所增加的银币数量
	 *
	 */
	public int addCopper(long humanUUId, int addGold) {
		return dbService.queryForUpdate(
			UPDATE_HUMAN_COPPER,
			new String[] { "humanUUId", "addGold", },
			new Object[] {  humanUUId ,  addGold   }
		);
	}

	/**
	 * 更新玩家 buff
	 *
	 * @param humanUUId
	 * @param buffs
	 * @return
	 */
	public int updateBuffs(long humanUUId, String buffs) {
		return dbService.queryForUpdate(
			UPDATE_BUFFS,
			new String[] { "humanUUId", "buffs" },
			new Object[] {  humanUUId ,  buffs  }
		);
	}

	/**
	 * 更新 district
	 *
	 * @param humanUUId
	 * @param buffs
	 * @return
	 */
	public int updateDistrict(long humanUUId, int district) {
		return dbService.queryForUpdate(UPDATE_DISTRICT,
			new String[] { "humanUUId", "district" },
			new Object[] {  humanUUId ,  district  });
	}

	@SuppressWarnings("unchecked")
	public List<HumanEntity> queryAllHuman() {
		return dbService.findByNamedQuery(QUERY_ALL_CHARACTERS);
	}

	/**
	 * 更新角色的vip等级
	 * @param humanUUId
	 * @param vipLevel
	 * @return
	 */
	public int updateHumanVipLevel(long humanUUId, int vipLevel) {
		return dbService.queryForUpdate(
				UPDATE_HUMAN_VIPLEVEL,
			new String[] { "humanUUId", "vipLevel" },
			new Object[] {  humanUUId ,  vipLevel }
		);
	}

	/***
	 * 更新角色BOSS车轮战奖励信息
	 * @param name
	 * @param bossWarPack
	 * @return
	 */
	public int updateHumanBossWarPack(long humanUUId, String bossWarPack) {
		return dbService.queryForUpdate(
				UPDATE_HUMAN_BOSSWARPACK,
			new String[] { "humanUUId", "bossWarPack" },
			new Object[] {  humanUUId ,  bossWarPack }
		);
	}

	/**
	 * 获取所有玩家剩余钻石总数
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public long getAllLeftBond() {
		long leftBond = 0;
		List<Object> _datas = this.dbService.findByNamedQuery(QUERY_ALL_LEFT_BOND);
		if (_datas == null || _datas.size() == 0) {
			return leftBond;
		}
		leftBond = (Long)_datas.get(0);
		return leftBond;
	}
	
	/**
	 * 获取所有玩家剩余物品价值
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public long getAllLeftItemBond() {
		long leftBond = 0;
		List<Object> _datas = this.dbService.findByNamedQuery(QUERY_ALL_LEFT_ITEM_BOND);
		if (_datas == null || _datas.size() == 0 || _datas.get(0) == null) {
			return leftBond;
		}
		try {
			leftBond = (Long)_datas.get(0);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return leftBond;
	}
	
	@SuppressWarnings("unchecked")
	public long getAllEternalCostMoneyBond() {
		long leftBond = 0;
		List<Object> _datas = this.dbService.findByNamedQuery(QUERY_ALL_LEFT_ETERNAL_COST_MONEY_BOND);
		if (_datas == null || _datas.size() == 0) {
			return leftBond;
		}
		try {
			leftBond = (Long)_datas.get(0);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return leftBond;
	}
	
	/**
	 * 加载所有玩家的国家，推荐国家统计用
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<Integer> loadAllCountry() {
		// 获取并设置权限
		List<Integer> _roles = this.dbService.findByNamedQuery(QUERY_ALL_COUNTRY);
		return _roles;
	}
	
	/**
	 * 更新玩家金子数
	 * @param roleId
	 * @param bond
	 */
	public void updateHumanBond(long roleId, long bond) {
		dbService.queryForUpdate(UPDATE_HUMAN_BOND,
				new String[] { "bond", "id"}, new Object[] {bond, roleId});
	}

}
