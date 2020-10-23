using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 每日签到奖励
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class DailySignGiftTemplateVO : TemplateObject
	{
	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int rewardId;

	/// <summary>
    /// 显示的奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int showRewardId;

	/// <summary>
    /// 是否特殊标记
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int isSpecial;

	/// <summary>
    /// vip额外奖励次数
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int vipRewardTimes;

	/// <summary>
    /// 要求vip等级
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int vipLevelLimit;


}
}