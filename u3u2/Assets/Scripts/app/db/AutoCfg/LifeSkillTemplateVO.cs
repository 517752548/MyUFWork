using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 生活技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class LifeSkillTemplateVO : TemplateObject
	{
	/// <summary>
    /// 资源类型
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int resourceType;

	/// <summary>
    /// 技能名称
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string name;


}
}