using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 提升模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PromoteTemplateVO : TemplateObject
	{
	/// <summary>
    /// 提升ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int promoteId;

	/// <summary>
    /// 提升名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string promoteName;


}
}