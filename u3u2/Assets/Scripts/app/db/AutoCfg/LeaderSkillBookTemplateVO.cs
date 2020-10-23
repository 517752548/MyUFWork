using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 人物技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LeaderSkillBookTemplateVO : ItemTemplate
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