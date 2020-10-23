using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 帮派任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsTaskTemplateVO : TemplateObject
	{
	/// <summary>
    /// 帮派等级
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int corpsLevel;

	/// <summary>
    /// 任务Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int questId;


}
}