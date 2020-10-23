using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宠物悟性类别
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPerceptTypeTemplateVO : TemplateObject
	{
	/// <summary>
    /// 物品ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int itemId;

	/// <summary>
    /// 物品数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int itemNum;

	/// <summary>
    /// 货币种类
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int currencyType;

	/// <summary>
    /// 货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int currencyNum;

	/// <summary>
    /// 对应vip功能Id
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int vipFuncId;


}
}