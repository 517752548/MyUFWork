package com.imop.lj.gameserver.title.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 称号模版
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TitleTemplateVO extends TemplateObject {

	/** 称号类型描述 */
	@ExcelCellBinding(offset = 1)
	protected String descname;

	/** 获得方式 */
	@ExcelCellBinding(offset = 2)
	protected String gettype;

	/** 时效 */
	@ExcelCellBinding(offset = 3)
	protected int deadtime;

	/** 称号描述 */
	@ExcelCellBinding(offset = 4)
	protected String desc;

	/** 基础属性列表，目前只有一组 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "5,6;7,8;9,10;11,12;13,14;15,16")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList;


	public String getDescname() {
		return this.descname;
	}

	public void setDescname(String descname) {
		if (StringUtils.isEmpty(descname)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[称号类型描述]descname不可以为空");
		}
		if (descname != null) {
			this.descname = descname.trim();
		}else{
			this.descname = descname;
		}
	}
	
	public String getGettype() {
		return this.gettype;
	}

	public void setGettype(String gettype) {
		if (StringUtils.isEmpty(gettype)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[获得方式]gettype不可以为空");
		}
		if (gettype != null) {
			this.gettype = gettype.trim();
		}else{
			this.gettype = gettype;
		}
	}
	
	public int getDeadtime() {
		return this.deadtime;
	}

	public void setDeadtime(int deadtime) {
		this.deadtime = deadtime;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[称号描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getBasePropList() {
		return this.basePropList;
	}

	public void setBasePropList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList) {
		if (basePropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[基础属性列表，目前只有一组]basePropList不可以为空");
		}	
		this.basePropList = basePropList;
	}
	

	@Override
	public String toString() {
		return "TitleTemplateVO[descname=" + descname + ",gettype=" + gettype + ",deadtime=" + deadtime + ",desc=" + desc + ",basePropList=" + basePropList + ",]";

	}
}