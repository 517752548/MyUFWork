package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 单个怪物表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EnemyTemplateVO extends TemplateObject {

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 1)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 攻击类型Id */
	@ExcelCellBinding(offset = 3)
	protected int attackTypeId;

	/** 性别 */
	@ExcelCellBinding(offset = 4)
	protected int sexId;

	/** 职业 */
	@ExcelCellBinding(offset = 5)
	protected int jobId;

	/** 美术Id */
	@ExcelCellBinding(offset = 6)
	protected String modelId;

	/** 音乐Id串 */
	@ExcelCellBinding(offset = 7)
	protected String musicIds;

	/** 模型高度 */
	@ExcelCellBinding(offset = 8)
	protected float modelHeight;

	/** 等级 */
	@ExcelCellBinding(offset = 9)
	protected int level;

	/** 宠物Id（武将表Id） */
	@ExcelCellBinding(offset = 10)
	protected int petTplId;

	/** 生命 */
	@ExcelCellBinding(offset = 11)
	protected long hp;

	/** 法力 */
	@ExcelCellBinding(offset = 12)
	protected int mp;

	/** 速度 */
	@ExcelCellBinding(offset = 13)
	protected int speed;

	/** 物理攻击 */
	@ExcelCellBinding(offset = 14)
	protected int physicalAttack;

	/** 物理护甲 */
	@ExcelCellBinding(offset = 15)
	protected int physicalArmor;

	/** 物理命中 */
	@ExcelCellBinding(offset = 16)
	protected int physicalHit;

	/** 物理闪避 */
	@ExcelCellBinding(offset = 17)
	protected int physicalDodgy;

	/** 物理暴击 */
	@ExcelCellBinding(offset = 18)
	protected int physicalCrit;

	/** 物理抗暴 */
	@ExcelCellBinding(offset = 19)
	protected int phsicalAntiCrit;

	/** 法术强度 */
	@ExcelCellBinding(offset = 20)
	protected int magicAttack;

	/** 法术抗性 */
	@ExcelCellBinding(offset = 21)
	protected int magicArmor;

	/** 法术命中 */
	@ExcelCellBinding(offset = 22)
	protected int magicHit;

	/** 法术抵抗 */
	@ExcelCellBinding(offset = 23)
	protected int magicDodgy;

	/** 法术暴击 */
	@ExcelCellBinding(offset = 24)
	protected int magicCrit;

	/** 法术抗暴 */
	@ExcelCellBinding(offset = 25)
	protected int magicAntiCrit;

	/** 怒气 */
	@ExcelCellBinding(offset = 26)
	protected int sp;

	/** 修为 */
	@ExcelCellBinding(offset = 27)
	protected int xw;

	/** 寿命 */
	@ExcelCellBinding(offset = 28)
	protected int life;

	/** 强壮成长基础值 */
	@ExcelCellBinding(offset = 29)
	protected int strengthGrowth;

	/** 敏捷成长基础值 */
	@ExcelCellBinding(offset = 30)
	protected int agilityGrowth;

	/** 智力成长基础值 */
	@ExcelCellBinding(offset = 31)
	protected int intellectGrowth;

	/** 信仰成长基础值 */
	@ExcelCellBinding(offset = 32)
	protected int faithGrowth;

	/** 耐力成长基础值 */
	@ExcelCellBinding(offset = 33)
	protected int staminaGrowth;

	/** 技能列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.SkillItem.class, collectionNumber = "34,35,36;37,38,39;40,41,42;43,44,45;46,47,48")
	protected List<com.imop.lj.gameserver.enemy.template.SkillItem> skillList;

	/** 说话列表 */
	@ExcelCollectionMapping(clazz = String.class, collectionNumber = "49;50;51")
	protected List<String> speakList;


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
					6, "[职业]jobId的值不得小于1");
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
	
	public float getModelHeight() {
		return this.modelHeight;
	}

	public void setModelHeight(float modelHeight) {
		this.modelHeight = modelHeight;
	}
	
	public int getLevel() {
		return this.level;
	}

	public void setLevel(int level) {
		if (level < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[等级]level的值不得小于0");
		}
		this.level = level;
	}
	
	public int getPetTplId() {
		return this.petTplId;
	}

	public void setPetTplId(int petTplId) {
		if (petTplId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[宠物Id（武将表Id）]petTplId的值不得小于0");
		}
		this.petTplId = petTplId;
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
	
	public List<com.imop.lj.gameserver.enemy.template.SkillItem> getSkillList() {
		return this.skillList;
	}

	public void setSkillList(List<com.imop.lj.gameserver.enemy.template.SkillItem> skillList) {
		if (skillList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[技能列表]skillList不可以为空");
		}	
		this.skillList = skillList;
	}
	
	public List<String> getSpeakList() {
		return this.speakList;
	}

	public void setSpeakList(List<String> speakList) {
		if (speakList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					50, "[说话列表]speakList不可以为空");
		}	
		this.speakList = speakList;
	}
	

	@Override
	public String toString() {
		return "EnemyTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",attackTypeId=" + attackTypeId + ",sexId=" + sexId + ",jobId=" + jobId + ",modelId=" + modelId + ",musicIds=" + musicIds + ",modelHeight=" + modelHeight + ",level=" + level + ",petTplId=" + petTplId + ",hp=" + hp + ",mp=" + mp + ",speed=" + speed + ",physicalAttack=" + physicalAttack + ",physicalArmor=" + physicalArmor + ",physicalHit=" + physicalHit + ",physicalDodgy=" + physicalDodgy + ",physicalCrit=" + physicalCrit + ",phsicalAntiCrit=" + phsicalAntiCrit + ",magicAttack=" + magicAttack + ",magicArmor=" + magicArmor + ",magicHit=" + magicHit + ",magicDodgy=" + magicDodgy + ",magicCrit=" + magicCrit + ",magicAntiCrit=" + magicAntiCrit + ",sp=" + sp + ",xw=" + xw + ",life=" + life + ",strengthGrowth=" + strengthGrowth + ",agilityGrowth=" + agilityGrowth + ",intellectGrowth=" + intellectGrowth + ",faithGrowth=" + faithGrowth + ",staminaGrowth=" + staminaGrowth + ",skillList=" + skillList + ",speakList=" + speakList + ",]";

	}
}