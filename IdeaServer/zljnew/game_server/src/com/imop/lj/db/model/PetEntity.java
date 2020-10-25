package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.SoftDeleteEntity;



/**
 * 宠物数据库实体对象
 * 
 */
@Entity
@Table(name = "t_pet_info")
@Comment(content="数据库实体类：武将")
public class PetEntity implements SoftDeleteEntity<Long> {
	/** */
	private static final long serialVersionUID = 6931213926527000159L;

	/** 主键 UUID */
	@Comment(content="主键 UUID")
	private long id;
	@Comment(content="级别")
	private int level;
	@Comment(content="经验值")
	private long exp;
	@Comment(content="所属角色")
	private long charId;
	@Comment(content="武将类型")
	private int petType;
	@Comment(content="模板ID")
	private int templateId;
	@Comment(content="创建日期")
	private Timestamp createDate;
	@Comment(content="删除时间")
	private Timestamp deleteDate;
	@Comment(content="是否已删除")
	private int deleted;
	/**最后一次招募时间 */
	@Comment(content="最后一次招募时间 ")
	private Timestamp lastHireDate;
	/**最后一次解雇时间*/
	@Comment(content="最后一次解雇时间 ")
	private Timestamp lastFireDate;
	/**武将状态*/
	@Comment(content="武将状态 ")
	private int petState;
	
	@Comment(content="武将星级")
	private int starId;
	@Comment(content="武将品质Id")
	private int colorId;
	
	@Comment(content="技能属性，如等级等，json")
	private String skillProp;
	
	@Comment(content="技能快捷栏json")
	private String skillShortcutProp;
	
	@Comment(content="剩余可分配点数")
	private int leftPoint;
	
	@Comment(content="一级属性分配的点数，json")
	private String aPropAddPoint;
	
	@Comment(content="成长率品质，宠物")
	private int growthColor;
	
	@Comment(content="变异类型，宠物")
	private int geneType;
	
	@Comment(content="是否出战中，宠物")
	private int isFight;
//	
//	@Comment(content="寿命，宠物")
//	private int life;
	
	//注意：如果不是公共的属性，需要给默认值，否则toEntity的时候会报错
	@Comment(content="名字，宠物")
	private String name = "";
	
	//注意：如果不是公共的属性，需要给默认值，否则toEntity的时候会报错
	@Comment(content="装备位星级，n对数值，json")
	private String equipStars = "";
	
	//注意：如果不是公共的属性，需要给默认值，否则toEntity的时候会报错
	@Comment(content="宠物培养增加属性json")
	private String trainAddProp = "";
	
	//注意：如果不是公共的属性，需要给默认值，否则toEntity的时候会报错
	@Comment(content="宠物资质丹增加属性json")
	private String itemAddProp = "";
	
	@Comment(content="悟性等级")
	private int perceptLevel;
	
	@Comment(content="悟性经验值")
	private long perceptExp;
	
	@Comment(content="宠物评分，宠物")
	private int petScore;
	
	@Comment(content="宠物技能栏上限")
	private int petSkillBarNum;
	
	@Comment(content="宠物还童次数")
	private int petAffinationNum;
	
	@Comment(content="宠物领悟技能成功率,扩大1000倍")
	private int petSenseRate;
	
	@Comment(content="绑定状态，0绑定，1不绑定")
	private int bindFlag;
	
	@Id
	@Override
	@Column(length = 36)
	public Long getId() {
		return this.id;
	}

	@Column
	public long getExp() {
		return exp;
	}

	@Column
	public int getLevel() {
		return level;
	}

	@Column
	public Timestamp getCreateDate() {
		return createDate;
	}

	@Column
	public int getDeleted() {
		return deleted;
	}

	@Column
	public Timestamp getDeleteDate() {
		return deleteDate;
	}
	
	@Column
	public long getCharId() {
		return charId;
	}
	
	
	@Column
	public int getPetType() {
		return petType;
	}

	@Column
	public int getTemplateId() {
		return templateId;
	}

