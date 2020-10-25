package com.imop.lj.gameserver.cdkeygift;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.gameserver.acrossserver.ServerClient;
import com.imop.lj.gameserver.cdkeygift.async.CDKeyCheckIoOperation;
import com.imop.lj.gameserver.common.Globals;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月4日 下午4:49:00
 * @version 1.0
 */

public class CDKeyWorldService implements InitializeRequired {

	@Override
	public void init() {
	}
	
	
	/**
	 * ===========领取==============
	 */
	/**
	 * 验证cdkey是否有效
	 */
	public void ckeckCDKeyEffective(ServerClient serverClient, long charUUID, String openId, String cdKeyStr, String serverId, String charName) {
		// 起一个Operation 执行,多线程执行完成，发验证消息
		CDKeyCheckIoOperation operation = new CDKeyCheckIoOperation(serverClient, cdKeyStr, charUUID, serverId, charName, openId);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation, 0);
	}

}
