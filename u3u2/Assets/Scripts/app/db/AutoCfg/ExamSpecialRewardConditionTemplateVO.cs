using System;
using System.Collections.Generic;
using UnityEngine;

namespace app.db
{
	/**
	 * 特殊奖励条件
	 * 
	 * @author CodeGenerator, don't modify this file please.
	 */
	public abstract class ExamSpecialRewardConditionTemplateVO : TemplateObject
	{
	/// <summary>
    /// 科举类型
    /// </summary>
	//@ExcelCellBinding(offset = 1)
	public int typeId;

	/// <summary>
    /// 正确答案数量
    /// </summary>
	//@ExcelCellBinding(offset = 2)
	public int rightAnswerNum;

	/// <summary>
    /// 奖励ID
    /// </summary>
	//@ExcelCellBinding(offset = 3)
	public int rewardId;


}
}