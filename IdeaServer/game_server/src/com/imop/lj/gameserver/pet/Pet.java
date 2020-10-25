package com.imop.lj.gameserver.pet;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemDef.BindType;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.pet.PetDef.PetState;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.prop.PetPropertyManager;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.role.RoleFinalProps;
import com.imop.lj.gameserver.role.RoleTypes;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RoleBaseStrProperties;

/**
 * 武将对象，基类
 */
public abstract class Pet extends Role implements PersistanceObject<Long, PetEntity>, InitializeRequired {

	/** 宠物UUID */
	protected long petUUID;

	/** 主人  */
	protected Human owner;

	/** 是否已经在数据库中 */
	protected boolean inDb;

	/** 生命期 */
	protected final LifeCycle lifeCycle;

	/** 武将属性管理器  */
	protected final PetPropertyManager propertyManager;
	
	/** 武将技能Map，含天赋技能和普通技能 */
	protected Map<Integer, PetSkillInfo> skillMap = new HashMap<Integer, PetSkillInfo>();
	
	protected final Comparator<PetSkillInfo> petSkillSortor = new PetSkillSortor();
	
	/** 武将技能快捷栏Map<快捷栏索引, 技能快捷栏>*/
	protected Map<Integer, PetSkillShortcutInfo> skillShortcutMap = new HashMap<Integer, PetSkillShortcutInfo>();
	
	/** 一级属性已分配点数&成长附加值 Map<一级属性key，已分配点数> */
	protected Map<Integer, Integer> aPropAddMap = new HashMap<Integer, Integer>();

	public Pet() {
		super(RoleTypes.PET);
		lifeCycle = new LifeCycleImpl(this);
		propertyManager = new PetPropertyManager(this);
	}

	/**
	 * 激活此武将，并初始化属性 此方法在玩家登录加载完数据，或者获得新武将时调用
	 */
	public void initPropsAndActive() {
		initProps();
		getLifeCycle().activate();
	}
	
	/**
	 * 初始化此武将背包
	 */
	public void initBag() {
		this.owner.getInventory().addPetBag(this);
//		this.owner.getInventory().addPetGemBag(this);
	}

	/**
	 * @description: 初始化宠物的所有属性但是这时宠物还没有被激活
	 * @author: liyuan
	 */
	public void initProps() {
		getPropertyManager().initPropety();
	}
	
	@Override
	public Human getOwner() {
		return owner;
	}

	/**
	 * 设置主人
	 * 
	 * @param owner
	 * @throws IllegalArgumentException
	 *             当owner为空时抛出
	 */
	public void setOwner(Human owner) {
		Assert.notNull(owner);
		this.owner = owner;
		onModified();
	}

	@Override
	protected List<KeyValuePair<Integer, Integer>> changedNum() {
		// 保存数值类属性变化
		List<KeyValuePair<Integer, Integer>> intNumChanged = new ArrayList<KeyValuePair<Integer, Integer>>();

		// XXX 处理 一二级属性，进行了去余取整 
		if (this.getPropertyManager().isChanged()) {
			KeyValuePair<Integer, Float>[] _numChanged = this.getPropertyManager().getChanged(); // float
			for (KeyValuePair<Integer, Float> pair : _numChanged) {
				intNumChanged.add(new KeyValuePair<Integer, Integer>(pair.getKey(), pair.getValue().intValue()));
			}
		}

		// 处理 baseIntProps
		if (this.baseIntProperties.isChanged()) {
			KeyValuePair<Integer, Integer>[] changes = this.baseIntProperties.getChanged();
			for (KeyValuePair<Integer, Integer> pair : changes) {
				intNumChanged.add(pair);
			}
		}

		return intNumChanged;
	}

	@Override
	public PetPropertyManager getPropertyManager() {
		return propertyManager;
	}

	@Override
	public long getUUID() {
		return this.petUUID;
	}

	@Override
	protected void onModified() {
		this.setModified();
	}

	@Override
	protected void sendMessage(GCMessage msg) {
		if (msg != null) {
			if (owner != null) {
				if (owner.getPlayer() != null) {
					owner.getPlayer().sendMessage(msg);
				}
			} else {
				// XXX 增加errorlog
			}
		}
	}

	@Override
	public long getCharId() {
		return owner != null ? owner.getUUID() : 0L;
	}

	@Override
	public Long getDbId() {
		return petUUID;
	}

