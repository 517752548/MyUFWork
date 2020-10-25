package com.imop.lj.gameserver.offlinedata;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.UserOfflineDataEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.CommonScene;

import net.sf.json.JSONArray;

/**
 * 玩家数据中的一部分，这里面的数据需要离线也能更新，所以单独出来
 * @author Administrator
 *
 */
public class UserOfflineData implements PersistanceObject<Long, UserOfflineDataEntity>{
	/** 玩家角色uuid */
	private long roleId;
	/** 账号Id */
	private String passportId;
	
	/** 血池 */
	private long hpPool;
	/** 蓝池 */
	private long mpPool;
	/** 宠物寿命池 */
	private long lifePool;
	
	/** 出战中的宠物Id，0 - 未出战 */
	private long fightPetId;
	
	/** 出战中的骑宠Id，0 - 未出战 */
	private long fightPetHorseId;

	/** 玩家宠物数据map，这里只有需要离线更新的数据，其他都在Pet上 */
	private Map<Long, UserPetData> petDataMap = Maps.newHashMap();
	/** 玩家骑宠数据map，这里只有需要离线更新的数据，其他都在Pet上 */
	private Map<Long, UserPetHorseData> petHorseDataMap = Maps.newHashMap();
//	/** 玩家伙伴数据map */
//	private Map<Integer, UserFriendData> friendDataMap = Maps.newHashMap();
	
	/** 当前使用的阵法索引 */
	private int curArrayIndex;
	/** 每个阵法的伙伴模板Id数组 */
	private PetFriendArray[] allFriendArray;
	/** 当前帮派boss挑战进度 */
	private int curCorpsBossLevel;
	/** 玩家帮派boss数据map*/
	private Map<Integer, UserCorpsBossData> bossDataMap = Maps.newHashMap();
	
	/** 是否已经在数据库中 */
	private boolean inDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	/** 公共场景 */
	private CommonScene commonScene;
	
	public UserOfflineData() {
		allFriendArray = new PetFriendArray[SharedConstants.FRIEND_ARRAY_NUM];
		this.lifeCycle = new LifeCycleImpl(this);
		commonScene = Globals.getSceneService().getCommonScene();
		init();
	}
	
	private void init() {
		for (int i = 0; i < allFriendArray.length; i++) {
			allFriendArray[i] = new PetFriendArray();
		}
	}
	
	public UserPetData getPetData(long petId) {
		return petDataMap.get(petId);
	}
	
	public void addUserPetData(long petId, UserPetData petData) {
		petDataMap.put(petId, petData);
	}
	
	public void delUserPetData(long petId) {
		petDataMap.remove(petId);
		//如果解雇的是出战宠物，则需要置为0
		if (petId == fightPetId) {
			fightPetId = 0;
		}
	}
	
	public UserPetHorseData getPetHorseData(long petHorseId) {
		return petHorseDataMap.get(petHorseId);
	}
	
	public void addUserPetHorseData(long petHorseId, UserPetHorseData petData) {
		petHorseDataMap.put(petHorseId, petData);
	}
	
	public void delUserPetHorseData(long petHorseId) {
		petHorseDataMap.remove(petHorseId);
		//如果解雇的是出战宠物，则需要置为0
		if (petHorseId == fightPetHorseId) {
			fightPetHorseId = 0;
		}
	}
	
	public UserCorpsBossData getCorpsBossData(int level) {
		return bossDataMap.get(level);
	}
	
	/**
	 * 得到玩家本周最高帮派boss进度
	 * @return
	 */
	public int getCorpsBossMaxLevel(){
		int maxLevel = 0;
		for (Integer level : bossDataMap.keySet()) {
			if (maxLevel < level) {
				maxLevel = level;
			}
		}
		//下周第一次打的时候,本周boss进度应该从0开始
		if(maxLevel > 0){
			 UserCorpsBossData data = bossDataMap.get(maxLevel);
			 if (data != null 
					 && !TimeUtils.isInSameWeek(data.getLastUpdateTime(), Globals.getTimeService().now())) {
				 bossDataMap.clear();
				 this.setModified();
			 }
		}
		return maxLevel;
	}
	
