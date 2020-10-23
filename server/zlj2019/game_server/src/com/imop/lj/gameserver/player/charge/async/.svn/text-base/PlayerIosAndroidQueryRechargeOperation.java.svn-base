package com.imop.lj.gameserver.player.charge.async;

import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.QueryRechargeResponse;
import com.imop.platform.local.response.QueryRechargeResponse.Order;

/**
 * ios和Android充值直冲查询接口
 *
 *
 * 注:对于目前是对Android充值调用,ios 91 充值没有调用这个接口
 */
public class PlayerIosAndroidQueryRechargeOperation implements LocalBindUUIDIoOperation {

	private static final Logger logger = Loggers.chargeLogger;

	private IIosAndroidQueryRechargeOperationCallback callback;

	private long roleUUID;

	private List<Order> orderList;

	private boolean pass = false;

	public PlayerIosAndroidQueryRechargeOperation(long roleUUID, IIosAndroidQueryRechargeOperationCallback callback) {
		this.roleUUID = roleUUID;
		this.callback = callback;
	}

	@Override
	public int doIo() {
		try {
			Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
			if (player == null) {
				// 直接结束
				return STAGE_STOP_DONE;
			}
			Human _human = player.getHuman();
			if (_human == null) {
				// 直接结束
				return STAGE_STOP_DONE;
			}

			logger.info("PlayerIosAndroidQueryRechargeOperation.doIo.QueryRecharge "
					+ "passportId" + player.getPassportId() + ";"
					+ "uuid=" + player.getHuman().getUUID() + ";"
					+ "ip=" + player.getClientIp() + ";"
					+ "deviceID=" + player.getDeviceID() + ";");
			QueryRechargeResponse _response = Globals.getSynLocalService().iosAndroidQueryRechargePayment(player.getRoleUUID(), player.getClientIp(), Globals.getTimeService().now());

			if(_response.isSuccess()){
				orderList = _response.getRecharge();
				if(null == orderList || orderList.size() <= 0){
					logger.error("PlayerIosAndroidQueryRechargeOperation.doIo.QueryRecharge order is null"
							+ "passportId" + player.getPassportId() + ";"
							+ "uuid=" + player.getHuman().getUUID() + ";"
							+ "ip=" + player.getClientIp() + ";"
							+ "deviceID=" + player.getDeviceID() + ";");
					return STAGE_STOP_DONE;
				}
			}
			pass = true;
		} catch (Exception e) {
			logger.error("PlayerIosAndroidQueryRechargeOperation :" + e);
		}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			return IIoOperation.STAGE_STOP_DONE;
		}
		Human human = player.getHuman();
		if (human == null) {
			return IIoOperation.STAGE_STOP_DONE;
		}
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if(pass){
			//TODO 日志
			callback.afterCheckComplete(roleUUID, orderList);
		}
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
