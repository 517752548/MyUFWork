package com.imop.lj.gameserver.offlinedata;

import java.util.HashSet;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.UserSnapEntity;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserSnapDef.UserSnapPropAttr;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.MainSkillType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.scene.CommonScene;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

/**
 * 玩家离线数据对象，这里面的数据都是玩家数据的镜像，全都依赖于Human或pet，不会单独更新
 * 
 * @author yu.zhao
 * 
 */
/**
 * @author Administrator
 *
 */
public class UserSnap implements PersistanceObject<Long, UserSnapEntity> {
	/** 玩家角色ID 主键 */
	private long id;
	/** 账号Id */
	private String passportId;
	/** 服务器Id */
	private int serverId;
	/** 角色名称 */
	private String name;
	/** 等级 */
	private int level;
	
//	/** 心法Id */
//	private int mindId;
//	/** 心法等级 */
//	private int mindLevel;
	/** Map<心法Id,心法等级>*/
	private Map<Integer, Integer> mainSkillMap = Maps.newHashMap();
	/** 翅膀Id */
	private int wingId;
	/** 翅膀阶数 */
	private int wingLevel;
	/** 主将自动技能Id */
	private int autoActionId;
	/** 宠物自动技能Id */
	private int petAutoActionId;
	/** 主将自动技能等级 */
	private int autoSkillLevel;
	/** 主将自动技能层数*/
	private int autoSkillLayer;
	/** 宠物自动技能等级 */
	private int petAutoSkillLevel;
	
	/** 玩家通天塔等级 */
	private int towerLevel;
	
	/** 战斗加速倍数 */
	private int battleSpeed;
	
	/** 武将离线数据管理 */
	private PetSnapManager psManager;
	
	/** 主将装备位相关数据管理，装备、星级、宝石 */
	private EquipRelatedManager equipRelatedManager;
	
	/** 布阵信息 */
	private long[] formationArray = new long[7];
	
	/** 功能开启 */
	private Set<Integer> funcArray = new HashSet<Integer>();
	
	/** 是否已经在数据库中 */
	private boolean inDb;
	/** 生命期 */
	private final LifeCycle lifeCycle;
	/** 公共场景 */
	private CommonScene commonScene;
	
	public UserSnap() {
		this.lifeCycle = new LifeCycleImpl(this);
		commonScene = Globals.getSceneService().getCommonScene();
		this.psManager = new PetSnapManager(this);
		this.equipRelatedManager = new EquipRelatedManager(this);
	}

	/**
	 * 重新加载所有数据
	 * 
	 * @param human
	 */
	public void reload(Human human) {
		this.lifeCycle.activate();
		onBaseInfoChange(human);
		this.psManager.rebuild(human);
		this.equipRelatedManager.rebuildAll(human);
	}

	/**
	 * 基础信息改变时，如级别，国家，军衔，Vip等级，布阵
	 * 
	 * @param human
	 */
	public void onBaseInfoChange(Human human) {
		this.id = human.getUUID();
		this.name = human.getName();
		if (human.getPlayer() != null) {
			this.passportId = human.getPassportId();
		}
		this.serverId = human.getServerId();
		this.level = human.getLevel();
		
		//心法
//		this.mindId = human.getRunningMainSkillType().getIndex();
//		this.mindLevel = human.getMainSkillLevel();
		this.mainSkillMap.clear();
		for(Entry<Integer, Integer> entry : human.getMainSkillMap().entrySet()){
			this.mainSkillMap.put(entry.getKey(), entry.getValue());
		}
		
		//翅膀
		this.wingId = human.getWingManager().getWingingTplId();
		this.wingLevel = this.wingId != 0 ? human.getWingManager().getWinging().getWingLevel() : 0;
		
		//通天塔
		this.towerLevel = human.getTowerManager().getCurTowerLevel();
		
		//自动技能
		this.autoActionId = human.getAutoFightAction();
		this.autoSkillLevel = BattleDef.DEFAULT_SKILL_LEVEL;
		this.autoSkillLayer = BattleDef.DEFAULT_SUB_SKILL_LAYER;
		PetSkillInfo s1 = human.getPetManager().getLeader().getSkillInfo(this.autoActionId);
		if (s1 != null) {
			this.autoSkillLevel = s1.getLevel();
			this.autoSkillLayer = s1.getLayer();
		}
		//宠物自动技能
		this.petAutoActionId = human.getPetAutoFightAction();
		this.petAutoSkillLevel = BattleDef.DEFAULT_SKILL_LEVEL;
		Pet fightPet = Globals.getPetService().getFightPet(human);
		if (fightPet != null) {
			PetSkillInfo s2 = fightPet.getSkillInfo(this.petAutoActionId);
			if (s2 != null) {
				this.petAutoSkillLevel = s2.getLevel();
			}
		}
		
		// 功能开启
		this.funcArray.clear();
		for(FuncTypeEnum type : human.getFuncManager().getOpenedFuncSet()){
			this.funcArray.add(type.getIndex());
		}
		
		//战斗加速信息
		this.battleSpeed = human.getBattleManager().getSpeed();
		
		//武将信息
		this.psManager.rebuild(human);
		
		this.setModified();
	}

