using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 特殊在线礼包
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class SpecOnlineGiftTemplateVO : TemplateObject
	{
	/// <summary>
    /// CD
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public long cd;

	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int rewardId;

	/// <summary>
    /// 头像ID
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public string iconId;

	/// <summary>
    ///  资源类型
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int resType;

	/// <summary>
    /// 资源ID
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public string resId;

	/// <summary>
    /// X轴偏移量
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int offsetX;

	/// <summary>
    /// Y轴偏移量
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int offsetY;

	/// <summary>
    /// 美术字ID
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int artFontId;

	/// <summary>
    ///  按钮信息多语言ID
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int menuDescLangId;

	/// <summary>
    /// 按钮信息
    /// </summary>
	//@ExcelCellBinding(offset = 10)
	public string menuDesc;

	/// <summary>
    /// 奖励描述多语言ID
    /// </summary>
	//@ExcelCellBinding(offset = 11)
	public int rewardDescLangId;

	/// <summary>
    /// 奖励描述
    /// </summary>
	//@ExcelCellBinding(offset = 12)
	public string rewardDesc;

	/// <summary>
    /// 领取描述多语言ID
    /// </summary>
	//@ExcelCellBinding(offset = 13)
	public int receiveDescLangId;

	/// <summary>
    /// 领取描述
    /// </summary>
	//@ExcelCellBinding(offset = 14)
	public string receiveDesc;


}
}