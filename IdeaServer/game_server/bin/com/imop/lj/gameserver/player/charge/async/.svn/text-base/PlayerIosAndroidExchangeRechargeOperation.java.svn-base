package com.imop.lj.gameserver.player.charge.async;

import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.ExchangeRechargeResponse;

/**
 * ios和Android充值直冲兑换接口
 *
 *
 * 注:对于目前是对Android充值调用,ios 91 充值没有调用这个接口
 */
public class PlayerIosAndroidExchangeRechargeOperation implements LocalBindUUIDIoOperation {

	private static final Logger logger = Loggers.chargeLogger;

//	private IIosAndroidExchangeRechargeOperationCallback callback;

	private long roleUUID;

	private List<com.imop.platform.local.response.QueryRechargeResponse.Order> queryOrderList;

	private List<com.imop.platform.local.response.ExchangeRechargeResponse.Order> exchangeOrderList;

//	private boolean pass = false;

	public PlayerIosAndroidExchangeRechargeOperation(long roleUUID, List<com.imop.platform.local.response.QueryRechargeResponse.Order> queryOrderList,IIosAndroidExchangeRechargeOperationCallback callback) {
		this.roleUUID = roleUUID;
//		this.callback = callback;
		this.queryOrderList = queryOrderList;
	}

	@Override
	public int doIo() {
		try {
			Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
			if (player == null) {
				// 直接结束
				return STAGE_STOP_DONE;
			}
			final Human _human = player.getHuman();
			if (_human == null) {
				// 直接结束
				return STAGE_STOP_DONE;
			}
			StringBuilder pids = new StringBuilder();

			for(int i= 0 ; i < queryOrderList.size() ; i++){
				com.imop.platform.local.response.QueryRechargeResponse.Order queryOrder = queryOrderList.get(i);
				pids.append(queryOrder.id);
				if(i < queryOrderList.size() - 1){
					pids.append(",");
				}
			}

			logger.info("PlayerIosAndroidExchangeRechargeOperation.doIo.ExchangeRecharge "
					+ "passportId" + player.getPassportId() + ";"
					+ "uuid=" + player.getHuman().getUUID() + ";"
					+ "ip=" + player.getClientIp() + ";"
					+ "deviceID=" + player.getDeviceID() + ";");
			ExchangeRechargeResponse _response = Globals.getSynLocalService().iosAndroidExchangeRechargePayment(player.getRoleUUID(), 
					pids.toString(), player.getClientIp(), Globals.getTimeService().now());

			if(_response.isSuccess()){
				exchangeOrderList = _response.getRecharge();
				if(null == exchangeOrderList || exchangeOrderList.size() <= 0){
					logger.error("PlayerIosAndroidExchangeRechargeOperation.doIo.ExchangeRecharge order is null"
							+ "passportId" + player.getPassportId() + ";"
							+ "uuid=" + player.getHuman().getUUID() + ";"
							+ "ip=" + player.getClientIp() + ";"
							+ "deviceID=" + player.getDeviceID() + ";");
					return STAGE_STOP_DONE;
				}
				
				//直接往公共场景发消息，给玩家充值 XXX 2016/3/30
				IMessage msg = new SysInternalMessage() {
					@Override
					public void execute() {
						Globals.getChargeLogicalProcessor().chargeBond(_human, exchangeOrderList);
					}
				};
				Globals.getSceneService().getCommonScene().putMessage(msg);
			}
//			pass = true;
		} catch (Exception e) {
			logger.error("PlayerIosAndroidExchangeRechargeOperation :" + e);
		}
		return STAGE_STOP_DONE;
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
		//XXX 改为直接在doIO中，发消息给公共场景，给玩家充值 2016/3/30
//		if(pass){
//			if(exchangeOrderList == null){
//				exchangeOrderList = new ArrayList<com.imop.platform.local.response.ExchangeRechargeResponse.Order>();
//			}
//			//TODO 日志
//			callback.afterCheckComplete(roleUUID, exchangeOrderList);
//		}
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
