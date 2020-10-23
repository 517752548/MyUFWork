package com.imop.lj.gameserver.offlinedata;

import java.sql.Timestamp;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.TowerLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.UserOfflineDataEntity;
import com.imop.lj.db.model.UserSnapEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCOfflineUserBaseInfo;
import com.imop.lj.gameserver.common.msg.GCOfflineUserLeaderInfo;
import com.imop.lj.gameserver.common.msg.GCOfflineUserPetInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.sysmsg.UserSnapUpdateHorseMessage;
import com.imop.lj.gameserver.offlinedata.sysmsg.UserSnapUpdateMessage;
import com.imop.lj.gameserver.offlinedata.sysmsg.UserSnapUpdatePetMessage;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetFightState;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.timeevent.TimeQueueService;
import com.imop.lj.gameserver.timeevent.template.SysPowerGiveTimeTemplate;

import net.sf.json.JSONObject;

/**
 * 所有玩家离线数据服务
 * 在服务器启动时，加载所有玩家的离线数据
 * 
 * @author yu.zhao
 *
 */
public class OfflineDataService implements InitializeRequired {
	public static final String ROLE_ID = "roleId";
	public static final String ROLE_NAME = "roleName";
	public static final String ROLE_LEVEL = "roleLevel";
	public static final String ROLE_TPLID = "roleTplId";
	public static final String ROLE_FIGHT_PETID = "roleFightPetId";
	public static final String ROLE_FIGHT_PET_HORSE_ID = "roleFightPetHorseId";
	public static final String ROLE_CORPS_ID = "roleCorpsId";
	public static final String ROLE_CORPS_NAME = "roleCorpsName";
	public static final String ROLE_FIGHT_POWER = "roleFightPower";
	
	public static final int ADD_PET = 1;
	public static final int DEL_PET = 2;
	public static final int UPDATE_PET = 3;
	public static final int SAVE_OR_UPDATE_PET = 5;

	/** 所有玩家离线数据对象，key为玩家uuid */
	protected Map<Long, UserSnap> allUserSnap = new HashMap<Long, UserSnap>();
	
	/** 玩家名字与uuid的对应，Map<玩家名字, 玩家uuid> */
	protected Map<String, Long> allUserNameMap = new HashMap<String, Long>();
	
	/** 所有玩家的需要离线更新的数据，含宠物和伙伴 */
	protected Map<Long, UserOfflineData> allUserOfflineData = new HashMap<Long, UserOfflineData>();
	
	public OfflineDataService() {
		
	}

	@Override
	public void init() {
		initAllUserSnap();
		initAllUserData();
	}
	
	protected void initAllUserSnap() {
		List<UserSnapEntity> userSnapEntityList = Globals.getDaoService().getUserSnapDao().loadAllUserSnapEntity();
		for (UserSnapEntity userSnapEntity : userSnapEntityList) {
			UserSnap userSnap = new UserSnap();
			userSnap.fromEntity(userSnapEntity);
			userSnap.setInDb(true);
			userSnap.active();
			// 放入map
			allUserSnap.put(userSnap.getId(), userSnap);
			allUserNameMap.put(userSnap.getName(), userSnap.getId());
		}
	}
	
	protected void initAllUserData() {
		List<UserOfflineDataEntity> entityList = Globals.getDaoService().getUserOfflineDao().loadAllUserOfflineEntity();
		for (UserOfflineDataEntity entity : entityList) {
			UserOfflineData userData = new UserOfflineData();
			userData.fromEntity(entity);
			userData.setInDb(true);
			userData.active();
			// 放入map
			allUserOfflineData.put(userData.getRoleId(), userData);
		}
	}
	
	/**
	 * 初始化
	 * 
	 * @param human
	 */
	protected void init(Human human){
		UserSnap snap = new UserSnap();
		snap.reload(human);
		snap.setInDb(false);
		this.allUserSnap.put(snap.getId(), snap);
		this.allUserNameMap.put(snap.getName(), snap.getId());
		snap.setModified();
	}
	
	/**
	 * 当前添加武将时
	 * 
	 * @param pet
	 */
	public void onAddPet(Pet pet) {
		// 往公共场景发消息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdatePetMessage(pet, ADD_PET));
	}

