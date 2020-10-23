using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 装备重铸
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipRecastTemplateVO : TemplateObject
	{
	/// <summary>
    /// 是否能够被重铸（1开启，0关闭）
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int isAbleToRecast;

	/// <summary>
    /// 重铸消耗货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int currencyType;

	/// <summary>
    /// 重铸消耗货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int currencyNum;

	/// <summary>
    /// 重铸消耗道具模板ID
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int itemId;

	/// <summary>
    /// 重铸消耗道具数量
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int itemNum;


}
}