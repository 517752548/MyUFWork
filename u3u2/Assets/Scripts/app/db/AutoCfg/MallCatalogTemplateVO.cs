using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 商城标签配置
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MallCatalogTemplateVO : TemplateObject
	{
	/// <summary>
    /// 排序ID
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int sortId;

	/// <summary>
    /// 名称多语言ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public long nameLangId;

	/// <summary>
    /// 名称
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public string name;

	/// <summary>
    /// 标签类型ID
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int catalogTypeId;


}
}