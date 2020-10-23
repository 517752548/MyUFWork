using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 怪物组表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyArmyTemplateVO : TemplateObject
	{
	/// <summary>
    /// 名称多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long nameLangId;

	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;

	/// <summary>
    /// 敌人Id列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.EnemyProbTemplate.class, collectionNumber = "3,4;5,6;7,8;9,10;11,12;13,14;15,16;17,18;19,20;21,22")
	public List<EnemyProbTemplate> enemyIdAndProbList;

	/// <summary>
    /// 胜利奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 23)
	public int rewardId;

	/// <summary>
    /// 扣除双倍点
    /// </summary>
	//@ExcelCellBinding(offset = 24)
	public int doublePointCost;

	/// <summary>
    /// 是否是通天塔
    /// </summary>
	//@ExcelCellBinding(offset = 25)
	public int isTower;


}
}