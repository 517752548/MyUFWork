package com.imop.lj.gameserver.pet.prop;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.core.util.KeyValuePair;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.pet.helper.PetHelper;
import com.imop.lj.gameserver.pet.prop.effector.PetAPropFromType;
import com.imop.lj.gameserver.pet.prop.effector.PetBPropFromType;
import com.imop.lj.gameserver.pet.template.PetFightPowerTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

public class PetPropertyManager extends RolePropertyManager<Pet, Float> {

	/** 战斗属性 */
	protected PetBattleProperty battleProperty;

	public PetPropertyManager(Pet role) {
		super(role, 4);
		battleProperty = new PetBattleProperty(PetAPropFromType.values().length, PetBPropFromType.values().length);
	}

	/**
	 * 获取改变
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public KeyValuePair<Integer, Float>[] getChanged() {
		if (propChangeSet.isEmpty()) {
			return null;
		}
		boolean _aPropChange = propChangeSet.get(RolePropertyManager.CHANGE_INDEX_APROP);
		boolean _bPropChange = propChangeSet.get(RolePropertyManager.CHANGE_INDEX_BPROP);
		int _length = 0;
		if (_aPropChange) {
			_length += PetAProperty._SIZE;
		}
		if (_bPropChange) {
			_length += PetBProperty._SIZE;
		}
		KeyValuePair<Integer, Float>[] valuePairs = new KeyValuePair[_length];
		int i = 0;
		if (_aPropChange) {
			for (KeyValuePair<Integer, Float> valuePair : this.battleProperty.getAPropValuePairs()) {
				valuePairs[i] = valuePair;
				valuePairs[i].setKey(PropertyType.genPropertyKey(valuePairs[i].getKey(), PropertyType.PET_PROP_A));
				i++;
			}
		}
		if (_bPropChange) {
			for (KeyValuePair<Integer, Float> valuePair : this.battleProperty.getBPropValuePairs()) {
				valuePairs[i] = valuePair;
				valuePairs[i].setKey(PropertyType.genPropertyKey(valuePairs[i].getKey(), PropertyType.PET_PROP_B));
				i++;
			}
		}
		return valuePairs;
	}

	@Override
	protected boolean updateAProperty(Pet role, int effectMask) {
		boolean _changed = false;
		for (PetAPropFromType fromType : PetAPropFromType.values()) {
			if ((fromType.mark & effectMask) != 0) {
				PetAProperty property = this.battleProperty.getAPropSegment(fromType.index);
				fromType.effector.effect(property, role);
				if (property.isChanged()) {
					_changed = true;
					property.resetChanged();
				}
			}
		}
		
		if (_changed) {
			this.battleProperty.updateAProperty();
			role.setModified();
			return true;
		}
		return false;
	}

	@Override
	protected boolean updateBProperty(Pet role, int effectMask) {
		boolean _changed = false;
		for (PetBPropFromType fromType : PetBPropFromType.values()) {
			if ((fromType.mark & effectMask) != 0) {
				PetBProperty property = this.battleProperty.getBPropSegment(fromType.index);
				fromType.effector.effect(property, role);
				if (property.isChanged()) {
					_changed = true;
					property.resetChanged();
				}
			}
		}
		if (_changed) {
			this.battleProperty.updateBProperty();
//			//二级属性变化，战力更新
//			role.updateFightPower();
			role.setModified();
			return true;
		}
		return false;
	}
	
	@Override
	public void updateProperty(int effectMask) {
		updateProperty(effectMask, false);
	}
	
	/**
	 * 更新属性，将hp、mp、life设置为满值
	 * @param effectMask
	 */
	public void updatePropertyFull(int effectMask) {
		updateProperty(effectMask, true);
	}
	
	private void updateProperty(int effectMask, boolean fullFlag) {
		//XXX hp\mp\life整体规则是，两种状态：满值时，分子分母一起变化，值始终相同；不满时，只分母变，分子不变（可能会由不满变到满的状态，一旦变满，则按照满的规则）
		long humanId = owner.getOwner().getCharId();
		long petId = owner.getUUID();
		long hp = 0;
		long mp = 0;
		long life = 0;
		UserPetData petData = null;
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(humanId);
		if (offlineData != null) {
			petData = offlineData.getPetData(petId);
			if (petData != null) {
				//pet属性
				hp = petData.getHp();
				mp = petData.getMp();
				life = petData.getLife();
			}
		}
		//是否满值
		boolean hpFull = fullFlag || hp >= (int)getBProperty(PetBProperty.HP);
		boolean mpFull = fullFlag || mp >= (int)getBProperty(PetBProperty.MP);
		boolean lifeFull = fullFlag || life >= (int)getBProperty(PetBProperty.LIFE);
		
		if (this.updateAProperty(owner, effectMask)) {
			effectMask |= RolePropertyManager.PROP_FROM_MARK_APROPERTY;
			propChangeSet.set(RolePropertyManager.CHANGE_INDEX_APROP);
		}
		
		if (this.updateBProperty(owner, effectMask)) {
			propChangeSet.set(RolePropertyManager.CHANGE_INDEX_BPROP);
			
			// 更新此武将离线数据
			Globals.getOfflineDataService().onUpdatePet(this.owner);
			
			//如果之前是满值，则变化后需要更新当前值
			if (petData != null) {
				int hpNew = (int)getBProperty(PetBProperty.HP);
				int mpNew = (int)getBProperty(PetBProperty.MP);
				int lifeNew = (int)getBProperty(PetBProperty.LIFE);
				if (hpFull) {
					petData.setHp(hpNew);
				}
				if (mpFull) {
					petData.setMp(mpNew);
				}
				if (lifeFull) {
					petData.setLife(lifeNew);
				}
			}
		}
		
		// 重新计算并更新战斗力
		updateFightPower();
					
		// 通知前台属性变化
		owner.snapChangedProperty(true);
		
		if (hpFull || mpFull || lifeFull) {
			if (offlineData != null && petData != null) {
				//存库
				offlineData.setModified();
				//骑宠不需要发送血池等数据变化
				//发消息通知前台属性变化
				owner.getOwner().sendMessage(PetMessageBuilder.buildGCPetCurPropUpdate(humanId, owner.getUUID()));
			}
		}
	}

