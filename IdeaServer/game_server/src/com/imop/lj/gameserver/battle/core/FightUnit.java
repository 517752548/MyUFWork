package com.imop.lj.gameserver.battle.core;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Random;
import java.util.Set;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffState;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.LabelCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.helper.EffectFactory;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.pet.PetDef.GeneType;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.skill.template.SkillBuffTemplate;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;
import com.imop.lj.gameserver.skill.template.SkillPetHorseAddTemplate;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 战斗单位
 * 
 */
public class FightUnit implements Identifier, Cloneable {
	private final Random random = new Random(RandomUtils.nextLong());
	private boolean attacker;
	private boolean first;
	
	/** 所属玩家Id */
	private long ownerId;
	
	/** 武将唯一Id，只有武将有，怪物等没有 */
	private long petUUId;
	
	/** 模板Id */
	private int tplId;
	/**战斗单位唯一ID*/
	protected String uuid;
	/** 战斗单位唯一标示 */
	protected String id;
	/** 战斗单位状态 */
	protected long status = 0L;
	/** 战斗单位类型 */
	protected PetType unitType;
	/** 战斗单位名称 */
	protected String name;
	
	/** 武将类型 */
	protected PetAttackType attackType;
	
	/** 普通攻击默认读取攻击力, 0默认,1物理,2法术*/
	protected int normalAttackTypeId;
	
	/** 宠物变异类型 */
	protected GeneType geneType = GeneType.NORMAL;

	/** 武将等级 */
	protected int level;
	/** 武将所在位置 */
	protected int position;
	
	/** 心法Id，主将有 */
	protected int mindId;
	/** 心法等级，主将有 */
	protected int mindLevel;
	
	/** 武将技能列表 */
	protected Map<Integer, FightUnitSkillInfo> skillListMap = new LinkedHashMap<Integer, FightUnitSkillInfo>();
	
	/** 武将战斗属性Map，key为对应属性在BattleDef中的定义 */
	protected Map<String, Double> attrMap = new HashMap<String, Double>();
	/** 武将初始属性Map，复活时使用此map更新attrMap */
	protected Map<String, Double> initAttrMap = new HashMap<String, Double>();
	
	/** 武将战斗过程中额外获得的效果列表，含被动技能效果 */
	protected List<IEffect> addEffectList = new ArrayList<IEffect>();
	
	/** 武将普通攻击效果 */
	protected List<IEffect> normalAttack = new ArrayList<IEffect>();
	/** 武将 主动技能 效果Map，key为技能id */
	protected Map<Integer, List<IEffect>> skillEffectMap = new HashMap<Integer, List<IEffect>>();
	
	/** 记录主动技能释放的回合数，用于伙伴和怪物释放cd */
	protected Map<Integer, Integer> usedSkillMap = new HashMap<Integer, Integer>();
	
	/** 记录主动技能释放的次数,用于战斗结束后更改技能熟练度*/
	protected Map<Integer, Integer> usedSkillCountMap = new HashMap<Integer, Integer>();
	
	/** 该轮选择的技能Id */
	protected int selSkillId;
	/** 该轮选择的目标（位置） */
	protected int selTarget;
	/** 嗑药的道具Id */
	protected int selItemId;
	/** 召唤宠物Id */
	protected long summonPetId;
	
	/** 怪物中可被捕捉时，该值为捕捉的宠物Id */
	private int catchPetId;
	/** 捕捉者的玩家Id */
	private long catcherOwnerId;
	
	/** 复活用的临时数据map */
	private Map<String, Double> reviveAttrMap = new HashMap<String, Double>();
	/** 复活的次数 */
	private int reviveTimes = 0;
	/** 标识最近一轮是否出手过，用于复活后出手判断 */
	private boolean actionFlag;
	
	/** 逃跑次数 */
	private int escapeTimes;
	
	/** 侠义之心次数 */
	private int chivalricTimes;
	
	/** 是否自动选择技能，目前竞技场的时候为true */
	private boolean isAutoSelSkill;
	
	/** 是否机器人，竞技场用 */
	private boolean isRobot;
	
	//主角武器模板Id
	private int leaderWeaponId;
	
//	//最近一次技能消耗检测是否成功的标识
//	private boolean lastCheckSelSkillCostFlag;
//	private int lastCheckSelSkillId;
	
	//需要显示的错误信息，如魔法不足，道具不足等错误提示
	private String showError = "";
	
	/** Map<骑宠Id,技能Id> */
	private Map<Integer, Integer> petHorseAddMap = new HashMap<Integer, Integer>();
	
	/** 有骑宠技能加成,骑宠技能的等级,计算伤害公式的时候用*/
	private int petHorseSkillLevel;
	
	public FightUnit() {
		setAttr(BattleDef.HP, 0.0D);
		setAttr(BattleDef.MP, 0.0D);
		setAttr(BattleDef.SP, 0.0D);
		setAttr(BattleDef.HP + BattleDef.MAX, 0.0D);
		setAttr(BattleDef.MP + BattleDef.MAX, 0.0D);
		setAttr(BattleDef.SP + BattleDef.MAX, 0.0D);
		
		setAttr(BattleDef.SPEED, 0.0D);
		setAttr(BattleDef.SPEED + BattleDef.MAX, 0.0D);
		
		setAttr(BattleDef.PHYSICAL_ATTACK, 0.0D);
		setAttr(BattleDef.PHYSICAL_ARMOR, 0.0D);
		setAttr(BattleDef.PHYSICAL_ANTICRIT, 0.0D);
		setAttr(BattleDef.PHYSICAL_CRIT, 0.0D);
		setAttr(BattleDef.PHYSICAL_DODGY, 0.0D);
		setAttr(BattleDef.PHYSICAL_HIT, 0.0D);
		
		setAttr(BattleDef.MAGIC_ATTACK, 0.0D);
		setAttr(BattleDef.MAGIC_ARMOR, 0.0D);
		setAttr(BattleDef.MAGIC_ANTICRIT, 0.0D);
		setAttr(BattleDef.MAGIC_CRIT, 0.0D);
		setAttr(BattleDef.MAGIC_DODGY, 0.0D);
		setAttr(BattleDef.MAGIC_HIT, 0.0D);
	}

