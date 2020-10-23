package com.imop.lj.gameserver.player.async;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.charge.async.ChargeOrderInfo;

/**
 * 生成充值订单Id
 *
 */
public class GenerateOrderIdOperation implements LocalBindUUIDIoOperation {
	private static final Logger logger = Loggers.chargeLogger;

	private long roleUUID;
	
	private String gameOrderId;
	
	private String channelCode;
	
	private String channelExt;
	
	private GenerateOrderIdCallBack callBack;
	
	public GenerateOrderIdOperation(long roleUUID,String channelCode,String channelExt, GenerateOrderIdCallBack callBack) {
		this.roleUUID = roleUUID;
		this.channelCode = channelCode;
		this.channelExt = channelExt;
		this.callBack = callBack;
	}
	
	@Override
	public int doIo() {
		try {
			Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
			if (player == null) {
				// 直接结束
				return STAGE_STOP_DONE;
			}
			Human human = player.getHuman();
			if (human == null) {
				// 直接结束
				return STAGE_STOP_DONE;
			}
			
			if (channelCode != null && !channelCode.isEmpty()) {
				gameOrderId = Globals.getChargeLogicalProcessor().generateOrder(player, channelCode, channelExt);
			} else {
				gameOrderId = Globals.getChargeLogicalProcessor().generateOrder(player);
			}
			
			Loggers.chargeLogger.info("roleUUID=" + roleUUID + ";gameOrderId=" + gameOrderId);
			
		} catch (Exception e) {
			logger.error("GenerateOrderIdOperation :" + e);
			return IIoOperation.STAGE_STOP_DONE;
		}
		
		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		ChargeOrderInfo orderInfo = new ChargeOrderInfo();
		orderInfo.setOrderId(gameOrderId);	
		callBack.afterCheckComplete(roleUUID, orderInfo, true);

		return IIoOperation.STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}

}
