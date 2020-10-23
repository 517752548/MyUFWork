using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 效果配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectTemplateVO : TemplateObject
	{
	/// <summary>
    /// 效果类型
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int effectTypeId;

	/// <summary>
    /// buff互斥组
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int buffMutex;

	/// <summary>
    /// buff优先级，用于上buff时替换同类型buff或解buff时
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int effectLevel;

	/// <summary>
    /// 同一个互斥组内的效果权重
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int effectWeight;

	/// <summary>
    /// 同一个互斥组内的效果分组
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int effectGroupId;

	/// <summary>
    /// buff叠加层数
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int buffOverlapNum;

	/// <summary>
    /// buff类型
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int buffTypeId;

	/// <summary>
    /// buff持续回合数
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int buffRoundNum;

	/// <summary>
    /// 0非持续型，1持续型
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int buffContinued;

	/// <summary>
    /// buff好坏（0中性，1好，2坏）
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public int buffGoodBad;

	/// <summary>
    /// buff对象存活状态（0活着，1可复活）
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public int buffTargetLiveFlag;

	/// <summary>
    /// 是否仙符效果（0否，1是）
    /// </summary>
	//@ExcelCellBinding(offset = 12)
	public int calcTypeId;

	/// <summary>
    /// 冷却回合数
    /// </summary>
	//@ExcelCellBinding(offset = 13)
	public int cdRound;

	/// <summary>
    /// 是否近身，0否，1是
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public int nearby;

	/// <summary>
    /// 是否可以选择目标，0否，1是
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public int targetSelect;

	/// <summary>
    /// 是否使用自身目标，1是，0否
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int targetSelf;

	/// <summary>
    /// 目标类型
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public int targetTypeId;

	/// <summary>
    /// 范围类型
    /// </summary>
	//@ExcelCellBinding(offset = 18)
	public int targetRangeTypeId;

	/// <summary>
    /// 范围数量
    /// </summary>
	//@ExcelCellBinding(offset = 19)
	public int targetNum;

	/// <summary>
    /// 效果数值是否为负数
    /// </summary>
	//@ExcelCellBinding(offset = 20)
	public int isNegativeFlag;

	/// <summary>
    /// 效果数值类型
    /// </summary>
	//@ExcelCellBinding(offset = 21)
	public int effectValueTypeId;

	/// <summary>
    /// 数值类型
    /// </summary>
	//@ExcelCellBinding(offset = 22)
	public int valueTypeId;

	/// <summary>
    /// 效果系数
    /// </summary>
	//@ExcelCellBinding(offset = 23)
	public int valueCoef;

	/// <summary>
    /// 初始数值
    /// </summary>
	//@ExcelCellBinding(offset = 24)
	public long valueBase;

	/// <summary>
    /// 增量数值
    /// </summary>
	//@ExcelCellBinding(offset = 25)
	public int valueAdd;

	/// <summary>
    /// 心法系数
    /// </summary>
	//@ExcelCellBinding(offset = 26)
	public int mindCoef;

	/// <summary>
    /// 附加参数1
    /// </summary>
	//@ExcelCellBinding(offset = 27)
	public int extraCoef1;

	/// <summary>
    /// 附加参数2
    /// </summary>
	//@ExcelCellBinding(offset = 28)
	public int extraCoef2;

	/// <summary>
    /// 附加参数3
    /// </summary>
	//@ExcelCellBinding(offset = 29)
	public int extraCoef3;

	/// <summary>
    /// 附加参数4
    /// </summary>
	//@ExcelCellBinding(offset = 30)
	public int extraCoef4;

	/// <summary>
    /// 加buff概率（扩大1000倍）
    /// </summary>
	//@ExcelCellBinding(offset = 31)
	public int extraCoef5;

	/// <summary>
    /// 读取物理攻击力还是法术攻击力(0默认,1物理,2法术)
    /// </summary>
	//@ExcelCellBinding(offset = 32)
	public int attackTypeId;

	/// <summary>
    /// 层数效果数值列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "33;34;35;36;37;38;39;40;41;42")
	public List<int> skillLayerEffectList;


}
}