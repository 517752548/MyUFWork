package com.imop.lj.gameserver.vip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * VIP升级配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class VipConfigTemplateVO extends TemplateObject {

	/** 特权描述多语言ID */
	@ExcelCellBinding(offset = 1)
	protected long descLangId;

	/** 特权描述 */
	@ExcelCellBinding(offset = 2)
	protected String desc;

	/** 排序ID */
	@ExcelCellBinding(offset = 3)
	protected int sortId;

	/** 是否显示到VIP面板 */
	@ExcelCellBinding(offset = 4)
	protected boolean show;

	/** 对应级别的VIP配置 */
	@ExcelCollectionMapping(clazz = com.imop.lj.common.model.template.VipItemTemplate.class, collectionNumber = "5,6;7,8;9,10;11,12;13,14;15,16;17,18;19,20;21,22;23,24;25,26;27,28;29,30;31,32;33,34;35,36")
	protected List<com.imop.lj.common.model.template.VipItemTemplate> vipItemList;


	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		if (descLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[特权描述多语言ID]descLangId的值不得小于0");
		}
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[特权描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public int getSortId() {
		return this.sortId;
	}

	public void setSortId(int sortId) {
		this.sortId = sortId;
	}
	
	public boolean isShow() {
		return this.show;
	}

	public void setShow(boolean show) {
		this.show = show;
	}
	
	public List<com.imop.lj.common.model.template.VipItemTemplate> getVipItemList() {
		return this.vipItemList;
	}

	public void setVipItemList(List<com.imop.lj.common.model.template.VipItemTemplate> vipItemList) {
		if (vipItemList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[对应级别的VIP配置]vipItemList不可以为空");
		}	
		this.vipItemList = vipItemList;
	}
	

	@Override
	public String toString() {
		return "VipConfigTemplateVO[descLangId=" + descLangId + ",desc=" + desc + ",sortId=" + sortId + ",show=" + show + ",vipItemList=" + vipItemList + ",]";

	}
}