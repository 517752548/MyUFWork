using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 绿野仙踪-副本配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WizardRaidTemplateVO : TemplateObject
	{
	/// <summary>
    /// 单人或组队（1单人，2组队）
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int raidTypeId;

	/// <summary>
    /// 副本等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int levelMin;

	/// <summary>
    /// 副本等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int levelMax;

	/// <summary>
    /// 南瓜怪NpcID
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int pumpkinNpcId;

	/// <summary>
    /// BOSSNpcID
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "5;6;7")
	public List<int> bossNpcIdList;

	/// <summary>
    /// BOSS奖励Id
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "8;9;10")
	public List<int> bossRewardIdList;

	/// <summary>
    /// 活动奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public int rewardId;


}
}