	/**
	 * 当删除武将时
	 * 
	 * @param pet
	 */
	public void onDeletePet(Pet pet) {
		// 往公共场景发消息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdatePetMessage(pet, DEL_PET));
	}

	/**
	 * 当修改武将时
	 * 
	 * @param pet
	 */
	public void onUpdatePet(Pet pet) {
		// 往公共场景发消息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdatePetMessage(pet, UPDATE_PET));
	}
	
	/**
	 * 当修改或添加武将时
	 * 
	 * @param pet
	 */
	public void onSaveOrUpdatePet(Pet pet) {
		// 往公共场景发消息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdatePetMessage(pet, SAVE_OR_UPDATE_PET));
	}
	
	/**
	 * 当坐骑改变时
	 * 
	 * @param human
	 */
	public void onUpdateHorse(Human human) {
		// 往公共场景发消息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdateHorseMessage(human));
	}
	
	public void flushHorse(Human human){
		UserSnap snap = this.allUserSnap.get(human.getUUID());
		if(snap == null){
			this.init(human);
			return;
		}
		
//		snap.getHorseSnap().rebuild(human);
		snap.setModified();
	}
	
	
	public int getRidingHorseTplId(Human human){
		UserOfflineData offlineData = getUserOfflineData(human.getCharId());
		if(offlineData == null 
				|| offlineData.getPetHorseDataMap() == null 
				||offlineData.getPetDataMap().isEmpty()
				||offlineData.getPetHorseDataMap().get(offlineData.getFightPetHorseId()) == null){
			return 0;
		}
		return (int) offlineData.getPetHorseDataMap().get(offlineData.getFightPetHorseId()).getTplId();
	}
	
	public void changePet(Pet pet, int changeOp) {
		UserSnap snap = this.allUserSnap.get(pet.getOwner().getUUID());
		if(snap == null){
			this.init(pet.getOwner());
			return;
		}
		
		switch (changeOp) {
		case ADD_PET:
			snap.getPsManager().onAddPet(pet);
			//离线数据2增加数据
			addPetOfUserOfflineData(pet);
			break;
		case DEL_PET:
			snap.getPsManager().onDeletePet(pet);
			//离线数据2删除数据
			delPetOfUserOfflineData(pet);
			break;
		case UPDATE_PET:
			snap.getPsManager().onUpdatePet(pet);
			break;
		case SAVE_OR_UPDATE_PET:
			snap.getPsManager().onSaveOrUpdatePet(pet);
			break;
		default:
			break;
		}
	}
	
	/**
	 * 更新玩家离线数据中的基础信息
	 * @param human
	 */
	public void onBaseInfoChange(Human human) {
		// 往公共场景发消息，只更新基础信息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdateMessage(human, false));
	}
	
	/**
	 * 往公共场景发消息，更新玩家离线数据
	 * 
	 * @param human
	 */
	public void sendRebuildUserSnapMsg(Human human) {
		// 往公共场景发消息，更新全部信息
		Globals.getSceneService().getCommonScene().putMessage(new UserSnapUpdateMessage(human, true));
	}
	
	/**
	 * 基础信息改变时，如级别，国家，军衔，Vip等级，布阵
	 * 
	 * @param human
	 */
	public void updateBaseInfo(Human human) {
		UserSnap snap = this.allUserSnap.get(human.getUUID());
		if(snap == null){
			this.init(human);
			return;
		}
		
		snap.onBaseInfoChange(human);
	}
	
	/**
	 * 重新构建离线数据(全部更新)
	 * 
	 * @param human
	 */
	public void rebuildUserSnap(Human human) {
		UserSnap snap = this.getUserSnap(human.getUUID());
		if (snap == null) {
			// 如果不存在，则初始化
			this.init(human);
		}else{
			snap.reload(human);
		}
	}
	
	/**
	 * 获取所有的离线玩家数据 注意：要在场景线程或公共线程中才能调用此方法，否则会出现同步的异常
	 * 
	 * @return
	 */
	public Map<Long, UserSnap> getAllUserSnap() {
		return allUserSnap;
	}

