using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 人物技能等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanSubSkillLevelTemplateVO : TemplateObject
	{
	/// <summary>
    /// 技能ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int subSkillId;

	/// <summary>
    /// 技能名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;

	/// <summary>
    /// 技能等级
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int subSkillLevel;

	/// <summary>
    /// 所需心法等级
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int needMainSkillLevel;

	/// <summary>
    /// 所需玩家等级
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int needHumanLevel;

	/// <summary>
    /// 升级技能层数熟练度列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost.class, collectionNumber = "6;7;8;9;10;11;12;13;14;15")
	public List<HumanSubSkillCost> humanSubSkillCostList;

	/// <summary>
    /// 消耗技能书Id
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int subSkillBookId;


}
}