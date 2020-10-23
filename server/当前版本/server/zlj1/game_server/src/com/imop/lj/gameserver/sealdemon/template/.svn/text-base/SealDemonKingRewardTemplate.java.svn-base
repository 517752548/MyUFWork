package com.imop.lj.gameserver.sealdemon.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;

@ExcelRowBinding
public class SealDemonKingRewardTemplate extends SealDemonKingRewardTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//魔王宝箱道具Id是否存在
		ItemTemplate item = templateService.get(this.getItemId(), ItemTemplate.class);
		if(item == null){
			throw new TemplateConfigException(this.sheetName, this.id, "道具不存在！itemID="+this.getItemId());
		}
	}

}