	@Override
	public String getGUID() {
		return "pet#" + getUUID();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public boolean isInDb() {
		return this.inDb;
	}

	@Override
	public void setDbId(Long id) {
		this.petUUID = Long.valueOf(id);
	}

	@Override
	public void setInDb(boolean inDb) {
		this.inDb = inDb;
	}

	@Override
	public void setModified() {
		if (owner != null) {
			// TODO 为了防止发生一些错误的使用状况,暂时把此处的检查限制得很严格
			this.lifeCycle.checkModifiable();
			if (this.lifeCycle.isActive()) {
				// 物品的生命期处于活动状态,并且该宠物不是空的,则执行通知更新机制进行
				owner.getPlayer().getDataUpdater().addUpdate(lifeCycle);
			}
		}
	}
	
	public void onDelete() {
		if (this.lifeCycle.isActive()) {
			Loggers.petLogger.info("onDelete pet=" + getUUID());
			this.lifeCycle.destroy();
			this.getOwner().getPlayer().getDataUpdater().addDelete(this.getLifeCycle());
		}
	}

	@Override
	public abstract void init();
	
	@Override
	public void heartBeat() {
		
	}
	
	/**
	 * 是否主将
	 * @return
	 */
	public boolean isLeader() {
		return this.getPetType() == PetType.LEADER;
	}
	
	/**
	 * 是否宠物
	 * @return
	 */
	public boolean isPet() {
		return this.getPetType() == PetType.PET;
	}
	
	/**
	 * 是否伙伴
	 * @return
	 */
	public boolean isFriend() {
		return this.getPetType() == PetType.FRIEND;
	}
	
	/**
	 * 是否骑宠
	 * @return
	 */
	public boolean isHorse() {
		return this.getPetType() == PetType.HORSE;
	}
	
	public boolean isNormal(){
		return this.getPetState() == PetState.NORMAL.getIndex();
	}
	
	@Override
	public void fromEntity(PetEntity entity) {
		this.setDbId(entity.getId());
		this.setLevel(entity.getLevel());
		this.setExp(entity.getExp());
		this.setTemplateId(entity.getTemplateId());
		this.setPetType(entity.getPetType());
		this.setCreateTime(entity.getCreateDate().getTime());
		this.setDeleted(entity.getDeleted());
		final Timestamp deleteTime = entity.getDeleteDate();
		if (deleteTime != null) {
			this.setDeleteTime(deleteTime.getTime());
		}
		this.setPetState(entity.getPetState());
		this.setLastHireTime(entity.getLastHireDate().getTime());
		this.setLastFireTime(entity.getLastFireDate().getTime());
		
		this.setName(entity.getName());
		
		this.setStar(entity.getStarId());
		this.setColor(entity.getColorId());
		this.setSkillProp(entity.getSkillProp());
		this.setSkillShortcutProp(entity.getSkillShortcutProp());
		
		this.setLeftPoint(entity.getLeftPoint());
		this.setAPropAdd(entity.getaPropAddPoint());
		
		this.setPetScore(entity.getPetScore());
		this.setSkillBarNum(entity.getPetSkillBarNum());
		this.setPetAffinationNum(entity.getPetAffinationNum());
		this.setPetSenseRate(entity.getPetSenseRate());
		
		//绑定状态
		this.setBind(entity.getBindFlag() == BindType.BIND.getIndex());
	}

	@Override
	public PetEntity toEntity() {
		PetEntity entity = new PetEntity();
		entity.setId(this.getDbId());
		entity.setCharId(this.getCharId());
		entity.setCreateDate(new Timestamp(this.getCreateTime()));
		entity.setLevel((short)this.getLevel());
		entity.setExp(this.getExp());
		entity.setTemplateId(this.getTemplateId());
		entity.setPetType(this.getPetType().getIndex());
		entity.setDeleted(this.getDeleted());
		entity.setDeleteDate(this.getDeleted() == 1 ? new Timestamp(this.getDeleteTime() ): null);
		entity.setPetState(this.getPetState());
		entity.setLastHireDate(new Timestamp(this.getLastHireTime()));
		entity.setLastFireDate(new Timestamp(this.getLastFireTime()));
		entity.setStarId(this.getStar());
		entity.setColorId(this.getColor());
		entity.setSkillProp(this.getSkillProp());
		entity.setSkillShortcutProp(this.getSkillShortcutProp());
		
		entity.setLeftPoint(this.getLeftPoint());
		entity.setaPropAddPoint(this.getAPropAddStr());
		
		entity.setPetScore(this.getPetScore());
		entity.setPetSkillBarNum(this.getSkillBarNum());
		entity.setPetAffinationNum(this.getPetAffinationNum());
		entity.setPetSenseRate(this.getPetSenseRate());
		
		//绑定状态
		entity.setBindFlag(this.isBind() ? BindType.BIND.getIndex() : BindType.NOT_BIND.getIndex());
		
		return entity;
	}
	
	private String getSkillProp() {
		JSONArray json = new JSONArray();
		for (PetSkillInfo skill : skillMap.values()) {
			json.add(skill.getJsonStr());
		}
		return json.toString();
	}
	
	private void setSkillProp(String skillPropStr) {
		if (skillPropStr == null || skillPropStr.isEmpty()) {
			return;
		}
		
		JSONArray json = JSONArray.fromObject(skillPropStr);
		if (json.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < json.size(); i++) {
			String j = json.getString(i);
			PetSkillInfo info = PetSkillInfo.fromJsonStr(j);
			if (info != null) {
				addSkill(info);
			} else {
				Loggers.petLogger.error("skillInfo is null!j=" + j + ";skillPropStr=" + skillPropStr + ";petId=" + getUUID());
			}
		}
	}
	
	private String getSkillShortcutProp() {
		JSONArray json = new JSONArray();
		for (PetSkillShortcutInfo skill : skillShortcutMap.values()) {
			json.add(skill.toJson());
		}
		return json.toString();
	}
	
	private void setSkillShortcutProp(String skillPropStr) {
		if (skillPropStr == null || skillPropStr.isEmpty()) {
			return;
		}
		
		JSONArray json = JSONArray.fromObject(skillPropStr);
		if (json.isEmpty()) {
			return;
		}
		
		for (int i = 0; i < json.size(); i++) {
			String j = json.getString(i);
			PetSkillShortcutInfo info = PetSkillShortcutInfo.fromJson(j);
			if (info != null) {
				skillShortcutMap.put(info.getIndex(), info);
			} else {
				Loggers.petLogger.error("PetSkillShortcutInfo is null!j=" + j + ";skillPropStr=" + skillPropStr + ";petId=" + getUUID());
			}
		}
	}
	
	
	
	private String getAPropAddStr() {
		JSONObject json = new JSONObject();
		if (aPropAddMap != null) {
			for (Entry<Integer, Integer> entry : aPropAddMap.entrySet()) {
				json.put(entry.getKey(), entry.getValue());
			}
		}
		return json.toString();
	}
	
	private void setAPropAdd(String aPropAddStr) {
		if (aPropAddStr == null || aPropAddStr.isEmpty()) {
			return;
		}
		
		JSONObject jsonObj = JSONObject.fromObject(aPropAddStr);
		if (jsonObj == null || jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return;
		}
		
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END; k++) {
				updateAddAProp(k, JsonUtils.getInt(jsonObj, k));
		}
	}
	
