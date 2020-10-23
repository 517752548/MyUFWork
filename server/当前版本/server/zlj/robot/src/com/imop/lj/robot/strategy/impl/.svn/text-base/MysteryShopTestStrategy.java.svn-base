package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.mysteryshop.MSItemInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.mysteryshop.msg.CGBuyMsItem;
import com.imop.lj.gameserver.mysteryshop.msg.CGFlushMystery;
import com.imop.lj.gameserver.mysteryshop.msg.CGReqMysteryShopInfo;
import com.imop.lj.gameserver.mysteryshop.msg.GCMysteryShopInfo;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class MysteryShopTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public MysteryShopTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
		//打开神秘商店
		CGReqMysteryShopInfo reqMsg = new CGReqMysteryShopInfo();
		this.sendMessage(reqMsg);
		//刷新
		CGFlushMystery flushMsg = new CGFlushMystery(1);
		this.sendMessage(flushMsg);

	}

	@Override
	public void onResponse(IMessage message) {
		if (message instanceof GCMysteryShopInfo) {
			GCMysteryShopInfo shopMsg = (GCMysteryShopInfo) message;
			System.out.println(shopMsg);
			MSItemInfo[] infos = shopMsg.getMsItemInfoList();
			if(infos == null || infos.length == 0){
				return;
			}
			//购买
			CGBuyMsItem buyMSg = new CGBuyMsItem(infos[0].getId());
			this.sendMessage(buyMSg);
		}
	}
}
