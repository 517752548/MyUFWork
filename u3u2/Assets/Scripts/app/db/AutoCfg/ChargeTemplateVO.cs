using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 充值模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ChargeTemplateVO : TemplateObject
	{
	/// <summary>
    /// 充值RMB数量
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int rmb;

	/// <summary>
    /// 获得金子数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int bond;

	/// <summary>
    /// 首充额外获得金子
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int firstSysBond;

	/// <summary>
    /// 赠送金子
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int giftSysBond;


}
}