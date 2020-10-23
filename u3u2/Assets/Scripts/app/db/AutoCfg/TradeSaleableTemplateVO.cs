using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 可交易的物品
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeSaleableTemplateVO : TemplateObject
	{
	/// <summary>
    /// 上架商品模板ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int templateId;

	/// <summary>
    /// 商品类型
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int commodityType;

	/// <summary>
    /// 二级标签
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int subTagId;

	/// <summary>
    /// 有效的(1有效，0无效)
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int isAvailable;


}
}