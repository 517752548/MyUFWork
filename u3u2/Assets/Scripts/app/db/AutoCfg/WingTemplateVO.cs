using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 翅膀
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class WingTemplateVO : TemplateObject
	{
	/// <summary>
    /// 翅膀名称
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string wingName;

	/// <summary>
    /// 翅膀图标
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string icon;

	/// <summary>
    /// 美术Id
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public string modelId;

	/// <summary>
    /// 品质ID
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int rarityId;

	/// <summary>
    /// 技能属性列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.pet.template.PassiveTalentPropItem.class, collectionNumber = "5,6,7;8,9,10;11,12,13;14,15,16;17,18,19;20,21,22")
	public List<PassiveTalentPropItem> propList;


}
}