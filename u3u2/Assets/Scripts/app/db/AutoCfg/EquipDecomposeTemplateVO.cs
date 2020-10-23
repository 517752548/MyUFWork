using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 装备分解
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipDecomposeTemplateVO : TemplateObject
	{
	/// <summary>
    /// 装备颜色
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int color;

	/// <summary>
    /// 等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int lowLevel;

	/// <summary>
    /// 等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int hightLevel;

	/// <summary>
    /// 消耗货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int currencyType;

	/// <summary>
    /// 消耗货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int currencyNum;

	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int rewardId;

	/// <summary>
    /// 是否有效
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int isAvailable;


}
}