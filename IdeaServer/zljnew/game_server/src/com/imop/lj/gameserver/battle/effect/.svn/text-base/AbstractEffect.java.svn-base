package com.imop.lj.gameserver.battle.effect;

import java.text.MessageFormat;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.Battle;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Round;
import com.imop.lj.gameserver.battle.helper.BattleCalculateHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetAttackType;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;

/**
 * 战斗效果抽象类
 * 
 */
public abstract class AbstractEffect implements IEffect {
	protected final Logger logger = Loggers.battleLogger;
	
	protected int effectId;
	protected SkillEffectTemplate effectTpl;
	
	protected EffectType type;
	protected Phase[] phases;
	protected int index;
	
	protected int skillId;
	protected int skillLevel;
	protected int skillLayer;
	protected FightUnit owner;
	
	protected boolean isMain;
	
	/** 效果自身等级，仙符类 */
	protected int effectLevel;
	/** 效果最近一次使用成功回合数 */
	protected int lastUsedRound;
	
	public AbstractEffect(int effectId, EffectType type, Phase[] phases) {
		this.effectId = effectId;
		this.type = type;
		this.phases = phases;
		try {
			this.effectId = effectId;
			this.effectTpl = Globals.getTemplateCacheService().get(effectId, SkillEffectTemplate.class);
			if (effectTpl == null) {
				throw new Exception("effect id not exist!" + effectId);
			}
		} catch(Exception e) {
			throw new IllegalArgumentException("无法初始化效果[" + getClass().getSimpleName() + "]对应的技能标识", e);
		}
	}
	
	@Override
	public int getId() {
		return this.effectId;
	}
	
	public int getEffectId() {
		return effectId;
	}

	@Override
	public boolean isBuff() {
		return false;
	}
	
	@Override
	public boolean isMagicAttack() {
		if(this.effectTpl.isDefaultAttack()){
			return owner.getAttackType() == PetAttackType.INTELLECT;
		}
		return this.effectTpl.isMagicAttack();
	}

