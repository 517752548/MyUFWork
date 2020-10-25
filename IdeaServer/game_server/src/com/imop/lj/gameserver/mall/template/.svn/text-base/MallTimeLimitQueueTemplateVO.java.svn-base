package com.imop.lj.gameserver.mall.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 商城限时商品配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MallTimeLimitQueueTemplateVO extends TemplateObject {

	/** 延迟时间 */
	@ExcelCellBinding(offset = 1)
	protected long delayTime;

	/** 是否可循环 */
	@ExcelCellBinding(offset = 2)
	protected boolean loop;

	/** 是否生效 */
	@ExcelCellBinding(offset = 3)
	protected boolean effective;

	/** 开始公告ID */
	@ExcelCellBinding(offset = 4)
	protected int startBroadcastId;

	/** 结束公告ID */
	@ExcelCellBinding(offset = 5)
	protected int endBroadCastId;

	/** 间隔时间 */
	@ExcelCellBinding(offset = 6)
	protected long intervalTime;


	public long getDelayTime() {
		return this.delayTime;
	}

	public void setDelayTime(long delayTime) {
		if (delayTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[延迟时间]delayTime的值不得小于0");
		}
		this.delayTime = delayTime;
	}
	
	public boolean isLoop() {
		return this.loop;
	}

	public void setLoop(boolean loop) {
		this.loop = loop;
	}
	
	public boolean isEffective() {
		return this.effective;
	}

	public void setEffective(boolean effective) {
		this.effective = effective;
	}
	
	public int getStartBroadcastId() {
		return this.startBroadcastId;
	}

	public void setStartBroadcastId(int startBroadcastId) {
		if (startBroadcastId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[开始公告ID]startBroadcastId的值不得小于0");
		}
		this.startBroadcastId = startBroadcastId;
	}
	
	public int getEndBroadCastId() {
		return this.endBroadCastId;
	}

	public void setEndBroadCastId(int endBroadCastId) {
		if (endBroadCastId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[结束公告ID]endBroadCastId的值不得小于0");
		}
		this.endBroadCastId = endBroadCastId;
	}
	
	public long getIntervalTime() {
		return this.intervalTime;
	}

	public void setIntervalTime(long intervalTime) {
		if (intervalTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[间隔时间]intervalTime的值不得小于0");
		}
		this.intervalTime = intervalTime;
	}
	

	@Override
	public String toString() {
		return "MallTimeLimitQueueTemplateVO[delayTime=" + delayTime + ",loop=" + loop + ",effective=" + effective + ",startBroadcastId=" + startBroadcastId + ",endBroadCastId=" + endBroadCastId + ",intervalTime=" + intervalTime + ",]";

	}
}