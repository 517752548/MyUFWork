using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 神秘商店
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MysteryShopItemTemplateVO : TemplateObject
	{
	/// <summary>
    /// 等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int lowerLimit;

	/// <summary>
    /// 等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int upperLimit;

	/// <summary>
    /// 物品模版ID
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int tempId;

	/// <summary>
    /// 数量
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int num;

	/// <summary>
    /// 打折后的价格
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.CurrencyTemplate.class, collectionNumber = "5,6")
	public List<CurrencyTemplate> priceList;

	/// <summary>
    /// 折扣
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int discount;

	/// <summary>
    /// 权重
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int weight;


}
}