	@Override
	public FightUnit clone() {
		try {
			FightUnit result = (FightUnit) super.clone();
			
			//attrMap
			for (Entry<String, Double> entry : this.attrMap.entrySet()) {
				setAttr(entry.getKey(), entry.getValue());
			}
			
			//addEffectList
			List<IEffect> addEList = new ArrayList<IEffect>();
			for (IEffect e : getAddEffectList()) {
				IEffect cloneEffect = e.clone();
				addEList.add(cloneEffect);
			}
			result.setAddEffectList(addEList);
			
			//normalAttack
			List<IEffect> eList = new ArrayList<IEffect>();
			for (IEffect e : getNormalAttack()) {
				IEffect cloneEffect = e.clone();
				eList.add(cloneEffect);
			}
			result.setNormalAttack(eList);
			
			//skillListMap
			for (FightUnitSkillInfo info : this.skillListMap.values()) {
				result.addSkillOnInit(info.clone());
			}
			
			//skillEffectMap
			for (Entry<Integer, List<IEffect>> entry : this.skillEffectMap.entrySet()) {
				List<IEffect> effectList = new ArrayList<IEffect>();
				int skillId = entry.getKey();
				List<IEffect> elst = entry.getValue();
				for (IEffect e : elst) {
					IEffect cloneEffect = e.clone();
					effectList.add(cloneEffect);
				}
				result.addSkillEffectList(skillId, effectList);
			}
			
			return result;
		} catch (CloneNotSupportedException e) {
			String message = "战斗单位无法被克隆";
			Loggers.battleLogger.error(message);
		}
		return null;
	}
	
	/**
	 * 返回武将唯一标示id
	 */
	@Override
	public String getIdentifier() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public int getTplId() {
		return tplId;
	}

	public void setTplId(int tplId) {
		this.tplId = tplId;
	}

	public Map<String, Double> getAttrMap() {
		return attrMap;
	}

	public void addSkillOnInit(FightUnitSkillInfo info) {
		skillListMap.put(info.getSkillId(), info);
	}
	
	public Collection<FightUnitSkillInfo> getAllSkill() {
		return skillListMap.values();
	}
	
	/**
	 * 获得状态
	 * 
	 * @return
	 */
	public long getStatus() {
		return this.status;
	}

	/**
	 * 增加状态
	 * 
	 * @param status
	 */
	public void addStatus(long status) {
		this.status |= status;
	}

	/**
	 * 移除状态
	 * 
	 * @param status
	 */
	public void removeStatus(long status) {
		this.status ^= status;
	}
	
	/**
	 * 判断是否有此状态
	 * 
	 * @param status
	 * @return
	 */
	public boolean hasStatus(long status) {
		return (this.status & status) == status;
	}

	/**
	 * 设置死亡
	 */
	public void dead() {
		this.status |= 1L;
	}

	/**
	 * 设置存活
	 */
	public void live() {
		this.status ^= 1L;
	}

	/**
	 * 是否死亡
	 * 
	 * @return
	 */
	public boolean isDead() {
		return hasStatus(FightUnitStatus.DEAD);
	}
	
	/**
	 * 是否被击飞
	 * @return
	 */
	public boolean isDeadFly() {
		return hasStatus(FightUnitStatus.DEAD_FLY);
	}
	
	/**
	 * 当前是否活着
	 * @return
	 */
	public boolean isAlive() {
		return getHp() > 0;
	}
	
	/**
	 * 是否广义的死亡，包含死亡和被捕捉
	 * @return
	 */
	public boolean isGeneralDead() {
		return isDead() || isCaught();
	}
	
	/**
	 * 该战斗对象当前是否可操作
	 * @return
	 */
	public boolean canOp() {
		if (isCaught() || isDeadFly() || isEscape()) {
			return false;
		}
		return true;
	}

	/**
	 * 获取一个技能最近一次在那一轮中使用过
	 * @param skillId
	 * @return
	 */
	public int getUsedSkillRound(int skillId) {
		if (usedSkillMap.containsKey(skillId)) {
			return usedSkillMap.get(skillId);
		}
		return 0;
	}
	
	/**
	 * 更新技能的轮数
	 * @param skillId
	 * @param round
	 */
	public void updateUsedSkill(int skillId, int round) {
		usedSkillMap.put(skillId, round);
	}
	
	/**
	 * 获取一个技能在战斗中的使用次数
	 * @param skillId
	 * @return
	 */
	public int getUsedSkillCount(int skillId){
		if (usedSkillCountMap.containsKey(skillId)) {
			return usedSkillCountMap.get(skillId);
		}
		return 0;
	}
	
	public Map<Integer, Integer> getUsedSkillCountMap(){
		return this.usedSkillCountMap;
	}
	