	/**
	 * 获取技能列表，按照位置id排序，不包括普通攻击
	 * @return
	 */
	public List<PetSkillInfo> getSkillList() {
		List<PetSkillInfo> lt = new ArrayList<PetSkillInfo>();
		lt.addAll(skillMap.values());
		Collections.sort(lt, petSkillSortor);
		return lt;
	}
	
	private class PetSkillSortor implements Comparator<PetSkillInfo> {
		@Override
		public int compare(PetSkillInfo o1, PetSkillInfo o2) {
			//FIXME
//			if (o1.getPosId().getIndex() > o2.getPosId().getIndex()) {
//				return 1;
//			} else if (o1.getPosId().getIndex() < o2.getPosId().getIndex()) {
//				return -1;
//			}
			return 0;
		}
	}
	
	
	/**
	 * 获取指定位置的武将技能信息
	 * @param skillPos
	 * @return
	 */
	public PetSkillInfo getSkillInfo(int skillId) {
		return skillMap.get(skillId);
	}
	
	public void removeSkill(int skillId) {
		skillMap.remove(skillId);
	}
	
	public void addSkill(PetSkillInfo skill) {
		skillMap.put(skill.getSkillId(), skill);
		this.setModified();
	}
	
	public boolean hasSkill(int skillId) {
		return skillMap.containsKey(skillId);
	}
	
