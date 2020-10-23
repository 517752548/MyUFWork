using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宠物技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetSkillBookItemTemplateVO : ItemTemplate
	{
	/// <summary>
    /// 技能ID
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int skillTplId;

	/// <summary>
    /// 技能书等级
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int bookLevel;


}
}