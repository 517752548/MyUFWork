package com.imop.lj.gameserver.charge;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import org.slf4j.Logger;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ChargeLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.behavior.bindid.BindIdBehaviorTypeEnum;
import com.imop.lj.gameserver.charge.template.ChargeTemplate;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerChargeDiamondEvent;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.currency.CurrencyProcessor;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerQueryAccount;
import com.imop.lj.gameserver.player.charge.async.ChargeOrderInfo;
import com.imop.lj.gameserver.player.charge.async.IChargeCallBack;
import com.imop.lj.gameserver.player.charge.async.IIosAndroidExchangeRechargeOperationCallback;
import com.imop.lj.gameserver.player.charge.async.IIosAndroidQueryRechargeOperationCallback;
import com.imop.lj.gameserver.player.charge.async.IIosRechargeCallback;
import com.imop.lj.gameserver.player.charge.async.PlayerChargeDiamond;
import com.imop.lj.gameserver.player.charge.async.PlayerIosAndroidExchangeRechargeOperation;
import com.imop.lj.gameserver.player.charge.async.PlayerIosAndroidQueryRechargeOperation;
import com.imop.lj.gameserver.player.charge.async.PlayerIosRechargeOperation;
import com.imop.lj.gameserver.player.msg.GCChargeRecord;
import com.imop.lj.gameserver.player.msg.GCPlayerChargeDiamond;
import com.imop.platform.local.response.GenerateOrderResponse;

public class ChargeLogicalProcessor implements InitializeRequired{

	public static final Logger CHARGE_LOGGER = Loggers.chargeLogger;

	public ChargeLogicalProcessor() {

	}
	
	public void init() {
		Set<Integer> rmbSet = new HashSet<Integer>();
		for (ChargeTemplate tpl : Globals.getTemplateCacheService().getAll(ChargeTemplate.class).values()) {
			if (!rmbSet.add(tpl.getRmb())) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "充值RMB数量不能相同！" + tpl.getRmb());
			}
		}
	}

	/**
	 * 查询MM数量 : 相当于打开充值面板，按照充值类型不同返回不同数据
	 *
	 * @param player
	 */
	public void queryPlayerAccount(Player player) {
		if (!Globals.getServerConfig().getFuncSwitches().isChargeEnabled()) {
			player.sendSystemMessage(LangConstants.FUNC_INVALID);
			return;
		}

		Human human = player.getHuman();
		if (human == null) {
			return;
		}

		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			player.sendSystemMessage(LangConstants.LOCAL_TURN_OFF);
			return;
		}

		PlayerQueryAccount _queryOper = new PlayerQueryAccount(player.getRoleUUID());
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_queryOper, player.getRoleUUID());
	}

	/**
	 * 人人平台兑换模式：MM兑换金币公式
	 *
	 * @param mmCount
	 * @return
	 */
	protected int getGoldConvertedRenRenPlatform(int mmCount) {
		return mmCount * Globals.getServerConfig().getChargeMM2DiamondRate();
		// return mmCount;
	}

//	/**
//	 * 91平台兑换模式：MM兑换金币公式
//	 *
//	 * @param mmCount
//	 * @return
//	 */
//	protected int getGoldConvertedSJ91Platform(int mmCount) {
//		int gamePoint = 0;
//		switch(mmCount){
//		case 10:
//		gamePoint = 32;
//		break;
//		case 30:
//			gamePoint = 103;
//			break;
//		case 80:
//			gamePoint = 312;
//			break;
//		case 300:
//			gamePoint = 1452;
//			break;
//		default:
//			gamePoint = (int)Math.floor(mmCount * 4.9f);
//			break;
//		}
//		return gamePoint;
//	}

	/**
	 * 自由兑换模式：玩家充入金币，使用MM兑换金币
	 *
	 * @param player
	 * @param mmCost
	 *            要兑换多少MM
	 */
	public void chargeGold(Player player, int mmCost) {
		if (!Globals.getServerConfig().getFuncSwitches().isChargeEnabled()) {
			player.sendErrorMessage(LangConstants.GAME_CHARGE_SWITCH_CLOSED);
			return;
		}

		if (player == null) {
			return;
		}

		Human _human = player.getHuman();
		if (_human == null) {
			return;
		}

		if (mmCost > SharedConstants.MAX_EXCHANGE_MM) {
			// 兑换的MM太多了
			player.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_MM_TOO_MANY);
			return;
		}
		if (mmCost > 0) {
			int _diamondConv = getGoldConvertedRenRenPlatform(mmCost);// 可以兑换成多少金币

			if (!validateDiamondCount(_diamondConv)) {
				// MM 数量不正确
				player.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_MM_ILLEGAL);
				return;
			}

			long _diamondBefore = _human.getAllBond();
			long _diamondWill = _diamondBefore + _diamondConv;

			if (_diamondWill <= 0 || _diamondWill > SharedConstants.MAX_DIAMOND_CARRY_AMOUNT) {
				// 钻石已经太多了，再充下去会溢出的
				player.sendSystemMessage(LangConstants.GAME_BEFORE_CHARGE_DIAMOND_OVER_FLOW);
				return;
			}
			PlayerChargeDiamond _chargOper = new PlayerChargeDiamond(player.getRoleUUID(), mmCost, new IChargeCallBack() {
				@Override
				public void afterCheckComplete(long roleUUID, final ChargeOrderInfo orderInfo, boolean isSuccess) {
					if (!isSuccess) {
						return;
					}
					Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
					if (player == null) {
						// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值,平台返回成功，但是给不了钱了
						Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID+"", "调用充值接口成功，但是给用户金钱时失败"));
						return;
					}

					Human human = player.getHuman();
					if (human == null) {
						// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值,平台返回成功，但是给不了钱了
						Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID+"", "调用充值接口成功，但是给用户金钱时失败"));
						return;
					}

					int bondBefore = (int)human.getBond();
					int allBondBefore = (int)human.getAllBond();
					int amount = orderInfo.getGamepoints() != null ? Integer.parseInt(orderInfo.getGamepoints()) : 0;
					int addBond = getGoldConvertedRenRenPlatform(amount);
					// 增加的货币不能大于最高级
					if ((allBondBefore + addBond) <= 0 || (allBondBefore + addBond) > SharedConstants.MAX_DIAMOND_CARRY_AMOUNT) {
						player.sendSystemMessage(LangConstants.GAME_BEFORE_CHARGE_DIAMOND_OVER_FLOW);
						return;
					}
					
					if(addBond <= 0){
						Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID+"", "调用充值接口成功，但是返回金钱数是0:" + orderInfo.toString()));
						return;
					}

					CurrencyProcessor.instance.giveMoney(human, addBond, Currency.BOND, false, MoneyLogReason.REASON_MONEY_CHARGE_DIAMOND,
							MessageFormat.format(MoneyLogReason.REASON_MONEY_CHARGE_DIAMOND.getReasonText(), amount), true);

					human.snapChangedProperty(true);
					// 发送成功消息
					GCPlayerChargeDiamond _msg = new GCPlayerChargeDiamond(orderInfo.getBalance());
					player.sendMessage(_msg);
