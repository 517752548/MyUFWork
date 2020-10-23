using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 属性种类对应单价值
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemForPropValueTemplateVO : TemplateObject
	{
	/// <summary>
    /// 属性名称
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public string name;

	/// <summary>
    /// 单颗价值系数
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int value;


}
}