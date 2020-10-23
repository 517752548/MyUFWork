using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 活动UI模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ActivityUITemplateVO : TemplateObject
	{
	/// <summary>
    /// 活动计数ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int behaviorId;

	/// <summary>
    /// 活动名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;

	/// <summary>
    ///  奖励的活力值(单次)
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int energyNumPerTime;

	/// <summary>
    ///  奖励的活跃度(单次)
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int activityNumPerTime;

	/// <summary>
    ///  可以获得活力值的次数
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int activityTotalTime;

	/// <summary>
    ///  活动对应功能Id
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int funcId;

	/// <summary>
    ///  定时任务Id
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int activityTimeEventId;

	/// <summary>
    ///  参与推荐随机
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int participateRecommendRandom;

	/// <summary>
    ///  参加活动的超链接
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public string hyperlink;

	/// <summary>
    ///  活动时间说明
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public string activityTimeDesc;

	/// <summary>
    ///  开始时间
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public string startTimeDesc;

	/// <summary>
    ///  任务形式
    /// </summary>
	//@ExcelCellBinding(offset = 12)
	public string taskMemberDesc;

	/// <summary>
    ///  活动描述
    /// </summary>
	//@ExcelCellBinding(offset = 13)
	public string desc;

	/// <summary>
    ///  任务奖励展示
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public int showRewardId;

	/// <summary>
    ///  活动图标
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public string icon;

	/// <summary>
    ///  限时活动Id
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int timeLimitActivityId;

	/// <summary>
    ///  活动角标
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public string superScript;

	/// <summary>
    ///  活动开启条件描述
    /// </summary>
	//@ExcelCellBinding(offset = 18)
	public string openConditionDesc;


}
}