//					player.sendErrorMessage(LangConstants.GAME_CHARGE_DIAMOND_SUCCESS, "" + addBond);

					// 处理任务兑换钻石
					PlayerChargeDiamondEvent _event = new PlayerChargeDiamondEvent(human, addBond, false);
					Globals.getEventService().fireEvent(_event);

					int bondAfter = (int)human.getBond();

					orderInfo.setAddBond(addBond);
					orderInfo.setBondBefore(bondBefore);
					orderInfo.setBondAfter(bondAfter);

					Globals.getLocalScribeService().sendScribeGameIncomeReport(human, MoneyLogReason.REASON_MONEY_CHARGE_DIAMOND, orderInfo);

					// 发送充值日志
					Globals.getLogService().sendChargeLog(human, ChargeLogReason.CHARGE_DIAMOND_SUCCESS, "", Currency.BOND.getIndex(), bondBefore, bondAfter,
							amount, "", "");
				}
			});
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_chargOper, player.getRoleUUID());
		} else {
			// MM数量是负数
			player.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_MM_ILLEGAL);
		}
	}

	/**
	 * 验证钻石数量, 钻石数量中不应含有小数
	 *
	 * @param diamondCount
	 * @return
	 *
	 */
	protected static boolean validateDiamondCount(double diamondCount) {
		if (diamondCount <= 0) {
			return false;
		}

		// 将钻石数量向下取整
		double temp = Math.floor(diamondCount);
		// 取出小数部分
		double result = diamondCount - temp;

		// 判断小数部分是否为 0
		return result == 0;
	}

	public void chargeSandBoxIpadCheck(Player player, String chargeData) {
//		if (player == null) {
//			return;
//		}
//
//		Human human = player.getHuman();
//		if (human == null) {
//			return;
//		}
////		// XXX 没有绑定的quick登陆不能充值
////		if (player.isQuickLogin() && !player.isReadyBandQuickLogin()) {
////			player.getHuman().sendMessage(LangConstants.NOT_BAND_ACCOUNT_CAN_NOT_CHARGE);
////			return;
////		}
//
//		// 2. 通过HTTP异步执行校验
//		PlayerIosSandBoxChargeOperation playerIosSandBoxChargeOperation = new PlayerIosSandBoxChargeOperation(player.getRoleUUID(), chargeData, new IChargeCallBack() {
//			@Override
//			public void afterCheckComplete(long roleUUID,ChargeOrderInfo orderInfo,boolean isSuccess) {
//				if (!isSuccess) {
//					return;
//				}
//				Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
//				if (player == null) {
//					// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值,平台返回成功，但是给不了钱了
//					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID, "调用充值接口成功，但是给用户金钱时失败"));
//					return;
//				}
//
//				Human human = player.getHuman();
//				if (human == null) {
//					// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值,平台返回成功，但是给不了钱了
//					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID, "调用充值接口成功，但是给用户金钱时失败"));
//					return;
//				}
//				int bondBefore = human.getBond();
//				int allBondBefore = human.getAllBond();
//				int amount = orderInfo.getGamepoint();
//				int addBond = amount;
//
//				if ((allBondBefore + addBond) <= 0 || (allBondBefore + addBond) > SharedConstants.MAX_DIAMOND_CARRY_AMOUNT) {
//					player.sendSystemMessage(LangConstants.GAME_BEFORE_CHARGE_DIAMOND_OVER_FLOW);
//					return;
//				}
//
//				if(addBond <= 0){
//					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID, "调用充值接口成功，但是返回金钱数是0:" + orderInfo.toString()));
//					return;
//				}
//
//				MoneyLogReason moneyReason = null;
//				String moneyParam = null;
//				ChargeLogReason chargeReason = null;
//				String chargeParam = null;
//
//				switch (player.getCurrTerminalType()) {
//				case IPAD:
//					moneyReason = LogReasons.MoneyLogReason.IPAD_CHARGE;
//					moneyParam = MessageFormat.format(LogReasons.MoneyLogReason.IPAD_CHARGE.getReasonText(), addBond, "");
//					chargeReason = ChargeLogReason.CHARGE_IPAD_DIAMOND_SUCCESS;
//					chargeParam = "";
//					break;
//				case IPHONE:
//					moneyReason = LogReasons.MoneyLogReason.IPHONE_CHARGE;
//					moneyParam = MessageFormat.format(LogReasons.MoneyLogReason.IPHONE_CHARGE.getReasonText(), addBond, "");
//					chargeReason = ChargeLogReason.CHARGE_IPHONE_DIAMOND_SUCCESS;
//					chargeParam = "";
//					break;
//				default:
//					human.sendMessage(LangConstants.IOS_CHARGE_CHECK_FAIL);
//					return;
//				}
//
//				CurrencyProcessor.instance.giveMoney(human, addBond, Currency.BOND, false, moneyReason,moneyParam);
//
//				human.snapChangedProperty(true);
//				// 发送成功消息
//				GCPlayerChargeDiamond _msg = new GCPlayerChargeDiamond(orderInfo.getBalance());
//				player.sendMessage(_msg);
//				player.sendImportantMessage(LangConstants.GAME_CHARGE_DIAMOND_SUCCESS, "" + addBond);
//
//				// 处理任务兑换钻石
//				PlayerChargeDiamondEvent _event = new PlayerChargeDiamondEvent(human, addBond);
//				Globals.getEventService().fireEvent(_event);
//
//				// 玩家vip等级改变推消息。
//				human.onVipLevelChanged();
//				int bondAfter = human.getBond();
//
//				orderInfo.setAddBond(addBond);
//				orderInfo.setBondBefore(bondBefore);
//				orderInfo.setBondAfter(bondAfter);
//
//				Globals.getLocalScribeService().sendScribeGameIncomeReport(human, moneyReason, orderInfo);
//
//				// 发送充值日志
//				Globals.getLogService().sendChargeLog(human, chargeReason, chargeParam, Currency.BOND.getIndex(), bondBefore, bondAfter,
//						amount, "", orderInfo.getOrderId());
//				sendChargeCheckMsg(player, isSuccess, "", orderInfo.getOrderId());
//			}
//		});
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(playerIosSandBoxChargeOperation, player.getRoleUUID());
	}

	/**
	 * @param player
	 * @param chargeData
	 */
	public void chargeBuyIpadCheck(Player player, String chargeData) {
		if (player == null || player.getHuman() == null) {
			return;
		}

//		// XXX 没有绑定的quick登陆不能充值
//		if (player.isQuickLogin() && !player.isReadyBandQuickLogin()) {
//			player.getHuman().sendMessage(LangConstants.NOT_BAND_ACCOUNT_CAN_NOT_CHARGE);
//			return;
//		}

		// 2. 通过HTTP异步执行校验
		PlayerIosRechargeOperation playerIosRechargeOperation = new PlayerIosRechargeOperation(player.getRoleUUID(), chargeData, new IIosRechargeCallback() {
			@Override
			public void afterCheckComplete(long roleUUID, boolean isSuccess) {
				if (!isSuccess) {
					return;
				}
				Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
				if (player == null) {
					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "", "调用查询接口成功，但是给用户金钱时失败"));
					return;
				}

				Human human = player.getHuman();
				if (human == null) {
					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "", "调用查询接口成功，但是给用户金钱时失败"));
					return;
				}
				
				Globals.getChargeLogicalProcessor().iosAndroidCharge(player);

