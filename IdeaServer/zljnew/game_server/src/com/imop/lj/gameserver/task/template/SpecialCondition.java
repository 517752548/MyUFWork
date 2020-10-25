package com.imop.lj.gameserver.task.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;
import com.imop.lj.gameserver.task.cond.IQuestCondition;

/**
 * 接任务时的特殊条件限制，此处并非真正的条件对象，而是用于读取表格时用的对象
 * 
 * 
 */
@ExcelRowBinding
public class SpecialCondition {
	
	/** 条件编号 */
	@BeanFieldNumber(number = 1)
	private int type;
	/** 参数1 */
	@BeanFieldNumber(number = 2)
	private String param1st;
	/** 参数2 */
	@BeanFieldNumber(number = 3)
	private String param2st;

	/**
	 * 检验所填参数是否正确
	 */
	public void check(int questId) {
		switch (type) {
//			case IQuest.QUEST_CONDITION_ALLIANCE:
//				checkAllianceConditionData(questId);
//				break;
		}
	}
	
//	/**
//	 * 检查职业条件
//	 * 
//	 * @param questId
//	 */
//	private void checkAllianceConditionData(int questId) {
//		if ("".equals(param1st)) {
//			if (!param1st.matches("\\d+")) {
//				throw new TemplateConfigException("任务主表", questId, "阵营填写错误");
//			}
//			if (Integer.parseInt(param1st) > 7) {
//				throw new TemplateConfigException("任务主表", questId, "所填阵营不能大于7");
//			}
//		}
//	}
	
	/**
	 * 获取该对象所对应的接任务条件
	 * 
	 * @return
	 */
	public IQuestCondition buildQuestCondition() {
		IQuestCondition condition = null;
		switch (type) {
//			case IQuest.QUEST_CONDITION_ALLIANCE:
//				condition = getAllianceCondition();
//				break;
		}
		return condition;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public String getParam1st() {
		return param1st;
	}

	public void setParam1st(String param1st) {
		this.param1st = param1st;
	}

	public String getParam2st() {
		return param2st;
	}

	public void setParam2st(String param2st) {
		this.param2st = param2st;
	}

}