	public void clearAllSkill(){
		skillMap.clear();
		this.setModified();
	}
	
	public void clearAllTalentSkill() {
		Iterator<Integer> it = skillMap.keySet().iterator();
		for (;it.hasNext();) {
			Integer k = it.next();
			if (skillMap.get(k).isTalent()) {
				it.remove();
			}
		}
	}
	
	public void clearAllNormalSkill(){
		Iterator<Integer> it = skillMap.keySet().iterator();
		for (;it.hasNext();) {
			Integer k = it.next();
			if (!skillMap.get(k).isTalent()) {
				it.remove();
			}
		}
		
		this.setModified();
	}
	
	public void clearSkillShortcut(){
		this.skillShortcutMap.clear();
		this.setModified();
	}
	
	public void setSkillMap(Map<Integer, PetSkillInfo> skillMap) {
		if(skillMap == null || skillMap.isEmpty()){
			return;
		}
		for(Entry<Integer,PetSkillInfo> entry : skillMap.entrySet()){
			this.skillMap.put(entry.getKey(), entry.getValue());
		}
	}

	public void setaPropAddMap(Map<Integer, Integer> aPropAddMap) {
		if(aPropAddMap == null || aPropAddMap.isEmpty()){
			return;
		}
		for(Entry<Integer,Integer> entry : aPropAddMap.entrySet()){
			this.aPropAddMap.put(entry.getKey(), entry.getValue());
		}
	}

	/**
	 * 获取武将名字
	 * @return
	 */
	public String getName() {
		if (getTemplate() != null) {
			return getTemplate().getName();
		}
		return "";
	}
	
	public void setName(String name) {
		this.baseStrProperties.setString(RoleBaseStrProperties.NAME, name);
		this.setModified();
	}

	/**
	 * 获取下次升级经验值
	 * 
	 * @return
	 */
	@Override
	public long getLevelUpNeedExp() {
		return this.baseStrProperties.getLong(RoleBaseStrProperties.LEVEL_UP_NEED_EXP);
	}
	
	/**
	 * 设置下次升级经验值
	 * 
	 * @return
	 */
	public void setLevelUpNeedExp(long exp) {
		this.baseStrProperties.setLong(RoleBaseStrProperties.LEVEL_UP_NEED_EXP, exp);
	}

	@Override
	public void setLevel(int level) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LEVEL, level);