//				PlayerIosAndroidQueryRechargeOperation chargeIpadOperation = new PlayerIosAndroidQueryRechargeOperation(roleUUID,new IIosAndroidQueryRechargeOperationCallback() {
//					@Override
//					public void afterCheckComplete(long roleUUID,List<Order> orderList) {
//						Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
//						if (player == null) {
//							Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "", "调用查询接口成功，但是给用户金钱时失败"));
//							return;
//						}
//
//						Human human = player.getHuman();
//						if (human == null) {
//							Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID + "", "调用查询接口成功，但是给用户金钱时失败"));
//							return;
//						}
//
//						Globals.getChargeLogicalProcessor().iosAndroidCharge(player);
//					}
//				});
//				Globals.getAsyncService().createOperationAndExecuteAtOnce(chargeIpadOperation, player.getRoleUUID());
			}
		});
		Globals.getAsyncService().createOperationAndExecuteAtOnce(playerIosRechargeOperation, player.getRoleUUID());
	}

	/**
	 * 处理ipad版本的充值校验
	 *
	 * @param player
	 * @param chargeData
	 */
	public void chargeIpadCheck(Player player, String chargeData) {
		if (player == null || player.getHuman() == null) {
			return;
		}

		if (chargeData == null || chargeData.isEmpty()) {
			return;
		}
		
		// 开关判断
		if (!Globals.getServerConfig().isZhichongFlag()) {
			// 记录日志，直冲未开启
			Loggers.chargeLogger.warn("#ChargeLogicalProcessor#chargeIpadCheck#zhicongFlag is false!playerId=" + 
					player != null ? player.getPassportId() : "0");
			return;
		}
		
		boolean isIOS = false;
		TerminalTypeEnum terminalTypeEnum = player.getCurrTerminalType();
		if (terminalTypeEnum == TerminalTypeEnum.IPHONE 
				|| terminalTypeEnum == TerminalTypeEnum.IPAD) {
			isIOS = true;
		}
		if (!isIOS) {
			Loggers.chargeLogger.warn("#ChargeLogicalProcessor#chargeIpadCheck#player terminal type is not ios!playerId=" + 
					(player != null ? player.getPassportId() : "0") + ";terminalTypeEnum=" + terminalTypeEnum);
			return;
		}
		
		this.chargeBuyIpadCheck(player, chargeData);
		
//		if ("buy".equalsIgnoreCase(Globals.getServerConfig().getAppleStoreType())) {
//			this.chargeBuyIpadCheck(player, chargeData);
//		} else if ("sandbox".equalsIgnoreCase(Globals.getServerConfig().getAppleStoreType())) {
//			this.chargeSandBoxIpadCheck(player, chargeData);
//		}
	}

