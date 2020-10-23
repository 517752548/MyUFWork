using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 剧情副本
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PlotDungeonTemplateVO : TemplateObject
	{
	/// <summary>
    /// 剧情副本等级
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int plotDungeonLevel;

	/// <summary>
    /// 是否是精英副本
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int hardFlag;

	/// <summary>
    /// 开启任务id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int triggerQuestId;

	/// <summary>
    /// 怪物组ID
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int enemyArmyId;

	/// <summary>
    /// 打怪显示奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int showEnemyRewardId;

	/// <summary>
    /// 3D模型
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public string model3DId;

	/// <summary>
    /// 显示奖励名字
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public string showRewardName;

	/// <summary>
    /// 章节名称
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public string chapterName;

	/// <summary>
    /// 每日奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int dailyRewardId;

	/// <summary>
    /// 每日显示奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public int showDailyRewardId;


}
}