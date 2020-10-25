package com.imop.lj.gameserver.story.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 剧情配置表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class StoryTemplateVO extends TemplateObject {

	/** 剧情id */
	@ExcelCellBinding(offset = 1)
	protected int storyId;

	/** 剧情类型 */
	@ExcelCellBinding(offset = 2)
	protected int storyType;

	/** 剧情内容 */
	@ExcelCellBinding(offset = 3)
	protected String content;

	/** 是否npc */
	@ExcelCellBinding(offset = 4)
	protected int isNpc;


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
	
	public int getStoryType() {
		return this.storyType;
	}

	public void setStoryType(int storyType) {
		if (storyType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[剧情类型]storyType的值不得小于0");
		}
		this.storyType = storyType;
	}
	
	public String getContent() {
		return this.content;
	}

	public void setContent(String content) {
		if (content != null) {
			this.content = content.trim();
		}else{
			this.content = content;
		}
	}
	
	public int getIsNpc() {
		return this.isNpc;
	}

	public void setIsNpc(int isNpc) {
		if (isNpc > 1 || isNpc < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[是否npc]isNpc的值不合法，应为0至1之间");
		}
		this.isNpc = isNpc;
	}
	

	@Override
	public String toString() {
		return "StoryTemplateVO[storyId=" + storyId + ",storyType=" + storyType + ",content=" + content + ",isNpc=" + isNpc + ",]";

	}
}