	/**
	 * 计算并更新武将战斗力
	 */
	public void updateFightPower() {
		//数据校验及数据准备
		if (owner.getTemplate() == null || owner.getJobType() == null || owner.getTemplate().getPetAttackType() == null || owner.getJobType().getFightPowerType() == null) {
			// 非法数据
			return;
		}
		PetFightPowerTemplate template = Globals.getTemplateCacheService().getTemplateService().get(owner.getJobType().getFightPowerType().getIndex(), PetFightPowerTemplate.class);
		if(template == null){
			// 非法数据
			return;
		}
		
		// 基础属性战斗力
		double basePower = PetHelper.getBaseFightPower(getBattleProperty().getBProperty(), template);
		
		//技能战斗力 技能等级*技能对应系数
		double skillPower = 0;
		Map<Integer, PetSkillInfo> map = Maps.newHashMap();
		
		if(owner instanceof PetLeader){
			PetLeader leader = (PetLeader) owner;
			map = leader.getSkillMap();
		}else if(owner instanceof PetPet){
			map = owner.getSkillMap();
		}
		
		for(Entry<Integer, PetSkillInfo> entry : map.entrySet()){
			SkillTemplate st = Globals.getTemplateCacheService().getTemplateService().get(entry.getKey(), SkillTemplate.class);
			if(st == null){
				continue;
			}
			skillPower += entry.getValue().getLevel() * st.getSkillScore();
		}
		
		// 最终战斗力
		int finalPower = (int)(basePower + skillPower);
		
		// 更新战斗力
		owner.setFightPower(finalPower);
	}

	public double getBasePower(PetFightPowerTemplate template) {
		double basePower = 
		getBProperty(PetBProperty.HP) * template.getHP() +
		getBProperty(PetBProperty.MP) * template.getMP() +
		getBProperty(PetBProperty.PHYSICAL_ATTACK) * template.getPhysicalAttack() + 
		getBProperty(PetBProperty.PHYSICAL_ARMOR) * template.getPhysicalArmor() + 
		getBProperty(PetBProperty.PHYSICAL_HIT) * template.getPhysicalHit() + 
		getBProperty(PetBProperty.PHYSICAL_DODGY) * template.getPhysicalDodgy() + 
		getBProperty(PetBProperty.PHYSICAL_CRIT) * template.getPhysicalCrit()+ 
		getBProperty(PetBProperty.PHYSICAL_ANTICRIT) * template.getPhysicalAnticrit() + 
		getBProperty(PetBProperty.MAGIC_ATTACK) * template.getMagicalAttack() + 
		getBProperty(PetBProperty.MAGIC_ARMOR) * template.getMagicalArmor() + 
		getBProperty(PetBProperty.MAGIC_HIT) * template.getMagicalHit() + 
		getBProperty(PetBProperty.MAGIC_DODGY) * template.getMagicalDodgy() + 
		getBProperty(PetBProperty.MAGIC_CRIT) * template.getMagicalCrit() + 
		getBProperty(PetBProperty.MAGIC_ANTICRIT) * template.getMagicalAnticrit() + 
		getBProperty(PetBProperty.SPEED) * template.getSpeed() ;
		return basePower;
	}
	
	/**
	 * 初始化武将属性
	 */
	public void initPropety(){
		int effectMask = RolePropertyManager.PROP_FROM_MARK_ALL;
		if (this.updateAProperty(owner, effectMask)) {
			effectMask |= RolePropertyManager.PROP_FROM_MARK_APROPERTY;
			propChangeSet.set(RolePropertyManager.CHANGE_INDEX_APROP);
		}
		if (this.updateBProperty(owner, effectMask)) {
			propChangeSet.set(RolePropertyManager.CHANGE_INDEX_BPROP);
		}
		// 重新计算并更新战斗力
		updateFightPower();
//		// 更新饰品的显示属性
//		Globals.getAccessoryService().updateAccessoryShowAttr(this.owner);
	}

	/**
	 * 战斗属性
	 * 
	 * @return
	 */
	public PetBattleProperty getBattleProperty() {
		return this.battleProperty;
	}

	public float getAProperty(int index) {
		return this.battleProperty.getAProperty(index);
	}

	public float getBProperty(int index) {
		return this.battleProperty.getBProperty(index);
	}

	public boolean isAPropertyChanged(int index) {
		return this.battleProperty.isAPropertyChanged(index);
	}

	public boolean isBPropertyChanged(int index) {
		return this.battleProperty.isBPropertyChanged(index);
	}
	
}
