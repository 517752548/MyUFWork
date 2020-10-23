package com.imop.lj.gameserver.player.async;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.prize.UserPrizeHolder;
import com.imop.lj.gameserver.reward.Reward;

/**
 * 查询改玩家的所有t_user_prize，并转为邮件发送给玩家
 */
public class PlayerPrizeToMailOperation implements LocalBindUUIDIoOperation {

	private final static Logger logger = Loggers.prizeLogger;

	private Player player;
	private List<UserPrize> prizeList;
	
	private boolean userPrizeQuery = true;
	
	private List<UserPrizeHolder> hList = new ArrayList<UserPrizeHolder>();

	public PlayerPrizeToMailOperation(Player player) {
		this.player = player;
	}

	@Override
	public int doIo() {
		//检查所有需要给玩家的奖励
		checkUserPrizes();

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if (userPrizeQuery) {
			prizeToMail();
		}
		
		return IIoOperation.STAGE_STOP_DONE;
	}
	
	private void checkUserPrizes() {
		try {
			// 查询数据库
			Human human = player.getHuman();
			if (human == null) {
				return;
			}
			
			prizeList = Globals.getPrizeService().fetchUserPrizeNameListByPassportId(human.getUUID());
			if (prizeList != null && !prizeList.isEmpty()) {
				for (UserPrize uprize : prizeList) {
					UserPrizeHolder uph = Globals.getPrizeService().convertToPrizeHolder(uprize);
					if (uph == null) {
						continue;
					}
					
					int prizeId = uprize.getId();
					if (changePrizeToGot(prizeId)) {
						//增加到列表中,后边发邮件
						hList.add(uph);
					}
				}
			}
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "访问奖励数据库异常，PlayerQueryUserPrizes.doIo，passportId = "
								+ player.getPassportId()));
			}
			userPrizeQuery = false;
		}
	}
	
	private boolean changePrizeToGot(int prizeId) {
		//更新数据库记录
		try {
			//变为已领取
			Globals.getPrizeService().updateUserPrizeStatus(prizeId);
			return true;
		} catch (Exception ex) {
			logger.error("PlayerPrizeToMailOperation#=" + player.getRoleUUID() + "=",
					"访问奖励数据库异常，PlayerGetUserPrize.doIo error, passportId : "
							+ player.getPassportId() + ";prizeId=" + prizeId);
		}
		return false;
	}
	
	/**
	 * 将奖励变为邮件发给玩家
	 */
	private void prizeToMail() {
		if (hList == null || hList.isEmpty()) {
			return;
		}
		
		long roleId = player.getCharId();
		for (UserPrizeHolder uph : hList) {
			Reward reward = uph.toReawrd(roleId);
			String info = uph.getPrizeInfo();
			Globals.getMailService().sendSysMail(roleId, MailType.SYSTEM, info, info, reward);
		}
	}
	
	@Override
	public long getBindUUID() {
		return this.player.getRoleUUID();
	}

}