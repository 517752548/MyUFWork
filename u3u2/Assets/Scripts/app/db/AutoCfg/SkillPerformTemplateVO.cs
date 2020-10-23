using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 技能表现
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillPerformTemplateVO : TemplateObject
	{
	/// <summary>
    /// 技能组合Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string composeId;

	/// <summary>
    /// 技能Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string skillId;

	/// <summary>
    /// 效果Id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int effectId;

	/// <summary>
    /// 技能表现说明
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public string desc;

	/// <summary>
    /// 技能动作id
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public string actionId;

	/// <summary>
    /// 技能动作类型(1投掷子弹，2射击子弹，3平推子弹，4其它，5冲锋)
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int actionType;

	/// <summary>
    /// 是否近身攻击（1是，0否）
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int isNearAttack;

	/// <summary>
    /// 技能影响开始的时间（秒）
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public float impactStartTime;

	/// <summary>
    /// 技能影响的次数
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int impactTimes;

	/// <summary>
    /// 技能影响的时间间隔（秒）
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public float impactInterval;

	/// <summary>
    /// 动作完成后除子弹外的特效延迟几秒完成
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public float effectStopDelayTime;

	/// <summary>
    /// 技能特效项列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.skill.template.SkillPerformEffectItemTemplate.class, collectionNumber = "12,13,14,15,16,17;18,19,20,21,22,23;24,25,26,27,28,29")
	public List<SkillPerformEffectItemTemplate> effectItemList;

	/// <summary>
    /// 受击特效
    /// </summary>
	//@ExcelCellBinding(offset = 30)
	public string blowEffectId;

	/// <summary>
    /// 被击特效出现位置（1头顶，2胸口，3脚下）
    /// </summary>
	//@ExcelCellBinding(offset = 31)
	public int blowEffectPosId;

	/// <summary>
    /// 技能音效项列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.skill.template.SkillPerformSoundItemTemplate.class, collectionNumber = "32,33,34;35,36,37;38,39,40")
	public List<SkillPerformSoundItemTemplate> soundItemList;

	/// <summary>
    /// 总时长（秒）
    /// </summary>
	//@ExcelCellBinding(offset = 41)
	public float totalTime;


}
}