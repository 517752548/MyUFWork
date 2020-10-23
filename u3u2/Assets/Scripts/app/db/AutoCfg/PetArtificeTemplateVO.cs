using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 炼化
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetArtificeTemplateVO : TemplateObject
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
    /// 开启悟性等级
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int perceptionLevel;

	/// <summary>
    /// 品质下限
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int minQuality;

	/// <summary>
    /// 品质上限
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int maxQuality;

	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public string name;


}
}