	/**
	 * 获取玩家离线数据对象
	 * 
	 * @param uuid
	 * @return
	 */
	public UserSnap getUserSnap(long uuid) {
		return allUserSnap.get(uuid);
	}
	
	/**
	 * 玩家离线数据是否存在
	 * 
	 * @param uuid
	 * @return
	 */
	public boolean hasUserSnapExist(long uuid) {
		return allUserSnap.containsKey(uuid);
	}
	
	/**
	 * 根据名称判断玩家是否存在
	 * 
	 * @param name
	 * @return
	 */
	public boolean isUserNameExist(String name) {
		Long uuid = allUserNameMap.get(name);
		return uuid != null && uuid > 0;
	}
	
	/**
	 * 根据玩家名称获取玩家角色Id，如果玩家不存在，则返回0
	 * 
	 * @param name
	 * @return
	 */
	public long getUserIdByName(String name) {
		long uuid = 0;
		if (allUserNameMap.containsKey(name)) {
			uuid = allUserNameMap.get(name);
		}
		return uuid;
	}
	
	/**
	 * 根据角色Id获取角色所属的服务器Id，非法情况返回0
	 * @param charId
	 * @return
	 */
	public int getUserServerId(long charId) {
		int serverId = 0;
		if (null != getUserSnap(charId)) {
			serverId = getUserSnap(charId).getServerId();
		}
		return serverId;
	}
	
	public String getUserName(long charId) {
		String name = "";
		UserSnap us = getUserSnap(charId);
		if (us != null) {
			name = us.getName();
		}
		return name;
	}
	
	public int getUserTplId(long charId) {
		int tplId = 0;
		UserSnap us = getUserSnap(charId);
		if (us != null) {
			tplId = us.getHumanTplId();
		}
		return tplId;
	}
	
	public JobType getUserJobType(long charId) {
		JobType jt = JobType.XIAKE;
		UserSnap us = getUserSnap(charId);
		if (us != null) {
			PetTemplate petTpl = Globals.getTemplateCacheService().get(us.getHumanTplId(), PetTemplate.class);
			if (petTpl != null) {
				jt =  petTpl.getJobType();
			}
		}
		return jt;
	}
	
	public int getUserLevel(long charId) {
		int level = 0;
		UserSnap us = getUserSnap(charId);
		if (us != null) {
			level = us.getLevel();
		}
		return level;
	}
	
	public UserOfflineData getUserOfflineData(long roleId) {
		return allUserOfflineData.get(roleId);
	}
	
	/**
	 * 创建离线数据2
	 * @param human
	 */
	public void createUserOfflineData(Human human) {
		long roleId = human.getCharId();
		if (getUserOfflineData(roleId) == null) {
			createUserOfflineData(roleId);
		}
	}
	
	/**
	 * 增加主将的离线数据2
	 * @param human
	 */
	public void addLeaderUserOfflineData(Human human) {
		long roleId = human.getCharId();
		UserOfflineData offlineData = getUserOfflineData(roleId);
		if (offlineData == null) {
			return;
		}
		if (human == null || human.getPetManager() == null || human.getPetManager().getLeader() == null) {
			return;
		}
		
		//增加主将数据
		addPetOfUserOfflineData(human.getPetManager().getLeader());
	}
	

