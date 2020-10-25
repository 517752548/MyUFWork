package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

/**
 * GM增加Vip经验
 * 
 */
public class GMAddVipExpMessage extends SysInternalMessage {
	private long roleId;
	private int gmExp;
	
	public GMAddVipExpMessage(long roleId, int gmExp){
		this.roleId = roleId;
		this.gmExp = gmExp;
	}
	
	
	@Override
	public void execute() {
		Globals.getVipService().onGmAddVipExp(roleId, gmExp);
	}

}
