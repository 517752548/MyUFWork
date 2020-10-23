using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 战斗属性系数表
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class BattlePropCoefTemplateVO : TemplateObject
	{
	/// <summary>
    /// 物理防御系数
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int phArmor;

	/// <summary>
    /// 物理命中系数
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int phHit;

	/// <summary>
    /// 物理闪避系数
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int phDodgy;

	/// <summary>
    /// 物理暴击系数
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int phCrit;

	/// <summary>
    /// 物理抗暴系数
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int phAntiCrit;

	/// <summary>
    /// 法术防御系数
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int maArmor;

	/// <summary>
    /// 法术命中系数
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int maHit;

	/// <summary>
    /// 法术闪避系数
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int maDodgy;

	/// <summary>
    /// 法术暴击系数
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int maCrit;

	/// <summary>
    /// 法术抗暴系数
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public int maAntiCrit;


}
}