	public PetSnapManager getPsManager() {
		return psManager;
	}

	public EquipRelatedManager getEquipRelatedManager() {
		return equipRelatedManager;
	}

	public long getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public String getPassportId() {
		return passportId;
	}

	public int getServerId() {
		return serverId;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id;
	}

	@Override
	public Long getDbId() {
		return this.id;
	}

	@Override
	public String getGUID() {
		return "UserSnapEntity#" + this.id;
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
		return this.id;
	}

	@Override
	public UserSnapEntity toEntity() {
		UserSnapEntity userSnapEntity = new UserSnapEntity();
		userSnapEntity.setId(this.id);
		userSnapEntity.setName(this.name);
		userSnapEntity.setPassportId(this.passportId);
		userSnapEntity.setServerId(this.serverId);
		userSnapEntity.setLevel(this.level);
		
//		userSnapEntity.setMindId(this.mindId);
//		userSnapEntity.setMindLevel(this.mindLevel);
		userSnapEntity.setMainSkillPack(mainSKillMapToJson());
		userSnapEntity.setWingId(this.wingId);
		userSnapEntity.setWingLevel(this.wingLevel);
		userSnapEntity.setTowerLevel(this.towerLevel);
		userSnapEntity.setAutoActionId(this.autoActionId);
		userSnapEntity.setAutoSkillLevel(this.autoSkillLevel);
		userSnapEntity.setAutoSkillLayer(this.autoSkillLayer);
		userSnapEntity.setPetAutoActionId(this.petAutoActionId);
		userSnapEntity.setPetAutoSkillLevel(this.petAutoSkillLevel);
		
		userSnapEntity.setArmies(this.getPsManager().toJson());
		userSnapEntity.setFormation(this.formation2Json());
		userSnapEntity.setFuncPack(this.func2Json());
		userSnapEntity.setPropsPack(this.propAttr2Json());
		//装备相关数据
		userSnapEntity.setEquipPack(this.getEquipRelatedManager().toProps(false));
		
		return userSnapEntity;
	}

	
	@Override
	public void fromEntity(UserSnapEntity entity) {
		this.id = entity.getId();
		this.name = entity.getName();
		this.passportId = entity.getPassportId();
		this.serverId = entity.getServerId();
		this.level = entity.getLevel();
		
//		this.mindId = entity.getMindId();
//		this.mindLevel = entity.getMindLevel();
		mainSkillMapFromJson(entity.getMainSkillPack());
        
		this.wingId = entity.getWingId();
		this.wingLevel = entity.getWingLevel();
		this.towerLevel = entity.getTowerLevel();
		this.autoActionId = entity.getAutoActionId();
		this.autoSkillLevel = entity.getAutoSkillLevel();
		this.autoSkillLayer = entity.getAutoSkillLayer();
		this.petAutoActionId = entity.getPetAutoActionId();
		this.petAutoSkillLevel = entity.getPetAutoSkillLevel();
		
		this.psManager.fromJson(entity.getArmies());
		this.formationFromJson(entity.getFormation());
		this.funcFromJson(entity.getFuncPack());
		this.propAttrFromJson(entity.getPropsPack());
		//装备相关数据
		this.equipRelatedManager.fromProps(entity.getEquipPack());
	}
	
	public String mainSKillMapToJson() {
		JSONObject json = new JSONObject();
		if (null == mainSkillMap) {
			return json.toString();
		}
		for (Integer id : mainSkillMap.keySet()) {
			json.put(id, mainSkillMap.get(id));
		}
		return json.toString();
	}
	