//		long upgradeExp = isLeader() ? 
//				Globals.getTemplateCacheService().get(this.getLevel(), PetLevelTemplate.class).getMainExp() :
//				Globals.getTemplateCacheService().get(this.getLevel(), PetLevelTemplate.class).getPetExp();
//		this.setLevelUpNeedExp(upgradeExp);
		this.setModified();
	}

	/**
	 * @return
	 */
	@Override
	public int getLevel() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.LEVEL);
	}
	
	
	/**
	 * 获得宠物评分
	 */
	public int getPetScore() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_SCORE);
	}
	
	/**
	 * 修改宠物评分
	 * @param score
	 */
	public void setPetScore(int score){
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_SCORE, score);
		this.setModified();
	}
	/**
	 * 获取武将星级
	 * @return
	 */
	public int getStar() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.STAR);
	}
	
	public void setStar(int star) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.STAR, star);
		this.setModified();
	}
	
	/**
	 * 获取武将颜色
	 * @return
	 */
	public int getColor() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.COLOR);
	}
	
	public void setColor(int color) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.COLOR, color);
		this.setModified();
	}

	/** 经验值 */
	public long getExp() {
		return this.baseStrProperties.getLong(RoleBaseStrProperties.EXP);
	}
	
	/** 经验值 */
	public void setExp(long exp) {
		this.baseStrProperties.setLong(RoleBaseStrProperties.EXP, exp);
		this.setModified();
	}

	/** 武将类型 */
	public PetType getPetType() {
		return PetType.valueOf(this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_TYPE));
	}

	/** 武将类型 1主将0非主将*/
	public void setPetType(int petType) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_TYPE, petType);
		this.setModified();
	}

	/** 模板ID */
	public int getTemplateId() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.TEMPLET_ID);
	}

	/** 模板ID */
	public void setTemplateId(int templateId) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.TEMPLET_ID, templateId);
		this.setModified();
	}
	
	/** 创建日期 */
	public long getCreateTime() {
		return this.finalProps.getLong(RoleFinalProps.CREATE_TIME);
	}

	/** 创建日期 */
	public void setCreateTime(long createDate) {
		this.finalProps.setLong(RoleFinalProps.CREATE_TIME, createDate);
	}

	/** 删除时间 */
	public long getDeleteTime() {
		return this.finalProps.getLong(RoleFinalProps.DELETE_TIME);
	}

	/** 删除时间 */
	public void setDeleteTime(long deleteDate) {
		this.finalProps.setLong(RoleFinalProps.DELETE_TIME, deleteDate);
	}

	/** 是否已删除 */
	public int getDeleted() {
		return this.finalProps.getInt(RoleFinalProps.DELETED);
	}

	/** 是否已删除 */
	public void setDeleted(int deleted) {
		this.finalProps.setInt(RoleFinalProps.DELETED, deleted);
	}

	/** 技能id,对于主将可以改变技能，非主将技能从模板里获得 */
	public int getSkillId() {
		return 0;
//		if(this.isLeader()){
//			return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.SKILL_ID);
//		}else{
//			return 1;//this.getTemplate().getSkillId();
//		}
	}

	/** 技能id,对于主将可以改变技能，非主将技能从模板里获得 */
	public void setSkillId(int skillId) {
//		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.SKILL_ID, skillId);
//		this.setModified();
	}

	/**武将当前状态*/
	public int getPetState() {
		return this.finalProps.getInt(RoleFinalProps.PET_STATE);
	}

	/**设置武将当前状态*/
	public void setPetState(int petState) {
		this.finalProps.setInt(RoleFinalProps.PET_STATE, petState);
		this.setModified();
	}

	/**武将最后一次招募时间*/
	public long getLastHireTime() {
		return this.finalProps.getLong(RoleFinalProps.LAST_HIRE_TIME);
	}

	/**设置武将最后一次招募时间*/
	public void setLastHireTime(long lastHireTime) {
		this.finalProps.setLong(RoleFinalProps.LAST_HIRE_TIME, lastHireTime);
		this.setModified();
	}

	/**武将最后一次解雇时间*/
	public long getLastFireTime() {
		return this.finalProps.getLong(RoleFinalProps.LAST_FIRE_TIME);
	}

	/**设置武将最后一次解雇时间*/
	public void setLastFireTime(long lastFireTime) {
		this.finalProps.setLong(RoleFinalProps.LAST_FIRE_TIME, lastFireTime);
		this.setModified();
	}
	
	/**还童次数*/
	public int getPetAffinationNum() {
		return this.finalProps.getInt(RoleFinalProps.PET_AFFINATION_NUM);
	}
	
	/**设置还童次数*/
	public void setPetAffinationNum(int affinationNum) {
		this.finalProps.setInt(RoleFinalProps.PET_AFFINATION_NUM, affinationNum);
		this.setModified();
	}
	
	/**领悟技能成功率,扩大1000倍*/
	public int getPetSenseRate() {
		return this.finalProps.getInt(RoleFinalProps.PET_SENSE_RATE);
	}
	
	/**设置领悟技能成功率,扩大1000倍*/
	public void setPetSenseRate(int senseRate) {
		this.finalProps.setInt(RoleFinalProps.PET_SENSE_RATE, senseRate);
		this.setModified();
	}

	/**
	 * 获取武将的一级属性可分配点数
	 * @return
	 */
	public int getLeftPoint() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.LEFT_POINT);
	}
	
	/**
	 * 设置一级属性可分配点数
	 * @param leftPoint
	 */
	public void setLeftPoint(int leftPoint) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.LEFT_POINT, leftPoint);
		this.setModified();
	}
	
	/**
	 * 获取指定一级属性的增加值
	 * @param aPropKey
	 * @return
	 */
	public int getAddAProp(int aPropKey) {
		if (aPropAddMap != null && this.aPropAddMap.containsKey(aPropKey)) {
			return this.aPropAddMap.get(aPropKey);
		}
		return 0;
	}
	
	/**
	 * 更新指定的一级属性的增加值
	 * @param aPropKey
	 * @param num
	 */
	public void updateAddAProp(int aPropKey, int num) {
		this.aPropAddMap.put(aPropKey, num);
		this.setModified();
	}
	
	public Map<Integer, Integer> getAddAPropMap() {
		return this.aPropAddMap;
	}
	
	/**
	 * 获取武将品质，主将品质会变化
	 * 
	 * @return
	 */
	public PetQuality getQuality() {
		PetQuality quality = PetQuality.WHITE;
		if (null != PetQuality.valueOf(getColor())) {
			quality = PetQuality.valueOf(getColor());
		}
		return quality;
	}
	
	public PetTemplate getTemplate(){
		return Globals.getTemplateCacheService().get(this.getTemplateId(), PetTemplate.class);
	}
	
	/**
	 * 获取职业类型
	 * @return
	 */
	public JobType getJobType() {
		if (getTemplate() != null) {
			return getTemplate().getJobType();
		}
		return null;
	}
	
	/**
	 * 获取性别
	 * @return
	 */
	public Sex getSex() {
		if (getTemplate() != null) {
			return getTemplate().getSex();
		}
		return null;
	}
	
	/**
	 * 获取宠物技能栏数量
	 * @return
	 */
	public int getSkillBarNum(){
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_SKILL_BAR_NUM);
	}
	
	/**
	 * 设置宠物技能栏数量
	 * @param num
	 */
	public void setSkillBarNum(int num){
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_SKILL_BAR_NUM, num);
		this.setModified();
	}
	
	/**
	 * 获取战斗力
	 * @return
	 */
	public int getFightPower() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.FIGHT_POWER);
	}
	
	/**
	 * 设置战斗力
	 * @param power
	 */
	public void setFightPower(int power) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.FIGHT_POWER, power);
		this.setModified();
		// 武将战斗力变化，可能会引起玩家总战斗力变化
