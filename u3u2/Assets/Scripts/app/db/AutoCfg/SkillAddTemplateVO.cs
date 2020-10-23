using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 技能效果配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillAddTemplateVO : TemplateObject
	{
	/// <summary>
    /// 技能Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int skillId;

	/// <summary>
    /// 心法Id
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int mindId;

	/// <summary>
    /// 心法等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int mindLevelMin;

	/// <summary>
    /// 心法等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int mindLevelMax;

	/// <summary>
    /// 技能等级下限
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int skillLevelMin;

	/// <summary>
    /// 技能等级上限
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int skillLevelMax;

	/// <summary>
    /// 技能效果Id列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "7;8;9;10;11")
	public List<int> effectIdList;


}
}