	/**
	 * 判断此战斗效果是否合法
	 */
	@Override
	public boolean isVaild(Phase phase) {
		if ((this.phases == null) || (this.phases.length == 0)) {
			return false;
		}
		// 是否死亡
		FightUnit owner = getOwner();
		if (owner.isDead()) {
			if (this.logger.isDebugEnabled()) {
				String message = MessageFormat.format("效果[{0}]的所有者[{1}]已死，效果无效", getIdentifier(), owner.getIdentifier());
				this.logger.debug(message);
			}

			return false;
		}
		// 判断此战斗效果是否与战斗效果定义的对象相符
		for (Phase p : this.phases) {
			if (p == phase) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 根据上下文判断是否合法
	 */
	@Override
	public boolean isVaild(Phase phase, Object context) {
		return isVaild(phase);
	}

	/**
	 * 执行战斗效果
	 */
	@Override
	public List<ReportItem> execute(Phase phase, Object context) {
		for (Phase vaild : getPhases()) {
			if (vaild == phase) {
				//如果效果在cd中，则不执行
				if (isEffectInCD(context)) {
					return null;
				}
				//设置最近一次效果执行的轮数
				setLastUsedRound(getCurRound(context));
				//执行效果
				return doExecute(phase, context);
			}
		}
		return null;
	}
	
	public boolean isEffectInCD(Object context) {
		//buff自身没有cd，释放才有cd
		if (this.isBuff()) {
			return false;
		}
		//在cd中，目前只有镶嵌的仙符效果有cd
		int curRound = getCurRound(context);
		if (isEmbedEffect() &&
				getLastUsedRound() > 0 && getCdRound() > 0 &&
				getLastUsedRound() != curRound &&
				getLastUsedRound() + getCdRound() >= curRound) {
			return true;
		}
		return false;
	}
	
	public int getCurRound(Object context) {
		int round = 0;
		if (context instanceof Action &&
				((Action) context).getRound() != null) {
			round = ((Action) context).getRound().getRound();
		} else if (context instanceof Round) {
			round = ((Round) context).getRound();
		} else if (context instanceof Battle) {
			round = ((Battle) context).getRound();
		} else {
			Loggers.battleLogger.error("ERROR!getCurRound error!context=" + context);
		}
		
		return round;
	}
	
	/**
	 * 执行
	 * 
	 * @param phase
	 * @param context
	 * @return
	 */
	protected abstract List<ReportItem> doExecute(Phase phase, Object context);

	/**
	 * 定义战斗对象持有者
	 */
	@Override
	public void setOwner(FightUnit owner) {
		this.owner = owner;
	}

	/**
	 * 获得战斗对象持有者
	 */
	@Override
	public FightUnit getOwner() {
		return this.owner;
	}

	/**
	 * 返回唯一标识
	 */
	@Override
	public String getIdentifier() {
		return this.effectId+"";
	}

	/**
	 * 返回战斗效果定义阶段
	 */
	@Override
	public Phase[] getPhases() {
		return this.phases;
	}

	/**
	 * 战斗效果分类定义
	 */
	@Override
	public EffectType getType() {
		return this.type;
	}

	public int compareTo(IEffect other) {
		if (getIndex() > other.getIndex())
			return 1;
		if (getIndex() < other.getIndex()) {
			return -1;
		}
		if (hashCode() > other.hashCode())
			return 1;
		if (hashCode() < other.hashCode()) {
			return -1;
		}
		return 0;
	}
	
	@Override
	public SkillEffectTemplate getEffectTpl() {
		return this.effectTpl;
	}

	/**
	 * 克隆,在每次战斗过程中需要拷贝
	 */
	@Override
	public IEffect clone() {
		try {
			return (IEffect) super.clone();
		} catch (CloneNotSupportedException e) {
			logger.error(String.format("克隆战斗效果失败 效果id:%d", this.getIdentifier()));
		}
		return null;
	}
	
	@Override
	public void init() {
		
	}

	@Override
	public int getIndex() {
		return this.index;
	}

	/**
	 * 获得索引
	 * 
	 * @param index
	 */
	public void setIndex(int index) {
		this.index = index;
	}

	/**
	 * 定义阶段
	 * 
	 * @param phases
	 */
	public void setPhases(Phase[] phases) {
		this.phases = phases;
	}

	@Override
	public int getSkillId() {
		return skillId;
	}
	
	@Override
	public int getReportSkillId(Object paramObject) {
		//不取该阶段效果id,而是取之前阶段的效果id
		if(EffectType.DoubleAttackWithValue == getType()){
			Action action = (Action)paramObject;
			List<IEffect> effects = action.getEffects(Phase.ACTION_EXECUTE);
			return effects.get(0).getSkillId();
		}
		return getSkillId();
	}
	
	@Override
	public int getSkillLevel() {
		return skillLevel;
	}

	@Override
	public void setSkillLevel(int skillLevel) {
		this.skillLevel = skillLevel;
	}
	
	@Override
	public int getSkillLayer() {
		return skillLayer;
	}

	@Override
	public void setSkillLayer(int skillLayer) {
		this.skillLayer = skillLayer;
	}

	@Override
	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}
	
	@Override
	public boolean isFrom(IEffect fromE) {
		return false;
	}
	
	@Override
	public boolean isMain() {
		return isMain;
	}
	
	@Override
	public void setMain() {
		this.isMain = true;
	}
	
	public final int getEffectLevel() {
		return effectLevel;
	}

	public final void setEffectLevel(int effectLevel) {
		this.effectLevel = effectLevel;
	}
	
	public int getLastUsedRound() {
		return lastUsedRound;
	}

	public void setLastUsedRound(int lastUsedRound) {
		this.lastUsedRound = lastUsedRound;
	}
	
	/**
	 * 获取技能效果的冷却回合数
	 * @return
	 */
	public int getCdRound() {
		return this.effectTpl.getCdRound();
	}

	/**
	 * 计算伤害值，血量
	 * 
	 * @param owner
	 * @param target
	 * @return
	 */
	protected int getDamageValue(FightUnit owner, FightUnit target) {
		return BattleCalculateHelper.calcSkillHurt(owner, getAttackerAttack(owner, target), target);
	}
	
	/**
	 * 获取攻击力
	 * @param attacker
	 * @return
	 */
	protected int getAttackerAttack(FightUnit attacker, FightUnit defender) {
		//默认是攻击方基础攻击力
		double baseAttack = 0d;
		boolean isDefault = this.getEffectTpl().isDefaultAttack();
		boolean isStrength = this.getEffectTpl().isPhsicalAttack();
		boolean isMagic = this.getEffectTpl().isMagicAttack();
		if(isDefault){
			//默认-取面板攻击
			baseAttack = BattleCalculateHelper.getBaseAttack(attacker);
		}else if(isStrength){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.STRENGTH );
		}else if(isMagic){
			baseAttack = BattleCalculateHelper.getBaseAttackByType(attacker, PetAttackType.INTELLECT );
		}
		return (int)baseAttack;
	}
	
	/**
	 * 是否镶嵌（仙符）类效果
	 * @return
	 */
	public boolean isEmbedEffect() {
		return getEffectTpl().isEmbedSkillEffect();
	}
}