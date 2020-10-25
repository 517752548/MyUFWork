package com.imop.lj.gameserver.battle.effect;

import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Identifier;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;

/**
 * 战斗效果接口
 *
 */
public interface IEffect extends Identifier, Comparable<IEffect>, Cloneable{
	/** 效果Id */
	public int getId();
	
	/** 获得可以执行此效果的战斗阶段*/
	public Phase[] getPhases();
	
	/** 获得技能类型*/
	public EffectType getType();
	
	/** 判断此阶段是否可以执行*/
	public boolean isVaild(Phase phase, Object paramObject);
	
	/** 判断此阶段是否可以执行*/
	public boolean isVaild(Phase phase);
	
	/** 执行 */
	public List<ReportItem> execute(Phase phase, Object paramObject);
	
	/** clone*/
	public IEffect clone();
	
	/** 初始化 */
	public void init();
	
	/** 设置战斗效果所属对象*/
	public void setOwner(FightUnit paramT);
	
	/** 获得战斗效果所属对象*/
	public FightUnit getOwner();
	
	/** 获得效果索引*/
	public int getIndex();
	
	/** 获取skillId */
	public int getSkillId();
	
	/** 连击时的skillId,特殊处理
	 * @param actionLogic */
	public int getReportSkillId(Object paramObject);
	
	/** 获取skill等级 */
	public int getSkillLevel();
	
	public void setSkillId(int skillId);
	
	public void setSkillLevel(int skillLevel);
	
	/** 是否buff */
	public boolean isBuff();
	
	/** 是否法术攻击*/
	public boolean isMagicAttack();
	
	public SkillEffectTemplate getEffectTpl();
	
	public boolean isFrom(IEffect fromE);
	
	/** 是否主效果 */
	public boolean isMain();
	public void setMain();
	
	public int getEffectLevel();

	public void setEffectLevel(int effectLevel);
	
	public int getSkillLayer();
	
	public void setSkillLayer(int skillLayer);
	
}
