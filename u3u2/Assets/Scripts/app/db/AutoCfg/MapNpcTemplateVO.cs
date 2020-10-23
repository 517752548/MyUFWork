using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 地图npc模板
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class MapNpcTemplateVO : TemplateObject
	{
	/// <summary>
    /// 地图Id
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int mapId;

	/// <summary>
    /// NPCId
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int npcId;

	/// <summary>
    /// 是否像素点，0否，1是
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int pixelFlag;

	/// <summary>
    /// x坐标
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int x;

	/// <summary>
    /// y坐标
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int y;


}
}