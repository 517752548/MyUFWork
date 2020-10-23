using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 队伍目标模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TeamTargetTemplateVO : TemplateObject
	{
	/// <summary>
    /// 名称多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long nameLangId;

	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;

	/// <summary>
    /// 最低等级要求
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int levelLimit;

	/// <summary>
    /// 最低人数要求
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int memberNumLimit;

	/// <summary>
    /// 描述多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public long descLangId;

	/// <summary>
    /// 描述
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public string desc;

	/// <summary>
    /// 所属大类名称
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public string typeName;


}
}