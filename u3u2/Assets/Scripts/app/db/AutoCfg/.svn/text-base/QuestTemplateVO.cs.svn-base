using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 任务模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class QuestTemplateVO : TemplateObject
	{
	/// <summary>
    ///  标题多语言 Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long titleLangId;

	/// <summary>
    /// 标题
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string title;

	/// <summary>
    /// 任务主类型（区分主线和日常）
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int questType;

	/// <summary>
    /// 是否是重复任务
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public bool repeat;

	/// <summary>
    /// 每日完成的次数
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int dailyTimes;

	/// <summary>
    /// 必须完成的前置任务ID
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int preQuestId;

	/// <summary>
    /// 等级限制
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int acceptMinLevel;

	/// <summary>
    /// 要求组队最少人数，0表示不需要组队
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int minTeamMemberNum;

	/// <summary>
    /// 接任务的特殊任务条件
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.task.template.SpecialCondition.class, collectionNumber = "9,10,11;12,13,14")
	public List<SpecialCondition> specialCondition;

	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public int rewardId;

	/// <summary>
    /// 显示奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int showRewardId;

	/// <summary>
    /// 任务描述
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public string desc;

	/// <summary>
    ///  任务完成npc说话内容多语言 Id
    /// </summary>
	//@ExcelCellBinding(offset = 18)
	public long finishNpcTalkDescLangId;

	/// <summary>
    /// 任务完成npc说话内容
    /// </summary>
	//@ExcelCellBinding(offset = 19)
	public string finishNpcTalkDesc;

	/// <summary>
    ///  开启的条件描述多语言 Id
    /// </summary>
	//@ExcelCellBinding(offset = 20)
	public long requireDescLangId;

	/// <summary>
    /// 开启的条件描述
    /// </summary>
	//@ExcelCellBinding(offset = 21)
	public string requireDesc;

	/// <summary>
    ///  任务完成信息多语言 Id
    /// </summary>
	//@ExcelCellBinding(offset = 22)
	public long finishDescLangId;

	/// <summary>
    /// 任务完成信息
    /// </summary>
	//@ExcelCellBinding(offset = 23)
	public string finishDesc;

	/// <summary>
    /// 接取任务NPC地图Id
    /// </summary>
	//@ExcelCellBinding(offset = 24)
	public int startNpcMapId;

	/// <summary>
    /// 接取任务NPC
    /// </summary>
	//@ExcelCellBinding(offset = 25)
	public int startNpc;

	/// <summary>
    /// 交付任务NPC地图ID
    /// </summary>
	//@ExcelCellBinding(offset = 26)
	public int endNpcMapId;

	/// <summary>
    /// 交付任务NPC
    /// </summary>
	//@ExcelCellBinding(offset = 27)
	public int endNpc;

	/// <summary>
    /// 是否自动接取
    /// </summary>
	//@ExcelCellBinding(offset = 28)
	public int autoAccept;

	/// <summary>
    /// 是否自动完成
    /// </summary>
	//@ExcelCellBinding(offset = 29)
	public int autoFinish;

	/// <summary>
    /// 剧情id
    /// </summary>
	//@ExcelCellBinding(offset = 30)
	public int storyId;

	/// <summary>
    /// 动画剧情Id
    /// </summary>
	//@ExcelCellBinding(offset = 31)
	public int videoStoryId;

	/// <summary>
    /// 寻路字符串
    /// </summary>
	//@ExcelCellBinding(offset = 32)
	public string pathStr;

	/// <summary>
    /// 特殊任务目标
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.task.template.SpecialDestination.class, collectionNumber = "33,34,35,36,37,38")
	public List<SpecialDestination> specialDestination;

	/// <summary>
    /// 条件奖励ID
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "39;40;41;42;43;44;45;46")
	public List<int> rewardIdOnCondition;

	/// <summary>
    /// 任务怪IdList
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "47;48;49;50;51")
	public List<int> enemyArmyIdList;

	/// <summary>
    /// 任务物品掉落奖励
    /// </summary>
	//@ExcelCellBinding(offset = 52)
	public int taskDropRewardId;


}
}