package com.imop.lj.gameserver.story.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 剧情战报配置表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class StoryBattleTemplateVO extends TemplateObject {

	/** 剧情id */
	@ExcelCellBinding(offset = 1)
	protected int storyId;

	/** 时间点ms */
	@ExcelCellBinding(offset = 2)
	protected int time;

	/** 回合数 */
	@ExcelCellBinding(offset = 3)
	protected int round;

	/** 特殊事件类型 */
	@ExcelCellBinding(offset = 4)
	protected int eventType;

	/** 状态 */
	@ExcelCellBinding(offset = 5)
	protected int status;

	/** 对象类型 */
	@ExcelCellBinding(offset = 6)
	protected int targetType;

	/** 对象编号 */
	@ExcelCellBinding(offset = 7)
	protected String targetId;

	/** 角色名称 */
	@ExcelCellBinding(offset = 8)
	protected String targetName;

	/** 3d模型名称/音乐名 */
	@ExcelCellBinding(offset = 9)
	protected String modelName;

	/** 释放技能id */
	@ExcelCellBinding(offset = 10)
	protected int skillId;

	/** 技能目标的对象编号,多个目标用英文逗号隔开 */
	@ExcelCellBinding(offset = 11)
	protected String skillTargets;

	/** 位置x */
	@ExcelCellBinding(offset = 12)
	protected int posX;

	/** 位置y */
	@ExcelCellBinding(offset = 13)
	protected int posY;

	/** 血量 */
	@ExcelCellBinding(offset = 14)
	protected int hp;

	/** 动作 */
	@ExcelCellBinding(offset = 15)
	protected String action;

	/** 朝向 */
	@ExcelCellBinding(offset = 16)
	protected int direction;

	/** 说话 */
	@ExcelCellBinding(offset = 17)
	protected String speak;


	public int getStoryId() {
		return this.storyId;
	}

	public void setStoryId(int storyId) {
		if (storyId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[剧情id]storyId的值不得小于0");
		}
		this.storyId = storyId;
	}
	
	public int getTime() {
		return this.time;
	}

	public void setTime(int time) {
		if (time < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[时间点ms]time的值不得小于0");
		}
		this.time = time;
	}
	
	public int getRound() {
		return this.round;
	}

	public void setRound(int round) {
		if (round < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[回合数]round的值不得小于0");
		}
		this.round = round;
	}
	
	public int getEventType() {
		return this.eventType;
	}

	public void setEventType(int eventType) {
		if (eventType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[特殊事件类型]eventType的值不得小于0");
		}
		this.eventType = eventType;
	}
	
	public int getStatus() {
		return this.status;
	}

	public void setStatus(int status) {
		if (status < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[状态]status的值不得小于0");
		}
		this.status = status;
	}
	
	public int getTargetType() {
		return this.targetType;
	}

	public void setTargetType(int targetType) {
		if (targetType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[对象类型]targetType的值不得小于0");
		}
		this.targetType = targetType;
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
	
	public String getTargetName() {
		return this.targetName;
	}

	public void setTargetName(String targetName) {
		if (targetName != null) {
			this.targetName = targetName.trim();
		}else{
			this.targetName = targetName;
		}
	}
	
	public String getModelName() {
		return this.modelName;
	}

	public void setModelName(String modelName) {
		if (modelName != null) {
			this.modelName = modelName.trim();
		}else{
			this.modelName = modelName;
		}
	}
	
	public int getSkillId() {
		return this.skillId;
	}

	public void setSkillId(int skillId) {
		if (skillId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[释放技能id]skillId的值不得小于0");
		}
		this.skillId = skillId;
	}
	
	public String getSkillTargets() {
		return this.skillTargets;
	}

	public void setSkillTargets(String skillTargets) {
		if (skillTargets != null) {
			this.skillTargets = skillTargets.trim();
		}else{
			this.skillTargets = skillTargets;
		}
	}
	
	public int getPosX() {
		return this.posX;
	}

	public void setPosX(int posX) {
		this.posX = posX;
	}
	
	public int getPosY() {
		return this.posY;
	}

	public void setPosY(int posY) {
		if (posY > 10 || posY < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[位置y]posY的值不合法，应为0至10之间");
		}
		this.posY = posY;
	}
	
	public int getHp() {
		return this.hp;
	}

	public void setHp(int hp) {
		this.hp = hp;
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
		if (direction > 8 || direction < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[朝向]direction的值不合法，应为0至8之间");
		}
		this.direction = direction;
	}
	
	public String getSpeak() {
		return this.speak;
	}

	public void setSpeak(String speak) {
		if (speak != null) {
			this.speak = speak.trim();
		}else{
			this.speak = speak;
		}
	}
	

	@Override
	public String toString() {
		return "StoryBattleTemplateVO[storyId=" + storyId + ",time=" + time + ",round=" + round + ",eventType=" + eventType + ",status=" + status + ",targetType=" + targetType + ",targetId=" + targetId + ",targetName=" + targetName + ",modelName=" + modelName + ",skillId=" + skillId + ",skillTargets=" + skillTargets + ",posX=" + posX + ",posY=" + posY + ",hp=" + hp + ",action=" + action + ",direction=" + direction + ",speak=" + speak + ",]";

	}
}