	public void addCorpsBossData(int level, UserCorpsBossData data) {
		bossDataMap.put(level, data);
	}
	
	public void delCorpsBossData(int level) {
		bossDataMap.remove(level);
	}
	
//	public UserFriendData getUserFriendData(int tplId) {
//		return friendDataMap.get(tplId);
//	}
	
	public String getPassportId() {
		return passportId;
	}
	
	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public long getHpPool() {
		return hpPool;
	}

	public void setHpPool(long hpPool) {
		this.hpPool = hpPool;
	}

	public long getMpPool() {
		return mpPool;
	}

	public void setMpPool(long mpPool) {
		this.mpPool = mpPool;
	}

	public Map<Long, UserPetData> getPetDataMap() {
		return petDataMap;
	}

	public void setPetDataMap(Map<Long, UserPetData> petDataMap) {
		for(Entry<Long, UserPetData> entry : petDataMap.entrySet()){
			this.petDataMap.put(entry.getKey(), entry.getValue());
		}
	}
	
	public Map<Long, UserPetHorseData> getPetHorseDataMap() {
		return petHorseDataMap;
	}
	
	public void setPetHorseDataMap(Map<Long, UserPetHorseData> petHorseDataMap) {
		for(Entry<Long, UserPetHorseData> entry : petHorseDataMap.entrySet()){
			this.petHorseDataMap.put(entry.getKey(), entry.getValue());
		}
	}
	
	public Map<Integer, UserCorpsBossData> getCorpsBossMap() {
		return bossDataMap;
	}

	public void setCorpsBossMap(Map<Integer, UserCorpsBossData> dataMap) {
		for(Entry<Integer, UserCorpsBossData> entry : dataMap.entrySet()){
			this.bossDataMap.put(entry.getKey(), entry.getValue());
		}
	}

//	public Map<Integer, UserFriendData> getFriendDataMap() {
//		return friendDataMap;
//	}
//
//	public void addFriendDataMap(UserFriendData data) {
//		this.friendDataMap.put(data.getTplId(), data);
//	}

	public int getCurArrayIndex() {
		return curArrayIndex;
	}

	public void setCurArrayIndex(int curArrayIndex) {
		this.curArrayIndex = curArrayIndex;
	}

	public PetFriendArray[] getAllFriendArray() {
		return allFriendArray;
	}
	
	public int getCurCorpsBossLevel() {
		return curCorpsBossLevel;
	}

	public void setCurCorpsBossLevel(int curCorpsBossLevel) {
		this.curCorpsBossLevel = curCorpsBossLevel;
	}
	
	public long getLifePool() {
		return lifePool;
	}

	public void setLifePool(long lifePool) {
		this.lifePool = lifePool;
	}

	public long getFightPetId() {
		return fightPetId;
	}

	public void setFightPetId(long fightPetId) {
		this.fightPetId = fightPetId;
	}

	public long getFightPetHorseId() {
		return fightPetHorseId;
	}

	public void setFightPetHorseId(long fightPetHorseId) {
		this.fightPetHorseId = fightPetHorseId;
	}

	@Override
	public void setDbId(Long id) {
		this.roleId = id;
	}

	@Override
	public Long getDbId() {
		return this.roleId;
	}

	@Override
	public String getGUID() {
		return "UserOfflineDataEntity#" + this.roleId;
	}

	@Override
	public boolean isInDb() {
		return this.inDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.roleId;
	}

	@Override
	public UserOfflineDataEntity toEntity() {
		UserOfflineDataEntity entity = new UserOfflineDataEntity();
		entity.setId(this.roleId);
		entity.setPassportId(this.passportId);
		entity.setHpPool(this.hpPool);
		entity.setMpPool(this.mpPool);
		entity.setLifePool(this.lifePool);
		entity.setFightPetId(this.fightPetId);
		entity.setFightPetHorseId(this.fightPetHorseId);
		
		entity.setCurArrayIndex(this.curArrayIndex);
		entity.setFriendArray(friendArrayToJson());
		
//		entity.setFriendPack(friendMapToJson());
		entity.setPetPack(petMapToJson());
		entity.setPetHorsePack(petHorseMapToJson());
		entity.setCurCorpsBossLevel(this.curCorpsBossLevel);
		entity.setCorpsBossPack(bossMapToJson());
		
		return entity;
	}

