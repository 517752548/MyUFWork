using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 变异
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetVariationTemplateVO : TemplateObject
	{
	/// <summary>
    /// 消耗物品ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int itemId;

	/// <summary>
    /// 消耗物品数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int itemNum;

	/// <summary>
    /// 消耗金币
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int currencyNum;

	/// <summary>
    /// 货币种类
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int currencyType;

	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public string name;


}
}