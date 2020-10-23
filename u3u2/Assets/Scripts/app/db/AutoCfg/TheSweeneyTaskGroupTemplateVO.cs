using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 除暴安良任务组模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TheSweeneyTaskGroupTemplateVO : TemplateObject
	{
	/// <summary>
    /// 任务组Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int questGroupId;

	/// <summary>
    /// 任务Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int questId;

	/// <summary>
    /// 权重
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int weight;


}
}