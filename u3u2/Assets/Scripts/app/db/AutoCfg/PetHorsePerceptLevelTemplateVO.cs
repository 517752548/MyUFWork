using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 骑宠悟性等级
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetHorsePerceptLevelTemplateVO : TemplateObject
	{
	/// <summary>
    /// 悟性经验值
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long perceptExp;

	/// <summary>
    /// 属性附加属性比例
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int addtionAttr;

	/// <summary>
    /// 属性附加等级
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int addtionLevel;

	/// <summary>
    /// 骑宠评分
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int petHorseScore;


}
}