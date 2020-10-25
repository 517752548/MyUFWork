package com.imop.lj.gameserver.prize.handler;

import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.prize.msg.CGPrizeActivationcode;
import com.imop.lj.gameserver.prize.msg.CGPrizeGet;
import com.imop.lj.gameserver.prize.msg.CGPrizeList;

/**
 * 奖励处理器
 * 
 * 
 */
public class PrizeMessageHandler {

	/**
	 * 领取奖励 (平台奖励 gm补偿）
	 * 
	 * @param player
	 * @param cgPrizeGet
	 */
	public void handlePrizeGet(Player player, CGPrizeGet cgPrizeGet) {
		//XXX 暂时没有此功能，注掉
		return;
		
//		if(cgPrizeGet.getPrizeType() == PrizeDef.PRIZE_TYPE_GM){
//			PlayerGetUserPrize operation = new PlayerGetUserPrize(player, Integer.parseInt(cgPrizeGet.getPrizeId()));
//			Globals.getAsyncService().createOperationAndExecuteAtOnce(operation, player.getRoleUUID());
//		}else if(cgPrizeGet.getPrizeType() == PrizeDef.PRIZE_TYPE_PLATFORM){
//			if (Globals.getServerConfig().isTurnOnLocalInterface()) {
//				//TODO FIXME 暂时注掉平台奖励
////				PlayerGetPlatformPrize operation = new PlayerGetPlatformPrize(
////						player, cgPrizeGet.getUniqueId(), Integer.parseInt(cgPrizeGet.getPrizeId()));
////				Globals.getAsyncService().createOperationAndExecuteAtOnce(
////						operation, player.getRoleUUID());
//			} else {
//				Loggers.playerLogger.error("#PrizeMessageHandler#handlePrizeGet#isTurnOnLocalInterface is false!charId=" + player.getRoleUUID());
//			}
//		} else{
//			// TODO 其它情况再说，本版本不处理
//			return;
//		}
	}
	
	/**
	 * 查询平台奖励和gm补偿奖励
	 * 
	 * @param player
	 * @param cgPrizeList
	 */
	public void handlePrizeList(Player player, CGPrizeList cgPrizeList) {
		//XXX 暂时没有此功能，注掉
		return;
//		Globals.getPrizeService().sendPrizeListMsg(player);
	}

	/**
	 * 查询激活码
	 * 
	 * @param player
	 * @param cgPrizeActivationcode
	 */
	public void handlePrizeActivationcode(Player player,
			CGPrizeActivationcode cgPrizeActivationcode) {
//		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
//			Loggers.playerLogger.error("#PrizeMessageHandler#handlePrizeActivationcode#isTurnOnLocalInterface is false!charId=" + player.getRoleUUID());
//			return;
//		}
//		PlayerQueryActivationCode operation = new PlayerQueryActivationCode(
//				player, cgPrizeActivationcode.getActivationCode());
//		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,
//				player.getRoleUUID());
	}

	/**
	 * 查询平台奖励信息
	 * 
	 * @param player
	 * @param cgPrizePlatformList
	 */
	// public void handlePrizePlatformList(Player player,
	// CGPrizePlatformList cgPrizePlatformList) {
	// // 执行异步查询
	// PlayerQueryPlatformPrizes operation = new PlayerQueryPlatformPrizes(
	// player);
	// Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,
	// player.getRoleUUID());
	// }

	/**
	 * 领取平台补偿奖励
	 * 
	 * @param player
	 * @param cgPrizePlatformGet
	 */
	// public void handlePrizePlatformGet(Player player,
	// CGPrizePlatformGet cgPrizePlatformGet) {
	//
	// PlayerGetPlatformPrize operation = new PlayerGetPlatformPrize(player,
	// cgPrizePlatformGet.getUniqueId(),
	// cgPrizePlatformGet.getPrizeId());
	// Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,
	// player.getRoleUUID());
	//
	// }

	/**
	 * 查询GM补偿列表
	 * 
	 * @param player
	 * @param cgPrizeUserList
	 */
	// public void handlePrizeUserList(Player player,CGPrizeUserList
	// cgPrizeUserList) {
	// // 执行异步查询
	// PlayerQueryUserPrizes operation = new PlayerQueryUserPrizes(player);
	// Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,
	// player.getRoleUUID());
	// }

