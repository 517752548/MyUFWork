package com.imop.lj.gameserver.siegedemon.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 剧情录像
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SiegeDemonTemplateVO extends TemplateObject {

	/** 副本类型（1普通，2困难） */
	@ExcelCellBinding(offset = 1)
	protected int siegeTypeId;

	/** 任务ID */
	@ExcelCellBinding(offset = 2)
	protected int taskId;

	/** 魔族NpcID */
	@ExcelCellBinding(offset = 3)
	protected int siegeNpcId;


	public int getSiegeTypeId() {
		return this.siegeTypeId;
	}

	public void setSiegeTypeId(int siegeTypeId) {
		this.siegeTypeId = siegeTypeId;
	}
	
	public int getTaskId() {
		return this.taskId;
	}

	public void setTaskId(int taskId) {
		if (taskId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[任务ID]taskId的值不得小于1");
		}
		this.taskId = taskId;
	}
	
	public int getSiegeNpcId() {
		return this.siegeNpcId;
	}

	public void setSiegeNpcId(int siegeNpcId) {
		if (siegeNpcId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[魔族NpcID]siegeNpcId的值不得小于1");
		}
		this.siegeNpcId = siegeNpcId;
	}
	

	@Override
	public String toString() {
		return "SiegeDemonTemplateVO[siegeTypeId=" + siegeTypeId + ",taskId=" + taskId + ",siegeNpcId=" + siegeNpcId + ",]";

	}
}