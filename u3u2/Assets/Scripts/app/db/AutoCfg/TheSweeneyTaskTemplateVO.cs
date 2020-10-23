using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 除暴安良任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TheSweeneyTaskTemplateVO : TemplateObject
	{
	/// <summary>
    /// 主将等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int levelMin;

	/// <summary>
    /// 主将等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int levelMax;

	/// <summary>
    /// 任务组Id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int questGroupId;

	/// <summary>
    /// 特殊奖励
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int specialAwards;


}
}