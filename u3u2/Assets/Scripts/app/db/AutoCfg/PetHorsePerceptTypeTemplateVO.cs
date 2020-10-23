using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 骑宠悟性类别
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePerceptTypeTemplateVO : TemplateObject
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


}
}