	@Column
	public Timestamp getLastHireDate() {
		return lastHireDate;
	}
	@Column
	public Timestamp getLastFireDate() {
		return lastFireDate;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getPetState() {
		return petState;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setExp(long exp) {
		this.exp = exp;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public void setCreateDate(Timestamp createDate) {
		this.createDate = createDate;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
	
	public void setCharId(long charId) {
		this.charId = charId;
	}

	public void setPetType(int petType) {
		this.petType = petType;
	}

	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}

	public void setLastHireDate(Timestamp lastHireDate) {
		this.lastHireDate = lastHireDate;
	}

	public void setLastFireDate(Timestamp lastFireDate) {
		this.lastFireDate = lastFireDate;
	}

	public void setPetState(int petState) {
		this.petState = petState;
	}

	@Column(columnDefinition = " int default 1", nullable = false)
	public int getStarId() {
		return starId;
	}

	public void setStarId(int starId) {
		this.starId = starId;
	}

	@Column(columnDefinition = " int default 1", nullable = false)
	public int getColorId() {
		return colorId;
	}

	public void setColorId(int colorId) {
		this.colorId = colorId;
	}

	@Column(columnDefinition = " varchar(2048) default ''", nullable = false)
	public String getSkillProp() {
		return skillProp;
	}

	public void setSkillProp(String skillProp) {
		this.skillProp = skillProp;
	}
	
	@Column(columnDefinition = " varchar(2048) default ''", nullable = false)
	public String getSkillShortcutProp() {
		return skillShortcutProp;
	}

	public void setSkillShortcutProp(String skillShortcutProp) {
		this.skillShortcutProp = skillShortcutProp;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getLeftPoint() {
		return leftPoint;
	}

	public void setLeftPoint(int leftPoint) {
		this.leftPoint = leftPoint;
	}

	@Column(columnDefinition = " varchar(1024) default ''", nullable = false)
	public String getaPropAddPoint() {
		return aPropAddPoint;
	}

	public void setaPropAddPoint(String aPropAddPoint) {
		this.aPropAddPoint = aPropAddPoint;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getGrowthColor() {
		return growthColor;
	}

	public void setGrowthColor(int growthColor) {
		this.growthColor = growthColor;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getGeneType() {
		return geneType;
	}

	public void setGeneType(int geneType) {
		this.geneType = geneType;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsFight() {
		return isFight;
	}

	public void setIsFight(int isFight) {
		this.isFight = isFight;
	}

//	@Column(columnDefinition = " int(11) default 0", nullable = false)
//	public int getLife() {
//		return life;
//	}
//
//	public void setLife(int life) {
//		this.life = life;
//	}

	@Column(columnDefinition = " varchar(255) default null ", nullable = true)
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Column(columnDefinition = " varchar(512) default ''", nullable = false)
	public String getEquipStars() {
		return equipStars;
	}

	public void setEquipStars(String equipStars) {
		this.equipStars = equipStars;
	}

	@Column(columnDefinition = " varchar(128) default ''", nullable = false)
	public String getTrainAddProp() {
		return trainAddProp;
	}

	public void setTrainAddProp(String trainAddProp) {
		this.trainAddProp = trainAddProp;
	}
	
	@Column(columnDefinition = " varchar(128) default ''", nullable = false)
	public String getItemAddProp() {
		return itemAddProp;
	}

	public void setItemAddProp(String itemAddProp) {
		this.itemAddProp = itemAddProp;
	}

	@Column(columnDefinition = " int(11) default 0 ", nullable = false)
	public int getPerceptLevel() {
		return perceptLevel;
	}

	public void setPerceptLevel(int perceptLevel) {
		this.perceptLevel = perceptLevel;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getPerceptExp() {
		return perceptExp;
	}

	public void setPerceptExp(long perceptExp) {
		this.perceptExp = perceptExp;
	}
	
	@Column(columnDefinition = " int(11) default 0 ", nullable = false)
	public int getPetScore() {
		return petScore;
	}

	public void setPetScore(int petScore) {
		this.petScore = petScore;
	}

	@Column(columnDefinition = " int(11) default 0 ", nullable = false)
	public int getPetSkillBarNum() {
		return petSkillBarNum;
	}

	public void setPetSkillBarNum(int petSkillBarNum) {
		this.petSkillBarNum = petSkillBarNum;
	}

	@Column(columnDefinition = " int(11) default 0 ", nullable = false)
	public int getPetAffinationNum() {
		return petAffinationNum;
	}

	public void setPetAffinationNum(int petAffinationNum) {
		this.petAffinationNum = petAffinationNum;
	}

	@Column(columnDefinition = " int(11) default 0 ", nullable = false)
	public int getPetSenseRate() {
		return petSenseRate;
	}

	public void setPetSenseRate(int petSenseRate) {
		this.petSenseRate = petSenseRate;
	}

	@Column(columnDefinition = " int(11) default 0 ", nullable = false)
	public int getBindFlag() {
		return bindFlag;
	}

	public void setBindFlag(int bindFlag) {
		this.bindFlag = bindFlag;
	}
	
}
