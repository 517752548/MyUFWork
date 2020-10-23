using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 挂机价值配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EnemyGuaJiValueTemplateVO : TemplateObject
	{
	/// <summary>
    /// 参数描述
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string desc;

	/// <summary>
    /// 价值列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.GuaJiValueItem.class, collectionNumber = "2,3;4,5;6,7;8,9;10,11")
	public List<GuaJiValueItem> valueList;


}
}