//		if (this.owner != null && this.owner.getFormationManager() != null && 
//				this.owner.getFormationManager().isPetInFormation(petUUID)) {
//			// 武将在阵型上，更新总战斗力
//			this.owner.updateFightPower();
//			// 更新战斗力的离线数据
//			Globals.getOfflineDataService().onBaseInfoChange(this.owner.getOwner());
//		}
	}
	
	
	/**
	 * 更新武将战力
	 */
	public void updateFightPower() {
		//FIXME
//		int fightPower = 0;
//		//技能提供的战斗力= 技能1等级*系数1+技能2等级*系数2 + 技能3等级* 系数3 +技能4等级*系数4  （系数读取配置文件）
//		for (PetSkillInfo skill : skillMap.values()) {
//			PetFightPowerSkillTemplate skillTpl = Globals.getTemplateCacheService().get(skill.getPosId().index, PetFightPowerSkillTemplate.class);
//			if (skillTpl != null && 
//					skillTpl.getLevelCoef() > 0) {
//				fightPower += skillTpl.getLevelCoef() * skill.getLevel();
//			}
//		}
//		
//		//二级属性带来的战力
//		int ppTemp = 0;
//		Collection<PetFightPowerBPropTemplate> cols = Globals.getTemplateCacheService().getAll(PetFightPowerBPropTemplate.class).values();
//		for (PetFightPowerBPropTemplate propTpl : cols) {
//			if (propTpl.getLevelCoef() > 0) {
//				ppTemp += propTpl.getLevelCoef() * this.propertyManager.getBProperty(propTpl.getPropIndex());
//			}
//		}
//		//去余取整
//		ppTemp = (int)(1.0f * ppTemp / Globals.getGameConstants().getPetDivBase());
//		
//		fightPower += ppTemp;
//		
//		//更新武将战力
//		setFightPower(fightPower);
	}
	
	public Map<Integer, PetSkillInfo> getSkillMap() {
		return skillMap;
	}
	
	public int getSkillNum(){
		return skillMap.size();
	}
	
	public Map<Integer, PetSkillShortcutInfo> getSkillShortcutMap(){
		return this.skillShortcutMap;
	}
	
	public boolean isBind() {
		return this.baseIntProperties.getPropertyValue(RoleBaseIntProperties.PET_BIND) == BindType.BIND.getIndex();
	}

	public void setBind(boolean isBind) {
		this.baseIntProperties.setPropertyValue(RoleBaseIntProperties.PET_BIND, 
				isBind ? BindType.BIND.getIndex() : BindType.NOT_BIND.getIndex());
		this.setModified();
	}

	/**
	 * 升级后更新可分配点数 
	 * @param levels 
	 */
	public abstract void onUpgradeLevel(int levels);
	
}
