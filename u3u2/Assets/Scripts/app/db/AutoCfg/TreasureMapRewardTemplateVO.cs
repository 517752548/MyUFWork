using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 藏宝图奖励模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TreasureMapRewardTemplateVO : TemplateObject
	{
	/// <summary>
    /// 道具Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int itemId;

	/// <summary>
    /// 奖励类型
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int triggerType;

	/// <summary>
    /// 根据奖励类型遇怪或者给奖励
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int param;

	/// <summary>
    /// 权重
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int weight;

	/// <summary>
    /// 打怪失败奖励
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int loseReward;


}
}