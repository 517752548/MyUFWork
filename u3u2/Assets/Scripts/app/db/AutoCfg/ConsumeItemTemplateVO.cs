using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 可消耗物品模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ConsumeItemTemplateVO : ItemTemplate
	{
	/// <summary>
    /// 战斗内可使用，0不可以，1可以
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int fightUseFlag;

	/// <summary>
    /// 消耗类型
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int costTypeId;

	/// <summary>
    /// 消耗参数A
    /// </summary>
	//@ExcelCellBinding(offset = 40)
	public int costArgA;

	/// <summary>
    /// 消耗参数B
    /// </summary>
	//@ExcelCellBinding(offset = 41)
	public int costArgB;

	/// <summary>
    /// 使用对象1使用时没有使用对象，对象是角色本身2只能对除主将以外武将使用3只能对主将使用4所有武将都可以用5只能骑宠使用6只能宠物使用
    /// </summary>
	//@ExcelCellBinding(offset = 42)
	public int useTargetId;

	/// <summary>
    /// 是否弹快捷使用，0否，1是
    /// </summary>
	//@ExcelCellBinding(offset = 43)
	public int fastUseTip;

	/// <summary>
    /// 函数功能
    /// </summary>
	//@ExcelCellBinding(offset = 44)
	public int functionId;

	/// <summary>
    /// 参数a
    /// </summary>
	//@ExcelCellBinding(offset = 45)
	public int argA;

	/// <summary>
    /// 参数b
    /// </summary>
	//@ExcelCellBinding(offset = 46)
	public int argB;

	/// <summary>
    /// 参数c
    /// </summary>
	//@ExcelCellBinding(offset = 47)
	public int argC;

	/// <summary>
    /// 参数d
    /// </summary>
	//@ExcelCellBinding(offset = 48)
	public int argD;

	/// <summary>
    /// 参数e
    /// </summary>
	//@ExcelCellBinding(offset = 49)
	public int argE;

	/// <summary>
    /// 参数f
    /// </summary>
	//@ExcelCellBinding(offset = 50)
	public int argF;

	/// <summary>
    /// 地图ID
    /// </summary>
	//@ExcelCellBinding(offset = 51)
	public int mapId;

	/// <summary>
    /// x坐标点
    /// </summary>
	//@ExcelCellBinding(offset = 52)
	public int tileX;

	/// <summary>
    /// y坐标点
    /// </summary>
	//@ExcelCellBinding(offset = 53)
	public int tileY;


}
}