package com.imop.lj.gameserver.player.async;

import org.slf4j.Logger;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.prize.PlatformPrizeHolder;
import com.imop.lj.gameserver.prize.PrizeDef;
import com.imop.lj.gameserver.prize.msg.GCPrizeSuccess;
import com.imop.platform.local.response.GetGoodsResponse;


/**
 * 领取奖励
 * 
 * 
 */
public class PlayerGetPlatformPrize implements LocalBindUUIDIoOperation {

	private final static Logger logger = Loggers.prizeLogger;

	private Player player;
	/** 奖励编号 */
	private int prizeId;
	/** 奖励内容 */
	private volatile PlatformPrizeHolder prize;
	/** 平台奖励唯一ID */
	private volatile int uniqueId;
	/** 奖励reason */
	private volatile LogReasons.PrizeLogReason reason = null;
	/** 获取平台奖励物品 */
	private volatile GetGoodsResponse response;

	public PlayerGetPlatformPrize(Player player, int uniqueId, int prizeId) {
		this.player = player;
		this.prizeId = prizeId;
		this.uniqueId = uniqueId;
	}

	@Override
	public int doStart() {

		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		// 查询奖励
		try {
			prize = Globals.getPrizeService().fetchPlatformPrizeByPrizeId(uniqueId, prizeId);
		} catch (IllegalArgumentException ex) {
			logger.error("数据库奖励配置错误，prizeId : " + prizeId, ex);
			player.sendErrorMessage(LangConstants.PRIZE_GET_FAIL);
		} catch (Exception ex) {
			logger.error("查询平台奖励时，从本地数据库中查询出错，prizeId : " + prizeId, ex);
			player.sendErrorMessage(LangConstants.PRIZE_GET_FAIL);
		}

		if (prize == null) {
			logger.error("查询平台奖励时，从本地数据库中查询出错，没有找到要的东西，prizeId : " + prizeId);
			player.sendErrorMessage(LangConstants.PRIZE_GET_FAIL);
			return IIoOperation.STAGE_IO_DONE;
		}

		// 奖品不可以领取
		if (!prize.checkPlayerCanGet(player)) {
			return IIoOperation.STAGE_IO_DONE;
		}

		// 更新数据库记录
		try {
			response = Globals.getSynLocalService().getGoods(player.getPassportId(), player.getRoleUUID() + "",	player.getClientIp(), uniqueId, prizeId);
		} catch (Exception ex) {
			logger.error(LogUtils.buildLogInfoStr(Long.toString(player.getRoleUUID()),	"玩家在领取平台奖励时出错"), ex);
		}

		// 根据错误码进行信息提示
		switch (response.getErrorCode()) {
		case 1:
		case 2:
		case 3:
		case 999:
			player.sendErrorMessage(LangConstants.PRIZE_GET_FAIL);
			break;
		case 4:
			player.sendErrorMessage(LangConstants.PRIZE_USER_ALREADY_FETCHED);
			break;
		}

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStop() {

		Human human = player.getHuman();
		try {

			// 更新成功
			if (response != null && response.isSuccess()) {
				// 判断返回的奖励ID是否一致
				if (response.getPrizeId() != prizeId) {
					logger.error(String.format(
							"请求领取的奖励居然的要领取的奖励不一致！平台ID：%d，奖励ID：%d",
							uniqueId, prizeId));
					player.sendErrorMessage(LangConstants.PRIZE_GET_FAIL);
				} else {
					// 再次执行检查
					if (!prize.checkPlayerCanGet(player)) {
						reason = LogReasons.PrizeLogReason.PRIZE_FAIL_USER_PRIZE_AFTER_UNMEET;
					} else {
						// 给玩家发奖
						prize.doPrizePlayer(player);
						player.sendSystemMessage(LangConstants.PRIZE_PLATFORM_FETCH_SUCCESS);
						reason = LogReasons.PrizeLogReason.PRIZE_SUCCESS;
						// 向玩家发送奖励领取成功信息
						GCPrizeSuccess gcPrizeSuccess = new GCPrizeSuccess();
						gcPrizeSuccess.setPrizeId(Integer.toString(prizeId));
						gcPrizeSuccess.setPrizeType(1);						
						gcPrizeSuccess.setUniqueId(uniqueId);
						player.sendMessage(gcPrizeSuccess);
						
						// 领取奖励后，重新获取礼包列表
						Globals.getPrizeService().sendPrizeListMsg(player);
					}
				}
			}

			// 发送领取奖励的日志
			if (reason != null) {
				Globals.getLogService().sendPrizeLog(human, reason, "",
						human.getSceneId(),
						PrizeDef.PRIZE_TYPE_PLATFORM, prizeId);
			}

		} catch (Exception ex) {
			logger.error(LogUtils.buildLogInfoStr(Long.toString(player.getRoleUUID()), String.format("给玩家平台奖励时出错，平台ID：%d，奖励ID：%d", uniqueId, prizeId)));
		} 
		return IIoOperation.STAGE_STOP_DONE;
	}
	
	@Override
	public long getBindUUID() {
		return player.getRoleUUID();
	}

}