package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 效果配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillEffectTemplateVO extends TemplateObject {

	/** 效果类型 */
	@ExcelCellBinding(offset = 1)
	protected int effectTypeId;

	/** buff互斥组 */
	@ExcelCellBinding(offset = 2)
	protected int buffMutex;

	/** buff优先级，用于上buff时替换同类型buff或解buff时 */
	@ExcelCellBinding(offset = 3)
	protected int effectLevel;

	/** buff叠加层数 */
	@ExcelCellBinding(offset = 4)
	protected int buffOverlapNum;

	/** buff类型 */
	@ExcelCellBinding(offset = 5)
	protected int buffTypeId;

	/** buff持续回合数 */
	@ExcelCellBinding(offset = 6)
	protected int buffRoundNum;

	/** 0非持续型，1持续型 */
	@ExcelCellBinding(offset = 7)
	protected int buffContinued;

	/** buff好坏（0中性，1好，2坏） */
	@ExcelCellBinding(offset = 8)
	protected int buffGoodBad;

	/** buff对象存活状态（0活着，1可复活） */
	@ExcelCellBinding(offset = 9)
	protected int buffTargetLiveFlag;

	/** 是否仙符效果（0否，1是） */
	@ExcelCellBinding(offset = 10)
	protected int calcTypeId;

	/** 冷却回合数 */
	@ExcelCellBinding(offset = 11)
	protected int cdRound;

	/** 是否近身，0否，1是 */
	@ExcelCellBinding(offset = 12)
	protected int nearby;

	/** 是否可以选择目标，0否，1是 */
	@ExcelCellBinding(offset = 13)
	protected int targetSelect;

	/** 是否使用自身目标，1是，0否 */
	@ExcelCellBinding(offset = 14)
	protected int targetSelf;

	/** 目标类型 */
	@ExcelCellBinding(offset = 15)
	protected int targetTypeId;

	/** 范围类型 */
	@ExcelCellBinding(offset = 16)
	protected int targetRangeTypeId;

	/** 范围数量 */
	@ExcelCellBinding(offset = 17)
	protected int targetNum;

	/** 效果数值是否为负数 */
	@ExcelCellBinding(offset = 18)
	protected int isNegativeFlag;

	/** 效果数值类型 */
	@ExcelCellBinding(offset = 19)
	protected int effectValueTypeId;

	/** 数值类型 */
	@ExcelCellBinding(offset = 20)
	protected int valueTypeId;

	/** 效果系数 */
	@ExcelCellBinding(offset = 21)
	protected int valueCoef;

	/** 初始数值 */
	@ExcelCellBinding(offset = 22)
	protected long valueBase;

	/** 增量数值 */
	@ExcelCellBinding(offset = 23)
	protected int valueAdd;

	/** 心法系数 */
	@ExcelCellBinding(offset = 24)
	protected int mindCoef;

	/** 附加参数1 */
	@ExcelCellBinding(offset = 25)
	protected int extraCoef1;

	/** 附加参数2 */
	@ExcelCellBinding(offset = 26)
	protected int extraCoef2;

	/** 附加参数3 */
	@ExcelCellBinding(offset = 27)
	protected int extraCoef3;

	/** 附加参数4 */
	@ExcelCellBinding(offset = 28)
	protected int extraCoef4;

	/** 加buff概率（扩大1000倍） */
	@ExcelCellBinding(offset = 29)
	protected int extraCoef5;


	public int getEffectTypeId() {
		return this.effectTypeId;
	}

	public void setEffectTypeId(int effectTypeId) {
		if (effectTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[效果类型]effectTypeId的值不得小于0");
		}
		this.effectTypeId = effectTypeId;
	}
	
	public int getBuffMutex() {
		return this.buffMutex;
	}

	public void setBuffMutex(int buffMutex) {
		if (buffMutex < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[buff互斥组]buffMutex的值不得小于0");
		}
		this.buffMutex = buffMutex;
	}
	
	public int getEffectLevel() {
		return this.effectLevel;
	}

	public void setEffectLevel(int effectLevel) {
		if (effectLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[buff优先级，用于上buff时替换同类型buff或解buff时]effectLevel的值不得小于0");
		}
		this.effectLevel = effectLevel;
	}
	
	public int getBuffOverlapNum() {
		return this.buffOverlapNum;
	}

	public void setBuffOverlapNum(int buffOverlapNum) {
		if (buffOverlapNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[buff叠加层数]buffOverlapNum的值不得小于0");
		}
		this.buffOverlapNum = buffOverlapNum;
	}
	
	public int getBuffTypeId() {
		return this.buffTypeId;
	}

	public void setBuffTypeId(int buffTypeId) {
		if (buffTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[buff类型]buffTypeId的值不得小于0");
		}
		this.buffTypeId = buffTypeId;
	}
	
	public int getBuffRoundNum() {
		return this.buffRoundNum;
	}

	public void setBuffRoundNum(int buffRoundNum) {
		if (buffRoundNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[buff持续回合数]buffRoundNum的值不得小于0");
		}
		this.buffRoundNum = buffRoundNum;
	}
	
	public int getBuffContinued() {
		return this.buffContinued;
	}

	public void setBuffContinued(int buffContinued) {
		if (buffContinued > 1 || buffContinued < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[0非持续型，1持续型]buffContinued的值不合法，应为0至1之间");
		}
		this.buffContinued = buffContinued;
	}
	
	public int getBuffGoodBad() {
		return this.buffGoodBad;
	}

	public void setBuffGoodBad(int buffGoodBad) {
		if (buffGoodBad > 2 || buffGoodBad < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[buff好坏（0中性，1好，2坏）]buffGoodBad的值不合法，应为0至2之间");
		}
		this.buffGoodBad = buffGoodBad;
	}
	
	public int getBuffTargetLiveFlag() {
		return this.buffTargetLiveFlag;
	}

	public void setBuffTargetLiveFlag(int buffTargetLiveFlag) {
		if (buffTargetLiveFlag > 2 || buffTargetLiveFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[buff对象存活状态（0活着，1可复活）]buffTargetLiveFlag的值不合法，应为0至2之间");
		}
		this.buffTargetLiveFlag = buffTargetLiveFlag;
	}
	
	public int getCalcTypeId() {
		return this.calcTypeId;
	}

	public void setCalcTypeId(int calcTypeId) {
		if (calcTypeId > 1 || calcTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[是否仙符效果（0否，1是）]calcTypeId的值不合法，应为0至1之间");
		}
		this.calcTypeId = calcTypeId;
	}
	
	public int getCdRound() {
		return this.cdRound;
	}

	public void setCdRound(int cdRound) {
		if (cdRound < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[冷却回合数]cdRound的值不得小于0");
		}
		this.cdRound = cdRound;
	}
	
	public int getNearby() {
		return this.nearby;
	}

	public void setNearby(int nearby) {
		if (nearby > 1 || nearby < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[是否近身，0否，1是]nearby的值不合法，应为0至1之间");
		}
		this.nearby = nearby;
	}
	
	public int getTargetSelect() {
		return this.targetSelect;
	}

	public void setTargetSelect(int targetSelect) {
		if (targetSelect > 1 || targetSelect < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[是否可以选择目标，0否，1是]targetSelect的值不合法，应为0至1之间");
		}
		this.targetSelect = targetSelect;
	}
	
	public int getTargetSelf() {
		return this.targetSelf;
	}

	public void setTargetSelf(int targetSelf) {
		if (targetSelf > 1 || targetSelf < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[是否使用自身目标，1是，0否]targetSelf的值不合法，应为0至1之间");
		}
		this.targetSelf = targetSelf;
	}
	
	public int getTargetTypeId() {
		return this.targetTypeId;
	}

	public void setTargetTypeId(int targetTypeId) {
		if (targetTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[目标类型]targetTypeId的值不得小于0");
		}
		this.targetTypeId = targetTypeId;
	}
	
	public int getTargetRangeTypeId() {
		return this.targetRangeTypeId;
	}

	public void setTargetRangeTypeId(int targetRangeTypeId) {
		if (targetRangeTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[范围类型]targetRangeTypeId的值不得小于0");
		}
		this.targetRangeTypeId = targetRangeTypeId;
	}
	
	public int getTargetNum() {
		return this.targetNum;
	}

	public void setTargetNum(int targetNum) {
		if (targetNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[范围数量]targetNum的值不得小于0");
		}
		this.targetNum = targetNum;
	}
	
	public int getIsNegativeFlag() {
		return this.isNegativeFlag;
	}

	public void setIsNegativeFlag(int isNegativeFlag) {
		if (isNegativeFlag > 1 || isNegativeFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					19, "[效果数值是否为负数]isNegativeFlag的值不合法，应为0至1之间");
		}
		this.isNegativeFlag = isNegativeFlag;
	}
	
	public int getEffectValueTypeId() {
		return this.effectValueTypeId;
	}

	public void setEffectValueTypeId(int effectValueTypeId) {
		if (effectValueTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					20, "[效果数值类型]effectValueTypeId的值不得小于0");
		}
		this.effectValueTypeId = effectValueTypeId;
	}
	
	public int getValueTypeId() {
		return this.valueTypeId;
	}

	public void setValueTypeId(int valueTypeId) {
		if (valueTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					21, "[数值类型]valueTypeId的值不得小于0");
		}
		this.valueTypeId = valueTypeId;
	}
	
	public int getValueCoef() {
		return this.valueCoef;
	}

	public void setValueCoef(int valueCoef) {
		if (valueCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					22, "[效果系数]valueCoef的值不得小于0");
		}
		this.valueCoef = valueCoef;
	}
	
	public long getValueBase() {
		return this.valueBase;
	}

	public void setValueBase(long valueBase) {
		if (valueBase < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					23, "[初始数值]valueBase的值不得小于0");
		}
		this.valueBase = valueBase;
	}
	
	public int getValueAdd() {
		return this.valueAdd;
	}

	public void setValueAdd(int valueAdd) {
		if (valueAdd < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					24, "[增量数值]valueAdd的值不得小于0");
		}
		this.valueAdd = valueAdd;
	}
	
	public int getMindCoef() {
		return this.mindCoef;
	}

	public void setMindCoef(int mindCoef) {
		if (mindCoef < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					25, "[心法系数]mindCoef的值不得小于0");
		}
		this.mindCoef = mindCoef;
	}
	
	public int getExtraCoef1() {
		return this.extraCoef1;
	}

	public void setExtraCoef1(int extraCoef1) {
		if (extraCoef1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					26, "[附加参数1]extraCoef1的值不得小于0");
		}
		this.extraCoef1 = extraCoef1;
	}
	
	public int getExtraCoef2() {
		return this.extraCoef2;
	}

	public void setExtraCoef2(int extraCoef2) {
		if (extraCoef2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					27, "[附加参数2]extraCoef2的值不得小于0");
		}
		this.extraCoef2 = extraCoef2;
	}
	
	public int getExtraCoef3() {
		return this.extraCoef3;
	}

	public void setExtraCoef3(int extraCoef3) {
		if (extraCoef3 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					28, "[附加参数3]extraCoef3的值不得小于0");
		}
		this.extraCoef3 = extraCoef3;
	}
	
	public int getExtraCoef4() {
		return this.extraCoef4;
	}

	public void setExtraCoef4(int extraCoef4) {
		if (extraCoef4 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					29, "[附加参数4]extraCoef4的值不得小于0");
		}
		this.extraCoef4 = extraCoef4;
	}
	
	public int getExtraCoef5() {
		return this.extraCoef5;
	}

	public void setExtraCoef5(int extraCoef5) {
		if (extraCoef5 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					30, "[加buff概率（扩大1000倍）]extraCoef5的值不得小于0");
		}
		this.extraCoef5 = extraCoef5;
	}
	

	@Override
	public String toString() {
		return "SkillEffectTemplateVO[effectTypeId=" + effectTypeId + ",buffMutex=" + buffMutex + ",effectLevel=" + effectLevel + ",buffOverlapNum=" + buffOverlapNum + ",buffTypeId=" + buffTypeId + ",buffRoundNum=" + buffRoundNum + ",buffContinued=" + buffContinued + ",buffGoodBad=" + buffGoodBad + ",buffTargetLiveFlag=" + buffTargetLiveFlag + ",calcTypeId=" + calcTypeId + ",cdRound=" + cdRound + ",nearby=" + nearby + ",targetSelect=" + targetSelect + ",targetSelf=" + targetSelf + ",targetTypeId=" + targetTypeId + ",targetRangeTypeId=" + targetRangeTypeId + ",targetNum=" + targetNum + ",isNegativeFlag=" + isNegativeFlag + ",effectValueTypeId=" + effectValueTypeId + ",valueTypeId=" + valueTypeId + ",valueCoef=" + valueCoef + ",valueBase=" + valueBase + ",valueAdd=" + valueAdd + ",mindCoef=" + mindCoef + ",extraCoef1=" + extraCoef1 + ",extraCoef2=" + extraCoef2 + ",extraCoef3=" + extraCoef3 + ",extraCoef4=" + extraCoef4 + ",extraCoef5=" + extraCoef5 + ",]";

	}
}