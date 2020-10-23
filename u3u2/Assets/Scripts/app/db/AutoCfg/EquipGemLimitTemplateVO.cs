using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 镶嵌宝石限制
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipGemLimitTemplateVO : TemplateObject
	{
	/// <summary>
    /// 装备部位Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int posId;

	/// <summary>
    /// 可镶嵌宝石Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int gemItemId;


}
}