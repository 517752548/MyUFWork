package com.imop.lj.gameserver.scene.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 随机名称表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SceneTemplateVO extends TemplateObject {

	/**  区域类型 ID */
	@ExcelCellBinding(offset = 1)
	protected int distTypeId;

	/** 场景索引 */
	@ExcelCellBinding(offset = 2)
	protected int index;

	/**  区域名称多语言 Id */
	@ExcelCellBinding(offset = 3)
	protected long distNameLangId;

	/**  区域名称 */
	@ExcelCellBinding(offset = 4)
	protected String distName;

	/**  城市说明多语言 Id */
	@ExcelCellBinding(offset = 5)
	protected long descLangId;

	/**  城市说明 */
	@ExcelCellBinding(offset = 6)
	protected String desc;

	/** 允许访问等级 */
	@ExcelCellBinding(offset = 7)
	protected int requireLevel;

	/** 音乐ID */
	@ExcelCellBinding(offset = 8)
	protected int musicId;


	public int getDistTypeId() {
		return this.distTypeId;
	}

	public void setDistTypeId(int distTypeId) {
		if (distTypeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 区域类型 ID]distTypeId不可以为0");
		}
		this.distTypeId = distTypeId;
	}
	
	public int getIndex() {
		return this.index;
	}

	public void setIndex(int index) {
		if (index == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[场景索引]index不可以为0");
		}
		this.index = index;
	}
	
	public long getDistNameLangId() {
		return this.distNameLangId;
	}

	public void setDistNameLangId(long distNameLangId) {
		if (distNameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[ 区域名称多语言 Id]distNameLangId的值不得小于0");
		}
		this.distNameLangId = distNameLangId;
	}
	
	public String getDistName() {
		return this.distName;
	}

	public void setDistName(String distName) {
		if (StringUtils.isEmpty(distName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[ 区域名称]distName不可以为空");
		}
		if (distName != null) {
			this.distName = distName.trim();
		}else{
			this.distName = distName;
		}
	}
	
	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		if (descLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[ 城市说明多语言 Id]descLangId的值不得小于0");
		}
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[ 城市说明]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public int getRequireLevel() {
		return this.requireLevel;
	}

	public void setRequireLevel(int requireLevel) {
		if (requireLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[允许访问等级]requireLevel的值不得小于0");
		}
		this.requireLevel = requireLevel;
	}
	
	public int getMusicId() {
		return this.musicId;
	}

	public void setMusicId(int musicId) {
		this.musicId = musicId;
	}
	

	@Override
	public String toString() {
		return "SceneTemplateVO[distTypeId=" + distTypeId + ",index=" + index + ",distNameLangId=" + distNameLangId + ",distName=" + distName + ",descLangId=" + descLangId + ",desc=" + desc + ",requireLevel=" + requireLevel + ",musicId=" + musicId + ",]";

	}
}