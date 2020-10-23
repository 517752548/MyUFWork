package com.imop.lj.common.model.template;

import com.imop.lj.common.model.constant.SuggestLinkInfo;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class SuggestLinkTemplate {
	@BeanFieldNumber(number = 1)
	private int linkType;
	@BeanFieldNumber(number = 2)
	private int linkPanleId;
	@BeanFieldNumber(number = 3)
	private String desc;

	public int getLinkType() {
		return linkType;
	}

	public void setLinkType(int linkType) {
		this.linkType = linkType;
	}

	public int getLinkPanleId() {
		return linkPanleId;
	}

	public void setLinkPanleId(int linkPanleId) {
		this.linkPanleId = linkPanleId;
	}

	public String getDesc() {
		return desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}
	
	public SuggestLinkInfo toSuggestLinkInfo(){
		SuggestLinkInfo info = new SuggestLinkInfo();
		info.setLinkPanleId(this.linkPanleId);
		info.setLinkType(this.linkType);
		info.setDesc(this.desc);
		return info;
	}

}
