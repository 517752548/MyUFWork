
package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 * 在线礼包重试
 * 
 * @author xiaowei.liu
 * 
 */
public class OnlineGiftTestStrategy extends OnceExecuteStrategy {

	public OnlineGiftTestStrategy(Robot robot) {
		super(robot);
	}

	@Override
	public void doAction() {
//		CGReceiveOnlineGift req = new CGReceiveOnlineGift();
//		this.sendMessage(req);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println(message.toString());
	}

}