	/**
	 * 领取GM平台的补偿奖励
	 * 
	 * @param player
	 * @param cgPrizeUserGet
	 */
	// public void handlePrizeUserGet(Player player, CGPrizeUserGet
	// cgPrizeUserGet) {
	//
	// PlayerGetUserPrize operation = new PlayerGetUserPrize(player,
	// cgPrizeUserGet.getPrizeId());
	// Globals.getAsyncService().createOperationAndExecuteAtOnce(operation,
	// player.getRoleUUID());
	// }

//	/**
//	 * 领取连续登陆奖励
//	 * 
//	 * @param player
//	 * @param cgGetConloginPrize
//	 */
//	public void handleGetConloginPrize(Player player,
//			CGGetConloginPrize cgGetConloginPrize) {
//		Human human = player.getHuman();
////		// 已经过了连续登陆领奖期
////		if (!human.getContinuousLoginManager().canGetPrize()) {
////			player.sendErrorMessage(LangConstants.PRIZE_CONTINUOUS_LOGIN_PRIZE_OUTTIME);
////			return;
////		}
////		// 是否已经领取
////		if (human.getContinuousLoginManager().isPrize(
////				cgGetConloginPrize.getDay()) == 1) {
////			player.sendErrorMessage(LangConstants.PRIZE_CONTINUOUS_LOGIN_PRIZE_GETED);
////			return;
////		}
////
////		if (human.getContinuousLoginManager().getPrize(
////				cgGetConloginPrize.getDay())) {
////			// 领取奖励成功
////			human.sendMessage(new GCGetConloginPrize());
////		}
//
//	}

//	/**
//	 * 显示连续登陆模板
//	 * 
//	 * @param player
//	 * @param cgConloginPrizeList
//	 */
//	public void handleConloginPrizeList(Player player,
//			CGConloginPrizeList cgConloginPrizeList) {
//		// 显示面板道具信息
//
//		List<CommonItem> allConLoginItemInfo = new ArrayList<CommonItem>();
//		List<ContinuousLoginInfo> allConLoginInfo = new ArrayList<ContinuousLoginInfo>();
//		ContinuousLoginInfo continuousLoginInfo = null;
//		// 领取奖励状态
//		Map<Integer, Integer> conLoginMap = player.getHuman()
//				.getContinuousLoginManager().getConLoginMap();
//		CommonItemBuilder commonItemBuilder = new CommonItemBuilder();
//		Map<Integer, ContinuousLoginTemplate> allConLoginItemplate = player
//				.getHuman().getContinuousLoginManager().getTemplateMap();
//		for (ContinuousLoginTemplate conLoginTemplate : allConLoginItemplate
//				.values()) {
//			commonItemBuilder.bindItemTemplate(Globals.getItemService()
//					.getItemTempByTempId(conLoginTemplate.getItemId()),
//					conLoginTemplate.getItemCount());
//			allConLoginItemInfo.add(commonItemBuilder.buildCommonItem());
//			// 已经领取几天，
//			if (conLoginTemplate.getId() <= player.getHuman()
//					.getContinuousLoginManager().getCreatedDays()) {
//				continuousLoginInfo = new ContinuousLoginInfo();
//				continuousLoginInfo.setDay(conLoginTemplate.getId());
//				continuousLoginInfo.setStatus(conLoginMap.get(conLoginTemplate
//						.getId()));
//				allConLoginInfo.add(continuousLoginInfo);
//			}
//		}
//		// 是否领奖
//
//		GCConloginPrizeList gcConloginPrizeList = new GCConloginPrizeList();
//
//		if (allConLoginItemInfo.size() == 0) {
//			gcConloginPrizeList.setPrizeCommonItem(new CommonItem[0]);
//			gcConloginPrizeList.setPrizeGetStatus(new ContinuousLoginInfo[0]);
//		} else {
//			gcConloginPrizeList.setPrizeCommonItem(allConLoginItemInfo
//					.toArray(new CommonItem[allConLoginItemInfo.size()]));
//			gcConloginPrizeList.setPrizeGetStatus(allConLoginInfo
//					.toArray(new ContinuousLoginInfo[allConLoginInfo.size()]));
//		}
//		// 发送面板需要的道具信息
//		player.sendMessage(gcConloginPrizeList);
//	}
}
