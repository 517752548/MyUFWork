package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectValueType;
import com.imop.lj.gameserver.battle.core.BattleDef.RangeType;
import com.imop.lj.gameserver.battle.core.BattleDef.TargetType;
import com.imop.lj.gameserver.battle.core.BattleDef.ValueType;
import com.imop.lj.gameserver.battle.helper.EffectHelper;


/**
 * 效果配置
 * 
 */
@ExcelRowBinding
public class SkillEffectTemplate extends SkillEffectTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//效果类型是否存在
		if (getEffectType() == null) {
			throw new TemplateConfigException(sheetName, id, "效果不存在！" + this.effectTypeId);
		}
		
		//检查当类型为加buff时，buffTypeId必须存在
		switch (getEffectType()) {
		case AddBuff:
		case AddBuffParam:
		case AddBuffFromAllAttack:
			if (getBuffTypeId() <= 0) {
				throw new TemplateConfigException(sheetName, id, "加buff但buff类型不存在！");
			}

			if (getEffectValueType() == null) {
				throw new TemplateConfigException(sheetName, id, "加buff但效果数值类型不存在！");
			}
			
			break;
		case PetTalentMain:
//			//攻击类型检查
//			if (PetDef.PetAttackType.valueOf(getExtraCoef1()) == null) {
//				throw new TemplateConfigException(sheetName, id, "附加参数1 攻击类型不存在！" + getExtraCoef1());
//			}
			break;
		case Fumo3Main :
			if(getExtraCoef1() < 0 || getExtraCoef1() > 2){
				throw new TemplateConfigException(sheetName, id, "损失生命公式数值错误,此列代表正负,0-正数,1-负数！");
			}
			break;
		default:
			break;
		}
		//检查buff类型是否存在
		if (getBuffTypeId() > 0) {
			SkillBuffTemplate buffTpl = templateService.get(getBuffTypeId(), SkillBuffTemplate.class); 
			if (null == buffTpl) {
				throw new TemplateConfigException(sheetName, id, "buff类型不存在！");
			}
			//回合数是否合法
			if (getBuffRoundNum() <= 0) {
				throw new TemplateConfigException(sheetName, id, "buff持续回合数非法！" + this.buffRoundNum);
			}
//			//攻击类型检查
//			if (buffTpl.getBuffCatalog() == BuffCatalog.PET_TALENT_1) {
//				if (PetDef.PetAttackType.valueOf(getExtraCoef1()) == null) {
//					throw new TemplateConfigException(sheetName, id, "buff公式类型对应的附加参数1 攻击类型不存在！" + getExtraCoef1());
//				}
//			}
			if (buffTpl.getBuffCatalog() == BuffCatalog.PARAM_1) {
				if (EffectValueType.valueOf(getExtraCoef3()) == null) {
					throw new TemplateConfigException(sheetName, id, "buff数值的附加参数3 类型不存在！" + getExtraCoef3());
				}
			}
			//该类型的buff需要用到 数值类型 计算，不能为空
			if (buffTpl.getBuffCatalog() != null) {
				if (getValueType() == null) {
					throw new TemplateConfigException(sheetName, id, "该类型的buff需要用到 数值类型 计算，不能为空！" + this.getValueTypeId());
				}
				if(getEffectValueType() == null){
					throw new TemplateConfigException(sheetName, id, "该类型的buff需要用到 效果数值类型 计算，不能为空！" + this.getValueTypeId());
				}
			}
			
			
			//buff的互斥组和叠加层数不可同时为0
			if(getBuffMutex() <= 0 && getBuffOverlapNum() <= 0){
				throw new TemplateConfigException(sheetName, id, "buff的互斥组和叠加层数不可同时为0");
			}
			//如果buff有互斥组,那么优先级必须填写
			if(getBuffMutex() > 0){
				if(getEffectLevel() <= 0){
					throw new TemplateConfigException(sheetName, id, "buff有互斥组,那么优先级必须填写");
				}
			}
			
			//buff叠加层数 不能超过buff持续回合数
			if(getBuffOverlapNum() > getBuffRoundNum()){
				throw new TemplateConfigException(sheetName, id, "效果叠加层数值不能超过持续回合数！" + this.buffOverlapNum);
			}
			
		}
		
		//加buff概率不能为0
		if (getEffectType() == EffectType.AddBuff || getEffectType() == EffectType.AddBuffFromAllAttack) {
			if (getExtraCoef5() <= 0) {
				throw new TemplateConfigException(sheetName, id, "加buff概率不能为0！");
			}
		}
		
		//一些buff不能是持续类型的
		if (isContinuedBuff()) {
			if (getEffectValueType() == EffectValueType.STATUS || 
					getEffectValueType() == EffectValueType.HURT_SHIELD) {
				throw new TemplateConfigException(sheetName, id, "状态类buff|伤害吸收盾buff不能是持续类型的！");
			}
		} else {
			//减血的buff不能是非持续性的
			if (getBuffTypeId() > 0 && isNegative() && getEffectValueType() == EffectValueType.HP) {
				throw new TemplateConfigException(sheetName, id, "减血的buff必须是持续性的！");
			}
		}
		
		//状态值必须是2的n次方的数，n>=1
		if (getEffectValueType() == EffectValueType.STATUS) {
			String a = Long.toBinaryString(getValueBase());
			if (a.split("1").length != 2) {
				throw new TemplateConfigException(sheetName, id, "状态类buff所加状态值非法！");
			}
		}
		
		//可选择目标的必须使用自身目标
		if (isTargetSelect() && !isTargetSelf()) {
			throw new TemplateConfigException(sheetName, id, "可选择目标的必须使用自身目标！");
		}
		
		//目标类型是否存在
		if (this.targetTypeId > 0) {
			if (getTargetType() == null) {
				throw new TemplateConfigException(sheetName, id, "目标类型不存在！" + this.targetTypeId);
			}
		}
		//范围类型是否存在
		if (this.targetRangeTypeId > 0) {
			if (getRangeType() == null) {
				throw new TemplateConfigException(sheetName, id, "范围类型不存在！" + this.targetRangeTypeId);
			}
		}
		
		//如果使用自身目标，则必须有目标类型
		if (isTargetSelf()) {
			if (this.targetTypeId <= 0) {
				throw new TemplateConfigException(sheetName, id, "目标类型不存在！" + this.targetTypeId);
			}
			//目标类型是如下几种，则必须有范围类型
			switch (getTargetType()) {
			case ENEMY:
			case OUR:
			case OUR_DEAD:
			case OUR_ALL:
				if (this.targetRangeTypeId <= 0) {
					throw new TemplateConfigException(sheetName, id, "该目标类型必须选择范围类型！" + this.targetRangeTypeId);
				}
				//以下范围类型，必须指定范围数量
				switch (getRangeType()) {
				case RANDOM:
					if (this.targetNum <= 0) {
						throw new TemplateConfigException(sheetName, id, "范围数量非法！" + this.targetNum);
					}
					break;

				default:
					break;
				}
				
				default:
					break;
			}
		}
		
		if (this.effectValueTypeId > 0) {
			if (null == getEffectValueType()) {
				throw new TemplateConfigException(sheetName, id, "效果数值类型非法！" + this.effectValueTypeId);
			}
		}
		if (this.valueTypeId > 0) {
			if (null == getValueType()) {
				throw new TemplateConfigException(sheetName, id, "数值类型非法！" + this.valueTypeId);
			}
		}
		
		//按公式计算目标人数的，附加参数1为人数上限，不能小于1
		if (getEffectType() == EffectType.Fumo2Main) {
			if (EffectHelper.int2Double(getExtraCoef1()) < 1) {
				throw new TemplateConfigException(sheetName, id, "目标人数上限不能小于1！" + getExtraCoef1());
			}
		}
		
		
		
	}
	
	public EffectType getEffectType() {
		return EffectType.valueOf(this.getEffectTypeId());
	}
	
	public TargetType getTargetType() {
		return TargetType.valueOf(this.getTargetTypeId());
	}
	
	public RangeType getRangeType() {
		return RangeType.valueOf(this.getTargetRangeTypeId());
	}
	
	public EffectValueType getEffectValueType() {
		return EffectValueType.valueOf(this.getEffectValueTypeId());
	}
	
	public ValueType getValueType() {
		return ValueType.valueOf(this.getValueTypeId());
	}
	
	public boolean isContinuedBuff() {
		return this.getBuffContinued() == 1;
	}
	
	/**
	 * 是否使用自身的目标
	 * @return
	 */
	public boolean isTargetSelf() {
		return this.getTargetSelf() == 1;
	}
	
	/**
	 * 是否可以选择目标
	 * @return
	 */
	public boolean isTargetSelect() {
		return this.getTargetSelect() == 1;
	}
	
	/**
	 * 是否近身
	 * @return
	 */
	public boolean isNearby(){
		return this.getNearby() == 1;
	}
	
	/**
	 * 效果数值是否为负数
	 * @return
	 */
	public boolean isNegative() {
		return this.getIsNegativeFlag() == 1;
	}
	
	public boolean isNeutral() {
		return this.getBuffGoodBad() == 0;
	}
	
	public boolean isGood() {
		return this.getBuffGoodBad() == 1;
	}
	
	public boolean isBad() {
		return this.getBuffGoodBad() == 2;
	}
	
	/**
	 * buff目标是否可复活对象
	 * @return
	 */
	public boolean isBuffTargetRevive() {
		return this.getBuffTargetLiveFlag() == 1;
	}
	
	/**
	 * 是否镶嵌（仙符）类效果
	 * @return
	 */
	public boolean isEmbedSkillEffect() {
		return this.getCalcTypeId() == 1;
	}
	
	/**
	 * 默认类型攻击力
	 * @return
	 */
	public boolean isDefaultAttack(){
		return this.getAttackTypeId() == 0;
	}
	/**
	 * 是否物理攻击力
	 * @return
	 */
	public boolean isPhsicalAttack(){
		return this.getAttackTypeId() == 1;
	}
	/**
	 * 是否法术攻击力
	 * @return
	 */
	public boolean isMagicAttack(){
		return this.getAttackTypeId() == 2;
	}
}
