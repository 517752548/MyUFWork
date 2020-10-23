using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 技能开格子
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SkillEffectOpenTemplateVO : TemplateObject
	{
	/// <summary>
    /// 所需道具Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int itemTplId;

	/// <summary>
    /// 所需道具数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int itemNum;


}
}