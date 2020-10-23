using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 生活技能升级消耗
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillLevelTemplateVO : TemplateObject
	{
	/// <summary>
    /// 技能ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int lifeSkillId;

	/// <summary>
    /// 技能名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;

	/// <summary>
    /// 所需玩家等级
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int needHumanLevel;

	/// <summary>
    /// 技能等级
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int lifeSkillLevel;

	/// <summary>
    /// 升级技能层数熟练度列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost.class, collectionNumber = "5;6;7;8;9;10;11;12")
	public List<HumanSubSkillCost> lifeSkillCostList;

	/// <summary>
    /// 单次可获资源最大值
    /// </summary>
	//@ExcelCellBinding(offset = 13)
	public int maxResNum;

	/// <summary>
    /// 道具Id
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public int itemId;

	/// <summary>
    /// 道具名称
    /// </summary>
	//@ExcelCellBinding(offset = 15)
	public string itemName;

	/// <summary>
    /// 消耗技能书Id
    /// </summary>
	//@ExcelCellBinding(offset = 16)
	public int lifeSkillBookId;

	/// <summary>
    /// 升级描述
    /// </summary>
	//@ExcelCellBinding(offset = 17)
	public string upgradeDes;


}
}