	public void addUsedSkillCount(int skillId){
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		if (skillTpl == null) {
			Loggers.battleLogger.error("skill template not exist!skillId=" + skillId);
			return;
		}
		
		//必须是心法技能和学习的技能
		if(!skillTpl.isMind() || skillTpl.isLeaderStudy()){
			return;
		}
		
		//第一次使用技能
		if(!usedSkillCountMap.containsKey(skillId)){
			usedSkillCountMap.put(skillId, 1);
		}else{
			usedSkillCountMap.put(skillId, usedSkillCountMap.get(skillId) + 1);
		}
	}
	
	/**
	 * 此战斗单位增加战斗效果
	 * 
	 * @param effect
	 */
	public void addEffect(IEffect effect) {
		if (effect == null) {
			return;
		}
		effect.setOwner(this);
		addEffectRelated(effect);
	}
	
	public void addEffect(List<IEffect> effects) {
		if (effects == null || effects.isEmpty()) {
			return;
		}
		for (IEffect effect : effects) {
			effect.setOwner(this);
			addEffectRelated(effect);
		}
	}
	
	/**
	 * 增加战斗效果，相应add的数值变更
	 * @param effect
	 */
	private void addEffectRelated(IEffect effect) {
		this.addEffectList.add(effect);
	}
	
	/**
	 * 移除战斗效果
	 * 
	 * @param effects
	 */
	public void remove(IEffect effect) {
		this.addEffectList.remove(effect);
	}
	
	private void onDead(boolean isDeadFly) {
		//死亡后清除所有被动效果
		addEffectList.clear();
		//状态置为只有死亡
		this.status = 0 | FightUnitStatus.DEAD;
		
		//如果被击飞，则记录击飞状态
		if (isDeadFly) {
			this.status |= FightUnitStatus.DEAD_FLY;
		}
	}
	
	/**
	 * 获取捕捉者的玩家Id
	 * @return
	 */
	public long getCatcherOwnerId() {
		return this.catcherOwnerId;
	}
	
	/**
	 * 当宠物被抓时的处理
	 * @param catcherOwernId 捕捉者的玩家Id
	 */
	public void onBeCaught(long catcherOwnerId) {
		//被捕捉后清除所有被动效果
		addEffectList.clear();
		//状态置为只有被捕捉
		this.status = 0 | FightUnitStatus.BE_CAUGHT;
		
		//设置捕捉者的玩家Id
		this.catcherOwnerId = catcherOwnerId;
	}
	
	/**
	 * 该战斗单位是否已被捕捉
	 * @return
	 */
	public boolean isCaught() {
		return hasStatus(FightUnitStatus.BE_CAUGHT);
	}
	
	/**
	 * 该战斗单位是否逃跑
	 * @return
	 */
	public boolean isEscape() {
		return hasStatus(FightUnitStatus.ESCAPE);
	}
	
	/**
	 * 复活时的处理
	 * @param reviveHp
	 */
	public void onRevive() {
		if (isCanRevive()) {
			//移除死亡状态
			this.removeStatus(FightUnitStatus.DEAD);
			//属性重新设置为初始属性
			this.attrMap.clear();
			this.attrMap.putAll(this.initAttrMap);
			//属性变为指定值
			for (Entry<String, Double> entry : getReviveAttrMap().entrySet()) {
				this.attrMap.put(entry.getKey(), entry.getValue());
			}
			//清除复活临时数据
			clearReviveAttrMap();
			//复活次数+1
			reviveTimes++;
		}
	}
	
	public boolean isCanRevive() {
		return !reviveAttrMap.isEmpty();
	}

	public Map<String, Double> getReviveAttrMap() {
		return reviveAttrMap;
	}
	
	public void clearReviveAttrMap() {
		this.reviveAttrMap.clear();
	}
	
	public int getReviveTimes() {
		return this.reviveTimes;
	}

	public boolean isActionFlag() {
		return actionFlag;
	}

	public void setActionFlag(boolean actionFlag) {
		this.actionFlag = actionFlag;
	}

	/**
	 * 根据战斗阶段获得所有战斗效果
	 * 
	 * @param effects
	 */
	public List<IEffect> getEffectsForExec(Phase phase) {
		List<IEffect> result = new ArrayList<IEffect>();
		for (IEffect e : this.addEffectList) {
			if (e.isVaild(phase)) {
				result.add(e);
			}
		}
		return result;
	}
	
	/**
	 * 获取战斗逻辑上肯定不能同时存在的buff，技术要求
	 * @param willAddETpl
	 * @return
	 */
	public IEffect getBuffConfictLogic(SkillEffectTemplate willAddETpl) {
		EffectValueType vType = willAddETpl.getEffectValueType();
		//如果是加状态的，同一个状态也只能存在一个
		if (vType == EffectValueType.STATUS &&
				hasStatus(willAddETpl.getValueBase())) {
			for (IEffect e : addEffectList) {
				if (e.getEffectTpl().getEffectValueType() == EffectValueType.STATUS && 
						e.getEffectTpl().getValueBase() == willAddETpl.getValueBase()) {
					return e;
				}
			}
		}
		return null;
	}
	
	public List<IEffect> getBadBuffEffectList() {
		List<IEffect> ret = new ArrayList<IEffect>();
		for (IEffect e : addEffectList) {
			if (e.isBuff() && e.getEffectTpl().isBad()) {
				ret.add(e);
			}
		}
		return ret;
	}
	
	public List<IEffect> getGoodBuffEffectList() {
		List<IEffect> ret = new ArrayList<IEffect>();
		for (IEffect e : addEffectList) {
			if (e.isBuff() && e.getEffectTpl().isGood()) {
				ret.add(e);
			}
		}
		return ret;
	}
	
