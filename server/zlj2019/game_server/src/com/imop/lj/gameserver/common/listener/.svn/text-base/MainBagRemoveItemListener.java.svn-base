package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.MainBagRemoveItemEvent;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;

public class MainBagRemoveItemListener implements IEventListener<MainBagRemoveItemEvent> {

	@Override
	public void fireEvent(MainBagRemoveItemEvent event) {
		Human human = event.getInfo();
		ItemTemplate itemTpl = event.getTmpl();
		int tempCount = event.getTempCount();
		
		//任务监听
		human.getTaskListener().onCollectItem(human, itemTpl.getId(), tempCount);
		
		//装备相关
		Globals.getEquipService().onMainBagRemoveItem(human, itemTpl, tempCount);
	}
}
