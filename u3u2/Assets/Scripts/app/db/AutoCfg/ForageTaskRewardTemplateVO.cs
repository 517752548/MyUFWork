using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 护送粮草奖励模版
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ForageTaskRewardTemplateVO : TemplateObject
	{
	/// <summary>
    /// 粮草品质
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int forageStar;

	/// <summary>
    /// 押金
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int deposit;

	/// <summary>
    /// 押金类型
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int depositType;

	/// <summary>
    /// 基础奖励类型1
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int rewardType1;

	/// <summary>
    /// 基础奖励1
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int rewardNum1;

	/// <summary>
    /// 战斗失败扣除基础奖励1的比例
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int deductProp1;

	/// <summary>
    /// 基础奖励类型2
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int rewardType2;

	/// <summary>
    /// 基础奖励2
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int rewardNum2;

	/// <summary>
    /// 刷出基础奖励2的概率
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int rewardProp2;


}
}