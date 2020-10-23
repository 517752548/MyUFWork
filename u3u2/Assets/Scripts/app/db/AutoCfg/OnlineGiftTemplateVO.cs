using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 在线礼包
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class OnlineGiftTemplateVO : TemplateObject
	{
	/// <summary>
    /// CD
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long cd;

	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int rewardId;

	/// <summary>
    /// 显示的奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int showRewardId;


}
}