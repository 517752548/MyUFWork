package com.imop.lj.gameserver.constant.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 音乐配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MusicConfigTemplateVO extends TemplateObject {

	/** 音乐资源 */
	@ExcelCellBinding(offset = 1)
	protected int resId;

	/** 是否循环 */
	@ExcelCellBinding(offset = 2)
	protected int loop;


	public int getResId() {
		return this.resId;
	}

	public void setResId(int resId) {
		this.resId = resId;
	}
	
	public int getLoop() {
		return this.loop;
	}

	public void setLoop(int loop) {
		if (loop > 1 || loop < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[是否循环]loop的值不合法，应为0至1之间");
		}
		this.loop = loop;
	}
	

	@Override
	public String toString() {
		return "MusicConfigTemplateVO[resId=" + resId + ",loop=" + loop + ",]";

	}
}