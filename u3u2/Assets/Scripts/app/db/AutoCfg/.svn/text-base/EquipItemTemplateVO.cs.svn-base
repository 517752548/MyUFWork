using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 装备物品模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class EquipItemTemplateVO : ItemTemplate
	{
	/// <summary>
    /// 是否固定装备，0否，1是
    /// </summary>
	//@ExcelCellBinding(offset = 38)
	public int isFixedAttr;

	/// <summary>
    /// 部位Id
    /// </summary>
	//@ExcelCellBinding(offset = 39)
	public int positionId;

	/// <summary>
    /// 阶数Id
    /// </summary>
	//@ExcelCellBinding(offset = 40)
	public int gradeId;

	/// <summary>
    /// 职业要求
    /// </summary>
	//@ExcelCellBinding(offset = 41)
	public int jobLimit;

	/// <summary>
    /// 性别要求
    /// </summary>
	//@ExcelCellBinding(offset = 42)
	public int sexLimit;

	/// <summary>
    /// 属性要求类型
    /// </summary>
	//@ExcelCellBinding(offset = 43)
	public int propLimit;

	/// <summary>
    /// 属性要求数值
    /// </summary>
	//@ExcelCellBinding(offset = 44)
	public int propValueLimit;

	/// <summary>
    /// 耐久度
    /// </summary>
	//@ExcelCellBinding(offset = 45)
	public int durability;

	/// <summary>
    /// 左手模型
    /// </summary>
	//@ExcelCellBinding(offset = 46)
	public string leftModel;

	/// <summary>
    /// 右手模型
    /// </summary>
	//@ExcelCellBinding(offset = 47)
	public string rightModel;

	/// <summary>
    /// 基础属性价值
    /// </summary>
	//@ExcelCellBinding(offset = 48)
	public int basePropValue;

	/// <summary>
    /// 附加属性价值
    /// </summary>
	//@ExcelCellBinding(offset = 49)
	public int addPropValue;

	/// <summary>
    /// 绑定属性价值
    /// </summary>
	//@ExcelCellBinding(offset = 50)
	public int bindPropValue;

	/// <summary>
    /// 基础属性列表，目前只有一组
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "51,52")
	public List<EquipItemAttribute> basePropList;

	/// <summary>
    /// 附加属性列表
    /// </summary>
	//@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "53,54;55,56;57,58;59,60;61,62;63,64")
	public List<EquipItemAttribute> addPropList;


}
}