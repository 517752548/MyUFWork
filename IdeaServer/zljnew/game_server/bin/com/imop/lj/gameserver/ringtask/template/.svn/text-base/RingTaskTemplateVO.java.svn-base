package com.imop.lj.gameserver.ringtask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 跑环任务配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RingTaskTemplateVO extends TemplateObject {

	/** 主将等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 主将等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 轮数 */
	@ExcelCellBinding(offset = 3)
	protected int roundNum;

	/** 跑环任务列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "4;5;6;7;8;9;10;11;12;13")
	protected List<Integer> ringTaskList;


	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[主将等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[主将等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getRoundNum() {
		return this.roundNum;
	}

	public void setRoundNum(int roundNum) {
		if (roundNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[轮数]roundNum的值不得小于1");
		}
		this.roundNum = roundNum;
	}
	
	public List<Integer> getRingTaskList() {
		return this.ringTaskList;
	}

	public void setRingTaskList(List<Integer> ringTaskList) {
		if (ringTaskList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[跑环任务列表]ringTaskList不可以为空");
		}	
		this.ringTaskList = ringTaskList;
	}
	

	@Override
	public String toString() {
		return "RingTaskTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",roundNum=" + roundNum + ",ringTaskList=" + ringTaskList + ",]";

	}
}