package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.human.Human;

/**
 * 
 * 登陆检查，登陆后，检查是否在上次离线前有未完成的挂机
 * 
 * @author bing.dong
 *
 */
public class PlayerCheckCleanMsg extends SysInternalMessage {

	private Human human;
	
	public PlayerCheckCleanMsg(Human human) {
		this.human = human;
	}
	
	@Override
	public void execute() {
		// 检查奖励
		human.checkPowerRelated();
	}
	
}
