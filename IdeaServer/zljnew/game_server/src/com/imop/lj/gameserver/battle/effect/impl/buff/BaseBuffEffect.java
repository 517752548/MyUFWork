package com.imop.lj.gameserver.battle.effect.impl.buff;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffState;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractEffect;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.IntIdHelper;
import com.imop.lj.gameserver.battle.helper.IntIdHelper.IntIdType;
import com.imop.lj.gameserver.battle.model.RealDamage;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

public class BaseBuffEffect extends AbstractEffect {
	private int id;
	/** buff剩余回合数 */
	private int leftTimes;
	/** 是否持续性buff，如果是，则每回合都执行效果 */
	private boolean continued;
	
	private Double value = 0D;
	
	private List<ReportItem> ret = new ArrayList<ReportItem>();
	
	/** 效果来源者*/
	private FightUnit fromOwner;
	
	public BaseBuffEffect(int effectId) {
		super(effectId, EffectType.BuffSelf, new Phase[] { Phase.ROUND_START, Phase.ROUND_END });
		id = IntIdHelper.genNextIntId(IntIdType.BATTLE_BUFF);
	}
	
	@Override
	public void init() {
		//根据模板初始化一些参数
		leftTimes = getEffectTpl().getBuffRoundNum();
		this.continued = getEffectTpl().isContinuedBuff();
	}
	
	@Override
	protected List<ReportItem> doExecute(Phase phase, Object context) {
		List<ReportItem> result = new ArrayList<ReportItem>();
		if (phase == Phase.ROUND_END) {
			//执行持续性效果
			if (this.isContinued()) {
				List<ReportItem> riList = executeContinuedEffect();
				if (riList != null && !riList.isEmpty()) {
					result.addAll(riList);
				}
			}
			
			//扣减回合次数和增加叠加层数
			result.addAll(reduceTimes(phase));
		}
		
		return result;
	}
	
	private List<ReportItem> reduceTimes(Phase phase) {
		List<ReportItem> result = new ArrayList<ReportItem>();
		if (phase == Phase.ROUND_END) {
			//回合数
			this.leftTimes -= 1;
			if (this.logger.isDebugEnabled()) {
				String message = MessageFormat.format("战斗单位[{0}]的BUFF[{1}]还剩余[{2}]回合,叠加层数是[{3}]层", ((FightUnit) getOwner()).getIdentifier(),
						getIdentifier(), Integer.valueOf(this.leftTimes), Integer.valueOf(this.getOverlapNumByTarget(getOwner())));
	
				this.logger.debug(message);
			}
	
			if (this.leftTimes == 0) {
				result.addAll(doRemove(phase));
			} else {
				result.addAll(decreaseTimes(phase));
			}
		}
		return result;
	}
	
	/**
	 * 附加buff，各个技能效果自身调用
	 * @param target
	 * @param buffValue
	 * @param realDamage
	 * @return
	 */
	public List<ReportItem> addTo(FightUnit target, int buffValue, RealDamage realDamage) {
		List<ReportItem> result = new ArrayList<ReportItem>();
		
		//找需要干掉的effect
		IEffect needRemoveEffect = findNeedRemoveEffect(target);
		
		if (needRemoveEffect != this && needRemoveEffect instanceof BaseBuffEffect) {
			//如果有有冲突的buff,则干掉
			if (needRemoveEffect != null) {
				result.addAll(((BaseBuffEffect)needRemoveEffect).remove());
				
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("移除当前buffId=" + needRemoveEffect.getEffectTpl().getBuffTypeId() + 
							"互斥组=" + needRemoveEffect.getEffectTpl().getBuffMutex() +
							";叠加层数=" + needRemoveEffect.getEffectTpl().getBuffOverlapNum());
				}
			}
			
		}
		