	/**
	 * 增加非主将的离线数据2
	 * @param human
	 * @param pet
	 */
	protected void addPetOfUserOfflineData(Pet pet) {
		Human human = pet.getOwner();
		if (human == null) {
			return;
		}
		long petId = pet.getUUID();
		UserOfflineData offlineData = getUserOfflineData(human.getCharId());
		if(pet.isLeader() || pet.isPet()){
			UserPetData petData = offlineData.getPetData(petId);
			//数据已经有了，不用再加了
			if (petData != null) {
				return;
			}
			
			//构建初始数据
			petData = buildInitUserPetData(pet);
			//加入离线数据中
			offlineData.addUserPetData(petId, petData);
			
			//发消息通知前台
			human.sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(human.getCharId(), petId));
		}
		if(pet.isHorse()){
			UserPetHorseData petHorseData = offlineData.getPetHorseData(petId);
			//数据已经有了，不用再加了
			if (petHorseData != null) {
				return;
			}
			
			//构建初始数据
			petHorseData = buildInitUserPetHorseData(pet);
			//加入离线数据中
			offlineData.addUserPetHorseData(petId, petHorseData);
			
			//发消息通知前台
			human.sendMessage(PetMessageBuilder.buildGCPetHorseCurPropUpdate(human.getCharId(), petId));
			
			//第一次获得的时候,出战状态
			if(human.getPetManager().getOwnHorseNum() == 1){
				Globals.getPetService().horseRide(human, pet.getUUID(), PetFightState.FIGHT.getIndex());
			}
		}
		//存库
		offlineData.setModified();
	}
	
	protected void delPetOfUserOfflineData(Pet pet) {
		UserOfflineData offlineData = getUserOfflineData(pet.getCharId());
		if(pet.isLeader() || pet.isPet()){
			UserPetData petData = offlineData.getPetData(pet.getUUID());
			if (petData != null) {
				offlineData.delUserPetData(pet.getUUID());
				offlineData.setModified();
			}
		}
		
		if(pet.isHorse()){
			UserPetHorseData petHorseData = offlineData.getPetHorseData(pet.getUUID());
			if (petHorseData != null) {
				offlineData.delUserPetHorseData(pet.getUUID());
				offlineData.setModified();
			}
		}
	}
	
	protected UserPetData buildInitUserPetData(Pet pet) {
		UserPetData petData = new UserPetData();
		petData.setOwnerId(pet.getOwner().getCharId());
		petData.setUuid(pet.getUUID());
		petData.setTplId(pet.getTemplateId());
		//初始属性值为上限值
		petData.setHp((long)pet.getPropertyManager().getBProperty(PetBProperty.HP));
		petData.setMp((long)pet.getPropertyManager().getBProperty(PetBProperty.MP));
		petData.setSp((long)pet.getPropertyManager().getBProperty(PetBProperty.SP));
		petData.setLife((long)pet.getPropertyManager().getBProperty(PetBProperty.LIFE));
		return petData;
	}
	
	protected UserPetHorseData buildInitUserPetHorseData(Pet pet) {
		UserPetHorseData petData = new UserPetHorseData();
		petData.setOwnerId(pet.getOwner().getCharId());
		petData.setUuid(pet.getUUID());
		petData.setTplId(pet.getTemplateId());
		petData.setLoy((long)pet.getPropertyManager().getBProperty(PetBProperty.LOYALTY));
		petData.setClo((long)pet.getPropertyManager().getBProperty(PetBProperty.CLOSENESS));
		return petData;
	}
	
	protected void createUserOfflineData(long roleId) {
		UserOfflineData data = new UserOfflineData();
		data.setRoleId(roleId);
		data.setCurArrayIndex(0);
		data.setCurDoublePoint(0);
		data.setIsOpenDouble(0);
		data.setHpPool(Globals.getGameConstants().getInitHpPool());
		data.setMpPool(Globals.getGameConstants().getInitMpPool());
		data.setLifePool(Globals.getGameConstants().getInitLifePool());
		
		data.setInDb(false);
		data.active();
		data.setModified();
		
		this.allUserOfflineData.put(roleId, data);
		
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player != null && player.getHuman() != null) {
//			//发送伙伴阵容列表
//			Globals.getPetService().sendFriendArrayListMsg(player.getHuman());
			//发送池子数值
			player.sendMessage(PetMessageBuilder.buildGCPetPoolUpdate(roleId));
		}
	}
	
	public void sendCurPropOnLogin(Human human) {
		long roleId = human.getCharId();
		UserOfflineData offlineData = getUserOfflineData(roleId);
		if (offlineData == null) {
			return;
		}
		//发送池子数值
		human.sendMessage(PetMessageBuilder.buildGCPetPoolUpdate(roleId));
		
		//发每个pet当前数值
		for (UserPetData petData : offlineData.getPetDataMap().values()) {
			human.sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(roleId, petData.getUuid()));
		}
		//发每个骑宠当前值
		for (UserPetHorseData petHorseData : offlineData.getPetHorseDataMap().values()) {
			human.sendMessage(PetMessageBuilder.buildGCPetHorseCurPropUpdate(roleId, petHorseData.getUuid()));
		}
	}
	
	/**
	 * 主将身上的装备发生变化时更新
	 * @param human
	 */
	public void onLeaderEquipUpdate(Human human) {
		UserSnap us = getUserSnap(human.getCharId());
		if (us != null) {
			us.onLeaderEquipUpdate(human);
		}
	}
	
	/**
	 * 装备位星级发生变化时更新
	 * @param human
	 */
	public void onLeaderEquipStarUpdate(Human human) {
		UserSnap us = getUserSnap(human.getCharId());
		if (us != null) {
			us.onEquipStarUpdate(human);
		}
	}
	
	/**
	 * 装备位镶嵌的宝石发生变化时更新
	 * @param human
	 */
	public void onLeaderGemUpdate(Human human) {
		UserSnap us = getUserSnap(human.getCharId());
		if (us != null) {
			us.onLeaderGemUpdate(human);
		}
	}
	
	/**
	 * 查看离线数据的主将基础信息
	 * @param human
	 * @param targetId
	 */
	public void sendRoleBaseInfoMsg(Human human, long targetId) {
		UserSnap targetUserSnap = getUserSnap(targetId);
		UserOfflineData offlineData = getUserOfflineData(targetId);
		if (null == targetUserSnap) {
			Loggers.offlineDataLogger.error("target userSnap not exist!targetId=" + targetId);
			return;
		}
		if (null == offlineData) {
			Loggers.offlineDataLogger.error("target userOfflineData not exist!targetId=" + targetId);
			return;
		}
		
		//获取基础信息的json串
		String jsonStr = buildRoleBaseInfoJson(targetUserSnap, offlineData);
		//发消息
		human.sendMessage(new GCOfflineUserBaseInfo(targetId, jsonStr));
	}
	
	/**
	 * 构建离线数据的主将基础信息
	 * @param userSnap
	 * @param offlineData
	 * @return
	 */
	protected String buildRoleBaseInfoJson(UserSnap userSnap, UserOfflineData offlineData) {
		JSONObject json = new JSONObject();
		long roleId = userSnap.getCharId();
		json.put(ROLE_ID, roleId);
		json.put(ROLE_NAME, userSnap.getName());
		json.put(ROLE_LEVEL, userSnap.getLevel());
		json.put(ROLE_TPLID, userSnap.getHumanTplId());
		json.put(ROLE_FIGHT_POWER, userSnap.getPsManager().getLeader().getFightPower());
		
		json.put(ROLE_FIGHT_PETID, offlineData.getFightPetId());
		json.put(ROLE_FIGHT_PET_HORSE_ID, offlineData.getFightPetHorseId());
		
		json.put(ROLE_CORPS_ID, Globals.getCorpsService().getUserCorpsId(roleId));
		json.put(ROLE_CORPS_NAME, "");
		if (Globals.getCorpsService().getUserCorps(roleId) != null) {
			json.put(ROLE_CORPS_NAME, Globals.getCorpsService().getUserCorps(roleId).getName());
		}
		return json.toString();
	}
	
	/**
	 * 查看离线数据的主将装备相关信息
	 * @param human
	 * @param targetId
	 */
	public void sendRoleLeaderInfoMsg(Human human, long targetId) {
		UserSnap targetUserSnap = getUserSnap(targetId);
		if (null == targetUserSnap) {
			Loggers.offlineDataLogger.error("target userSnap not exist!targetId=" + targetId);
			return;
		}
		
		//获取基础信息的json串
		String jsonStr = targetUserSnap.getEquipRelatedManager().toProps(true);
		//发消息
		human.sendMessage(new GCOfflineUserLeaderInfo(targetId, jsonStr));
	}
	
	/**
	 * 查看离线数据的宠物信息
	 * @param human
	 * @param targetId
	 * @param targetPetId
	 */
	public void sendRolePetInfoMsg(Human human, long targetId, long targetPetId) {
		UserSnap targetUserSnap = getUserSnap(targetId);
		if (null == targetUserSnap) {
			Loggers.offlineDataLogger.error("target userSnap not exist!targetId=" + targetId);
			return;
		}
		PetBattleSnap pbSnap = targetUserSnap.getPsManager().getPetById(targetPetId);
		if (pbSnap == null) {
			Loggers.offlineDataLogger.error("target PetBattleSnap not exist!targetId=" + 
					targetId + ";targetPetId=" + targetPetId);
			human.sendErrorMessage(LangConstants.PET_NOT_EXIST);
			return;
		}
		
		//查看的必须是宠物
		if (!pbSnap.isPet()) {
			return;
		}
		
		//获取基础信息的json串
		String jsonStr = pbSnap.toJson(true);
		//发消息
		human.sendMessage(new GCOfflineUserPetInfo(targetId, targetPetId, jsonStr));
	}
	
    /**
     * 玩家登录后的双倍经验点相关处理 1、挂机扣双倍经验点 2、恢复双倍经验点
     */
    public void checkDoublePointRelated(Human human) {
    	
    	// 重置玩家双倍经验点值
    	Timestamp _lastLogoutTime = human.getLastLogoutTime();
    	if (_lastLogoutTime != null) {
    		long lastGiveDoublePointTime = human.getLastGiveDoublePointTime();
    		long now = Globals.getTimeService().now();
    		TimeQueueService timeQueueService = Globals.getTimeQueueService();
    		
    		// 补充双倍经验点
    		SysPowerGiveTimeTemplate sysDoublePointGiveTimeTemplate = Globals.getTemplateCacheService().get(SharedConstants.CONFIG_TEMPLATE_DOUBLE_POINT_ID,
    				SysPowerGiveTimeTemplate.class);
    		int amountDoublePoint = 0;
    		for (int timeEventId : sysDoublePointGiveTimeTemplate.getTimeEventIds()) {
    			long compareTime = timeQueueService.getLastRealTime(timeEventId);
    			int reachTimes = TimeUtils.getSpecTimeCountBetween(lastGiveDoublePointTime, now, compareTime);
    			if (reachTimes > 0) {
    				amountDoublePoint += reachTimes * Globals.getGameConstants().getSysGiveDoublePointNum();
    			}
    		}
    		if (amountDoublePoint > 0) {
    			this.recoverDoublePoint(human, amountDoublePoint);
    		}
    	}
    }
    
    public void recoverDoublePoint(Human human, int amount) {
        int addDoublePoint = 0;
        // 更新最后一次给双倍经验点时间
        human.setLastGiveDoublePointTime(Globals.getTimeService().now());
        UserOfflineData offlineData = allUserOfflineData.get(human.getCharId());
        if(offlineData == null){
        	return ;
        }
        // 获得当前双倍经验点值
        if (offlineData.getCurDoublePoint() >= Globals.getGameConstants().getSysGiveDoublePointMax()) {
            // 如果当前双倍经验点大于系统双倍经验点值上限，代表用户购买了双倍经验点
            return ;
        } else {
            // 计算增加以后的双倍经验点值
            int afterDoublePoint = offlineData.getCurDoublePoint() + amount;
            // 如果当前双倍经验点值小于系统双倍经验点上限，只增加到双倍经验点的上限，其他不给增加
            if (afterDoublePoint >= Globals.getGameConstants().getSysGiveDoublePointMax()) {
                addDoublePoint = Globals.getGameConstants().getSysGiveDoublePointMax() - offlineData.getCurDoublePoint();
            } else {
                addDoublePoint = amount;
            }
            offlineData.setCurDoublePoint(offlineData.getCurDoublePoint() + addDoublePoint);
            offlineData.setModified();
            
            if(human.getTowerManager() == null){
            	return;
            }
            //记录日志
            Globals.getLogService().sendTowerLog(human, TowerLogReason.SYS_GIVE_DOUBLE_POINT, "", human.getTowerManager().getCurTowerLevel(), offlineData.getCurDoublePoint(), offlineData.getIsOpenDouble());
        }
    }
	
}
