package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.human.HumanInfo;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.callback.ICallback;
import com.imop.platform.local.response.IResponse;

public class ReportPlayerOperation implements LocalIoOperation {

	private Player player;
	//被举报玩家的角色名
	private String targetCharName;
	//被举报玩家的human信息
	private HumanInfo targetHuman;
	//聊天内容
	private String chatText;
	//频道
	private int scope;
	//令牌
	private String token;
	

	public int getScope() {
		return scope;
	}

	public String getToken() {
		return token;
	}

	public void setScope(int scope) {
		this.scope = scope;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public String getChatText() {
		return chatText;
	}

	public void setChatText(String chatText) {
		this.chatText = chatText;
	}

	public Player getPlayer() {
		return player;
	}

	public String getTargetCharName() {
		return targetCharName;
	}

	public HumanInfo getTargetHuman() {
		return targetHuman;
	}

	public void setPlayer(Player player) {
		this.player = player;
	}

	public void setTargetCharName(String targetCharName) {
		this.targetCharName = targetCharName;
	}

	public void setTargetHuman(HumanInfo targetHuman) {
		this.targetHuman = targetHuman;
	}

	

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		//举报时间
		long reportTime = Globals.getTimeService().now();
		String channel = this.scope + "";
		String chatId = this.token + "";
		 Globals.getAsyncLocalService().reportPlayer(player.getClientIp(), player.getPassportName(), player.getPassportId(),
				player.getRoleUUID(),player.getHuman().getName(), player.getHuman().getLevel(), reportTime, 
				targetHuman.getName(), targetHuman.getPassportId(), targetHuman.getRoleUUID(),targetCharName, targetHuman.getLevel(),
				channel, reportTime+"", chatId, 
				this.chatText, new ICallback(){

					@Override
					public void onSuccess(IResponse response) {
						player.sendErrorMessage(LangConstants.REPORT_PLAYER_SUCC);
					}

					@Override
					public void onFail(IResponse response) {
						player.sendErrorMessage(LangConstants.REPORT_PLAYER_FAIL);
					}
			 
		 });
		 return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		return IIoOperation.STAGE_STOP_DONE;
	}

}