//	/**
//	 * 发送ipad充值成功或失败的消息
//	 *
//	 *
//	 * @param player
//	 * @param pass
//	 * @param productId
//	 * @param transcationId
//	 */
//	protected void sendChargeCheckMsg(Player player, boolean pass, String productId, String transcationId) {
//		if (player == null) {
//			return;
//		}
//
//		GCChargeIpadCheck msg = new GCChargeIpadCheck();
//		msg.setPass(pass);
//		msg.setProductId(productId);
//		msg.setTranscationId(transcationId);
//		if (pass) {
//			msg.setCheckMsg(Globals.getLangService().readSysLang(LangConstants.IPAD_CHARGE_SUCCESS));
//		} else {
//			msg.setCheckMsg(Globals.getLangService().readSysLang(LangConstants.IPAD_CHARGE_FAIL));
//		}
//
//		player.getHuman().sendMessage(msg);
//
//	}

	/**
	 * 处理91ios版本的充值校验
	 *
	 * @param player
	 * @param chargeData
	 */
	public void chargeIos91Check(Player player, String chargeData, String checkData) {
//		// 1. 基础数据校验
//		if (player == null) {
//			return;
//		}
//
//		Human human = player.getHuman();
//		if (human == null) {
//			return;
//		}
//
//		if (chargeData == null) {
//			return;
//		}
//		// 2. 通过HTTP异步执行校验
//		Player91IosChargeOperation chargeIos91Operation = new Player91IosChargeOperation(player.getRoleUUID(), chargeData, checkData, new IChargeCallBack() {
//			@Override
//			public void afterCheckComplete(long roleUUID,ChargeOrderInfo orderInfo,boolean isSuccess) {
//				if (!isSuccess) {
//					return;
//				}
//				Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
//				if (player == null) {
//					// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值,平台返回成功，但是给不了钱了
//					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID, "调用充值接口成功，但是给用户金钱时失败"));
//					return;
//				}
//
//				Human human = player.getHuman();
//				if (human == null) {
//					// 人已经不在无法继续，记录日志，可以通过日志帮玩家恢复充值,平台返回成功，但是给不了钱了
//					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID, "调用充值接口成功，但是给用户金钱时失败"));
//					return;
//				}
//
//				int bondBefore = human.getBond();
//				int allBondBefore = human.getAllBond();
//				int amount = orderInfo.getGamepoint();
//				int addBond = getGoldConvertedSJ91Platform(amount);
//				// 增加的货币不能大于最高级
//				if ((allBondBefore + addBond) <= 0 || (allBondBefore + addBond) > SharedConstants.MAX_DIAMOND_CARRY_AMOUNT) {
//					player.sendSystemMessage(LangConstants.GAME_BEFORE_CHARGE_DIAMOND_OVER_FLOW);
//					return;
//				}
//
//				if(addBond <= 0){
//					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(roleUUID, "调用充值接口成功，但是返回金钱数是0:" + orderInfo.toString()));
//					return;
//				}
//
//				CurrencyProcessor.instance.giveMoney(human, addBond, Currency.BOND, false, orderInfo.getMoneyLogReason(),
//						orderInfo.toString());
//
//				human.snapChangedProperty(true);
//				// 发送成功消息
////				GCPlayerChargeDiamond _msg = new GCPlayerChargeDiamond(orderInfo.getBalance());
////				player.sendMessage(_msg);
//				player.sendImportantMessage(LangConstants.GAME_CHARGE_DIAMOND_SUCCESS, "" + addBond);
//
//				// 处理任务兑换钻石
//				PlayerChargeDiamondEvent _event = new PlayerChargeDiamondEvent(human, addBond);
//				Globals.getEventService().fireEvent(_event);
//
//				// 玩家vip等级改变推消息。
//				human.onVipLevelChanged();
//				int bondAfter = human.getBond();
//
//				orderInfo.setAddBond(addBond);
//				orderInfo.setBondBefore(bondBefore);
//				orderInfo.setBondAfter(bondAfter);
//
//				Globals.getLocalScribeService().sendScribeGameIncomeReport(human, orderInfo.getMoneyLogReason(), orderInfo);
//
//				// 发送充值日志
//				Globals.getLogService().sendChargeLog(human, orderInfo.getChargeLogReason(), orderInfo.toString(), Currency.BOND.getIndex(), bondBefore, bondAfter,
//						amount, "", orderInfo.getOrderId());
//
//				sendChargeCheckMsg(player, isSuccess, "", orderInfo.getOrderId());
//			}
//		});
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(chargeIos91Operation, player.getRoleUUID());
	}
	
	public String generateOrder(Player player,String channelCode,String channelExt) {
		if (player == null) {
			// 直接结束
			return null;
		}
		
		Human human = player.getHuman();
		if (human == null) {
			// 直接结束
			return null;
		}

		String orderId = this.generateOrderId(player, channelCode, channelExt);
		
		return orderId;
	}
	
	public String generateOrder(Player player) {
		if (player == null) {
			// 直接结束
			return null;
		}
		
		Human human = player.getHuman();
		if (human == null) {
			// 直接结束
			return null;
		}

		String channelCode = this.getChannelCodeByFValue(player);
		
		String orderId = this.generateOrderId(player, channelCode, null);
		
		return orderId;
	}
	
	protected String getChannelCodeByFValue(Player player){
		if (player == null) {
			// 直接结束
			return null;
		}
		
		// 根据 fValue判定生成订单号是否要传入channelCode
		Loggers.chargeLogger.info("generateOrder " + "passportId" + player.getPassportId() + ";" + "uuid=" + player.getHuman().getUUID() + ";" + "ip="
				+ player.getClientIp() + ";" + "deviceID=" + player.getDeviceID() + ";" + "fValue=" + player.getfValue() + ";");
//		//如果是爱游戏 ，返回相应订单号 TODO
//		if(Globals.getOtherPlatformConstants().getEgame_fvalue().equalsIgnoreCase(player.getfValue())){
//			return AuthPlatform.EGAME.index + "";
//		}
		return null;
	}
	
	/**
	 * 生成一个服务器生成的订单号，由平台去验证
	 * 
	 * @param orderId
	 * @param player
	 * @return
	 */
	public String generateOrderId(Player player, String channelCode, String channelExt) {
		if (player == null) {
			// 直接结束
			return null;
		}
		Human human = player.getHuman();
		if (human == null) {
			// 直接结束
			return null;
		}

		String gameOrderId = null;

		try {
			// 用户实际IP地址
			String log_ip = human.getPlayer().getClientIp();
			// 去掉端口号
			if (log_ip.indexOf(":") != -1) {
				log_ip = log_ip.substring(0, log_ip.indexOf(":"));
			}

			// 账号ID
			String account_id = human.getPlayer().getPassportId();

			// 账号名（登录名）
			String account_name = human.getPlayer().getPassportName();

			// 角色ID
			String char_id = human.getCharId() + "";

			// 角色名
			String char_name = human.getName();

			// 终端设备分类：PC，IOS，Android
			String device = human.getCurrTerminalType().getTerminalTypeName();

			// 设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
			String device_type = human.getPlayer().getDeviceType();
			if (human.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				device_type = -1 + "";
			}

			// 操作系统版本，IOS和Android的版本，PC类型此项设置为-1
			String device_version = human.getPlayer().getDeviceVersion();
			if (human.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				device_version = -1 + "";
			}

			// 设备唯一识别id
			String guid = human.getPlayer().getDeviceID();
			if (human.getCurrTerminalType() == TerminalTypeEnum.WEB) {
				guid = -1 + "";
			}
			GenerateOrderResponse _response = null;
			if(channelCode != null && !"".equalsIgnoreCase(channelCode)){
				_response = Globals.getSynLocalService().generateOrder(account_id, account_name, char_id, char_name, device_type,
						device_version, log_ip, guid, guid, device,channelCode,channelExt);
				
			}else{
				_response = Globals.getSynLocalService().generateOrder(account_id, account_name, char_id, char_name, device_type,
						device_version, log_ip, guid, guid, device);
			}
			
			if (_response != null && _response.isSuccess()) {
				gameOrderId = _response.getGameOrderId();
				Loggers.chargeLogger.info("generateOrder " 
						+ "passportId" + player.getPassportId() + ";" 
						+ "uuid=" + player.getHuman().getUUID() + ";" 
						+ "ip=" + player.getClientIp() + ";" 
						+ "deviceID=" + player.getDeviceID() + ";" 
						+ "gameOrderId=" + gameOrderId + ";"
						+ "channelCode=" + channelCode
						+ ";channelExt=" + channelExt);
			} else {
				Loggers.chargeLogger.info("generateOrder " + "passportId" + player.getPassportId() + ";" + "uuid=" + player.getHuman().getUUID() + ";" + "ip="
						+ player.getClientIp() + ";" + "deviceID=" + player.getDeviceID() + ";" 
						+ "errorCode=" +_response == null? "response is null" : _response.getErrorCode() + ";"
						+ "channelCode=" + channelCode + ";channelExt=" + channelExt);
			}
			
			return gameOrderId;
		} catch (Exception e) {
			Loggers.chargeLogger.error("order generate is failed", e);
		}
		return gameOrderId;
	}

	/**
	 * IOS和android直冲查询
	 *
	 * @param player
	 * @param chargeData
	 */
	public void iosAndroidCharge(Player player) {
		// 开关判断
		if (!Globals.getServerConfig().isZhichongFlag()) {
			// 记录日志，直冲未开启
			Loggers.chargeLogger.warn("#ChargeLogicalProcessor#iosAndroidCharge#zhicongFlag is false!playerId=" + 
					player != null ? player.getPassportId() : "0");
			return;
		}

		// 1. 基础数据校验
		if (player == null) {
			return;
		}

		Human human = player.getHuman();
		if (human == null) {
			return;
		}

		PlayerIosAndroidQueryRechargeOperation queryRechargeOperation = new PlayerIosAndroidQueryRechargeOperation(player.getRoleUUID(),
				new IIosAndroidQueryRechargeOperationCallback() {
					@Override
					public void afterCheckComplete(long roleUUID, List<com.imop.platform.local.response.QueryRechargeResponse.Order> queryOrderList) {
						Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
						if (player == null || player.getHuman() == null || !player.isInScene()) {
							Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(String.valueOf(roleUUID), "调用查询接口成功，但是给用户金钱时失败1-chargefail1"));
							return;
						}

						Human human = player.getHuman();
						if (human.getBindIdBehaviorManager() == null) {
							Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(String.valueOf(roleUUID), "调用查询接口成功，但是给用户金钱时失败2-chargefail2"));
							return;
						}

						PlayerIosAndroidExchangeRechargeOperation exchangeRechargeOperation = new PlayerIosAndroidExchangeRechargeOperation(roleUUID,
								queryOrderList, new IIosAndroidExchangeRechargeOperationCallback() {

									@Override
									public void afterCheckComplete(long roleUUID,
											List<com.imop.platform.local.response.ExchangeRechargeResponse.Order> exchangeOrderList) {
										Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
										if (player == null || player.getHuman() == null || !player.isInScene()) {
											Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(String.valueOf(roleUUID), "调用查询接口成功，但是给用户金钱时失败3-chargefail3"));
											return;
										}

										Human human = player.getHuman();
										if (human.getBindIdBehaviorManager() == null) {
											Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(String.valueOf(roleUUID), "调用查询接口成功，但是给用户金钱时失败4-chargefail4"));
											return;
										}
										
										chargeBond(human, exchangeOrderList);
									}
								});
						Globals.getAsyncService().createOperationAndExecuteAtOnce(exchangeRechargeOperation, player.getRoleUUID());
					}
				});

		Globals.getAsyncService().createOperationAndExecuteAtOnce(queryRechargeOperation, player.getRoleUUID());
	}
	
	public void chargeBond(Human human, List<com.imop.platform.local.response.ExchangeRechargeResponse.Order> exchangeOrderList) {
		if (human == null) {
			Loggers.chargeLogger.error("调用查询接口成功，但是给用户金钱时失败5-chargefail5");
			return;
		}
		try {
			long roleUUID = human.getRoleUUID();
			for (com.imop.platform.local.response.ExchangeRechargeResponse.Order exchangeOrder : exchangeOrderList) {

				ChargeOrderInfo orderInfo = new ChargeOrderInfo();
				orderInfo.setUser_id(Long.parseLong(exchangeOrder.getUser_id()));
				//直冲没有balance
				orderInfo.setBalance(0);
				
				orderInfo.setOrderId(exchangeOrder.getOrder_id());
				orderInfo.setAmount(Double.parseDouble(exchangeOrder.getAmount()));
				orderInfo.setCurrency(exchangeOrder.getCurrency());
				orderInfo.setChargeType(exchangeOrder.getChargetype());
				orderInfo.setPay_channel(exchangeOrder.getPay_channel());
				orderInfo.setSub_channel(exchangeOrder.getSub_channel());
				orderInfo.setTerminal(exchangeOrder.getTerminal());
				orderInfo.setGamepoints(exchangeOrder.getGame_points());
				orderInfo.setType(exchangeOrder.getType());
//				orderInfo.setDevice_type(exchangeOrder.);// TODO no found device_type in exchangeOrder
//				orderInfo.setDevice_version(exchangeOrder.get);// TODO no found device_version in exchangeOrder
				orderInfo.setGame_code(exchangeOrder.getGame_code());
				orderInfo.setGame_domain(exchangeOrder.getGame_domain());
				orderInfo.setGame_server_domain(exchangeOrder.getGame_server_domain());
				orderInfo.setChar_id(exchangeOrder.getChar_id());
				orderInfo.setChar_name(exchangeOrder.getChar_name());
				orderInfo.setAdd_time(exchangeOrder.getAdd_time());
				orderInfo.setExpend_time(exchangeOrder.getExpend_time());
				orderInfo.setDelay_time(exchangeOrder.getDelay_time());
				orderInfo.setTerminal(exchangeOrder.getTerminal());
				orderInfo.setRemark(exchangeOrder.getRemark());
				orderInfo.setPay_channel(exchangeOrder.getPay_channel());
				orderInfo.setSub_channel(exchangeOrder.getSub_channel());
				orderInfo.setChargeType(exchangeOrder.getChargetype());
				
				//给过来的钱是分为单位的，除以100表示元
				int rmb = Integer.parseInt(orderInfo.getGamepoints()) / 100;
				if (rmb <= 0) {
					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(String.valueOf(roleUUID), "调用充值接口成功，但是gamepoint是0:" + 
							"rmb=" + rmb + ";" + ";orderInfo.getGamepoints()=" + orderInfo.getGamepoints() + ";" + orderInfo.toString()));
					continue;
				}
				
				//找钱数对应的模板
				ChargeTemplate chargeTpl = null;
				for (ChargeTemplate cTpl : Globals.getTemplateCacheService().getAll(ChargeTemplate.class).values()) {
					if (cTpl.getRmb() == rmb) {
						chargeTpl = cTpl;
						break;
					}
				}
				
				int bondBefore = (int)human.getBond();// 元宝
				long allBondBefore = human.getAllBond();
				int amount = chargeTpl != null ? chargeTpl.getBond() : ((Integer.parseInt(orderInfo.getGamepoints()) * Globals.getServerConfig().getChargeMM2DiamondRate()) / 100);
				int addBond = amount;
				// 增加的货币不能大于最高级
				if ((allBondBefore + addBond) <= 0 || (allBondBefore + addBond) > SharedConstants.MAX_DIAMOND_CARRY_AMOUNT) {
					human.sendSystemMessage(LangConstants.GAME_BEFORE_CHARGE_DIAMOND_OVER_FLOW);
					return;
				}

				if(addBond <= 0){
					Loggers.chargeLogger.error(LogUtils.buildLogInfoStr(String.valueOf(roleUUID), "调用充值接口成功，但是返回金钱数是0:" + orderInfo.toString()));
					continue;
				}

				//给元宝
				CurrencyProcessor.instance.giveMoney(human, addBond, Currency.BOND, false, orderInfo.getMoneyLogReason(),
						orderInfo.toString(), true);

				//给红包钱
				int redMoney = (int)(addBond * Globals.getGameConstants().getChargeCountToRedEnvelopeRate());
				if (redMoney > 0) {
					CurrencyProcessor.instance.giveMoney(human, redMoney, Currency.RED_ENVELOPE, false, MoneyLogReason.GIVE_RED_MONEY_ON_CHARGE,
							LogUtils.genReasonText(MoneyLogReason.GIVE_RED_MONEY_ON_CHARGE, addBond, orderInfo.getGamepoints()), true);
				} else {
					Loggers.chargeLogger.warn("redMoney is less than 0!roleId=" + roleUUID + ";addBond=" + addBond + ";redMoney=" + redMoney);
				}
				
				human.snapChangedProperty(true);
//				// 发送成功消息
//				human.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_SUCCESS, "" + addBond);

				//根据充值模板Id，给玩家额外金子
				if (chargeTpl != null) {
					giveGiftBondOnCharge(chargeTpl.getId(), human);
				} else {
					// 记录日志
					Loggers.chargeLogger.warn("ChargeLogicalProcessor.iosAndroidCharge() chargeTpl is null,so do not give gift bond" + 
							" bond=" + addBond + ";roleUUID=" + roleUUID + ";redMoney=" + redMoney);
				}
				
				// 记录日志
				Loggers.chargeLogger.info("ChargeLogicalProcessor.iosAndroidCharge() content key=" + 
						LangConstants.GAME_CHARGE_DIAMOND_SUCCESS + " bond=" + addBond + ";roleUUID=" + roleUUID + ";redMoney=" + redMoney);

				// 处理任务兑换钻石
				PlayerChargeDiamondEvent _event = new PlayerChargeDiamondEvent(human, addBond, false);
				Globals.getEventService().fireEvent(_event);

				int bondAfter = (int)human.getBond();

				orderInfo.setAddBond(addBond);
				orderInfo.setBondBefore(bondBefore);
				orderInfo.setBondAfter(bondAfter);

				Globals.getLocalScribeService().sendScribeGameIncomeReport(human, orderInfo.getMoneyLogReason(), orderInfo);

				// 发送充值日志
				Globals.getLogService().sendChargeLog(human, orderInfo.getChargeLogReason(), orderInfo.toString(), Currency.BOND.getIndex(), bondBefore, bondAfter,
						amount, "", orderInfo.getOrderId());
				
				//汇报热云
				Globals.getReyunService().reportCharge(human.getPlayer(), rmb, addBond, orderInfo.getOrderId());
				//汇报dataEye
				Globals.getDataEyeService().chargeLog(human.getPlayer(), rmb, addBond, orderInfo.getOrderId());
			}
		} catch (Exception e) {
			if (CHARGE_LOGGER.isErrorEnabled()) {
				CHARGE_LOGGER.error(ErrorsUtil.error(GameErrorLogInfo.CHARGE_DIAMOND_INVOKE_FAIL,
						"#GS.IIosAndroidExchangeRechargeOperationCallback.afterCheckComplete", ""), e);
			}
		}
	}
	
	public int getBondByTplId(int tplId) {
		ChargeTemplate tpl = Globals.getTemplateCacheService().get(tplId, ChargeTemplate.class);
		if (tpl != null) {
			return tpl.getBond();
		}
		return 0;
	}
	
	/**
	 * 充值额外获得绑定元宝
	 * @param tplId
	 * @param human
	 */
	protected void giveGiftBondOnCharge(int tplId, Human human) {
		if (human == null || human.getBindIdBehaviorManager() == null) {
			Loggers.chargeLogger.error("huamn is null!tplId=" + tplId + "-chargefail6");
			return;
		}
		
		ChargeTemplate tpl = Globals.getTemplateCacheService().get(tplId, ChargeTemplate.class);
		if (tpl == null) {
			Loggers.chargeLogger.error("chargeTpl is null!tplId=" + tplId + ";roleId=" + human.getCharId() + "-chargefail7");
			return;
		}
		
		boolean isFirst = human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.CHARGE_RECORD, tplId);
		//行为记录
		human.getBindIdBehaviorManager().doBehavior(BindIdBehaviorTypeEnum.CHARGE_RECORD, tplId);
		
		//通知前台
		noticeChargeRecord(human);
		
		boolean hasFirst = tpl.getFirstSysBond() > 0;
		boolean hasGift = tpl.getGiftSysBond() > 0;
		if (!hasFirst && !hasGift) {
			return;
		}
		
		//根据玩家是否首冲，看给首冲还是给赠送
		if (hasFirst && isFirst) {
			//给首冲额外金子
			CurrencyProcessor.instance.giveMoney(human, tpl.getFirstSysBond(), Currency.SYS_BOND, false, 
					MoneyLogReason.CHARGE_FIRST_GIVE, MoneyLogReason.CHARGE_FIRST_GIVE.getReasonText(), true);
			human.snapChangedProperty(true);
//			//发送成功消息
//			human.sendSystemMessage(LangConstants.GAME_CHARGE_FIRST_GIVE, "" + tpl.getFirstSysBond());
		} else if (hasGift) {
			//给赠送金子
			CurrencyProcessor.instance.giveMoney(human, tpl.getGiftSysBond(), Currency.SYS_BOND, false, 
					MoneyLogReason.CHARGE_GIFT_GIVE, MoneyLogReason.CHARGE_GIFT_GIVE.getReasonText(), true);
			human.snapChangedProperty(true);
//			//发送成功消息
//			human.sendSystemMessage(LangConstants.GAME_CHARGE_GIFT_GIVE, "" + tpl.getGiftSysBond());
		}
	}
	
	/**
	 * 通知前台玩家充值记录变化
	 * @param human
	 */
	public void noticeChargeRecord(Human human) {
		if (human == null || human.getBindIdBehaviorManager() == null) {
			return;
		}
		
		List<Integer> rList = new ArrayList<Integer>();
		//将已充值的模板id通知前台
		for (Integer tid : Globals.getTemplateCacheService().getAll(ChargeTemplate.class).keySet()) {
			if (!human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.CHARGE_RECORD, tid)) {
				rList.add(tid);
			}
		}
		int[] arr = new int[rList.size()];
		for (int i = 0; i < rList.size(); i++) {
			arr[i] = rList.get(i);
		}
		human.sendMessage(new GCChargeRecord(arr));
	}
	
	/**
	 * 仅gm调用 TODO FIXME 上线时需要干掉，否则影响充值的数据
	 * @param human
	 * @param tplId
	 */
	public void gmCharge(Human human, int tplId) {
		//只有gm账号可用
		if (human.getPlayer().getPermission() != SharedConstants.ACCOUNT_ROLE_DEBUG) {
			return;
		}
		
		ChargeTemplate tpl = Globals.getTemplateCacheService().get(tplId, ChargeTemplate.class);
		if (tpl == null) {
			return;
		}
		int addBond = tpl.getBond();
		if (addBond <= 0) {
			return;
		}

		CurrencyProcessor.instance.giveMoney(human, addBond, Currency.SYS_BOND, false, 
				MoneyLogReason.DEBUG_CMD_GIVE, "debug-gmCharge", true);

//		// 发送成功消息
//		human.sendSystemMessage(LangConstants.GAME_CHARGE_DIAMOND_SUCCESS, "" + addBond);
		
		//根据充值模板Id，给玩家额外金子
		giveGiftBondOnCharge(tplId, human);
		
		human.snapChangedProperty(true);
		
		PlayerChargeDiamondEvent _event = new PlayerChargeDiamondEvent(human, addBond, true);
		Globals.getEventService().fireEvent(_event);
	}
	
}
