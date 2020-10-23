using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宠物悟性提升经验
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetPerceptPromoteTemplateVO : TemplateObject
	{
	/// <summary>
    /// 提升方式
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int promoteType;

	/// <summary>
    /// 悟性等级
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int perceptLevel;

	/// <summary>
    /// 单次提供经验
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int singleExp;

	/// <summary>
    /// 单次小暴击概率
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int singleSmallCritProp;

	/// <summary>
    /// 单次大暴击概率
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int singleBigCritProp;

	/// <summary>
    /// 批量小暴击概率
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int batchSmallCritProp;

	/// <summary>
    /// 批量大暴击概率
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int batchBigCritProp;


}
}