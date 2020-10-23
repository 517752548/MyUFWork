package com.imop.lj.gameserver.offlinedata.sysmsg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.Pet;

/**
 * 更新玩家离线数据中的一个武将的数据
 * 
 * @author xiaowei.liu
 * 
 */
public class UserSnapUpdatePetMessage extends SysInternalMessage {
	private Pet pet;
	private int changeOp;

	public UserSnapUpdatePetMessage(Pet pet, int changeOp) {
		this.pet = pet;
		this.changeOp = changeOp;
	}

	@Override
	public void execute() {
		Globals.getOfflineDataService().changePet(pet, changeOp);
	}

}
