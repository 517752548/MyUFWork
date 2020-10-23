using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宠物成长率
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class PetGrowthTemplateVO : TemplateObject
	{
	/// <summary>
    /// 普通宠权重
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int normalWeight;

	/// <summary>
    /// 垃圾宠权重
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int rubbishyWeight;

	/// <summary>
    /// 变异宠权重
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int transformWeight;

	/// <summary>
    /// 成长率加成
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int add;

	/// <summary>
    /// 成长率名称多语言Id
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public long nameLangId;

	/// <summary>
    /// 成长率名称
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public string name;

	/// <summary>
    /// 宠物评分
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int petScore;


}
}