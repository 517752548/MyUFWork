using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 敌人组配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MissionEnemyGroupTemplateVO : TemplateObject
	{
	/// <summary>
    /// 敌人列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.mission.template.MissionUnitEnemyTemplate.class, collectionNumber = "2,3;4,5;6,7;8,9;10,11;12,13")
	public List<MissionUnitEnemyTemplate> enemyList;


}
}