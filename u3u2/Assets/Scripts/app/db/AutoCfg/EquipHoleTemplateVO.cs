using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 装备孔数
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipHoleTemplateVO : TemplateObject
	{
	/// <summary>
    /// 装备颜色
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int colorId;

	/// <summary>
    /// 装备等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int levelMin;

	/// <summary>
    /// 装备等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int levelMax;

	/// <summary>
    /// 最大孔数
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int maxHoleNum;


}
}