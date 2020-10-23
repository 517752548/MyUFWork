using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 辅助技能消耗配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CorpsAssistCostTemplateVO : TemplateObject
	{
	/// <summary>
    /// 当前辅助技能等级
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int assistLevel;

	/// <summary>
    /// 需求玩家等级
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int playerLevel;

	/// <summary>
    /// 需求帮派等级
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int corpsLevel;

	/// <summary>
    /// 需求侍剑堂等级
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int sjLevel;

	/// <summary>
    /// 升级消耗银票
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int costCurrency;

	/// <summary>
    /// 修炼1次消耗帮贡
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int costContri;


}
}