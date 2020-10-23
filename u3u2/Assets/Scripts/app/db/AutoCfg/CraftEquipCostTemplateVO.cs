using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 打造-打造花费
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CraftEquipCostTemplateVO : TemplateObject
	{
	/// <summary>
    /// 装备ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int equipId;

	/// <summary>
    /// 装备类别Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int equipTypeId;

	/// <summary>
    /// 是否可打造（0不可，1可以）
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int canCraftFlag;

	/// <summary>
    /// 装备等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int levelMin;

	/// <summary>
    /// 装备等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int levelMax;

	/// <summary>
    /// 颜色概率-组Id
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int colorGroupId;

	/// <summary>
    /// 花费银票
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int costGold;

	/// <summary>
    /// 消耗道具列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.equip.template.CraftEquipCostItem.class, collectionNumber = "8,9;10,11;12,13")
	public List<CraftEquipCostItem> costItemList;

	/// <summary>
    /// 配方Id
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public int recipeId;

	/// <summary>
    /// 固定属性组Id
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public int fixedAttrGroupId;

	/// <summary>
    /// 材料提升概率组id
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int itemProbGroupId;


}
}