	public List<IEffect> getNeutralBuffEffectList() {
		List<IEffect> ret = new ArrayList<IEffect>();
		for (IEffect e : addEffectList) {
			if (e.isBuff() && e.getEffectTpl().isNeutral()) {
				ret.add(e);
			}
		}
		return ret;
	}
	
	public List<IEffect> getAddEffectList() {
		return this.addEffectList;
	}
	
	public void setAddEffectList(List<IEffect> addEffectList) {
		this.addEffectList = addEffectList;
	}

	/**
	 * 根据buff大类获取buff效果列表
	 * @param bc
	 * @return
	 */
	public List<IEffect> getBuffEffectByCatalog(BuffCatalog bc) {
		List<IEffect> ret = new ArrayList<IEffect>();
		for (IEffect e : addEffectList) {
			if (e.isBuff()) {
				int buffId = e.getEffectTpl().getBuffTypeId();
				SkillBuffTemplate sbTpl = Globals.getTemplateCacheService().get(buffId, SkillBuffTemplate.class);
				if (sbTpl != null && sbTpl.getBuffCatalog() == bc) {
					ret.add(e);
				}
			}
		}
		return ret;
	}

	/**
	 * 此技能有没有此战斗效果
	 * 
	 * @param skillId
	 * @return
	 */
	public boolean hasSkill(int skillId) {
		//普通攻击
		if (isNomarlAttack(skillId)) {
			return true;
		}

		return this.skillEffectMap.containsKey(skillId);
	}
	
	public int getSkillLevel(int skillId) {
		if (this.skillListMap.containsKey(skillId)) {
			return this.skillListMap.get(skillId).getSkillLevel();
		}
		return 0;
	}
	
	public boolean isNomarlAttack(int skillId) {
		return skillId == BattleDef.NORMAL_ATTACK_SKILL_ID;
	}
	
	public boolean isCatchSkill(int skillId) {
		return skillId == BattleDef.CATCH_PET_SKILL_ID;
	}
	
	public boolean isDefenceSkill(int skillId) {
		return skillId == BattleDef.DEFENCE_SKILL_ID;
	}
	
	public int getPosition() {
		return this.position;
	}

	public void setPosition(int position) {
		this.position = position;
	}

	public List<IEffect> getNormalAttack() {
		return this.normalAttack;
	}

	public void setNormalAttack(List<IEffect> normalAttack) {
		setOwnerOfEffect(normalAttack);
		this.normalAttack = normalAttack;
	}

	public List<IEffect> getSkillEffectList(int skillId) {
		return this.skillEffectMap.get(skillId);
	}
	
	public void addSkillEffectOnInit() {
		for (FightUnitSkillInfo skillInfo : skillListMap.values()) {
			List<IEffect> skillEffectList = new ArrayList<>();
			
			//技能公共效果
			skillEffectList.addAll(Globals.getTemplateCacheService().getBattleTemplateCache().getSkillEffects(
					skillInfo.getSkillId(), skillInfo.getSkillLevel(), skillInfo.getSkillLayer(), 0, 0));
			
			//镶嵌的仙符效果
			for (FightUnitSkillEffectInfo eeInfo : skillInfo.getEmbedEffectList()) {
				IEffect ee = EffectFactory.createEmbedSkillEffect(eeInfo.getEffectId(), eeInfo.getEffectLevel(), 
						skillInfo.getSkillId(), skillInfo.getSkillLevel());
				skillEffectList.add(ee);
			}
			
			addSkillEffectList(skillInfo.getSkillId(), skillEffectList);
		}
	}
	
	public void addSkillEffectList(int skillId, List<IEffect> effectList) {
		if (effectList == null || effectList.isEmpty()) {
			return;
		}
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		if (skillTpl == null) {
			Loggers.battleLogger.error("skill template not exist!skillId=" + skillId);
			return;
		}

		//XXX 这里必须是战斗中使用的被动技能
		if (skillTpl.isPassive()) {
			//被动技能效果放入addEffectMap 
			this.addEffect(effectList);
		} else {
			setOwnerOfEffect(effectList);
			//主动技能效果，放入技能效果map
			skillEffectMap.put(skillId, effectList);
		}
	}
	
	private void setOwnerOfEffect(List<IEffect> effectList) {
		for (IEffect e : effectList) {
			e.setOwner(this);
		}
	}
	
	public PetAttackType getAttackType() {
		return this.attackType;
	}

	public void setAttackType(PetAttackType aType) {
		this.attackType = aType;
	}

	public GeneType getGeneType() {
		return geneType;
	}

	public void setGeneType(GeneType geneType) {
		this.geneType = geneType;
	}

