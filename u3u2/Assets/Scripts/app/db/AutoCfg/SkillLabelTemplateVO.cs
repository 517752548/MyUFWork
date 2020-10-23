using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 标识配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillLabelTemplateVO : TemplateObject
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
    /// 特效(str)
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public string effect;

	/// <summary>
    /// 特效显示方式(int)1、头上，2、脚下
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int effectShowType;

	/// <summary>
    /// 标记最大叠加数
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int maxLabelNum;


}
}