	public void mainSkillMapFromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return;
		}
		JSONObject obj = JSONObject.fromObject(jsonStr);
		if(obj == null || obj.isEmpty()){
			return;
		}
		for (MainSkillType type : MainSkillType.values()) {
			if(type == MainSkillType.NULL){
				continue;
			}
			mainSkillMap.put(type.getIndex(), JsonUtils.getInt(obj, type.getIndex()));
		}
	}
	
	public String propAttr2Json(){
		JSONObject obj = new JSONObject();
		obj.put(UserSnapPropAttr.BATTLE_SPEED.getIndex(), this.battleSpeed);
		
		return obj.toString();
	}
	
	public void propAttrFromJson(String json){
		if(json == null || json.isEmpty()){
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(json);
		if(obj == null || obj.isNullObject() || obj.isEmpty()){
			return;
		}
		
		this.battleSpeed = JsonUtils.getInt(obj, UserSnapPropAttr.BATTLE_SPEED.getIndex());
	}

	public String formation2Json(){
		JSONArray array = new JSONArray();
		array.add(this.formationArray.length);
		for(long petId : this.formationArray){
			array.add(petId);
		}
		return array.toString();
	}
	
	public String func2Json(){
		JSONArray array = new JSONArray();
		for(Integer funcId : this.funcArray){
			array.add(funcId);
		}
		return array.toString();
	}
	
	public void formationFromJson(String json){
		if(json == null || json.isEmpty()){
			return;
		}
		
		JSONArray array = JSONArray.fromObject(json);
		if (array == null || array.isEmpty()) {
			return;
		}

		int length = array.getInt(0);
		length = length > this.formationArray.length ? this.formationArray.length : length;
		for (int i = 1; i <= length; i++) {
			this.formationArray[i - 1] = array.getLong(i);
		}
	}
	
	public void funcFromJson(String json){
		if(json == null || json.isEmpty()){
			return;
		}
		
		JSONArray array = JSONArray.fromObject(json);
		if (array == null || array.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < array.size(); i++) {
			this.funcArray.add(array.getInt(i));
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

	public long[] getFormationArray() {
		return formationArray;
	}

	public void setFormationArray(long[] formationArray) {
		this.formationArray = formationArray;
	}

	public int getLevel() {
		return level;
	}

	/**
	 * 获取主将即玩家本身的模板Id
	 * @return
	 */
	public int getHumanTplId() {
		// 从武将管理中取
		if (null != psManager && null != psManager.getLeader()) {
			return psManager.getLeader().getTempId();
		}
		return 0;
	}
	
	/**
	 * 获取主将即玩家本身的模板
	 * @return 可能为null
	 */
	public PetTemplate getHumanTemplate() {
		if (null != psManager && null != psManager.getLeader()) {
			return psManager.getLeader().getTemplate();
		}
		return null;
	}
	
	/**
	 * 获取玩家性别
	 * @return
	 */
	public Sex getHumanSex() {
		if (null != psManager && null != psManager.getLeader() && null != psManager.getLeader().getTemplate()) {
			return psManager.getLeader().getTemplate().getSex();
		}
		return Sex.FEMALE;
	}
	
	/**
	 * 获取玩家的职业id
	 * @return
	 */
	public int getHumanJobTypeId() {
		if (null != psManager && null != psManager.getLeader() && null != psManager.getLeader().getTemplate()) {
			return psManager.getLeader().getTemplate().getJobId();
		}
		return 0;
	}
	
	/**
	 * 获取玩家的职业
	 * @return 如果是非法数据，可能返回null
	 */
	public JobType getHumanJobType() {
		return JobType.valueOf(getHumanJobTypeId());
	}
	
	public Set<Integer> getFuncArray() {
		return funcArray;
	}

	public void setFuncArray(Set<Integer> funcArray) {
		this.funcArray = funcArray;
	}

//	public int getMindId() {
//		return mindId;
//	}
//
//	public int getMindLevel() {
//		return mindLevel;
//	}
	
	public int getWingId() {
		return wingId;
	}

	public int getWingLevel() {
		return wingLevel;
	}
	public int getTowerLevel() {
		return towerLevel;
	}
	
	public int getAutoActionId() {
		return autoActionId;
	}

	public int getPetAutoActionId() {
		return petAutoActionId;
	}

	public int getAutoSkillLevel() {
		return autoSkillLevel;
	}
	
	public int getAutoSkillLayer() {
		return autoSkillLayer;
	}

	public int getPetAutoSkillLevel() {
		return petAutoSkillLevel;
	}

	public int getBattleSpeed() {
		return battleSpeed;
	}

	/**
	 * 主将身上的装备发生变化时更新
	 * @param human
	 */
	public void onLeaderEquipUpdate(Human human) {
		this.equipRelatedManager.rebuildEquip(human);
		this.setModified();
	}
	
	/**
	 * 装备位星级发生变化时更新
	 * @param human
	 */
	public void onEquipStarUpdate(Human human) {
		this.equipRelatedManager.rebuildStar(human);
		this.setModified();
	}
	
//	/**
//	 * 装备位镶嵌的宝石发生变化时更新
//	 * @param human
//	 */
//	public void onLeaderGemUpdate(Human human) {
//		this.equipRelatedManager.rebuildGem(human);
//		this.setModified();
//	}
	
	public PetSkillInfo getAutoSkillEmbedEffectList() {
		return getPsManager().getLeader().getSkillMap().get(getAutoActionId());
	}
}
