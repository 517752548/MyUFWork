using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 装备位升星
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class UpgradeEquipStarTemplateVO : TemplateObject
	{
	/// <summary>
    /// 基础物品ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int baseItemId;

	/// <summary>
    /// 基础物品数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int baseItemNum;

	/// <summary>
    /// 基本概率
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int baseProb;

	/// <summary>
    /// 额外加成所需物品ID
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int extraItemId;

	/// <summary>
    /// 额外概率加成所需物品数量
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int extraItemNum;

	/// <summary>
    /// 额外概率
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int extraItemProb;

	/// <summary>
    /// 加成百分比
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int scale;

	/// <summary>
    /// 开启等级
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int level;

	/// <summary>
    /// 所需银币
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int coins;


}
}