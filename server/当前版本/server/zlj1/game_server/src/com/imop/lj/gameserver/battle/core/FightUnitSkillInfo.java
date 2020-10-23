package com.imop.lj.gameserver.battle.core;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.pet.PetDef;

public class FightUnitSkillInfo implements Cloneable {
	private int skillId;
	private int skillLevel = PetDef.DEFAULT_SKILL_LEVEL;
	private int weight;
	private int cdRound;
	private int lastUsedRound;
	
	/** 技能镶嵌的效果列表 */
	private List<FightUnitSkillEffectInfo> embedEffectList = new ArrayList<FightUnitSkillEffectInfo>();
	
	public FightUnitSkillInfo(int skillId, int skillLevel) {
		this.skillId = skillId;
		this.skillLevel = skillLevel;
	}
	
	public FightUnitSkillInfo(int skillId, int skillLevel, int weight, int cdRound) {
		this.skillId = skillId;
		this.skillLevel = skillLevel;
		this.weight = weight;
		this.cdRound = cdRound;
	}

	public int getSkillId() {
		return skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}

	public int getSkillLevel() {
		return skillLevel;
	}

	public void setSkillLevel(int skillLevel) {
		this.skillLevel = skillLevel;
	}

	public int getWeight() {
		return weight;
	}

	public void setWeight(int weight) {
		this.weight = weight;
	}

	public int getLastUsedRound() {
		return lastUsedRound;
	}

	public void setLastUsedRound(int lastUsedRound) {
		this.lastUsedRound = lastUsedRound;
	}
	
	public int getCdRound() {
		return cdRound;
	}

	public void setCdRound(int cdRound) {
		this.cdRound = cdRound;
	}

	public List<FightUnitSkillEffectInfo> getEmbedEffectList() {
		return embedEffectList;
	}

	public void addEmbedEffect(FightUnitSkillEffectInfo info) {
		embedEffectList.add(info);
	}

	@Override
	public FightUnitSkillInfo clone() {
		FightUnitSkillInfo info = new FightUnitSkillInfo(skillId, skillLevel, weight, cdRound);
		info.setLastUsedRound(lastUsedRound);
		List<FightUnitSkillEffectInfo> eeList = info.getEmbedEffectList();
		for (FightUnitSkillEffectInfo eInfo : embedEffectList) {
			eeList.add(new FightUnitSkillEffectInfo(eInfo.getEffectId(), eInfo.getEffectLevel()));
		}
		return info;
	}
	
}