	public int getLevel() {
		return this.level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public boolean isLeader() {
		return this.unitType == PetType.LEADER;
	}
	
	public boolean isPet() {
		return this.unitType == PetType.PET;
	}
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public boolean isAutoSelSkill() {
		return isAutoSelSkill;
	}

	public void setAutoSelSkill(boolean isAutoSelSkill) {
		this.isAutoSelSkill = isAutoSelSkill;
	}

	/**
	 * 按照速度从大到小对战斗单位排序
	 */
	public static final Comparator<FightUnit> COMPARATOR = new Comparator<FightUnit>() {
		public int compare(FightUnit o1, FightUnit o2) {
			double speed1 = o1.getAttr(BattleDef.SPEED);
			double speed2 = o2.getAttr(BattleDef.SPEED);
			if (speed1 > speed2)
				return -1;
			if (speed1 < speed2) {
				return 1;
			}

			if (o1.isAttacker() != o2.isAttacker()) {
				if (o1.isAttacker()) {
					return -1;
				}
				return 1;
			}

			if(o1.getTemplateId() > o2.getTemplateId()){
				return 1;
			}
			
			if(o1.getTemplateId() < o2.getTemplateId()){
				return -1;
			}
			
			if (o1.hashCode() > o2.hashCode())
				return -1;
			if (o1.hashCode() < o2.hashCode()) {
				return 1;
			}
			return 0;
		}
	};

	public Random getRandom() {
		return this.random;
	}

	public long getHp() {
		return getAttr(BattleDef.HP).longValue();
	}
	
	/**
	 * 是否是攻击者
	 * 
	 * @return
	 */
	public boolean isAttacker() {
		return this.attacker;
	}

	/**
	 * 设置攻击者
	 * 
	 * @return
	 */
	public void setAttacker(boolean attacker) {
		this.attacker = attacker;
	}

	/**
	 * 是否是第一个
	 * 
	 * @return
	 */
	public boolean isFirst() {
		return this.first;
	}

	/**
	 * 设置第一个
	 * 
	 * @return
	 */
	public void setFirst(boolean first) {
		this.first = first;
	}

	public PetType getUnitType() {
		return unitType;
	}

	public void setUnitType(PetType unitType) {
		this.unitType = unitType;
	}

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public int getTemplateId() {
		return tplId;
	}

	public void setTemplateId(int templateId) {
		this.tplId = templateId;
	}
	
	public String getModelId() {
		String modelId = "";
		if (getUnitType() == PetType.MONSTER) {
			EnemyTemplate tpl = Globals.getTemplateCacheService().get(this.tplId, EnemyTemplate.class);
			modelId = tpl.getModelId();
		} else {
			PetTemplate tpl = Globals.getTemplateCacheService().get(this.tplId, PetTemplate.class);
			modelId = tpl.getModelId();
		}
		return modelId;
	}
	
	public boolean hasAttr(String key) {
		return this.attrMap.containsKey(key);
	}
	
	/**
	 * 获取战斗属性基础值
	 * @param key
	 * @return
	 */
	public Double getAttr(String key) {
		if (hasAttr(key)) {
			return this.attrMap.get(key);
		}
		return 0D;
	}
	
	/**
	 * 增量更新一个属性值
	 * @param key
	 * @param changedValue
	 */
	public Double updateAttr(String key, int changedValue) {
		//上限检查
		Double last = getAttr(key);
		Double v = last + changedValue;
		String maxKey = key + BattleDef.MAX;
		if (hasAttr(maxKey)) {
			if (v > getAttr(maxKey)) {
				v = getAttr(maxKey);
			}
		}
		if (v <= 0) {
			double tmp = v;
			v = 0D;
			
			//血量的特殊处理，如果没血的，就死亡了
			if (key == BattleDef.HP) {
				boolean isDeadFly = calcDeadFly(tmp);
				onDead(isDeadFly);
			}
		}
		this.setAttr(key, v);
		//返回实际变化值
		return getAttr(key) - last;
	}
	
	/**
	 * 根据血量计算是否被击飞
	 * @param delta
	 * @param max
	 * @return
	 */
	public boolean calcDeadFly(double delta) {
		if (delta < 0) {
			//只有怪物和宠物可以被击飞
			if (getUnitType() == PetType.MONSTER || getUnitType() == PetType.PET) {
				if (-delta >= getAttr(BattleDef.HP + BattleDef.MAX) * Globals.getGameConstants().getBattleDeadFly()) {
					return true;
				}
			}
		}
		return false;
	}
	
	/**
	 * 设置一个属性值
	 * @param key
	 * @param value
	 */
	public void setAttr(String key, Double value) {
		this.attrMap.put(key, value);
	}

	public Map<String, Double> getInitAttrMap() {
		return initAttrMap;
	}

	public void setInitAttrMap(Map<String, Double> initAttrMap) {
		this.initAttrMap = initAttrMap;
	}

	/**
	 * 支持两种:
	 * 1.固定效果(未配置buff权重) + 从随机效果(都配置了buff权重)列表中随机
	 * 2.从随机效果(都配置了buff权重)列表中随机
	 * @param phase
	 * @return
	 */
	public List<IEffect> getSelSkillEffectList(Phase phase) {
		List<IEffect> ret = new ArrayList<IEffect>();
		if (this.selSkillId > 0 && this.skillEffectMap.containsKey(this.selSkillId)) {
			for (IEffect e : this.skillEffectMap.get(this.selSkillId)) {
				if (e.isVaild(phase)) {
					ret.add(e);
				}
			}
		}
		if(ret.isEmpty()){
			return ret;
		}
		
		List<Integer> randomSkillEffectIdList = new ArrayList<Integer>();
		for (IEffect e : ret) {
			//只加载配置权重的
			if(e.getEffectTpl() == null || e.getEffectTpl().getEffectWeight() <= 0){
				continue;
			}
			
			randomSkillEffectIdList.add(e.getId());
			
		}
		
		//目前是多个非主效果列表中随机1个
		if(!randomSkillEffectIdList.isEmpty()){
			SkillEffectTemplate tpl = Globals.getTemplateCacheService().getBattleTemplateCache().getBuffWeightLst(randomSkillEffectIdList, 1);
			Iterator<IEffect> iterator = ret.iterator();
			while(iterator.hasNext()){
				IEffect e = iterator.next();
				//删除配置权重的效果和同一效果分组Id的效果
				if(e.getEffectTpl().getEffectWeight() > 0
						&& e.getEffectTpl().getEffectGroupId() != tpl.getEffectGroupId()){
					iterator.remove();
				}
			}
		}
		
		return ret;
	}
	
	public List<IEffect> getActionEffectsForAction(Phase phase, int round) {
//		//默认最近一次技能check成功
//		setLastCheckSelSkillCostFlag(true);
//		setLastCheckSelSkillId(0);
		
		List<IEffect> ret = getActionEffects(phase, round);
		//根据返回的实际技能效果，修正selSkillId，在doSkillCost的时候确保正确
		if (ret != null) {
			//如果是普攻，则将技能id设置为1
			if (ret.equals(getNormalAttack())) {
				this.setSelSkillId(BattleDef.NORMAL_ATTACK_SKILL_ID);
			}
		} else {
			//不能释放任何技能，设置技能id为0
			this.setSelSkillId(0);
		}
		return ret;
	}
	
	private List<IEffect> getActionEffects(Phase phase, int round) {
		//混乱了，则为普通攻击
		if (hasStatus(FightUnitStatus.CHAOS)) {
			if (!hasStatus(FightUnitStatus.FORBID_NORMAL)) {
				return getNormalAttack();
			} else {
				//混乱且被禁止普攻，则不出手
				return null;
			}
		}
		
		//是否被沉默
		if (!hasStatus(FightUnitStatus.FORBID_SKILL)) {
			if (checkSelSkill(round)) {
				return getSelSkillEffectList(phase);
			}
		}
		
		//判断能否使用普通攻击，如果可以，则返回普通攻击的效果
		if (!hasStatus(FightUnitStatus.FORBID_NORMAL)) {
			return getNormalAttack();
		} else {
			//普通攻击被禁止了，返回空
			return null;
		}
	}
	
	private void autoSelSkill(int round) {
		//根据配置进行技能选择
		Globals.getBattleService().autoSelSkillForFightUnit(this, round);
	}
	
	/**
	 * 检查技能消耗
	 * @param round
	 * @return
	 */
	private boolean checkSelSkill(int round) {
		boolean flag = false;
		switch (getUnitType()) {
		case LEADER:
		case PET:
			//如果是自动选择技能的，则需要先选技能，
			if (isAutoSelSkill()) {
				autoSelSkill(round);
			}
			flag = checkPetSelSkillCost(round);
			break;
		case FRIEND:
		case MONSTER:
			flag = checkFriendSelSkill(round);
			break;
		default:
			Loggers.battleLogger.error(getIdentifier() + " invalid unit type!" + getUnitType());
			break;
		}
		return flag;
	}
	
	/**
	 * 检测玩家是否能释放所选技能
	 */
	private boolean checkPetSelSkillCost(int round) {
		if (this.selSkillId <= 0) {
			return false;
		}
		if (isNomarlAttack(this.selSkillId)) {
			return false;
		}
		
		boolean flag = Globals.getBattleService().checkSkillCost(this, this.selSkillId);
		if (flag) {
			//更新本轮使用该技能，这里也进行记录
			FightUnitSkillInfo t = this.skillListMap.get(this.selSkillId);
			t.setLastUsedRound(round);
			//增加技能使用次数
			this.addUsedSkillCount(this.selSkillId);
		} else {
			//如果魔法不足，则增加错误提示
			updateShowError(Globals.getBattleService().getSkillCostError(this.selSkillId));
		}
//		//设置最近一次技能check标识位
//		setLastCheckSelSkillCostFlag(flag);
//		setLastCheckSelSkillId(this.selSkillId);
		
		return flag;
	}
	
	private boolean checkFriendSelSkill(int round) {
		//先默认普通攻击，下面再选技能
		setSelSkillId(0);
		
		//伙伴按照技能优先级和回合数的限制，进行释放技能，不检测耗蓝
		List<FightUnitSkillInfo> skillList = new ArrayList<FightUnitSkillInfo>();
		List<Integer> weightList = new ArrayList<Integer>();
		int weight = 0;
		for (Integer skillId : skillEffectMap.keySet()) {
			FightUnitSkillInfo info = skillListMap.get(skillId);
			//在cd中的技能，跳过
			if (isSkillInCdRound(skillId, round)) {
				continue;
			}
			skillList.add(info);
			weight += info.getWeight();
			weightList.add(weight);
		}
		//技能都在cd中
		if (skillList.isEmpty()) {
			return false;
		}
		
		int selSkillId = 0;
		//有一个可用的技能，则使用该技能
		if (skillList.size() == 1) {
			selSkillId = skillList.get(0).getSkillId();
		} else {
			//随机一个技能
			FightUnitSkillInfo hitSkill = RandomUtils.hitObject(weightList, skillList, weight);
			if (hitSkill != null) {
				selSkillId = hitSkill.getSkillId();
			} else {
				Loggers.battleLogger.error("hit Skill is null!fightUnit=" + getIdentifier() + ";round=" + round);
			}
		}
		if (selSkillId > 0) {
			//设置选择的技能
			setSelSkillId(selSkillId);
			//更新本轮使用该技能
			FightUnitSkillInfo t = skillListMap.get(selSkillId);
			t.setLastUsedRound(round);
			return true;
		}
		
		return false;
	}
	
	public boolean isSkillInCdRound(int skillId, int curRound) {
		FightUnitSkillInfo info = this.skillListMap.get(skillId);
		//在cd中的技能
		if (info.getLastUsedRound() > 0 && info.getCdRound() > 0 &&
				info.getLastUsedRound() != curRound &&
				info.getLastUsedRound() + info.getCdRound() >= curRound ) {
			return true;
		}
		return false;
	}
	
	/**
	 * 玩家释放技能消耗
	 */
	public ReportItem doSkillCost() {
		//只有主将和宠物有技能消耗
		if (!isLeader() && !isPet()) {
			return null;
		}
		//selSkillId为0或普攻时，不需要消耗
		if (this.selSkillId <= 0 || this.selSkillId == BattleDef.NORMAL_ATTACK_SKILL_ID) {
			return null;
		}
		
		int skillLevel = getSkillLevel(this.selSkillId);
		int cost = Globals.getBattleService().getSkillCostValue(this.selSkillId, skillLevel);
		if (cost <= 0) {
			//不需要消耗，直接返回
			return null;
		}
		
		String attrKey = Globals.getBattleService().getSkillCostAttrKey(this.selSkillId, skillLevel);
		//消耗为负数
		int realCost = updateAttr(attrKey, -cost).intValue();
		
		//消耗的战报
		int reportKey = Globals.getBattleService().getSkillCostReportKey(this.selSkillId, skillLevel);
		ReportItem item = ReportItem.valueOf(this, null);
		item.updateAttr(reportKey, realCost);
		//正常消耗不冒泡
		item.updateAction(BattleReportDefine.REPORT_ITEM_NO_POP, Boolean.valueOf(true));
		return item;
	}
	
	public int getSelSkillId() {
		return this.selSkillId;
	}

	public void setSelSkillId(int selSkillId) {
		this.selSkillId = selSkillId;
	}

	public int getSelTarget() {
		return selTarget;
	}

	public void setSelTarget(int selTarget) {
		this.selTarget = selTarget;
	}

	/**
	 * 该战斗单位是否一个可被捕捉的对象
	 * @return
	 */
	public boolean canBeCaught() {
		return this.catchPetId > 0 && !isGeneralDead();
	}
	
	public int getCatchPetId() {
		return this.catchPetId;
	}
	
	public void setCatchPetId(int petTplId) {
		this.catchPetId = petTplId;
	}
	
	public int getMindId() {
		return mindId;
	}

	public void setMindId(int mindId) {
		this.mindId = mindId;
	}

	public int getMindLevel() {
		return mindLevel;
	}

	public void setMindLevel(int mindLevel) {
		this.mindLevel = mindLevel;
	}
	

	public int getEscapeTimes() {
		return escapeTimes;
	}

	public void addEscapeTimes() {
		this.escapeTimes++;
	}
	
	public void addChivalricTimes(){
		this.chivalricTimes++;
	}
	
	public void clearChivalricTimes(){
		this.chivalricTimes = 0;
	}

	public int getChivalricTimes() {
		return chivalricTimes;
	}

	public long getOwnerId() {
		return ownerId;
	}

	public void setOwnerId(long ownerId) {
		this.ownerId = ownerId;
	}

	public long getPetUUId() {
		return petUUId;
	}

	public void setPetUUId(long petUUId) {
		this.petUUId = petUUId;
	}

	public int getSelItemId() {
		return selItemId;
	}

	public void setSelItemId(int selItemId) {
		this.selItemId = selItemId;
	}
	
	public long getSummonPetId() {
		return summonPetId;
	}

	public void setSummonPetId(long summonPetId) {
		this.summonPetId = summonPetId;
	}

	public int getLeaderWeaponId() {
		return leaderWeaponId;
	}

	public void setLeaderWeaponId(int leaderWeaponId) {
		this.leaderWeaponId = leaderWeaponId;
	}

	/**
	 * 只有主将可以增加怒气
	 * @return
	 */
	public boolean canAddSp() {
		return unitType == PetType.LEADER;
	}
	
	/**
	 * 获取武将主动技能id集合
	 * @return
	 */
	public Set<Integer> getSkillIdSet() {
		return this.skillEffectMap.keySet();
	}

	public boolean isRobot() {
		return isRobot;
	}

	public void setRobot(boolean isRobot) {
		this.isRobot = isRobot;
	}

//	public boolean isLastCheckSelSkillCostFlag() {
//		return lastCheckSelSkillCostFlag;
//	}
//
//	public void setLastCheckSelSkillCostFlag(boolean lastCheckSelSkillCostFlag) {
//		this.lastCheckSelSkillCostFlag = lastCheckSelSkillCostFlag;
//	}
//
//	public int getLastCheckSelSkillId() {
//		return lastCheckSelSkillId;
//	}
//
//	public void setLastCheckSelSkillId(int lastCheckSelSkillId) {
//		this.lastCheckSelSkillId = lastCheckSelSkillId;
//	}
	
	public boolean hasShowError() {
		return this.showError != null && !this.showError.isEmpty();
	}
	
	public String getShowError() {
		return this.showError;
	}
	
	public void updateShowError(String error) {
		if (error != null && !error.isEmpty()) {
			this.showError = error;
		}
	}
	
	public void clearShowError() {
		this.showError = "";
	}
	
	public Map<Integer, Integer> getPetHorseAddMap() {
		return petHorseAddMap;
	}

	public void setPetHorseAddMap(Map<Integer, Integer> petHorseAddMap) {
		for(Entry<Integer, Integer> entry : petHorseAddMap.entrySet()){
			this.petHorseAddMap.put(entry.getKey(), entry.getValue());
		}
	}

	public int getPetHorseSkillLevel() {
		return petHorseSkillLevel;
	}

	public void setPetHorseSkillLevel(int petHorseSkillLevel) {
		this.petHorseSkillLevel = petHorseSkillLevel;
	}
	
	public int getNormalAttackTypeId() {
		return normalAttackTypeId;
	}

	public void setNormalAttackTypeId(int normalAttackTypeId) {
		this.normalAttackTypeId = normalAttackTypeId;
	}

	public int hashCode() {
		int result = 1;
		result = 31 * result
				+ (this.random == null ? 0 : this.random.hashCode());
		return result;
	}

	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		FightUnit other = (FightUnit) obj;
		if (getIdentifier().equals(other.getIdentifier())) {
			return true;
		}
		return false;
	}

