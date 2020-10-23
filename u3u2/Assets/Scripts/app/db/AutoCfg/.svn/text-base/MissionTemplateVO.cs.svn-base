using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 关卡配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MissionTemplateVO : TemplateObject
	{
	/// <summary>
    /// 地形Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string mapId;

	/// <summary>
    /// 出生点
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public string bornPos;

	/// <summary>
    /// 背景音乐
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public string music;

	/// <summary>
    /// 是否boss
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int isBoss;

	/// <summary>
    /// 奖励Id
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int missionPrizeId;

	/// <summary>
    /// 敌人组id、位置、出场顺序、出场延迟（秒）的列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.mission.template.MissionUnitTemplate.class, collectionNumber = "7,8,9,10;11,12,13,14;15,16,17,18;19,20,21,22;23,24,25,26")
	public List<MissionUnitTemplate> enemyGroupList;


}
}