using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 月卡模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MonthCardTemplateVO : TemplateObject
	{
	/// <summary>
    /// 月卡货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int monthCurrId;

	/// <summary>
    /// 月卡货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int monthCurrNum;

	/// <summary>
    /// 立返货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int rebateCurrId;

	/// <summary>
    /// 立返货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int rebateCurrNum;

	/// <summary>
    /// 每日返利货币类型
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int dayRebateCurrId;

	/// <summary>
    /// 每日返利货币数量
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int dayRebateCurrNum;


}
}