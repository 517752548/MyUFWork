package com.imop.lj.gameserver.video.template;

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
public abstract class VideoTemplateVO extends TemplateObject {

	/** 剧情id */
	@ExcelCellBinding(offset = 1)
	protected int videoId;

	/** 时间点,毫秒 */
	@ExcelCellBinding(offset = 2)
	protected int timePoint;

	/** 对象 */
	@ExcelCellBinding(offset = 3)
	protected String targetId;

	/** 对象类型 */
	@ExcelCellBinding(offset = 4)
	protected int targetType;

	/** 事件类型 */
	@ExcelCellBinding(offset = 5)
	protected int eventType;

	/** 3d模型名称 */
	@ExcelCellBinding(offset = 6)
	protected String model3DId;

	/** 角色名称 */
	@ExcelCellBinding(offset = 7)
	protected String playerName;

	/** 是否像素点 */
	@ExcelCellBinding(offset = 8)
	protected int pixelPoint;

	/** 位置x */
	@ExcelCellBinding(offset = 9)
	protected int xPoint;

	/** 位置y */
	@ExcelCellBinding(offset = 10)
	protected int yPoint;

	/** 动作 */
	@ExcelCellBinding(offset = 11)
	protected String action;

	/** 方向 */
	@ExcelCellBinding(offset = 12)
	protected int direction;

	/** 说话 */
	@ExcelCellBinding(offset = 13)
	protected String talk;


	public int getVideoId() {
		return this.videoId;
	}

	public void setVideoId(int videoId) {
		if (videoId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[剧情id]videoId的值不得小于0");
		}
		this.videoId = videoId;
	}
	
	public int getTimePoint() {
		return this.timePoint;
	}

	public void setTimePoint(int timePoint) {
		if (timePoint < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[时间点,毫秒]timePoint的值不得小于0");
		}
		this.timePoint = timePoint;
	}
	
	public String getTargetId() {
		return this.targetId;
	}

	public void setTargetId(String targetId) {
		if (targetId != null) {
			this.targetId = targetId.trim();
		}else{
			this.targetId = targetId;
		}
	}
	
	public int getTargetType() {
		return this.targetType;
	}

	public void setTargetType(int targetType) {
		if (targetType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[对象类型]targetType的值不得小于0");
		}
		this.targetType = targetType;
	}
	
	public int getEventType() {
		return this.eventType;
	}

	public void setEventType(int eventType) {
		if (eventType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[事件类型]eventType的值不得小于1");
		}
		this.eventType = eventType;
	}
	
	public String getModel3DId() {
		return this.model3DId;
	}

	public void setModel3DId(String model3DId) {
		if (model3DId != null) {
			this.model3DId = model3DId.trim();
		}else{
			this.model3DId = model3DId;
		}
	}
	
	public String getPlayerName() {
		return this.playerName;
	}

	public void setPlayerName(String playerName) {
		if (playerName != null) {
			this.playerName = playerName.trim();
		}else{
			this.playerName = playerName;
		}
	}
	
	public int getPixelPoint() {
		return this.pixelPoint;
	}

	public void setPixelPoint(int pixelPoint) {
		if (pixelPoint < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[是否像素点]pixelPoint的值不得小于0");
		}
		this.pixelPoint = pixelPoint;
	}
	
	public int getXPoint() {
		return this.xPoint;
	}

	public void setXPoint(int xPoint) {
		if (xPoint < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[位置x]xPoint的值不得小于0");
		}
		this.xPoint = xPoint;
	}
	
	public int getYPoint() {
		return this.yPoint;
	}

	public void setYPoint(int yPoint) {
		if (yPoint < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[位置y]yPoint的值不得小于0");
		}
		this.yPoint = yPoint;
	}
	
	public String getAction() {
		return this.action;
	}

	public void setAction(String action) {
		if (action != null) {
			this.action = action.trim();
		}else{
			this.action = action;
		}
	}
	
	public int getDirection() {
		return this.direction;
	}

	public void setDirection(int direction) {
		this.direction = direction;
	}
	
	public String getTalk() {
		return this.talk;
	}

	public void setTalk(String talk) {
		if (talk != null) {
			this.talk = talk.trim();
		}else{
			this.talk = talk;
		}
	}
	

	@Override
	public String toString() {
		return "VideoTemplateVO[videoId=" + videoId + ",timePoint=" + timePoint + ",targetId=" + targetId + ",targetType=" + targetType + ",eventType=" + eventType + ",model3DId=" + model3DId + ",playerName=" + playerName + ",pixelPoint=" + pixelPoint + ",xPoint=" + xPoint + ",yPoint=" + yPoint + ",action=" + action + ",direction=" + direction + ",talk=" + talk + ",]";

	}
}