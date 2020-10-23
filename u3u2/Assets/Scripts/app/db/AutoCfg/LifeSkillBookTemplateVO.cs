using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 生活技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillBookTemplateVO : ItemTemplate
	{
	/// <summary>
    /// 职业要求
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int jobLimit;

	/// <summary>
    /// 技能ID
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int skillId;


}
}