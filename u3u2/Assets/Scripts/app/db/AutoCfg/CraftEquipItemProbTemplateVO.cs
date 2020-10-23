using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 打造-材料提升概率
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class CraftEquipItemProbTemplateVO : TemplateObject
	{
	/// <summary>
    /// 材料提升概率组id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int groupId;

	/// <summary>
    /// 阶数Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int gradeId;

	/// <summary>
    /// 影响概率值
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "3;4;5;6;7")
	public List<int> propList;

	/// <summary>
    /// 材料最大数量
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int maxNum;


}
}