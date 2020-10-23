using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 商品子标签
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class TradeSubTagTemplateVO : TemplateObject
	{
	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string name;

	/// <summary>
    /// 一级标签ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int mainTagId;

	/// <summary>
    /// 显示序号
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int displayIndex;

	/// <summary>
    /// 默认图标
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public string displayIcon;

	/// <summary>
    /// 职业
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int jobType;

	/// <summary>
    /// 性别
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int sex;


}
}