package com.imop.lj.gameserver.player.charge.async;

import net.sf.json.JSONObject;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * ios91充值校验
 *
 *
 * 注:对于AppStore验证成功但是TranscationEntity已经记录过此订单的情况,pass标记位仍然为true,
 */
public class Player91IosChargeOperation implements LocalBindUUIDIoOperation {

	private IChargeCallBack callback;

	private long roleUUID;

	private String chargeData = null;

	private String checkData = "";

	private boolean isSuccess = false;

	private ChargeOrderInfo orderInfo;

	public Player91IosChargeOperation(long roleUUID, String chargeData, String checkData, IChargeCallBack callback) {
		this.roleUUID = roleUUID;
		this.chargeData = chargeData;
		this.checkData = checkData;
		this.callback = callback;
		this.orderInfo = new ChargeOrderInfo();
	}

	@Override
	public int doIo() {
		do {
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

				String response = null;
				// json.accumulate("chargeData", chargeData);
				// json.accumulate("checkData", checkData);
				// response =
				// "{\"receipt\":{\"item_id\":\"457804408\", \"original_transaction_id\":\"1000000007213442\", \"bvrs\":\"1.0.1\", \"product_id\":\"iron.one\", \"purchase_date\":\"2011-09-07 14:59:23 Etc/GMT\", \"quantity\":\"1\", \"bid\":\"com.renren.gamecenter\", \"original_purchase_date\":\"2011-09-07 14:59:23 Etc/GMT\", \"transaction_id\":\"1000000007213442\"}, \"status\":0}";
				// response = json.toString();
				response = checkAppleBusinessReq(this.chargeData,this.checkData);
				if (response == null || "".equals(response)) {
					return STAGE_IO_DONE;
				}

				JSONObject json = JSONObject.fromObject(response);
				Loggers.playerLogger.warn("transaction " + response);

				String productid = String.valueOf(json.get("product_id"));
				// TODO 展示将checkData作为transcationid
				String transcationid = String.valueOf(json.get("transcationid"));

				int mmCost = json.getInt("mm_cost");

//				List<TranscationEntity> transcations = Globals.getDaoService().getTranscationDao().QueryTranscationByTranscationId(transcationid);
//
//				if (transcations == null || transcations.size() == 0) {
//
//					orderInfo.setUser_id(player.getId());
//					//TODO 不通过平台91充值没有余额
//					orderInfo.setBalance(0);
//					orderInfo.setOrderId(transcationid);
//					orderInfo.setAmount(mmCost);
//					orderInfo.setCurrency("CNY");
//					orderInfo.setChargeType("iosexpand");
//					orderInfo.setPay_channel("sj91");
//					orderInfo.setSub_channel("");
//					orderInfo.setTerminal("ios");
//					orderInfo.setGamepoint(mmCost);
//
//					TranscationEntity transcationEntity = new TranscationEntity();
//					transcationEntity.setRoleId(player.getHuman().getUUID());
//					transcationEntity.setProductid(productid);
//					transcationEntity.setTranscationid(transcationid);
//					transcationEntity.setParam(response);
//					transcationEntity.setRegionid(Globals.getServerConfig().getRegionId());
//					transcationEntity.setServerid(Globals.getServerConfig().getServerId());
//					transcationEntity.setRolename(player.getHuman().getName());
//					transcationEntity.setUserid(player.getPassportId());
//					transcationEntity.setUsername(player.getPassportName());
//					transcationEntity.setUpdatetime(new Timestamp(Globals.getTimeService().now()));
//					Globals.getDaoService().getTranscationDao().save(transcationEntity);
//
//					isSuccess = true;
//				} else {
//					Loggers.playerLogger.error("transaction is exist id:" + transcationid);
//				}
			} catch (Exception e) {
				Loggers.playerLogger.error("ChargeIos91Operation :" + e);
			}
		} while (false);
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
		if(isSuccess){
			callback.afterCheckComplete(this.roleUUID, orderInfo, isSuccess);
		}
		return STAGE_STOP_DONE;
	}

	private String checkAppleBusinessReq(String data,String checkData) {
		if (data == null || data.equalsIgnoreCase("")) {
			return null;
		}

		JSONObject json = new JSONObject();

		String[] datas = data.split(",");
		if (datas.length != 3) {
			return null;
		}
		try {
			// product_id
			String productId = datas[0];
			// mm_cost
			Integer mm_cost = Integer.parseInt(datas[1]);
			// transcationid
			String transcationid = datas[2];
			json.put("product_id", productId);
			json.put("mm_cost", mm_cost);
			json.put("transcationid", transcationid);
			return json.toString();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;

	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
