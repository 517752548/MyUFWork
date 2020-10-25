package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.event.MallBuyItemEvent;
import com.imop.lj.gameserver.human.Human;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年5月14日 下午2:44:03
 * @version 1.0
 */

public class MallBuyItemListener implements IEventListener<MallBuyItemEvent>  {

	@Override
	public void fireEvent(MallBuyItemEvent event) {
		Human human = event.getInfo();
		
		//FIXME
//		// 任务监听
//		human.getTaskListener().onMallBuyItem(human, event.getItemTempId(), event.getNum());
	}

}