		//加当前这个新的buff
		if(realDamage!= null && realDamage.getRealDamage() != 0){
			result.addAll(doAddTo(target, realDamage.getRealDamage()));
		}else{
			result.addAll(doAddTo(target, buffValue));
		}
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug(getFromOwner().getIdentifier() + "给" + target.getIdentifier() + "加buffId=" + getEffectTpl().getBuffTypeId());
		}
			
		return result;
	}
	
	private IEffect findNeedRemoveEffect(FightUnit target) {
		//XXX 获取当前身上会冲突的状态类buff,优先处理
		IEffect curStatusE = target.getBuffConfictLogic(getEffectTpl());
		if(curStatusE != null){
			return curStatusE;
		}
		
		//身上现有的buff和自己
		IEffect needRemoveEffect = null;
		
		List<IEffect> addEffectList = target.getAddEffectList();
		
		if(addEffectList.isEmpty()){
			return null;
		} 
		
		boolean isOverlapMax = isOverlapMaxNum(target);
		//遍历玩家身上的buff列表
		for (int i = 0; i < addEffectList.size(); i++) {
			IEffect e = addEffectList.get(i);
			
			//跳过非buff效果
			if(!(e instanceof BaseBuffEffect)){
				continue;
			}
			
			if(isSameMutex(e)){
				if (hasHighPriority(e)) {
					needRemoveEffect = e;
				} else {
					needRemoveEffect = this;
				}
			} else {
				//同一来源
				if(isSameOwner(addEffectList.get(i)) && isOverlapMax) {
					needRemoveEffect = e;
				}
			}
			//找到有冲突的buff就退出,因为每次只加一个buff
			if (needRemoveEffect != null) {
				break;
			}
		}
		
		return needRemoveEffect;
	}

	/**
	 * 优先级高
	 * @param curE
	 * @return
	 */
	private boolean hasHighPriority(IEffect curE) {
		return this.getEffectTpl().getEffectLevel() >= curE.getEffectTpl().getEffectLevel();
	}

	/**
	 * 已叠加到最大次数
	 * @param addEffectList
	 * @return
	 */
	private boolean isOverlapMaxNum(FightUnit target) {
		if(getOverlapNumByTarget(target) >= this.effectTpl.getBuffOverlapNum()){
			return true;
		}
		return false;
	}

	/**
	 * 是否是同一互斥组
	 * @param curE
	 * @return
	 */
	private boolean isSameMutex(IEffect curE) {
		//互斥组不填写的话,即不在一个互斥组内
		return this.getEffectTpl().getBuffMutex() > 0 
				? this.getEffectTpl().getBuffMutex() == curE.getEffectTpl().getBuffMutex()
				: false;
	}

	/**
	 * 是否是同一来源
	 * @return
	 */
	private boolean isSameOwner(IEffect curE) {
		if (curE instanceof BaseBuffEffect) {
			if (this.getFromOwner() == ((BaseBuffEffect) curE).getFromOwner()) {
				return true;
			} 
		}
		return false;
	}

	/**
	 * 持续型buf，如每回合恢复生命、每回合恢复怒气 目前只支持生命及怒气
	 * 
	 * @return
	 */
	private List<ReportItem> executeContinuedEffect() {
		FightUnit owner = getOwner();
		int v = this.value.intValue();
		if (v == 0) {
			//效果值为0，则没有战报，即无效果
			Loggers.battleLogger.warn("effect value is 0!eid=" + getId());
			return null;
		}
//		int v = this.value != 0 ? this.value.intValue() : calcBuffAddValue(owner, null);
		ReportItem item = ReportItem.valueOf(owner, this);
		List<ReportItem> extraReport = EffectHelper.alterValue(owner, this, v, item, false);
		List<ReportItem> ret = new ArrayList<ReportItem>();
		ret.add(item);
		if (extraReport != null && !extraReport.isEmpty()) {
			ret.addAll(extraReport);
		}
		return ret;
	}

	public List<ReportItem> remove() {
		List<ReportItem> ret = new ArrayList<ReportItem>();
		FightUnit owner = getOwner();
		owner.remove(this);
		
		List<ReportItem> extraReport = null;
		ReportItem result = ReportItem.valueOf(owner, this);
		if (!isContinued()) {
			//注：值为负数
			Double decValue = -this.value;
			extraReport = EffectHelper.alterValue(owner, this, decValue.intValue(), result, true);
		}
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug(getOwner().getIdentifier() + "的buff移除，buffId=" + getEffectTpl().getBuffTypeId());
		}
		
		Map<Integer, Object> map = new HashMap<Integer, Object>();
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_UUID, getId());
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_ID, getEffectTpl().getBuffTypeId());
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_STATE, BuffState.REMOVE.getIndex());
		result.setBuffMap(map);
		ret.add(result);
		if (extraReport != null && !extraReport.isEmpty()) {
			ret.addAll(extraReport);
		}
		return ret;
	}
	
	protected boolean canAddBuff(FightUnit target) {
		return true;
	}

	private List<ReportItem> doAddTo(FightUnit target, int value) {
		if(!canAddBuff(target)){
			return ret;
		}
		
		ReportItem result = ReportItem.valueOf(target, this);
		
		FightUnit owner = getOwner();
		//这里已经将effect的owner设置为target,目的是效果加到目标后,目标战报的展示(回合数)
		target.addEffect(this);
		List<ReportItem> extraReport = null;
		if (!isContinued()) {
			extraReport = EffectHelper.alterValue(target, this, calcBuffAddValue(target, owner, value), result, true);
		} else {
			//先算好数值放到value上，等到回合结束执行效果时就不算了，因为这里有owner
			this.setValue((double)calcBuffAddValue(target, owner, 0));
		}
		
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("BaseBuffEffect buffId=" + getEffectTpl().getBuffTypeId() + 
					";value=" + this.value + ";effectId=" + getEffectTpl().getId());
		}
		
		Map<Integer, Object> report = new HashMap<Integer, Object>();
		report.put(BattleReportDefine.REPORT_ITEM_BUFF_UUID, getId());
		report.put(BattleReportDefine.REPORT_ITEM_BUFF_ID, getEffectTpl().getBuffTypeId());
		report.put(BattleReportDefine.REPORT_ITEM_BUFF_STATE, BuffState.ADD.getIndex());
		report.put(BattleReportDefine.REPORT_ITEM_BUFF_LEFT, Integer.valueOf(this.leftTimes));
		result.setBuffMap(report);
		ret.add(result);
		if (extraReport != null && !extraReport.isEmpty()) {
			ret.addAll(extraReport);
		}
		return ret;
	}
	
	/**
	 * 计算buff附加的数值
	 * @param target
	 * @param doSkillOwner
	 * @param value
	 * @return
	 */
	protected int calcBuffAddValue(FightUnit target, FightUnit doSkillOwner, int value) {
		//XXX 如果EffectValueType配置的是ALL_DEFENCE或者ALL_DODGY这种的会找不到
		Double base = EffectHelper.getAttrByEffectValueType(target, getEffectTpl().getEffectValueType());
		int f = EffectHelper.calcAddValue(base, (int)getEffectTpl().getValueBase(), getEffectTpl().getValueType());
		//如果未负数，则取负数
		if (getEffectTpl().isNegative()) {
			f = -f;
		}
		return f;
	}
	
	private List<ReportItem> decreaseTimes(Phase phase) {
		Map<Integer, Object> map = new HashMap<Integer, Object>();
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_UUID, getId());
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_ID, getEffectTpl().getBuffTypeId());
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_STATE, BuffState.ING.getIndex());
		map.put(BattleReportDefine.REPORT_ITEM_BUFF_LEFT, Integer.valueOf(this.leftTimes));

		ReportItem item = ReportItem.valueOf(getOwner(), this);
		item.setBuffMap(map);
		
		List<ReportItem> r = new ArrayList<ReportItem>();
		r.add(item);
		return r;
	}

	public final int getId() {
		if (this.id > 0) {
			return this.id;
		}
		return this.hashCode();
	}
	
	private List<ReportItem> doRemove(Phase phase) {
		return remove();
	}

	private boolean isContinued() {
		return this.continued;
	}

	public Double getValue() {
		return this.value;
	}
	
	public void setValue(Double value) {
		this.value = value;
	}

	public int getLeftTimes() {
		return leftTimes;
	}
	
	public int getOverlapNumByTarget(FightUnit target) {
		if(target == null){
			return 0;
		}
		int num = 0;
		if(target.getAddEffectList().isEmpty()){
			return 1;
		}
		
		for (IEffect e : target.getAddEffectList()) {
			if (e instanceof BaseBuffEffect) {
				if(this.effectId == ((BaseBuffEffect)e).effectId){
					num += 1;
				}
			}
		}
		
		return num;
	}
	
	public FightUnit getFromOwner() {
		return fromOwner;
	}

	public void setFromOwner(FightUnit fromOwner) {
		this.fromOwner = fromOwner;
	}

	@Override
	public boolean isBuff() {
		return true;
	}
}