	public Object toMap() {
		Map<Integer, Object> js = new HashMap<Integer, Object>();
		PetType unitTypeShow = this.getUnitType();
		if (isRobot()) {
			//机器人按位置算是否主将、宠物
			if (getPosition() == BattleDef.LEADER_POS_DEFAULT) {
				unitTypeShow = PetType.LEADER;
			} else if (getPosition() == BattleDef.PET_POS_DEFAULT) {
				unitTypeShow = PetType.PET;
			}
		}
		js.put(BattleReportDefine.FIGHTUNIT_TYPE, unitTypeShow.getIndex());
		
		js.put(BattleReportDefine.FIGHTUNIT_ID, this.getIdentifier());
		js.put(BattleReportDefine.FIGHTUNIT_PETUUID, this.getPetUUId());
		js.put(BattleReportDefine.FIGHTUNIT_OWERID, this.getOwnerId());
		js.put(BattleReportDefine.FIGHTUNIT_TPLID, this.getTplId());
		js.put(BattleReportDefine.FIGHTUNIT_POSITION, this.getPosition());
		js.put(BattleReportDefine.FIGHTUNIT_ATTACKTYPE, this.getAttackType().getIndex());
		js.put(BattleReportDefine.FIGHTUNIT_LEVEL, this.getLevel());
		js.put(BattleReportDefine.FIGHTUNIT_GENETYPE, this.getGeneType().getIndex());
		//主将武器模板Id
		js.put(BattleReportDefine.FIGHTUNIT_LEADER_WEAPONID, getLeaderWeaponId());
		
		js.put(BattleReportDefine.FIGHTUNIT_HP, this.getHp());
		js.put(BattleReportDefine.FIGHTUNIT_HP_MAX, this.getAttr(BattleDef.HP + BattleDef.MAX));
		//是否可被捕捉的对象
		js.put(BattleReportDefine.FIGHTUNIT_CAN_BE_CAUGHT, this.getCatchPetId());
		//名字
		js.put(BattleReportDefine.FIGHTUNIT_NAME, this.getName());
		
		js.put(BattleReportDefine.FIGHTUNIT_MP, this.getAttr(BattleDef.MP));
		js.put(BattleReportDefine.FIGHTUNIT_MP_MAX, this.getAttr(BattleDef.MP + BattleDef.MAX));
		if (isLeader()) {
			js.put(BattleReportDefine.FIGHTUNIT_SP, this.getAttr(BattleDef.SP));
			js.put(BattleReportDefine.FIGHTUNIT_SP_MAX, this.getAttr(BattleDef.SP + BattleDef.MAX));
		}
		
		//buff
		List<Object> buffList = new ArrayList<Object>();
		//遍历effect，找到是buff的，加到这里
		for (IEffect e : this.addEffectList) {
			if (e instanceof BaseBuffEffect) {
				Map<Integer, Object> map = new HashMap<Integer, Object>();
				map.put(BattleReportDefine.REPORT_ITEM_BUFF_UUID, e.getId());
				map.put(BattleReportDefine.REPORT_ITEM_BUFF_ID, e.getEffectTpl().getBuffTypeId());
				map.put(BattleReportDefine.REPORT_ITEM_BUFF_STATE, BuffState.ING.getIndex());
				map.put(BattleReportDefine.REPORT_ITEM_BUFF_LEFT, Integer.valueOf(((BaseBuffEffect) e).getLeftTimes()));

				ReportItem item = ReportItem.valueOf(this, e);
				item.setBuffMap(map);
				
				buffList.add(item.toMap());
			}
		}
		js.put(BattleReportDefine.REPORT_ITEM_BUFF, buffList);
		
		//状态
		js.put(BattleReportDefine.FIGHTUNIT_STATUS, getStatus());
		
		//侠义之心标记
		if(this.getChivalricTimes() > 0){
			js.put(BattleReportDefine.REPORT_ITEM_CHIVALRIC_ID, LabelCatalog.CHIVALRIC.getIndex());
			js.put(BattleReportDefine.REPORT_ITEM_CHIVALRIC, Boolean.valueOf(true));
		}
		return js;
	}
	
