using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 仙符道具
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectItemTemplateVO : ItemTemplate
	{
	/// <summary>
    /// 技能效果ID
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int skillEffectId;

	/// <summary>
    /// 初始经验
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int initExp;

	/// <summary>
    /// 等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 40)
	public int levelMax;

	/// <summary>
    /// 镶嵌类型（同一类型的不能同时在一个技能上）
    /// </summary>
	//@ExcelCellBinding(offset = 41)
	public int embedType;

	/// <summary>
    /// 是否稀有（稀有的一个技能只能有一个）
    /// </summary>
	//@ExcelCellBinding(offset = 42)
	public int uniqueFlag;


}
}