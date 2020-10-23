using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宠物技能书
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemItemTemplateVO : ItemTemplate
	{
	/// <summary>
    /// 属性key
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int propKey;

	/// <summary>
    /// 属性值
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int propValue;

	/// <summary>
    /// 宝石颜色
    /// </summary>
	//@ExcelCellBinding(offset = 40)
	public int gemTypeId;

	/// <summary>
    /// 宝石等级
    /// </summary>
	//@ExcelCellBinding(offset = 41)
	public int gemLevel;

	/// <summary>
    /// 宝石组（降级时按组找低级宝石）
    /// </summary>
	//@ExcelCellBinding(offset = 42)
	public int gemGroup;


}
}