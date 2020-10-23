using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 宝石合成
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class GemSynthesisTemplateVO : TemplateObject
	{
	/// <summary>
    /// 宝石等级
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int gemLevel;

	/// <summary>
    /// 合成基数
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int synthesisBase;

	/// <summary>
    /// 合成费用类型
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int currencyType;

	/// <summary>
    /// 合成费用
    /// </summary>
	//@ExcelCellBinding(offset = 4)
	public int currencyNum;

	/// <summary>
    /// 合成符ID
    /// </summary>
	//@ExcelCellBinding(offset = 5)
	public int symbolId;

	/// <summary>
    /// 合成符消耗
    /// </summary>
	//@ExcelCellBinding(offset = 6)
	public int symbolNum;

	/// <summary>
    /// 成功概率
    /// </summary>
	//@ExcelCellBinding(offset = 7)
	public int synthesisProb;

	/// <summary>
    /// 返还道具概率
    /// </summary>
	//@ExcelCellBinding(offset = 8)
	public int rewardProb;

	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 9)
	public int rewardId;


}
}