	public SkillPetHorseAddTemplate getPetHorseAddTpl(FightUnit attacker, int selSkillId) {
		SkillPetHorseAddTemplate tpl = null;
		//Map<骑宠Id,技能Id>
		for(Entry<Integer, Integer> entry : attacker.getPetHorseAddMap().entrySet()){
			if(entry.getValue() == this.selSkillId){
				tpl = Globals.getTemplateCacheService().get(entry.getKey(), SkillPetHorseAddTemplate.class);
			}
		}
		return tpl;
	}
	
	 @Override
	 public String toString() {
		String baseStr = "[battlelog]基础数值：[ id = " + id + ", status = " + status
				+ ", unitType = " + unitType + ", type = " + attackType
				+ ", level = " + level + ", position = " + position
				+ ", tplId = " + tplId + ", skillId = "
				+ ", leader = " + isLeader() + "]";
		StringBuffer attackSb = new StringBuffer();
		attackSb.append("[battlelog]攻击参数：");
		for(Entry<String, Double> entry : this.attrMap.entrySet()){
			attackSb.append(entry.getKey());
			attackSb.append(" = ");
			attackSb.append(entry.getValue());
			attackSb.append(",");
		}
		return "\n\t" + baseStr + "\n\t" + attackSb.toString();
	 }
}

