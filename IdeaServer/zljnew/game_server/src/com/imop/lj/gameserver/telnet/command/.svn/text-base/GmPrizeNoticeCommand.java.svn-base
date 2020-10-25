package com.imop.lj.gameserver.telnet.command;

import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.prize.msg.CanGetPrizeNumMessage;
import com.imop.lj.gameserver.prize.msg.UserPrizeToMailMessage;


/**
 * GM奖励通知
 * 为了更新玩家主界面的礼包数用
 * 在GameServer收到这个命令时，去触发更新礼包数
 * local的无法触发更新
 *
 */
public class GmPrizeNoticeCommand extends LoginedTelnetCommand {

	public GmPrizeNoticeCommand() {
		super("prizenotice");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {

		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);
		String passportIds = _json.getString("passportIds");
		if (passportIds == null || passportIds.trim().equals("")) {
			return;
		}

		// 生成passportIdSet
		Set<String> passportIdSet = parsePassportIds(passportIds);
		// 通知玩家奖励数量变化
		noticePrizeNum(passportIdSet);
	}

	/**
	 * 生成passportIdSet
	 * @param passportIds
	 * @return
	 */
	private Set<String> parsePassportIds(String passportIds) {
		Set<String> passportIdSet = new HashSet<String>();
		String[] passportIdArray = passportIds.split(";");
		if (passportIdArray.length <= 0) {
			return passportIdSet;
		}
		int length = passportIdArray.length;
		for (int i = 0; i <= length; i++) {
			passportIdSet.add(passportIdArray[i]);
		}
		return passportIdSet;
	}

	/**
	 * 通知玩家奖励数量变化
	 * @param passportIdSet
	 */
	private void noticePrizeNum(Set<String> passportIdSet) {
		// 判断是否有数据
		if (passportIdSet.size() <= 0) {
			return;
		}

		// 遍历passportIdSet，判断玩家是否在线，如果在线，则往玩家消息队列丢一个更新礼包数的消息
		for (String passportId : passportIdSet) {
			Player player = Globals.getOnlinePlayerService().getPlayerByPassportId(passportId);
			if (player != null && player.isOnline()) {
				//暂时改为通过邮件发奖励
//				player.putMessage(new CanGetPrizeNumMessage(player));
				player.putMessage(new UserPrizeToMailMessage(player));
			}
		}
	}

}
