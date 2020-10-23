using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 生活技能-采矿-消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillMineCostTemplateVO : TemplateObject
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

	/// <summary>
    /// 消耗时间/小时
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int costTime;


}
}