	@Override
	public void fromEntity(UserOfflineDataEntity entity) {
		this.roleId = entity.getId();
		this.passportId = entity.getPassportId();
		this.hpPool = entity.getHpPool();
		this.mpPool = entity.getMpPool();
		this.lifePool = entity.getLifePool();
		this.fightPetId = entity.getFightPetId();
		this.fightPetHorseId = entity.getFightPetHorseId();
		
		this.curArrayIndex = entity.getCurArrayIndex();
		this.friendArrayFromJson(entity.getFriendArray());
		
//		this.friendMapFromJson(entity.getFriendPack());
		this.petMapFromJson(entity.getPetPack());
		this.petHorseMapFromJson(entity.getPetHorsePack());
		this.curCorpsBossLevel = entity.getCurCorpsBossLevel();
		this.bossMapFromJson(entity.getCorpsBossPack());
	}
	
	public String friendArrayToJson() {
		JSONArray jsonArr = new JSONArray();
		for (int i = 0; i < allFriendArray.length; i++) {
			jsonArr.add(allFriendArray[i].toJson());
		}
		return jsonArr.toString();
	}
	
	public void friendArrayFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			PetFriendArray pfa = PetFriendArray.fromJsonStr(array.getString(i));
			if (pfa != null) {
				allFriendArray[i] = pfa;
			}
		}
	}
	
//	public String friendMapToJson() {
//		JSONArray jsonArr = new JSONArray();
//		for (UserFriendData ufd : friendDataMap.values()) {
//			jsonArr.add(ufd.toJson());
//		}
//		return jsonArr.toString();
//	}
//	
//	public void friendMapFromJson(String jsonStr) {
//		if (jsonStr == null || jsonStr.isEmpty()) {
//			return;
//		}
//		
//		JSONArray array = JSONArray.fromObject(jsonStr);
//		if (array == null || array.isEmpty()) {
//			return;
//		}
//		
//		for (int i = 0; i < array.size(); i++) {
//			UserFriendData upd = UserFriendData.fromJson(array.getString(i));
//			if (upd != null) {
//				friendDataMap.put(upd.getTplId(), upd);
//			}
//		}
//	}
	
	public String petMapToJson() {
		JSONArray jsonArr = new JSONArray();
		for (UserPetData upd : petDataMap.values()) {
			jsonArr.add(upd.toJson());
		}
		return jsonArr.toString();
	}
	
	public String petHorseMapToJson() {
		JSONArray jsonArr = new JSONArray();
		for (UserPetHorseData upd : petHorseDataMap.values()) {
			jsonArr.add(upd.toJson());
		}
		return jsonArr.toString();
	}
	
	public String bossMapToJson() {
		JSONArray jsonArr = new JSONArray();
		for (UserCorpsBossData data : bossDataMap.values()) {
			jsonArr.add(data.toJson());
		}
		return jsonArr.toString();
	}
	
	public void petMapFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			UserPetData upd = UserPetData.fromJson(array.getString(i));
			if (upd != null) {
				petDataMap.put(upd.getUuid(), upd);
			}
		}
	}
	
	public void petHorseMapFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			UserPetHorseData upd = UserPetHorseData.fromJson(array.getString(i));
			if (upd != null) {
				petHorseDataMap.put(upd.getUuid(), upd);
			}
		}
	}
	
	public void bossMapFromJson(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}
		
		JSONArray array = JSONArray.fromObject(jsonStr);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			UserCorpsBossData data = UserCorpsBossData.fromJson(array.getString(i));
			if (data != null) {
				bossDataMap.put(data.getBossLevel(), data);
			}
		}
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}
	}

	/**
	 * 删除信息
	 */
	public void delete() {
		onDelete();
	}

	/**
	 * 实例被删除,触发删除机制
	 */
	protected void onDelete() {
		this.lifeCycle.destroy();
		this.commonScene.getCommonDataUpdater().addDelete(lifeCycle);
	}

	/**
	 * 激活此对象，并初始化属性 此方法在玩家登录加载完数据
	 */
	public void active() {
		getLifeCycle().activate();
	}
}
