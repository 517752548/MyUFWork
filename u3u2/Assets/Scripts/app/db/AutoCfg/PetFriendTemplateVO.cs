using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 伙伴配置表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetFriendTemplateVO : TemplateObject
	{
	/// <summary>
    /// 是否需要解锁，0免费，1需要解锁
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int needUnlock;

	/// <summary>
    /// 解锁方式花费列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "2;3;4")
	public List<int> unlockCostList;


}
}