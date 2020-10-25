package com.imop.lj.gameserver.mail.confirmhandler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 删除带附件的邮件二次确认框
 * 
 */
public class DelMailStaticHandler extends IStaticHandler {
	private String[] uuids;

	public DelMailStaticHandler(String[] uuids) {
		this.uuids = uuids;
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			// 确认
			Globals.getMailService().delMailConfirm(human, uuids);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.MAIL_DEL_HAS_ATTACHMENT;
	}
}
