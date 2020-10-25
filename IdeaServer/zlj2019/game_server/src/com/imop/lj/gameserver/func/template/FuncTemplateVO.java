package com.imop.lj.gameserver.func.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 功能按钮定义
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class FuncTemplateVO extends TemplateObject {

	/** 组ID */
	@ExcelCellBinding(offset = 1)
	protected int groupId;

	/** 所属功能 */
	@ExcelCellBinding(offset = 2)
	protected int ownerFuncType;

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 3)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 4)
	protected String name;

	/** 是否有对应按钮 */
	@ExcelCellBinding(offset = 5)
	protected int showBtn;

	/** 上下位置 */
	@ExcelCellBinding(offset = 6)
	protected int position;

	/** 顺序 */
	@ExcelCellBinding(offset = 7)
	protected int order;

	/** 描述多语言Id */
	@ExcelCellBinding(offset = 8)
	protected long descLangId;

	/** 描述 */
	@ExcelCellBinding(offset = 9)
	protected String desc;

	/** 特效 */
	@ExcelCellBinding(offset = 10)
	protected int effect;

	/** 特效时显示名称多语言Id */
	@ExcelCellBinding(offset = 11)
	protected long effectNameLangId;

	/** 特效时显示名称 */
	@ExcelCellBinding(offset = 12)
	protected String effectName;

	/** 音乐ID */
	@ExcelCellBinding(offset = 13)
	protected int musicId;


	public int getGroupId() {
		return this.groupId;
	}

	public void setGroupId(int groupId) {
		this.groupId = groupId;
	}
	
	public int getOwnerFuncType() {
		return this.ownerFuncType;
	}

	public void setOwnerFuncType(int ownerFuncType) {
		if (ownerFuncType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[所属功能]ownerFuncType的值不得小于0");
		}
		this.ownerFuncType = ownerFuncType;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		if (nameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[名称多语言Id]nameLangId的值不得小于0");
		}
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getShowBtn() {
		return this.showBtn;
	}

	public void setShowBtn(int showBtn) {
		if (showBtn < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[是否有对应按钮]showBtn的值不得小于0");
		}
		this.showBtn = showBtn;
	}
	
	public int getPosition() {
		return this.position;
	}

	public void setPosition(int position) {
		if (position < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[上下位置]position的值不得小于0");
		}
		this.position = position;
	}
	
	public int getOrder() {
		return this.order;
	}

	public void setOrder(int order) {
		if (order < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[顺序]order的值不得小于0");
		}
		this.order = order;
	}
	
	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		if (descLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[描述多语言Id]descLangId的值不得小于0");
		}
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public int getEffect() {
		return this.effect;
	}

	public void setEffect(int effect) {
		if (effect < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[特效]effect的值不得小于0");
		}
		this.effect = effect;
	}
	
	public long getEffectNameLangId() {
		return this.effectNameLangId;
	}

	public void setEffectNameLangId(long effectNameLangId) {
		if (effectNameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[特效时显示名称多语言Id]effectNameLangId的值不得小于0");
		}
		this.effectNameLangId = effectNameLangId;
	}
	
	public String getEffectName() {
		return this.effectName;
	}

	public void setEffectName(String effectName) {
		if (StringUtils.isEmpty(effectName)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[特效时显示名称]effectName不可以为空");
		}
		if (effectName != null) {
			this.effectName = effectName.trim();
		}else{
			this.effectName = effectName;
		}
	}
	
	public int getMusicId() {
		return this.musicId;
	}

	public void setMusicId(int musicId) {
		this.musicId = musicId;
	}
	

	@Override
	public String toString() {
		return "FuncTemplateVO[groupId=" + groupId + ",ownerFuncType=" + ownerFuncType + ",nameLangId=" + nameLangId + ",name=" + name + ",showBtn=" + showBtn + ",position=" + position + ",order=" + order + ",descLangId=" + descLangId + ",desc=" + desc + ",effect=" + effect + ",effectNameLangId=" + effectNameLangId + ",effectName=" + effectName + ",musicId=" + musicId + ",]";

	}
}