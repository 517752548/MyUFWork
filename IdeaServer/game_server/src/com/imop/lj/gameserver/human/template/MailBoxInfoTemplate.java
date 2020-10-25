package com.imop.lj.gameserver.human.template;

import java.util.Arrays;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.human.TipsInfoDef.MailBoxInfoType;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class MailBoxInfoTemplate extends MailBoxInfoTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		List<MailBoxInfoType> allMailBox = Arrays.asList(MailBoxInfoType.values());
		if(!allMailBox.contains(MailBoxInfoType.valueOf(this.getId()))) {
			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("信封类型id:%d不存在", this.getId()));
		}
		
		for(MailBoxInfoType type : MailBoxInfoType.values()){
			MailBoxInfoTemplate template = templateService.get(type.index, MailBoxInfoTemplate.class);
			if(template == null){
				throw new TemplateConfigException(this.getSheetName(), getId(), String.format("信封类型id:%d不存在", type.index));
			}
		}
	}

}
