using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 生活技能-采矿-等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMineLevelTemplateVO : TemplateObject
	{
	/// <summary>
    /// 消耗货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int currencyType;

	/// <summary>
    /// 消耗货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int currencyNum;


}
}