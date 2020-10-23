using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 小信封内容模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MailBoxInfoTemplateVO : TemplateObject
	{
	/// <summary>
    /// 多语言id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long infoLangId;

	/// <summary>
    /// 内容
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public string info;

	/// <summary>
    /// tips宽度
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int weight;

	/// <summary>
    /// 小信封图标
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int icon;


}
}