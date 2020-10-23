using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 翅膀升阶消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WingUpgradeTemplateVO : TemplateObject
	{
	/// <summary>
    /// 翅膀模板id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int wingTplId;

	/// <summary>
    /// 翅膀阶数
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int wingLevel;

	/// <summary>
    /// 道具id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int itemId;

	/// <summary>
    /// 道具数量
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int itemNum;

	/// <summary>
    /// 货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int currencyType;

	/// <summary>
    /// 货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int currencyNum;

	/// <summary>
    /// 升阶概率
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int upgradeProp;

	/// <summary>
    /// 祝福满值
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int blessMaxValue;


}
}