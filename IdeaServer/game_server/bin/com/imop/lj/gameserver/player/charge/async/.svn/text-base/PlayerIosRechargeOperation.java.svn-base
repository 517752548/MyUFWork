package com.imop.lj.gameserver.player.charge.async;

import org.slf4j.Logger;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.PMKey;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.PM;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.platform.local.response.IOSRechargeResponse;

/**
 * ipad充值校验
 *
 * 注:对于AppStore验证成功但是TranscationEntity已经记录过此订单的情况,pass标记位仍然为true,
 */
public class PlayerIosRechargeOperation implements LocalBindUUIDIoOperation {

	private static final Logger logger = Loggers.chargeLogger;

	private IIosRechargeCallback callback;

	private boolean isSuccess = false;

	private String chargeData = null;

	/** player的uuid */
	private long roleUUID;

	public PlayerIosRechargeOperation(long roleUUID,String chargeData,IIosRechargeCallback callback) {
		this.roleUUID = roleUUID;
		this.chargeData = chargeData;
		this.callback = callback;
	}

	@Override
	public int doIo() {
		try{
			if(chargeData == null || "".equalsIgnoreCase(chargeData)){
				return STAGE_STOP_DONE;
			}
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

			String item_table = "";
//			TerminalTypeEnum terminalTypeEnum = player.getCurrTerminalType();
//			switch (terminalTypeEnum) {
//			case IPHONE:
//			case IPAD:
//				item_table = Globals.getIpadChargeService().getItemTable(player.getAppid());
//				break;
//			default:
//				break;
//			}
//
//			if("".equalsIgnoreCase(item_table)){
//				return STAGE_IO_DONE;
//			}


//			String response = null;
//			JSONObject json = new JSONObject();
//			json.accumulate("receipt-data", chargeData);
//				response = "{\"receipt\":{\"item_id\":\"457804408\", \"original_transaction_id\":\"1000000007213442\", \"bvrs\":\"1.0.1\", \"product_id\":\"iron.one\", \"purchase_date\":\"2011-09-07 14:59:23 Etc/GMT\", \"quantity\":\"1\", \"bid\":\"com.renren.gamecenter\", \"original_purchase_date\":\"2011-09-07 14:59:23 Etc/GMT\", \"transaction_id\":\"1000000007213442\"}, \"status\":0}";
//				response = checkAppleBusinessReq(json.toString());
			logger.info("PlayerIosRechargeOperation.doIo.iosRecharge "
					+ "passportId" + player.getPassportId() + ";"
					+ "uuid=" + player.getHuman().getUUID()  + ";"
					+ "ip=" + player.getClientIp()  + ";"
					+ "item_table="+ item_table  + ";"
					+ "chargeData=" + chargeData  + ";"
					+ "deviceID=" + player.getDeviceID()  + ";"
					+ "guid=" + player.getDeviceID() + ";"
					);
//			CreateIOSPaymentResponse _response = Globals.getSynLocalService().createIOSPayment(player.getPassportId(), player.getHuman().getUUID() + "", player.getClientIp(), item_table, chargeData, player.getDeviceID(), player.getDeviceID());
			IOSRechargeResponse _response = Globals.getSynLocalService().iosRecharge(player.getPassportId(),
					player.getPassportName(),
					human.getUUID(),
					human.getName(),
					player.getClientIp(),
					item_table,
					chargeData,
					player.getDeviceID(),
					player.getDeviceID(),
					player.getDeviceType(),
					player.getDeviceVersion());
//			String[] infos = {"ok","1","1000000007213442","sz.1001"};
//			CreateIOSPaymentResponse _response = new CreateIOSPaymentResponse(infos);
//			_response.onSuccess(infos);

			if(_response.isSuccess()){
				//1：    正常情况
				//5000： IOS票据为空
				//5001： IOS请求失败
				//5002： IOS黑名单用户
				//5003： IOS票据错误
				//5004： IOS套餐ID错误
				//5005： IOS票据重复使用
				//5000+：通过PMC直接返回的错误值
				//5999： 充值成功，但是受到封禁，N小时自动解封

				//1：    正常情况
				if(_response.getStatus() == 1){
					isSuccess = true;

					//ios充值信息
//					TranscationEntity transcationEntity = new TranscationEntity();
//					transcationEntity.setRoleId(player.getHuman().getUUID());
//					transcationEntity.setProductid(_response.getProduct_id());
//					transcationEntity.setTranscationid(_response.getTransaction_id());
//					transcationEntity.setRegionid(Globals.getServerConfig().getRegionId());
//					transcationEntity.setServerid(Globals.getServerConfig().getServerId());
//					transcationEntity.setRolename(player.getHuman().getName());
//					transcationEntity.setUserid(player.getPassportId());
//					transcationEntity.setUsername(player.getPassportName());
//					transcationEntity.setUpdatetime(new Timestamp(Globals.getTimeService().now()));
//					Globals.getDaoService().getTranscationDao().save(transcationEntity);

					return STAGE_IO_DONE;
				}else if(_response.getStatus() == 5999){
					//5999： 充值成功，但是受到封禁，N小时自动解封
					isSuccess = true;
					//ios充值信息
//					TranscationEntity transcationEntity = new TranscationEntity();
//					transcationEntity.setRoleId(player.getHuman().getUUID());
//					transcationEntity.setProductid(_response.getProduct_id());
//					transcationEntity.setTranscationid(_response.getTransaction_id());
//					transcationEntity.setRegionid(Globals.getServerConfig().getRegionId());
//					transcationEntity.setServerid(Globals.getServerConfig().getServerId());
//					transcationEntity.setRolename(player.getHuman().getName());
//					transcationEntity.setUserid(player.getPassportId());
//					transcationEntity.setUsername(player.getPassportName());
//					transcationEntity.setUpdatetime(new Timestamp(Globals.getTimeService().now()));
//					Globals.getDaoService().getTranscationDao().save(transcationEntity);
					return STAGE_IO_DONE;
				}else if(_response.getStatus() == 5000){
					//5000： IOS票据为空
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_5000);
					return STAGE_STOP_DONE;
				}else if(_response.getStatus() == 5001){
					//5001： IOS请求失败
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_5001);
					return STAGE_STOP_DONE;
				}else if(_response.getStatus() == 5002){
					//5002： IOS黑名单用户
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_5002);
					return STAGE_STOP_DONE;
				}else if(_response.getStatus() == 5003){
					//5003： IOS票据错误
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_5003);
					return STAGE_STOP_DONE;
				}else if(_response.getStatus() == 5004){
					//5004： IOS套餐ID错误
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_5004);
					return STAGE_STOP_DONE;
				}else if(_response.getStatus() == 5005){
					//5005： IOS票据重复使用
					player.getHuman().sendSystemMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_5005);
					return STAGE_STOP_DONE;
				}else{
//					player.getHuman().sendMessage(LangConstants.IOS_CHARGE_CHECK_FAIL_ERROR);
					return STAGE_STOP_DONE;
				}
			}else{
				int errno = _response.getErrorCode();
				if (errno == 1) {
					// 签名错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "sing error!").tos()));
					}
				} else if (errno == 2) {
					// 时间戳错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", PM.kv(PMKey.REASON, "time error!")
								.tos()));
					}
				} else if (errno == 3) {
					// 参数格式错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "Parameter error!").tos()));
					}
				} else if (errno == 4) {
					// 充值接口被关闭
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo",
								PM.kv(PMKey.REASON, "charge close!").tos()));
					}
				} else {
					// 未知错误
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL, "#GS.PlayerChargeDiamond.doIo", PM
								.kv(PMKey.REASON, "Unknown error!").tos()));
					}
				}
				logger.error("transaction error " + _response.getErrorCode());
				return STAGE_STOP_DONE;
			}
		}
		catch(Exception e){
			logger.error("CheckChargeIpadOperation.doIo :", e);
			e.printStackTrace();
		}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
		if (player == null) {
			return IIoOperation.STAGE_IO_DONE;
		}
		Human human = player.getHuman();
		if (human == null) {
			return IIoOperation.STAGE_IO_DONE;
		}
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if(isSuccess){
			callback.afterCheckComplete(this.roleUUID,isSuccess);
		}

		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
