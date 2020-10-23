using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 人物心法对应人物技能
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class HumanMainSkillToSubSkillTemplateVO : TemplateObject
	{
	/// <summary>
    /// 技能名称
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string name;

	/// <summary>
    /// 心法ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int mainSkillId;

	/// <summary>
    /// 技能ID
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int subSkillId;

	/// <summary>
    /// 描述
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public string descInfo;

	/// <summary>
    /// 心法系数
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public float mindCoefDesc;

	/// <summary>
    /// 技能系数
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public float skillCoefDesc;

	/// <summary>
    /// 系数1
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public float coef1Desc;

	/// <summary>
    /// 系数2
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public float coef2Desc;


}
}