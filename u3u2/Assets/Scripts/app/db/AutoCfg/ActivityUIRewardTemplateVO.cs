using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 活动UI奖励模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ActivityUIRewardTemplateVO : TemplateObject
	{
	/// <summary>
    ///  奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int rewardId;

	/// <summary>
    ///  显示奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int showRewardId;


}
}