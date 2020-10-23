using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 商城普通物品配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MallNormalItemTemplateVO : TemplateObject
	{
	/// <summary>
    /// 是否下架（0否，1是）
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int notSale;

	/// <summary>
    /// 排序ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int sortId;

	/// <summary>
    /// 商城物品
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.ItemCostTemplate.class, collectionNumber = "3,4")
	public List<ItemCostTemplate> normalItemList;

	/// <summary>
    /// 目录
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int catalogId;

	/// <summary>
    /// 是否热销
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public bool sellWell;

	/// <summary>
    /// 购买价格
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.CurrencyTemplate.class, collectionNumber = "7,8;9,10")
	public List<CurrencyTemplate> priceList;

	/// <summary>
    /// 兑换所需物品
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.ItemCostTemplate.class, collectionNumber = "11,12;13,14")
	public List<ItemCostTemplate> exchangeItemList;

	/// <summary>
    /// 各种标识
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public string marks;

	/// <summary>
    /// 二级标签
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int subTag;


}
}