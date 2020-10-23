package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 英雄模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetTemplateVO extends TemplateObject {

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 1)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 类型 */
	@ExcelCellBinding(offset = 3)
	protected int typeId;

	/** 攻击类型（1物理，2法术） */
	@ExcelCellBinding(offset = 4)
	protected int attackTypeId;

	/** 性别 */
	@ExcelCellBinding(offset = 5)
	protected int sexId;

	/** 职业 */
	@ExcelCellBinding(offset = 6)
	protected int jobId;

	/** 美术Id */
	@ExcelCellBinding(offset = 7)
	protected String modelId;

	/** 音乐Id串 */
	@ExcelCellBinding(offset = 8)
	protected String musicIds;

	/** 模型缩放系数 */
	@ExcelCellBinding(offset = 9)
	protected String modelScale;

	/** 携带等级【宠物】 */
	@ExcelCellBinding(offset = 10)
	protected int fightLevel;

	/** 宠物类型（0普通，1高级宠，2神兽） */
	@ExcelCellBinding(offset = 11)
	protected int petpetTypeId;

	/** 宠物类别（野兽、妖怪、精灵和人形） */
	@ExcelCellBinding(offset = 12)
	protected int petpetKindId;

	/** 宠物捕捉成功率*十万 */
	@ExcelCellBinding(offset = 13)
	protected int catchProb;

	/** 捕捉道具ID */
	@ExcelCellBinding(offset = 14)
	protected int catchItemId;

	/** 捕捉道具数量 */
	@ExcelCellBinding(offset = 15)
	protected int catchItemNum;

	/** 宠物变异颜色值 */
	@ExcelCellBinding(offset = 16)
	protected String petTransColor;

	/** 图鉴排序Id */
	@ExcelCellBinding(offset = 17)
	protected int sortId;

	/** 图鉴获取途径描述 */
	@ExcelCellBinding(offset = 18)
	protected String gotDesc;

	/** 强壮 */
	@ExcelCellBinding(offset = 19)
	protected int strength;

	/** 敏捷 */
	@ExcelCellBinding(offset = 20)
	protected int agility;

	/** 智力 */
	@ExcelCellBinding(offset = 21)
	protected int intellect;

	/** 信仰 */
	@ExcelCellBinding(offset = 22)
	protected int faith;

	/** 耐力 */
	@ExcelCellBinding(offset = 23)
	protected int stamina;

	/** 生命 */
	@ExcelCellBinding(offset = 24)
	protected long hp;

	/** 法力 */
	@ExcelCellBinding(offset = 25)
	protected int mp;

	/** 速度 */
	@ExcelCellBinding(offset = 26)
	protected int speed;

	/** 物理攻击 */
	@ExcelCellBinding(offset = 27)
	protected int physicalAttack;

	/** 物理护甲 */
	@ExcelCellBinding(offset = 28)
	protected int physicalArmor;

	/** 物理命中 */
	@ExcelCellBinding(offset = 29)
	protected int physicalHit;

	/** 物理闪避 */
	@ExcelCellBinding(offset = 30)
	protected int physicalDodgy;

	/** 物理暴击 */
	@ExcelCellBinding(offset = 31)
	protected int physicalCrit;

	/** 物理抗暴 */
	@ExcelCellBinding(offset = 32)
	protected int phsicalAntiCrit;

	/** 法术强度 */
	@ExcelCellBinding(offset = 33)
	protected int magicAttack;

	/** 法术抗性 */
	@ExcelCellBinding(offset = 34)
	protected int magicArmor;

	/** 法术命中 */
	@ExcelCellBinding(offset = 35)
	protected int magicHit;

	/** 法术抵抗 */
	@ExcelCellBinding(offset = 36)
	protected int magicDodgy;

	/** 法术暴击 */
	@ExcelCellBinding(offset = 37)
	protected int magicCrit;

	/** 法术抗暴 */
	@ExcelCellBinding(offset = 38)
	protected int magicAntiCrit;

	/** 怒气 */
	@ExcelCellBinding(offset = 39)
	protected int sp;

	/** 修为 */
	@ExcelCellBinding(offset = 40)
	protected int xw;

	/** 寿命 */
	@ExcelCellBinding(offset = 41)
	protected int life;

	/** 强壮成长基础值 */
	@ExcelCellBinding(offset = 42)
	protected int strengthGrowth;

	/** 敏捷成长基础值 */
	@ExcelCellBinding(offset = 43)
	protected int agilityGrowth;

	/** 智力成长基础值 */
	@ExcelCellBinding(offset = 44)
	protected int intellectGrowth;

	/** 信仰成长基础值 */
	@ExcelCellBinding(offset = 45)
	protected int faithGrowth;

	/** 耐力成长基础值 */
	@ExcelCellBinding(offset = 46)
	protected int staminaGrowth;

	/** 随机资质成长值 */
	@ExcelCellBinding(offset = 47)
	protected int randGrowth;

	/** 英雄介绍 */
	@ExcelCellBinding(offset = 48)
	protected String descInfo;

	/** 性格介绍 */
	@ExcelCellBinding(offset = 49)
	protected String charaInfo;

	/** 宠物天赋技能包Id */
	@ExcelCellBinding(offset = 50)
	protected int petTalentSkillPackId;

	/** 宠物培养上限系数1 */
	@ExcelCellBinding(offset = 51)
	protected int petTrainCoef1;

	/** 宠物培养上限系数2 */
	@ExcelCellBinding(offset = 52)
	protected int petTrainCoef2;

	/** 技能列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.SkillItem.class, collectionNumber = "53,54,55;56,57,58;59,60,61;62,63,64;65,66,67")
	protected List<com.imop.lj.gameserver.enemy.template.SkillItem> skillList;

	/** 上架费用类型 */
	@ExcelCellBinding(offset = 68)
	protected int listingFeeType;

	/** 上架费用 */
	@ExcelCellBinding(offset = 69)
	protected int listingFee;


	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getTypeId() {
		return this.typeId;
	}

	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}
	
	public int getAttackTypeId() {
		return this.attackTypeId;
	}

	public void setAttackTypeId(int attackTypeId) {
		this.attackTypeId = attackTypeId;
	}
	
	public int getSexId() {
		return this.sexId;
	}

	public void setSexId(int sexId) {
		this.sexId = sexId;
	}
	
	public int getJobId() {
		return this.jobId;
	}

	public void setJobId(int jobId) {
		if (jobId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[职业]jobId的值不得小于1");
		}
		this.jobId = jobId;
	}
	
	public String getModelId() {
		return this.modelId;
	}

	public void setModelId(String modelId) {
		if (modelId != null) {
			this.modelId = modelId.trim();
		}else{
			this.modelId = modelId;
		}
	}
	
	public String getMusicIds() {
		return this.musicIds;
	}

	public void setMusicIds(String musicIds) {
		if (musicIds != null) {
			this.musicIds = musicIds.trim();
		}else{
			this.musicIds = musicIds;
		}
	}
	
	public String getModelScale() {
		return this.modelScale;
	}

	public void setModelScale(String modelScale) {
		if (modelScale != null) {
			this.modelScale = modelScale.trim();
		}else{
			this.modelScale = modelScale;
		}
	}
	
	public int getFightLevel() {
		return this.fightLevel;
	}

	public void setFightLevel(int fightLevel) {
		if (fightLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[携带等级【宠物】]fightLevel的值不得小于0");
		}
		this.fightLevel = fightLevel;
	}
	
	public int getPetpetTypeId() {
		return this.petpetTypeId;
	}

	public void setPetpetTypeId(int petpetTypeId) {
		if (petpetTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[宠物类型（0普通，1高级宠，2神兽）]petpetTypeId的值不得小于0");
		}
		this.petpetTypeId = petpetTypeId;
	}
	
	public int getPetpetKindId() {
		return this.petpetKindId;
	}

	public void setPetpetKindId(int petpetKindId) {
		if (petpetKindId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[宠物类别（野兽、妖怪、精灵和人形）]petpetKindId的值不得小于0");
		}
		this.petpetKindId = petpetKindId;
	}
	
	public int getCatchProb() {
		return this.catchProb;
	}

	public void setCatchProb(int catchProb) {
		if (catchProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[宠物捕捉成功率*十万]catchProb的值不得小于0");
		}
		this.catchProb = catchProb;
	}
	
	public int getCatchItemId() {
		return this.catchItemId;
	}

	public void setCatchItemId(int catchItemId) {
		if (catchItemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[捕捉道具ID]catchItemId的值不得小于0");
		}
		this.catchItemId = catchItemId;
	}
	
	public int getCatchItemNum() {
		return this.catchItemNum;
	}

	public void setCatchItemNum(int catchItemNum) {
		if (catchItemNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[捕捉道具数量]catchItemNum的值不得小于0");
		}
		this.catchItemNum = catchItemNum;
	}
	
	public String getPetTransColor() {
		return this.petTransColor;
	}

	public void setPetTransColor(String petTransColor) {
		if (petTransColor != null) {
			this.petTransColor = petTransColor.trim();
		}else{
			this.petTransColor = petTransColor;
		}
	}
	
	public int getSortId() {
		return this.sortId;
	}

	public void setSortId(int sortId) {
		if (sortId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[图鉴排序Id]sortId的值不得小于0");
		}
		this.sortId = sortId;
	}
	
	public String getGotDesc() {
		return this.gotDesc;
	}

	public void setGotDesc(String gotDesc) {
		if (gotDesc != null) {
			this.gotDesc = gotDesc.trim();
		}else{
			this.gotDesc = gotDesc;
		}
	}
	
	public int getStrength() {
		return this.strength;
	}

	public void setStrength(int strength) {
		this.strength = strength;
	}
	
	public int getAgility() {
		return this.agility;
	}

	public void setAgility(int agility) {
		this.agility = agility;
	}
	
	public int getIntellect() {
		return this.intellect;
	}

	public void setIntellect(int intellect) {
		this.intellect = intellect;
	}
	
	public int getFaith() {
		return this.faith;
	}

	public void setFaith(int faith) {
		this.faith = faith;
	}
	
	public int getStamina() {
		return this.stamina;
	}

	public void setStamina(int stamina) {
		this.stamina = stamina;
	}
	
	public long getHp() {
		return this.hp;
	}

	public void setHp(long hp) {
		this.hp = hp;
	}
	
	public int getMp() {
		return this.mp;
	}

	public void setMp(int mp) {
		this.mp = mp;
	}
	
	public int getSpeed() {
		return this.speed;
	}

	public void setSpeed(int speed) {
		this.speed = speed;
	}
	
	public int getPhysicalAttack() {
		return this.physicalAttack;
	}

	public void setPhysicalAttack(int physicalAttack) {
		this.physicalAttack = physicalAttack;
	}
	
	public int getPhysicalArmor() {
		return this.physicalArmor;
	}

	public void setPhysicalArmor(int physicalArmor) {
		this.physicalArmor = physicalArmor;
	}
	
	public int getPhysicalHit() {
		return this.physicalHit;
	}

	public void setPhysicalHit(int physicalHit) {
		this.physicalHit = physicalHit;
	}
	
	public int getPhysicalDodgy() {
		return this.physicalDodgy;
	}

	public void setPhysicalDodgy(int physicalDodgy) {
		this.physicalDodgy = physicalDodgy;
	}
	
	public int getPhysicalCrit() {
		return this.physicalCrit;
	}

	public void setPhysicalCrit(int physicalCrit) {
		this.physicalCrit = physicalCrit;
	}
	
	public int getPhsicalAntiCrit() {
		return this.phsicalAntiCrit;
	}

	public void setPhsicalAntiCrit(int phsicalAntiCrit) {
		this.phsicalAntiCrit = phsicalAntiCrit;
	}
	
	public int getMagicAttack() {
		return this.magicAttack;
	}

	public void setMagicAttack(int magicAttack) {
		this.magicAttack = magicAttack;
	}
	
	public int getMagicArmor() {
		return this.magicArmor;
	}

	public void setMagicArmor(int magicArmor) {
		this.magicArmor = magicArmor;
	}
	
	public int getMagicHit() {
		return this.magicHit;
	}

	public void setMagicHit(int magicHit) {
		this.magicHit = magicHit;
	}
	
	public int getMagicDodgy() {
		return this.magicDodgy;
	}

	public void setMagicDodgy(int magicDodgy) {
		this.magicDodgy = magicDodgy;
	}
	
	public int getMagicCrit() {
		return this.magicCrit;
	}

	public void setMagicCrit(int magicCrit) {
		this.magicCrit = magicCrit;
	}
	
	public int getMagicAntiCrit() {
		return this.magicAntiCrit;
	}

	public void setMagicAntiCrit(int magicAntiCrit) {
		this.magicAntiCrit = magicAntiCrit;
	}
	
	public int getSp() {
		return this.sp;
	}

	public void setSp(int sp) {
		this.sp = sp;
	}
	
	public int getXw() {
		return this.xw;
	}

	public void setXw(int xw) {
		this.xw = xw;
	}
	
	public int getLife() {
		return this.life;
	}

	public void setLife(int life) {
		this.life = life;
	}
	
	public int getStrengthGrowth() {
		return this.strengthGrowth;
	}

	public void setStrengthGrowth(int strengthGrowth) {
		this.strengthGrowth = strengthGrowth;
	}
	
	public int getAgilityGrowth() {
		return this.agilityGrowth;
	}

	public void setAgilityGrowth(int agilityGrowth) {
		this.agilityGrowth = agilityGrowth;
	}
	
	public int getIntellectGrowth() {
		return this.intellectGrowth;
	}

	public void setIntellectGrowth(int intellectGrowth) {
		this.intellectGrowth = intellectGrowth;
	}
	
	public int getFaithGrowth() {
		return this.faithGrowth;
	}

	public void setFaithGrowth(int faithGrowth) {
		this.faithGrowth = faithGrowth;
	}
	
	public int getStaminaGrowth() {
		return this.staminaGrowth;
	}

	public void setStaminaGrowth(int staminaGrowth) {
		this.staminaGrowth = staminaGrowth;
	}
	
	public int getRandGrowth() {
		return this.randGrowth;
	}

	public void setRandGrowth(int randGrowth) {
		this.randGrowth = randGrowth;
	}
	
	public String getDescInfo() {
		return this.descInfo;
	}

	public void setDescInfo(String descInfo) {
		if (descInfo != null) {
			this.descInfo = descInfo.trim();
		}else{
			this.descInfo = descInfo;
		}
	}
	
	public String getCharaInfo() {
		return this.charaInfo;
	}

	public void setCharaInfo(String charaInfo) {
		if (charaInfo != null) {
			this.charaInfo = charaInfo.trim();
		}else{
			this.charaInfo = charaInfo;
		}
	}
	
	public int getPetTalentSkillPackId() {
		return this.petTalentSkillPackId;
	}

	public void setPetTalentSkillPackId(int petTalentSkillPackId) {
		if (petTalentSkillPackId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					51, "[宠物天赋技能包Id]petTalentSkillPackId的值不得小于0");
		}
		this.petTalentSkillPackId = petTalentSkillPackId;
	}
	
	public int getPetTrainCoef1() {
		return this.petTrainCoef1;
	}

	public void setPetTrainCoef1(int petTrainCoef1) {
		if (petTrainCoef1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					52, "[宠物培养上限系数1]petTrainCoef1的值不得小于0");
		}
		this.petTrainCoef1 = petTrainCoef1;
	}
	
	public int getPetTrainCoef2() {
		return this.petTrainCoef2;
	}

	public void setPetTrainCoef2(int petTrainCoef2) {
		if (petTrainCoef2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					53, "[宠物培养上限系数2]petTrainCoef2的值不得小于0");
		}
		this.petTrainCoef2 = petTrainCoef2;
	}
	
	public List<com.imop.lj.gameserver.enemy.template.SkillItem> getSkillList() {
		return this.skillList;
	}

	public void setSkillList(List<com.imop.lj.gameserver.enemy.template.SkillItem> skillList) {
		if (skillList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					54, "[技能列表]skillList不可以为空");
		}	
		this.skillList = skillList;
	}
	
	public int getListingFeeType() {
		return this.listingFeeType;
	}

	public void setListingFeeType(int listingFeeType) {
		this.listingFeeType = listingFeeType;
	}
	
	public int getListingFee() {
		return this.listingFee;
	}

	public void setListingFee(int listingFee) {
		this.listingFee = listingFee;
	}
	

	@Override
	public String toString() {
		return "PetTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",typeId=" + typeId + ",attackTypeId=" + attackTypeId + ",sexId=" + sexId + ",jobId=" + jobId + ",modelId=" + modelId + ",musicIds=" + musicIds + ",modelScale=" + modelScale + ",fightLevel=" + fightLevel + ",petpetTypeId=" + petpetTypeId + ",petpetKindId=" + petpetKindId + ",catchProb=" + catchProb + ",catchItemId=" + catchItemId + ",catchItemNum=" + catchItemNum + ",petTransColor=" + petTransColor + ",sortId=" + sortId + ",gotDesc=" + gotDesc + ",strength=" + strength + ",agility=" + agility + ",intellect=" + intellect + ",faith=" + faith + ",stamina=" + stamina + ",hp=" + hp + ",mp=" + mp + ",speed=" + speed + ",physicalAttack=" + physicalAttack + ",physicalArmor=" + physicalArmor + ",physicalHit=" + physicalHit + ",physicalDodgy=" + physicalDodgy + ",physicalCrit=" + physicalCrit + ",phsicalAntiCrit=" + phsicalAntiCrit + ",magicAttack=" + magicAttack + ",magicArmor=" + magicArmor + ",magicHit=" + magicHit + ",magicDodgy=" + magicDodgy + ",magicCrit=" + magicCrit + ",magicAntiCrit=" + magicAntiCrit + ",sp=" + sp + ",xw=" + xw + ",life=" + life + ",strengthGrowth=" + strengthGrowth + ",agilityGrowth=" + agilityGrowth + ",intellectGrowth=" + intellectGrowth + ",faithGrowth=" + faithGrowth + ",staminaGrowth=" + staminaGrowth + ",randGrowth=" + randGrowth + ",descInfo=" + descInfo + ",charaInfo=" + charaInfo + ",petTalentSkillPackId=" + petTalentSkillPackId + ",petTrainCoef1=" + petTrainCoef1 + ",petTrainCoef2=" + petTrainCoef2 + ",skillList=" + skillList + ",listingFeeType=" + listingFeeType + ",listingFee=" + listingFee + ",]";

	}
}