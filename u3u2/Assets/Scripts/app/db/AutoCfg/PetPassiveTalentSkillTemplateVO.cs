using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宠物被动天赋技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPassiveTalentSkillTemplateVO : TemplateObject
	{
	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string name;

	/// <summary>
    /// 技能属性列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.pet.template.PassiveTalentPropItem.class, collectionNumber = "2,3,4;5,6,7")
	public List<PassiveTalentPropItem> propList;


}
}